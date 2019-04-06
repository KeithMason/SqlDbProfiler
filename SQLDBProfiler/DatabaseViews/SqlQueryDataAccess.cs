// ----------------------------------------------------------------------
// <copyright file="SqlQueryDataAccess.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// SQL Query Data Access Class
    /// </summary>
    public class SqlQueryDataAccess
    {
        /// <summary>
        /// Gets the performance query results.
        /// </summary>
        /// <param name="sqlCode">The SQL code.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <returns>the performance query results</returns>
        public static DataView GetPerformanceQueryResults(string sqlCode, string connectionString)
        {
            string sql = string.Format("EXEC sp_executesql @statement = N'{0}'", sqlCode.Replace("'", "''"));

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, connection))
            using (DataTable dataTable = new DataTable())
            {
                connection.Open();
                dataAdapter.Fill(dataTable);
                return dataTable.DefaultView;
            }
        }

        /// <summary>
        /// Performs the use database.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="connectionString">The connection string.</param>
        public static void ExecuteUseDatabase(string database, string connectionString)
        {
            string sqlCode = string.Format("EXEC sp_executesql @statement = N'USE [{0}];'", database);

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sqlCode, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
