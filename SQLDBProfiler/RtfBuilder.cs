// ----------------------------------------------------------------------
// <copyright file="RtfBuilder.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
//     Traceutils assembly - //writen by Locky, 2009. 
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Drawing;
    using System.Text;

    /// <summary>
    /// RTF Builder
    /// </summary>
    public class RTFBuilder
    {
        #region private fields

        /// <summary>
        /// The slash
        /// </summary>
        private static readonly char[] Slashable = new[] { '{', '}', '\\' };

        /// <summary>
        /// The default font size
        /// </summary>
        private readonly float defaultFontSize;

        /// <summary>
        /// The string builder
        /// </summary>
        private readonly StringBuilder stringBuilder = new StringBuilder();

        /// <summary>
        /// The color table
        /// </summary>
        private readonly List<Color> colortable = new List<Color>();

        /// <summary>
        /// The font table
        /// </summary>
        private readonly StringCollection fonttable = new StringCollection();

        /// <summary>
        /// The back color
        /// </summary>
        private Color backcolor;

        /// <summary>
        /// The fore color
        /// </summary>
        private Color forecolor;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RTFBuilder"/> class.
        /// </summary>
        public RTFBuilder()
        {
            this.ForeColor = Color.FromKnownColor(KnownColor.WindowText);
            this.BackColor = Color.FromKnownColor(KnownColor.Window);
            this.defaultFontSize = 20F;
        }

        #endregion

        #region public properties

        /// <summary>
        /// Sets the color of the fore.
        /// </summary>
        /// <value>
        /// The color of the fore.
        /// </value>
        public Color ForeColor
        {
            set
            {
                if (!this.colortable.Contains(value)) 
                {
                    this.colortable.Add(value); 
                }

                if (value != this.forecolor)
                {
                    this.stringBuilder.Append(string.Format("\\cf{0} ", this.colortable.IndexOf(value) + 1));
                }

                this.forecolor = value;
            }
        }

        /// <summary>
        /// Sets the color of the back.
        /// </summary>
        /// <value>
        /// The color of the back.
        /// </value>
        public Color BackColor
        {
            set
            {
                if (!this.colortable.Contains(value)) 
                {
                    this.colortable.Add(value); 
                }

                if (value != this.backcolor)
                {
                    this.stringBuilder.Append(string.Format("\\highlight{0} ", this.colortable.IndexOf(value) + 1));
                }

                this.backcolor = value;
            }
        }

        #endregion

        #region public methods

        /// <summary>
        /// Appends the line.
        /// </summary>
        public void AppendLine()
        {
            this.stringBuilder.AppendLine("\\line");
        }

        /// <summary>
        /// Appends the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Append(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                value = CheckChar(value);
                if (value.IndexOf(Environment.NewLine) >= 0)
                {
                    string[] lines = value.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                    foreach (string line in lines)
                    {
                        this.stringBuilder.Append(line);
                        this.stringBuilder.Append("\\line ");
                    }
                }
                else
                {
                    this.stringBuilder.Append(value);
                }
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public new string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang3081");
            result.Append("{\\fonttbl");
            for (int i = 0; i < this.fonttable.Count; i++)
            {
                try
                {
                    result.Append(string.Format(this.fonttable[i], i));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            result.AppendLine("}");
            result.Append("{\\colortbl ;");
            foreach (Color item in this.colortable)
            {
                result.AppendFormat("\\red{0}\\green{1}\\blue{2};", item.R, item.G, item.B);
            }

            result.AppendLine("}");
            result.Append("\\viewkind4\\uc1\\pard\\plain\\f0");
            result.AppendFormat("\\fs{0} ", this.defaultFontSize);
            result.AppendLine();
            result.Append(this.stringBuilder.ToString());
            result.Append("}");
            return result.ToString();
        }

        #endregion

        #region private methods

        /// <summary>
        /// Checks the char.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>check string</returns>
        private static string CheckChar(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.IndexOfAny(Slashable) >= 0)
                {
                    value = value.Replace("{", "\\{").Replace("}", "\\}").Replace("\\", "\\\\");
                }

                bool replaceuni = false;
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] > 255)
                    {
                        replaceuni = true;
                        break;
                    }
                }

                if (replaceuni)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (value[i] <= 255)
                        {
                            sb.Append(value[i]);
                        }
                        else
                        {
                            sb.Append("\\u");
                            sb.Append((int)value[i]);
                            sb.Append("?");
                        }
                    }

                    value = sb.ToString();
                }
            }

            return value;
        }

        #endregion
    }
}