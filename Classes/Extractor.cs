using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOTR_Fixer;


namespace SOTR_Fixer.Classes
{
    internal class Extractor
    {
        public static List<SrtItems> Extract(string filePath)
        {
            List<SrtItems> srtItemsList = new List<SrtItems>();
            StreamReader streamReader = new StreamReader(filePath);
            string s = streamReader.ReadLine();
            using (streamReader)
            {
                while (s != null)
                {
                    SrtItems srtItems = new SrtItems();
                    string str1;
                    if (s != null || s != "\n")
                        srtItems.LineCount = int.Parse(s);
                    else
                        str1 = streamReader.ReadLine();
                    string line = streamReader.ReadLine();
                    string[] strArray = srtItems.Split(line);
                    srtItems.SubStart = strArray[0];
                    srtItems.SubEnd = strArray[1];
                    string str2 = streamReader.ReadLine();
                    srtItems.SubLine.Add(str2);
                    string str3 = streamReader.ReadLine();
                    if (!string.IsNullOrEmpty(str3))
                    {
                        srtItems.SubLine.Add(str3);
                        srtItemsList.Add(srtItems);
                        str1 = streamReader.ReadLine();
                        s = streamReader.ReadLine();
                    }
                    else
                    {
                        srtItemsList.Add(srtItems);
                        s = streamReader.ReadLine();
                    }
                }
            }
            return srtItemsList;
        }



    }
}
