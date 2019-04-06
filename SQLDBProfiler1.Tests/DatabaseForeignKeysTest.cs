// <copyright file="DatabaseForeignKeysTest.cs">Copyright ©</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for DatabaseForeignKeys</summary>
    [PexClass(typeof(DatabaseForeignKeys))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class DatabaseForeignKeysTest
    {
        /// <summary>Test stub for .ctor(String, String, String, String, String, String)</summary>
        [PexMethod]
        public DatabaseForeignKeys Constructor(
            string schema,
            string table,
            string column,
            string foreignKey,
            string referenceTable,
            string referenceColumn
        )
        {
            DatabaseForeignKeys target = new DatabaseForeignKeys
                                             (schema, table, column, foreignKey, referenceTable, referenceColumn);
            return target;
            // TODO: add assertions to method DatabaseForeignKeysTest.Constructor(String, String, String, String, String, String)
        }

        /// <summary>Test stub for SqlStatement()</summary>
        [PexMethod]
        public string SqlStatement()
        {
            string result = DatabaseForeignKeys.SqlStatement();
            return result;
            // TODO: add assertions to method DatabaseForeignKeysTest.SqlStatement()
        }
    }
}
