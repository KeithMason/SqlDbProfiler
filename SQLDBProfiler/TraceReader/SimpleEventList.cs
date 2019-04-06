// ----------------------------------------------------------------------
// <copyright file="SimpleEventList.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// Simple Event List
    /// </summary>
    public class SimpleEventList
    {
        /// <summary>
        /// The Sorted Dictionary list
        /// </summary>
        public readonly SortedDictionary<string, EventList> List;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleEventList"/> class.
        /// </summary>
        public SimpleEventList()
        {
            this.List = new SortedDictionary<string, EventList>();
        }

        /// <summary>
        /// Saves to file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public void SaveToFile(string filename)
        {
            EventList[] a = new EventList[this.List.Count];
            this.List.Values.CopyTo(a, 0);
            XmlSerializer x = new XmlSerializer(typeof(EventList[]));

            FileStream fs = new FileStream(filename, FileMode.Create);
            x.Serialize(fs, a);
            fs.Dispose();
        }

        /// <summary>
        /// Adds the event.
        /// </summary>
        /// <param name="eventClass">The event class.</param>
        /// <param name="nestLevel">The nest level.</param>
        /// <param name="databaseID">The database ID.</param>
        /// <param name="databaseName">Name of the database.</param>
        /// <param name="objectID">The object ID.</param>
        /// <param name="objectName">Name of the object.</param>
        /// <param name="textData">The text data.</param>
        /// <param name="cpu">The CPU.</param>
        /// <param name="reads">The reads.</param>
        /// <param name="writes">The writes.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="count">The count.</param>
        /// <param name="rowcounts">The row counts.</param>
        public void AddEvent(long eventClass, long nestLevel, long databaseID, string databaseName, long objectID, string objectName, string textData, long cpu, long reads, long writes, long duration, long count, long rowcounts)
        {
            EventList evt;
            string key = string.Format("({0}).({1}).({2})", databaseID, objectID, textData);
            if (!this.List.TryGetValue(key, out evt))
            {
                evt = new EventList(databaseID, databaseName, objectID, objectName, textData);
                this.List.Add(key, evt);
            }

            evt.NestLevel = nestLevel;
            evt.EventClass = eventClass;
            evt.Count += count;
            evt.CPU += cpu;
            evt.Reads += reads;
            evt.Writes += writes;
            evt.Duration += duration;
            evt.RowCounts += rowcounts;
        }
    }
}
