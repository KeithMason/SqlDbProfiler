// ----------------------------------------------------------------------
// <copyright file="EventList.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
//     Traceutils assembly 
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// C Event
    /// </summary>
    [Serializable]
    public class EventList
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EventList"/> class.
        /// </summary>
        public EventList()
        {
            return;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventList"/> class.
        /// </summary>
        /// <param name="databaseID">A database ID.</param>
        /// <param name="databaseName">Name of a database.</param>
        /// <param name="objectID">A object ID.</param>
        /// <param name="objectName">Name of a object.</param>
        /// <param name="textData">A text data.</param>
        public EventList(long databaseID, string databaseName, long objectID, string objectName, string textData)
        {
            this.DatabaseID = databaseID;
            this.DatabaseName = databaseName;
            this.ObjectID = objectID;
            this.ObjectName = objectName;
            this.TextData = textData;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventList"/> class.
        /// </summary>
        /// <param name="eventClass">The event class.</param>
        /// <param name="spid">The SPID.</param>
        /// <param name="nestLevel">The nest level.</param>
        /// <param name="databaseID">A database ID.</param>
        /// <param name="databaseName">Name of a database.</param>
        /// <param name="objectID">A object ID.</param>
        /// <param name="objectName">Name of a object.</param>
        /// <param name="textData">A text data.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="reads">The reads.</param>
        /// <param name="writes">The writes.</param>
        /// <param name="cpu">The CPU.</param>
        public EventList(long eventClass, long spid, long nestLevel, long databaseID, string databaseName, long objectID, string objectName, string textData, long duration, long reads, long writes, long cpu)
        {
            this.EventClass = eventClass;
            this.DatabaseID = databaseID;
            this.DatabaseName = databaseName;
            this.ObjectID = objectID;
            this.ObjectName = objectName;
            this.TextData = textData;
            this.Duration = duration;
            this.Reads = reads;
            this.Writes = writes;
            this.CPU = cpu;
            this.SPID = spid;
            this.NestLevel = nestLevel;
        }

        #endregion

        /// <summary>
        /// Gets or sets the event class.
        /// </summary>
        /// <value>
        /// The event class.
        /// </value>
        [XmlAttribute]
        public long EventClass { get; set; }

        /// <summary>
        /// Gets or sets the database ID.
        /// </summary>
        /// <value>
        /// The database ID.
        /// </value>
        [XmlAttribute]
        public long DatabaseID { get; set; }

        /// <summary>
        /// Gets or sets the object ID.
        /// </summary>
        /// <value>
        /// The object ID.
        /// </value>
        [XmlAttribute]
        public long ObjectID { get; set; }

        /// <summary>
        /// Gets or sets the row counts.
        /// </summary>
        /// <value>
        /// The row counts.
        /// </value>
        [XmlAttribute]
        public long RowCounts { get; set; }

        /// <summary>
        /// Gets or sets the text data.
        /// </summary>
        /// <value>
        /// The text data.
        /// </value>
        public string TextData { get; set; }

        /// <summary>
        /// Gets or sets the name of the database.
        /// </summary>
        /// <value>
        /// The name of the database.
        /// </value>
        [XmlAttribute]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the object.
        /// </summary>
        /// <value>
        /// The name of the object.
        /// </value>
        [XmlAttribute]
        public string ObjectName { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        [XmlAttribute]
        public long Count { get; set; }

        /// <summary>
        /// Gets or sets the CPU.
        /// </summary>
        /// <value>
        /// The CPU.
        /// </value>
        [XmlAttribute]
        public long CPU { get; set; }

        /// <summary>
        /// Gets or sets the reads.
        /// </summary>
        /// <value>
        /// The reads.
        /// </value>
        [XmlAttribute]
        public long Reads { get; set; }

        /// <summary>
        /// Gets or sets the writes.
        /// </summary>
        /// <value>
        /// The writes.
        /// </value>
        [XmlAttribute]
        public long Writes { get; set; }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        [XmlAttribute]
        public long Duration { get; set; }

        /// <summary>
        /// Gets or sets the SPID.
        /// </summary>
        /// <value>
        /// The SPID.
        /// </value>
        [XmlAttribute]
        public long SPID { get; set; }

        /// <summary>
        /// Gets or sets the nest level.
        /// </summary>
        /// <value>
        /// The nest level.
        /// </value>
        [XmlAttribute]
        public long NestLevel { get; set; }

        /// <summary>
        /// Gets the average CPU.
        /// </summary>
        /// <value>
        /// The average CPU.
        /// </value>
        public long AvgCPU
        {
            get { return this.Count == 0 ? 0 : this.CPU / this.Count; }
        }

        /// <summary>
        /// Gets the average reads.
        /// </summary>
        /// <value>
        /// The average reads.
        /// </value>
        public long AvgReads
        {
            get { return this.Count == 0 ? 0 : this.Reads / this.Count; }
        }

        /// <summary>
        /// Gets the average writes.
        /// </summary>
        /// <value>
        /// The average writes.
        /// </value>
        public long AvgWrites
        {
            get { return this.Count == 0 ? 0 : this.Writes / this.Count; }
        }

        /// <summary>
        /// Gets the duration of the average.
        /// </summary>
        /// <value>
        /// The duration of the average.
        /// </value>
        public long AvgDuration
        {
            get { return this.Count == 0 ? 0 : this.Duration / this.Count; }
        }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <returns>Key string</returns>
        public string GetKey()
        {
            return string.Format("({0}).({1}).({2}).({3})", this.DatabaseID, this.ObjectID, this.ObjectName, this.TextData);
        }
    }
}