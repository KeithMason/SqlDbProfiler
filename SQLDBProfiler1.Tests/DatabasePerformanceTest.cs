// <copyright file="DatabasePerformanceTest.cs">Copyright ©</copyright>
using System;
using System.Windows.Forms;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for DatabasePerformance</summary>
    [PexClass(typeof(DatabasePerformance))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class DatabasePerformanceTest
    {
        /// <summary>Test stub for .ctor(ConnectionParameters, Form)</summary>
        [PexMethod]
        public DatabasePerformance Constructor(ConnectionParameters connectionParameters, Form parentForm)
        {
            DatabasePerformance target
               = new DatabasePerformance(connectionParameters, parentForm);
            return target;
            // TODO: add assertions to method DatabasePerformanceTest.Constructor(ConnectionParameters, Form)
        }
    }
}
