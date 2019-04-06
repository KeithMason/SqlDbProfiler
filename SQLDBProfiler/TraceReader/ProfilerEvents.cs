// -----------------------------------------------------------------------
// <copyright file="ProfilerEvents.cs" company="Masonsoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// -----------------------------------------------------------------------

namespace SQLDBProfiler
{
    /// <summary>
    /// Profiler Events
    /// </summary>
    public static class ProfilerEvents
    {
        /// <summary>
        /// The names string array
        /// </summary>
        public static readonly string[] Names = new string[202] 
        {
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            "RPC:Completed",
            "RPC:Starting",
            "SQL:BatchCompleted",
            "SQL:BatchStarting",
            "Audit Login",
            "Audit Logout",
            "Attention",
            "ExistingConnection",
            "Audit Server Starts And Stops",
            "DTCTransaction",
            "Audit Login Failed",
            "EventLog",
            "ErrorLog",
            "Lock:Released",
            "Lock:Acquired",
            "Lock:Deadlock",
            "Lock:Cancel",
            "Lock:Timeout",
            "Degree of Parallelism (7.0 Insert)",
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            "Exception",
            "SP:CacheMiss",
            "SP:CacheInsert",
            "SP:CacheRemove",
            "SP:Recompile",
            "SP:CacheHit",
            "Deprecated",
            "SQL:StmtStarting",
            "SQL:StmtCompleted",
            "SP:Starting",
            "SP:Completed",
            "SP:StmtStarting",
            "SP:StmtCompleted",
            "Object:Created",
            "Object:Deleted",
            string.Empty,
            string.Empty,
            "SQLTransaction",
            "Scan:Started",
            "Scan:Stopped",
            "CursorOpen",
            "TransactionLog",
            "Hash Warning",
            string.Empty,
            string.Empty,
            "Auto Stats",
            "Lock:Deadlock Chain",
            "Lock:Escalation",
            "OLEDB Errors",
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            "Execution Warnings",
            "Showplan Text (Unencoded)",
            "Sort Warnings",
            "CursorPrepare",
            "Prepare SQL",
            "Exec Prepared SQL",
            "Unprepare SQL",
            "CursorExecute",
            "CursorRecompile",
            "CursorImplicitConversion",
            "CursorUnprepare",
            "CursorClose",
            "Missing Column Statistics",
            "Missing Join Predicate",
            "Server Memory Change",
            "UserConfigurable:0",
            "UserConfigurable:1",
            "UserConfigurable:2",
            "UserConfigurable:3",
            "UserConfigurable:4",
            "UserConfigurable:5",
            "UserConfigurable:6",
            "UserConfigurable:7",
            "UserConfigurable:8",
            "UserConfigurable:9",
            "Data File Auto Grow",
            "Log File Auto Grow",
            "Data File Auto Shrink",
            "Log File Auto Shrink",
            "Showplan Text",
            "Showplan All",
            "Showplan Statistics Profile",
            string.Empty,
            "RPC Output Parameter",
            string.Empty,
            "Audit Database Scope GDR Event",
            "Audit Schema Object GDR Event",
            "Audit Addlogin Event",
            "Audit Login GDR Event",
            "Audit Login Change Property Event",
            "Audit Login Change Password Event",
            "Audit Add Login to Server Role Event",
            "Audit Add DB User Event",
            "Audit Add Member to DB Role Event",
            "Audit Add Role Event",
            "Audit App Role Change Password Event",
            "Audit Statement Permission Event",
            "Audit Schema Object Access Event",
            "Audit Backup/Restore Event",
            "Audit DBCC Event",
            "Audit Change Audit Event",
            "Audit Object Derived Permission Event",
            "OLEDB Call Event",
            "OLEDB QueryInterface Event",
            "OLEDB DataRead Event",
            "Showplan XML",
            "SQL:FullTextQuery",
            "Broker:Conversation",
            "Deprecation Announcement",
            "Deprecation Final Support",
            "Exchange Spill Event",
            "Audit Database Management Event",
            "Audit Database Object Management Event",
            "Audit Database Principal Management Event",
            "Audit Schema Object Management Event",
            "Audit Server Principal Impersonation Event",
            "Audit Database Principal Impersonation Event",
            "Audit Server Object Take Ownership Event",
            "Audit Database Object Take Ownership Event",
            "Broker:Conversation Group",
            "Blocked process report",
            "Broker:Connection",
            "Broker:Forwarded Message Sent",
            "Broker:Forwarded Message Dropped",
            "Broker:Message Classify",
            "Broker:Transmission",
            "Broker:Queue Disabled",
            "Broker:Mirrored Route State Changed",
            string.Empty,
            "Showplan XML Statistics Profile",
            string.Empty,
            "Deadlock graph",
            "Broker:Remote Message Acknowledgement",
            "Trace File Close",
            string.Empty,
            "Audit Change Database Owner",
            "Audit Schema Object Take Ownership Event",
            string.Empty,
            "FT:Crawl Started",
            "FT:Crawl Stopped",
            "FT:Crawl Aborted",
            "Audit Broker Conversation",
            "Audit Broker Login",
            "Broker:Message Undeliverable",
            "Broker:Corrupted Message",
            "User Error Message",
            "Broker:Activation",
            "Object:Altered",
            "Performance statistics",
            "SQL:StmtRecompile",
            "Database Mirroring State Change",
            "Showplan XML For Query Compile",
            "Showplan All For Query Compile",
            "Audit Server Scope GDR Event",
            "Audit Server Object GDR Event",
            "Audit Database Object GDR Event",
            "Audit Server Operation Event",
            string.Empty,
            "Audit Server Alter Trace Event",
            "Audit Server Object Management Event",
            "Audit Server Principal Management Event",
            "Audit Database Operation Event",
            string.Empty,
            "Audit Database Object Access Event",
            "TM: Begin Tran starting",
            "TM: Begin Tran completed",
            "TM: Promote Tran starting",
            "TM: Promote Tran completed",
            "TM: Commit Tran starting",
            "TM: Commit Tran completed",
            "TM: Rollback Tran starting",
            "TM: Rollback Tran completed",
            "Lock:Timeout (timeout > 0)",
            "Progress Report: Online Index Operation",
            "TM: Save Tran starting",
            "TM: Save Tran completed",
            "Background Job Error",
            "OLEDB Provider Information",
            "Mount Tape",
            "Assembly Load",
            string.Empty,
            "XQuery Static Type",
            "QN: Subscription",
            "QN: Parameter table",
            "QN: Template"
        };

