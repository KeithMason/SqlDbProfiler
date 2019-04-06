// <copyright file="DatabasePrimaryKeysTest.cs">Copyright ©</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for DatabasePrimaryKeys</summary>
    [PexClass(typeof(DatabasePrimaryKeys))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class DatabasePrimaryKeysTest
    {
        /// <summary>Test stub for .ctor(String, String, String, String)</summary>
        [PexMethod]
        public DatabasePrimaryKeys Constructor(
            string schema,
            string table,
            string column,
            string primaryKey
        )
        {
            DatabasePrimaryKeys target
               = new DatabasePrimaryKeys(schema, table, column, primaryKey);
            return target;
            // TODO: add assertions to method DatabasePrimaryKeysTest.Constructor(String, String, String, String)
        }

        /// <summary>Test stub for SqlStatement()</summary>
        [PexMethod]
        public string SqlStatement()
        {
            string result = DatabasePrimaryKeys.SqlStatement();
            return result;
            // TODO: add assertions to method DatabasePrimaryKeysTest.SqlStatement()
        }
    }
}
