// ----------------------------------------------------------------------
// <copyright file="DatabaseIndexUsage.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System.Text;

    /// <summary>
    /// Database Index Usage
    /// </summary>
    public class DatabaseIndexUsage
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseIndexUsage"/> class.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="table">The table.</param>
        /// <param name="index">The index.</param>
        /// <param name="reads">The reads.</param>
        /// <param name="writes">The writes.</param>
        public DatabaseIndexUsage(string schema, string table, string index, long reads, long writes)
        {
            this.Schema = schema;
            this.Table = table;
            this.Index = index;
            this.Reads = reads;
            this.Writes = writes;
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
        /// Gets or sets the index.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        public string Index { get; set; }

        /// <summary>
        /// Gets or sets the reads.
        /// </summary>
        /// <value>
        /// The reads.
        /// </value>
        public long Reads { get; set; }

        /// <summary>
        /// Gets or sets the writes.
        /// </summary>
        /// <value>
        /// The writes.
        /// </value>
        public long Writes { get; set; }

        #endregion

        #region public methods

        /// <summary>
        /// SQL Statement.
        /// </summary>
        /// <returns>SQL Statement</returns>
        public static string SqlStatement()
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT DISTINCT	SCHEMA_NAME(t.SCHEMA_ID) AS [Schema], ");
            sql.AppendLine("CAST(t.name AS NVARCHAR(128)) AS [Table], ");
            sql.AppendLine("CAST(i.name AS NVARCHAR(128)) AS [Index], ");
            sql.AppendLine("ius.user_seeks + ius.user_scans + ius.user_lookups AS [Reads], ");
            sql.AppendLine("ius.user_updates AS [Writes] ");
            sql.AppendLine("FROM sys.indexes i WITH(NOLOCK) ");
            sql.AppendLine("JOIN sys.tables t WITH(NOLOCK) ON t.OBJECT_ID = i.OBJECT_ID ");
            sql.AppendLine("JOIN sys.dm_db_index_usage_stats ius WITH(NOLOCK) ON ius.OBJECT_ID = i.OBJECT_ID AND i.index_id = ius.index_id ");
            sql.AppendLine("WHERE t.[type] = 'U' AND i.[type] = 2 ");
            sql.AppendLine("ORDER BY ius.user_seeks + ius.user_scans + ius.user_lookups DESC, ius.user_updates DESC ");

            return sql.ToString();
        }

        #endregion
    }
}
