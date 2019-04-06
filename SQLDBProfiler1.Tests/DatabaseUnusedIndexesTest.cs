// <copyright file="DatabaseUnusedIndexesTest.cs">Copyright ©</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for DatabaseUnusedIndexes</summary>
    [PexClass(typeof(DatabaseUnusedIndexes))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class DatabaseUnusedIndexesTest
    {
        /// <summary>Test stub for .ctor(String, String, String)</summary>
        [PexMethod]
        public DatabaseUnusedIndexes Constructor(
            string schema,
            string table,
            string index
        )
        {
            DatabaseUnusedIndexes target = new DatabaseUnusedIndexes(schema, table, index);
            return target;
            // TODO: add assertions to method DatabaseUnusedIndexesTest.Constructor(String, String, String)
        }

        /// <summary>Test stub for SqlStatement()</summary>
        [PexMethod]
        public string SqlStatement()
        {
            string result = DatabaseUnusedIndexes.SqlStatement();
            return result;
            // TODO: add assertions to method DatabaseUnusedIndexesTest.SqlStatement()
        }
    }
}
