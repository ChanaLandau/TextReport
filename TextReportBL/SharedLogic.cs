using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace TextReportBL
{
   public static class SharedLogic
    {
        public static int GetText(string path)
        {
            
            AllLogic.GetLines(path);//1
            AllLogic.GetWords(path);//2
            AllLogic.GetUniqueWords(path);//3

            //4
            int sentenceCount = 0;
            String line;
            String delimiters = "?!.";

            for (int i = 0; i < File.ReadLines(path).Count(); i++)
            {
                 line = File.ReadLines(path).Skip(14).Take(1).First();
                for (int j = 0; j < line.Count(); j++)
                {
                   // if(line.Contains(delimiters)==true)
                    //if (delimiters.IndexOf(line.CharAt(i.ToString())) != -1)
                    //{ // If the delimiters string contains the character
                        

                    //}
                }
            }

            return 0;
        }
    }
}
