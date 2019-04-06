// <copyright file="DatabaseTriggersTest.cs">Copyright ©</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for DatabaseTriggers</summary>
    [PexClass(typeof(DatabaseTriggers))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class DatabaseTriggersTest
    {
        /// <summary>Test stub for .ctor(String, String, String, String, Int32, Int32, Int32, Int32, Int32, Int32)</summary>
        [PexMethod]
        public DatabaseTriggers Constructor(
            string triggerName,
            string triggerOwner,
            string tableSchema,
            string tableName,
            int update,
            int delete,
            int insert,
            int after,
            int insteadOf,
            int disabled
        )
        {
            DatabaseTriggers target = new DatabaseTriggers
                                          (triggerName, triggerOwner, tableSchema, tableName, update, 
                                           delete, insert, after, insteadOf, disabled);
            return target;
            // TODO: add assertions to method DatabaseTriggersTest.Constructor(String, String, String, String, Int32, Int32, Int32, Int32, Int32, Int32)
        }

        /// <summary>Test stub for SqlStatement()</summary>
        [PexMethod]
        public string SqlStatement()
        {
            string result = DatabaseTriggers.SqlStatement();
            return result;
            // TODO: add assertions to method DatabaseTriggersTest.SqlStatement()
        }
    }
}
