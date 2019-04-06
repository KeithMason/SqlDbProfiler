// ----------------------------------------------------------------------
// <copyright file="SqlLogon.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// SQL Logon
    /// </summary>
    public partial class SqlLogon : Form
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlLogon"/> class.
        /// </summary>
        /// <param name="connectionParameters">The connection parameters.</param>
        public SqlLogon(ConnectionParameters connectionParameters)
        {
            this.InitializeComponent();
            this.ConnectParameters = connectionParameters;
        }

        #endregion

        #region properties

        /// <summary>
        /// Gets or sets the connect parameters.
        /// </summary>
        /// <value>
        /// The connect parameters.
        /// </value>
        public ConnectionParameters ConnectParameters { get; set; }

        #endregion

        #region page event

        /// <summary>
        /// Handles the Load event of the SQL Logon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SqlLogon_Load(object sender, EventArgs e)
        {
            this.TextBoxServer.Text = this.ConnectParameters.Server;
            this.TextBoxUserName.Text = this.ConnectParameters.UserName;
            this.TextBoxPassword.Text = this.ConnectParameters.Password;
            this.ComboBoxAuthentication.SelectedIndex = this.ConnectParameters.Authentication;
            this.UpdateEntryFields();
        }

        /// <summary>
        /// Handles the OnLoadComplete event of the SQL Logon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SqlLogon_OnLoadComplete(object sender, EventArgs e)
        {
            this.FocusEntryFields();
        }

        /// <summary>
        /// Handles the Click event of the buttonConnect control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            this.ConnectParameters.Server = this.TextBoxServer.Text;
            this.ConnectParameters.UserName = this.TextBoxUserName.Text;
            this.ConnectParameters.Password = this.TextBoxPassword.Text;
            this.ConnectParameters.Authentication = this.ComboBoxAuthentication.SelectedIndex;

            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the buttonCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the ComboBoxAuthentication control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ComboBoxAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateEntryFields();
        }

        #endregion

        #region private methods

        /// <summary>
        /// Updates the entry fields.
        /// </summary>
        private void UpdateEntryFields()
        {
            if (this.ComboBoxAuthentication.SelectedIndex == 0)
            {
                this.TextBoxUserName.Enabled = false;
                this.TextBoxPassword.Enabled = false;
            }
            else
            {
                this.TextBoxUserName.Enabled = true;
                this.TextBoxPassword.Enabled = true;
            }

            this.FocusEntryFields();
        }

        /// <summary>
        /// Focuses the entry fields.
        /// </summary>
        private void FocusEntryFields()
        {
            if (this.TextBoxServer.Text == string.Empty)
            {
                this.TextBoxServer.Focus();
            }
            else if (this.ComboBoxAuthentication.SelectedIndex == 1 && this.TextBoxUserName.Text == string.Empty)
            {
                this.TextBoxUserName.Focus();
            }
            else if (this.ComboBoxAuthentication.SelectedIndex == 1 && this.TextBoxPassword.Text == string.Empty)
            {
                this.TextBoxPassword.Focus();
            }
        }

        #endregion
    }
}
