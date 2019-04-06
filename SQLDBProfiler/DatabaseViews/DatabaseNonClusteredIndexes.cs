// ----------------------------------------------------------------------
// <copyright file="DatabaseNonClusteredIndexes.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System.Text;

    /// <summary>
    /// Public Class DatabaseNoPrimaryKey
    /// </summary>
    public class DatabaseNonClusteredIndexes
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseNonClusteredIndexes" /> class.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="table">The table.</param>
        /// <param name="index">The index.</param>
        /// <param name="column">The column.</param>
        /// <param name="unique">The unique.</param>
        public DatabaseNonClusteredIndexes(string schema, string table, string index, string column, string unique)
        {
            this.Schema = schema;
            this.Table = table;
            this.Index = index;
            this.Column = column;
            this.IsUnique = unique;
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
        /// Gets or sets the column.
        /// </summary>
        /// <value>
        /// The column.
        /// </value>
        public string Column { get; set; }

        /// <summary>
        /// Gets or sets the is unique.
        /// </summary>
        /// <value>
        /// The is unique.
        /// </value>
        public string IsUnique { get; set; }

        #endregion

        #region public methods

        /// <summary>
        /// SQL Statement.
        /// </summary>
        /// <returns>SQL Statement</returns>
        public static string SqlStatement()
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT SCHEMA_NAME(t.SCHEMA_ID) AS [Schema], ");
            sql.AppendLine("CAST(t.name AS NVARCHAR(128)) AS [Table], ");
            sql.AppendLine("CAST(ind.name AS NVARCHAR(128)) AS [Index], ");
            sql.AppendLine("CAST(col.name AS NVARCHAR(128)) AS [Column], ");
            sql.AppendLine("CASE ind.is_unique WHEN 0 THEN 'No' ELSE 'Yes' END AS [IsUnique] ");
            sql.AppendLine("FROM sys.indexes ind WITH(NOLOCK) ");
            sql.AppendLine("JOIN sys.tables t WITH(NOLOCK) ON ind.OBJECT_ID = t.OBJECT_ID ");
            sql.AppendLine("JOIN sys.index_columns ic WITH(NOLOCK) ON ind.OBJECT_ID = ic.OBJECT_ID AND ind.index_id = ic.index_id ");
            sql.AppendLine("JOIN sys.columns col WITH(NOLOCK) ON ic.OBJECT_ID = col.OBJECT_ID AND ic.column_id = col.column_id ");
            sql.AppendLine("WHERE ind.type_desc = 'NONCLUSTERED' AND ind.is_primary_key = 0 ");
            sql.AppendLine("AND ind.is_unique_constraint = 0 AND t.is_ms_shipped = 0 ");
            sql.AppendLine("ORDER BY t.name,ind.name,col.name ");

            return sql.ToString();
        }

        #endregion
    }
}
