// ----------------------------------------------------------------------
// <copyright file="SQLDBProfiler.cs" company="MasonSoft Technology Ltd">
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
    public partial class SqlDbProfiler : Form
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
        /// The maximum events
        /// </summary>
        private int maxEvents = Properties.Settings.Default.MaxDisplayEvents;

        /// <summary>
        /// The list view events
        /// </summary>
        private ListViewComponent listviewEvents;

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
        /// Initializes a new instance of the <see cref="SqlDbProfiler"/> class.
        /// </summary>
        public SqlDbProfiler()
        {
            this.InitializeComponent();
            this.InitListView();
            this.AdjustFormSize();

            this.Text = string.Format("SQL Server Database Profiler - {0}", Application.ProductVersion);
            this.ToolStripSqlProfiler.Renderer = new CustomToolStripMenuRenderer();
            this.LastPosition = -1;
            this.LastPattern = string.Empty;

            this.ConnectParameters = new ConnectionParameters();
            this.GetPropertySetting();
            this.GetEventMaskSettings();
            this.GetCommandLineParameters();

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

        /// <summary>
        /// Gets or sets the connect parameters.
        /// </summary>
        /// <value>
        /// The connect parameters.
        /// </value>
        internal ConnectionParameters ConnectParameters { get; set; }

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

            MessageBox.Show(
                string.Format("Failed to find \"{0}\". Searched to the end of data. ", this.LastPattern),
                "SQL DBProfiler",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        #endregion

        #region page events

        /// <summary>
        /// Handles the Load event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SqlDbProfilerForm_Load(object sender, EventArgs e)
        {
            return;
        }

        /// <summary>
        /// Handles the First Shown event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SqlDbProfiler_Shown(object sender, EventArgs e)
        {
            if (this.GetSqlServerLogon())
            {
                try
                {
                    this.connection = this.GetConnection();
                    this.connection.Open();
                    this.connection.Close();
                    this.ConnectParameters.ValidConnection = true;
                }
                catch
                {
                    MessageBox.Show("Invalid Logon Information!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Handles the FormClosing event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void SqlDbProfilerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.profilingState == ProfilingStateEnum.profilingStatePaused || this.profilingState == ProfilingStateEnum.profilingStateProfiling)
            {
                this.StopProfiling();
            }

            this.SaveFormPropertySettings();
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
        /// Handles the Click event of the ToolStripMenuItemRepository control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ToolStripMenuItemRepository_Click(object sender, EventArgs e)
        {
            this.ToolStripButtonRepository.PerformClick();
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
        /// Handles the KeyDown event of the edPassword control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void EdPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.toolstripButtonStart.PerformClick();
            }
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
            if (this.CachedListView.Count > 1)
            {
                this.DoFind();
            }
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
                if (this.RichTextBoxTextData.Focused)
                {
                    this.RichTextBoxTextData.SelectAll();
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
            if (this.CachedListView.Count > 1)
            {
                if (this.profilingState == ProfilingStateEnum.profilingStateProfiling)
                {
                    MessageBox.Show(
                        "You cannot find when trace is running",
                        "SQL DBProfiler",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                this.SelectAllEvents(true);
                this.PerformFind();
            }
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
        /// Handles the Click event of the copySelectedToClipboardToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CopySelectedToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CopyEventsToClipboard(true);
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

        /// <summary>
        /// Handles the Click event of the informaticsToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void InformaticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ToolStripButtonSchemaQueries.PerformClick();
        }

        /// <summary>
        /// Handles the Click event of the PerformanceToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void PerformanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ToolStripButtonPerformaceQueries.PerformClick();
        }

        /// <summary>
        /// Handles the Click event of the ToolStripButtonClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ToolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the ToolStripButtonSchemaQueries control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ToolStripButtonSchemaQueries_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ConnectParameters.ValidConnection)
                {
                    using (DatabaseSchema form = new DatabaseSchema(this.ConnectParameters, this))
                    {
                        form.ShowDialog();
                        if (form.LoadOtherDialog == "Performance")
                        {
                            this.ToolStripButtonPerformaceQueries.PerformClick();
                        }
                    }
                }
                else
                {
                    if (this.GetSqlServerLogon())
                    {
                        this.connection = this.GetConnection();
                        this.connection.Open();
                        this.connection.Close();
                        this.ConnectParameters.ValidConnection = true;

                        using (DatabaseSchema form = new DatabaseSchema(this.ConnectParameters, this))
                        {
                            form.ShowDialog(this);
                            if (form.LoadOtherDialog == "Performance")
                            {
                                this.ToolStripButtonPerformaceQueries.PerformClick();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.ConnectParameters.ValidConnection = false;
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the Click event of the ToolStripButtonPerformanceQueries control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ToolStripButtonPerformanceQueries_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ConnectParameters.ValidConnection)
                {
                    using (DatabasePerformance form = new DatabasePerformance(this.ConnectParameters, this))
                    {
                        form.ShowDialog(this);
                        if (form.LoadOtherDialog == "Schema")
                        {
                            this.ToolStripButtonSchemaQueries.PerformClick();
                        }
                    }
                }
                else
                {
                    if (this.GetSqlServerLogon())
                    {
                        this.connection = this.GetConnection();
                        this.connection.Open();
                        this.connection.Close();
                        this.ConnectParameters.ValidConnection = true;

                        using (DatabasePerformance form = new DatabasePerformance(this.ConnectParameters, this))
                        {
                            form.ShowDialog(this);
                            if (form.LoadOtherDialog == "Schema")
                            {
                                this.ToolStripButtonSchemaQueries.PerformClick();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.ConnectParameters.ValidConnection = false;
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the Click event of the toolStripButtonRepository control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ToolStripButtonRepository_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlCodeRepository form = new SqlCodeRepository(this))
                {
                    form.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region private methods

        /// <summary>
        /// Adjusts the size of the form.
        /// </summary>
        private void AdjustFormSize()
        {
            this.Width = Properties.Settings.Default.FormWidth;
            this.Height = Properties.Settings.Default.FormHeight;

            Screen userScreen = Screen.FromControl(this);
            int userScreenWidth = userScreen.Bounds.Width;
            int userScreenHeight = userScreen.Bounds.Height;

            if (userScreenWidth < 1200 || userScreenHeight < 800)
            {
                this.Width = userScreenWidth;
                this.Height = userScreenHeight;
            }

            this.WindowState = Properties.Settings.Default.WindowsState == "Maximized" ? FormWindowState.Maximized : FormWindowState.Normal;
        }

        /// <summary>
        /// Gets the SQL server logon.
        /// </summary>
        /// <returns>Logon proceed or cancel</returns>
        private bool GetSqlServerLogon()
        {
            try
            {
                using (SqlLogon form = new SqlLogon(this.ConnectParameters))
                {
                    DialogResult dialogResult = form.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        this.ConnectParameters = form.ConnectParameters;
                        this.ConnectParameters.ValidConnection = false;
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns>the connection</returns>
        private SqlConnection GetConnection()
        {
            string constr = this.ConnectParameters.Authentication == 0 ? string.Format(
                                    @"Data Source = {0};Initial Catalog={1};Integrated Security=SSPI;Application Name=SQL DB Profiler",
                                    this.ConnectParameters.Server,
                                    this.ConnectParameters.Database)
                           : string.Format(
                                    @"Data Source={0};Initial Catalog={3};User Id={1};Password={2};;Application Name=SQL DB Profiler",
                                    this.ConnectParameters.Server,
                                    this.ConnectParameters.UserName,
                                    this.ConnectParameters.Password,
                                    this.ConnectParameters.Database);

            return new SqlConnection { ConnectionString = constr };
        }

        /// <summary>
        /// Gets the property setting.
        /// </summary>
        private void GetPropertySetting()
        {
            this.ConnectParameters.Server = Properties.Settings.Default.ServerName;
            this.ConnectParameters.UserName = Properties.Settings.Default.UserName;
            this.ConnectParameters.Authentication = string.IsNullOrEmpty(this.ConnectParameters.UserName) ? 0 : 1;
            this.ConnectParameters.ValidConnection = false;

            this.TextboxFilterDuration.Text = Properties.Settings.Default.Duration.ToString(CultureInfo.InvariantCulture);
            this.TextboxFilterDatabase.Text = Properties.Settings.Default.Database.ToString(CultureInfo.InvariantCulture);
            this.TextboxFilterLoginName.Text = Properties.Settings.Default.LoginName.ToString(CultureInfo.InvariantCulture);
            this.TextboxFilterTextData.Text = Properties.Settings.Default.TextData.ToString(CultureInfo.InvariantCulture);
            this.TextboxFilterNotTextData.Text = Properties.Settings.Default.NotTextData.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets the event mask settings.
        /// </summary>
        private void GetEventMaskSettings()
        {
            int eventMask = Properties.Settings.Default.EventMask;

            this.CheckboxEventExistingConnection.Checked = (eventMask & 1) != 0;
            this.CheckboxEventLoginLogout.Checked = (eventMask & 2) != 0;
            this.CheckboxEventRPCStarting.Checked = (eventMask & 4) != 0;
            this.CheckboxEventRPCCompleted.Checked = (eventMask & 8) != 0;
            this.CheckboxEventBatchStarting.Checked = (eventMask & 16) != 0;
            this.CheckboxEventBatchCompleted.Checked = (eventMask & 32) != 0;
        }

        /// <summary>
        /// Gets the command line parameters.
        /// </summary>
        private void GetCommandLineParameters()
        {
            this.ParseCommandLine();
            if (this.autostart)
            {
                this.StartProfiling();
            }
        }

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
                        this.ConnectParameters.Server = ep;
                        i++;
                        break;
                    case "-u":
                    case "-user":
                        this.ConnectParameters.UserName = ep;
                        i++;
                        break;
                    case "-p":
                    case "-password":
                        this.ConnectParameters.Password = ep;
                        i++;
                        break;
                    case "-m":
                    case "-maxevents":
                        if (!int.TryParse(ep, out this.maxEvents))
                        {
                            this.maxEvents = Properties.Settings.Default.MaxDisplayEvents;
                        }

                        break;
                    case "-d":
                    case "-duration":
                        int d;
                        if (int.TryParse(ep, out d))
                        {
                            this.TextboxFilterDuration.Text = d.ToString(CultureInfo.InvariantCulture);
                        }

                        break;
                    case "-database":
                        this.TextboxFilterDatabase.Text = ep;
                        break;
                    case "-login":
                        this.TextboxFilterLoginName.Text = ep;
                        break;
                    case "-text":
                        this.TextboxFilterTextData.Text = ep;
                        break;
                    case "-nottext":
                        this.TextboxFilterNotTextData.Text = ep;
                        break;
                    case "-start":
                        this.autostart = true;
                        break;
                }

                i++;
            }

            this.ConnectParameters.Authentication = string.IsNullOrEmpty(this.ConnectParameters.UserName) ? 0 : 1;

            if (this.ConnectParameters.Server.Length == 0)
            {
                this.ConnectParameters.Server = ".";
            }
        }

        /// <summary>
        /// Initiates the LV.
        /// </summary>
        private void InitListView()
        {
            this.listviewEvents = new ListViewComponent
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
        /// Starts the profiling.
        /// </summary>
        private void StartProfiling()
        {
            try
            {
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

                if (!this.ConnectParameters.ValidConnection)
                {
                    if (!this.GetSqlServerLogon())
                    {
                        return;
                    }
                }

                this.connection = this.GetConnection();
                this.connection.Open();
                this.ConnectParameters.ValidConnection = true;

                this.traceReader = new RawTraceReader(this.connection);

                this.traceReader.CreateTrace();

                if (true)
                {
                    if (this.CheckboxEventLoginLogout.Checked)
                    {
                        this.traceReader.SetEvent(
                            ProfilerEvents.SecurityAudit.AuditLogin,
                            ProfilerEventColumns.TextData,
                            ProfilerEventColumns.LoginName,
                            ProfilerEventColumns.SPID);
                    }

                    if (this.CheckboxEventExistingConnection.Checked)
                    {
                        this.traceReader.SetEvent(
                            ProfilerEvents.Sessions.ExistingConnection,
                            ProfilerEventColumns.TextData,
                            ProfilerEventColumns.SPID);
                    }

                    if (this.CheckboxEventBatchCompleted.Checked)
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

                    if (this.CheckboxEventBatchStarting.Checked)
                    {
                        this.traceReader.SetEvent(
                            ProfilerEvents.TSQL.SQLBatchStarting,
                            ProfilerEventColumns.TextData,
                            ProfilerEventColumns.LoginName,
                            ProfilerEventColumns.DatabaseName,
                            ProfilerEventColumns.SPID);
                    }

                    if (this.CheckboxEventRPCStarting.Checked)
                    {
                        this.traceReader.SetEvent(
                            ProfilerEvents.StoredProcedures.RPCStarting,
                            ProfilerEventColumns.TextData,
                            ProfilerEventColumns.LoginName,
                            ProfilerEventColumns.DatabaseName,
                            ProfilerEventColumns.SPID);
                    }
                }

                if (this.CheckboxEventRPCCompleted.Checked)
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
                if (int.TryParse(this.TextboxFilterDuration.Text, out dur))
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

                if (this.TextboxFilterDatabase.Text != string.Empty)
                {
                    this.traceReader.SetFilter(ProfilerEventColumns.DatabaseName, LogicalOperators.AND, ComparisonOperators.Like, this.TextboxFilterDatabase.Text);
                }

                if (this.TextboxFilterLoginName.Text != string.Empty)
                {
                    this.traceReader.SetFilter(ProfilerEventColumns.LoginName, LogicalOperators.AND, ComparisonOperators.Like, this.TextboxFilterLoginName.Text);
                }

                if (this.TextboxFilterTextData.Text != string.Empty)
                {
                    this.traceReader.SetFilter(ProfilerEventColumns.TextData, LogicalOperators.AND, ComparisonOperators.Like, this.TextboxFilterTextData.Text);
                }

                if (this.TextboxFilterNotTextData.Text != string.Empty)
                {
                    this.traceReader.SetFilter(ProfilerEventColumns.TextData, LogicalOperators.AND, ComparisonOperators.NotLike, this.TextboxFilterNotTextData.Text);
                }

                this.traceReader.SetFilter(ProfilerEventColumns.TextData, LogicalOperators.AND, ComparisonOperators.NotLike, "%sp_reset_connection%");

                this.CachedListView.Clear();
                this.eventsQueue.Clear();
                this.itemBySql.Clear();

                this.listviewEvents.VirtualListSize = 0;
                this.StartProfilerThread();

                this.SaveProfilerPropertySettings();

                this.UpdateButtons();
            }
            catch (Exception ex)
            {
                this.ConnectParameters.ValidConnection = false;
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
            this.cbSelectEvents.Enabled = this.profilingState == ProfilingStateEnum.profilingStateStopped;
            this.cbSelectFilters.Enabled = this.profilingState == ProfilingStateEnum.profilingStateStopped;
            this.CheckboxEventBatchStarting.Enabled = this.CheckboxEventBatchCompleted.Enabled;
            this.CheckboxEventExistingConnection.Enabled = this.CheckboxEventBatchCompleted.Enabled;
            this.CheckboxEventRPCCompleted.Enabled = this.CheckboxEventBatchCompleted.Enabled;
            this.CheckboxEventLoginLogout.Enabled = this.CheckboxEventBatchCompleted.Enabled;
            this.CheckboxEventRPCStarting.Enabled = this.CheckboxEventBatchCompleted.Enabled;
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

            this.traceUtilities.FillRichEdit(this.RichTextBoxTextData, stringBuilder.ToString());
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
                MessageBox.Show(
                    "You cannot find when trace is running",
                    "SQL DBProfiler",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            using (FindForm findForm = new FindForm())
            {
                findForm.MainForm = this;
                findForm.ShowDialog();
            }
        }

        /// <summary>
        /// Gets the current database.
        /// </summary>
        /// <returns>the current database.</returns>
        private string GetCurrentDatabase()
        {
            string database = this.TextboxFilterDatabase.Text;

            if (string.IsNullOrEmpty(database) || database.Contains("%"))
            {
                database = "master";
            }

            return database;
        }

        /// <summary>
        /// Copies the events to clipboard.
        /// </summary>
        /// <param name="copySelected">if set to <c>true</c> [copy selected].</param>
        private void CopyEventsToClipboard(bool copySelected)
        {
            StringBuilder stringBuilder = new StringBuilder();

            lock (this.CachedListView)
            {
                stringBuilder.AppendLine(string.Format(@"Event Class{0}CPU{0}Reads{0}Writes{0}Duration{0}SPID{0}Login Name{0}Database{0}Text Data", "\t"));

                foreach (var item in this.CachedListView)
                {
                    if ((copySelected && item.Selected) | (!copySelected))
                    {
                        stringBuilder.Append(this.CreateClipboardRow((ProfilerEvent)item.Tag));
                    }
                }
            }

            MessageBox.Show(
                "Event(s) data copied to clipboard",
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            Clipboard.SetText(stringBuilder.ToString());
        }

        /// <summary>
        /// Creates the clipboard row.
        /// </summary>
        /// <param name="profilerEvent">The profiler event.</param>
        /// <returns>the clipboard row string values</returns>
        private string CreateClipboardRow(ProfilerEvent profilerEvent)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string tab = "\t";

            stringBuilder.AppendFormat(@"{0}{1}", ProfilerEvents.Names[profilerEvent.EventClass], tab);
            stringBuilder.AppendFormat(@"{0}{1}", profilerEvent.CPU.ToString(), tab);
            stringBuilder.AppendFormat(@"{0}{1}", profilerEvent.Reads.ToString(), tab);
            stringBuilder.AppendFormat(@"{0}{1}", profilerEvent.Writes.ToString(), tab);
            stringBuilder.AppendFormat(@"{0}{1}", profilerEvent.Duration.ToString(), tab);
            stringBuilder.AppendFormat(@"{0}{1}", profilerEvent.SPID.ToString(), tab);
            stringBuilder.AppendFormat(@"{0}{1}", profilerEvent.LoginName, tab);
            stringBuilder.AppendFormat(@"{0}{1}", profilerEvent.DatabaseName, tab);
            stringBuilder.AppendFormat("\"{0}\"", profilerEvent.TextData.Replace("\"", "\"\""));
            stringBuilder.AppendLine();

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Saves the property settings.
        /// </summary>
        private void SaveProfilerPropertySettings()
        {
            Properties.Settings.Default.ServerName = this.ConnectParameters.Server;
            Properties.Settings.Default.UserName = this.ConnectParameters.UserName;

            int eventMask = 0;
            if (this.CheckboxEventExistingConnection.Checked)
            {
                eventMask |= 1;
            }

            if (this.CheckboxEventLoginLogout.Checked)
            {
                eventMask |= 2;
            }

            if (this.CheckboxEventRPCStarting.Checked)
            {
                eventMask |= 4;
            }

            if (this.CheckboxEventRPCCompleted.Checked)
            {
                eventMask |= 8;
            }

            if (this.CheckboxEventBatchStarting.Checked)
            {
                eventMask |= 16;
            }

            if (this.CheckboxEventBatchCompleted.Checked)
            {
                eventMask |= 32;
            }

            Properties.Settings.Default.EventMask = eventMask;
            Properties.Settings.Default.Duration = int.Parse(this.TextboxFilterDuration.Text);
            Properties.Settings.Default.Database = this.TextboxFilterDatabase.Text;
            Properties.Settings.Default.LoginName = this.TextboxFilterLoginName.Text;
            Properties.Settings.Default.TextData = this.TextboxFilterTextData.Text;
            Properties.Settings.Default.NotTextData = this.TextboxFilterNotTextData.Text;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Saves the form property settings.
        /// </summary>
        private void SaveFormPropertySettings()
        {
            Properties.Settings.Default.ServerName = this.ConnectParameters.Server;
            Properties.Settings.Default.UserName = this.ConnectParameters.UserName;
            Properties.Settings.Default.FormWidth = this.Width;
            Properties.Settings.Default.FormHeight = this.Height;
            Properties.Settings.Default.WindowsState = this.WindowState == FormWindowState.Maximized ? "Maximized" : "Normal";

            Properties.Settings.Default.Save();
        }

        #endregion
    }
}
