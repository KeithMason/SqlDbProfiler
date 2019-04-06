// ----------------------------------------------------------------------
// <copyright file="DatabaseUnusedIndexes.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System.Text;

    /// <summary>
    /// Public Class ViewChangesLast90Days
    /// </summary>
    public class DatabaseUnusedIndexes
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseUnusedIndexes"/> class.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="table">The table.</param>
        /// <param name="index">The index.</param>
        public DatabaseUnusedIndexes(string schema, string table, string index)
        {
            this.Schema = schema;
            this.Table = table;
            this.Index = index;
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

        #endregion

        #region public methods

        /// <summary>
        /// SQL Statement.
        /// </summary>
        /// <returns>SQL Statement</returns>
        public static string SqlStatement()
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT SCHEMA_NAME(t.SCHEMA_ID) AS [Schema],OBJECT_NAME(i.OBJECT_ID) AS [Table], CAST(i.NAME AS NVARCHAR(128)) AS [Index] ");
            sql.AppendLine("FROM sys.indexes i WITH(NOLOCK) ");
            sql.AppendLine("JOIN sys.objects o WITH(NOLOCK) ON i.OBJECT_ID = o.OBJECT_ID ");
            sql.AppendLine("JOIN sys.tables t WITH(NOLOCK) ON i.OBJECT_ID = t.OBJECT_ID  ");
            sql.AppendLine("WHERE OBJECTPROPERTY(o.OBJECT_ID,'IsUserTable') = 1 ");
            sql.AppendLine("AND i.INDEX_ID NOT IN (SELECT S.INDEX_ID FROM sys.dm_db_index_usage_stats s ");
            sql.AppendLine("WHERE s.OBJECT_ID = i.OBJECT_ID AND i.INDEX_ID = s.INDEX_ID) ");
            sql.AppendLine("AND i.type_desc = 'NONCLUSTERED' ");
            sql.AppendLine("ORDER BY [Table],[Index] ASC ");

            return sql.ToString();
        }

        #endregion
    }
}
