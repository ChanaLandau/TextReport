using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextReportBL
{
    public static class AllLogic
    {
        public static int GetLines(string path)
        {
            return File.ReadLines(path).Count();
        }
        public static int GetWords(string path)
        {
            string line;
            int wordsCount = 0;

            using (StreamReader file = File.OpenText(path))
            {
                do
                {
                    line = file.ReadLine();
                    if (line != null)
                    {
                        wordsCount += line.Split(' ').Length;
                    }
                }
                while (line != null);
            }
            return wordsCount;
        }
        public static int GetUniqueWords(string path)
        {
            string text = File.ReadAllText(path);
            IEnumerable<string> allWords = text.Split(' ');
            int uniqueWords = allWords.GroupBy(w => w).Where(g => g.Count() == 1).Count();
            return uniqueWords;
        }

    }
}
