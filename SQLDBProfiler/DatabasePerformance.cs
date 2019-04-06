// ----------------------------------------------------------------------
// <copyright file="DatabasePerformance.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// Database Performance Class
    /// </summary>
    public partial class DatabasePerformance : Form
    {
        #region private fields

        /// <summary>
        /// Is the form loaded
        /// </summary>
        private bool formLoaded = false;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabasePerformance"/> class.
        /// </summary>
        /// <param name="connectionParameters">The connection parameters.</param>
        /// <param name="parentForm">The parent form.</param>
        public DatabasePerformance(ConnectionParameters connectionParameters, Form parentForm)
        {
            this.InitializeComponent();
            this.AdjustFormSize(parentForm);

            this.ConnectionParams = connectionParameters;
            this.ConnectionString = this.GetConnectionString();
            this.DatabaseName = connectionParameters.Database;
        }

        #endregion

        #region properties

        /// <summary>
        /// Gets or sets the SQL performance queries.
        /// </summary>
        /// <value>
        /// The SQL performance queries.
        /// </value>
        public SqlQueries SqlPerformanceQueries { get; set; }

        /// <summary>
        /// Gets or sets the load other dialog.
        /// </summary>
        /// <value>
        /// The load other dialog.
        /// </value>
        public string LoadOtherDialog { get; set; }

        /// <summary>
        /// Gets or sets the connection.
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        private string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the connection parameters.
        /// </summary>
        /// <value>
        /// The connection parameters.
        /// </value>
        private ConnectionParameters ConnectionParams { get; set; }

        /// <summary>
        /// Gets or sets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        private string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        /// <value>
        /// The view.
        /// </value>
        private string CurrentQuery { get; set; }

        #endregion

        #region page events

        /// <summary>
        /// Handles the Load event of the DatabasePerformance control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DatabasePerformance_Load(object sender, EventArgs e)
        {
            this.formLoaded = false;

            this.DataGridViewPerformance.DefaultCellStyle.Font = new Font("Segoe UI", 9, GraphicsUnit.Point);
            this.DataGridViewPerformance.AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI", 9, GraphicsUnit.Point);
            this.DataGridViewPerformance.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, GraphicsUnit.Point);
            this.DataGridViewPerformance.ContextMenuStrip = this.contextMenuStrip1;

            this.LoadSqlPerformanceQueries();
            this.PopulateDatabaseComboBox();
            this.PopulateToolStripComboBoxQuery();

            this.formLoaded = true;
        }

        /// <summary>
        /// Handles the Shown event of the DatabasePerformance control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DatabasePerformance_Shown(object sender, EventArgs e)
        {
            this.GetDatabasePerformance();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the ToolStripComboBox_Database control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ToolStripComboBoxDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DatabaseName = this.ToolStripComboBoxDatabase.Text;
            this.ConnectionParams.Database = this.DatabaseName;

            this.GetDatabasePerformance();
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
        /// Handles the SelectedIndexChanged event of the ToolStripComboBoxQuery control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ToolStripComboBoxQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CurrentQuery = this.ToolStripComboBoxQuery.Text;
            this.GetDatabasePerformance();
        }

        /// <summary>
        /// Handles the Click event of the ToolStripButtonAutoSizeRows control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ToolStripButtonAutoSizeRows_Click(object sender, EventArgs e)
        {
            this.GetDatabasePerformance(true);
        }

        /// <summary>
        /// Handles the Click event of the ToolStripButtonSchemaQueries control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ToolStripButtonSchemaQueries_Click(object sender, EventArgs e)
        {
            this.LoadOtherDialog = "Schema";
            this.Close();
        }

        /// <summary>
        /// Handles the 1 event of the copySelectedToClipboardToolStripMenuItem_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CopySelectedToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.DataGridViewPerformance.GetSelectedDataGridViewCells());
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
            this.WindowState = parentForm.WindowState == FormWindowState.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
        }

        /// <summary>
        /// Populates the database.
        /// </summary>
        private void PopulateDatabaseComboBox()
        {
            DatabaseSchemaAccessLayer databaseInfo = new DatabaseSchemaAccessLayer(this.ConnectionParams);
            List<string> databases = databaseInfo.GetDatabaseList();
            this.ToolStripComboBoxDatabase.Items.AddRange(databases.ToArray());

            if (string.IsNullOrEmpty(this.DatabaseName))
            {
                this.ToolStripComboBoxDatabase.SelectedIndex = 0;
            }
            else
            {
                this.ToolStripComboBoxDatabase.Text = this.DatabaseName;
            }
        }

        /// <summary>
        /// Populates the tool strip combo box query.
        /// </summary>
        private void PopulateToolStripComboBoxQuery()
        {
            Array queryArray = this.SqlPerformanceQueries.QueryItems.ToArray();

            foreach (SqlQuery sql in queryArray)
            {
                this.ToolStripComboBoxQuery.Items.Add(sql.SqlName);
            }

            if (this.ToolStripComboBoxQuery.Items.Count > 0)
            {
                this.ToolStripComboBoxQuery.SelectedIndex = 0;
                this.CurrentQuery = this.ToolStripComboBoxQuery.Text;
            }
        }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <returns>the connection string</returns>
        private string GetConnectionString()
        {
            string constr = this.ConnectionParams.Authentication == 0 ? string.Format(
                                    @"Data Source = {0};Initial Catalog={1};Integrated Security=SSPI;Application Name=SQL DB Profiler",
                                    this.ConnectionParams.Server,
                                    this.ConnectionParams.Database)
                           : string.Format(
                                    @"Data Source={0};Initial Catalog={3};User Id={1};Password={2};;Application Name=SQL DB Profiler",
                                    this.ConnectionParams.Server,
                                    this.ConnectionParams.UserName,
                                    this.ConnectionParams.Password,
                                    this.ConnectionParams.Database);

            return constr;
        }

        /// <summary>
        /// Shows the no data panel.
        /// </summary>
        private void ShowNoDataPanel()
        {
            this.panelNoData.Left = (this.DataGridViewPerformance.Width / 2) - 80;
            this.panelNoData.Top = (this.DataGridViewPerformance.Height / 2) - 30;
            this.panelNoData.BringToFront();
        }

        #endregion

        #region performance private methods

        /// <summary>
        /// Gets the database view.
        /// </summary>
        /// <param name="autoSizeRows">if set to <c>true</c> [auto size rows].</param>
        private void GetDatabasePerformance(bool autoSizeRows = false)
        {
            if (this.formLoaded)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    this.DataGridViewPerformance.Cursor = Cursors.WaitCursor;
                    this.panelNoData.SendToBack();
                    this.toolStripStatusExecuting.Visible = true;
                    this.ToolStripButtonAutoSizeRows.Visible = false;
                    this.DataGridViewPerformance.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                    this.DataGridViewPerformance.DataSource = null;
                    Application.DoEvents();

                    this.ConnectionString = this.GetConnectionString();
                    SqlQueryDataAccess.ExecuteUseDatabase(this.DatabaseName, this.ConnectionString);
                    string sqlStatement = string.Empty;

                    foreach (SqlQuery sql in this.SqlPerformanceQueries.QueryItems)
                    {
                        if (sql.SqlName == this.CurrentQuery)
                        {
                            this.DataGridViewPerformance.DataSource = SqlQueryDataAccess.GetPerformanceQueryResults(sql.SqlCode, this.ConnectionString);
                            break;
                        }
                    }

                    if (this.DataGridViewPerformance.Rows.Count > 0)
                    {
                        int maxColumnWidth = Properties.Settings.Default.MaxColumnWidth;

                        foreach (DataGridViewColumn column in this.DataGridViewPerformance.Columns)
                        {
                            if (column.Width > maxColumnWidth)
                            {
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                                column.Width = maxColumnWidth;
                                if (autoSizeRows)
                                {
                                    column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                                    this.DataGridViewPerformance.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                                }

                                this.ToolStripButtonAutoSizeRows.Visible = true;
                            }

                            if (column.IsNumericColumn())
                            {
                                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                                if (column.IsDecimalColumn())
                                {
                                    column.DefaultCellStyle.Format = "N2";
                                }
                                else
                                {
                                    column.DefaultCellStyle.Format = "N0";
                                }
                            }
                        }
                    }
                    else
                    {
                        this.ShowNoDataPanel();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.toolStripStatusRowCount.Text = string.Format("{0} rows  ", this.DataGridViewPerformance.Rows.Count);
                this.toolStripStatusExecuting.Visible = false;
                this.DataGridViewPerformance.Cursor = Cursors.Default;
                this.Cursor = Cursors.Default;
                this.DataGridViewPerformance.Focus();
            }
        }

        /// <summary>
        /// Loads the SQL performance queries.
        /// </summary>
        private void LoadSqlPerformanceQueries()
        {
            XmlDocument xmlDoc = new XmlDocument();

            string startupPath = Application.StartupPath;
            xmlDoc.Load(string.Format("{0}\\SqlPerformance.xml", startupPath));

            XmlNodeReader reader = new XmlNodeReader(xmlDoc.DocumentElement);
            XmlSerializer ser = new XmlSerializer(typeof(SqlQueries));
            object obj = ser.Deserialize(reader);

            SqlQueries performanceQueries = new SqlQueries();
            performanceQueries = (SqlQueries)obj;

            this.SqlPerformanceQueries = performanceQueries;
        }

        #endregion
    }
}
