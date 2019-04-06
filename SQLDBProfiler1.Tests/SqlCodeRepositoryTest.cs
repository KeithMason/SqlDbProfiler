// <copyright file="SqlCodeRepositoryTest.cs">Copyright ©</copyright>
using System;
using System.Windows.Forms;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for SqlCodeRepository</summary>
    [PexClass(typeof(SqlCodeRepository))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class SqlCodeRepositoryTest
    {
        /// <summary>Test stub for .ctor(Form)</summary>
        [PexMethod]
        public SqlCodeRepository Constructor(Form parentForm)
        {
            SqlCodeRepository target = new SqlCodeRepository(parentForm);
            return target;
            // TODO: add assertions to method SqlCodeRepositoryTest.Constructor(Form)
        }
    }
}
