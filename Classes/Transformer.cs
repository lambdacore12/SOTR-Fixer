using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOTR_Fixer.Classes
{
    internal class Transformer
    {
        public static string Transform(string path)
        {
            string[] strArray1 = new string[4]
            {
                "j",
                "l",
                "v",
                "t"
            };
            string[] strArray2 = new string[3]
            {
                " John Mueller: ",
                " Lizzie Sassmann: ",
                " Vanessa Fox: "
            };
            List<SrtItems> srtItemsList = Extractor.Extract(path);
            for (int index1 = 0; index1 < srtItemsList.Count; ++index1)
            {
                string lower = srtItemsList[index1].SubLine[0][0].ToString().ToLower();
                string str1 = srtItemsList[index1].SubLine[0][1].ToString();
                for (int index2 = 0; index2 < strArray1.Length; ++index2)
                {
                    if (lower == strArray1[index2] && str1 == " ")
                    {
                        if (lower == "t")
                        {
                            string str2 = "[" + srtItemsList[index1].SubStart.ToString().Substring(0, 8) + "]" + srtItemsList[index1].SubLine[0].Remove(0, 1);
                            srtItemsList[index1].SubLine[0] = str2;
                        }
                        else
                        {
                            string str3 = "[" + srtItemsList[index1].SubStart.ToString().Substring(0, 8) + "]";
                            string str4 = srtItemsList[index1].SubLine[0].Remove(0, 1);
                            string str5 = str3 + strArray2[index2] + str3 + str4;
                            srtItemsList[index1].SubLine[0] = str5;
                        }
                    }
                }
            }
            string str = (string)null;
            foreach (SrtItems srtItems in srtItemsList)
                str = str + srtItems.LineCount.ToString() + Environment.NewLine + srtItems.SubStart + " --> " + srtItems.SubEnd + Environment.NewLine + srtItems.SubLine[0] + Environment.NewLine + Environment.NewLine;
            return str;
        }
    }
}
