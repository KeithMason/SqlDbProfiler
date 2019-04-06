// <copyright file="CEventListTest.cs">Copyright ©</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for CEventList</summary>
    [PexClass(typeof(CEventList))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class CEventListTest
    {
        /// <summary>Test stub for AddEvent(Int32, Int64, String, Int64, String, String, Int64, Int64, Int64, Int64, Int64, Int64)</summary>
        [PexMethod]
        public void AddEvent(
            [PexAssumeUnderTest]CEventList target,
            int cnt,
            long databaseID,
            string databaseName,
            long objectID,
            string objectName,
            string textData,
            long cpu,
            long reads,
            long writes,
            long duration,
            long count,
            long rowcounts
        )
        {
            target.AddEvent(cnt, databaseID, databaseName, objectID, objectName, textData, 
                            cpu, reads, writes, duration, count, rowcounts);
            // TODO: add assertions to method CEventListTest.AddEvent(CEventList, Int32, Int64, String, Int64, String, String, Int64, Int64, Int64, Int64, Int64, Int64)
        }

        /// <summary>Test stub for AppendFromFile(Int32, String, Boolean, Boolean)</summary>
        [PexMethod]
        public void AppendFromFile(
            [PexAssumeUnderTest]CEventList target,
            int cnt,
            string filename,
            bool ignorenonamesp,
            bool transform
        )
        {
            target.AppendFromFile(cnt, filename, ignorenonamesp, transform);
            // TODO: add assertions to method CEventListTest.AppendFromFile(CEventList, Int32, String, Boolean, Boolean)
        }

        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public CEventList Constructor()
        {
            CEventList target = new CEventList();
            return target;
            // TODO: add assertions to method CEventListTest.Constructor()
        }
    }
}
