// <copyright file="ProfilerEventsErrorsAndWarningsTest.cs">Copyright ©</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for ErrorsAndWarnings</summary>
    [PexClass(typeof(ProfilerEvents.ErrorsAndWarnings))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class ProfilerEventsErrorsAndWarningsTest
    {
    }
}
