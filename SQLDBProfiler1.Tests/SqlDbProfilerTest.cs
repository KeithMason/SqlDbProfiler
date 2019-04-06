// <copyright file="SqlDbProfilerTest.cs">Copyright ©</copyright>
using System;
using System.Windows.Forms;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for SqlDbProfiler</summary>
    [PexClass(typeof(SqlDbProfiler))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class SqlDbProfilerTest
    {
        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public SqlDbProfiler Constructor()
        {
            SqlDbProfiler target = new SqlDbProfiler();
            return target;
            // TODO: add assertions to method SqlDbProfilerTest.Constructor()
        }

        /// <summary>Test stub for FocusListViewItem(ListViewItem)</summary>
        [PexMethod]
        internal void FocusListViewItem(
            [PexAssumeUnderTest]SqlDbProfiler target,
            ListViewItem listViewItem
        )
        {
            target.FocusListViewItem(listViewItem);
            // TODO: add assertions to method SqlDbProfilerTest.FocusListViewItem(SqlDbProfiler, ListViewItem)
        }

        /// <summary>Test stub for PerformFind()</summary>
        [PexMethod]
        internal void PerformFind([PexAssumeUnderTest]SqlDbProfiler target)
        {
            target.PerformFind();
            // TODO: add assertions to method SqlDbProfilerTest.PerformFind(SqlDbProfiler)
        }

        /// <summary>Test stub for SelectAllEvents(Boolean)</summary>
        [PexMethod]
        internal void SelectAllEvents([PexAssumeUnderTest]SqlDbProfiler target, bool select)
        {
            target.SelectAllEvents(select);
            // TODO: add assertions to method SqlDbProfilerTest.SelectAllEvents(SqlDbProfiler, Boolean)
        }
    }
}