        /// <summary>
        /// Cursor types
        /// </summary>
        public static class Cursors
        {
            /// <summary>
            /// The cursor open
            /// </summary>
            public const int CursorOpen = 53;

            /// <summary>
            /// The cursor prepare
            /// </summary>
            public const int CursorPrepare = 70;

            /// <summary>
            /// The cursor execute
            /// </summary>
            public const int CursorExecute = 74;

            /// <summary>
            /// The cursor recompile
            /// </summary>
            public const int CursorRecompile = 75;

            /// <summary>
            /// The cursor implicit conversion
            /// </summary>
            public const int CursorImplicitConversion = 76;

            /// <summary>
            /// The cursor unprepared
            /// </summary>
            public const int CursorUnprepare = 77;

            /// <summary>
            /// The cursor close
            /// </summary>
            public const int CursorClose = 78;
        }

        /// <summary>
        /// Database types
        /// </summary>
        public static class Database
        {
            /// <summary>
            /// The data file auto grow
            /// </summary>
            public const int DataFileAutoGrow = 92;

            /// <summary>
            /// The log file auto grow
            /// </summary>
            public const int LogFileAutoGrow = 93;

            /// <summary>
            /// The data file auto shrink
            /// </summary>
            public const int DataFileAutoShrink = 94;

            /// <summary>
            /// The log file auto shrink
            /// </summary>
            public const int LogFileAutoShrink = 95;

            /// <summary>
            /// The database mirroring state change
            /// </summary>
            public const int DatabaseMirroringStateChange = 167;
        }

        /// <summary>
        /// Errors and Warnings
        /// </summary>
        public static class ErrorsAndWarnings
        {
            /// <summary>
            /// The attention error/warning
            /// </summary>
            public const int Attention = 16;

