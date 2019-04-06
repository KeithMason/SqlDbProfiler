// ----------------------------------------------------------------------
// <copyright file="SqlQueries.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// SQL Queries
    /// </summary>
    [Serializable, XmlRoot("queries"), XmlType("queries")]
    public class SqlQueries
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlQueries"/> class.
        /// </summary>
        public SqlQueries()
        {
            this.QueryItems = new List<SqlQuery>();
        }

        /// <summary>
        /// Gets or sets the query items.
        /// </summary>
        /// <value>
        /// The query items.
        /// </value>
        [XmlElement("query")]
        public List<SqlQuery> QueryItems { get; set; }
    }
}
