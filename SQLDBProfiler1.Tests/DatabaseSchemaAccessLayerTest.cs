// <copyright file="DatabaseSchemaAccessLayerTest.cs">Copyright ©</copyright>
using System;
using System.Collections.Generic;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for DatabaseSchemaAccessLayer</summary>
    [PexClass(typeof(DatabaseSchemaAccessLayer))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class DatabaseSchemaAccessLayerTest
    {
        /// <summary>Test stub for .ctor(ConnectionParameters)</summary>
        [PexMethod]
        public DatabaseSchemaAccessLayer Constructor(ConnectionParameters connectionParameters)
        {
            DatabaseSchemaAccessLayer target
               = new DatabaseSchemaAccessLayer(connectionParameters);
            return target;
            // TODO: add assertions to method DatabaseSchemaAccessLayerTest.Constructor(ConnectionParameters)
        }

        /// <summary>Test stub for GetDatabaseChangesLast90Days(String)</summary>
        [PexMethod]
        public List<DatabaseChangesLast90Days> GetDatabaseChangesLast90Days(
            [PexAssumeUnderTest]DatabaseSchemaAccessLayer target,
            string database
        )
        {
            List<DatabaseChangesLast90Days> result
               = target.GetDatabaseChangesLast90Days(database);
            return result;
            // TODO: add assertions to method DatabaseSchemaAccessLayerTest.GetDatabaseChangesLast90Days(DatabaseSchemaAccessLayer, String)
        }

        /// <summary>Test stub for GetDatabaseForeignKeys(String)</summary>
        [PexMethod]
        public List<DatabaseForeignKeys> GetDatabaseForeignKeys(
            [PexAssumeUnderTest]DatabaseSchemaAccessLayer target,
            string database
        )
        {
            List<DatabaseForeignKeys> result = target.GetDatabaseForeignKeys(database);
            return result;
            // TODO: add assertions to method DatabaseSchemaAccessLayerTest.GetDatabaseForeignKeys(DatabaseSchemaAccessLayer, String)
        }

        /// <summary>Test stub for GetDatabaseIndexUsage(String)</summary>
        [PexMethod]
        public List<DatabaseIndexUsage> GetDatabaseIndexUsage(
            [PexAssumeUnderTest]DatabaseSchemaAccessLayer target,
            string database
        )
        {
            List<DatabaseIndexUsage> result = target.GetDatabaseIndexUsage(database);
            return result;
            // TODO: add assertions to method DatabaseSchemaAccessLayerTest.GetDatabaseIndexUsage(DatabaseSchemaAccessLayer, String)
        }

        /// <summary>Test stub for GetDatabaseList()</summary>
        [PexMethod]
        public List<string> GetDatabaseList([PexAssumeUnderTest]DatabaseSchemaAccessLayer target)
        {
            List<string> result = target.GetDatabaseList();
            return result;
            // TODO: add assertions to method DatabaseSchemaAccessLayerTest.GetDatabaseList(DatabaseSchemaAccessLayer)
        }

        /// <summary>Test stub for GetDatabaseNameSize(String)</summary>
        [PexMethod]
        public List<DatabaseNameSize> GetDatabaseNameSize(
            [PexAssumeUnderTest]DatabaseSchemaAccessLayer target,
            string database
        )
        {
            List<DatabaseNameSize> result = target.GetDatabaseNameSize(database);
            return result;
            // TODO: add assertions to method DatabaseSchemaAccessLayerTest.GetDatabaseNameSize(DatabaseSchemaAccessLayer, String)
        }

        /// <summary>Test stub for GetDatabaseNoPrimaryKey(String)</summary>
        [PexMethod]
        public List<DatabaseNoPrimaryKey> GetDatabaseNoPrimaryKey(
            [PexAssumeUnderTest]DatabaseSchemaAccessLayer target,
            string database
        )
        {
            List<DatabaseNoPrimaryKey> result = target.GetDatabaseNoPrimaryKey(database);
            return result;
            // TODO: add assertions to method DatabaseSchemaAccessLayerTest.GetDatabaseNoPrimaryKey(DatabaseSchemaAccessLayer, String)
        }

        /// <summary>Test stub for GetDatabaseNonClusteredIndexes(String)</summary>
        [PexMethod]
        public List<DatabaseNonClusteredIndexes> GetDatabaseNonClusteredIndexes(
            [PexAssumeUnderTest]DatabaseSchemaAccessLayer target,
            string database
        )
        {
            List<DatabaseNonClusteredIndexes> result
               = target.GetDatabaseNonClusteredIndexes(database);
            return result;
            // TODO: add assertions to method DatabaseSchemaAccessLayerTest.GetDatabaseNonClusteredIndexes(DatabaseSchemaAccessLayer, String)
        }

        /// <summary>Test stub for GetDatabasePrimaryKeys(String)</summary>
        [PexMethod]
        public List<DatabasePrimaryKeys> GetDatabasePrimaryKeys(
            [PexAssumeUnderTest]DatabaseSchemaAccessLayer target,
            string database
        )
        {
            List<DatabasePrimaryKeys> result = target.GetDatabasePrimaryKeys(database);
            return result;
            // TODO: add assertions to method DatabaseSchemaAccessLayerTest.GetDatabasePrimaryKeys(DatabaseSchemaAccessLayer, String)
        }

        /// <summary>Test stub for GetDatabaseTriggers(String)</summary>
        [PexMethod]
        public List<DatabaseTriggers> GetDatabaseTriggers(
            [PexAssumeUnderTest]DatabaseSchemaAccessLayer target,
            string database
        )
        {
            List<DatabaseTriggers> result = target.GetDatabaseTriggers(database);
            return result;
            // TODO: add assertions to method DatabaseSchemaAccessLayerTest.GetDatabaseTriggers(DatabaseSchemaAccessLayer, String)
        }

        /// <summary>Test stub for GetDatabaseUnusedIndexes(String)</summary>
        [PexMethod]
        public List<DatabaseUnusedIndexes> GetDatabaseUnusedIndexes(
            [PexAssumeUnderTest]DatabaseSchemaAccessLayer target,
            string database
        )
        {
            List<DatabaseUnusedIndexes> result = target.GetDatabaseUnusedIndexes(database);
            return result;
            // TODO: add assertions to method DatabaseSchemaAccessLayerTest.GetDatabaseUnusedIndexes(DatabaseSchemaAccessLayer, String)
        }

        /// <summary>Test stub for GetIdentityFields(String)</summary>
        [PexMethod]
        public List<DatabaseIdentityFields> GetIdentityFields(
            [PexAssumeUnderTest]DatabaseSchemaAccessLayer target,
            string database
        )
        {
            List<DatabaseIdentityFields> result = target.GetIdentityFields(database);
            return result;
            // TODO: add assertions to method DatabaseSchemaAccessLayerTest.GetIdentityFields(DatabaseSchemaAccessLayer, String)
        }

        /// <summary>Test stub for GetTableRowCounts(String)</summary>
        [PexMethod]
        public List<DatabaseTableRowCounts> GetTableRowCounts(
            [PexAssumeUnderTest]DatabaseSchemaAccessLayer target,
            string database
        )
        {
            List<DatabaseTableRowCounts> result = target.GetTableRowCounts(database);
            return result;
            // TODO: add assertions to method DatabaseSchemaAccessLayerTest.GetTableRowCounts(DatabaseSchemaAccessLayer, String)
        }
    }
}
