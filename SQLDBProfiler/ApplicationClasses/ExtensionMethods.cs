// ----------------------------------------------------------------------
// <copyright file="ExtensionMethods.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Utilities Class
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Determines whether the specified column is numeric.
        /// </summary>
        /// <param name="column">The column.</param>
        /// <returns>
        ///   <c>true</c> if the specified column is numeric; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNumericColumn(this DataGridViewColumn column)
        {
            if (column == null)
            {
                return false;
            }
            else
            {
                if (column.ValueType.UnderlyingSystemType != null)
                {
                    if (column.ValueType.UnderlyingSystemType == typeof(float)
                            || column.ValueType.UnderlyingSystemType == typeof(double)
                            || column.ValueType.UnderlyingSystemType == typeof(decimal)
                            || column.ValueType.UnderlyingSystemType == typeof(byte)
                            || column.ValueType.UnderlyingSystemType == typeof(sbyte)
                            || column.ValueType.UnderlyingSystemType == typeof(short)
                            || column.ValueType.UnderlyingSystemType == typeof(ushort)
                            || column.ValueType.UnderlyingSystemType == typeof(int)
                            || column.ValueType.UnderlyingSystemType == typeof(uint)
                            || column.ValueType.UnderlyingSystemType == typeof(long)
                            || column.ValueType.UnderlyingSystemType == typeof(ulong))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Determines whether [is decimal column] [the specified column].
        /// </summary>
        /// <param name="column">The column.</param>
        /// <returns>
        ///   <c>true</c> if [is decimal column] [the specified column]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsDecimalColumn(this DataGridViewColumn column)
        {
            if (column == null)
            {
                return false;
            }
            else
            {
                if (column.ValueType.UnderlyingSystemType == typeof(float)
                        || column.ValueType.UnderlyingSystemType == typeof(double)
                        || column.ValueType.UnderlyingSystemType == typeof(decimal))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Encapsulates the specified input string with CData.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <returns>a CData string</returns>
        public static string GetCData(this string inputString)
        {
            return string.Format("<![CDATA[{0}]]>", inputString);
        }

        /// <summary>
        /// Gets the selected data grid view cells.
        /// </summary>
        /// <param name="dataGridView">The this grid.</param>
        /// <returns>DataGridView selected cells</returns>
        public static string GetSelectedDataGridViewCells(this DataGridView dataGridView)
        {
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder headerBuilder = new StringBuilder();

            bool cellsAdded = false;
            bool firstColumn = true;
            bool firstRow = true;
            string delimiter = string.Empty;

            for (int rows = 0; rows < dataGridView.Rows.Count; rows++)
            {
                for (int cols = 0; cols < dataGridView.Columns.Count; cols++)
                {
                    if (dataGridView.Rows[rows].Cells[cols].Selected)
                    {
                        delimiter = firstColumn ? string.Empty : "\t";

                        if (firstRow)
                        {
                            headerBuilder.Append(string.Format(@"{0}{1}", delimiter, dataGridView.Rows[rows].Cells[cols].OwningColumn.HeaderCell.Value.ToString()));
                        }

                        stringBuilder.Append(string.Format(@"{0}{1}", delimiter, dataGridView.Rows[rows].Cells[cols].Value.ToString()));
                        firstColumn = false;
                        cellsAdded = true;
                    }
                }

                if (cellsAdded)
                {
                    stringBuilder.AppendLine();
                    if (firstRow)
                    {
                        headerBuilder.AppendLine();
                    }

                    cellsAdded = false;
                    firstColumn = true;
                    firstRow = false;
                }
            }

            MessageBox.Show(
                "Selected cells copied to clipboard",
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return headerBuilder.ToString() + stringBuilder.ToString();
        }
    }
}
