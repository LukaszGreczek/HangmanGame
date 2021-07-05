using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanGame
{
    public class DataReader
    {
        string[] dataFormFile;

        public DataReader()
        {
            GetDataFromFile();
        }

        private void GetDataFromFile() {
            dataFormFile = System.IO.File.ReadAllLines(@"C:\Users\Toru\Desktop\HangmanGame\HangmanGame\HangmanGame\countries_and_capitals.txt");
        }

        public Dictionary<string, string> GetCapitalsDictionary()
        {
            Dictionary<string, string> tmpCapitalDictionary = new Dictionary<string, string>();

            foreach (string line in dataFormFile)
            {
                string[] lineValue = line.Split(" | ");
                tmpCapitalDictionary.Add(lineValue[0], lineValue[1]);
            }

            return tmpCapitalDictionary;
        }

    }
}
