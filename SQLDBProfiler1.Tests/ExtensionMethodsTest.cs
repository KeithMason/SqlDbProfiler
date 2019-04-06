// <copyright file="ExtensionMethodsTest.cs">Copyright ©</copyright>
using System;
using System.Windows.Forms;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using SQLDBProfiler;

namespace SQLDBProfiler
{
    /// <summary>This class contains parameterized unit tests for ExtensionMethods</summary>
    [PexClass(typeof(ExtensionMethods))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class ExtensionMethodsTest
    {
        /// <summary>Test stub for GetCData(String)</summary>
        [PexMethod]
        public string GetCData(string inputString)
        {
            string result = ExtensionMethods.GetCData(inputString);
            return result;
            // TODO: add assertions to method ExtensionMethodsTest.GetCData(String)
        }

        /// <summary>Test stub for GetSelectedDataGridViewCells(DataGridView)</summary>
        [PexMethod]
        public string GetSelectedDataGridViewCells(DataGridView dataGridView)
        {
            string result = ExtensionMethods.GetSelectedDataGridViewCells(dataGridView);
            return result;
            // TODO: add assertions to method ExtensionMethodsTest.GetSelectedDataGridViewCells(DataGridView)
        }

        /// <summary>Test stub for IsDecimalColumn(DataGridViewColumn)</summary>
        [PexMethod]
        public bool IsDecimalColumn(DataGridViewColumn column)
        {
            bool result = ExtensionMethods.IsDecimalColumn(column);
            return result;
            // TODO: add assertions to method ExtensionMethodsTest.IsDecimalColumn(DataGridViewColumn)
        }

        /// <summary>Test stub for IsNumericColumn(DataGridViewColumn)</summary>
        [PexMethod]
        public bool IsNumericColumn(DataGridViewColumn column)
        {
            bool result = ExtensionMethods.IsNumericColumn(column);
            return result;
            // TODO: add assertions to method ExtensionMethodsTest.IsNumericColumn(DataGridViewColumn)
        }
    }
}
