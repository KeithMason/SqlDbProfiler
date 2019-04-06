// <copyright file="DatabaseSchemaTest.cs">Copyright ©</copyright>
using System;
using System.Windows.Forms;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for DatabaseSchema</summary>
    [PexClass(typeof(DatabaseSchema))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class DatabaseSchemaTest
    {
        /// <summary>Test stub for .ctor(ConnectionParameters, Form)</summary>
        [PexMethod]
        public DatabaseSchema Constructor(ConnectionParameters connectionParameters, Form parentForm)
        {
            DatabaseSchema target = new DatabaseSchema(connectionParameters, parentForm);
            return target;
            // TODO: add assertions to method DatabaseSchemaTest.Constructor(ConnectionParameters, Form)
        }
    }
}
