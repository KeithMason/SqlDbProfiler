// -----------------------------------------------------------------------
// <copyright file="ProfilerEvent.cs" company="Masonsoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// -----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System;

    /// <summary>
    /// Profiler Event
    /// </summary>
    public class ProfilerEvent
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfilerEvent"/> class.
        /// </summary>
        public ProfilerEvent()
        {
            this.EventObjects = new object[65];
        }

        #endregion

        #region public properties

        /// <summary>
        /// Gets the text data.
        /// </summary>
        /// <value>
        /// The text data.
        /// </value>
        public string TextData
        {
            get { return this.GetString(ProfilerEventColumns.TextData); }
        }

        /// <summary>
        /// Gets the binary data.
        /// </summary>
        /// <value>
        /// The binary data.
        /// </value>
        public byte[] BinaryData
        {
            get { return this.GetByte(ProfilerEventColumns.BinaryData); }
        }

        /// <summary>
        /// Gets the database ID.
        /// </summary>
        /// <value>
        /// The database ID.
        /// </value>
        public int DatabaseID
        {
            get { return this.GetInt(ProfilerEventColumns.DatabaseID); }
        }

        /// <summary>
        /// Gets the transaction ID.
        /// </summary>
        /// <value>
        /// The transaction ID.
        /// </value>
        public long TransactionID
        {
            get { return this.GetLong(ProfilerEventColumns.TransactionID); }
        }

        /// <summary>
        /// Gets the line number.
        /// </summary>
        /// <value>
        /// The line number.
        /// </value>
        public int LineNumber
        {
            get { return this.GetInt(ProfilerEventColumns.LineNumber); }
        }

        /// <summary>
        /// Gets the name of the NT user.
        /// </summary>
        /// <value>
        /// The name of the NT user.
        /// </value>
        public string NTUserName
        {
            get { return this.GetString(ProfilerEventColumns.NTUserName); }
        }

        /// <summary>
        /// Gets the name of the NT domain.
        /// </summary>
        /// <value>
        /// The name of the NT domain.
        /// </value>
        public string NTDomainName
        {
            get { return this.GetString(ProfilerEventColumns.NTDomainName); }
        }

        /// <summary>
        /// Gets the name of the host.
        /// </summary>
        /// <value>
        /// The name of the host.
        /// </value>
        public string HostName
        {
            get { return this.GetString(ProfilerEventColumns.HostName); }
        }

        /// <summary>
        /// Gets the client process ID.
        /// </summary>
        /// <value>
        /// The client process ID.
        /// </value>
        public int ClientProcessID
        {
            get { return this.GetInt(ProfilerEventColumns.ClientProcessID); }
        }

        /// <summary>
        /// Gets the name of the application.
        /// </summary>
        /// <value>
        /// The name of the application.
        /// </value>
        public string ApplicationName
        {
            get { return this.GetString(ProfilerEventColumns.ApplicationName); }
        }

        /// <summary>
        /// Gets the name of the login.
        /// </summary>
        /// <value>
        /// The name of the login.
        /// </value>
        public string LoginName
        {
            get { return this.GetString(ProfilerEventColumns.LoginName); }
        }

        /// <summary>
        /// Gets the SPID.
        /// </summary>
        /// <value>
        /// The SPID.
        /// </value>
        public int SPID
        {
            get { return this.GetInt(ProfilerEventColumns.SPID); }
        }

        /// <summary>
        /// Gets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        public long Duration
        {
            get { return this.GetLong(ProfilerEventColumns.Duration); }
        }

        /// <summary>
        /// Gets the start time.
        /// </summary>
        /// <value>
        /// The start time.
        /// </value>
        public DateTime StartTime
        {
            get { return this.GetDateTime(ProfilerEventColumns.StartTime); }
        }

        /// <summary>
        /// Gets the end time.
        /// </summary>
        /// <value>
        /// The end time.
        /// </value>
        public DateTime EndTime
        {
            get { return this.GetDateTime(ProfilerEventColumns.EndTime); }
        }

        /// <summary>
        /// Gets the reads.
        /// </summary>
        /// <value>
        /// The reads.
        /// </value>
        public long Reads
        {
            get { return this.GetLong(ProfilerEventColumns.Reads); }
        }

        /// <summary>
        /// Gets the writes.
        /// </summary>
        /// <value>
        /// The writes.
        /// </value>
        public long Writes
        {
            get { return this.GetLong(ProfilerEventColumns.Writes); }
        }

        /// <summary>
        /// Gets the CPU.
        /// </summary>
        /// <value>
        /// The CPU.
        /// </value>
        public int CPU
        {
            get { return this.GetInt(ProfilerEventColumns.CPU); }
        }

        /// <summary>
        /// Gets the permissions.
        /// </summary>
        /// <value>
        /// The permissions.
        /// </value>
        public long Permissions
        {
            get { return this.GetLong(ProfilerEventColumns.Permissions); }
        }

        /// <summary>
        /// Gets the severity.
        /// </summary>
        /// <value>
        /// The severity.
        /// </value>
        public int Severity
        {
            get { return this.GetInt(ProfilerEventColumns.Severity); }
        }

        /// <summary>
        /// Gets the event sub class.
        /// </summary>
        /// <value>
        /// The event sub class.
        /// </value>
        public int EventSubClass
        {
            get { return this.GetInt(ProfilerEventColumns.EventSubClass); }
        }

        /// <summary>
        /// Gets the object ID.
        /// </summary>
        /// <value>
        /// The object ID.
        /// </value>
        public int ObjectID
        {
            get { return this.GetInt(ProfilerEventColumns.ObjectID); }
        }

        /// <summary>
        /// Gets the success.
        /// </summary>
        /// <value>
        /// The success.
        /// </value>
        public int Success
        {
            get { return this.GetInt(ProfilerEventColumns.Success); }
        }

        /// <summary>
        /// Gets the index ID.
        /// </summary>
        /// <value>
        /// The index ID.
        /// </value>
        public int IndexID
        {
            get { return this.GetInt(ProfilerEventColumns.IndexID); }
        }

        /// <summary>
        /// Gets the integer data.
        /// </summary>
        /// <value>
        /// The integer data.
        /// </value>
        public int IntegerData
        {
            get { return this.GetInt(ProfilerEventColumns.IntegerData); }
        }

        /// <summary>
        /// Gets the name of the server.
        /// </summary>
        /// <value>
        /// The name of the server.
        /// </value>
        public string ServerName
        {
            get { return this.GetString(ProfilerEventColumns.ServerName); }
        }

        /// <summary>
        /// Gets the event class.
        /// </summary>
        /// <value>
        /// The event class.
        /// </value>
        public int EventClass
        {
            get { return this.GetInt(ProfilerEventColumns.EventClass); }
        }

        /// <summary>
        /// Gets the type of the object.
        /// </summary>
        /// <value>
        /// The type of the object.
        /// </value>
        public int ObjectType
        {
            get { return this.GetInt(ProfilerEventColumns.ObjectType); }
        }

        /// <summary>
        /// Gets the nest level.
        /// </summary>
        /// <value>
        /// The nest level.
        /// </value>
        public int NestLevel
        {
            get { return this.GetInt(ProfilerEventColumns.NestLevel); }
        }

        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public int State
        {
            get { return this.GetInt(ProfilerEventColumns.State); }
        }

        /// <summary>
        /// Gets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        public int Error
        {
            get { return this.GetInt(ProfilerEventColumns.Error); }
        }

        /// <summary>
        /// Gets the mode.
        /// </summary>
        /// <value>
        /// The mode.
        /// </value>
        public int Mode
        {
            get { return this.GetInt(ProfilerEventColumns.Mode); }
        }

        /// <summary>
        /// Gets the handle.
        /// </summary>
        /// <value>
        /// The handle.
        /// </value>
        public int Handle
        {
            get { return this.GetInt(ProfilerEventColumns.Handle); }
        }

        /// <summary>
        /// Gets the name of the object.
        /// </summary>
        /// <value>
        /// The name of the object.
        /// </value>
        public string ObjectName
        {
            get { return this.GetString(ProfilerEventColumns.ObjectName); }
        }

        /// <summary>
        /// Gets the name of the database.
        /// </summary>
        /// <value>
        /// The name of the database.
        /// </value>
        public string DatabaseName
        {
            get { return this.GetString(ProfilerEventColumns.DatabaseName); }
        }

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public string FileName
        {
            get { return this.GetString(ProfilerEventColumns.FileName); }
        }

        /// <summary>
        /// Gets the name of the owner.
        /// </summary>
        /// <value>
        /// The name of the owner.
        /// </value>
        public string OwnerName
        {
            get { return this.GetString(ProfilerEventColumns.OwnerName); }
        }

        /// <summary>
        /// Gets the name of the role.
        /// </summary>
        /// <value>
        /// The name of the role.
        /// </value>
        public string RoleName
        {
            get { return this.GetString(ProfilerEventColumns.RoleName); }
        }

        /// <summary>
        /// Gets the name of the target user.
        /// </summary>
        /// <value>
        /// The name of the target user.
        /// </value>
        public string TargetUserName
        {
            get { return this.GetString(ProfilerEventColumns.TargetUserName); }
        }

        /// <summary>
        /// Gets the name of the DB user.
        /// </summary>
        /// <value>
        /// The name of the DB user.
        /// </value>
        public string DBUserName
        {
            get { return this.GetString(ProfilerEventColumns.DBUserName); }
        }

        /// <summary>
        /// Gets the login sid.
        /// </summary>
        /// <value>
        /// The login sid.
        /// </value>
        public byte[] LoginSid
        {
            get { return this.GetByte(ProfilerEventColumns.LoginSid); }
        }

        /// <summary>
        /// Gets the name of the target login.
        /// </summary>
        /// <value>
        /// The name of the target login.
        /// </value>
        public string TargetLoginName
        {
            get { return this.GetString(ProfilerEventColumns.TargetLoginName); }
        }

        /// <summary>
        /// Gets the target login sid.
        /// </summary>
        /// <value>
        /// The target login sid.
        /// </value>
        public byte[] TargetLoginSid
        {
            get { return this.GetByte(ProfilerEventColumns.TargetLoginSid); }
        }

        /// <summary>
        /// Gets the column permissions.
        /// </summary>
        /// <value>
        /// The column permissions.
        /// </value>
        public int ColumnPermissions
        {
            get { return this.GetInt(ProfilerEventColumns.ColumnPermissions); }
        }

        /// <summary>
        /// Gets the name of the linked server.
        /// </summary>
        /// <value>
        /// The name of the linked server.
        /// </value>
        public string LinkedServerName
        {
            get { return this.GetString(ProfilerEventColumns.LinkedServerName); }
        }

        /// <summary>
        /// Gets the name of the provider.
        /// </summary>
        /// <value>
        /// The name of the provider.
        /// </value>
        public string ProviderName
        {
            get { return this.GetString(ProfilerEventColumns.ProviderName); }
        }

        /// <summary>
        /// Gets the name of the method.
        /// </summary>
        /// <value>
        /// The name of the method.
        /// </value>
        public string MethodName
        {
            get { return this.GetString(ProfilerEventColumns.MethodName); }
        }

        /// <summary>
        /// Gets the row counts.
        /// </summary>
        /// <value>
        /// The row counts.
        /// </value>
        public long RowCounts
        {
            get { return this.GetLong(ProfilerEventColumns.RowCounts); }
        }

        /// <summary>
        /// Gets the request ID.
        /// </summary>
        /// <value>
        /// The request ID.
        /// </value>
        public int RequestID
        {
            get { return this.GetInt(ProfilerEventColumns.RequestID); }
        }

        /// <summary>
        /// Gets the sequence.
        /// </summary>
        /// <value>
        /// The sequence.
        /// </value>
        public long XactSequence
        {
            get { return this.GetLong(ProfilerEventColumns.XactSequence); }
        }

        /// <summary>
        /// Gets the event sequence.
        /// </summary>
        /// <value>
        /// The event sequence.
        /// </value>
        public long EventSequence
        {
            get { return this.GetLong(ProfilerEventColumns.EventSequence); }
        }

        /// <summary>
        /// Gets the big integer data 1.
        /// </summary>
        /// <value>
        /// The big integer data 1.
        /// </value>
        public long BigintData1
        {
            get { return this.GetLong(ProfilerEventColumns.BigintData1); }
        }

        /// <summary>
        /// Gets the big integer data 2.
        /// </summary>
        /// <value>
        /// The big integer data 2.
        /// </value>
        public long BigintData2
        {
            get { return this.GetLong(ProfilerEventColumns.BigintData2); }
        }

        /// <summary>
        /// Gets the GUID.
        /// </summary>
        /// <value>
        /// The GUID.
        /// </value>
        public Guid GUID
        {
            get { return this.GetGuid(ProfilerEventColumns.GUID); }
        }

        /// <summary>
        /// Gets the integer data2.
        /// </summary>
        /// <value>
        /// The integer data2.
        /// </value>
        public int IntegerData2
        {
            get { return this.GetInt(ProfilerEventColumns.IntegerData2); }
        }

        /// <summary>
        /// Gets the object I d2.
        /// </summary>
        /// <value>
        /// The object I d2.
        /// </value>
        public long ObjectID2
        {
            get { return this.GetLong(ProfilerEventColumns.ObjectID2); }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public int Type
        {
            get { return this.GetInt(ProfilerEventColumns.Type); }
        }

        /// <summary>
        /// Gets the owner ID.
        /// </summary>
        /// <value>
        /// The owner ID.
        /// </value>
        public int OwnerID
        {
            get { return this.GetInt(ProfilerEventColumns.OwnerID); }
        }

        /// <summary>
        /// Gets the name of the parent.
        /// </summary>
        /// <value>
        /// The name of the parent.
        /// </value>
        public string ParentName
        {
            get { return this.GetString(ProfilerEventColumns.ParentName); }
        }

        /// <summary>
        /// Gets the is system.
        /// </summary>
        /// <value>
        /// The is system.
        /// </value>
        public int IsSystem
        {
            get { return this.GetInt(ProfilerEventColumns.IsSystem); }
        }

        /// <summary>
        /// Gets the offset.
        /// </summary>
        /// <value>
        /// The offset.
        /// </value>
        public int Offset
        {
            get { return this.GetInt(ProfilerEventColumns.Offset); }
        }

        /// <summary>
        /// Gets the source database ID.
        /// </summary>
        /// <value>
        /// The source database ID.
        /// </value>
        public int SourceDatabaseID
        {
            get { return this.GetInt(ProfilerEventColumns.SourceDatabaseID); }
        }

        /// <summary>
        /// Gets the SQL handle.
        /// </summary>
        /// <value>
        /// The SQL handle.
        /// </value>
        public byte[] SqlHandle
        {
            get { return this.GetByte(ProfilerEventColumns.SqlHandle); }
        }

        /// <summary>
        /// Gets the name of the session login.
        /// </summary>
        /// <value>
        /// The name of the session login.
        /// </value>
        public string SessionLoginName
        {
            get { return this.GetString(ProfilerEventColumns.SessionLoginName); }
        }

        /// <summary>
        /// Gets the plan handle.
        /// </summary>
        /// <value>
        /// The plan handle.
        /// </value>
        public byte[] PlanHandle
        {
            get { return this.GetByte(ProfilerEventColumns.PlanHandle); }
        }

        #endregion

        #region internal properties

        /// <summary>
        /// Gets the events.
        /// </summary>
        /// <value>
        /// The events.
        /// </value>
        internal object[] EventObjects { get; private set; }

        /// <summary>
        /// Gets or sets the column mask.
        /// </summary>
        /// <value>
        /// The column mask.
        /// </value>
        internal ulong ColumnMask { get; set; }

        #endregion

        #region public methods

        /// <summary>
        /// Columns the is set.
        /// </summary>
        /// <param name="columnId">The column id.</param>
        /// <returns>true or false</returns>
        public bool ColumnIsSet(int columnId)
        {
            return (this.ColumnMask & (1UL << columnId)) != 0;
        }

        #endregion

        #region private methods

        /// <summary>
        /// Gets the integer.
        /// </summary>
        /// <param name="idx">The index.</param>
        /// <returns>an integer</returns>
        private int GetInt(int idx)
        {
            if (!this.ColumnIsSet(idx))
            {
                return 0;
            }

            return this.EventObjects[idx] == null ? 0 : (int)this.EventObjects[idx];
        }

        /// <summary>
        /// Gets the long.
        /// </summary>
        /// <param name="idx">The index.</param>
        /// <returns>Long Integer</returns>
        private long GetLong(int idx)
        {
            if (!this.ColumnIsSet(idx))
            {
                return 0;
            }

            return this.EventObjects[idx] == null ? 0 : (long)this.EventObjects[idx];
        }

        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <param name="idx">The index.</param>
        /// <returns>a string</returns>
        private string GetString(int idx)
        {
            if (!this.ColumnIsSet(idx) && idx != 35)
            {
                return string.Empty;
            }

            return this.EventObjects[idx] == null ? string.Empty : (string)this.EventObjects[idx];
        }

        /// <summary>
        /// Gets the byte.
        /// </summary>
        /// <param name="idx">The index.</param>
        /// <returns>a byte</returns>
        private byte[] GetByte(int idx)
        {
            return this.ColumnIsSet(idx) ? (byte[])this.EventObjects[idx] : new byte[1];
        }

        /// <summary>
        /// Gets the date time.
        /// </summary>
        /// <param name="idx">The index.</param>
        /// <returns>a date time</returns>
        private DateTime GetDateTime(int idx)
        {
            return this.ColumnIsSet(idx) ? (DateTime)this.EventObjects[idx] : new DateTime(0);
        }

        /// <summary>
        /// Gets the GUID.
        /// </summary>
        /// <param name="idx">The index.</param>
        /// <returns>a GUID</returns>
        private Guid GetGuid(int idx)
        {
            return this.ColumnIsSet(idx) ? (Guid)this.EventObjects[idx] : Guid.Empty;
        }

        #endregion
    }
}