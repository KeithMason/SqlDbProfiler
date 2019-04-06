// <copyright file="RTFBuilderTest.cs">Copyright ©</copyright>
using System;
using System.Drawing;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for RTFBuilder</summary>
    [PexClass(typeof(RTFBuilder))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class RTFBuilderTest
    {
        /// <summary>Test stub for Append(String)</summary>
        [PexMethod]
        public void Append([PexAssumeUnderTest]RTFBuilder target, string value)
        {
            target.Append(value);
            // TODO: add assertions to method RTFBuilderTest.Append(RTFBuilder, String)
        }

        /// <summary>Test stub for AppendLine()</summary>
        [PexMethod]
        public void AppendLine([PexAssumeUnderTest]RTFBuilder target)
        {
            target.AppendLine();
            // TODO: add assertions to method RTFBuilderTest.AppendLine(RTFBuilder)
        }

        /// <summary>Test stub for set_BackColor(Color)</summary>
        [PexMethod]
        public void BackColorSet([PexAssumeUnderTest]RTFBuilder target, Color value)
        {
            target.BackColor = value;
            // TODO: add assertions to method RTFBuilderTest.BackColorSet(RTFBuilder, Color)
        }

        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public RTFBuilder Constructor()
        {
            RTFBuilder target = new RTFBuilder();
            return target;
            // TODO: add assertions to method RTFBuilderTest.Constructor()
        }

        /// <summary>Test stub for set_ForeColor(Color)</summary>
        [PexMethod]
        public void ForeColorSet([PexAssumeUnderTest]RTFBuilder target, Color value)
        {
            target.ForeColor = value;
            // TODO: add assertions to method RTFBuilderTest.ForeColorSet(RTFBuilder, Color)
        }

        /// <summary>Test stub for ToString()</summary>
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]RTFBuilder target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method RTFBuilderTest.ToString01(RTFBuilder)
        }
    }
}
