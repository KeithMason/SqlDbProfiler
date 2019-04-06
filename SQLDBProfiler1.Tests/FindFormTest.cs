// <copyright file="FindFormTest.cs">Copyright ©</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for FindForm</summary>
    [PexClass(typeof(FindForm))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class FindFormTest
    {
        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public FindForm Constructor()
        {
            FindForm target = new FindForm();
            return target;
            // TODO: add assertions to method FindFormTest.Constructor()
        }
    }
}
