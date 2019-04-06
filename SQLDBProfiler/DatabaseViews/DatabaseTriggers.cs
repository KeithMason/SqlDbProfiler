// ----------------------------------------------------------------------
// <copyright file="DatabaseTriggers.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System.Text;

    /// <summary>
    /// Public Class DatabaseTriggers
    /// </summary>
    public class DatabaseTriggers
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseTriggers" /> class.
        /// </summary>
        /// <param name="triggerName">Name of the trigger.</param>
        /// <param name="triggerOwner">The trigger owner.</param>
        /// <param name="tableSchema">The table schema.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="update">The update.</param>
        /// <param name="delete">The delete.</param>
        /// <param name="insert">The insert.</param>
        /// <param name="after">The after.</param>
        /// <param name="insteadOf">The instead of.</param>
        /// <param name="disabled">The disabled.</param>
        public DatabaseTriggers(
                string triggerName,
                string triggerOwner,
                string tableSchema,
                string tableName,
                int update,
                int delete,
                int insert,
                int after,
                int insteadOf,
                int disabled)
        {
            this.TriggerName = triggerName;
            this.TriggerOwner = triggerOwner;
            this.TableSchema = tableSchema;
            this.TableName = tableName;
            this.IsUpdate = update;
            this.IsDelete = delete;
            this.IsInsert = insert;
            this.IsAfter = after;
            this.IsInsteadOf = insteadOf;
            this.Disabled = disabled;
        }

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets the name of the trigger.
        /// </summary>
        /// <value>
        /// The name of the trigger.
        /// </value>
        public string TriggerName { get; set; }

        /// <summary>
        /// Gets or sets the trigger owner.
        /// </summary>
        /// <value>
        /// The trigger owner.
        /// </value>
        public string TriggerOwner { get; set; }

        /// <summary>
        /// Gets or sets the table schema.
        /// </summary>
        /// <value>
        /// The table schema.
        /// </value>
        public string TableSchema { get; set; }

        /// <summary>
        /// Gets or sets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        public string TableName { get; set; }

        /// <summary>
        /// Gets or sets the is update.
        /// </summary>
        /// <value>
        /// The is update.
        /// </value>
        public int IsUpdate { get; set; }

        /// <summary>
        /// Gets or sets the is delete.
        /// </summary>
        /// <value>
        /// The is delete.
        /// </value>
        public int IsDelete { get; set; }

        /// <summary>
        /// Gets or sets the is insert.
        /// </summary>
        /// <value>
        /// The is insert.
        /// </value>
        public int IsInsert { get; set; }

        /// <summary>
        /// Gets or sets the is after.
        /// </summary>
        /// <value>
        /// The is after.
        /// </value>
        public int IsAfter { get; set; }

        /// <summary>
        /// Gets or sets the is instead of.
        /// </summary>
        /// <value>
        /// The is instead of.
        /// </value>
        public int IsInsteadOf { get; set; }

        /// <summary>
        /// Gets or sets the disabled.
        /// </summary>
        /// <value>
        /// The disabled.
        /// </value>
        public int Disabled { get; set; }

        #endregion

        #region public methods

        /// <summary>
        /// SQL Statement.
        /// </summary>
        /// <returns>SQL Statement</returns>
        public static string SqlStatement()
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT CAST(sysobjects.name AS NVARCHAR(128)) AS [TriggerName] ");
            sql.AppendLine(",USER_NAME(sysobjects.uid) AS [TriggerOwner] ");
            sql.AppendLine(",CAST(s.name AS NVARCHAR(128)) AS [TableSchema] ");
            sql.AppendLine(",OBJECT_NAME(parent_obj) AS [TableName] ");
            sql.AppendLine(",OBJECTPROPERTY(id,'ExecIsUpdateTrigger') AS [isUpdate] ");
            sql.AppendLine(",OBJECTPROPERTY(id,'ExecIsDeleteTrigger') AS [isDelete] ");
            sql.AppendLine(",OBJECTPROPERTY(id,'ExecIsInsertTrigger') AS [isInsert] ");
            sql.AppendLine(",OBJECTPROPERTY(id,'ExecIsAfterTrigger') AS [isAfter] ");
            sql.AppendLine(",OBJECTPROPERTY(id,'ExecIsInsteadOfTrigger') AS [isInsteadOf] ");
            sql.AppendLine(",OBJECTPROPERTY(id,'ExecIsTriggerDisabled') AS [Disabled] ");
            sql.AppendLine("FROM sysobjects WITH(NOLOCK) ");
            sql.AppendLine("INNER JOIN sysusers WITH(NOLOCK) ON sysobjects.uid = sysusers.uid ");
            sql.AppendLine("INNER JOIN sys.tables t WITH(NOLOCK) ON sysobjects.parent_obj = t.object_id ");
            sql.AppendLine("INNER JOIN sys.schemas s WITH(NOLOCK) ON t.schema_id = s.schema_id ");
            sql.AppendLine("WHERE sysobjects.type = 'TR' ");

            return sql.ToString();
        }

        #endregion
    }
}