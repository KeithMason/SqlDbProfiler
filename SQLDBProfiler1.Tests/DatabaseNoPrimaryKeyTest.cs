// <copyright file="DatabaseNoPrimaryKeyTest.cs">Copyright ©</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for DatabaseNoPrimaryKey</summary>
    [PexClass(typeof(DatabaseNoPrimaryKey))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class DatabaseNoPrimaryKeyTest
    {
        /// <summary>Test stub for .ctor(String, String, Int64)</summary>
        [PexMethod]
        public DatabaseNoPrimaryKey Constructor(
            string schema,
            string table,
            long rowCount
        )
        {
            DatabaseNoPrimaryKey target = new DatabaseNoPrimaryKey(schema, table, rowCount);
            return target;
            // TODO: add assertions to method DatabaseNoPrimaryKeyTest.Constructor(String, String, Int64)
        }

        /// <summary>Test stub for SqlStatement()</summary>
        [PexMethod]
        public string SqlStatement()
        {
            string result = DatabaseNoPrimaryKey.SqlStatement();
            return result;
            // TODO: add assertions to method DatabaseNoPrimaryKeyTest.SqlStatement()
        }
    }
}
