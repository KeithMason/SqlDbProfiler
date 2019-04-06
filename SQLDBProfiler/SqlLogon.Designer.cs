namespace SQLDBProfiler
{
    partial class SqlLogon
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
            System.Windows.Forms.PictureBox PictureBoxLogo;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqlLogon));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ComboBoxAuthentication = new System.Windows.Forms.ComboBox();
            this.TextBoxServer = new System.Windows.Forms.TextBox();
            this.TextBoxUserName = new System.Windows.Forms.TextBox();
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            PictureBoxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(PictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBoxLogo
            // 
            PictureBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            PictureBoxLogo.Image = global::SQLDBProfiler.Properties.Resources.SqlDbProfiler1;
            PictureBoxLogo.InitialImage = global::SQLDBProfiler.Properties.Resources.SqlDbProfiler1;
            PictureBoxLogo.Location = new System.Drawing.Point(22, 12);
            PictureBoxLogo.Name = "PictureBoxLogo";
            PictureBoxLogo.Size = new System.Drawing.Size(100, 100);
            PictureBoxLogo.TabIndex = 7;
            PictureBoxLogo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(133, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 38);
            this.label1.TabIndex = 6;
            this.label1.Text = "SQL Server Logon";
            // 
            // buttonConnect
            // 
            this.buttonConnect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonConnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonConnect.Location = new System.Drawing.Point(248, 290);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(85, 26);
            this.buttonConnect.TabIndex = 4;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonCancel.Location = new System.Drawing.Point(348, 290);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(65, 26);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(72, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Server:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.Location = new System.Drawing.Point(20, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Authentication:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.Location = new System.Drawing.Point(42, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "User Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.Location = new System.Drawing.Point(52, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "Password:";
            // 
            // ComboBoxAuthentication
            // 
            this.ComboBoxAuthentication.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ComboBoxAuthentication.FormattingEnabled = true;
            this.ComboBoxAuthentication.Items.AddRange(new object[] {
            "Windows authentication",
            "SQL Server authentication"});
            this.ComboBoxAuthentication.Location = new System.Drawing.Point(140, 166);
            this.ComboBoxAuthentication.Name = "ComboBoxAuthentication";
            this.ComboBoxAuthentication.Size = new System.Drawing.Size(273, 25);
            this.ComboBoxAuthentication.TabIndex = 1;
            this.ComboBoxAuthentication.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAuthentication_SelectedIndexChanged);
            // 
            // TextBoxServer
            // 
            this.TextBoxServer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TextBoxServer.Location = new System.Drawing.Point(140, 127);
            this.TextBoxServer.Name = "TextBoxServer";
            this.TextBoxServer.Size = new System.Drawing.Size(273, 25);
            this.TextBoxServer.TabIndex = 0;
            // 
            // TextBoxUserName
            // 
            this.TextBoxUserName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TextBoxUserName.Location = new System.Drawing.Point(140, 205);
            this.TextBoxUserName.Name = "TextBoxUserName";
            this.TextBoxUserName.Size = new System.Drawing.Size(273, 25);
            this.TextBoxUserName.TabIndex = 2;
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TextBoxPassword.Location = new System.Drawing.Point(140, 244);
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.PasswordChar = '*';
            this.TextBoxPassword.Size = new System.Drawing.Size(273, 25);
            this.TextBoxPassword.TabIndex = 3;
            // 
            // SqlLogon
            // 
            this.AcceptButton = this.buttonConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(440, 338);
            this.ControlBox = false;
            this.Controls.Add(PictureBoxLogo);
            this.Controls.Add(this.TextBoxPassword);
            this.Controls.Add(this.TextBoxUserName);
            this.Controls.Add(this.TextBoxServer);
            this.Controls.Add(this.ComboBoxAuthentication);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SqlLogon";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SQL Server Logon";
            this.Load += new System.EventHandler(this.SqlLogon_Load);
            this.Shown += new System.EventHandler(this.SqlLogon_OnLoadComplete);
            ((System.ComponentModel.ISupportInitialize)(PictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ComboBoxAuthentication;
        private System.Windows.Forms.TextBox TextBoxServer;
        private System.Windows.Forms.TextBox TextBoxUserName;
        private System.Windows.Forms.TextBox TextBoxPassword;
    }
}