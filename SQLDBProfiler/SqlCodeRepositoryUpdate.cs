// ----------------------------------------------------------------------
// <copyright file="SqlCodeRepositoryUpdate.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// SQL Code Repository Update
    /// </summary>
    public partial class SqlCodeRepositoryUpdate : Form
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlCodeRepositoryUpdate"/> class.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="sqlCodeDescription">The SQL code description.</param>
        /// <param name="sqlCode">The SQL code.</param>
        public SqlCodeRepositoryUpdate(string action, string sqlCodeDescription, string sqlCode)
        {
            this.InitializeComponent();

            this.Action = action;
            this.SqlCodeDescription = sqlCodeDescription;
            this.SqlCode = sqlCode;

            if (action == "Update")
            {
                this.TextBoxCodeDescription.Text = this.SqlCodeDescription;
                this.RichTextBoxSqlCode.Text = this.SqlCode;
            }
        }

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets the SQL code.
        /// </summary>
        /// <value>
        /// The SQL code.
        /// </value>
        public string SqlCode { get; set; }

        /// <summary>
        /// Gets or sets the SQL code description.
        /// </summary>
        /// <value>
        /// The SQL code description.
        /// </value>
        public string SqlCodeDescription { get; set; }

        #endregion

        #region page events

        /// <summary>
        /// Handles the Shown event of the SQL Code Repository Update control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SqlCodeRepositoryUpdate_Shown(object sender, EventArgs e)
        {
            this.TextBoxCodeDescription.Focus();
        }

        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            this.SqlCodeDescription = this.TextBoxCodeDescription.Text;
            this.SqlCode = this.RichTextBoxSqlCode.Text;
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the ButtonCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.SqlCodeDescription = string.Empty;
            this.SqlCode = string.Empty;
            this.Close();
        }

        #endregion
    }
}
