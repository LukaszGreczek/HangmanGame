using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanGame
{
    public class Hangman
    {
        Dictionary<string, string> CapitalDictionary;

        public Hangman()
        {
            DataReader data = new DataReader();
            CapitalDictionary = data.GetCapitalsDictionary();
        }

    }
}
