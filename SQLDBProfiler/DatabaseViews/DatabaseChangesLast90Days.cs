// ----------------------------------------------------------------------
// <copyright file="DatabaseChangesLast90Days.cs" company="Chemistry Digital Ltd">
//     Copyright. All right reserved
// </copyright>
// ------------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System;
    using System.Text;

    /// <summary>
    /// Public Class ViewChangesLast90Days
    /// </summary>
    public class DatabaseChangesLast90Days
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseChangesLast90Days" /> class.
        /// </summary>
        /// <param name="obectjName">The object name.</param>
        /// <param name="type">The type parameter</param>
        /// <param name="action">The action parameter</param>
        /// <param name="created">The created parameter</param>
        /// <param name="modified">The modified parameter</param>
        public DatabaseChangesLast90Days(string obectjName, string type, string action, DateTime created, DateTime modified)
        {
            this.Object = obectjName;
            this.Type = type;
            this.Action = action;
            this.Created = created;
            this.Modified = modified;
        }

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets the object.
        /// </summary>
        /// <value>
        /// The object.
        /// </value>
        public string Object { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>
        /// The created.
        /// </value>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the modified.
        /// </summary>
        /// <value>
        /// The modified.
        /// </value>
        public DateTime Modified { get; set; }

        #endregion

        #region public methods

        /// <summary>
        /// SQL Statement.
        /// </summary>
        /// <returns>SQL Statement</returns>
        public static string SqlStatement()
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT CAST(O.[name] AS NVARCHAR(128)) AS [Object], ");
            sql.AppendLine("CASE O.[type] WHEN 'P' THEN 'StoredProc' WHEN 'FN' THEN 'Function' WHEN 'U' THEN 'Table'  ");
            sql.AppendLine("WHEN 'V' THEN 'View' WHEN 'TR' THEN 'Trigger' END AS [Type], ");
            sql.AppendLine("CASE WHEN O.[create_date] = O.[modify_date] THEN 'created' ELSE 'modified' END AS [Action], ");
            sql.AppendLine("CONVERT(DATETIME,O.[create_date],121) AS [Created], ");
            sql.AppendLine("CONVERT(DATETIME,O.[modify_date],121) AS [Modified] ");
            sql.AppendLine("FROM sys.objects O WITH(NOLOCK) ");
            sql.AppendLine("WHERE O.[type] IN ('P','U','FN','V','TR') ");
            sql.AppendLine("AND O.[modify_date] > DATEADD(day, -90, GETDATE()) ");
            sql.AppendLine("ORDER BY O.[modify_date] DESC ");

            return sql.ToString();
        }

        #endregion
    }
}
