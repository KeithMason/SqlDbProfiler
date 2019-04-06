// <copyright file="ProfilerEventTest.cs">Copyright ©</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for ProfilerEvent</summary>
    [PexClass(typeof(ProfilerEvent))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class ProfilerEventTest
    {
        /// <summary>Test stub for get_ApplicationName()</summary>
        [PexMethod]
        public string ApplicationNameGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            string result = target.ApplicationName;
            return result;
            // TODO: add assertions to method ProfilerEventTest.ApplicationNameGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_BigintData1()</summary>
        [PexMethod]
        public long BigintData1Get([PexAssumeUnderTest]ProfilerEvent target)
        {
            long result = target.BigintData1;
            return result;
            // TODO: add assertions to method ProfilerEventTest.BigintData1Get(ProfilerEvent)
        }

        /// <summary>Test stub for get_BigintData2()</summary>
        [PexMethod]
        public long BigintData2Get([PexAssumeUnderTest]ProfilerEvent target)
        {
            long result = target.BigintData2;
            return result;
            // TODO: add assertions to method ProfilerEventTest.BigintData2Get(ProfilerEvent)
        }

        /// <summary>Test stub for get_BinaryData()</summary>
        [PexMethod]
        public byte[] BinaryDataGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            byte[] result = target.BinaryData;
            return result;
            // TODO: add assertions to method ProfilerEventTest.BinaryDataGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_CPU()</summary>
        [PexMethod]
        public int CPUGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            int result = target.CPU;
            return result;
            // TODO: add assertions to method ProfilerEventTest.CPUGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_ClientProcessID()</summary>
        [PexMethod]
        public int ClientProcessIDGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            int result = target.ClientProcessID;
            return result;
            // TODO: add assertions to method ProfilerEventTest.ClientProcessIDGet(ProfilerEvent)
        }

        /// <summary>Test stub for ColumnIsSet(Int32)</summary>
        [PexMethod]
        public bool ColumnIsSet([PexAssumeUnderTest]ProfilerEvent target, int columnId)
        {
            bool result = target.ColumnIsSet(columnId);
            return result;
            // TODO: add assertions to method ProfilerEventTest.ColumnIsSet(ProfilerEvent, Int32)
        }

        /// <summary>Test stub for get_ColumnPermissions()</summary>
        [PexMethod]
        public int ColumnPermissionsGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            int result = target.ColumnPermissions;
            return result;
            // TODO: add assertions to method ProfilerEventTest.ColumnPermissionsGet(ProfilerEvent)
        }

        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public ProfilerEvent Constructor()
        {
            ProfilerEvent target = new ProfilerEvent();
            return target;
            // TODO: add assertions to method ProfilerEventTest.Constructor()
        }

        /// <summary>Test stub for get_DBUserName()</summary>
        [PexMethod]
        public string DBUserNameGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            string result = target.DBUserName;
            return result;
            // TODO: add assertions to method ProfilerEventTest.DBUserNameGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_DatabaseID()</summary>
        [PexMethod]
        public int DatabaseIDGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            int result = target.DatabaseID;
            return result;
            // TODO: add assertions to method ProfilerEventTest.DatabaseIDGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_DatabaseName()</summary>
        [PexMethod]
        public string DatabaseNameGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            string result = target.DatabaseName;
            return result;
            // TODO: add assertions to method ProfilerEventTest.DatabaseNameGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_Duration()</summary>
        [PexMethod]
        public long DurationGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            long result = target.Duration;
            return result;
            // TODO: add assertions to method ProfilerEventTest.DurationGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_EndTime()</summary>
        [PexMethod]
        public DateTime EndTimeGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            DateTime result = target.EndTime;
            return result;
            // TODO: add assertions to method ProfilerEventTest.EndTimeGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_Error()</summary>
        [PexMethod]
        public int ErrorGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            int result = target.Error;
            return result;
            // TODO: add assertions to method ProfilerEventTest.ErrorGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_EventClass()</summary>
        [PexMethod]
        public int EventClassGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            int result = target.EventClass;
            return result;
            // TODO: add assertions to method ProfilerEventTest.EventClassGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_EventSequence()</summary>
        [PexMethod]
        public long EventSequenceGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            long result = target.EventSequence;
            return result;
            // TODO: add assertions to method ProfilerEventTest.EventSequenceGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_EventSubClass()</summary>
        [PexMethod]
        public int EventSubClassGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            int result = target.EventSubClass;
            return result;
            // TODO: add assertions to method ProfilerEventTest.EventSubClassGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_FileName()</summary>
        [PexMethod]
        public string FileNameGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            string result = target.FileName;
            return result;
            // TODO: add assertions to method ProfilerEventTest.FileNameGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_GUID()</summary>
        [PexMethod]
        public Guid GUIDGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            Guid result = target.GUID;
            return result;
            // TODO: add assertions to method ProfilerEventTest.GUIDGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_Handle()</summary>
        [PexMethod]
        public int HandleGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            int result = target.Handle;
            return result;
            // TODO: add assertions to method ProfilerEventTest.HandleGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_HostName()</summary>
        [PexMethod]
        public string HostNameGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            string result = target.HostName;
            return result;
            // TODO: add assertions to method ProfilerEventTest.HostNameGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_IndexID()</summary>
        [PexMethod]
        public int IndexIDGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            int result = target.IndexID;
            return result;
            // TODO: add assertions to method ProfilerEventTest.IndexIDGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_IntegerData2()</summary>
        [PexMethod]
        public int IntegerData2Get([PexAssumeUnderTest]ProfilerEvent target)
        {
            int result = target.IntegerData2;
            return result;
            // TODO: add assertions to method ProfilerEventTest.IntegerData2Get(ProfilerEvent)
        }

        /// <summary>Test stub for get_IntegerData()</summary>
        [PexMethod]
        public int IntegerDataGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            int result = target.IntegerData;
            return result;
            // TODO: add assertions to method ProfilerEventTest.IntegerDataGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_IsSystem()</summary>
        [PexMethod]
        public int IsSystemGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            int result = target.IsSystem;
            return result;
            // TODO: add assertions to method ProfilerEventTest.IsSystemGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_LineNumber()</summary>
        [PexMethod]
        public int LineNumberGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            int result = target.LineNumber;
            return result;
            // TODO: add assertions to method ProfilerEventTest.LineNumberGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_LinkedServerName()</summary>
        [PexMethod]
        public string LinkedServerNameGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            string result = target.LinkedServerName;
            return result;
            // TODO: add assertions to method ProfilerEventTest.LinkedServerNameGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_LoginName()</summary>
        [PexMethod]
        public string LoginNameGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            string result = target.LoginName;
            return result;
            // TODO: add assertions to method ProfilerEventTest.LoginNameGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_LoginSid()</summary>
        [PexMethod]
        public byte[] LoginSidGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            byte[] result = target.LoginSid;
            return result;
            // TODO: add assertions to method ProfilerEventTest.LoginSidGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_MethodName()</summary>
        [PexMethod]
        public string MethodNameGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            string result = target.MethodName;
            return result;
            // TODO: add assertions to method ProfilerEventTest.MethodNameGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_Mode()</summary>
        [PexMethod]
        public int ModeGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            int result = target.Mode;
            return result;
            // TODO: add assertions to method ProfilerEventTest.ModeGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_NTDomainName()</summary>
        [PexMethod]
        public string NTDomainNameGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            string result = target.NTDomainName;
            return result;
            // TODO: add assertions to method ProfilerEventTest.NTDomainNameGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_NTUserName()</summary>
        [PexMethod]
        public string NTUserNameGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            string result = target.NTUserName;
            return result;
            // TODO: add assertions to method ProfilerEventTest.NTUserNameGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_NestLevel()</summary>
        [PexMethod]
        public int NestLevelGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            int result = target.NestLevel;
            return result;
            // TODO: add assertions to method ProfilerEventTest.NestLevelGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_ObjectID2()</summary>
        [PexMethod]
        public long ObjectID2Get([PexAssumeUnderTest]ProfilerEvent target)
        {
            long result = target.ObjectID2;
            return result;
            // TODO: add assertions to method ProfilerEventTest.ObjectID2Get(ProfilerEvent)
        }

        /// <summary>Test stub for get_ObjectID()</summary>
        [PexMethod]
        public int ObjectIDGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            int result = target.ObjectID;
            return result;
            // TODO: add assertions to method ProfilerEventTest.ObjectIDGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_ObjectName()</summary>
        [PexMethod]
        public string ObjectNameGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            string result = target.ObjectName;
            return result;
            // TODO: add assertions to method ProfilerEventTest.ObjectNameGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_ObjectType()</summary>
        [PexMethod]
        public int ObjectTypeGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            int result = target.ObjectType;
            return result;
            // TODO: add assertions to method ProfilerEventTest.ObjectTypeGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_Offset()</summary>
        [PexMethod]
        public int OffsetGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            int result = target.Offset;
            return result;
            // TODO: add assertions to method ProfilerEventTest.OffsetGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_OwnerID()</summary>
        [PexMethod]
        public int OwnerIDGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            int result = target.OwnerID;
            return result;
            // TODO: add assertions to method ProfilerEventTest.OwnerIDGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_OwnerName()</summary>
        [PexMethod]
        public string OwnerNameGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            string result = target.OwnerName;
            return result;
            // TODO: add assertions to method ProfilerEventTest.OwnerNameGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_ParentName()</summary>
        [PexMethod]
        public string ParentNameGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            string result = target.ParentName;
            return result;
            // TODO: add assertions to method ProfilerEventTest.ParentNameGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_Permissions()</summary>
        [PexMethod]
        public long PermissionsGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            long result = target.Permissions;
            return result;
            // TODO: add assertions to method ProfilerEventTest.PermissionsGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_PlanHandle()</summary>
        [PexMethod]
        public byte[] PlanHandleGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            byte[] result = target.PlanHandle;
            return result;
            // TODO: add assertions to method ProfilerEventTest.PlanHandleGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_ProviderName()</summary>
        [PexMethod]
        public string ProviderNameGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            string result = target.ProviderName;
            return result;
            // TODO: add assertions to method ProfilerEventTest.ProviderNameGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_Reads()</summary>
        [PexMethod]
        public long ReadsGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            long result = target.Reads;
            return result;
            // TODO: add assertions to method ProfilerEventTest.ReadsGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_RequestID()</summary>
        [PexMethod]
        public int RequestIDGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            int result = target.RequestID;
            return result;
            // TODO: add assertions to method ProfilerEventTest.RequestIDGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_RoleName()</summary>
        [PexMethod]
        public string RoleNameGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            string result = target.RoleName;
            return result;
            // TODO: add assertions to method ProfilerEventTest.RoleNameGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_RowCounts()</summary>
        [PexMethod]
        public long RowCountsGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            long result = target.RowCounts;
            return result;
            // TODO: add assertions to method ProfilerEventTest.RowCountsGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_SPID()</summary>
        [PexMethod]
        public int SPIDGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            int result = target.SPID;
            return result;
            // TODO: add assertions to method ProfilerEventTest.SPIDGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_ServerName()</summary>
        [PexMethod]
        public string ServerNameGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            string result = target.ServerName;
            return result;
            // TODO: add assertions to method ProfilerEventTest.ServerNameGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_SessionLoginName()</summary>
        [PexMethod]
        public string SessionLoginNameGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            string result = target.SessionLoginName;
            return result;
            // TODO: add assertions to method ProfilerEventTest.SessionLoginNameGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_Severity()</summary>
        [PexMethod]
        public int SeverityGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            int result = target.Severity;
            return result;
            // TODO: add assertions to method ProfilerEventTest.SeverityGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_SourceDatabaseID()</summary>
        [PexMethod]
        public int SourceDatabaseIDGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            int result = target.SourceDatabaseID;
            return result;
            // TODO: add assertions to method ProfilerEventTest.SourceDatabaseIDGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_SqlHandle()</summary>
        [PexMethod]
        public byte[] SqlHandleGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            byte[] result = target.SqlHandle;
            return result;
            // TODO: add assertions to method ProfilerEventTest.SqlHandleGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_StartTime()</summary>
        [PexMethod]
        public DateTime StartTimeGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            DateTime result = target.StartTime;
            return result;
            // TODO: add assertions to method ProfilerEventTest.StartTimeGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_State()</summary>
        [PexMethod]
        public int StateGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            int result = target.State;
            return result;
            // TODO: add assertions to method ProfilerEventTest.StateGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_Success()</summary>
        [PexMethod]
        public int SuccessGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            int result = target.Success;
            return result;
            // TODO: add assertions to method ProfilerEventTest.SuccessGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_TargetLoginName()</summary>
        [PexMethod]
        public string TargetLoginNameGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            string result = target.TargetLoginName;
            return result;
            // TODO: add assertions to method ProfilerEventTest.TargetLoginNameGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_TargetLoginSid()</summary>
        [PexMethod]
        public byte[] TargetLoginSidGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            byte[] result = target.TargetLoginSid;
            return result;
            // TODO: add assertions to method ProfilerEventTest.TargetLoginSidGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_TargetUserName()</summary>
        [PexMethod]
        public string TargetUserNameGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            string result = target.TargetUserName;
            return result;
            // TODO: add assertions to method ProfilerEventTest.TargetUserNameGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_TextData()</summary>
        [PexMethod]
        public string TextDataGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            string result = target.TextData;
            return result;
            // TODO: add assertions to method ProfilerEventTest.TextDataGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_TransactionID()</summary>
        [PexMethod]
        public long TransactionIDGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            long result = target.TransactionID;
            return result;
            // TODO: add assertions to method ProfilerEventTest.TransactionIDGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_Type()</summary>
        [PexMethod]
        public int TypeGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            int result = target.Type;
            return result;
            // TODO: add assertions to method ProfilerEventTest.TypeGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_Writes()</summary>
        [PexMethod]
        public long WritesGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            long result = target.Writes;
            return result;
            // TODO: add assertions to method ProfilerEventTest.WritesGet(ProfilerEvent)
        }

        /// <summary>Test stub for get_XactSequence()</summary>
        [PexMethod]
        public long XactSequenceGet([PexAssumeUnderTest]ProfilerEvent target)
        {
            long result = target.XactSequence;
            return result;
            // TODO: add assertions to method ProfilerEventTest.XactSequenceGet(ProfilerEvent)
        }
    }
}
