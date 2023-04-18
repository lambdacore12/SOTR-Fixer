using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOTR_Fixer.Classes
{
    internal class SrtItems
    {
        private readonly string[] delimiter = new string[4] { "-->", "->", "- >", "-- >" };

        private int lineCount = 0;
        private string subStart;
        private string subEnd;
        private List<string> subLine = new List<string>();

        public string[] Delimiter => this.delimiter;

        public int LineCount
        {
            get => this.lineCount;
            set => this.lineCount = value;
        }

        public string SubStart
        {
            get => this.subStart;
            set => this.subStart = value;
        }

        public string SubEnd
        {
            get => this.subEnd;
            set => this.subEnd = value;
        }

        public List<string> SubLine
        {
            get => this.subLine;
            set => this.subLine = value;
        }

        public string[] Split(string line)
        {
            string[] strArray = line.Split(this.Delimiter, StringSplitOptions.None);
            return new string[2] { strArray[0].Trim(), strArray[1].Trim() };
        }
    }
}
