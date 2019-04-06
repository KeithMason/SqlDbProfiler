// <copyright file="DatabaseIdentityFieldsTest.cs">Copyright ©</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for DatabaseIdentityFields</summary>
    [PexClass(typeof(DatabaseIdentityFields))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class DatabaseIdentityFieldsTest
    {
        /// <summary>Test stub for .ctor(String, String, String, String, Int32, Int32, Int32)</summary>
        [PexMethod]
        public DatabaseIdentityFields Constructor(
            string schema,
            string tableName,
            string column,
            string type,
            int seed,
            int increment,
            int currentIdentity
        )
        {
            DatabaseIdentityFields target = new DatabaseIdentityFields
                                                (schema, tableName, column, type, seed, increment, currentIdentity);
            return target;
            // TODO: add assertions to method DatabaseIdentityFieldsTest.Constructor(String, String, String, String, Int32, Int32, Int32)
        }

        /// <summary>Test stub for SqlStatement()</summary>
        [PexMethod]
        public string SqlStatement()
        {
            string result = DatabaseIdentityFields.SqlStatement();
            return result;
            // TODO: add assertions to method DatabaseIdentityFieldsTest.SqlStatement()
        }
    }
}
