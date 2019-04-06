// ----------------------------------------------------------------------
// <copyright file="DatabaseNoPrimaryKey.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System.Text;

    /// <summary>
    /// Public Class DatabaseNoPrimaryKey
    /// </summary>
    public class DatabaseNoPrimaryKey
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseNoPrimaryKey"/> class.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="table">The table.</param>
        /// <param name="rowCount">The row count.</param>
        public DatabaseNoPrimaryKey(string schema, string table, long rowCount)
        {
            this.Schema = schema;
            this.Table = table;
            this.RowCount = rowCount;
        }

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets the schema.
        /// </summary>
        /// <value>
        /// The schema.
        /// </value>
        public string Schema { get; set; }

        /// <summary>
        /// Gets or sets the table.
        /// </summary>
        /// <value>
        /// The table.
        /// </value>
        public string Table { get; set; }

        /// <summary>
        /// Gets or sets the row count.
        /// </summary>
        /// <value>
        /// The row count.
        /// </value>
        public long RowCount { get; set; }

        #endregion

        #region public methods

        /// <summary>
        /// SQL Statement.
        /// </summary>
        /// <returns>SQL Statement</returns>
        public static string SqlStatement()
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT DISTINCT SCHEMA_NAME(t.SCHEMA_ID) AS [Schema], ");
            sql.AppendLine("OBJECT_NAME(i.OBJECT_ID) AS [Table], p.[Rows] AS [RowCount] ");
            sql.AppendLine("FROM sys.indexes i WITH(NOLOCK) ");
            sql.AppendLine("JOIN sys.partitions p WITH(NOLOCK) ON p.index_id = i.index_id AND i.OBJECT_ID = p.OBJECT_ID ");
            sql.AppendLine("JOIN sys.tables t WITH(NOLOCK) ON i.OBJECT_ID = t.OBJECT_ID ");
            sql.AppendLine("WHERE i.index_id = 0 AND OBJECTPROPERTY(i.OBJECT_ID,'IsUserTable') = 1 ");
            sql.AppendLine("ORDER BY [Table] ");

            return sql.ToString();
        }

        #endregion
    }
}
