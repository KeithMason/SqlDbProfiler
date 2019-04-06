// <copyright file="DatabaseNameSizeTest.cs">Copyright ©</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for DatabaseNameSize</summary>
    [PexClass(typeof(DatabaseNameSize))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class DatabaseNameSizeTest
    {
        /// <summary>Test stub for .ctor(String, String, String, Int32)</summary>
        [PexMethod]
        public DatabaseNameSize Constructor(
            string databaseName,
            string logicalName,
            string physicalName,
            int sizeMB
        )
        {
            DatabaseNameSize target
               = new DatabaseNameSize(databaseName, logicalName, physicalName, sizeMB);
            return target;
            // TODO: add assertions to method DatabaseNameSizeTest.Constructor(String, String, String, Int32)
        }

        /// <summary>Test stub for SqlStatement()</summary>
        [PexMethod]
        public string SqlStatement()
        {
            string result = DatabaseNameSize.SqlStatement();
            return result;
            // TODO: add assertions to method DatabaseNameSizeTest.SqlStatement()
        }
    }
}
