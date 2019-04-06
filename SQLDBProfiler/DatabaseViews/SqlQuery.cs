// -----------------------------------------------------------------------
// <copyright file="SqlQuery.cs" company="Masonsoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// -----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// SQL Query items
    /// </summary>
    public class SqlQuery
    {
        /// <summary>
        /// Gets or sets the name of the SQL.
        /// </summary>
        /// <value>
        /// The name of the SQL.
        /// </value>
        [XmlAttribute("description")]
        public string SqlName { get; set; }

        /// <summary>
        /// Gets or sets the SQL query Code.
        /// </summary>
        /// <value>
        /// The SQL query code.
        /// </value>
        [XmlIgnore]
        public string SqlCode { get; set; }

        /// <summary>
        /// Gets or sets the content of the C data.
        /// </summary>
        /// <value>
        /// The content of the C data.
        /// </value>
        /// <exception cref="System.InvalidOperationException">Invalid array length</exception>
        [XmlText]
        public XmlNode[] CDataContent
        {
            get
            {
                var dummy = new XmlDocument();
                return new XmlNode[] { dummy.CreateCDataSection(this.SqlCode) };
            }

            set
            {
                if (value == null)
                {
                    this.SqlCode = null;
                    return;
                }

                if (value.Length != 1)
                {
                    throw new InvalidOperationException(
                        string.Format("Invalid array length {0}", value.Length));
                }

                this.SqlCode = value[0].Value;
            }
        }
    }
}
