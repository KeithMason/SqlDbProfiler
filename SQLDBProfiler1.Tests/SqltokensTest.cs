// <copyright file="SqltokensTest.cs">Copyright ©</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for Sqltokens</summary>
    [PexClass(typeof(Sqltokens))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class SqltokensTest
    {
        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public Sqltokens Constructor()
        {
            Sqltokens target = new Sqltokens();
            return target;
            // TODO: add assertions to method SqltokensTest.Constructor()
        }

        /// <summary>Test stub for get_Item(String)</summary>
        [PexMethod]
        public TraceUtilities.TokenKind ItemGet([PexAssumeUnderTest]Sqltokens target, string token)
        {
            TraceUtilities.TokenKind result = target[token];
            return result;
            // TODO: add assertions to method SqltokensTest.ItemGet(Sqltokens, String)
        }
    }
}
