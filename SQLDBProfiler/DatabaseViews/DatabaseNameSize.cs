// ----------------------------------------------------------------------
// <copyright file="DatabaseNameSize.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// ----------------------------------------------------------------------
// -----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System.Text;

    /// <summary>
    /// Database Names and Sizes
    /// </summary>
    public class DatabaseNameSize
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseNameSize"/> class.
        /// </summary>
        /// <param name="databaseName">Name of the database.</param>
        /// <param name="logicalName">Name of the logical.</param>
        /// <param name="physicalName">Name of the physical.</param>
        /// <param name="sizeMB">The size MB.</param>
        public DatabaseNameSize(string databaseName, string logicalName, string physicalName, int sizeMB)
        {
            this.DatabaseName = databaseName;
            this.LogicalName = logicalName;
            this.PhysicalName = physicalName;
            this.SizeMB = sizeMB;
        }

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets the name of the database.
        /// </summary>
        /// <value>
        /// The name of the database.
        /// </value>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the logical.
        /// </summary>
        /// <value>
        /// The name of the logical_.
        /// </value>
        public string LogicalName { get; set; }

        /// <summary>
        /// Gets or sets the name of the physical.
        /// </summary>
        /// <value>
        /// The name of the physical_.
        /// </value>
        public string PhysicalName { get; set; }

        /// <summary>
        /// Gets or sets the size
        /// </summary>
        /// <value>
        /// The size inMB.
        /// </value>
        public int SizeMB { get; set; }

        #endregion

        #region public methods

        /// <summary>
        /// SQL Statement.
        /// </summary>
        /// <returns>SQL Statement</returns>
        public static string SqlStatement()
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT DB_NAME(database_id) AS [DatabaseName], ");
            sql.Append("CAST(Name AS NVARCHAR(100)) AS [LogicalName], ");
            sql.Append("CAST([Physical_Name] As NVARCHAR(128)) AS [PhysicalName], ");
            sql.Append("((size*8)/1024) AS [Size_MB] ");
            sql.Append("FROM sys.master_files WITH(NOLOCK) WHERE database_id > 4 ");

            return sql.ToString();
        }

        #endregion
    }
}
