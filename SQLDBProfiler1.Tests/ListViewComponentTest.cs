// <copyright file="ListViewComponentTest.cs">Copyright ©</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for ListViewComponent</summary>
    [PexClass(typeof(ListViewComponent))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class ListViewComponentTest
    {
        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public ListViewComponent Constructor()
        {
            ListViewComponent target = new ListViewComponent();
            return target;
            // TODO: add assertions to method ListViewComponentTest.Constructor()
        }
    }
}
