// <copyright file="SqlQueriesTest.cs">Copyright ©</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for SqlQueries</summary>
    [PexClass(typeof(SqlQueries))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class SqlQueriesTest
    {
        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public SqlQueries Constructor()
        {
            SqlQueries target = new SqlQueries();
            return target;
            // TODO: add assertions to method SqlQueriesTest.Constructor()
        }
    }
}
