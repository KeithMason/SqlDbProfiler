// ----------------------------------------------------------------------
// <copyright file="SqlCodeRepository.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// Code Repository Form
    /// </summary>
    public partial class SqlCodeRepository : Form
    {
        #region private fields

        /// <summary>
        /// The Trace Utilities
        /// </summary>
        private readonly TraceUtilities traceUtilities = new TraceUtilities();

        /// <summary>
        /// Is the form loaded
        /// </summary>
        private bool formLoaded = false;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlCodeRepository" /> class.
        /// </summary>
        /// <param name="parentForm">The parent form.</param>
        public SqlCodeRepository(Form parentForm)
        {
            this.InitializeComponent();
            this.AdjustFormSize(parentForm);
        }

        #endregion

        #region properties

        /// <summary>
        /// Gets or sets the SQL code repository XML.
        /// </summary>
        /// <value>
        /// The SQL code repository XML.
        /// </value>
        public SqlQueries SqlCodeRepositoryQueries { get; set; }

        #endregion

        #region page events

        /// <summary>
        /// Handles the Load event of the SQL Code Repository control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SqlCodeRepository_Load(object sender, EventArgs e)
        {
            this.formLoaded = false;
            this.LoadSqlRepository();
            this.LoadListBoxCodeList();
            this.formLoaded = true;

            this.ListBoxCodeList.SelectedIndex = this.ListBoxCodeList.Items.Count == 0 ? -1 : 0;
        }

        /// <summary>
        /// Handles the FormClosing event of the SQL Code Repository control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void SqlCodeRepository_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.FormRepositorySplitterPosition = this.SplitContainerRepository.SplitterDistance;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Handles the Click event of the ToolStripButtonClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ToolStripButtonClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the ListBoxCodeList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ListBoxCodeList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.formLoaded && sender.GetType() == typeof(ListBox))
            {
                ListBox codeNameListbox = (ListBox)sender;

                foreach (SqlQuery query in this.SqlCodeRepositoryQueries.QueryItems)
                {
                    if (query.SqlName == codeNameListbox.SelectedItem.ToString())
                    {
                        this.traceUtilities.FillRichEdit(this.RichTextBoxQueryData, query.SqlCode);
                        this.ToolStripLabelCodeHeading.Text = query.SqlName;
                        this.ToolStripCodeMaintenance.Focus();
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the ToolStripButtonCopyToClipboard control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ToolStripButtonCopyToClipboard_Click(object sender, System.EventArgs e)
        {
            Clipboard.SetText(this.RichTextBoxQueryData.Text);

            MessageBox.Show(
                "SQL Code copied to clipboard",
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Handles the Click event of the ToolStripButtonSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ToolStripButtonSearch_Click(object sender, System.EventArgs e)
        {
            this.SearchCodeList();
        }

        /// <summary>
        /// Handles the Click event of the ToolStripButtonNext control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ToolStripButtonNext_Click(object sender, System.EventArgs e)
        {
            this.SearchCodeList(true);
        }

        /// <summary>
        /// Handles the KeyDown event of the ToolStripTextBoxSearchCodeList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void ToolStripTextBoxSearchCodeList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ToolStripButtonSearch.PerformClick();
            }
        }

        /// <summary>
        /// Handles the Click event of the ToolStripButtonAddCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ToolStripButtonAddCode_Click(object sender, System.EventArgs e)
        {
            if (this.ListBoxCodeList.SelectedIndex > -1)
            {
                using (SqlCodeRepositoryUpdate form = new SqlCodeRepositoryUpdate("Add", this.ListBoxCodeList.SelectedItem.ToString(), this.RichTextBoxQueryData.Text))
                {
                    DialogResult result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        SqlQuery item = new SqlQuery();
                        item.SqlName = form.SqlCodeDescription;
                        item.SqlCode = form.SqlCode;

                        this.SqlCodeRepositoryQueries.QueryItems.Add(item);
                        this.LoadListBoxCodeList();
                        this.ListBoxCodeList.SelectedItem = item.SqlName;
                        this.SaveSqlRepositoryQueries();
                    }
                }
            }
            else
            {
                MessageBox.Show(
                    "No code item selected!",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Handles the Click event of the ToolStripButtonUpdate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ToolStripButtonUpdate_Click(object sender, System.EventArgs e)
        {
            if (this.ListBoxCodeList.SelectedIndex > -1)
            {
                SqlQuery itemOriginal = this.SqlCodeRepositoryQueries.QueryItems.Find(
                    delegate(SqlQuery query)
                    {
                        return query.SqlName == this.ListBoxCodeList.SelectedItem.ToString();
                    });

                if (itemOriginal != null)
                {
                    using (SqlCodeRepositoryUpdate form = new SqlCodeRepositoryUpdate(
                        "Update",
                        this.ListBoxCodeList.SelectedItem.ToString(),
                        this.RichTextBoxQueryData.Text))
                    {
                        DialogResult result = form.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            SqlQuery item = new SqlQuery();
                            item.SqlName = form.SqlCodeDescription;
                            item.SqlCode = form.SqlCode;

                            this.SqlCodeRepositoryQueries.QueryItems.Remove(itemOriginal);
                            this.SqlCodeRepositoryQueries.QueryItems.Add(item);

                            this.LoadListBoxCodeList();
                            this.ListBoxCodeList.SelectedItem = item.SqlName;
                            this.SaveSqlRepositoryQueries();
                        }
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Selected item not found!",
                        "Error!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(
                    "No code item selected!",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Handles the Click event of the ToolStripButtonDelete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ToolStripButtonDelete_Click(object sender, System.EventArgs e)
        {
            if (this.ListBoxCodeList.SelectedIndex > -1)
            {
                SqlQuery itemOriginal = this.SqlCodeRepositoryQueries.QueryItems.Find(
                    delegate(SqlQuery query)
                    {
                        return query.SqlName == this.ListBoxCodeList.SelectedItem.ToString();
                    });

                if (itemOriginal != null)
                {
                    DialogResult result = MessageBox.Show(
                        string.Format("Confirm Delete:\r\n{0}", itemOriginal.SqlName),
                        "Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        this.SqlCodeRepositoryQueries.QueryItems.Remove(itemOriginal);
                        this.LoadListBoxCodeList();
                        this.ListBoxCodeList.SelectedIndex = this.ListBoxCodeList.Items.Count == 0 ? -1 : 0;
                        this.SaveSqlRepositoryQueries();
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Selected item not found!",
                        "Error!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(
                    "No code item selected!",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        #endregion

        #region private methods

        /// <summary>
        /// Adjusts the size of the form.
        /// </summary>
        /// <param name="parentForm">The parent form.</param>
        private void AdjustFormSize(Form parentForm)
        {
            this.Width = parentForm.Width;
            this.Height = parentForm.Height;
            this.WindowState = parentForm.WindowState;
            this.SplitContainerRepository.SplitterDistance = Properties.Settings.Default.FormRepositorySplitterPosition;
        }

        /// <summary>
        /// Loads the code list.
        /// </summary>
        private void LoadListBoxCodeList()
        {
            this.ListBoxCodeList.Items.Clear();

            foreach (SqlQuery query in this.SqlCodeRepositoryQueries.QueryItems)
            {
                this.ListBoxCodeList.Items.Add(query.SqlName);
            }

            this.ListBoxCodeList.Sorted = true;
        }

        /// <summary>
        /// Loads the SQL repository.
        /// </summary>
        private void LoadSqlRepository()
        {
            XmlDocument xmlDoc = new XmlDocument();
            string startupPath = Application.StartupPath;
            xmlDoc.Load(string.Format("{0}\\SqlRepository.xml", startupPath));

            XmlNodeReader reader = new XmlNodeReader(xmlDoc.DocumentElement);
            XmlSerializer ser = new XmlSerializer(typeof(SqlQueries));
            object obj = ser.Deserialize(reader);

            SqlQueries repositoryCode = new SqlQueries();
            repositoryCode = (SqlQueries)obj;

            this.SqlCodeRepositoryQueries = repositoryCode;
        }

        /// <summary>
        /// Searches the code list.
        /// </summary>
        /// <param name="findNext">if set to <c>true</c> [find next].</param>
        private void SearchCodeList(bool findNext = false)
        {
            int startIndex = findNext ? this.ListBoxCodeList.SelectedIndex + 1 : 0;
            bool found = false;
            for (int i = startIndex; i < this.ListBoxCodeList.Items.Count; i++)
            {
                string item = ((string)this.ListBoxCodeList.Items[i]).ToLower();

                if (item.Contains(this.ToolStripTextBoxSearchCodeList.Text.ToLower()))
                {
                    this.ListBoxCodeList.SelectedIndex = i;
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                MessageBox.Show(
                    "Search text not found!",
                    "Search",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Saves the SQL queries.
        /// </summary>
        private void SaveSqlRepositoryQueries()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SqlQueries));
                SqlQueries repositoryCode = this.SqlCodeRepositoryQueries;

                string startupPath = Application.StartupPath;
                using (var writer = new StreamWriter(string.Format("{0}\\SqlRepository.xml", startupPath)))
                {
                    serializer.Serialize(writer, repositoryCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
