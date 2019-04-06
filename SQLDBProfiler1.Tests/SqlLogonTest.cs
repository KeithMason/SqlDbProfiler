// <copyright file="SqlLogonTest.cs">Copyright ©</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for SqlLogon</summary>
    [PexClass(typeof(SqlLogon))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class SqlLogonTest
    {
        /// <summary>Test stub for .ctor(ConnectionParameters)</summary>
        [PexMethod]
        public SqlLogon Constructor(ConnectionParameters connectionParameters)
        {
            SqlLogon target = new SqlLogon(connectionParameters);
            return target;
            // TODO: add assertions to method SqlLogonTest.Constructor(ConnectionParameters)
        }
    }
}
