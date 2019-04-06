// <copyright file="SimpleEventListTest.cs">Copyright ©</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for SimpleEventList</summary>
    [PexClass(typeof(SimpleEventList))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class SimpleEventListTest
    {
        /// <summary>Test stub for AddEvent(Int64, Int64, Int64, String, Int64, String, String, Int64, Int64, Int64, Int64, Int64, Int64)</summary>
        [PexMethod]
        public void AddEvent(
            [PexAssumeUnderTest]SimpleEventList target,
            long eventClass,
            long nestLevel,
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
            target.AddEvent
                (eventClass, nestLevel, databaseID, databaseName, objectID, objectName, 
                 textData, cpu, reads, writes, duration, count, rowcounts);
            // TODO: add assertions to method SimpleEventListTest.AddEvent(SimpleEventList, Int64, Int64, Int64, String, Int64, String, String, Int64, Int64, Int64, Int64, Int64, Int64)
        }

        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public SimpleEventList Constructor()
        {
            SimpleEventList target = new SimpleEventList();
            return target;
            // TODO: add assertions to method SimpleEventListTest.Constructor()
        }

        /// <summary>Test stub for SaveToFile(String)</summary>
        [PexMethod]
        public void SaveToFile([PexAssumeUnderTest]SimpleEventList target, string filename)
        {
            target.SaveToFile(filename);
            // TODO: add assertions to method SimpleEventListTest.SaveToFile(SimpleEventList, String)
        }
    }
}
