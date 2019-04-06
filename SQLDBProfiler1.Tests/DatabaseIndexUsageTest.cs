// <copyright file="DatabaseIndexUsageTest.cs">Copyright ©</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for DatabaseIndexUsage</summary>
    [PexClass(typeof(DatabaseIndexUsage))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class DatabaseIndexUsageTest
    {
        /// <summary>Test stub for .ctor(String, String, String, Int64, Int64)</summary>
        [PexMethod]
        public DatabaseIndexUsage Constructor(
            string schema,
            string table,
            string index,
            long reads,
            long writes
        )
        {
            DatabaseIndexUsage target
               = new DatabaseIndexUsage(schema, table, index, reads, writes);
            return target;
            // TODO: add assertions to method DatabaseIndexUsageTest.Constructor(String, String, String, Int64, Int64)
        }

        /// <summary>Test stub for SqlStatement()</summary>
        [PexMethod]
        public string SqlStatement()
        {
            string result = DatabaseIndexUsage.SqlStatement();
            return result;
            // TODO: add assertions to method DatabaseIndexUsageTest.SqlStatement()
        }
    }
}
