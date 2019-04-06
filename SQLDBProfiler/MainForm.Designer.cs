namespace SQLDBProfiler 
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolstripButtonClearCache = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstripButtonScroll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstripButtonStart = new System.Windows.Forms.ToolStripButton();
            this.toolstripButtonPause = new System.Windows.Forms.ToolStripButton();
            this.toolstripButtonStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.edServer = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tbAuth = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.edUser = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.edPassword = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cbSelectEvents = new System.Windows.Forms.ToolStripSplitButton();
            this.mnExistingConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.mnLoginLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnRPCStarting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnRPCCompleted = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnBatchStarting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnBatchCompleted = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonFilters = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.edNotText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.edText = new System.Windows.Forms.TextBox();
            this.edLogin = new System.Windows.Forms.TextBox();
            this.edDatabase = new System.Windows.Forms.TextBox();
            this.edDuration = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reTextData = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyAllToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startTraceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseTraceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopTraceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.extractAllEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractSelectedEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.saveAllEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findNextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.clearTraceWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelFilters.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 742);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1208, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstripButtonClearCache,
            this.toolStripSeparator5,
            this.toolstripButtonScroll,
            this.toolStripSeparator1,
            this.toolstripButtonStart,
            this.toolstripButtonPause,
            this.toolstripButtonStop,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.edServer,
            this.toolStripSeparator4,
            this.tbAuth,
            this.toolStripLabel2,
            this.edUser,
            this.toolStripLabel3,
            this.edPassword,
            this.toolStripLabel4,
            this.toolStripSeparator3,
            this.cbSelectEvents,
            this.toolStripSeparator6,
            this.toolStripButtonFilters,
            this.toolStripSeparator7});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1208, 26);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolstripButtonClearCache
            // 
            this.toolstripButtonClearCache.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstripButtonClearCache.Image = ((System.Drawing.Image)(resources.GetObject("toolstripButtonClearCache.Image")));
            this.toolstripButtonClearCache.ImageTransparentColor = System.Drawing.Color.Silver;
            this.toolstripButtonClearCache.Name = "toolstripButtonClearCache";
            this.toolstripButtonClearCache.Size = new System.Drawing.Size(23, 23);
            this.toolstripButtonClearCache.Text = "Clear trace";
            this.toolstripButtonClearCache.ToolTipText = "Clear trace\r\nCtrl+Shift+Del";
            this.toolstripButtonClearCache.Click += new System.EventHandler(this.ToolStripButtonClearCache_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 26);
            // 
            // toolstripButtonScroll
            // 
            this.toolstripButtonScroll.Checked = true;
            this.toolstripButtonScroll.CheckOnClick = true;
            this.toolstripButtonScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolstripButtonScroll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstripButtonScroll.Image = ((System.Drawing.Image)(resources.GetObject("toolstripButtonScroll.Image")));
            this.toolstripButtonScroll.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolstripButtonScroll.Name = "toolstripButtonScroll";
            this.toolstripButtonScroll.Size = new System.Drawing.Size(23, 23);
            this.toolstripButtonScroll.Text = "Auto scroll window";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // toolstripButtonStart
            // 
            this.toolstripButtonStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstripButtonStart.Image = ((System.Drawing.Image)(resources.GetObject("toolstripButtonStart.Image")));
            this.toolstripButtonStart.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolstripButtonStart.Name = "toolstripButtonStart";
            this.toolstripButtonStart.Size = new System.Drawing.Size(23, 23);
            this.toolstripButtonStart.Text = "Start trace";
            this.toolstripButtonStart.Click += new System.EventHandler(this.ToolStripButtonStartProfiling_Click);
            // 
            // toolstripButtonPause
            // 
            this.toolstripButtonPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstripButtonPause.Image = ((System.Drawing.Image)(resources.GetObject("toolstripButtonPause.Image")));
            this.toolstripButtonPause.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolstripButtonPause.Name = "toolstripButtonPause";
            this.toolstripButtonPause.Size = new System.Drawing.Size(23, 23);
            this.toolstripButtonPause.Text = "Pause trace";
            this.toolstripButtonPause.Click += new System.EventHandler(this.ToolStripButtonPause_Click);
            // 
            // toolstripButtonStop
            // 
            this.toolstripButtonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstripButtonStop.Image = ((System.Drawing.Image)(resources.GetObject("toolstripButtonStop.Image")));
            this.toolstripButtonStop.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolstripButtonStop.Name = "toolstripButtonStop";
            this.toolstripButtonStop.Size = new System.Drawing.Size(23, 23);
            this.toolstripButtonStop.Text = "Stop trace";
            this.toolstripButtonStop.Click += new System.EventHandler(this.ToolStripButtonStopProfiling_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(39, 23);
            this.toolStripLabel1.Text = "Server";
            // 
            // edServer
            // 
            this.edServer.Name = "edServer";
            this.edServer.Size = new System.Drawing.Size(100, 26);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 26);
            // 
            // tbAuth
            // 
            this.tbAuth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbAuth.Items.AddRange(new object[] {
            "Windows auth",
            "SQL Server auth"});
            this.tbAuth.Name = "tbAuth";
            this.tbAuth.Size = new System.Drawing.Size(121, 26);
            this.tbAuth.SelectedIndexChanged += new System.EventHandler(this.TbAuth_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(30, 23);
            this.toolStripLabel2.Text = "User";
            // 
            // edUser
            // 
            this.edUser.Name = "edUser";
            this.edUser.Size = new System.Drawing.Size(100, 26);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(57, 23);
            this.toolStripLabel3.Text = "Password";
            // 
            // edPassword
            // 
            this.edPassword.Name = "edPassword";
            this.edPassword.Size = new System.Drawing.Size(100, 26);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.AutoSize = false;
            this.toolStripLabel4.Enabled = false;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
            // 
            // cbSelectEvents
            // 
            this.cbSelectEvents.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cbSelectEvents.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnExistingConnection,
            this.mnLoginLogout,
            this.toolStripMenuItem1,
            this.mnRPCStarting,
            this.mnRPCCompleted,
            this.toolStripMenuItem2,
            this.mnBatchStarting,
            this.mnBatchCompleted});
            this.cbSelectEvents.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cbSelectEvents.Name = "cbSelectEvents";
            this.cbSelectEvents.Size = new System.Drawing.Size(57, 23);
            this.cbSelectEvents.Text = "Events";
            this.cbSelectEvents.Click += new System.EventHandler(this.CbSelectEvents_Click);
            // 
            // mnExistingConnection
            // 
            this.mnExistingConnection.Name = "mnExistingConnection";
            this.mnExistingConnection.Size = new System.Drawing.Size(182, 22);
            this.mnExistingConnection.Text = "Existing connections";
            this.mnExistingConnection.Click += new System.EventHandler(this.ExistingConnectionsToolStripMenuItem_Click);
            // 
            // mnLoginLogout
            // 
            this.mnLoginLogout.Name = "mnLoginLogout";
            this.mnLoginLogout.Size = new System.Drawing.Size(182, 22);
            this.mnLoginLogout.Text = "Audit login/logout";
            this.mnLoginLogout.Click += new System.EventHandler(this.ExistingConnectionsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(179, 6);
            // 
            // mnRPCStarting
            // 
            this.mnRPCStarting.Name = "mnRPCStarting";
            this.mnRPCStarting.Size = new System.Drawing.Size(182, 22);
            this.mnRPCStarting.Text = "RPC:Starting";
            this.mnRPCStarting.Click += new System.EventHandler(this.ExistingConnectionsToolStripMenuItem_Click);
            // 
            // mnRPCCompleted
            // 
            this.mnRPCCompleted.Checked = true;
            this.mnRPCCompleted.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnRPCCompleted.Name = "mnRPCCompleted";
            this.mnRPCCompleted.Size = new System.Drawing.Size(182, 22);
            this.mnRPCCompleted.Text = "RPC:Completed";
            this.mnRPCCompleted.Click += new System.EventHandler(this.ExistingConnectionsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(179, 6);
            // 
            // mnBatchStarting
            // 
            this.mnBatchStarting.Name = "mnBatchStarting";
            this.mnBatchStarting.Size = new System.Drawing.Size(182, 22);
            this.mnBatchStarting.Text = "Batch:Starting";
            this.mnBatchStarting.Click += new System.EventHandler(this.ExistingConnectionsToolStripMenuItem_Click);
            // 
            // mnBatchCompleted
            // 
            this.mnBatchCompleted.Checked = true;
            this.mnBatchCompleted.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnBatchCompleted.Name = "mnBatchCompleted";
            this.mnBatchCompleted.Size = new System.Drawing.Size(182, 22);
            this.mnBatchCompleted.Text = "Batch:Completed";
            this.mnBatchCompleted.Click += new System.EventHandler(this.ExistingConnectionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 26);
            // 
            // toolStripButtonFilters
            // 
            this.toolStripButtonFilters.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonFilters.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFilters.Name = "toolStripButtonFilters";
            this.toolStripButtonFilters.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.toolStripButtonFilters.Size = new System.Drawing.Size(48, 23);
            this.toolStripButtonFilters.Text = " Filters ";
            this.toolStripButtonFilters.Click += new System.EventHandler(this.ToolStripButtonFilters_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 26);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 50);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelFilters);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.reTextData);
            this.splitContainer1.Size = new System.Drawing.Size(1208, 692);
            this.splitContainer1.SplitterDistance = 441;
            this.splitContainer1.TabIndex = 4;
            // 
            // panelFilters
            // 
            this.panelFilters.BackColor = System.Drawing.SystemColors.Control;
            this.panelFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilters.Controls.Add(this.edNotText);
            this.panelFilters.Controls.Add(this.label6);
            this.panelFilters.Controls.Add(this.edText);
            this.panelFilters.Controls.Add(this.edLogin);
            this.panelFilters.Controls.Add(this.edDatabase);
            this.panelFilters.Controls.Add(this.edDuration);
            this.panelFilters.Controls.Add(this.label5);
            this.panelFilters.Controls.Add(this.label4);
            this.panelFilters.Controls.Add(this.label3);
            this.panelFilters.Controls.Add(this.label2);
            this.panelFilters.Controls.Add(this.label1);
            this.panelFilters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelFilters.Location = new System.Drawing.Point(775, 0);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(268, 219);
            this.panelFilters.TabIndex = 0;
            this.panelFilters.Visible = false;
            // 
            // edNotText
            // 
            this.edNotText.BackColor = System.Drawing.Color.White;
            this.edNotText.Location = new System.Drawing.Point(95, 180);
            this.edNotText.Name = "edNotText";
            this.edNotText.Size = new System.Drawing.Size(159, 20);
            this.edNotText.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Text NOT LIKE";
            // 
            // edText
            // 
            this.edText.BackColor = System.Drawing.Color.White;
            this.edText.Location = new System.Drawing.Point(95, 148);
            this.edText.Name = "edText";
            this.edText.Size = new System.Drawing.Size(159, 20);
            this.edText.TabIndex = 8;
            // 
            // edLogin
            // 
            this.edLogin.BackColor = System.Drawing.Color.White;
            this.edLogin.Location = new System.Drawing.Point(95, 116);
            this.edLogin.Name = "edLogin";
            this.edLogin.Size = new System.Drawing.Size(159, 20);
            this.edLogin.TabIndex = 7;
            // 
            // edDatabase
            // 
            this.edDatabase.BackColor = System.Drawing.Color.White;
            this.edDatabase.Location = new System.Drawing.Point(95, 84);
            this.edDatabase.Name = "edDatabase";
            this.edDatabase.Size = new System.Drawing.Size(159, 20);
            this.edDatabase.TabIndex = 6;
            this.edDatabase.Text = "0";
            // 
            // edDuration
            // 
            this.edDuration.BackColor = System.Drawing.Color.White;
            this.edDuration.Location = new System.Drawing.Point(95, 52);
            this.edDuration.Name = "edDuration";
            this.edDuration.Size = new System.Drawing.Size(159, 20);
            this.edDuration.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Text LIKE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Login Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Database";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Duration, ms >=";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filters:";
            // 
            // reTextData
            // 
            this.reTextData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reTextData.Location = new System.Drawing.Point(0, 0);
            this.reTextData.Name = "reTextData";
            this.reTextData.ReadOnly = true;
            this.reTextData.Size = new System.Drawing.Size(1208, 247);
            this.reTextData.TabIndex = 4;
            this.reTextData.Text = "";
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyAllToClipboardToolStripMenuItem,
            this.copySelectedToClipboardToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(253, 48);
            // 
            // copyAllToClipboardToolStripMenuItem
            // 
            this.copyAllToClipboardToolStripMenuItem.Name = "copyAllToClipboardToolStripMenuItem";
            this.copyAllToClipboardToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.copyAllToClipboardToolStripMenuItem.Text = "Copy all events to clipboard";
            this.copyAllToClipboardToolStripMenuItem.Click += new System.EventHandler(this.CopyAllToClipboardToolStripMenuItem_Click);
            // 
            // copySelectedToClipboardToolStripMenuItem
            // 
            this.copySelectedToClipboardToolStripMenuItem.Name = "copySelectedToClipboardToolStripMenuItem";
            this.copySelectedToClipboardToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.copySelectedToClipboardToolStripMenuItem.Text = "Copy selected events to clipboard";
            this.copySelectedToClipboardToolStripMenuItem.Click += new System.EventHandler(this.CopySelectedToClipboardToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1208, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startTraceToolStripMenuItem,
            this.pauseTraceToolStripMenuItem,
            this.stopTraceToolStripMenuItem,
            this.toolStripMenuItem3,
            this.extractAllEventsToolStripMenuItem,
            this.extractSelectedEventsToolStripMenuItem,
            this.toolStripSeparator8,
            this.saveAllEventsToolStripMenuItem,
            this.toolStripMenuItem5,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // startTraceToolStripMenuItem
            // 
            this.startTraceToolStripMenuItem.Name = "startTraceToolStripMenuItem";
            this.startTraceToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.startTraceToolStripMenuItem.Text = "Start trace";
            this.startTraceToolStripMenuItem.Click += new System.EventHandler(this.StartTraceToolStripMenuItem_Click);
            // 
            // pauseTraceToolStripMenuItem
            // 
            this.pauseTraceToolStripMenuItem.Name = "pauseTraceToolStripMenuItem";
            this.pauseTraceToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.pauseTraceToolStripMenuItem.Text = "Pause trace";
            this.pauseTraceToolStripMenuItem.Click += new System.EventHandler(this.PauseTraceToolStripMenuItem_Click);
            // 
            // stopTraceToolStripMenuItem
            // 
            this.stopTraceToolStripMenuItem.Name = "stopTraceToolStripMenuItem";
            this.stopTraceToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.stopTraceToolStripMenuItem.Text = "Stop trace";
            this.stopTraceToolStripMenuItem.Click += new System.EventHandler(this.StopTraceToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(249, 6);
            // 
            // extractAllEventsToolStripMenuItem
            // 
            this.extractAllEventsToolStripMenuItem.Name = "extractAllEventsToolStripMenuItem";
            this.extractAllEventsToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.extractAllEventsToolStripMenuItem.Text = "Copy all events to clipboard";
            this.extractAllEventsToolStripMenuItem.Click += new System.EventHandler(this.ExtractAllEventsToolStripMenuItem_Click);
            // 
            // extractSelectedEventsToolStripMenuItem
            // 
            this.extractSelectedEventsToolStripMenuItem.Name = "extractSelectedEventsToolStripMenuItem";
            this.extractSelectedEventsToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.extractSelectedEventsToolStripMenuItem.Text = "Copy selected events to clipboard";
            this.extractSelectedEventsToolStripMenuItem.Click += new System.EventHandler(this.ExtractSelectedEventsToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(249, 6);
            // 
            // saveAllEventsToolStripMenuItem
            // 
            this.saveAllEventsToolStripMenuItem.Name = "saveAllEventsToolStripMenuItem";
            this.saveAllEventsToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.saveAllEventsToolStripMenuItem.Text = "Save all events to CSV file";
            this.saveAllEventsToolStripMenuItem.Click += new System.EventHandler(this.SaveAllEventsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(249, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.findToolStripMenuItem,
            this.findNextToolStripMenuItem,
            this.toolStripMenuItem4,
            this.clearTraceWindowToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.selectAllToolStripMenuItem.Text = "Select all";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItem_Click);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.findToolStripMenuItem.Text = "Find...";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.FindToolStripMenuItem_Click);
            // 
            // findNextToolStripMenuItem
            // 
            this.findNextToolStripMenuItem.Name = "findNextToolStripMenuItem";
            this.findNextToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.findNextToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.findNextToolStripMenuItem.Text = "Find next";
            this.findNextToolStripMenuItem.Click += new System.EventHandler(this.FindNextToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(260, 6);
            // 
            // clearTraceWindowToolStripMenuItem
            // 
            this.clearTraceWindowToolStripMenuItem.Name = "clearTraceWindowToolStripMenuItem";
            this.clearTraceWindowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Delete)));
            this.clearTraceWindowToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.clearTraceWindowToolStripMenuItem.Text = "Clear Trace Window";
            this.clearTraceWindowToolStripMenuItem.Click += new System.EventHandler(this.ClearTraceWindowToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 764);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL DB Profiler v1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolstripButtonStart;
        private System.Windows.Forms.ToolStripButton toolstripButtonStop;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox reTextData;
        private System.Windows.Forms.ToolStripButton toolstripButtonScroll;
        private System.Windows.Forms.ToolStripButton toolstripButtonPause;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox edServer;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox edUser;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox edPassword;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSplitButton cbSelectEvents;
        private System.Windows.Forms.ToolStripMenuItem mnExistingConnection;
        private System.Windows.Forms.ToolStripMenuItem mnLoginLogout;
        private System.Windows.Forms.ToolStripMenuItem mnRPCStarting;
        private System.Windows.Forms.ToolStripMenuItem mnRPCCompleted;
        private System.Windows.Forms.ToolStripMenuItem mnBatchStarting;
        private System.Windows.Forms.ToolStripMenuItem mnBatchCompleted;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripComboBox tbAuth;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolstripButtonClearCache;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyAllToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copySelectedToClipboardToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startTraceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseTraceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopTraceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearTraceWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem extractAllEventsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractSelectedEventsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findNextToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.TextBox edText;
        private System.Windows.Forms.TextBox edLogin;
        private System.Windows.Forms.TextBox edDatabase;
        private System.Windows.Forms.TextBox edDuration;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton toolStripButtonFilters;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem saveAllEventsToolStripMenuItem;
        private System.Windows.Forms.TextBox edNotText;
        private System.Windows.Forms.Label label6;
    }
}

