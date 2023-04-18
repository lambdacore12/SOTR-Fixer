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
            string[] shortcuts = new string[3]
            {
                "j",
                "l",
                "v"
            };

            string[] names = new string[3]
            {
                " John Mueller: ",
                " Lizzie Sassmann: ",
                " Vanessa Fox: "
            };

            List<SrtItems> srtItemsList = Extractor.Extract(path);

            //loop through all srt items
            for (int i = 0; i < srtItemsList.Count; ++i)
            {
                // this is the key letter to be checked
                string keyLetter = srtItemsList[i].SubLine[0][0].ToString().ToLower();

                //this is the space after after the key letter
                string keySpace = srtItemsList[i].SubLine[0][1].ToString();

                //loop through shortcuts to check if they exist
                for (int j = 0; j < shortcuts.Length; ++j)
                {   
                    //if they do exist
                    if (keyLetter == shortcuts[j] && keySpace == " ")
                    {
                        //if the key letter is 't', meaning a time indicator
                        if (keyLetter == "t")
                        {
                            //replace the key letter t in first line with "[substart0->8] (which extracts the time values)
                            string newLine = "[" + srtItemsList[i].SubStart.ToString().Substring(0, 8) + "]" + srtItemsList[i].SubLine[0].Remove(0, 1);
                            srtItemsList[i].SubLine[0] = newLine;
                        }
                        else
                        {
                            //same as above but the desired format of [time] name [time]
                            string time = "[" + srtItemsList[i].SubStart.ToString().Substring(0, 8) + "]";
                            string cleanLinestr4 = srtItemsList[i].SubLine[0].Remove(0, 1);
                            string str5 = time + names[j] + time + cleanLinestr4;
                            srtItemsList[i].SubLine[0] = str5;
                        }
                    }
                }
            }

            //create one string to hold all of the subtitle content
            string str = "";
            for (int k = 0; k < srtItemsList.Count; k++)
            {
                str += srtItemsList[k].LineCount + Environment.NewLine;
                str += srtItemsList[k].SubStart + " --> " + srtItemsList[k].SubEnd + Environment.NewLine;
                for (int z = 0; z < srtItemsList[k].SubLine.Count; z++)
                {
                    str += srtItemsList[k].SubLine[z] + Environment.NewLine;
                }
                str += Environment.NewLine;
            }

            return str;
        }
    }
}
