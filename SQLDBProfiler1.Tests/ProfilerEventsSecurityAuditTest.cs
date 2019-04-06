// <copyright file="ProfilerEventsSecurityAuditTest.cs">Copyright ©</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for SecurityAudit</summary>
    [PexClass(typeof(ProfilerEvents.SecurityAudit))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class ProfilerEventsSecurityAuditTest
    {
    }
}
