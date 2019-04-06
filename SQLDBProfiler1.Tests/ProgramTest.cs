// <copyright file="ProgramTest.cs">Copyright ©</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for Program</summary>
    [PexClass(typeof(Program))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class ProgramTest
    {
        /// <summary>Test stub for Main()</summary>
        [PexMethod]
        public void Main()
        {
            Program.Main();
            // TODO: add assertions to method ProgramTest.Main()
        }
    }
}