            /// <summary>
            /// The event log error/warning
            /// </summary>
            public const int EventLog = 21;

            /// <summary>
            /// The error log error/warning
            /// </summary>
            public const int ErrorLog = 22;

            /// <summary>
            /// The exception error/warning
            /// </summary>
            public const int Exception = 33;

            /// <summary>
            /// The hash warning error/warning
            /// </summary>
            public const int HashWarning = 55;

            /// <summary>
            /// The execution warnings error/warning
            /// </summary>
            public const int ExecutionWarnings = 67;

            /// <summary>
            /// The sort warnings error/warning
            /// </summary>
            public const int SortWarnings = 69;

            /// <summary>
            /// The missing column statistics error/warning
            /// </summary>
            public const int MissingColumnStatistics = 79;

            /// <summary>
            /// The missing join predicate error/warning
            /// </summary>
            public const int MissingJoinPredicate = 80;

            /// <summary>
            /// The exchange spill event error/warning
            /// </summary>
            public const int ExchangeSpillEvent = 127;

            /// <summary>
            /// The blocked process report error/warning
            /// </summary>
            public const int Blockedprocessreport = 137;

            /// <summary>
            /// The user error message
            /// </summary>
            public const int UserErrorMessage = 162;

            /// <summary>
            /// The background job error
            /// </summary>
            public const int BackgroundJobError = 193;
        }

        /// <summary>
        /// Lock types
        /// </summary>
        public static class Locks
        {
            /// <summary>
            /// The lock released
            /// </summary>
            public const int LockReleased = 23;

            /// <summary>
            /// The lock acquired
            /// </summary>
            public const int LockAcquired = 24;

            /// <summary>
            /// The lock deadlock
            /// </summary>
            public const int LockDeadlock = 25;

            /// <summary>
            /// The lock cancel
            /// </summary>
            public const int LockCancel = 26;

            /// <summary>
            /// The lock timeout
            /// </summary>
            public const int LockTimeout = 27;

            /// <summary>
            /// The lock deadlock chain
            /// </summary>
            public const int LockDeadlockChain = 59;

            /// <summary>
            /// The lock escalation
            /// </summary>
            public const int LockEscalation = 60;

            /// <summary>
            /// The deadlock graph
            /// </summary>
            public const int DeadlockGraph = 148;

            /// <summary>
            /// The lock timeout
            /// </summary>
            public const int LockTimeout100 = 189;
        }

        /// <summary>
        /// Object types
        /// </summary>
        public static class Objects
        {
            /// <summary>
            /// The object created
            /// </summary>
            public const int ObjectCreated = 46;

            /// <summary>
            /// The object deleted
            /// </summary>
            public const int ObjectDeleted = 47;

            /// <summary>
            /// The object altered
            /// </summary>
            public const int ObjectAltered = 164;
        }

        /// <summary>
        /// Performance types
        /// </summary>
        public static class Performance
        {
            /// <summary>
            /// The degree of parallel insert
            /// </summary>
            public const int DegreeofParallelism70Insert = 28;

            /// <summary>
            /// The auto stats
            /// </summary>
            public const int AutoStats = 58;

            /// <summary>
            /// The show plan text unencoded
            /// </summary>
            public const int ShowplanTextUnencoded = 68;

            /// <summary>
            /// The show plan text
            /// </summary>
            public const int ShowplanText = 96;

            /// <summary>
            /// The show plan all
            /// </summary>
            public const int ShowplanAll = 97;

            /// <summary>
            /// The show plan statistics profile
            /// </summary>
            public const int ShowplanStatisticsProfile = 98;

            /// <summary>
            /// The show plan XML
            /// </summary>
            public const int ShowplanXML = 122;

            /// <summary>
            /// The SQL full text query
            /// </summary>
            public const int SQLFullTextQuery = 123;

            /// <summary>
            /// The show plan XML statistics profile
            /// </summary>
            public const int ShowplanXMLStatisticsProfile = 146;

            /// <summary>
            /// The performance statistics
            /// </summary>
            public const int PerformanceStatistics = 165;

