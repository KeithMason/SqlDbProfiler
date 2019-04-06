// <copyright file="EventListTest.cs">Copyright ©</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for EventList</summary>
    [PexClass(typeof(EventList))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class EventListTest
    {
        /// <summary>Test stub for get_AvgCPU()</summary>
        [PexMethod]
        public long AvgCPUGet([PexAssumeUnderTest]EventList target)
        {
            long result = target.AvgCPU;
            return result;
            // TODO: add assertions to method EventListTest.AvgCPUGet(EventList)
        }

        /// <summary>Test stub for get_AvgDuration()</summary>
        [PexMethod]
        public long AvgDurationGet([PexAssumeUnderTest]EventList target)
        {
            long result = target.AvgDuration;
            return result;
            // TODO: add assertions to method EventListTest.AvgDurationGet(EventList)
        }

        /// <summary>Test stub for get_AvgReads()</summary>
        [PexMethod]
        public long AvgReadsGet([PexAssumeUnderTest]EventList target)
        {
            long result = target.AvgReads;
            return result;
            // TODO: add assertions to method EventListTest.AvgReadsGet(EventList)
        }

        /// <summary>Test stub for get_AvgWrites()</summary>
        [PexMethod]
        public long AvgWritesGet([PexAssumeUnderTest]EventList target)
        {
            long result = target.AvgWrites;
            return result;
            // TODO: add assertions to method EventListTest.AvgWritesGet(EventList)
        }

        /// <summary>Test stub for .ctor(Int64, String, Int64, String, String)</summary>
        [PexMethod]
        public EventList Constructor(
            long databaseID,
            string databaseName,
            long objectID,
            string objectName,
            string textData
        )
        {
            EventList target
               = new EventList(databaseID, databaseName, objectID, objectName, textData);
            return target;
            // TODO: add assertions to method EventListTest.Constructor(Int64, String, Int64, String, String)
        }

        /// <summary>Test stub for .ctor(Int64, Int64, Int64, Int64, String, Int64, String, String, Int64, Int64, Int64, Int64)</summary>
        [PexMethod]
        public EventList Constructor01(
            long eventClass,
            long spid,
            long nestLevel,
            long databaseID,
            string databaseName,
            long objectID,
            string objectName,
            string textData,
            long duration,
            long reads,
            long writes,
            long cpu
        )
        {
            EventList target = new EventList
                                   (eventClass, spid, nestLevel, databaseID, databaseName, objectID, 
                                    objectName, textData, duration, reads, writes, cpu);
            return target;
            // TODO: add assertions to method EventListTest.Constructor01(Int64, Int64, Int64, Int64, String, Int64, String, String, Int64, Int64, Int64, Int64)
        }

        /// <summary>Test stub for GetKey()</summary>
        [PexMethod]
        public string GetKey([PexAssumeUnderTest]EventList target)
        {
            string result = target.GetKey();
            return result;
            // TODO: add assertions to method EventListTest.GetKey(EventList)
        }
    }
}
