namespace SQLDBProfiler
{
    partial class DatabaseSchema
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseSchema));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelLogo = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ToolStripComboBoxDatabase = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxQuery = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButtonPerformaceQueries = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.DataGridViewSchema = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copySelectedToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusExecuting = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusRowCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerProgressBar = new System.Windows.Forms.Timer(this.components);
            this.panelNoData = new System.Windows.Forms.Panel();
            this.labelNoData = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewSchema)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelNoData.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelLogo,
            this.toolStripLabel1,
            this.ToolStripComboBoxDatabase,
            this.toolStripLabel4,
            this.toolStripLabel2,
            this.toolStripComboBoxQuery,
            this.toolStripButton1,
            this.ToolStripButtonPerformaceQueries});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1184, 44);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabelLogo
            // 
            this.toolStripLabelLogo.AutoSize = false;
            this.toolStripLabelLogo.BackColor = System.Drawing.Color.Transparent;
            this.toolStripLabelLogo.BackgroundImage = global::SQLDBProfiler.Properties.Resources.SqlDbProfiler1;
            this.toolStripLabelLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStripLabelLogo.ImageTransparentColor = System.Drawing.SystemColors.Control;
            this.toolStripLabelLogo.Margin = new System.Windows.Forms.Padding(0, 1, 8, 2);
            this.toolStripLabelLogo.Name = "toolStripLabelLogo";
            this.toolStripLabelLogo.Size = new System.Drawing.Size(44, 44);
            this.toolStripLabelLogo.Text = " ";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(73, 41);
            this.toolStripLabel1.Text = "Database: ";
            // 
            // ToolStripComboBoxDatabase
            // 
            this.ToolStripComboBoxDatabase.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ToolStripComboBoxDatabase.Name = "ToolStripComboBoxDatabase";
            this.ToolStripComboBoxDatabase.Size = new System.Drawing.Size(230, 44);
            this.ToolStripComboBoxDatabase.SelectedIndexChanged += new System.EventHandler(this.ToolStripComboBox_Database_SelectedIndexChanged);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(17, 41);
            this.toolStripLabel4.Text = "  ";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(110, 41);
            this.toolStripLabel2.Text = "Schema Queries:";
            // 
            // toolStripComboBoxQuery
            // 
            this.toolStripComboBoxQuery.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripComboBoxQuery.Items.AddRange(new object[] {
            "Database Files",
            "Table Row Counts",
            "Index Usage",
            "Unused Indexes",
            "All Primary Keys",
            "All Foreign Keys",
            "All Identity Fields",
            "All Triggers",
            "Non-Clustered Indexes",
            "Tables with no Primary Keys",
            "Changes in the last 90 days"});
            this.toolStripComboBoxQuery.Name = "toolStripComboBoxQuery";
            this.toolStripComboBoxQuery.Size = new System.Drawing.Size(300, 44);
            this.toolStripComboBoxQuery.SelectedIndexChanged += new System.EventHandler(this.ToolStripComboBoxQuery_SelectedIndexChanged);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(46, 41);
            this.toolStripButton1.Text = "Close";
            this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButtonClose_Click);
            // 
            // ToolStripButtonPerformaceQueries
            // 
            this.ToolStripButtonPerformaceQueries.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripButtonPerformaceQueries.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ToolStripButtonPerformaceQueries.Image = global::SQLDBProfiler.Properties.Resources.TableHS;
            this.ToolStripButtonPerformaceQueries.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolStripButtonPerformaceQueries.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonPerformaceQueries.Margin = new System.Windows.Forms.Padding(8, 1, 0, 2);
            this.ToolStripButtonPerformaceQueries.Name = "ToolStripButtonPerformaceQueries";
            this.ToolStripButtonPerformaceQueries.Size = new System.Drawing.Size(157, 41);
            this.ToolStripButtonPerformaceQueries.Text = "Performance Queries";
            this.ToolStripButtonPerformaceQueries.Click += new System.EventHandler(this.ToolStripButtonPerformanceQueries_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 36);
            // 
            // DataGridViewSchema
            // 
            this.DataGridViewSchema.AllowUserToAddRows = false;
            this.DataGridViewSchema.AllowUserToDeleteRows = false;
            this.DataGridViewSchema.AllowUserToOrderColumns = true;
            this.DataGridViewSchema.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataGridViewSchema.BackgroundColor = System.Drawing.Color.White;
            this.DataGridViewSchema.ColumnHeadersHeight = 28;
            this.DataGridViewSchema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewSchema.GridColor = System.Drawing.SystemColors.ControlLight;
            this.DataGridViewSchema.Location = new System.Drawing.Point(0, 44);
            this.DataGridViewSchema.Name = "DataGridViewSchema";
            this.DataGridViewSchema.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridViewSchema.RowHeadersVisible = false;
            this.DataGridViewSchema.Size = new System.Drawing.Size(1184, 698);
            this.DataGridViewSchema.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copySelectedToClipboardToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(242, 26);
            // 
            // copySelectedToClipboardToolStripMenuItem
            // 
            this.copySelectedToClipboardToolStripMenuItem.Name = "copySelectedToClipboardToolStripMenuItem";
            this.copySelectedToClipboardToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.copySelectedToClipboardToolStripMenuItem.Text = "Copy selected cells to clipboard";
            this.copySelectedToClipboardToolStripMenuItem.Click += new System.EventHandler(this.CopySelectedToClipboardToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusExecuting,
            this.toolStripStatusLabel1,
            this.toolStripStatusRowCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 742);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1184, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusExecuting
            // 
            this.toolStripStatusExecuting.Name = "toolStripStatusExecuting";
            this.toolStripStatusExecuting.Size = new System.Drawing.Size(67, 17);
            this.toolStripStatusExecuting.Text = "Executing...";
            this.toolStripStatusExecuting.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripStatusLabel1.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1122, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = " ";
            // 
            // toolStripStatusRowCount
            // 
            this.toolStripStatusRowCount.Name = "toolStripStatusRowCount";
            this.toolStripStatusRowCount.Size = new System.Drawing.Size(47, 17);
            this.toolStripStatusRowCount.Text = "0 rows  ";
            // 
            // panelNoData
            // 
            this.panelNoData.AutoSize = true;
            this.panelNoData.BackColor = System.Drawing.Color.White;
            this.panelNoData.Controls.Add(this.labelNoData);
            this.panelNoData.Location = new System.Drawing.Point(12, 59);
            this.panelNoData.Name = "panelNoData";
            this.panelNoData.Size = new System.Drawing.Size(165, 33);
            this.panelNoData.TabIndex = 4;
            // 
            // labelNoData
            // 
            this.labelNoData.AutoSize = true;
            this.labelNoData.BackColor = System.Drawing.Color.White;
            this.labelNoData.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoData.ForeColor = System.Drawing.Color.Silver;
            this.labelNoData.Location = new System.Drawing.Point(3, 3);
            this.labelNoData.Name = "labelNoData";
            this.labelNoData.Size = new System.Drawing.Size(159, 30);
            this.labelNoData.TabIndex = 0;
            this.labelNoData.Text = "No Data Found";
            // 
            // DatabaseSchema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 764);
            this.Controls.Add(this.panelNoData);
            this.Controls.Add(this.DataGridViewSchema);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "DatabaseSchema";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Database Schema Queries";
            this.Load += new System.EventHandler(this.DatabaseSchema_Load);
            this.Shown += new System.EventHandler(this.DatabaseSchema_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewSchema)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelNoData.ResumeLayout(false);
            this.panelNoData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox ToolStripComboBoxDatabase;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridView DataGridViewSchema;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxQuery;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copySelectedToClipboardToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusRowCount;
        private System.Windows.Forms.Timer timerProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusExecuting;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripLabel toolStripLabelLogo;
        private System.Windows.Forms.ToolStripButton ToolStripButtonPerformaceQueries;
        private System.Windows.Forms.Panel panelNoData;
        private System.Windows.Forms.Label labelNoData;
    }
}