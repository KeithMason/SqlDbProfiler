// ----------------------------------------------------------------------
// <copyright file="EnumDatabaseViews.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    /// <summary>
    /// Database Views Enumeration
    /// </summary>
    public enum EnumDatabaseViews
    {
        /// <summary>
        /// The database names and sizes
        /// </summary>
        DatabaseFiles,

        /// <summary>
        /// The changes last90 days
        /// </summary>
        ChangesLast90Days,

        /// <summary>
        /// The non clustered indexes
        /// </summary>
        NonClusteredIndexes,

        /// <summary>
        /// The unused indexes
        /// </summary>
        UnusedIndexes,

        /// <summary>
        /// The index usage
        /// </summary>
        IndexUsage,

        /// <summary>
        /// The missing indexes
        /// </summary>
        IdentityFields,

        /// <summary>
        /// The no primary key
        /// </summary>
        NoPrimaryKey,

        /// <summary>
        /// The foreign keys
        /// </summary>
        ForeignKeys,

        /// <summary>
        /// The primary keys
        /// </summary>
        PrimaryKeys,

        /// <summary>
        /// The table row count
        /// </summary>
        TableRowCount,

        /// <summary>
        /// The triggers
        /// </summary>
        Triggers
    }
}
