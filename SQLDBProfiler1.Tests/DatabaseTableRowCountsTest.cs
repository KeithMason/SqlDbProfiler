// <copyright file="DatabaseTableRowCountsTest.cs">Copyright ©</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for DatabaseTableRowCounts</summary>
    [PexClass(typeof(DatabaseTableRowCounts))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class DatabaseTableRowCountsTest
    {
        /// <summary>Test stub for .ctor(String, Int64)</summary>
        [PexMethod]
        public DatabaseTableRowCounts Constructor(string tableName, long rowCount)
        {
            DatabaseTableRowCounts target = new DatabaseTableRowCounts(tableName, rowCount);
            return target;
            // TODO: add assertions to method DatabaseTableRowCountsTest.Constructor(String, Int64)
        }

        /// <summary>Test stub for SqlStatement()</summary>
        [PexMethod]
        public string SqlStatement()
        {
            string result = DatabaseTableRowCounts.SqlStatement();
            return result;
            // TODO: add assertions to method DatabaseTableRowCountsTest.SqlStatement()
        }
    }
}
