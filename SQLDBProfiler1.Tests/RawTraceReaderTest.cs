// <copyright file="RawTraceReaderTest.cs">Copyright ©</copyright>
using System;
using System.Data.SqlClient;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for RawTraceReader</summary>
    [PexClass(typeof(RawTraceReader))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class RawTraceReaderTest
    {
        /// <summary>Test stub for BuildEventSql(Int32, Int32, Int32[])</summary>
        [PexMethod]
        public string BuildEventSql(
            int traceid,
            int eventId,
            int[] columns
        )
        {
            string result = RawTraceReader.BuildEventSql(traceid, eventId, columns);
            return result;
            // TODO: add assertions to method RawTraceReaderTest.BuildEventSql(Int32, Int32, Int32[])
        }

        /// <summary>Test stub for Close()</summary>
        [PexMethod]
        public void Close([PexAssumeUnderTest]RawTraceReader target)
        {
            target.Close();
            // TODO: add assertions to method RawTraceReaderTest.Close(RawTraceReader)
        }

        /// <summary>Test stub for CloseTrace(SqlConnection)</summary>
        [PexMethod]
        public void CloseTrace([PexAssumeUnderTest]RawTraceReader target, SqlConnection con)
        {
            target.CloseTrace(con);
            // TODO: add assertions to method RawTraceReaderTest.CloseTrace(RawTraceReader, SqlConnection)
        }

        /// <summary>Test stub for .ctor(SqlConnection)</summary>
        [PexMethod]
        public RawTraceReader Constructor(SqlConnection con)
        {
            RawTraceReader target = new RawTraceReader(con);
            return target;
            // TODO: add assertions to method RawTraceReaderTest.Constructor(SqlConnection)
        }

        /// <summary>Test stub for CreateTrace()</summary>
        [PexMethod]
        public void CreateTrace([PexAssumeUnderTest]RawTraceReader target)
        {
            target.CreateTrace();
            // TODO: add assertions to method RawTraceReaderTest.CreateTrace(RawTraceReader)
        }

        /// <summary>Test stub for Next()</summary>
        [PexMethod]
        public ProfilerEvent Next([PexAssumeUnderTest]RawTraceReader target)
        {
            ProfilerEvent result = target.Next();
            return result;
            // TODO: add assertions to method RawTraceReaderTest.Next(RawTraceReader)
        }

        /// <summary>Test stub for SetEvent(Int32, Int32[])</summary>
        [PexMethod]
        public void SetEvent(
            [PexAssumeUnderTest]RawTraceReader target,
            int eventId,
            int[] columns
        )
        {
            target.SetEvent(eventId, columns);
            // TODO: add assertions to method RawTraceReaderTest.SetEvent(RawTraceReader, Int32, Int32[])
        }

        /// <summary>Test stub for SetFilter(Int32, Int32, Int32, Nullable`1&lt;Int64&gt;)</summary>
        [PexMethod]
        public void SetFilter(
            [PexAssumeUnderTest]RawTraceReader target,
            int columnId,
            int logicalOperator,
            int comparisonOperator,
            long? value
        )
        {
            target.SetFilter(columnId, logicalOperator, comparisonOperator, value);
            // TODO: add assertions to method RawTraceReaderTest.SetFilter(RawTraceReader, Int32, Int32, Int32, Nullable`1<Int64>)
        }

        /// <summary>Test stub for SetFilter(Int32, Int32, Int32, String)</summary>
        [PexMethod]
        public void SetFilter01(
            [PexAssumeUnderTest]RawTraceReader target,
            int columnId,
            int logicalOperator,
            int comparisonOperator,
            string value
        )
        {
            target.SetFilter(columnId, logicalOperator, comparisonOperator, value);
            // TODO: add assertions to method RawTraceReaderTest.SetFilter01(RawTraceReader, Int32, Int32, Int32, String)
        }

        /// <summary>Test stub for StartTrace()</summary>
        [PexMethod]
        public void StartTrace([PexAssumeUnderTest]RawTraceReader target)
        {
            target.StartTrace();
            // TODO: add assertions to method RawTraceReaderTest.StartTrace(RawTraceReader)
        }

        /// <summary>Test stub for StopTrace(SqlConnection)</summary>
        [PexMethod]
        public void StopTrace([PexAssumeUnderTest]RawTraceReader target, SqlConnection con)
        {
            target.StopTrace(con);
            // TODO: add assertions to method RawTraceReaderTest.StopTrace(RawTraceReader, SqlConnection)
        }

        /// <summary>Test stub for get_TraceId()</summary>
        [PexMethod]
        public int TraceIdGet([PexAssumeUnderTest]RawTraceReader target)
        {
            int result = target.TraceId;
            return result;
            // TODO: add assertions to method RawTraceReaderTest.TraceIdGet(RawTraceReader)
        }

        /// <summary>Test stub for get_TraceIsActive()</summary>
        [PexMethod]
        public bool TraceIsActiveGet([PexAssumeUnderTest]RawTraceReader target)
        {
            bool result = target.TraceIsActive;
            return result;
            // TODO: add assertions to method RawTraceReaderTest.TraceIsActiveGet(RawTraceReader)
        }
    }
}
