// ----------------------------------------------------------------------
// <copyright file="DatabaseTableRowCounts.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System.Text;

    /// <summary>
    /// Database Table Row Counts
    /// </summary>
    public class DatabaseTableRowCounts
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseTableRowCounts"/> class.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="rowCount">The row count.</param>
        public DatabaseTableRowCounts(string tableName, long rowCount)
        {
            this.TableName = tableName;
            this.RowCount = rowCount;
        }

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        public string TableName { get; set; }

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

            sql.Append("SELECT o.name AS [Table],ddps.row_count AS [RowCount] ");
            sql.Append("FROM sys.indexes AS i WITH(NOLOCK) ");
            sql.Append("INNER JOIN sys.objects AS o WITH(NOLOCK) ON i.OBJECT_ID = o.OBJECT_ID ");
            sql.Append("INNER JOIN sys.dm_db_partition_stats AS ddps WITH(NOLOCK) ON i.OBJECT_ID = ddps.OBJECT_ID  ");
            sql.Append("AND i.index_id = ddps.index_id  ");
            sql.Append("WHERE i.index_id < 2  AND o.is_ms_shipped = 0  ");
            sql.Append("AND OBJECTPROPERTY(i.OBJECT_ID,'IsUserTable') = 1 ");
            sql.Append("ORDER BY ddps.row_count DESC ");

            return sql.ToString();
        }

        #endregion
    }
}
