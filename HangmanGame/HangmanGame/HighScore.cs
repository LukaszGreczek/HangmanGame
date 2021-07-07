using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HangmanGame
{
    class HighScore
    {
        SortedList<double,Result> results = new SortedList<double, Result>();

        public HighScore()
        {
            this.Read();
        }
        
        public void Add(string name, string date, double guessingTime, int guessingTries, string guessedWord)
        {
            if(!results.ContainsKey(guessingTime))
            results.Add(guessingTime,new Result(name, date, guessingTime, guessingTries, guessedWord));
            else
            {
                guessingTime += 0.01;
                this.Add(name, date, guessingTime, guessingTries, guessedWord);
            }

            this.Save();
        }

        public void Display()
        {
            IList<double> re = results.Keys;
            for (int j = 0; j < 10 && j < results.Count; j++) 
            {
                double i = re[j];
                Console.WriteLine("{0}|{1}|{2}|{3}|{4}", results[i].name , results[i].date, (int) results[i].guessingTime, results[i].guessingTries, results[i].guessedWord);
            }
        }

        public void Save()
        {
            if (File.Exists("HangmanHighScore.txt"))
            {
                File.Delete("HangmanHighScore.txt");
            }
            using (StreamWriter file  = new StreamWriter("HangmanHighScore.txt", append: true))
            {
                
                IList<double> re = results.Keys;
                for (int j = 0; j < 10 && j < results.Count; j++)
                {
                    double i = re[j];
                    file.WriteLine("{0}|{1}|{2}|{3}|{4}", results[i].name, results[i].date, results[i].guessingTime, results[i].guessingTries, results[i].guessedWord);
                }
                
            }

        }

        public void Read()
        {
            foreach (string line in File.ReadAllLines("HangmanHighScore.txt"))
            {
                string[] record = line.Split("|");
                this.Add(record[0], record[1], Double.Parse(record[2]), Int32.Parse(record[3]), record[4]);
            }
            
        }
    }
}
