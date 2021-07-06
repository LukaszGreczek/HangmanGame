using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanGame
{
    public class Hangman
    {
        Dictionary<string, string> capitalDictionary;
        List<string> nationList = new List<string>();
        List<char> notInWord = new List<char>();
        char[] guessedChars;
        Timer gameTimer = new Timer();
        Random random = new Random();
        String guessingNation;
        String guessingCapital;
        int lifeToken;
        int counter;

        public bool IsRunning { get; set; }



        public Hangman()
        {
            DataReader data = new DataReader();// create class DataReader 

            capitalDictionary = data.GetCapitalsDictionary(); // get all pair nation-country from DataReader(file)
            
            foreach (var item in capitalDictionary.Keys)
            {
                nationList.Add(item);
            }
        }

        public void StartGame()
        {
            notInWord.Clear();

            gameTimer.StartTimer();// starting timer

            guessingNation = nationList[random.Next(0, nationList.Count)]; //get random name of nation
            guessingCapital = capitalDictionary[guessingNation]; // get nation capital

            lifeToken = 5; //reset life 

            //create array containig hited letters
            guessedChars = new char[guessingCapital.Length];

            //fill array '_' when is letter and ' ' when is space
            for (int i = 0; i < guessingCapital.Length; i++)
            {
                if (guessingCapital[i] == ' ')
                {
                    guessedChars[i] = ' ';
                }
                else
                    guessedChars[i] = '_';
            }

            IsRunning = true;
        }



        public void GuessLetter(char letter) 
        {
            counter++; //incrise guessing counter

            //search letter in word and add to guessedChars array
            bool inWord = false;
            for (int i = 0; i < guessingCapital.Length; i++)
            {
                if(guessingCapital[i] == Char.ToUpper(letter) || guessingCapital[i] == Char.ToLower(letter))
                {
                    guessedChars[i] = guessingCapital[i];
                    inWord = true;
                }
            }

            if (inWord)
            {
                
                //is completed a word
                if (new String(guessedChars).Contains('_'))
                {
                    //word is not completed
                }
                else
                {
                    IsRunning = false;
                }
            }
            else
            {
                lifeToken--; //lose lifetoken
                notInWord.Add(Char.ToUpper(letter)); // add letter to not-in-word list
                notInWord.Sort(); // sort list
                IsAlive();
            }


        }

        public void GuessWord(string word)
        {
            counter++;
            if((word.ToLower()) == (guessingCapital.ToLower()))
            {
                for (int i = 0; i < guessingCapital.Length; i++)
                {
                    guessedChars[i] = guessingCapital[i];

                    IsRunning = false;
                }
            }
            else
            {
                lifeToken -= 2;
            }


        }

        public void IsAlive()
        {
            if (lifeToken <= 0)
                IsRunning = false;

        }

        public void Display()
        {
            Console.Clear();

            Console.Write("Guessing word: ");
            foreach (char letter in guessedChars)
            {
                Console.Write(letter);
            }
            this.ShowHint();

            foreach (char item in notInWord)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine($"Life: {lifeToken} ");

        }

        public void ShowHint()
        {
            if (lifeToken < 5)
            {
                Console.WriteLine();
                Console.WriteLine("Hint: The capital of {0}",guessingNation);
            }
        }


        public void EndGame()
        {

            gameTimer.EndTimer();
            if (lifeToken>0)
            {
                Console.WriteLine("You guessed the capital after {0} letters.It took you {1} seconds"
                    ,  gameTimer.DisplayTime(), counter);
            }
            else
            {
                Console.WriteLine("You lose. Game time {0} seconds Try count {1}"
                    , gameTimer.DisplayTime() , counter);
            }

        }
    }
}
