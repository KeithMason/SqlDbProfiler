// <copyright file="SqlCodeRepositoryUpdateTest.cs">Copyright ©</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for SqlCodeRepositoryUpdate</summary>
    [PexClass(typeof(SqlCodeRepositoryUpdate))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class SqlCodeRepositoryUpdateTest
    {
        /// <summary>Test stub for .ctor(String, String, String)</summary>
        [PexMethod]
        public SqlCodeRepositoryUpdate Constructor(
            string action,
            string sqlCodeDescription,
            string sqlCode
        )
        {
            SqlCodeRepositoryUpdate target
               = new SqlCodeRepositoryUpdate(action, sqlCodeDescription, sqlCode);
            return target;
            // TODO: add assertions to method SqlCodeRepositoryUpdateTest.Constructor(String, String, String)
        }
    }
}