            /// <summary>
            /// The show plan XML for query compile
            /// </summary>
            public const int ShowplanXMLForQueryCompile = 168;

            /// <summary>
            /// The show plan all for query compile
            /// </summary>
            public const int ShowplanAllForQueryCompile = 169;
        }

        /// <summary>
        /// Scan types
        /// </summary>
        public static class Scans
        {
            /// <summary>
            /// The scan started
            /// </summary>
            public const int ScanStarted = 51;

            /// <summary>
            /// The scan stopped
            /// </summary>
            public const int ScanStopped = 52;
        }

        /// <summary>
        /// Security Audit Class
        /// </summary>
        public static class SecurityAudit
        {
            /// <summary>
            /// The audit login
            /// </summary>
            public const int AuditLogin = 14;

            /// <summary>
            /// The audit logout
            /// </summary>
            public const int AuditLogout = 15;

            /// <summary>
            /// The audit server starts and stops
            /// </summary>
            public const int AuditServerStartsAndStops = 18;

            /// <summary>
            /// The audit login failed
            /// </summary>
            public const int AuditLoginFailed = 20;

            /// <summary>
            /// The audit database scope GDR event
            /// </summary>
            public const int AuditDatabaseScopeGDREvent = 102;

            /// <summary>
            /// The audit schema object GDR event
            /// </summary>
            public const int AuditSchemaObjectGDREvent = 103;

            /// <summary>
            /// The audit add login event
            /// </summary>
            public const int AuditAddloginEvent = 104;

            /// <summary>
            /// The audit login GDR event
            /// </summary>
            public const int AuditLoginGDREvent = 105;

            /// <summary>
            /// The audit login change property event
            /// </summary>
            public const int AuditLoginChangePropertyEvent = 106;

            /// <summary>
            /// The audit login change password event
            /// </summary>
            public const int AuditLoginChangePasswordEvent = 107;

            /// <summary>
            /// The audit add log into server role event
            /// </summary>
            public const int AuditAddLogintoServerRoleEvent = 108;

            /// <summary>
            /// The audit add DB user event
            /// </summary>
            public const int AuditAddDBUserEvent = 109;

            /// <summary>
            /// The audit add member to DB role event
            /// </summary>
            public const int AuditAddMembertoDBRoleEvent = 110;

            /// <summary>
            /// The audit add role event
            /// </summary>
            public const int AuditAddRoleEvent = 111;

            /// <summary>
            /// The audit app role change password event
            /// </summary>
            public const int AuditAppRoleChangePasswordEvent = 112;

            /// <summary>
            /// The audit statement permission event
            /// </summary>
            public const int AuditStatementPermissionEvent = 113;

            /// <summary>
            /// The audit schema object access event
            /// </summary>
            public const int AuditSchemaObjectAccessEvent = 114;

            /// <summary>
            /// The audit backup restore event
            /// </summary>
            public const int AuditBackupRestoreEvent = 115;

            /// <summary>
            /// The audit DBCC event
            /// </summary>
            public const int AuditDBCCEvent = 116;

            /// <summary>
            /// The audit change audit event
            /// </summary>
            public const int AuditChangeAuditEvent = 117;

            /// <summary>
            /// The audit object derived permission event
            /// </summary>
            public const int AuditObjectDerivedPermissionEvent = 118;

            /// <summary>
            /// The audit database management event
            /// </summary>
            public const int AuditDatabaseManagementEvent = 128;

            /// <summary>
            /// The audit database object management event
            /// </summary>
            public const int AuditDatabaseObjectManagementEvent = 129;

            /// <summary>
            /// The audit database principal management event
            /// </summary>
            public const int AuditDatabasePrincipalManagementEvent = 130;

            /// <summary>
            /// The audit schema object management event
            /// </summary>
            public const int AuditSchemaObjectManagementEvent = 131;

            /// <summary>
            /// The audit server principal impersonation event
            /// </summary>
            public const int AuditServerPrincipalImpersonationEvent = 132;

            /// <summary>
            /// The audit database principal impersonation event
            /// </summary>
            public const int AuditDatabasePrincipalImpersonationEvent = 133;

