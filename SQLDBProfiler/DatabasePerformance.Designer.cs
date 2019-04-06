namespace SQLDBProfiler
{
    partial class DatabasePerformance
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabasePerformance));
            this.copySelectedToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataGridViewPerformance = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusExecuting = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusRowCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ToolStripComboBoxDatabase = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.ToolStripComboBoxQuery = new System.Windows.Forms.ToolStripComboBox();
            this.ToolStripButtonAutoSizeRows = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelLogo = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.ToolStripButtonSchemaQueries = new System.Windows.Forms.ToolStripButton();
            this.panelNoData = new System.Windows.Forms.Panel();
            this.labelNoData = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewPerformance)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelNoData.SuspendLayout();
            this.SuspendLayout();
            // 
            // copySelectedToClipboardToolStripMenuItem
            // 
            this.copySelectedToClipboardToolStripMenuItem.Name = "copySelectedToClipboardToolStripMenuItem";
            this.copySelectedToClipboardToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.copySelectedToClipboardToolStripMenuItem.Text = "Copy selected cells to clipboard";
            this.copySelectedToClipboardToolStripMenuItem.Click += new System.EventHandler(this.CopySelectedToClipboardToolStripMenuItem_Click);
            // 
            // DataGridViewPerformance
            // 
            this.DataGridViewPerformance.AllowUserToAddRows = false;
            this.DataGridViewPerformance.AllowUserToDeleteRows = false;
            this.DataGridViewPerformance.AllowUserToOrderColumns = true;
            this.DataGridViewPerformance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataGridViewPerformance.BackgroundColor = System.Drawing.Color.White;
            this.DataGridViewPerformance.ColumnHeadersHeight = 28;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewPerformance.DefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridViewPerformance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewPerformance.GridColor = System.Drawing.SystemColors.ControlLight;
            this.DataGridViewPerformance.Location = new System.Drawing.Point(0, 44);
            this.DataGridViewPerformance.Name = "DataGridViewPerformance";
            this.DataGridViewPerformance.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridViewPerformance.RowHeadersVisible = false;
            this.DataGridViewPerformance.Size = new System.Drawing.Size(1184, 698);
            this.DataGridViewPerformance.TabIndex = 6;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusExecuting,
            this.toolStripStatusLabel2,
            this.toolStripStatusRowCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 742);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1184, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusExecuting
            // 
            this.toolStripStatusExecuting.Name = "toolStripStatusExecuting";
            this.toolStripStatusExecuting.Size = new System.Drawing.Size(67, 17);
            this.toolStripStatusExecuting.Text = "Executing...";
            this.toolStripStatusExecuting.Visible = false;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(1120, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = " ";
            // 
            // toolStripStatusRowCount
            // 
            this.toolStripStatusRowCount.Name = "toolStripStatusRowCount";
            this.toolStripStatusRowCount.Size = new System.Drawing.Size(47, 17);
            this.toolStripStatusRowCount.Text = "0 rows  ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripStatusLabel1.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1201, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = " ";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copySelectedToClipboardToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(242, 48);
            // 
            // ToolStripButtonClose
            // 
            this.ToolStripButtonClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripButtonClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonClose.Name = "ToolStripButtonClose";
            this.ToolStripButtonClose.Size = new System.Drawing.Size(46, 41);
            this.ToolStripButtonClose.Text = "Close";
            this.ToolStripButtonClose.Click += new System.EventHandler(this.ToolStripButtonClose_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(73, 41);
            this.toolStripLabel1.Text = "Database: ";
            // 
            // ToolStripComboBoxDatabase
            // 
            this.ToolStripComboBoxDatabase.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ToolStripComboBoxDatabase.Name = "ToolStripComboBoxDatabase";
            this.ToolStripComboBoxDatabase.Size = new System.Drawing.Size(230, 44);
            this.ToolStripComboBoxDatabase.SelectedIndexChanged += new System.EventHandler(this.ToolStripComboBoxDatabase_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(140, 41);
            this.toolStripLabel2.Text = "Performance Queries:";
            // 
            // ToolStripComboBoxQuery
            // 
            this.ToolStripComboBoxQuery.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ToolStripComboBoxQuery.Name = "ToolStripComboBoxQuery";
            this.ToolStripComboBoxQuery.Size = new System.Drawing.Size(360, 44);
            this.ToolStripComboBoxQuery.SelectedIndexChanged += new System.EventHandler(this.ToolStripComboBoxQuery_SelectedIndexChanged);
            // 
            // ToolStripButtonAutoSizeRows
            // 
            this.ToolStripButtonAutoSizeRows.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButtonAutoSizeRows.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonAutoSizeRows.Name = "ToolStripButtonAutoSizeRows";
            this.ToolStripButtonAutoSizeRows.Size = new System.Drawing.Size(70, 41);
            this.ToolStripButtonAutoSizeRows.Text = "Auto Size";
            this.ToolStripButtonAutoSizeRows.Visible = false;
            this.ToolStripButtonAutoSizeRows.Click += new System.EventHandler(this.ToolStripButtonAutoSizeRows_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelLogo,
            this.toolStripLabel1,
            this.ToolStripComboBoxDatabase,
            this.toolStripLabel4,
            this.toolStripLabel2,
            this.ToolStripComboBoxQuery,
            this.ToolStripButtonAutoSizeRows,
            this.ToolStripButtonClose,
            this.ToolStripButtonSchemaQueries});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1184, 44);
            this.toolStrip1.TabIndex = 8;
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
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(13, 41);
            this.toolStripLabel4.Text = " ";
            // 
            // ToolStripButtonSchemaQueries
            // 
            this.ToolStripButtonSchemaQueries.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripButtonSchemaQueries.Image = global::SQLDBProfiler.Properties.Resources.RelationshipsHS;
            this.ToolStripButtonSchemaQueries.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolStripButtonSchemaQueries.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonSchemaQueries.Margin = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.ToolStripButtonSchemaQueries.Name = "ToolStripButtonSchemaQueries";
            this.ToolStripButtonSchemaQueries.Size = new System.Drawing.Size(127, 41);
            this.ToolStripButtonSchemaQueries.Text = "Schema Queries";
            this.ToolStripButtonSchemaQueries.Click += new System.EventHandler(this.ToolStripButtonSchemaQueries_Click);
            // 
            // panelNoData
            // 
            this.panelNoData.AutoSize = true;
            this.panelNoData.BackColor = System.Drawing.Color.White;
            this.panelNoData.Controls.Add(this.labelNoData);
            this.panelNoData.Location = new System.Drawing.Point(10, 50);
            this.panelNoData.Name = "panelNoData";
            this.panelNoData.Size = new System.Drawing.Size(165, 33);
            this.panelNoData.TabIndex = 9;
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
            // DatabasePerformance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 764);
            this.Controls.Add(this.panelNoData);
            this.Controls.Add(this.DataGridViewPerformance);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "DatabasePerformance";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Database Performance Queries";
            this.Load += new System.EventHandler(this.DatabasePerformance_Load);
            this.Shown += new System.EventHandler(this.DatabasePerformance_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewPerformance)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelNoData.ResumeLayout(false);
            this.panelNoData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton ToolStripButtonClose;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox ToolStripComboBoxDatabase;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox ToolStripComboBoxQuery;
        private System.Windows.Forms.ToolStripMenuItem copySelectedToClipboardToolStripMenuItem;
        private System.Windows.Forms.DataGridView DataGridViewPerformance;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusExecuting;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusRowCount;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripButton ToolStripButtonAutoSizeRows;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabelLogo;
        private System.Windows.Forms.ToolStripButton ToolStripButtonSchemaQueries;
        private System.Windows.Forms.Panel panelNoData;
        private System.Windows.Forms.Label labelNoData;
    }
}