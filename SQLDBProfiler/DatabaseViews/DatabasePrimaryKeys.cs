// ----------------------------------------------------------------------
// <copyright file="DatabasePrimaryKeys.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System.Text;

    /// <summary>
    /// Public Class DatabaseForeignKeys
    /// </summary>
    public class DatabasePrimaryKeys
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabasePrimaryKeys"/> class.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="table">The table.</param>
        /// <param name="column">The column.</param>
        /// <param name="primaryKey">The primary key.</param>
        public DatabasePrimaryKeys(string schema, string table, string column, string primaryKey)
        {
            this.Schema = schema;
            this.Table = table;
            this.Column = column;
            this.PrimaryKey = primaryKey;
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
        /// Gets or sets the column.
        /// </summary>
        /// <value>
        /// The column.
        /// </value>
        public string Column { get; set; }

        /// <summary>
        /// Gets or sets the foreign key.
        /// </summary>
        /// <value>
        /// The foreign key.
        /// </value>
        public string PrimaryKey { get; set; }

        #endregion

        #region public methods

        /// <summary>
        /// SQL Statement.
        /// </summary>
        /// <returns>SQL Statement</returns>
        public static string SqlStatement()
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT A.TABLE_SCHEMA AS [Schema],CAST(A.TABLE_NAME AS NVARCHAR(128)) AS [Table], ");
            sql.AppendLine("B.COLUMN_NAME AS [Column], A.CONSTRAINT_NAME AS [PrimaryKey] ");
            sql.AppendLine("FROM information_schema.table_constraints A WITH(NOLOCK), information_schema.constraint_column_usage B WITH(NOLOCK) ");
            sql.AppendLine("WHERE CONSTRAINT_TYPE = 'PRIMARY KEY' AND A.CONSTRAINT_NAME = B.CONSTRAINT_NAME ");
            sql.AppendLine("ORDER BY [Table] ");

            return sql.ToString();
        }

        #endregion
    }
}