            /// <summary>
            /// The audit server object take ownership event
            /// </summary>
            public const int AuditServerObjectTakeOwnershipEvent = 134;

            /// <summary>
            /// The audit database object take ownership event
            /// </summary>
            public const int AuditDatabaseObjectTakeOwnershipEvent = 135;

            /// <summary>
            /// The audit change database owner
            /// </summary>
            public const int AuditChangeDatabaseOwner = 152;

            /// <summary>
            /// The audit schema object take ownership event
            /// </summary>
            public const int AuditSchemaObjectTakeOwnershipEvent = 153;

            /// <summary>
            /// The audit broker conversation
            /// </summary>
            public const int AuditBrokerConversation = 158;

            /// <summary>
            /// The audit broker login
            /// </summary>
            public const int AuditBrokerLogin = 159;

            /// <summary>
            /// The audit server scope GDR event
            /// </summary>
            public const int AuditServerScopeGDREvent = 170;

            /// <summary>
            /// The audit server object GDR event
            /// </summary>
            public const int AuditServerObjectGDREvent = 171;

            /// <summary>
            /// The audit database object GDR event
            /// </summary>
            public const int AuditDatabaseObjectGDREvent = 172;

            /// <summary>
            /// The audit server operation event
            /// </summary>
            public const int AuditServerOperationEvent = 173;

            /// <summary>
            /// The audit server alter trace event
            /// </summary>
            public const int AuditServerAlterTraceEvent = 175;

            /// <summary>
            /// The audit server object management event
            /// </summary>
            public const int AuditServerObjectManagementEvent = 176;

            /// <summary>
            /// The audit server principal management event
            /// </summary>
            public const int AuditServerPrincipalManagementEvent = 177;

            /// <summary>
            /// The audit database operation event
            /// </summary>
            public const int AuditDatabaseOperationEvent = 178;

            /// <summary>
            /// The audit database object access event
            /// </summary>
            public const int AuditDatabaseObjectAccessEvent = 180;
        }

        /// <summary>
        /// Server Class
        /// </summary>
        public static class Server
        {
            /// <summary>
            /// The server memory change
            /// </summary>
            public const int ServerMemoryChange = 81;

            /// <summary>
            /// The trace file close
            /// </summary>
            public const int TraceFileClose = 150;

            /// <summary>
            /// The mount tape
            /// </summary>
            public const int MountTape = 195;
        }

        /// <summary>
        /// Sessions Class
        /// </summary>
        public static class Sessions
        {
            /// <summary>
            /// The existing connection
            /// </summary>
            public const int ExistingConnection = 17;
        }

        /// <summary>
        /// Stored Procedures Class
        /// </summary>
        public static class StoredProcedures
        {
            /// <summary>
            /// The RPC completed
            /// </summary>
            public const int RPCCompleted = 10;

            /// <summary>
            /// The RPC starting
            /// </summary>
            public const int RPCStarting = 11;

            /// <summary>
            /// The SP cache miss
            /// </summary>
            public const int SPCacheMiss = 34;

            /// <summary>
            /// The SP cache insert
            /// </summary>
            public const int SPCacheInsert = 35;

            /// <summary>
            /// The SP cache remove
            /// </summary>
            public const int SPCacheRemove = 36;

            /// <summary>
            /// The SP recompile
            /// </summary>
            public const int SPRecompile = 37;

            /// <summary>
            /// The SP cache hit
            /// </summary>
            public const int SPCacheHit = 38;

            /// <summary>
            /// The deprecated
            /// </summary>
            public const int Deprecated = 39;

            /// <summary>
            /// The SP starting
            /// </summary>
            public const int SPStarting = 42;

            /// <summary>
            /// The SP completed
            /// </summary>
            public const int SPCompleted = 43;

            /// <summary>
            /// The SP STMT starting
            /// </summary>
            public const int SPStmtStarting = 44;

            /// <summary>
            /// The SP STMT completed
            /// </summary>
            public const int SPStmtCompleted = 45;

            /// <summary>
            /// The RPC output parameter
            /// </summary>
            public const int RPCOutputParameter = 100;
        }

