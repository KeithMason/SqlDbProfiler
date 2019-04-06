// ----------------------------------------------------------------------
// <copyright file="DatabaseForeignKeys.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System.Text;

    /// <summary>
    /// Public Class DatabaseForeignKeys
    /// </summary>
    public class DatabaseForeignKeys
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseForeignKeys"/> class.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="table">The table.</param>
        /// <param name="column">The column.</param>
        /// <param name="foreignKey">The foreign key.</param>
        /// <param name="referenceTable">The reference table.</param>
        /// <param name="referenceColumn">The reference column.</param>
        public DatabaseForeignKeys(string schema, string table, string column, string foreignKey, string referenceTable, string referenceColumn)
        {
            this.Schema = schema;
            this.Table = table;
            this.Column = column;
            this.ForeignKey = foreignKey;
            this.ReferenceTable = referenceTable;
            this.ReferenceColumn = referenceColumn;
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
        public string ForeignKey { get; set; }

        /// <summary>
        /// Gets or sets the reference table.
        /// </summary>
        /// <value>
        /// The reference table.
        /// </value>
        public string ReferenceTable { get; set; }

        /// <summary>
        /// Gets or sets the reference column.
        /// </summary>
        /// <value>
        /// The reference column.
        /// </value>
        public string ReferenceColumn { get; set; }

        #endregion

        #region public methods

        /// <summary>
        /// SQL Statement.
        /// </summary>
        /// <returns>SQL Statement</returns>
        public static string SqlStatement()
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT SCHEMA_NAME(f.SCHEMA_ID) AS [Schema], ");
            sql.AppendLine("OBJECT_NAME(f.parent_object_id) AS [Table], ");
            sql.AppendLine("COL_NAME(fc.parent_object_id,fc.parent_column_id) AS [Column], ");
            sql.AppendLine("CAST(f.name AS NVARCHAR(128)) AS [ForeignKey], ");
            sql.AppendLine("OBJECT_NAME (f.referenced_object_id) AS [ReferenceTable], ");
            sql.AppendLine("COL_NAME(fc.referenced_object_id,fc.referenced_column_id) AS [ReferenceColumn] ");
            sql.AppendLine("FROM sys.foreign_keys f WITH(NOLOCK) ");
            sql.AppendLine("INNER JOIN sys.foreign_key_columns fc ON f.OBJECT_ID = fc.constraint_object_id ");
            sql.AppendLine("JOIN sys.tables t ON f.parent_object_id = t.OBJECT_ID ");

            return sql.ToString();
        }

        #endregion
    }
}
