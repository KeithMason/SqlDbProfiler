// <copyright file="SqlQueryDataAccessTest.cs">Copyright ©</copyright>
using System;
using System.Data;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for SqlQueryDataAccess</summary>
    [PexClass(typeof(SqlQueryDataAccess))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class SqlQueryDataAccessTest
    {
        /// <summary>Test stub for ExecuteUseDatabase(String, String)</summary>
        [PexMethod]
        public void ExecuteUseDatabase(string database, string connectionString)
        {
            SqlQueryDataAccess.ExecuteUseDatabase(database, connectionString);
            // TODO: add assertions to method SqlQueryDataAccessTest.ExecuteUseDatabase(String, String)
        }

        /// <summary>Test stub for GetPerformanceQueryResults(String, String)</summary>
        [PexMethod]
        public DataView GetPerformanceQueryResults(string sqlCode, string connectionString)
        {
            DataView result
               = SqlQueryDataAccess.GetPerformanceQueryResults(sqlCode, connectionString);
            return result;
            // TODO: add assertions to method SqlQueryDataAccessTest.GetPerformanceQueryResults(String, String)
        }
    }
}
