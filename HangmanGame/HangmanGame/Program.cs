using System;

namespace HangmanGame
{
    class Program
    {

        static void Main(string[] args)
        {
            
            Hangman hangman = new Hangman();



            int userChoice = 0;
            

            Console.WriteLine("HANGMAN GAME");
            
            while ((userChoice = MenuStart(userChoice)) !=3)
            {

                switch (userChoice)
                {
                    case 1:
                        PlayGame(hangman, userChoice);
                        break;

                    case 2:
                        hangman.DisplayHighScore();
                        break;

                }

                

            }

            Console.WriteLine("Goodbye!");

        }

        private static int MenuStart(int userChoice)
        {
            string line;
            bool isIncorect;
            Console.WriteLine("Press 1 to start game, 2 to see high score, 3 to exit a geme.");


            do
            {
                isIncorect = false;
                line = Console.ReadLine();
                try
                {
                    userChoice = int.Parse(line);
                    if (userChoice > 3 || userChoice < 1)
                    {
                        isIncorect = true;
                    }
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine("Incorect format try again.");
                    isIncorect = true;
                }


            } while (isIncorect);
            return userChoice;
        }

        private static void PlayGame(Hangman hangman, int userChoice)
        {
            bool isIncorect;
            string line;
            bool playNextGame = false;
            do
            {
                hangman.StartGame();

                do
                {
                    userChoice = LetterOrWord( userChoice);

                    switch (userChoice)
                    {
                        case 1:
                            GiveLetter(hangman);

                            break;
                        case 2:
                            GiveWord(hangman);

                            break;
                    }

                    hangman.Display();

                } while (hangman.IsRunning);
                hangman.EndGame();


                

                int option = 2;
                isIncorect = false;


                Console.WriteLine("1 - New Game 2 - Exit");
                do
                {
                    line = Console.ReadLine();
                    try
                    {
                        option = int.Parse(line);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine("Incorect format try again.");
                        isIncorect = true;
                    }
                } while (isIncorect);

                if (option == 1)
                {
                    playNextGame = true;
                }
                else
                {
                    playNextGame = false;
                }

            } while (playNextGame);
        }

        private static void GiveWord(Hangman hangman)
        {
            string line;
            Console.WriteLine("Enter the word you are guessing: ");

                line = Console.ReadLine();
                hangman.GuessWord(line);

        }

        private static void GiveLetter(Hangman hangman)
        {
            string line;
            bool isIncorect;
            Console.WriteLine("Enter the letter you are guessing: ");
            do
            {
                isIncorect = false;
                line = Console.ReadLine();
                if (Char.IsLetter(line[0]))
                {
                    hangman.GuessLetter(line[0]);
                }
                else
                {
                    Console.WriteLine("Incorect format try again.");
                    isIncorect = true;
                }

            } while (isIncorect);
        }

        private static int LetterOrWord(int userChoice)
        {
            bool isIncorect;
            string line;
            do
            {
                isIncorect = false;
                Console.WriteLine("1-Gueess letter 2-Guess Word");
                line = Console.ReadLine().ToString();
                try
                {
                    userChoice = int.Parse(line);
                    if (userChoice > 2 || userChoice < 1)
                    {
                        isIncorect = true;
                    }
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine("Incorect format try again.");
                    isIncorect = true;

                }

            } while (isIncorect);
            return userChoice;
        }


    }
}
