// <copyright file="SqlQueryTest.cs">Copyright ©</copyright>
using System;
using System.Xml;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for SqlQuery</summary>
    [PexClass(typeof(SqlQuery))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class SqlQueryTest
    {
        /// <summary>Test stub for get_CDataContent()</summary>
        [PexMethod]
        public XmlNode[] CDataContentGet([PexAssumeUnderTest]SqlQuery target)
        {
            XmlNode[] result = target.CDataContent;
            return result;
            // TODO: add assertions to method SqlQueryTest.CDataContentGet(SqlQuery)
        }

        /// <summary>Test stub for set_CDataContent(XmlNode[])</summary>
        [PexMethod]
        public void CDataContentSet([PexAssumeUnderTest]SqlQuery target, XmlNode[] value)
        {
            target.CDataContent = value;
            // TODO: add assertions to method SqlQueryTest.CDataContentSet(SqlQuery, XmlNode[])
        }
    }
}