        /// <summary>
        /// Transactions Class
        /// </summary>
        public static class Transactions
        {
            /// <summary>
            /// The DTC transaction
            /// </summary>
            public const int DTCTransaction = 19;

            /// <summary>
            /// The SQL transaction
            /// </summary>
            public const int SQLTransaction = 50;

            /// <summary>
            /// The transaction log
            /// </summary>
            public const int TransactionLog = 54;

            /// <summary>
            /// Transaction starting
            /// </summary>
            public const int TMBeginTranstarting = 181;

            /// <summary>
            /// The transaction completed
            /// </summary>
            public const int TMBeginTrancompleted = 182;

            /// <summary>
            /// The promote transaction starting
            /// </summary>
            public const int TMPromoteTranstarting = 183;

            /// <summary>
            /// The promote transaction completed
            /// </summary>
            public const int TMPromoteTrancompleted = 184;

            /// <summary>
            /// The commit transaction starting
            /// </summary>
            public const int TMCommitTranstarting = 185;

            /// <summary>
            /// The commit transaction completed
            /// </summary>
            public const int TMCommitTrancompleted = 186;

            /// <summary>
            /// The TM rollback transaction starting
            /// </summary>
            public const int TMRollbackTranstarting = 187;

            /// <summary>
            /// The TM rollback transaction completed
            /// </summary>
            public const int TMRollbackTrancompleted = 188;

            /// <summary>
            /// The TM save transaction starting
            /// </summary>
            public const int TMSaveTranstarting = 191;

            /// <summary>
            /// The TM save transaction completed
            /// </summary>
            public const int TMSaveTrancompleted = 192;
        }

        /// <summary>
        /// TSQL Class
        /// </summary>
        public static class TSQL
        {
            /// <summary>
            /// The SQL batch completed
            /// </summary>
            public const int SQLBatchCompleted = 12;

            /// <summary>
            /// The SQL batch starting
            /// </summary>
            public const int SQLBatchStarting = 13;

            /// <summary>
            /// The SQL STMT starting
            /// </summary>
            public const int SQLStmtStarting = 40;

            /// <summary>
            /// The SQL STMT completed
            /// </summary>
            public const int SQLStmtCompleted = 41;

            /// <summary>
            /// The prepare SQL
            /// </summary>
            public const int PrepareSQL = 71;

            /// <summary>
            /// The exec prepared SQL
            /// </summary>
            public const int ExecPreparedSQL = 72;

            /// <summary>
            /// The unprepared SQL
            /// </summary>
            public const int UnprepareSQL = 73;

            /// <summary>
            /// The SQL STMT recompile
            /// </summary>
            public const int SQLStmtRecompile = 166;

            /// <summary>
            /// The X query static type
            /// </summary>
            public const int XQueryStaticType = 198;
        }

        /// <summary>
        /// User configurable Class
        /// </summary>
        public static class Userconfigurable
        {
            /// <summary>
            /// The user configurable 0
            /// </summary>
            public const int UserConfigurable0 = 82;

            /// <summary>
            /// The user configurable 1
            /// </summary>
            public const int UserConfigurable1 = 83;

            /// <summary>
            /// The user configurable 2
            /// </summary>
            public const int UserConfigurable2 = 84;

            /// <summary>
            /// The user configurable 3
            /// </summary>
            public const int UserConfigurable3 = 85;

            /// <summary>
            /// The user configurable 4
            /// </summary>
            public const int UserConfigurable4 = 86;

            /// <summary>
            /// The user configurable 5
            /// </summary>
            public const int UserConfigurable5 = 87;

            /// <summary>
            /// The user configurable 6
            /// </summary>
            public const int UserConfigurable6 = 88;

            /// <summary>
            /// The user configurable 7
            /// </summary>
            public const int UserConfigurable7 = 89;

            /// <summary>
            /// The user configurable 8
            /// </summary>
            public const int UserConfigurable8 = 90;

            /// <summary>
            /// The user configurable 9
            /// </summary>
            public const int UserConfigurable9 = 91;
        }

