// <copyright file="DatabaseChangesLast90DaysTest.cs">Copyright ©</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for DatabaseChangesLast90Days</summary>
    [PexClass(typeof(DatabaseChangesLast90Days))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class DatabaseChangesLast90DaysTest
    {
        /// <summary>Test stub for .ctor(String, String, String, DateTime, DateTime)</summary>
        [PexMethod]
        public DatabaseChangesLast90Days Constructor(
            string obectjName,
            string type,
            string action,
            DateTime created,
            DateTime modified
        )
        {
            DatabaseChangesLast90Days target
               = new DatabaseChangesLast90Days(obectjName, type, action, created, modified);
            return target;
            // TODO: add assertions to method DatabaseChangesLast90DaysTest.Constructor(String, String, String, DateTime, DateTime)
        }

        /// <summary>Test stub for SqlStatement()</summary>
        [PexMethod]
        public string SqlStatement()
        {
            string result = DatabaseChangesLast90Days.SqlStatement();
            return result;
            // TODO: add assertions to method DatabaseChangesLast90DaysTest.SqlStatement()
        }
    }
}
