// <copyright file="DatabaseNonClusteredIndexesTest.cs">Copyright ©</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for DatabaseNonClusteredIndexes</summary>
    [PexClass(typeof(DatabaseNonClusteredIndexes))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class DatabaseNonClusteredIndexesTest
    {
        /// <summary>Test stub for .ctor(String, String, String, String, String)</summary>
        [PexMethod]
        public DatabaseNonClusteredIndexes Constructor(
            string schema,
            string table,
            string index,
            string column,
            string unique
        )
        {
            DatabaseNonClusteredIndexes target
               = new DatabaseNonClusteredIndexes(schema, table, index, column, unique);
            return target;
            // TODO: add assertions to method DatabaseNonClusteredIndexesTest.Constructor(String, String, String, String, String)
        }

        /// <summary>Test stub for SqlStatement()</summary>
        [PexMethod]
        public string SqlStatement()
        {
            string result = DatabaseNonClusteredIndexes.SqlStatement();
            return result;
            // TODO: add assertions to method DatabaseNonClusteredIndexesTest.SqlStatement()
        }
    }
}
