// <copyright file="TraceUtilitiesTest.cs">Copyright ©</copyright>
using System;
using System.Windows.Forms;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for TraceUtilities</summary>
    [PexClass(typeof(TraceUtilities))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class TraceUtilitiesTest
    {
        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public TraceUtilities Constructor()
        {
            TraceUtilities target = new TraceUtilities();
            return target;
            // TODO: add assertions to method TraceUtilitiesTest.Constructor()
        }

        /// <summary>Test stub for FillRichEdit(RichTextBox, String)</summary>
        [PexMethod]
        public void FillRichEdit(
            [PexAssumeUnderTest]TraceUtilities target,
            RichTextBox rich,
            string value
        )
        {
            target.FillRichEdit(rich, value);
            // TODO: add assertions to method TraceUtilitiesTest.FillRichEdit(TraceUtilities, RichTextBox, String)
        }

        /// <summary>Test stub for StandardSql(String)</summary>
        [PexMethod]
        public string StandardSql([PexAssumeUnderTest]TraceUtilities target, string sql)
        {
            string result = target.StandardSql(sql);
            return result;
            // TODO: add assertions to method TraceUtilitiesTest.StandardSql(TraceUtilities, String)
        }
    }
}
