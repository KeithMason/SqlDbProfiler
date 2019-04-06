// ----------------------------------------------------------------------
// <copyright file="DatabaseSchema.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Database Schema
    /// </summary>
    public partial class DatabaseSchema : Form
    {
        #region private fields

        /// <summary>
        /// Is the form loaded
        /// </summary>
        private bool formLoaded = false;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseSchema" /> class.
        /// </summary>
        /// <param name="connectionParameters">The connection parameters.</param>
        /// <param name="parentForm">The parent form.</param>
        public DatabaseSchema(ConnectionParameters connectionParameters, Form parentForm)
        {
            this.InitializeComponent();
            this.AdjustFormSize(parentForm);

            this.ConnectionParams = connectionParameters;
            this.ConnectionString = this.GetConnectionString();
            this.DatabaseName = connectionParameters.Database;
            this.CurrentSchema = EnumDatabaseViews.DatabaseFiles;
        }

        #endregion

        #region properties

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
        private EnumDatabaseViews CurrentSchema { get; set; }

        #endregion

        #region page events

        /// <summary>
        /// Handles the Load event of the DatabaseInformatics control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DatabaseSchema_Load(object sender, EventArgs e)
        {
            this.formLoaded = false;

            this.DataGridViewSchema.DefaultCellStyle.Font = new Font("Segoe UI", 9, GraphicsUnit.Point);
            this.DataGridViewSchema.AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI", 9, GraphicsUnit.Point);
            this.DataGridViewSchema.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, GraphicsUnit.Point);
            this.DataGridViewSchema.ContextMenuStrip = this.contextMenuStrip1;

            this.toolStripComboBoxQuery.SelectedIndex = 0;
            this.PopulateDatabaseComboBox();

            this.formLoaded = true;
        }

        /// <summary>
        /// Handles the Shown event of the DatabaseSchema control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DatabaseSchema_Shown(object sender, EventArgs e)
        {
            this.GetDatabaseInformatics();
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
        /// Handles the SelectedIndexChanged event of the ToolStripComboBox_Database control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ToolStripComboBox_Database_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DatabaseName = this.ToolStripComboBoxDatabase.Text;
            this.ConnectionParams.Database = this.DatabaseName;

            this.GetDatabaseInformatics();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the ToolStripComboBoxQuery control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ToolStripComboBoxQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.toolStripComboBoxQuery.Text)
            {
                case "Table Row Counts":
                    this.CurrentSchema = EnumDatabaseViews.TableRowCount;
                    break;
                case "Index Usage":
                    this.CurrentSchema = EnumDatabaseViews.IndexUsage;
                    break;
                case "Unused Indexes":
                    this.CurrentSchema = EnumDatabaseViews.UnusedIndexes;
                    break;
                case "All Identity Fields":
                    this.CurrentSchema = EnumDatabaseViews.IdentityFields;
                    break;
                case "All Primary Keys":
                    this.CurrentSchema = EnumDatabaseViews.PrimaryKeys;
                    break;
                case "All Foreign Keys":
                    this.CurrentSchema = EnumDatabaseViews.ForeignKeys;
                    break;
                case "Non-Clustered Indexes":
                    this.CurrentSchema = EnumDatabaseViews.NonClusteredIndexes;
                    break;
                case "Tables with no Primary Keys":
                    this.CurrentSchema = EnumDatabaseViews.NoPrimaryKey;
                    break;
                case "Changes in the last 90 days":
                    this.CurrentSchema = EnumDatabaseViews.ChangesLast90Days;
                    break;
                case "All Triggers":
                    this.CurrentSchema = EnumDatabaseViews.Triggers;
                    break;
                default:
                    this.CurrentSchema = EnumDatabaseViews.DatabaseFiles;
                    break;
            }

            this.GetDatabaseInformatics();
        }

        /// <summary>
        /// Handles the Click event of the ToolStripButtonPerformanceQueries control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ToolStripButtonPerformanceQueries_Click(object sender, EventArgs e)
        {
            this.LoadOtherDialog = "Performance";
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the copySelectedToClipboardToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CopySelectedToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.DataGridViewSchema.GetSelectedDataGridViewCells());
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
            this.panelNoData.Left = (this.DataGridViewSchema.Width / 2) - 80;
            this.panelNoData.Top = (this.DataGridViewSchema.Height / 2) - 30;
            this.panelNoData.BringToFront();
        }

        #endregion

        #region informatic private methods

        /// <summary>
        /// Gets the database view.
        /// </summary>
        private void GetDatabaseInformatics()
        {
            if (this.formLoaded)
            {
                this.Cursor = Cursors.WaitCursor;
                this.DataGridViewSchema.Cursor = Cursors.WaitCursor;
                this.panelNoData.SendToBack();
                this.toolStripStatusExecuting.Visible = true;
                this.toolStripStatusRowCount.Text = "0 rows  ";
                this.DataGridViewSchema.DataSource = null;
                Application.DoEvents();

                switch (this.CurrentSchema)
                {
                    case EnumDatabaseViews.ChangesLast90Days:
                        {
                            this.GetDatabaseChangesLast90Days();
                            break;
                        }

                    case EnumDatabaseViews.ForeignKeys:
                        {
                            this.GetDatabaseForeignKeys();
                            break;
                        }

                    case EnumDatabaseViews.IndexUsage:
                        {
                            this.GetDatabaseIndexUsage();
                            break;
                        }

                    case EnumDatabaseViews.IdentityFields:
                        {
                            this.GetIdentityFields();
                            break;
                        }

                    case EnumDatabaseViews.DatabaseFiles:
                        {
                            this.GetDatabaseFilesInformation();
                            break;
                        }

                    case EnumDatabaseViews.NonClusteredIndexes:
                        {
                            this.GetDatabaseNonClusteredIndexes();
                            break;
                        }

                    case EnumDatabaseViews.NoPrimaryKey:
                        {
                            this.GetDatabaseNoPrimaryKey();
                            break;
                        }

                    case EnumDatabaseViews.PrimaryKeys:
                        {
                            this.GetDatabasePrimaryKeys();
                            break;
                        }

                    case EnumDatabaseViews.TableRowCount:
                        {
                            this.GetTableRowCounts();
                            break;
                        }

                    case EnumDatabaseViews.UnusedIndexes:
                        {
                            this.GetDatabaseUnusedIndexes();
                            break;
                        }

                    case EnumDatabaseViews.Triggers:
                        {
                            this.GetDatabaseTriggers();
                            break;
                        }

                    default:
                        {
                            this.GetDatabaseFilesInformation();
                            break;
                        }
                }

                this.toolStripStatusRowCount.Text = string.Format("{0} rows  ", this.DataGridViewSchema.Rows.Count);
                this.toolStripStatusExecuting.Visible = false;
                this.DataGridViewSchema.Cursor = Cursors.Default;
                this.Cursor = Cursors.Default;
                if (this.DataGridViewSchema.RowCount == 0)
                {
                    this.ShowNoDataPanel();
                }

                this.DataGridViewSchema.Focus();
            }
        }

        /// <summary>
        /// Gets the database changes last90 days.
        /// </summary>
        private void GetDatabaseChangesLast90Days()
        {
            DatabaseSchemaAccessLayer databaseInfo = new DatabaseSchemaAccessLayer(this.ConnectionParams);

            List<DatabaseChangesLast90Days> changesLast90Days = databaseInfo.GetDatabaseChangesLast90Days(this.DatabaseName);
            int count = changesLast90Days.Count;

            if (changesLast90Days.Count > 0)
            {
                this.DataGridViewSchema.DataSource = changesLast90Days;
                int dataGridViewWidth = this.DataGridViewSchema.Width;

                this.DataGridViewSchema.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                this.DataGridViewSchema.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                this.DataGridViewSchema.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                this.DataGridViewSchema.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                this.DataGridViewSchema.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            }
        }

        /// <summary>
        /// Gets the database foreign keys.
        /// </summary>
        private void GetDatabaseForeignKeys()
        {
            DatabaseSchemaAccessLayer databaseInfo = new DatabaseSchemaAccessLayer(this.ConnectionParams);

            List<DatabaseForeignKeys> primaryKeys = databaseInfo.GetDatabaseForeignKeys(this.DatabaseName);
            int count = primaryKeys.Count;

            if (primaryKeys.Count > 0)
            {
                this.DataGridViewSchema.DataSource = primaryKeys;
                int dataGridViewWidth = this.DataGridViewSchema.Width;

                this.DataGridViewSchema.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                this.DataGridViewSchema.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                this.DataGridViewSchema.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
            }
        }

        /// <summary>
        /// Gets the size of the database files information.
        /// </summary>
        private void GetDatabaseFilesInformation()
        {
            try
            {
                DatabaseSchemaAccessLayer databaseInfo = new DatabaseSchemaAccessLayer(this.ConnectionParams);
                List<DatabaseNameSize> databaseNameSize = databaseInfo.GetDatabaseNameSize(this.DatabaseName);

                if (databaseNameSize.Count > 0)
                {
                    this.DataGridViewSchema.DataSource = databaseNameSize;
                    int dataGridViewWidth = this.DataGridViewSchema.Width;

                    this.DataGridViewSchema.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                    this.DataGridViewSchema.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                    this.DataGridViewSchema.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                    this.DataGridViewSchema.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                    this.DataGridViewSchema.Columns[3].DefaultCellStyle.Format = "N0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Gets the table row counts.
        /// </summary>
        private void GetTableRowCounts()
        {
            try
            {
                DatabaseSchemaAccessLayer databaseInfo = new DatabaseSchemaAccessLayer(this.ConnectionParams);
                List<DatabaseTableRowCounts> tbleRowCounts = databaseInfo.GetTableRowCounts(this.DatabaseName);

                if (tbleRowCounts.Count > 0)
                {
                    this.DataGridViewSchema.DataSource = tbleRowCounts;
                    int dataGridViewWidth = this.DataGridViewSchema.Width;

                    this.DataGridViewSchema.Columns[0].MinimumWidth = Convert.ToInt32(dataGridViewWidth * .3);

                    this.DataGridViewSchema.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                    this.DataGridViewSchema.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                    this.DataGridViewSchema.Columns[1].DefaultCellStyle.Format = "N0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// All Identity Fields
        /// </summary>
        private void GetIdentityFields()
        {
            DatabaseSchemaAccessLayer databaseInfo = new DatabaseSchemaAccessLayer(this.ConnectionParams);

            List<DatabaseIdentityFields> identityFields = databaseInfo.GetIdentityFields(this.DatabaseName);
            int count = identityFields.Count;

            if (identityFields.Count > 0)
            {
                this.DataGridViewSchema.DataSource = identityFields;
                int dataGridViewWidth = this.DataGridViewSchema.Width;

                this.DataGridViewSchema.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                this.DataGridViewSchema.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                this.DataGridViewSchema.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                this.DataGridViewSchema.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                this.DataGridViewSchema.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                this.DataGridViewSchema.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                this.DataGridViewSchema.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                this.DataGridViewSchema.Columns[4].DefaultCellStyle.Format = "N0";
                this.DataGridViewSchema.Columns[5].DefaultCellStyle.Format = "N0";
                this.DataGridViewSchema.Columns[6].DefaultCellStyle.Format = "N0";
            }
        }

        /// <summary>
        /// Gets the database unused indexes.
        /// </summary>
        private void GetDatabaseUnusedIndexes()
        {
            DatabaseSchemaAccessLayer databaseInfo = new DatabaseSchemaAccessLayer(this.ConnectionParams);

            List<DatabaseUnusedIndexes> unusedIndexes = databaseInfo.GetDatabaseUnusedIndexes(this.DatabaseName);
            int count = unusedIndexes.Count;

            if (unusedIndexes.Count > 0)
            {
                this.DataGridViewSchema.DataSource = unusedIndexes;
                int dataGridViewWidth = this.DataGridViewSchema.Width;

                this.DataGridViewSchema.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                this.DataGridViewSchema.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                this.DataGridViewSchema.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
            }
        }

        /// <summary>
        /// Gets the database primary keys.
        /// </summary>
        private void GetDatabasePrimaryKeys()
        {
            DatabaseSchemaAccessLayer databaseInfo = new DatabaseSchemaAccessLayer(this.ConnectionParams);

            List<DatabasePrimaryKeys> primaryKeys = databaseInfo.GetDatabasePrimaryKeys(this.DatabaseName);
            int count = primaryKeys.Count;

            if (primaryKeys.Count > 0)
            {
                this.DataGridViewSchema.DataSource = primaryKeys;
                int dataGridViewWidth = this.DataGridViewSchema.Width;

                this.DataGridViewSchema.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                this.DataGridViewSchema.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                this.DataGridViewSchema.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
            }
        }

        /// <summary>
        /// Gets the database non clustered indexes.
        /// </summary>
        private void GetDatabaseNonClusteredIndexes()
        {
            DatabaseSchemaAccessLayer databaseInfo = new DatabaseSchemaAccessLayer(this.ConnectionParams);

            List<DatabaseNonClusteredIndexes> indexFragmentation = databaseInfo.GetDatabaseNonClusteredIndexes(this.DatabaseName);
            int count = indexFragmentation.Count;

            if (indexFragmentation.Count > 0)
            {
                this.DataGridViewSchema.DataSource = indexFragmentation;
                int dataGridViewWidth = this.DataGridViewSchema.Width;

                this.DataGridViewSchema.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                this.DataGridViewSchema.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                this.DataGridViewSchema.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                this.DataGridViewSchema.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                this.DataGridViewSchema.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            }
        }

        /// <summary>
        /// Gets the database index usage.
        /// </summary>
        private void GetDatabaseIndexUsage()
        {
            DatabaseSchemaAccessLayer databaseInfo = new DatabaseSchemaAccessLayer(this.ConnectionParams);

            List<DatabaseIndexUsage> indexFragmentation = databaseInfo.GetDatabaseIndexUsage(this.DatabaseName);
            int count = indexFragmentation.Count;

            if (indexFragmentation.Count > 0)
            {
                this.DataGridViewSchema.DataSource = indexFragmentation;
                int dataGridViewWidth = this.DataGridViewSchema.Width;

                this.DataGridViewSchema.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                this.DataGridViewSchema.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                this.DataGridViewSchema.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                this.DataGridViewSchema.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                this.DataGridViewSchema.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            }
        }

        /// <summary>
        /// Gets the database no primary key.
        /// </summary>
        private void GetDatabaseNoPrimaryKey()
        {
            DatabaseSchemaAccessLayer databaseInfo = new DatabaseSchemaAccessLayer(this.ConnectionParams);

            List<DatabaseNoPrimaryKey> indexFragmentation = databaseInfo.GetDatabaseNoPrimaryKey(this.DatabaseName);
            int count = indexFragmentation.Count;

            if (indexFragmentation.Count > 0)
            {
                this.DataGridViewSchema.DataSource = indexFragmentation;
                int dataGridViewWidth = this.DataGridViewSchema.Width;

                this.DataGridViewSchema.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                this.DataGridViewSchema.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                this.DataGridViewSchema.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                this.DataGridViewSchema.Columns[2].DefaultCellStyle.Format = "N0";
            }
        }

        /// <summary>
        /// Gets the database triggers.
        /// </summary>
        private void GetDatabaseTriggers()
        {
            DatabaseSchemaAccessLayer databaseInfo = new DatabaseSchemaAccessLayer(this.ConnectionParams);

            List<DatabaseTriggers> indexFragmentation = databaseInfo.GetDatabaseTriggers(this.DatabaseName);
            int count = indexFragmentation.Count;

            if (indexFragmentation.Count > 0)
            {
                this.DataGridViewSchema.DataSource = indexFragmentation;
                int dataGridViewWidth = this.DataGridViewSchema.Width;

                this.DataGridViewSchema.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                this.DataGridViewSchema.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                this.DataGridViewSchema.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                this.DataGridViewSchema.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                this.DataGridViewSchema.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                this.DataGridViewSchema.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                this.DataGridViewSchema.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                this.DataGridViewSchema.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                this.DataGridViewSchema.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                this.DataGridViewSchema.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            }
        }

        #endregion
    }
}
