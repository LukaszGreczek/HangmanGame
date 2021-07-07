using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanGame
{
    class Result
    {
        public string name, date, guessedWord;
        public int  guessingTries;
        public double guessingTime;
        public Result(string name,string date, double guessingTime, int guessingTries, string guessedWord)
        {
            this.name = name;
            this.date = date;
            this.guessingTime = guessingTime;
            this.guessingTries = guessingTries;
            this.guessedWord = guessedWord;
        }

    }
}
