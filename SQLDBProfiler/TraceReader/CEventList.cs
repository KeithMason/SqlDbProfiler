// ----------------------------------------------------------------------
// <copyright file="CEventList.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// C Event List
    /// </summary>
    public class CEventList
    {
        /// <summary>
        /// The event list
        /// </summary>
        public readonly SortedDictionary<string, EventList[]> EventList;

        /// <summary>
        /// Initializes a new instance of the <see cref="CEventList"/> class.
        /// </summary>
        public CEventList()
        {
            this.EventList = new SortedDictionary<string, EventList[]>();
        }

        /// <summary>
        /// Appends from file.
        /// </summary>
        /// <param name="cnt">The CNT.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="ignorenonamesp">if set to <c>true</c> [ignore no name SP].</param>
        /// <param name="transform">if set to <c>true</c> [transform].</param>
        public void AppendFromFile(int cnt, string filename, bool ignorenonamesp, bool transform)
        {
            XmlSerializer x = new XmlSerializer(typeof(EventList[]));
            FileStream fs = new FileStream(filename, FileMode.Open);
            EventList[] a = (EventList[])x.Deserialize(fs);
            TraceUtilities lex = new TraceUtilities();
            foreach (EventList e in a)
            {
                if (e.TextData.Contains("statman") || e.TextData.Contains("UPDATE STATISTICS"))
                {
                    continue;
                }

                if (!ignorenonamesp || e.ObjectName.Length != 0)
                {
                    if (transform)
                    {
                        this.AddEvent(
                            cnt,
                            e.DatabaseID,
                            e.DatabaseName,
                            e.ObjectName.Length == 0 ? 0 : e.ObjectID,
                            e.ObjectName.Length == 0 ? string.Empty : e.ObjectName,
                            e.ObjectName.Length == 0 ? lex.StandardSql(e.TextData) : e.TextData,
                            e.CPU,
                            e.Reads,
                            e.Writes,
                            e.Duration,
                            e.Count,
                            e.RowCounts);
                    }
                    else
                    {
                        this.AddEvent(
                            cnt,
                            e.DatabaseID,
                            e.DatabaseName,
                            e.ObjectID,
                            e.ObjectName,
                            e.TextData,
                            e.CPU,
                            e.Reads,
                            e.Writes,
                            e.Duration,
                            e.Count,
                            e.RowCounts);
                    }
                }
            }

            fs.Dispose();
        }

        /// <summary>
        /// Adds the event.
        /// </summary>
        /// <param name="cnt">The CNT.</param>
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
        public void AddEvent(int cnt, long databaseID, string databaseName, long objectID, string objectName, string textData, long cpu, long reads, long writes, long duration, long count, long rowcounts)
        {
            EventList[] evt;
            EventList e;
            string key = string.Format("({0}).({1}).({2}).({3})", databaseID, objectID, objectName, textData);
            if (!this.EventList.TryGetValue(key, out evt))
            {
                evt = new EventList[2];
                for (int k = 0; k < evt.Length; k++)
                {
                    evt[k] = new EventList(databaseID, databaseName, objectID, objectName, textData);
                }

                this.EventList.Add(key, evt);
                e = evt[cnt];
            }
            else
            {
                e = evt[cnt];
            }

            e.Count += count;
            e.CPU += cpu;
            e.Reads += reads;
            e.Writes += writes;
            e.Duration += duration;
            e.RowCounts += rowcounts;
        }
    }
}