// ----------------------------------------------------------------------
// <copyright file="DatabaseSchemaAccessLayer.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System.Collections.Generic;
    using System.Data.SqlClient;

    /// <summary>
    /// Database Schema Access Layer
    /// </summary>
    public class DatabaseSchemaAccessLayer
    {
        #region  constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseSchemaAccessLayer" /> class.
        /// </summary>
        /// <param name="connectionParameters">The connection parameters.</param>
        public DatabaseSchemaAccessLayer(ConnectionParameters connectionParameters)
        {
            this.ConnectionParams = connectionParameters;
            this.ConnectionString = this.GetConnectionString();
        }

        #endregion

        #region private properties

        /// <summary>
        /// Gets or sets the connect.
        /// </summary>
        /// <value>
        /// The connect.
        /// </value>
        private string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the connection parameters.
        /// </summary>
        /// <value>
        /// The connection parameters.
        /// </value>
        private ConnectionParameters ConnectionParams { get; set; }

        #endregion

        #region public methods

        /// <summary>
        /// Gets the database changes in the last 90 days.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>the database changes in the last 90 days</returns>
        public List<DatabaseChangesLast90Days> GetDatabaseChangesLast90Days(string database)
        {
            this.ExecuteUseDatabase(database);

            List<DatabaseChangesLast90Days> results = new List<DatabaseChangesLast90Days>();
            DatabaseChangesLast90Days resultrow;
            string sqlString = DatabaseChangesLast90Days.SqlStatement();
            sqlString = string.Format("EXEC sp_executesql @statement = N'{0}'", sqlString.Replace("'", "''"));

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            using (SqlCommand command = new SqlCommand(sqlString, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resultrow = new DatabaseChangesLast90Days(
                            reader.GetString(reader.GetOrdinal("Object")),
                            reader.GetString(reader.GetOrdinal("Type")),
                            reader.GetString(reader.GetOrdinal("Action")),
                            reader.GetDateTime(reader.GetOrdinal("Created")),
                            reader.GetDateTime(reader.GetOrdinal("Modified")));

                        results.Add(resultrow);
                    }
                }

                connection.Close();
            }

            return results;
        }

        /// <summary>
        /// Gets the database foreign keys.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>the database foreign keys.</returns>
        public List<DatabaseForeignKeys> GetDatabaseForeignKeys(string database)
        {
            this.ExecuteUseDatabase(database);

            List<DatabaseForeignKeys> results = new List<DatabaseForeignKeys>();
            DatabaseForeignKeys resultrow;
            string sqlString = DatabaseForeignKeys.SqlStatement();
            sqlString = string.Format("EXEC sp_executesql @statement = N'{0}'", sqlString.Replace("'", "''"));

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            using (SqlCommand command = new SqlCommand(sqlString, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resultrow = new DatabaseForeignKeys(
                            reader.GetString(reader.GetOrdinal("Schema")),
                            reader.GetString(reader.GetOrdinal("Table")),
                            reader.GetString(reader.GetOrdinal("Column")),
                            reader.GetString(reader.GetOrdinal("ForeignKey")),
                            reader.GetString(reader.GetOrdinal("ReferenceTable")),
                            reader.GetString(reader.GetOrdinal("ReferenceColumn")));

                        results.Add(resultrow);
                    }
                }

                connection.Close();
            }

            return results;
        }

        /// <summary>
        /// Gets the database index usage.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>the database index usage</returns>
        public List<DatabaseIndexUsage> GetDatabaseIndexUsage(string database)
        {
            this.ExecuteUseDatabase(database);

            List<DatabaseIndexUsage> results = new List<DatabaseIndexUsage>();
            DatabaseIndexUsage resultrow;
            string sqlString = DatabaseIndexUsage.SqlStatement();
            sqlString = string.Format("EXEC sp_executesql @statement = N'{0}'", sqlString.Replace("'", "''"));

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            using (SqlCommand command = new SqlCommand(sqlString, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resultrow = new DatabaseIndexUsage(
                            reader.GetString(reader.GetOrdinal("Schema")),
                            reader.GetString(reader.GetOrdinal("Table")),
                            reader.GetString(reader.GetOrdinal("Index")),
                            reader.GetInt64(reader.GetOrdinal("Reads")),
                            reader.GetInt64(reader.GetOrdinal("Writes")));

                        results.Add(resultrow);
                    }
                }

                connection.Close();
            }

            return results;
        }

        /// <summary>
        /// Gets the size and name of the database.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>the size and name of the database</returns>
        public List<DatabaseNameSize> GetDatabaseNameSize(string database)
        {
            this.ExecuteUseDatabase("master");
            List<DatabaseNameSize> results = new List<DatabaseNameSize>();
            DatabaseNameSize resultrow;
            string sqlString = DatabaseNameSize.SqlStatement();
            sqlString = string.Format("EXEC sp_executesql @statement = N'{0}'", sqlString.Replace("'", "''"));

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            using (SqlCommand command = new SqlCommand(sqlString, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resultrow = new DatabaseNameSize(
                            reader.GetString(reader.GetOrdinal("DatabaseName")),
                            reader.GetString(reader.GetOrdinal("LogicalName")),
                            reader.GetString(reader.GetOrdinal("PhysicalName")),
                            reader.GetInt32(reader.GetOrdinal("Size_MB")));

                        results.Add(resultrow);
                    }
                }

                connection.Close();
            }

            return results;
        }

        /// <summary>
        /// Gets the table row counts.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>
        /// table row counts
        /// </returns>
        public List<DatabaseTableRowCounts> GetTableRowCounts(string database)
        {
            this.ExecuteUseDatabase(database);
            List<DatabaseTableRowCounts> results = new List<DatabaseTableRowCounts>();
            DatabaseTableRowCounts resultrow;
            string sqlString = DatabaseTableRowCounts.SqlStatement();
            sqlString = string.Format("EXEC sp_executesql @statement = N'{0}'", sqlString.Replace("'", "''"));

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            using (SqlCommand command = new SqlCommand(sqlString, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resultrow = new DatabaseTableRowCounts(
                            reader.GetString(reader.GetOrdinal("Table")),
                            reader.GetInt64(reader.GetOrdinal("RowCount")));

                        results.Add(resultrow);
                    }
                }

                connection.Close();
            }

            return results;
        }

        /// <summary>
        /// Gets the identity fields.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>the identity fields</returns>
        public List<DatabaseIdentityFields> GetIdentityFields(string database)
        {
            this.ExecuteUseDatabase(database);

            List<DatabaseIdentityFields> results = new List<DatabaseIdentityFields>();
            DatabaseIdentityFields resultrow;
            string sqlString = DatabaseIdentityFields.SqlStatement();
            sqlString = string.Format("EXEC sp_executesql @statement = N'{0}'", sqlString.Replace("'", "''"));

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            using (SqlCommand command = new SqlCommand(sqlString, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resultrow = new DatabaseIdentityFields(
                            reader.GetString(reader.GetOrdinal("Schema")),
                            reader.GetString(reader.GetOrdinal("TableName")),
                            reader.GetString(reader.GetOrdinal("Column")),
                            reader.GetString(reader.GetOrdinal("Type")),
                            reader.GetInt32(reader.GetOrdinal("Seed")),
                            reader.GetInt32(reader.GetOrdinal("Increment")),
                            reader.GetInt32(reader.GetOrdinal("CurrentIdentity")));

                        results.Add(resultrow);
                    }
                }

                connection.Close();
            }

            return results;
        }

        /// <summary>
        /// Gets the database changes in the last 90 days.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>the database changes in the last 90 days.</returns>
        public List<DatabaseUnusedIndexes> GetDatabaseUnusedIndexes(string database)
        {
            this.ExecuteUseDatabase(database);

            List<DatabaseUnusedIndexes> results = new List<DatabaseUnusedIndexes>();
            DatabaseUnusedIndexes resultrow;
            string sqlString = DatabaseUnusedIndexes.SqlStatement();
            sqlString = string.Format("EXEC sp_executesql @statement = N'{0}'", sqlString.Replace("'", "''"));

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            using (SqlCommand command = new SqlCommand(sqlString, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resultrow = new DatabaseUnusedIndexes(
                            reader.GetString(reader.GetOrdinal("Schema")),
                            reader.GetString(reader.GetOrdinal("Table")),
                            reader.GetString(reader.GetOrdinal("Index")));

                        results.Add(resultrow);
                    }
                }

                connection.Close();
            }

            return results;
        }

        /// <summary>
        /// Gets the database primary keys.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>the database primary keys</returns>
        public List<DatabasePrimaryKeys> GetDatabasePrimaryKeys(string database)
        {
            this.ExecuteUseDatabase(database);

            List<DatabasePrimaryKeys> results = new List<DatabasePrimaryKeys>();
            DatabasePrimaryKeys resultrow;
            string sqlString = DatabasePrimaryKeys.SqlStatement();
            sqlString = string.Format("EXEC sp_executesql @statement = N'{0}'", sqlString.Replace("'", "''"));

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            using (SqlCommand command = new SqlCommand(sqlString, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resultrow = new DatabasePrimaryKeys(
                            reader.GetString(reader.GetOrdinal("Schema")),
                            reader.GetString(reader.GetOrdinal("Table")),
                            reader.GetString(reader.GetOrdinal("Column")),
                            reader.GetString(reader.GetOrdinal("PrimaryKey")));

                        results.Add(resultrow);
                    }
                }

                connection.Close();
            }

            return results;
        }

        /// <summary>
        /// Gets the database non clustered indexes.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>the database non clustered indexes</returns>
        public List<DatabaseNonClusteredIndexes> GetDatabaseNonClusteredIndexes(string database)
        {
            this.ExecuteUseDatabase(database);

            List<DatabaseNonClusteredIndexes> results = new List<DatabaseNonClusteredIndexes>();
            DatabaseNonClusteredIndexes resultrow;
            string sqlString = DatabaseNonClusteredIndexes.SqlStatement();
            sqlString = string.Format("EXEC sp_executesql @statement = N'{0}'", sqlString.Replace("'", "''"));

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            using (SqlCommand command = new SqlCommand(sqlString, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resultrow = new DatabaseNonClusteredIndexes(
                            reader.GetString(reader.GetOrdinal("Schema")),
                            reader.GetString(reader.GetOrdinal("Table")),
                            reader.GetString(reader.GetOrdinal("Index")),
                            reader.GetString(reader.GetOrdinal("Column")),
                            reader.GetString(reader.GetOrdinal("IsUnique")));

                        results.Add(resultrow);
                    }
                }

                connection.Close();
            }

            return results;
        }

        /// <summary>
        /// Gets the database no primary key.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>the database no primary key</returns>
        public List<DatabaseNoPrimaryKey> GetDatabaseNoPrimaryKey(string database)
        {
            this.ExecuteUseDatabase(database);

            List<DatabaseNoPrimaryKey> results = new List<DatabaseNoPrimaryKey>();
            DatabaseNoPrimaryKey resultrow;
            string sqlString = DatabaseNoPrimaryKey.SqlStatement();
            sqlString = string.Format("EXEC sp_executesql @statement = N'{0}'", sqlString.Replace("'", "''"));

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            using (SqlCommand command = new SqlCommand(sqlString, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resultrow = new DatabaseNoPrimaryKey(
                            reader.GetString(reader.GetOrdinal("Schema")),
                            reader.GetString(reader.GetOrdinal("Table")),
                            reader.GetInt64(reader.GetOrdinal("RowCount")));

                        results.Add(resultrow);
                    }
                }

                connection.Close();
            }

            return results;
        }

        /// <summary>
        /// Gets the database triggers.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>the database triggers</returns>
        public List<DatabaseTriggers> GetDatabaseTriggers(string database)
        {
            this.ExecuteUseDatabase(database);

            List<DatabaseTriggers> results = new List<DatabaseTriggers>();
            DatabaseTriggers resultrow;
            string sqlString = DatabaseTriggers.SqlStatement();
            sqlString = string.Format("EXEC sp_executesql @statement = N'{0}'", sqlString.Replace("'", "''"));

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            using (SqlCommand command = new SqlCommand(sqlString, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resultrow = new DatabaseTriggers(
                            reader.GetString(reader.GetOrdinal("TriggerName")),
                            reader.GetString(reader.GetOrdinal("TriggerOwner")),
                            reader.GetString(reader.GetOrdinal("TableSchema")),
                            reader.GetString(reader.GetOrdinal("TableName")),
                            reader.GetInt32(reader.GetOrdinal("IsUpdate")),
                            reader.GetInt32(reader.GetOrdinal("IsDelete")),
                            reader.GetInt32(reader.GetOrdinal("IsInsert")),
                            reader.GetInt32(reader.GetOrdinal("IsAfter")),
                            reader.GetInt32(reader.GetOrdinal("IsInsteadOf")),
                            reader.GetInt32(reader.GetOrdinal("Disabled")));

                        results.Add(resultrow);
                    }
                }

                connection.Close();
            }

            return results;
        }

        /// <summary>
        /// Gets the database list.
        /// </summary>
        /// <returns>Database List</returns>
        public List<string> GetDatabaseList()
        {
            string sql = "EXEC sp_executesql @statement = N'SELECT name FROM sys.databases WHERE user_access = 0 AND database_id > 4'";

            List<string> results = new List<string>();

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(reader.GetString(0));
                    }
                }

                connection.Close();
            }

            return results;
        }

        #endregion

        #region private methods

        /// <summary>
        /// Performs the SQL USE database command.
        /// </summary>
        /// <param name="databaseName">The database.</param>
        private void ExecuteUseDatabase(string databaseName)
        {
            string sqlCode = string.Format("EXEC sp_executesql @statement = N'USE [{0}];'", databaseName);

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            using (SqlCommand command = new SqlCommand(sqlCode, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <returns>the connection string</returns>
        private string GetConnectionString()
        {
            string constr = this.ConnectionParams.Authentication == 0 ? string.Format(
                                    @"Data Source = {0};Initial Catalog={1};Integrated Security=SSPI;Application Name=SQL DB Profiler",
                                    this.ConnectionParams.Server,
                                    this.ConnectionParams.Database)
                            : string.Format(
                                    @"Data Source={0};Initial Catalog={3};User Id={1};Password={2};;Application Name=SQL DB Profiler",
                                    this.ConnectionParams.Server,
                                    this.ConnectionParams.UserName,
                                    this.ConnectionParams.Password,
                                    this.ConnectionParams.Database);

            return constr;
        }

        /// <summary>
        /// Gets the safe string.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>
        /// string without nulls
        /// </returns>
        private string GetSafeString(SqlDataReader reader, string columnName)
        {
            string result = string.Empty;

            if (!reader.IsDBNull(reader.GetOrdinal(columnName)))
            {
                result = reader.GetString(reader.GetOrdinal(columnName));
            }

            return result;
        }

        #endregion
    }
}
