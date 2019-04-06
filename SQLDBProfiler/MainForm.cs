// ----------------------------------------------------------------------
// <copyright file="MainForm.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using System.Xml;

    /// <summary>
    /// The Main Form
    /// </summary>
    public partial class MainForm : Form
    {
        #region private/internal fields

        /// <summary>
        /// The cached list
        /// </summary>
        internal readonly List<ListViewItem> CachedListView = new List<ListViewItem>(1024);

        /// <summary>
        /// The Trace Utilities
        /// </summary>
        private readonly TraceUtilities traceUtilities = new TraceUtilities();

        /// <summary>
        /// The SQL Command
        /// </summary>
        private readonly SqlCommand command = new SqlCommand();

        /// <summary>
        /// The event started
        /// </summary>
        private readonly ProfilerEvent eventStarted = new ProfilerEvent();

        /// <summary>
        /// The event stopped
        /// </summary>
        private readonly ProfilerEvent eventStopped = new ProfilerEvent();

        /// <summary>
        /// The event paused
        /// </summary>
        private readonly ProfilerEvent eventPaused = new ProfilerEvent();

        /// <summary>
        /// The item by SQL
        /// </summary>
        private readonly Dictionary<string, ListViewItem> itemBySql = new Dictionary<string, ListViewItem>();

        /// <summary>
        /// The Raw Trace Reader
        /// </summary>
        private RawTraceReader traceReader;

        /// <summary>
        /// The SQL Connection
        /// </summary>
        private SqlConnection connection;

        /// <summary>
        /// The Thread
        /// </summary>
        private Thread thread;

        /// <summary>
        /// The need stop
        /// </summary>
        private bool objectThread = true;

        /// <summary>
        /// The profiling state
        /// </summary>
        private ProfilingStateEnum profilingState;

        /// <summary>
        /// The event count
        /// </summary>
        private int eventCount;

        /// <summary>
        /// The server name
        /// </summary>
        private string servername = string.Empty;

        /// <summary>
        /// The user name
        /// </summary>
        private string userName = string.Empty;

        /// <summary>
        /// The user password
        /// </summary>
        private string userPassword = string.Empty;

        /// <summary>
        /// The maximum events
        /// </summary>
        private int maxEvents = 1000;

        /// <summary>
        /// The list view events
        /// </summary>
        private ListViewNF listviewEvents;

        /// <summary>
        /// The events queue
        /// </summary>
        private Queue<ProfilerEvent> eventsQueue = new Queue<ProfilerEvent>(10);

        /// <summary>
        /// The auto start
        /// </summary>
        private bool autostart;

        /// <summary>
        /// Don't update source flag
        /// </summary>
        private bool dontUpdateSource;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();
            this.InitListView();
            this.Text = "SQL DB Profiler v2.4";
            this.LastPosition = -1;
            this.LastPattern = string.Empty;

            this.edPassword.TextBox.PasswordChar = '*';
            this.servername = Properties.Settings.Default.ServerName;
            this.userName = Properties.Settings.Default.UserName;
            this.edDuration.Text = Properties.Settings.Default.Duration.ToString(CultureInfo.InvariantCulture);
            this.edDatabase.Text = Properties.Settings.Default.Database.ToString(CultureInfo.InvariantCulture);
            this.edLogin.Text = Properties.Settings.Default.LoginName.ToString(CultureInfo.InvariantCulture);
            this.edText.Text = Properties.Settings.Default.TextData.ToString(CultureInfo.InvariantCulture);
            this.edNotText.Text = Properties.Settings.Default.NotTextData.ToString(CultureInfo.InvariantCulture);

            int eventMask = Properties.Settings.Default.EventMask;

            this.mnExistingConnection.Checked = (eventMask & 1) != 0;
            this.mnLoginLogout.Checked = (eventMask & 2) != 0;
            this.mnRPCStarting.Checked = (eventMask & 4) != 0;
            this.mnRPCCompleted.Checked = (eventMask & 8) != 0;
            this.mnBatchStarting.Checked = (eventMask & 16) != 0;
            this.mnBatchCompleted.Checked = (eventMask & 32) != 0;

            this.ParseCommandLine();
            this.edServer.Text = this.servername;
            this.edUser.Text = this.userName;
            this.edPassword.Text = this.userPassword;
            this.tbAuth.SelectedIndex = string.IsNullOrEmpty(this.userName) ? 0 : 1;
            if (this.autostart)
            {
                this.StartProfiling();
            }

            this.UpdateButtons();
        }

        #endregion

        #region private enumeration

        /// <summary>
        /// Profiling State Enumeration
        /// </summary>
        private enum ProfilingStateEnum
        {
            /// <summary>
            /// The profiling state stopped
            /// </summary>
            profilingStateStopped,

            /// <summary>
            /// The profiling state profiling
            /// </summary>
            profilingStateProfiling,

            /// <summary>
            /// The profiling state paused
            /// </summary>
            profilingStatePaused
        }

        #endregion

        #region internal properties

        /// <summary>
        /// Gets or sets the last position integer.
        /// </summary>
        /// <value>
        /// The last position integer.
        /// </value>
        internal int LastPosition { get; set; }

        /// <summary>
        /// Gets or sets the last pattern string.
        /// </summary>
        /// <value>
        /// The last pattern string.
        /// </value>
        internal string LastPattern { get; set; }

        #endregion

        #region internal methods

        /// <summary>
        /// Focuses the list view item.
        /// </summary>
        /// <param name="listViewItem">The list view item.</param>
        internal void FocusListViewItem(ListViewItem listViewItem)
        {
            listViewItem.Focused = true;
            listViewItem.Selected = true;
            this.ListView1_ItemSelectionChanged_1(this.listviewEvents, null);
            this.listviewEvents.EnsureVisible(this.listviewEvents.Items.IndexOf(listViewItem));
        }

        /// <summary>
        /// Selects all events.
        /// </summary>
        /// <param name="select">if set to <c>true</c> [select].</param>
        internal void SelectAllEvents(bool select)
        {
            lock (this.CachedListView)
            {
                this.listviewEvents.BeginUpdate();
                this.dontUpdateSource = true;
                try
                {
                    if (select)
                    {
                        this.LastPosition = 0;
                        this.CachedListView[0].Selected = true;
                        this.CachedListView[0].Focused = true;
                    }

                    foreach (ListViewItem lv in this.CachedListView)
                    {
                        lv.Selected = select;
                    }
                }
                finally
                {
                    this.dontUpdateSource = false;
                    this.UpdateSourceBox();
                    this.listviewEvents.EndUpdate();
                }
            }
        }

        /// <summary>
        /// Performs the find.
        /// </summary>
        internal void PerformFind()
        {
            if (string.IsNullOrEmpty(this.LastPattern))
            {
                return;
            }

            for (int i = this.LastPosition = this.listviewEvents.Items.IndexOf(this.listviewEvents.FocusedItem) + 1; i < this.CachedListView.Count; i++)
            {
                ListViewItem listViewItem = this.CachedListView[i];
                ProfilerEvent profilerEvent = (ProfilerEvent)listViewItem.Tag;

                if (profilerEvent.TextData.ToLower().Contains(this.LastPattern.ToLower()))
                {
                    listViewItem.Focused = true;
                    this.LastPosition = i;
                    this.SelectAllEvents(false);
                    this.FocusListViewItem(listViewItem);
                    return;
                }
            }

            MessageBox.Show(string.Format("Failed to find \"{0}\". Searched to the end of data. ", this.LastPattern), "SQL DBProfiler", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region page events

        /// <summary>
        /// Handles the Load event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            return;
        }

        /// <summary>
        /// Handles the FormClosing event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.profilingState == ProfilingStateEnum.profilingStatePaused || this.profilingState == ProfilingStateEnum.profilingStateProfiling)
            {
                this.StopProfiling();
            }
        }

        /// <summary>
        /// Handles the Click event of the toolStripButtonStartProfiling control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ToolStripButtonStartProfiling_Click(object sender, EventArgs e)
        {
            this.StartProfiling();
        }

        /// <summary>
        /// Handles the Click event of the tbPause control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ToolStripButtonPause_Click(object sender, EventArgs e)
        {
            this.PauseProfiling();
        }

        /// <summary>
        /// Handles the Click event of the toolStripButtonStopProfiling control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ToolStripButtonStopProfiling_Click(object sender, EventArgs e)
        {
            this.StopProfiling();
        }

        /// <summary>
        /// Handles the 1 event of the toolStripButtonClearCache control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ToolStripButtonClearCache_Click(object sender, EventArgs e)
        {
            this.ClearTrace();
        }

        /// <summary>
        /// Handles the Click event of the toolStripButtonFilters control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ToolStripButtonFilters_Click(object sender, EventArgs e)
        {
            this.panelFilters.Visible = !this.panelFilters.Visible;
        }

        /// <summary>
        /// Handles the Click event of the buttonCloseFilters control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonCloseFilters_Click(object sender, EventArgs e)
        {
            this.panelFilters.Visible = false;
        }

        /// <summary>
        /// The events on virtual items selection range changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="listViewVirtualItemsSelectionRangeChangedEventArgs">The <see cref="ListViewVirtualItemsSelectionRangeChangedEventArgs"/> instance containing the event data.</param>
        private void LvEventsOnVirtualItemsSelectionRangeChanged(object sender, ListViewVirtualItemsSelectionRangeChangedEventArgs listViewVirtualItemsSelectionRangeChangedEventArgs)
        {
            this.UpdateSourceBox();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the lvEvents control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void LvEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateSourceBox();
        }

        /// <summary>
        /// Handles the ColumnClick event of the lvEvents control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ColumnClickEventArgs"/> instance containing the event data.</param>
        private void LvEvents_ColumnClick(object sender, ColumnClickEventArgs e)
        {
        }

        /// <summary>
        /// Handles the Click event of the Select Events control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CbSelectEvents_Click(object sender, EventArgs e)
        {
            this.panelFilters.Visible = false;
        }

        /// <summary>
        /// New event arrived.
        /// </summary>
        /// <param name="profilerEvent">The event</param>
        /// <param name="last">if set to <c>true</c> [last].</param>
        private void NewEventArrived(ProfilerEvent profilerEvent, bool last)
        {
            {
                this.eventCount++;
                string caption;
                if (profilerEvent == this.eventStarted)
                {
                    caption = "Trace started";
                }
                else
                {
                    if (profilerEvent == this.eventPaused)
                    {
                        caption = "Trace paused";
                    }
                    else
                    {
                        if (profilerEvent == this.eventStopped)
                        {
                            caption = "Trace stopped";
                        }
                        else
                        {
                            caption = ProfilerEvents.Names[profilerEvent.EventClass];
                        }
                    }
                }

                ListViewItem listViewItem = new ListViewItem(caption);

                string textData = profilerEvent.TextData;
                string databaseName = profilerEvent.DatabaseName;
                listViewItem.SubItems.AddRange(new[] 
                { 
                    this.eventCount.ToString(CultureInfo.InvariantCulture), 
                    databaseName, 
                    textData, 
                    profilerEvent.LoginName, 
                    profilerEvent.CPU.ToString("#,0", CultureInfo.InvariantCulture), 
                    profilerEvent.Reads.ToString("#,0", CultureInfo.InvariantCulture), 
                    profilerEvent.Writes.ToString("#,0", CultureInfo.InvariantCulture), 
                    (profilerEvent.Duration / 1000).ToString("#,0"), 
                    profilerEvent.SPID.ToString(CultureInfo.InvariantCulture), 
                    string.Empty, 
                    string.Empty 
                });

                listViewItem.Tag = profilerEvent;
                this.CachedListView.Add(listViewItem);

                if (last)
                {
                    this.listviewEvents.VirtualListSize = this.CachedListView.Count;
                    this.listviewEvents.SelectedIndices.Clear();
                    if (this.toolstripButtonScroll.Checked)
                    {
                        this.FocusListViewItem(this.listviewEvents.Items[this.CachedListView.Count - 1]);
                    }

                    this.listviewEvents.Invalidate(listViewItem.Bounds);
                }
            }
        }

        /// <summary>
        /// Handles the 1 event of the listView1_ItemSelectionChanged control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ListViewItemSelectionChangedEventArgs"/> instance containing the event data.</param>
        private void ListView1_ItemSelectionChanged_1(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            this.UpdateSourceBox();
        }

        /// <summary>
        /// Handles the RetrieveVirtualItem event of the lvEvents control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RetrieveVirtualItemEventArgs"/> instance containing the event data.</param>
        private void LvEvents_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            e.Item = this.CachedListView[e.ItemIndex];
        }

        /// <summary>
        /// Handles the KeyDown event of the lvEvents control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void LvEvents_KeyDown(object sender, KeyEventArgs e)
        {
        }

        /// <summary>
        /// Handles the Tick event of the timer1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            Queue<ProfilerEvent> saved;
            lock (this)
            {
                saved = this.eventsQueue;
                this.eventsQueue = new Queue<ProfilerEvent>(10);
            }

            lock (this.CachedListView)
            {
                while (0 != saved.Count)
                {
                    this.NewEventArrived(saved.Dequeue(), 0 == saved.Count);
                }

                if (this.CachedListView.Count > this.maxEvents)
                {
                    while (this.CachedListView.Count > this.maxEvents)
                    {
                        this.CachedListView.RemoveAt(0);
                    }

                    this.listviewEvents.VirtualListSize = this.CachedListView.Count;
                    this.listviewEvents.Invalidate();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the existingConnectionsToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ExistingConnectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;
            this.UpdateButtons();
        }

        /// <summary>
        /// Handles the Selected Index Changed event of the Authentication control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TbAuth_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateButtons();
        }

        /// <summary>
        /// Handles the Click event of the copySelectedToClipboardToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CopySelectedToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CopyEventsToClipboard(true);
        }

        /// <summary>
        /// Handles the Click event of the clearTraceWindowToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ClearTraceWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ClearTrace();
        }

        /// <summary>
        /// Handles the Click event of the extractAllEventsToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ExtractAllEventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CopyEventsToClipboard(false);
        }

        /// <summary>
        /// Handles the Click event of the extractSelectedEventsToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ExtractSelectedEventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CopyEventsToClipboard(true);
        }

        /// <summary>
        /// Handles the Click event of the startTraceToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void StartTraceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.StartProfiling();
        }

        /// <summary>
        /// Handles the Click event of the pauseTraceToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void PauseTraceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.PauseProfiling();
        }

        /// <summary>
        /// Handles the Click event of the stopTraceToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void StopTraceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.StopProfiling();
        }

        /// <summary>
        /// Handles the Click event of the findToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DoFind();
        }

        /// <summary>
        /// Handles the Click event of the selectAllToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listviewEvents.Focused && (this.profilingState != ProfilingStateEnum.profilingStateProfiling))
            {
                this.SelectAllEvents(true);
            }
            else
            {
                if (this.reTextData.Focused)
                {
                    this.reTextData.SelectAll();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the findNextToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FindNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.profilingState == ProfilingStateEnum.profilingStateProfiling)
            {
                MessageBox.Show("You cannot find when trace is running", "SQL DBProfiler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.SelectAllEvents(true);
            this.PerformFind();
        }

        /// <summary>
        /// Handles the Click event of the copyAllToClipboardToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CopyAllToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CopyEventsToClipboard(false);
        }

        /// <summary>
        /// Handles the Click event of the saveAllEventsToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SaveAllEventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SaveEventsToCsvFile();
        }

        /// <summary>
        /// Handles the Click event of the exitToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region private methods

        /// <summary>
        /// Parses the command line.
        /// </summary>
        private void ParseCommandLine()
        {
            string[] args = Environment.GetCommandLineArgs();
            int i = 1;
            while (i < args.Length)
            {
                string ep = i + 1 < args.Length ? args[i + 1] : string.Empty;
                switch (args[i].ToLower())
                {
                    case "-s":
                    case "-server":
                        this.servername = ep;
                        i++;
                        break;
                    case "-u":
                    case "-user":
                        this.userName = ep;
                        i++;
                        break;
                    case "-p":
                    case "-password":
                        this.userPassword = ep;
                        i++;
                        break;
                    case "-m":
                    case "-maxevents":
                        if (!int.TryParse(ep, out this.maxEvents))
                        {
                            this.maxEvents = 1000;
                        }

                        break;
                    case "-d":
                    case "-duration":
                        int d;
                        if (int.TryParse(ep, out d))
                        {
                            this.edDuration.Text = d.ToString(CultureInfo.InvariantCulture);
                        }

                        break;
                    case "-database":
                        this.edDatabase.Text = ep;
                        break;
                    case "-login":
                        this.edLogin.Text = ep;
                        break;
                    case "-text":
                        this.edText.Text = ep;
                        break;
                    case "-nottext":
                        this.edNotText.Text = ep;
                        break;
                    case "-start":
                        this.autostart = true;
                        break;
                }

                i++;
            }

            if (this.servername.Length == 0)
            {
                this.servername = @".\sqlSQL DB";
            }
        }

        /// <summary>
        /// Updates the buttons.
        /// </summary>
        private void UpdateButtons()
        {
            this.toolstripButtonStart.Enabled = this.profilingState == ProfilingStateEnum.profilingStateStopped || this.profilingState == ProfilingStateEnum.profilingStatePaused;
            this.startTraceToolStripMenuItem.Enabled = this.toolstripButtonStart.Enabled;
            this.toolstripButtonStop.Enabled = this.profilingState == ProfilingStateEnum.profilingStatePaused || this.profilingState == ProfilingStateEnum.profilingStateProfiling;
            this.stopTraceToolStripMenuItem.Enabled = this.toolstripButtonStop.Enabled;
            this.toolstripButtonPause.Enabled = this.profilingState == ProfilingStateEnum.profilingStateProfiling;
            this.pauseTraceToolStripMenuItem.Enabled = this.toolstripButtonPause.Enabled;
            this.timer1.Enabled = this.profilingState == ProfilingStateEnum.profilingStateProfiling;
            this.tbAuth.Enabled = this.profilingState == ProfilingStateEnum.profilingStateStopped;

            this.toolStripButtonFilters.Enabled = this.profilingState == ProfilingStateEnum.profilingStateStopped;
            this.edServer.Enabled = this.profilingState == ProfilingStateEnum.profilingStateStopped;
            this.edUser.Enabled = this.edServer.Enabled && (this.tbAuth.SelectedIndex == 1);
            this.edPassword.Enabled = this.edServer.Enabled && (this.tbAuth.SelectedIndex == 1);
            this.cbSelectEvents.Enabled = this.edServer.Enabled;
            this.mnBatchStarting.Enabled = this.mnBatchCompleted.Enabled;
            this.mnExistingConnection.Enabled = this.mnBatchCompleted.Enabled;
            this.mnRPCCompleted.Enabled = this.mnBatchCompleted.Enabled;
            this.mnLoginLogout.Enabled = this.mnBatchCompleted.Enabled;
            this.mnRPCStarting.Enabled = this.mnBatchCompleted.Enabled;
        }

        /// <summary>
        /// Initiates the LV.
        /// </summary>
        private void InitListView()
        {
            this.listviewEvents = new ListViewNF
            {
                Dock = DockStyle.Fill,
                Location = new System.Drawing.Point(0, 0),
                Name = "lvEvents",
                Size = new System.Drawing.Size(979, 297),
                TabIndex = 0,
                VirtualMode = true,
                UseCompatibleStateImageBehavior = false,
                BorderStyle = BorderStyle.None,
                FullRowSelect = true,
                View = View.Details,
                GridLines = true,
                HideSelection = false,
                MultiSelect = false,
                AllowColumnReorder = false
            };

            this.listviewEvents.RetrieveVirtualItem += this.LvEvents_RetrieveVirtualItem;
            this.listviewEvents.KeyDown += this.LvEvents_KeyDown;
            this.listviewEvents.ItemSelectionChanged += this.ListView1_ItemSelectionChanged_1;
            this.listviewEvents.Columns.Add("Event Class", 122);
            this.listviewEvents.Columns.Add("No.", 53).TextAlign = HorizontalAlignment.Center;
            this.listviewEvents.Columns.Add("Database", 120);
            this.listviewEvents.Columns.Add("Text Data", 400);
            this.listviewEvents.Columns.Add("Login Name", 79);
            this.listviewEvents.Columns.Add("CPU", 82).TextAlign = HorizontalAlignment.Right;
            this.listviewEvents.Columns.Add("Reads", 78).TextAlign = HorizontalAlignment.Right;
            this.listviewEvents.Columns.Add("Writes", 78).TextAlign = HorizontalAlignment.Right;
            this.listviewEvents.Columns.Add("Duration", 82).TextAlign = HorizontalAlignment.Right;
            this.listviewEvents.Columns.Add("SPID", 80).TextAlign = HorizontalAlignment.Right;

            this.listviewEvents.ColumnClick += this.LvEvents_ColumnClick;
            this.listviewEvents.SelectedIndexChanged += this.LvEvents_SelectedIndexChanged;
            this.listviewEvents.VirtualItemsSelectionRangeChanged += this.LvEventsOnVirtualItemsSelectionRangeChanged;
            this.listviewEvents.MultiSelect = true;
            this.listviewEvents.ContextMenuStrip = this.contextMenuStrip1;
            this.splitContainer1.Panel1.Controls.Add(this.listviewEvents);
        }

        /// <summary>
        /// Profilers the thread.
        /// </summary>
        /// <param name="state">The state.</param>
        private void ProfilerThread(object state)
        {
            while (!this.objectThread && this.traceReader.TraceIsActive)
            {
                ProfilerEvent evt = this.traceReader.Next();
                if (evt != null)
                {
                    lock (this)
                    {
                        this.eventsQueue.Enqueue(evt);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns>connection string</returns>
        private SqlConnection GetConnection()
        {
            return new SqlConnection
                       {
                           ConnectionString =
                           this.tbAuth.SelectedIndex == 0 ? string.Format(
                                    @"Data Source = {0}; Initial Catalog = master; Integrated Security=SSPI;Application Name=SQL DB Profiler", 
                                    this.edServer.Text)
                           : string.Format(
                                    @"Data Source={0};Initial Catalog=master;User Id={1};Password={2};;Application Name=SQL DB Profiler", 
                                    this.edServer.Text, 
                                    this.edUser.Text, 
                                    this.edPassword.Text)
                       };
        }

        /// <summary>
        /// Starts the profiling.
        /// </summary>
        private void StartProfiling()
        {
            try
            {
                this.panelFilters.Visible = false;
                if (this.profilingState == ProfilingStateEnum.profilingStatePaused)
                {
                    this.ResumeProfiling();
                    return;
                }

                if (this.connection != null && this.connection.State == ConnectionState.Open)
                {
                    this.connection.Close();
                }

                this.eventCount = 0;
                this.connection = this.GetConnection();
                this.connection.Open();
                this.traceReader = new RawTraceReader(this.connection);

                this.traceReader.CreateTrace();

                if (true)
                {
                    if (this.mnLoginLogout.Checked)
                    {
                        this.traceReader.SetEvent(
                            ProfilerEvents.SecurityAudit.AuditLogin,
                            ProfilerEventColumns.TextData,
                            ProfilerEventColumns.LoginName,
                            ProfilerEventColumns.SPID);
                    }

                    if (this.mnExistingConnection.Checked)
                    {
                        this.traceReader.SetEvent(
                            ProfilerEvents.Sessions.ExistingConnection,
                            ProfilerEventColumns.TextData,
                            ProfilerEventColumns.SPID);
                    }

                    if (this.mnBatchCompleted.Checked)
                    {
                        this.traceReader.SetEvent(
                            ProfilerEvents.TSQL.SQLBatchCompleted,
                            ProfilerEventColumns.TextData,
                            ProfilerEventColumns.LoginName,
                            ProfilerEventColumns.CPU,
                            ProfilerEventColumns.Reads,
                            ProfilerEventColumns.Writes,
                            ProfilerEventColumns.Duration,
                            ProfilerEventColumns.DatabaseName,
                            ProfilerEventColumns.SPID,
                            ProfilerEventColumns.StartTime);
                    }

                    if (this.mnBatchStarting.Checked)
                    {
                        this.traceReader.SetEvent(
                            ProfilerEvents.TSQL.SQLBatchStarting,
                            ProfilerEventColumns.TextData,
                            ProfilerEventColumns.LoginName,
                            ProfilerEventColumns.DatabaseName,
                            ProfilerEventColumns.SPID);
                    }

                    if (this.mnRPCStarting.Checked)
                    {
                        this.traceReader.SetEvent(
                            ProfilerEvents.StoredProcedures.RPCStarting,
                            ProfilerEventColumns.TextData,
                            ProfilerEventColumns.LoginName,
                            ProfilerEventColumns.DatabaseName,
                            ProfilerEventColumns.SPID);
                    }
                }

                if (this.mnRPCCompleted.Checked)
                {
                    this.traceReader.SetEvent(
                        ProfilerEvents.StoredProcedures.RPCCompleted,
                        ProfilerEventColumns.TextData,
                        ProfilerEventColumns.LoginName,
                        ProfilerEventColumns.CPU,
                        ProfilerEventColumns.Reads,
                        ProfilerEventColumns.Writes,
                        ProfilerEventColumns.Duration,
                        ProfilerEventColumns.DatabaseName,
                        ProfilerEventColumns.SPID);
                }

                int dur;
                if (int.TryParse(this.edDuration.Text, out dur))
                {
                    if (dur > 0)
                    {
                        this.traceReader.SetFilter(ProfilerEventColumns.Duration, LogicalOperators.AND, ComparisonOperators.GreaterThanOrEqual, dur * 1000);
                    }

                    Properties.Settings.Default.Duration = dur >= 0 ? dur : 0;
                }

                this.command.Connection = this.connection;
                this.command.CommandTimeout = 0;
                this.traceReader.SetFilter(ProfilerEventColumns.ApplicationName, LogicalOperators.AND, ComparisonOperators.NotLike, "SQL DB Profiler");

                if (this.edDatabase.Text != string.Empty)
                {
                    this.traceReader.SetFilter(ProfilerEventColumns.DatabaseName, LogicalOperators.AND, ComparisonOperators.Like, this.edDatabase.Text);
                }

                if (this.edLogin.Text != string.Empty)
                {
                    this.traceReader.SetFilter(ProfilerEventColumns.LoginName, LogicalOperators.AND, ComparisonOperators.Like, this.edLogin.Text);
                }

                if (this.edText.Text != string.Empty)
                {
                    this.traceReader.SetFilter(ProfilerEventColumns.TextData, LogicalOperators.AND, ComparisonOperators.Like, this.edText.Text);
                }

                if (this.edNotText.Text != string.Empty)
                {
                    this.traceReader.SetFilter(ProfilerEventColumns.TextData, LogicalOperators.AND, ComparisonOperators.NotLike, this.edNotText.Text);
                }

                this.traceReader.SetFilter(ProfilerEventColumns.TextData, LogicalOperators.AND, ComparisonOperators.NotLike, "%sp_reset_connection%");

                this.CachedListView.Clear();
                this.eventsQueue.Clear();
                this.itemBySql.Clear();

                this.listviewEvents.VirtualListSize = 0;
                this.StartProfilerThread();

                this.servername = this.edServer.Text;
                this.userName = this.edUser.Text;

                Properties.Settings.Default.ServerName = this.servername;
                Properties.Settings.Default.UserName = this.tbAuth.SelectedIndex == 0 ? string.Empty : this.userName;

                int eventMask = 0;
                if (this.mnExistingConnection.Checked)
                {
                    eventMask |= 1;
                }

                if (this.mnLoginLogout.Checked)
                {
                    eventMask |= 2;
                }

                if (this.mnRPCStarting.Checked)
                {
                    eventMask |= 4;
                }

                if (this.mnRPCCompleted.Checked)
                {
                    eventMask |= 8;
                }

                if (this.mnBatchStarting.Checked)
                {
                    eventMask |= 16;
                }

                if (this.mnBatchCompleted.Checked)
                {
                    eventMask |= 32;
                }

                Properties.Settings.Default.EventMask = eventMask;
                Properties.Settings.Default.Duration = int.Parse(this.edDuration.Text);
                Properties.Settings.Default.Database = this.edDatabase.Text;
                Properties.Settings.Default.LoginName = this.edLogin.Text;
                Properties.Settings.Default.TextData = this.edText.Text;
                Properties.Settings.Default.NotTextData = this.edNotText.Text;
                Properties.Settings.Default.Save();

                this.UpdateButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Starts the profiler thread.
        /// </summary>
        private void StartProfilerThread()
        {
            if (this.traceReader != null)
            {
                this.traceReader.Close();
            }

            this.traceReader.StartTrace();
            this.thread = new Thread(this.ProfilerThread) { IsBackground = true, Priority = ThreadPriority.Lowest };
            this.objectThread = false;
            this.profilingState = ProfilingStateEnum.profilingStateProfiling;
            this.NewEventArrived(this.eventStarted, true);
            this.thread.Start();
        }

        /// <summary>
        /// Pauses the profiling.
        /// </summary>
        private void PauseProfiling()
        {
            using (SqlConnection connection = this.GetConnection())
            {
                connection.Open();
                this.traceReader.StopTrace(connection);
                connection.Close();
            }

            this.profilingState = ProfilingStateEnum.profilingStatePaused;
            this.NewEventArrived(this.eventPaused, true);
            this.UpdateButtons();
        }

        /// <summary>
        /// Resumes the profiling.
        /// </summary>
        private void ResumeProfiling()
        {
            this.StartProfilerThread();
            this.UpdateButtons();
        }

        /// <summary>
        /// Stops the profiling.
        /// </summary>
        private void StopProfiling()
        {
            this.toolstripButtonStop.Enabled = false;
            using (SqlConnection cn = this.GetConnection())
            {
                cn.Open();
                this.traceReader.StopTrace(cn);
                this.traceReader.CloseTrace(cn);
                cn.Close();
            }

            this.objectThread = true;
            if (this.thread.IsAlive)
            {
                this.thread.Abort();
            }

            this.thread.Join();
            this.profilingState = ProfilingStateEnum.profilingStateStopped;
            this.NewEventArrived(this.eventStopped, true);
            this.UpdateButtons();
        }

        /// <summary>
        /// Updates the source box.
        /// </summary>
        private void UpdateSourceBox()
        {
            if (this.dontUpdateSource)
            {
                return;
            }

            StringBuilder stringBuilder = new StringBuilder();
            foreach (int i in this.listviewEvents.SelectedIndices)
            {
                ListViewItem listViewItem = this.CachedListView[i];
                if (listViewItem.SubItems[1].Text != string.Empty)
                {
                    stringBuilder.AppendFormat("{0}\r\ngo\r\n", listViewItem.SubItems[3].Text);
                }
            }

            this.traceUtilities.FillRichEdit(this.reTextData, stringBuilder.ToString());
        }

        /// <summary>
        /// Clears the trace.
        /// </summary>
        private void ClearTrace()
        {
            lock (this.listviewEvents)
            {
                this.CachedListView.Clear();
                this.itemBySql.Clear();
                this.listviewEvents.VirtualListSize = 0;
                this.ListView1_ItemSelectionChanged_1(this.listviewEvents, null);
                this.listviewEvents.Invalidate();
            }
        }

        /// <summary>
        /// Copies the events to clipboard.
        /// </summary>
        /// <param name="copySelected">if set to <c>true</c> [copy selected].</param>
        private void CopyEventsToClipboard(bool copySelected)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode root = xmlDoc.CreateElement("events");
            lock (this.CachedListView)
            {
                if (copySelected)
                {
                    foreach (int i in this.listviewEvents.SelectedIndices)
                    {
                        this.CreateEventRow((ProfilerEvent)this.CachedListView[i].Tag, root);
                    }
                }
                else
                {
                    foreach (var i in this.CachedListView)
                    {
                        this.CreateEventRow((ProfilerEvent)i.Tag, root);
                    }
                }
            }

            xmlDoc.AppendChild(root);
            xmlDoc.PreserveWhitespace = true;
            using (StringWriter writer = new StringWriter())
            {
                XmlTextWriter textWriter = new XmlTextWriter(writer) { Formatting = Formatting.Indented };
                xmlDoc.Save(textWriter);
                Clipboard.SetText(writer.ToString());
            }

            MessageBox.Show(
                "Event(s) data copied to clipboard",
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Creates the XML event row.
        /// </summary>
        /// <param name="profilerEvent">The event</param>
        /// <param name="root">The XML root</param>
        private void CreateEventRow(ProfilerEvent profilerEvent, XmlNode root)
        {
            XmlNode row = root.OwnerDocument.CreateElement("event");
            this.NewAttribute(row, "EventClass", profilerEvent.EventClass.ToString(CultureInfo.InvariantCulture));
            this.NewAttribute(row, "CPU", profilerEvent.CPU.ToString(CultureInfo.InvariantCulture));
            this.NewAttribute(row, "Reads", profilerEvent.Reads.ToString(CultureInfo.InvariantCulture));
            this.NewAttribute(row, "Writes", profilerEvent.Writes.ToString(CultureInfo.InvariantCulture));
            this.NewAttribute(row, "Duration", profilerEvent.Duration.ToString(CultureInfo.InvariantCulture));
            this.NewAttribute(row, "SPID", profilerEvent.SPID.ToString(CultureInfo.InvariantCulture));
            this.NewAttribute(row, "LoginName", profilerEvent.LoginName);
            this.NewAttribute(row, "DatabasName", profilerEvent.DatabaseName);
            row.InnerText = profilerEvent.TextData;
            root.AppendChild(row);
        }

        /// <summary>
        /// New XML attribute.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        private void NewAttribute(XmlNode node, string name, string value)
        {
            XmlAttribute attr = node.OwnerDocument.CreateAttribute(name);
            attr.Value = value;
            node.Attributes.Append(attr);
        }

        /// <summary>
        /// Saves the events to CSV file.
        /// </summary>
        private void SaveEventsToCsvFile()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.DefaultExt = "csv";
            saveFileDialog1.Filter = "CSV File|*.csv|Test File|*.txt";
            saveFileDialog1.Title = "Save CSV File";
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != string.Empty)
            {
                using (StreamWriter objWriter = new StreamWriter(saveFileDialog1.FileName, false))
                {
                    lock (this.CachedListView)
                    {
                        objWriter.WriteLine("Event Class,CPU,Reads,Writes,Duration,SPID,Login Name,Database,Text Data");

                        foreach (var i in this.CachedListView)
                        {
                            objWriter.WriteLine(this.CreateCsvRow((ProfilerEvent)i.Tag));
                        }
                    }
                }

                MessageBox.Show("Event(s) data saved to CSV file", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Creates the CSV row.
        /// </summary>
        /// <param name="profilerEvent">The event</param>
        /// <returns>CSV row string</returns>
        private string CreateCsvRow(ProfilerEvent profilerEvent)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat("{0},", ProfilerEvents.Names[profilerEvent.EventClass]);
            stringBuilder.AppendFormat("{0},", profilerEvent.CPU.ToString(CultureInfo.InvariantCulture));
            stringBuilder.AppendFormat("{0},", profilerEvent.Reads.ToString(CultureInfo.InvariantCulture));
            stringBuilder.AppendFormat("{0},", profilerEvent.Writes.ToString(CultureInfo.InvariantCulture));
            stringBuilder.AppendFormat("{0},", profilerEvent.Duration.ToString(CultureInfo.InvariantCulture));
            stringBuilder.AppendFormat("{0},", profilerEvent.SPID.ToString(CultureInfo.InvariantCulture));
            stringBuilder.AppendFormat("\"{0}\",", profilerEvent.LoginName.Replace("\"", "\"\""));
            stringBuilder.AppendFormat("\"{0}\",", profilerEvent.DatabaseName.Replace("\"", "\"\""));
            stringBuilder.AppendFormat("\"{0}\"", profilerEvent.TextData.Replace("\"", "\"\""));

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Does the find.
        /// </summary>
        private void DoFind()
        {
            if (this.profilingState == ProfilingStateEnum.profilingStateProfiling)
            {
                MessageBox.Show("You cannot find when trace is running", "SQL DBProfiler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (FindForm findForm = new FindForm())
            {
                findForm.MainForm = this;
                findForm.ShowDialog();
            }
        }

        #endregion
    }
}