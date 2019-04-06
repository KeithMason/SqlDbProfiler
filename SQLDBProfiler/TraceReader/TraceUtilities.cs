// ----------------------------------------------------------------------
// <copyright file="TraceUtilities.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
//     Traceutils assembly 
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System;
    using System.Drawing;
    using System.Text;

    /// <summary>
    /// Trace Utilities Class
    /// </summary>
    public class TraceUtilities
    {
        #region private constants

        /// <summary>
        /// The identifier STR
        /// </summary>
        private const string IdentifierStr = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890_#$";

        /// <summary>
        /// The hex digits
        /// </summary>
        private const string HexDigits = "1234567890abcdefABCDEF";

        /// <summary>
        /// The number STR
        /// </summary>
        private const string NumberStr = "1234567890.-";

        #endregion

        #region private fields

        /// <summary>
        /// The tokens
        /// </summary>
        private readonly Sqltokens tokens = new Sqltokens();

        /// <summary>
        /// The identifiers array
        /// </summary>
        private readonly char[] identifiersArray = IdentifierStr.ToCharArray();

        /// <summary>
        /// The m_ string len
        /// </summary>
        private int stringLen;

        /// <summary>
        /// The token position
        /// </summary>
        private int tokenPos;

        /// <summary>
        /// The token
        /// </summary>
        private string token = string.Empty;

        /// <summary>
        /// The token id
        /// </summary>
        private TokenKind tokenId;

        /// <summary>
        /// The line
        /// </summary>
        private string line;

        /// <summary>
        /// The m_ run
        /// </summary>
        private int run;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TraceUtilities"/> class.
        /// </summary>
        public TraceUtilities()
        {
            Array.Sort(this.identifiersArray);
        }

        #endregion

        #region enums

        /// <summary>
        /// Token Kind 
        /// </summary>
        public enum TokenKind
        {
            /// <summary>
            /// The Token Kind comment
            /// </summary>
            tkComment,

            /// <summary>
            /// The Token Kind data type
            /// </summary>
            tkDatatype,

            /// <summary>
            /// The Token Kind function
            /// </summary>
            tkFunction,

            /// <summary>
            /// The Token Kind identifier
            /// </summary>
            tkIdentifier,

            /// <summary>
            /// The Token Kind key
            /// </summary>
            tkKey,

            /// <summary>
            /// The Token Kind null
            /// </summary>
            tkNull,

            /// <summary>
            /// The token kind number
            /// </summary>
            tkNumber,

            /// <summary>
            /// The Token Kind space
            /// </summary>
            tkSpace,

            /// <summary>
            /// The Token Kind string
            /// </summary>
            tkString,

            /// <summary>
            /// The Token Kind symbol
            /// </summary>
            tkSymbol,

            /// <summary>
            /// The Token Kind unknown
            /// </summary>
            tkUnknown,

            /// <summary>
            /// The Token Kind variable
            /// </summary>
            tkVariable,

            /// <summary>
            /// The Token Kind grey keyword
            /// </summary>
            tkGreyKeyword,

            /// <summary>
            /// The Token Kind keyword
            /// </summary>
            tkFuKeyword
        }

        /// <summary>
        /// SQL Range Enumerator
        /// </summary>
        private enum SqlRange
        {
            /// <summary>
            /// The Range Enumerator unknown
            /// </summary>
            rsUnknown,

            /// <summary>
            /// The Range Enumerator comment
            /// </summary>
            rsComment,

            /// <summary>
            /// The Range Enumerator string
            /// </summary>
            rsString
        }

        #endregion

        #region private properties

        /// <summary>
        /// Gets or sets the range.
        /// </summary>
        /// <value>
        /// The range.
        /// </value>
        private SqlRange Range { get; set; }

        /// <summary>
        /// Gets the token id.
        /// </summary>
        /// <value>
        /// The token id.
        /// </value>
        private TokenKind TokenId
        {
            get { return this.tokenId; }
        }

        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        private string Token
        {
            get { return this.token; }
        }

        /// <summary>
        /// Sets the line.
        /// </summary>
        /// <value>
        /// The line.
        /// </value>
        private string Line
        {
            set
            {
                this.Range = SqlRange.rsUnknown;
                this.line = value;
                this.run = 0;
                this.Next();
            }
        }

        #endregion

        #region public methods

        /// <summary>
        /// Standards the SQL.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <returns>standard SQL</returns>
        public string StandardSql(string sql)
        {
            StringBuilder result = new StringBuilder();
            this.Line = sql;
            while (this.TokenId != TokenKind.tkNull)
            {
                switch (this.TokenId)
                {
                    case TokenKind.tkNumber:
                    case TokenKind.tkString:
                        result.Append("<??>");
                        break;
                    default:
                        result.Append(this.Token);
                        break;
                }

                this.Next();
            }

            return result.ToString();
        }

        /// <summary>
        /// Fills the rich edit.
        /// </summary>
        /// <param name="rich">The rich.</param>
        /// <param name="value">The value.</param>
        public void FillRichEdit(System.Windows.Forms.RichTextBox rich, string value)
        {
            rich.Text = string.Empty;
            this.Line = value;

            RTFBuilder sb = new RTFBuilder { BackColor = rich.BackColor };
            while (this.TokenId != TokenKind.tkNull)
            {
                Color forecolor;
                switch (this.TokenId)
                {
                    case TokenKind.tkKey:
                        forecolor = Color.Blue;
                        break;
                    case TokenKind.tkFunction:
                        forecolor = Color.Fuchsia;
                        break;
                    case TokenKind.tkGreyKeyword:
                        forecolor = Color.Gray;
                        break;
                    case TokenKind.tkFuKeyword:
                        forecolor = Color.Fuchsia;
                        break;
                    case TokenKind.tkDatatype:
                        forecolor = Color.Blue;
                        break;
                    case TokenKind.tkNumber:
                        forecolor = Color.Red;
                        break;
                    case TokenKind.tkString:
                        forecolor = Color.Red;
                        break;
                    case TokenKind.tkComment:
                        forecolor = Color.DarkGreen;
                        break;
                    default:
                        forecolor = Color.Black;
                        break;
                }

                sb.ForeColor = forecolor;
                if (this.Token == Environment.NewLine || this.Token == "\r" || this.Token == "\n")
                {
                    sb.AppendLine();
                }
                else
                {
                    sb.Append(this.Token);
                }

                this.Next();
            }

            rich.Rtf = sb.ToString();
        }

        #endregion

        #region private methods

        /// <summary>
        /// Gets the char.
        /// </summary>
        /// <param name="idx">The index.</param>
        /// <returns>a character</returns>
        private char GetChar(int idx)
        {
            return idx >= this.line.Length ? '\x00' : this.line[idx];
        }

        /// <summary>
        /// Nulls the procedure.
        /// </summary>
        private void NullProc()
        {
            this.tokenId = TokenKind.tkNull;
        }

        /// <summary>
        /// LFs the procedure.
        /// </summary>
        private void LFProc()
        {
            this.tokenId = TokenKind.tkSpace;
            this.run++;
        }

        /// <summary>
        /// CRs the procedure.
        /// </summary>
        private void CRProc()
        {
            this.tokenId = TokenKind.tkSpace;
            this.run++;
            if (this.GetChar(this.run) == '\x0A')
            {
                this.run++;
            }
        }

        /// <summary>
        /// ANSIs the C procedure.
        /// </summary>
        private void AnsiCProc()
        {
            switch (this.GetChar(this.run))
            {
                case '\x00':
                    this.NullProc();
                    break;
                case '\x0A':
                    this.LFProc();
                    break;
                case '\x0D':
                    this.CRProc();
                    break;

                default:
                    {
                        this.tokenId = TokenKind.tkComment;
                        char c;
                        do
                        {
                            if (this.GetChar(this.run) == '*' && this.GetChar(this.run + 1) == '/')
                            {
                                this.Range = SqlRange.rsUnknown;
                                this.run += 2;
                                break;
                            }

                            this.run++;
                            c = this.GetChar(this.run);
                        }
                        while (!(c == '\x00' || c == '\x0A' || c == '\x0D'));
                        break;
                    }
            }
        }

        /// <summary>
        /// ASCIIs the char procedure.
        /// </summary>
        private void AsciiCharProc()
        {
            if (this.GetChar(this.run) == '\x00')
            {
                this.NullProc();
            }
            else
            {
                this.tokenId = TokenKind.tkString;
                if (this.run > 0 || this.Range != SqlRange.rsString || this.GetChar(this.run) != '\x27')
                {
                    this.Range = SqlRange.rsString;
                    char c;

                    do
                    {
                        this.run++;
                        c = this.GetChar(this.run);
                    }
                    while (!(c == '\x00' || c == '\x0A' || c == '\x0D' || c == '\x27'));

                    if (this.GetChar(this.run) == '\x27')
                    {
                        this.run++;
                        this.Range = SqlRange.rsUnknown;
                    }
                }
            }
        }

        /// <summary>
        /// Does the procedure table.
        /// </summary>
        /// <param name="chr">The CHR.</param>
        private void DoProcTable(char chr)
        {
            switch (chr)
            {
                case '\x00':
                    this.NullProc();
                    break;
                case '\x0A':
                    this.LFProc();
                    break;
                case '\x0D':
                    this.CRProc();
                    break;
                case '\x27':
                    this.AsciiCharProc();
                    break;
                case '=':
                    this.EqualProc();
                    break;
                case '>':
                    this.GreaterProc();
                    break;
                case '<':
                    this.LowerProc();
                    break;
                case '-':
                    this.MinusProc();
                    break;
                case '|':
                    this.OrSymbolProc();
                    break;
                case '+':
                    this.PlusProc();
                    break;
                case '/':
                    this.SlashProc();
                    break;
                case '&':
                    this.AndSymbolProc();
                    break;
                case '\x22':
                    this.QuoteProc();
                    break;
                case ':':
                case '@':
                    this.VariableProc();
                    break;
                case '^':
                case '%':
                case '*':
                case '!':
                    this.SymbolAssignProc();
                    break;
                case '{':
                case '}':
                case '.':
                case ',':
                case ';':
                case '?':
                case '(':
                case ')':
                case ']':
                case '~':
                    this.SymbolProc();
                    break;
                case '[':
                    this.BracketProc();
                    break;
                default:
                    this.DoInsideProc(chr);
                    break;
            }
        }

        /// <summary>
        /// Does the inside procedure.
        /// </summary>
        /// <param name="chr">The CHR.</param>
        private void DoInsideProc(char chr)
        {
            if ((chr >= 'A' && chr <= 'Z') || (chr >= 'a' && chr <= 'z') || (chr == '_') || (chr == '#'))
            {
                this.IdentProc();
                return;
            }

            if (chr >= '0' && chr <= '9')
            {
                this.NumberProc();
                return;
            }

            if ((chr >= '\x00' && chr <= '\x09') || (chr >= '\x0B' && chr <= '\x0C') || (chr >= '\x0E' && chr <= '\x20'))
            {
                this.SpaceProc();
                return;
            }

            this.UnknownProc();
        }

        /// <summary>
        /// Spaces the procedure.
        /// </summary>
        private void SpaceProc()
        {
            this.tokenId = TokenKind.tkSpace;
            char c;
            do
            {
                this.run++;
                c = this.GetChar(this.run);
            }
            while (!(c > '\x20' || c == '\x00' || c == '\x0A' || c == '\x0D'));
        }

        /// <summary>
        /// Unknowns the procedure.
        /// </summary>
        private void UnknownProc()
        {
            this.run++;
            this.tokenId = TokenKind.tkUnknown;
        }

        /// <summary>
        /// Numbers the procedure.
        /// </summary>
        private void NumberProc()
        {
            this.tokenId = TokenKind.tkNumber;
            if (this.GetChar(this.run) == '0' && (this.GetChar(this.run) == 'X' || this.GetChar(this.run) == 'x'))
            {
                this.run += 2;
                while (HexDigits.IndexOf(this.GetChar(this.run)) != -1)
                {
                    this.run++;
                }

                return;
            }

            this.run++;
            this.tokenId = TokenKind.tkNumber;
            while (NumberStr.IndexOf(this.GetChar(this.run)) != -1)
            {
                if (this.GetChar(this.run) == '.' && this.GetChar(this.run + 1) == '.')
                {
                    break;
                }

                this.run++;
            }
        }

        /// <summary>
        /// Quotes the procedure.
        /// </summary>
        private void QuoteProc()
        {
            this.tokenId = TokenKind.tkIdentifier;
            this.run++;
            while (!(this.GetChar(this.run) == '\x00' || this.GetChar(this.run) == '\x0A' || this.GetChar(this.run) == '\x0D'))
            {
                if (this.GetChar(this.run) == '\x22')
                {
                    this.run++;
                    break;
                }

                this.run++;
            }
        }

        /// <summary>
        /// Brackets the procedure.
        /// </summary>
        private void BracketProc()
        {
            this.tokenId = TokenKind.tkIdentifier;
            this.run++;
            while (!(this.GetChar(this.run) == '\x00' || this.GetChar(this.run) == '\x0A' || this.GetChar(this.run) == '\x0D'))
            {
                if (this.GetChar(this.run) == ']')
                {
                    this.run++;
                    break;
                }

                this.run++;
            }
        }

        /// <summary>
        /// Symbols the procedure.
        /// </summary>
        private void SymbolProc()
        {
            this.run++;
            this.tokenId = TokenKind.tkSymbol;
        }

        /// <summary>
        /// Symbols the assign procedure.
        /// </summary>
        private void SymbolAssignProc()
        {
            this.tokenId = TokenKind.tkSymbol;
            this.run++;
            if (this.GetChar(this.run) == '=')
            {
                this.run++;
            }
        }

        /// <summary>
        /// Keys the hash.
        /// </summary>
        /// <param name="pos">The position</param>
        private void KeyHash(int pos)
        {
            this.stringLen = 0;
            while (Array.BinarySearch(this.identifiersArray, this.GetChar(pos)) >= 0)
            {
                this.stringLen++;
                pos++;
            }

            return;
        }

        /// <summary>
        /// Indents the kind.
        /// </summary>
        /// <returns>indent kind</returns>
        private TokenKind IdentKind()
        {
            this.KeyHash(this.run);
            return this.tokens[this.line.Substring(this.tokenPos, this.run + this.stringLen - this.tokenPos)];
        }

        /// <summary>
        /// Indents the procedure.
        /// </summary>
        private void IdentProc()
        {
            this.tokenId = this.IdentKind();
            this.run += this.stringLen;
            if (this.tokenId == TokenKind.tkComment)
            {
                while (!(this.GetChar(this.run) == '\x00' || this.GetChar(this.run) == '\x0A' || this.GetChar(this.run) == '\x0D'))
                {
                    this.run++;
                }
            }
            else
            {
                while (IdentifierStr.IndexOf(this.GetChar(this.run)) != -1)
                {
                    this.run++;
                }
            }
        }

        /// <summary>
        /// Variables the procedure.
        /// </summary>
        private void VariableProc()
        {
            if (this.GetChar(this.run) == '@' && this.GetChar(this.run + 1) == '@')
            {
                this.run += 2;
                this.IdentProc();
            }
            else
            {
                this.tokenId = TokenKind.tkVariable;
                int i = this.run;
                do
                {
                    i++;
                }
                while (!(IdentifierStr.IndexOf(this.GetChar(i)) == -1));

                this.run = i;
            }
        }

        /// <summary>
        /// Ands the symbol procedure.
        /// </summary>
        private void AndSymbolProc()
        {
            this.tokenId = TokenKind.tkSymbol;
            this.run++;
            if (this.GetChar(this.run) == '=' || this.GetChar(this.run) == '&')
            {
                this.run++;
            }
        }

        /// <summary>
        /// Slashes the procedure.
        /// </summary>
        private void SlashProc()
        {
            this.run++;
            switch (this.GetChar(this.run))
            {
                case '*':
                    {
                        this.Range = SqlRange.rsComment;
                        this.tokenId = TokenKind.tkComment;
                        do
                        {
                            this.run++;
                            if (this.GetChar(this.run) == '*' && this.GetChar(this.run + 1) == '/')
                            {
                                this.Range = SqlRange.rsUnknown;
                                this.run += 2;
                                break;
                            }
                        }
                        while (!(this.GetChar(this.run) == '\x00' || this.GetChar(this.run) == '\x0D' || this.GetChar(this.run) == '\x0A'));
                    }

                    break;
                case '=':
                    this.run++;
                    this.tokenId = TokenKind.tkSymbol;
                    break;
                default:
                    this.tokenId = TokenKind.tkSymbol;
                    break;
            }
        }

        /// <summary>
        /// Pluses the procedure.
        /// </summary>
        private void PlusProc()
        {
            this.tokenId = TokenKind.tkSymbol;
            this.run++;
            if (this.GetChar(this.run) == '=' || this.GetChar(this.run) == '=')
            {
                this.run++;
            }
        }

        /// <summary>
        /// the symbol procedure.
        /// </summary>
        private void OrSymbolProc()
        {
            this.tokenId = TokenKind.tkSymbol;
            this.run++;
            if (this.GetChar(this.run) == '=' || this.GetChar(this.run) == '|')
            {
                this.run++;
            }
        }

        /// <summary>
        /// Minuses the procedure.
        /// </summary>
        private void MinusProc()
        {
            this.run++;
            if (this.GetChar(this.run) == '-')
            {
                this.tokenId = TokenKind.tkComment;
                char c;
                do
                {
                    this.run++;
                    c = this.GetChar(this.run);
                }
                while (!(c == '\x00' || c == '\x0A' || c == '\x0D'));
            }
            else
            {
                this.tokenId = TokenKind.tkSymbol;
            }
        }

        /// <summary>
        /// Lowers the procedure.
        /// </summary>
        private void LowerProc()
        {
            this.tokenId = TokenKind.tkSymbol;
            this.run++;
            switch (this.GetChar(this.run))
            {
                case '=':
                    this.run++;
                    break;
                case '<':
                    this.run++;
                    if (this.GetChar(this.run) == '=')
                    {
                        this.run++;
                    }

                    break;
            }
        }

        /// <summary>
        /// Greater procedure.
        /// </summary>
        private void GreaterProc()
        {
            this.tokenId = TokenKind.tkSymbol;
            this.run++;
            if (this.GetChar(this.run) == '=' || this.GetChar(this.run) == '>')
            {
                this.run++;
            }
        }

        /// <summary>
        /// Equals the procedure.
        /// </summary>
        private void EqualProc()
        {
            this.tokenId = TokenKind.tkSymbol;
            this.run++;
            if (this.GetChar(this.run) == '=' || this.GetChar(this.run) == '>')
            {
                this.run++;
            }
        }

        /// <summary>
        /// Next instance.
        /// </summary>
        private void Next()
        {
            this.tokenPos = this.run;
            switch (this.Range)
            {
                case SqlRange.rsComment:
                    this.AnsiCProc();
                    break;
                case SqlRange.rsString:
                    this.AsciiCharProc();
                    break;
                default:
                    this.DoProcTable(this.GetChar(this.run));
                    break;
            }

            this.token = this.line.Substring(this.tokenPos, this.run - this.tokenPos);
        }

        #endregion
    }
}