namespace SQLDBProfiler
{
    partial class SqlCodeRepository
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqlCodeRepository));
            this.SplitContainerRepository = new System.Windows.Forms.SplitContainer();
            this.ListBoxCodeList = new System.Windows.Forms.ListBox();
            this.ToolStripCodeList = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelLogo = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ToolStripTextBoxSearchCodeList = new System.Windows.Forms.ToolStripTextBox();
            this.ToolStripButtonSearch = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButtonNext = new System.Windows.Forms.ToolStripButton();
            this.RichTextBoxQueryData = new System.Windows.Forms.RichTextBox();
            this.ToolStripCode = new System.Windows.Forms.ToolStrip();
            this.ToolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.ToolStripLabelCodeHeading = new System.Windows.Forms.ToolStripLabel();
            this.ToolStripCodeMaintenance = new System.Windows.Forms.ToolStrip();
            this.ToolStripButtonCopyToClipboard = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.ToolStripButtonAddCode = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButtonUpdate = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerRepository)).BeginInit();
            this.SplitContainerRepository.Panel1.SuspendLayout();
            this.SplitContainerRepository.Panel2.SuspendLayout();
            this.SplitContainerRepository.SuspendLayout();
            this.ToolStripCodeList.SuspendLayout();
            this.ToolStripCode.SuspendLayout();
            this.ToolStripCodeMaintenance.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitContainerRepository
            // 
            this.SplitContainerRepository.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerRepository.Location = new System.Drawing.Point(0, 0);
            this.SplitContainerRepository.Name = "SplitContainerRepository";
            // 
            // SplitContainerRepository.Panel1
            // 
            this.SplitContainerRepository.Panel1.Controls.Add(this.ListBoxCodeList);
            this.SplitContainerRepository.Panel1.Controls.Add(this.ToolStripCodeList);
            this.SplitContainerRepository.Panel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            // 
            // SplitContainerRepository.Panel2
            // 
            this.SplitContainerRepository.Panel2.Controls.Add(this.RichTextBoxQueryData);
            this.SplitContainerRepository.Panel2.Controls.Add(this.ToolStripCode);
            this.SplitContainerRepository.Panel2.Controls.Add(this.ToolStripCodeMaintenance);
            this.SplitContainerRepository.Size = new System.Drawing.Size(1184, 764);
            this.SplitContainerRepository.SplitterDistance = 392;
            this.SplitContainerRepository.TabIndex = 1;
            // 
            // ListBoxCodeList
            // 
            this.ListBoxCodeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBoxCodeList.ItemHeight = 17;
            this.ListBoxCodeList.Location = new System.Drawing.Point(0, 44);
            this.ListBoxCodeList.Name = "ListBoxCodeList";
            this.ListBoxCodeList.Size = new System.Drawing.Size(392, 720);
            this.ListBoxCodeList.Sorted = true;
            this.ListBoxCodeList.TabIndex = 2;
            this.ListBoxCodeList.SelectedIndexChanged += new System.EventHandler(this.ListBoxCodeList_SelectedIndexChanged);
            // 
            // ToolStripCodeList
            // 
            this.ToolStripCodeList.AutoSize = false;
            this.ToolStripCodeList.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ToolStripCodeList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelLogo,
            this.toolStripLabel1,
            this.ToolStripTextBoxSearchCodeList,
            this.ToolStripButtonSearch,
            this.ToolStripButtonNext});
            this.ToolStripCodeList.Location = new System.Drawing.Point(0, 0);
            this.ToolStripCodeList.Name = "ToolStripCodeList";
            this.ToolStripCodeList.Size = new System.Drawing.Size(392, 44);
            this.ToolStripCodeList.TabIndex = 1;
            this.ToolStripCodeList.Text = "toolStrip1";
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
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(52, 41);
            this.toolStripLabel1.Text = "Search:";
            // 
            // ToolStripTextBoxSearchCodeList
            // 
            this.ToolStripTextBoxSearchCodeList.AutoSize = false;
            this.ToolStripTextBoxSearchCodeList.Name = "ToolStripTextBoxSearchCodeList";
            this.ToolStripTextBoxSearchCodeList.Size = new System.Drawing.Size(160, 23);
            this.ToolStripTextBoxSearchCodeList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ToolStripTextBoxSearchCodeList_KeyDown);
            // 
            // ToolStripButtonSearch
            // 
            this.ToolStripButtonSearch.Image = global::SQLDBProfiler.Properties.Resources.Search;
            this.ToolStripButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonSearch.Name = "ToolStripButtonSearch";
            this.ToolStripButtonSearch.Size = new System.Drawing.Size(55, 41);
            this.ToolStripButtonSearch.Text = "Find";
            this.ToolStripButtonSearch.Click += new System.EventHandler(this.ToolStripButtonSearch_Click);
            // 
            // ToolStripButtonNext
            // 
            this.ToolStripButtonNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButtonNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonNext.Margin = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.ToolStripButtonNext.Name = "ToolStripButtonNext";
            this.ToolStripButtonNext.Size = new System.Drawing.Size(41, 41);
            this.ToolStripButtonNext.Text = "Next";
            this.ToolStripButtonNext.Click += new System.EventHandler(this.ToolStripButtonNext_Click);
            // 
            // RichTextBoxQueryData
            // 
            this.RichTextBoxQueryData.BackColor = System.Drawing.Color.White;
            this.RichTextBoxQueryData.BulletIndent = 2;
            this.RichTextBoxQueryData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichTextBoxQueryData.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTextBoxQueryData.Location = new System.Drawing.Point(0, 44);
            this.RichTextBoxQueryData.Name = "RichTextBoxQueryData";
            this.RichTextBoxQueryData.ReadOnly = true;
            this.RichTextBoxQueryData.Size = new System.Drawing.Size(788, 684);
            this.RichTextBoxQueryData.TabIndex = 5;
            this.RichTextBoxQueryData.Text = "";
            // 
            // ToolStripCode
            // 
            this.ToolStripCode.AutoSize = false;
            this.ToolStripCode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ToolStripCode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButtonClose,
            this.ToolStripLabelCodeHeading});
            this.ToolStripCode.Location = new System.Drawing.Point(0, 0);
            this.ToolStripCode.Name = "ToolStripCode";
            this.ToolStripCode.Size = new System.Drawing.Size(788, 44);
            this.ToolStripCode.TabIndex = 6;
            this.ToolStripCode.Text = "toolStrip1";
            // 
            // ToolStripButtonClose
            // 
            this.ToolStripButtonClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripButtonClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButtonClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ToolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonClose.Name = "ToolStripButtonClose";
            this.ToolStripButtonClose.Size = new System.Drawing.Size(54, 41);
            this.ToolStripButtonClose.Text = " Close ";
            this.ToolStripButtonClose.Click += new System.EventHandler(this.ToolStripButtonClose_Click);
            // 
            // ToolStripLabelCodeHeading
            // 
            this.ToolStripLabelCodeHeading.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.ToolStripLabelCodeHeading.ForeColor = System.Drawing.Color.RoyalBlue;
            this.ToolStripLabelCodeHeading.Name = "ToolStripLabelCodeHeading";
            this.ToolStripLabelCodeHeading.Size = new System.Drawing.Size(17, 41);
            this.ToolStripLabelCodeHeading.Text = " ";
            // 
            // ToolStripCodeMaintenance
            // 
            this.ToolStripCodeMaintenance.AutoSize = false;
            this.ToolStripCodeMaintenance.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolStripCodeMaintenance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ToolStripCodeMaintenance.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButtonCopyToClipboard,
            this.toolStripLabel3,
            this.ToolStripButtonAddCode,
            this.ToolStripButtonUpdate,
            this.ToolStripButtonDelete});
            this.ToolStripCodeMaintenance.Location = new System.Drawing.Point(0, 728);
            this.ToolStripCodeMaintenance.Name = "ToolStripCodeMaintenance";
            this.ToolStripCodeMaintenance.Size = new System.Drawing.Size(788, 36);
            this.ToolStripCodeMaintenance.TabIndex = 7;
            this.ToolStripCodeMaintenance.Text = "toolStrip1";
            // 
            // ToolStripButtonCopyToClipboard
            // 
            this.ToolStripButtonCopyToClipboard.Image = global::SQLDBProfiler.Properties.Resources.TaskHH;
            this.ToolStripButtonCopyToClipboard.ImageTransparentColor = System.Drawing.Color.Black;
            this.ToolStripButtonCopyToClipboard.Name = "ToolStripButtonCopyToClipboard";
            this.ToolStripButtonCopyToClipboard.Size = new System.Drawing.Size(206, 33);
            this.ToolStripButtonCopyToClipboard.Text = "Copy SQL Code to Clipboard";
            this.ToolStripButtonCopyToClipboard.Click += new System.EventHandler(this.ToolStripButtonCopyToClipboard_Click);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.AutoSize = false;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(150, 29);
            this.toolStripLabel3.Text = " ";
            // 
            // ToolStripButtonAddCode
            // 
            this.ToolStripButtonAddCode.Image = global::SQLDBProfiler.Properties.Resources.NewDocument_32x32;
            this.ToolStripButtonAddCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonAddCode.Margin = new System.Windows.Forms.Padding(0, 1, 15, 2);
            this.ToolStripButtonAddCode.Name = "ToolStripButtonAddCode";
            this.ToolStripButtonAddCode.Size = new System.Drawing.Size(54, 33);
            this.ToolStripButtonAddCode.Text = "Add";
            this.ToolStripButtonAddCode.Click += new System.EventHandler(this.ToolStripButtonAddCode_Click);
            // 
            // ToolStripButtonUpdate
            // 
            this.ToolStripButtonUpdate.Image = global::SQLDBProfiler.Properties.Resources.Import;
            this.ToolStripButtonUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonUpdate.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.ToolStripButtonUpdate.Name = "ToolStripButtonUpdate";
            this.ToolStripButtonUpdate.Size = new System.Drawing.Size(74, 33);
            this.ToolStripButtonUpdate.Text = "Update";
            this.ToolStripButtonUpdate.Click += new System.EventHandler(this.ToolStripButtonUpdate_Click);
            // 
            // ToolStripButtonDelete
            // 
            this.ToolStripButtonDelete.Image = global::SQLDBProfiler.Properties.Resources.delete;
            this.ToolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonDelete.Name = "ToolStripButtonDelete";
            this.ToolStripButtonDelete.Size = new System.Drawing.Size(68, 33);
            this.ToolStripButtonDelete.Text = "Delete";
            this.ToolStripButtonDelete.Click += new System.EventHandler(this.ToolStripButtonDelete_Click);
            // 
            // SqlCodeRepository
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 764);
            this.Controls.Add(this.SplitContainerRepository);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "SqlCodeRepository";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SQL Code Repository";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SqlCodeRepository_FormClosing);
            this.Load += new System.EventHandler(this.SqlCodeRepository_Load);
            this.SplitContainerRepository.Panel1.ResumeLayout(false);
            this.SplitContainerRepository.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerRepository)).EndInit();
            this.SplitContainerRepository.ResumeLayout(false);
            this.ToolStripCodeList.ResumeLayout(false);
            this.ToolStripCodeList.PerformLayout();
            this.ToolStripCode.ResumeLayout(false);
            this.ToolStripCode.PerformLayout();
            this.ToolStripCodeMaintenance.ResumeLayout(false);
            this.ToolStripCodeMaintenance.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitContainerRepository;
        private System.Windows.Forms.ToolStrip ToolStripCodeList;
        private System.Windows.Forms.ListBox ListBoxCodeList;
        private System.Windows.Forms.ToolStripTextBox ToolStripTextBoxSearchCodeList;
        private System.Windows.Forms.ToolStripButton ToolStripButtonSearch;
        private System.Windows.Forms.ToolStripButton ToolStripButtonNext;
        private System.Windows.Forms.RichTextBox RichTextBoxQueryData;
        private System.Windows.Forms.ToolStrip ToolStripCode;
        private System.Windows.Forms.ToolStrip ToolStripCodeMaintenance;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton ToolStripButtonDelete;
        private System.Windows.Forms.ToolStripButton ToolStripButtonUpdate;
        private System.Windows.Forms.ToolStripButton ToolStripButtonAddCode;
        private System.Windows.Forms.ToolStripButton ToolStripButtonCopyToClipboard;
        private System.Windows.Forms.ToolStripButton ToolStripButtonClose;
        private System.Windows.Forms.ToolStripLabel ToolStripLabelCodeHeading;
        private System.Windows.Forms.ToolStripLabel toolStripLabelLogo;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}