// ----------------------------------------------------------------------
// <copyright file="FindForm.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Find Form Class
    /// </summary>
    public partial class FindForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FindForm" /> class.
        /// </summary>
        public FindForm()
        {
            this.InitializeComponent();
        }
        
        /// <summary>
        /// Gets or sets the main form.
        /// </summary>
        /// <value>
        /// The main form.
        /// </value>
        public SqlDbProfiler MainForm { get; set; }

        /// <summary>
        /// Handles the Click event of the Find button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonFind_Click(object sender, EventArgs e)
        {
            this.MainForm.LastPattern = this.edPattern.Text;
            this.MainForm.PerformFind();
        }

        /// <summary>
        /// Handles the TextChanged event of the edPattern control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void EdPattern_TextChanged(object sender, EventArgs e)
        {
            this.MainForm.LastPosition = -1;
            this.MainForm.FocusListViewItem(this.MainForm.CachedListView[0]);
        }
    }
}