        /// <summary>
        /// OLEDB Class
        /// </summary>
        public static class OLEDB
        {
            /// <summary>
            /// The OLEDB errors
            /// </summary>
            public const int OLEDBErrors = 61;

            /// <summary>
            /// The OLEDB call event
            /// </summary>
            public const int OLEDBCallEvent = 119;

            /// <summary>
            /// The OLEDB query interface event
            /// </summary>
            public const int OLEDBQueryInterfaceEvent = 120;

            /// <summary>
            /// The OLEDB data read event
            /// </summary>
            public const int OLEDBDataReadEvent = 121;

            /// <summary>
            /// The OLEDB provider information
            /// </summary>
            public const int OLEDBProviderInformation = 194;
        }

        /// <summary>
        /// Broker Class
        /// </summary>
        public static class Broker
        {
            /// <summary>
            /// The broker conversation
            /// </summary>
            public const int BrokerConversation = 124;

            /// <summary>
            /// The broker conversation group
            /// </summary>
            public const int BrokerConversationGroup = 136;

            /// <summary>
            /// The broker connection
            /// </summary>
            public const int BrokerConnection = 138;

            /// <summary>
            /// The broker forwarded message sent
            /// </summary>
            public const int BrokerForwardedMessageSent = 139;

            /// <summary>
            /// The broker forwarded message dropped
            /// </summary>
            public const int BrokerForwardedMessageDropped = 140;

            /// <summary>
            /// The broker message classify
            /// </summary>
            public const int BrokerMessageClassify = 141;

            /// <summary>
            /// The broker transmission
            /// </summary>
            public const int BrokerTransmission = 142;

            /// <summary>
            /// The broker queue disabled
            /// </summary>
            public const int BrokerQueueDisabled = 143;

            /// <summary>
            /// The broker mirrored route state changed
            /// </summary>
            public const int BrokerMirroredRouteStateChanged = 144;

            /// <summary>
            /// The broker remote message acknowledgement
            /// </summary>
            public const int BrokerRemoteMessageAcknowledgement = 149;

            /// <summary>
            /// The broker message undeliverable
            /// </summary>
            public const int BrokerMessageUndeliverable = 160;

            /// <summary>
            /// The broker corrupted message
            /// </summary>
            public const int BrokerCorruptedMessage = 161;

            /// <summary>
            /// The broker activation
            /// </summary>
            public const int BrokerActivation = 163;
        }

        /// <summary>
        /// Full text class
        /// </summary>
        public static class Fulltext
        {
            /// <summary>
            /// The FT crawl started
            /// </summary>
            public const int FTCrawlStarted = 155;

            /// <summary>
            /// The FT crawl stopped
            /// </summary>
            public const int FTCrawlStopped = 156;

            /// <summary>
            /// The FT crawl aborted
            /// </summary>
            public const int FTCrawlAborted = 157;
        }

        /// <summary>
        /// Deprecation Class
        /// </summary>
        public static class Deprecation
        {
            /// <summary>
            /// The deprecation announcement
            /// </summary>
            public const int DeprecationAnnouncement = 125;

            /// <summary>
            /// The deprecation final support
            /// </summary>
            public const int DeprecationFinalSupport = 126;
        }

        /// <summary>
        /// Progress Report Class
        /// </summary>
        public static class ProgressReport
        {
            /// <summary>
            /// The progress report online index operation
            /// </summary>
            public const int ProgressReportOnlineIndexOperation = 190;
        }

        /// <summary>
        /// CLR Class
        /// </summary>
        public static class CLR
        {
            /// <summary>
            /// The assembly load
            /// </summary>
            public const int AssemblyLoad = 196;
        }

        /// <summary>
        /// Query Notifications class
        /// </summary>
        public static class QueryNotifications
        {
            /// <summary>
            /// The QN subscription
            /// </summary>
            public const int QNSubscription = 199;

            /// <summary>
            /// The QN parameter table
            /// </summary>
            public const int QNParametertable = 200;

            /// <summary>
            /// The QN template
            /// </summary>
            public const int QNTemplate = 201;

            /// <summary>
            /// The QN dynamics
            /// </summary>
            public const int QNDynamics = 202;
        }
    }
}