// -----------------------------------------------------------------------
// <copyright file="DatabaseIdentityFields.cs" company="Masonsoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// -----------------------------------------------------------------------

namespace SQLDBProfiler
{
    using System.Text;

    /// <summary>
    /// Database Identity Fields
    /// </summary>
    public class DatabaseIdentityFields
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseIdentityFields"/> class.
        /// </summary>
        public DatabaseIdentityFields()
        {
            return;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseIdentityFields"/> class.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="column">The column.</param>
        /// <param name="type">The type.</param>
        /// <param name="seed">The seed.</param>
        /// <param name="increment">The increment.</param>
        /// <param name="currentIdentity">The current identity.</param>
        public DatabaseIdentityFields(
            string schema,
            string tableName,
            string column,
            string type,
            int seed,
            int increment,
            int currentIdentity)
        {
            this.Schema = schema;
            this.TableName = tableName;
            this.Column = column;
            this.Type = type;
            this.Seed = seed;
            this.Increment = increment;
            this.CurrentIdentity = currentIdentity;
        }

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets the name of the database.
        /// </summary>
        /// <value>
        /// The name of the database.
        /// </value>
        public string Schema { get; set; }

        /// <summary>
        /// Gets or sets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        public string TableName { get; set; }

        /// <summary>
        /// Gets or sets the average estimated impact.
        /// </summary>
        /// <value>
        /// The average estimated impact.
        /// </value>
        public string Column { get; set; }

        /// <summary>
        /// Gets or sets the last user seek.
        /// </summary>
        /// <value>
        /// The last user seek.
        /// </value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the equality columns.
        /// </summary>
        /// <value>
        /// The equality columns.
        /// </value>
        public int Seed { get; set; }

        /// <summary>
        /// Gets or sets the inequality columns.
        /// </summary>
        /// <value>
        /// The inequality columns.
        /// </value>
        public int Increment { get; set; }

        /// <summary>
        /// Gets or sets the included columns.
        /// </summary>
        /// <value>
        /// The included columns.
        /// </value>
        public int CurrentIdentity { get; set; }

        #endregion

        #region public methods

        /// <summary>
        /// SQL Statement.
        /// </summary>
        /// <returns>SQL Statement</returns>
        public static string SqlStatement()
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT CAST([Table].TABLE_SCHEMA AS NVARCHAR(128)) AS [Schema], ");
            sql.Append("CAST([Table].TABLE_NAME AS NVARCHAR(128)) AS [TableName], ");
            sql.Append("CAST([Column].COLUMN_NAME AS NVARCHAR(128)) AS [Column], ");
            sql.Append("[Column].DATA_TYPE AS [Type], ");
            sql.Append("CAST(IDENT_SEED([Table].TABLE_NAME) AS INT) AS [Seed], ");
            sql.Append("CAST(IDENT_INCR([Table].TABLE_NAME) AS INT) AS [Increment], ");
            sql.Append("CAST(IDENT_CURRENT([Table].TABLE_NAME) AS INT) AS [CurrentIdentity] ");
            sql.Append("FROM INFORMATION_SCHEMA.COLUMNS AS [Column] WITH(NOLOCK) ");
            sql.Append("INNER JOIN INFORMATION_SCHEMA.TABLES AS [Table] WITH(NOLOCK) ON [Table].TABLE_NAME = [Column].TABLE_NAME ");
            sql.Append("WHERE COLUMNPROPERTY(OBJECT_ID([Column].TABLE_NAME), [Column].COLUMN_NAME, 'IsIdentity') = 1 ");
            sql.Append("AND TABLE_TYPE = 'BASE TABLE' ");
            sql.Append("AND OBJECTPROPERTY(OBJECT_ID([Table].TABLE_SCHEMA+'.'+[Table].TABLE_NAME), 'TableHasIdentity') = 1 ");

            return sql.ToString();
        }

        #endregion
    }
}