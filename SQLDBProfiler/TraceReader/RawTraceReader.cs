// ----------------------------------------------------------------------
// <copyright file="RawTraceReader.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
//     Traceutils assembly  
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Text;

    /// <summary>
    /// Raw Trace Reader
    /// </summary>
    public class RawTraceReader
    {
        /// <summary>
        /// The delegates
        /// </summary>
        public readonly SetEventDelegate[] EventDelegates = new SetEventDelegate[66];

        #region private fields

        /// <summary>
        /// The m_ B16
        /// </summary>
        private readonly byte[] b16 = new byte[16];

        /// <summary>
        /// The m_ b8
        /// </summary>
        private readonly byte[] b8 = new byte[8];

        /// <summary>
        /// The m_ b2
        /// </summary>
        private readonly byte[] b2 = new byte[2];

        /// <summary>
        /// The m_ b4
        /// </summary>
        private readonly byte[] b4 = new byte[4];

        /// <summary>
        /// The m_ conn
        /// </summary>
        private readonly SqlConnection connection;

        /// <summary>
        /// The m_ reader
        /// </summary>
        private DbDataReader reader;

        /// <summary>
        /// The m_ trace id
        /// </summary>
        private int traceId;

        /// <summary>
        /// The m_ last read
        /// </summary>
        private bool lastRead;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RawTraceReader"/> class.
        /// </summary>
        /// <param name="con">The con.</param>
        public RawTraceReader(SqlConnection con)
        {
            this.connection = con;
            SetEventDelegate evtInt = this.SetIntColumn;
            SetEventDelegate evtLong = this.SetLongColumn;
            SetEventDelegate evtString = this.SetStringColumn;
            SetEventDelegate evtByte = this.SetByteColumn;
            SetEventDelegate evtDateTime = this.SetDateTimeColumn;
            SetEventDelegate evtGuid = SetGuidColumn;

            this.EventDelegates[ProfilerEventColumns.TextData] = evtString;
            this.EventDelegates[ProfilerEventColumns.BinaryData] = evtByte;
            this.EventDelegates[ProfilerEventColumns.DatabaseID] = evtInt;
            this.EventDelegates[ProfilerEventColumns.TransactionID] = evtLong;
            this.EventDelegates[ProfilerEventColumns.LineNumber] = evtInt;
            this.EventDelegates[ProfilerEventColumns.NTUserName] = evtString;
            this.EventDelegates[ProfilerEventColumns.NTDomainName] = evtString;
            this.EventDelegates[ProfilerEventColumns.HostName] = evtString;
            this.EventDelegates[ProfilerEventColumns.ClientProcessID] = evtInt;
            this.EventDelegates[ProfilerEventColumns.ApplicationName] = evtString;
            this.EventDelegates[ProfilerEventColumns.LoginName] = evtString;
            this.EventDelegates[ProfilerEventColumns.SPID] = evtInt;
            this.EventDelegates[ProfilerEventColumns.Duration] = evtLong;
            this.EventDelegates[ProfilerEventColumns.StartTime] = evtDateTime;
            this.EventDelegates[ProfilerEventColumns.EndTime] = evtDateTime;
            this.EventDelegates[ProfilerEventColumns.Reads] = evtLong;
            this.EventDelegates[ProfilerEventColumns.Writes] = evtLong;
            this.EventDelegates[ProfilerEventColumns.CPU] = evtInt;
            this.EventDelegates[ProfilerEventColumns.Permissions] = evtLong;
            this.EventDelegates[ProfilerEventColumns.Severity] = evtInt;
            this.EventDelegates[ProfilerEventColumns.EventSubClass] = evtInt;
            this.EventDelegates[ProfilerEventColumns.ObjectID] = evtInt;
            this.EventDelegates[ProfilerEventColumns.Success] = evtInt;
            this.EventDelegates[ProfilerEventColumns.IndexID] = evtInt;
            this.EventDelegates[ProfilerEventColumns.IntegerData] = evtInt;
            this.EventDelegates[ProfilerEventColumns.ServerName] = evtString;
            this.EventDelegates[ProfilerEventColumns.EventClass] = evtInt;
            this.EventDelegates[ProfilerEventColumns.ObjectType] = evtInt;
            this.EventDelegates[ProfilerEventColumns.NestLevel] = evtInt;
            this.EventDelegates[ProfilerEventColumns.State] = evtInt;
            this.EventDelegates[ProfilerEventColumns.Error] = evtInt;
            this.EventDelegates[ProfilerEventColumns.Mode] = evtInt;
            this.EventDelegates[ProfilerEventColumns.Handle] = evtInt;
            this.EventDelegates[ProfilerEventColumns.ObjectName] = evtString;
            this.EventDelegates[ProfilerEventColumns.DatabaseName] = evtString;
            this.EventDelegates[ProfilerEventColumns.FileName] = evtString;
            this.EventDelegates[ProfilerEventColumns.OwnerName] = evtString;
            this.EventDelegates[ProfilerEventColumns.RoleName] = evtString;
            this.EventDelegates[ProfilerEventColumns.TargetUserName] = evtString;
            this.EventDelegates[ProfilerEventColumns.DBUserName] = evtString;
            this.EventDelegates[ProfilerEventColumns.LoginSid] = evtByte;
            this.EventDelegates[ProfilerEventColumns.TargetLoginName] = evtString;
            this.EventDelegates[ProfilerEventColumns.TargetLoginSid] = evtByte;
            this.EventDelegates[ProfilerEventColumns.ColumnPermissions] = evtInt;
            this.EventDelegates[ProfilerEventColumns.LinkedServerName] = evtString;
            this.EventDelegates[ProfilerEventColumns.ProviderName] = evtString;
            this.EventDelegates[ProfilerEventColumns.MethodName] = evtString;
            this.EventDelegates[ProfilerEventColumns.RowCounts] = evtLong;
            this.EventDelegates[ProfilerEventColumns.RequestID] = evtInt;
            this.EventDelegates[ProfilerEventColumns.XactSequence] = evtLong;
            this.EventDelegates[ProfilerEventColumns.EventSequence] = evtLong;
            this.EventDelegates[ProfilerEventColumns.BigintData1] = evtLong;
            this.EventDelegates[ProfilerEventColumns.BigintData2] = evtLong;
            this.EventDelegates[ProfilerEventColumns.GUID] = evtGuid;
            this.EventDelegates[ProfilerEventColumns.IntegerData2] = evtInt;
            this.EventDelegates[ProfilerEventColumns.ObjectID2] = evtLong;
            this.EventDelegates[ProfilerEventColumns.Type] = evtInt;
            this.EventDelegates[ProfilerEventColumns.OwnerID] = evtInt;
            this.EventDelegates[ProfilerEventColumns.ParentName] = evtString;
            this.EventDelegates[ProfilerEventColumns.IsSystem] = evtInt;
            this.EventDelegates[ProfilerEventColumns.Offset] = evtInt;
            this.EventDelegates[ProfilerEventColumns.SourceDatabaseID] = evtInt;
            this.EventDelegates[ProfilerEventColumns.SqlHandle] = evtByte;
            this.EventDelegates[ProfilerEventColumns.SessionLoginName] = evtString;
            this.EventDelegates[ProfilerEventColumns.PlanHandle] = evtByte;
        }

        #endregion

        /// <summary>
        /// Set Raw Trace Reader Event Delegate
        /// </summary>
        /// <param name="evt">The event.</param>
        /// <param name="columnid">The column id.</param>
        public delegate void SetEventDelegate(ProfilerEvent evt, int columnid);

        #region public properties

        /// <summary>
        /// Gets the trace id.
        /// </summary>
        /// <value>
        /// The trace id.
        /// </value>
        public int TraceId
        {
            get { return this.traceId; }
        }

        /// <summary>
        /// Gets a value indicating whether [trace is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [trace is active]; otherwise, <c>false</c>.
        /// </value>
        public bool TraceIsActive
        {
            get
            {
                return this.lastRead;
            }
        }

        #endregion

        #region public methods

        /// <summary>
        /// Builds the event SQL.
        /// </summary>
        /// <param name="traceid">The trace id.</param>
        /// <param name="eventId">The event id.</param>
        /// <param name="columns">The columns.</param>
        /// <returns>Event SQL</returns>
        public static string BuildEventSql(int traceid, int eventId, params int[] columns)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int i in columns)
            {
                sb.AppendFormat("\r\n exec sp_trace_setevent {0}, {1}, {2}, @on", traceid, eventId, i);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Closes this instance.
        /// </summary>
        public void Close()
        {
            if (this.reader != null)
            {
                this.reader.Close();
            }

            this.lastRead = false;
        }

        /// <summary>
        /// Sets the event.
        /// </summary>
        /// <param name="eventId">The event id.</param>
        /// <param name="columns">The columns.</param>
        public void SetEvent(int eventId, params int[] columns)
        {
            SqlCommand cmd = new SqlCommand { Connection = this.connection, CommandText = "sp_trace_setevent", CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add("@traceid", SqlDbType.Int).Value = this.traceId;
            cmd.Parameters.Add("@eventid", SqlDbType.Int).Value = eventId;
            SqlParameter p = cmd.Parameters.Add("@columnid", SqlDbType.Int);
            cmd.Parameters.Add("@on", SqlDbType.Bit).Value = 1;
            foreach (int i in columns)
            {
                p.Value = i;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Sets the filter.
        /// </summary>
        /// <param name="columnId">The column id.</param>
        /// <param name="logicalOperator">The logical operator.</param>
        /// <param name="comparisonOperator">The comparison operator.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="System.Exception">an exception</exception>
        public void SetFilter(int columnId, int logicalOperator, int comparisonOperator, long? value)
        {
            SqlCommand cmd = new SqlCommand { Connection = this.connection, CommandText = "sp_trace_setfilter", CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add("@traceid", SqlDbType.Int).Value = this.traceId;
            cmd.Parameters.Add("@columnid", SqlDbType.Int).Value = columnId;
            cmd.Parameters.Add("@logical_operator", SqlDbType.Int).Value = logicalOperator;
            cmd.Parameters.Add("@comparison_operator", SqlDbType.Int).Value = comparisonOperator;
            if (value == null)
            {
                cmd.Parameters.Add("@value", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                switch (columnId)
                {
                    case ProfilerEventColumns.BigintData1:
                    case ProfilerEventColumns.BigintData2:
                    case ProfilerEventColumns.Duration:
                    case ProfilerEventColumns.EventSequence:
                    case ProfilerEventColumns.ObjectID2:
                    case ProfilerEventColumns.Permissions:
                    case ProfilerEventColumns.Reads:
                    case ProfilerEventColumns.RowCounts:
                    case ProfilerEventColumns.TransactionID:
                    case ProfilerEventColumns.Writes:
                    case ProfilerEventColumns.XactSequence:
                        cmd.Parameters.Add("@value", SqlDbType.BigInt).Value = value;
                        break;
                    case ProfilerEventColumns.ClientProcessID:
                    case ProfilerEventColumns.ColumnPermissions:
                    case ProfilerEventColumns.CPU:
                    case ProfilerEventColumns.DatabaseID:
                    case ProfilerEventColumns.Error:
                    case ProfilerEventColumns.EventClass:
                    case ProfilerEventColumns.EventSubClass:
                    case ProfilerEventColumns.Handle:
                    case ProfilerEventColumns.IndexID:
                    case ProfilerEventColumns.IntegerData:
                    case ProfilerEventColumns.IntegerData2:
                    case ProfilerEventColumns.IsSystem:
                    case ProfilerEventColumns.LineNumber:
                    case ProfilerEventColumns.Mode:
                    case ProfilerEventColumns.NestLevel:
                    case ProfilerEventColumns.ObjectID:
                    case ProfilerEventColumns.ObjectType:
                    case ProfilerEventColumns.Offset:
                    case ProfilerEventColumns.OwnerID:
                    case ProfilerEventColumns.RequestID:
                    case ProfilerEventColumns.Severity:
                    case ProfilerEventColumns.SourceDatabaseID:
                    case ProfilerEventColumns.SPID:
                    case ProfilerEventColumns.State:
                    case ProfilerEventColumns.Success:
                    case ProfilerEventColumns.Type:
                        cmd.Parameters.Add("@value", SqlDbType.Int).Value = value;
                        break;
                    default:
                        throw new Exception(string.Format("Unsupported column_id: {0}", columnId));
                }
            }

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Sets the filter.
        /// </summary>
        /// <param name="columnId">The column id.</param>
        /// <param name="logicalOperator">The logical operator.</param>
        /// <param name="comparisonOperator">The comparison operator.</param>
        /// <param name="value">The value.</param>
        public void SetFilter(int columnId, int logicalOperator, int comparisonOperator, string value)
        {
            SqlCommand cmd = new SqlCommand { Connection = this.connection, CommandText = "sp_trace_setfilter", CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add("@traceid", SqlDbType.Int).Value = this.traceId;
            cmd.Parameters.Add("@columnid", SqlDbType.Int).Value = columnId;
            cmd.Parameters.Add("@logical_operator", SqlDbType.Int).Value = logicalOperator;
            cmd.Parameters.Add("@comparison_operator", SqlDbType.Int).Value = comparisonOperator;
            if (value == null)
            {
                cmd.Parameters.Add("@value", SqlDbType.NVarChar).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add("@value", SqlDbType.NVarChar, value.Length).Value = value;
            }

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Creates the trace.
        /// </summary>
        public void CreateTrace()
        {
            SqlCommand cmd = new SqlCommand { Connection = this.connection, CommandText = "sp_trace_create", CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add("@traceid", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@options", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@trace_file", SqlDbType.NVarChar, 245).Value = DBNull.Value;
            cmd.Parameters.Add("@maxfilesize", SqlDbType.BigInt).Value = DBNull.Value;
            cmd.Parameters.Add("@stoptime", SqlDbType.DateTime).Value = DBNull.Value;
            cmd.Parameters.Add("@filecount", SqlDbType.Int).Value = DBNull.Value;
            cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();
            int result = (int)cmd.Parameters["@result"].Value;
            this.traceId = result != 0 ? -result : (int)cmd.Parameters["@traceid"].Value;
        }

        /// <summary>
        /// Closes the trace.
        /// </summary>
        /// <param name="con">The con.</param>
        public void CloseTrace(SqlConnection con)
        {
            this.ControlTrace(con, 2);
        }

        /// <summary>
        /// Stops the trace.
        /// </summary>
        /// <param name="con">The con.</param>
        public void StopTrace(SqlConnection con)
        {
            this.ControlTrace(con, 0);
        }

        /// <summary>
        /// Starts the trace.
        /// </summary>
        public void StartTrace()
        {
            this.ControlTrace(this.connection, 1);
            this.GetReader();
            this.Read();
        }

        /// <summary>
        /// Next instance.
        /// </summary>
        /// <returns>the next instance</returns>
        public ProfilerEvent Next()
        {
            if (!this.TraceIsActive)
            {
                return null;
            }

            int columnid = (int)this.reader[0];
            ////skip to begin of new event
            while (columnid != 65526 && this.Read() && this.TraceIsActive)
            {
                columnid = (int)this.reader[0];
            }

            ////start of new event
            if (columnid != 65526)
            {
                return null;
            }

            if (!this.TraceIsActive)
            {
                return null;
            }

            ////get potential event class
            this.reader.GetBytes(2, 0, this.b2, 0, 2);
            int eventClass = ToInt16(this.b2);

            ////we got new event
            if (eventClass >= 0 && eventClass < 255)
            {
                ProfilerEvent evt = new ProfilerEvent();
                evt.EventObjects[27] = eventClass;
                evt.ColumnMask |= 1 << 27;
                while (this.Read())
                {
                    columnid = (int)this.reader[0];
                    if (columnid > 64)
                    {
                        return evt;
                    }

                    this.EventDelegates[columnid](evt, columnid);
                }
            }

            this.Read();
            return null;
        }

        #endregion

        #region private methods

        /// <summary>
        /// Sets the GUID column.
        /// </summary>
        /// <param name="evt">The event.</param>
        /// <param name="columnid">The column id.</param>
        /// <exception cref="System.NotImplementedException">an exception</exception>
        private static void SetGuidColumn(ProfilerEvent evt, int columnid)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// To the integer 64.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>integer 64.</returns>
        private static long ToInt64(byte[] value)
        {
            int i1 = value[0] | value[1] << 8 | value[2] << 16 | value[3] << 24;
            int i2 = value[4] | value[5] << 8 | value[6] << 16 | value[7] << 24;
            return (uint)i1 | ((long)i2 << 32);
        }

        /// <summary>
        /// To the integer 32.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>integer 32.</returns>
        private static int ToInt32(byte[] value)
        {
            return value[0] | value[1] << 8 | value[2] << 16 | value[3] << 24;
        }

        /// <summary>
        /// To the integer 16.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>integer 16.</returns>
        private static int ToInt16(byte[] value)
        {
            return value[0] | value[1] << 8;
        }

        /// <summary>
        /// Controls the trace.
        /// </summary>
        /// <param name="con">The con.</param>
        /// <param name="status">The status.</param>
        private void ControlTrace(SqlConnection con, int status)
        {
            SqlCommand cmd = new SqlCommand { Connection = con, CommandText = "sp_trace_setstatus", CommandType = CommandType.StoredProcedure, CommandTimeout = 0 };
            cmd.Parameters.Add("@traceid", SqlDbType.Int).Value = this.traceId;
            cmd.Parameters.Add("@status", SqlDbType.Int).Value = status;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Gets the reader.
        /// </summary>
        private void GetReader()
        {
            SqlCommand cmd = new SqlCommand { Connection = this.connection, CommandText = "sp_trace_getdata", CommandType = CommandType.StoredProcedure, CommandTimeout = 0 };
            cmd.Parameters.Add("@traceid", SqlDbType.Int).Value = this.traceId;
            cmd.Parameters.Add("@records", SqlDbType.Int).Value = 0;
            this.reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
        }

        /// <summary>
        /// Reads this instance.
        /// </summary>
        /// <returns>true or false</returns>
        private bool Read()
        {
            this.lastRead = this.reader.Read();
            return this.lastRead;
        }

        /// <summary>
        /// Sets the date time column.
        /// </summary>
        /// <param name="evt">The event.</param>
        /// <param name="columnid">The column id.</param>
        private void SetDateTimeColumn(ProfilerEvent evt, int columnid)
        {
            ////2 byte - year
            ////2 byte - month
            ////2 byte - ???
            ////2 byte - day
            ////2 byte - hour
            ////2 byte - min
            ////2 byte - sec
            ////2 byte - msec
            this.reader.GetBytes(2, 0, this.b16, 0, 16);
            int year = this.b16[0] | this.b16[1] << 8;
            int month = this.b16[2] | this.b16[3] << 8;
            int day = this.b16[6] | this.b16[7] << 8;
            int hour = this.b16[8] | this.b16[9] << 8;
            int min = this.b16[10] | this.b16[11] << 8;
            int sec = this.b16[12] | this.b16[13] << 8;
            int msec = this.b16[14] | this.b16[15] << 8;
            evt.EventObjects[columnid] = new DateTime(year, month, day, hour, min, sec, msec);
            evt.ColumnMask |= (ulong)1 << columnid;
        }

        /// <summary>
        /// Sets the byte column.
        /// </summary>
        /// <param name="evt">The event.</param>
        /// <param name="columnid">The column id.</param>
        private void SetByteColumn(ProfilerEvent evt, int columnid)
        {
            byte[] b = new byte[(int)this.reader[1]];
            evt.EventObjects[columnid] = b;
            evt.ColumnMask |= 1UL << columnid;
        }

        /// <summary>
        /// Sets the string column.
        /// </summary>
        /// <param name="evt">The event.</param>
        /// <param name="columnid">The column id.</param>
        private void SetStringColumn(ProfilerEvent evt, int columnid)
        {
            evt.EventObjects[columnid] = Encoding.Unicode.GetString((byte[])this.reader[2]);
            evt.ColumnMask |= 1UL << columnid;
        }

        /// <summary>
        /// Sets the integer column.
        /// </summary>
        /// <param name="evt">The event.</param>
        /// <param name="columnid">The column id.</param>
        private void SetIntColumn(ProfilerEvent evt, int columnid)
        {
            this.reader.GetBytes(2, 0, this.b4, 0, 4);
            evt.EventObjects[columnid] = ToInt32(this.b4);
            evt.ColumnMask |= 1UL << columnid;
        }

        /// <summary>
        /// Sets the long column.
        /// </summary>
        /// <param name="evt">The event.</param>
        /// <param name="columnid">The column id.</param>
        private void SetLongColumn(ProfilerEvent evt, int columnid)
        {
            this.reader.GetBytes(2, 0, this.b8, 0, 8);
            evt.EventObjects[columnid] = ToInt64(this.b8);
            evt.ColumnMask |= 1UL << columnid;
        }

        #endregion
    }
}