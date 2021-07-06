using System;

namespace HangmanGame
{
    class Program
    {
        static void Main(string[] args)
        {

            Hangman hangman = new Hangman();
            string line;
            int userChoice = 0;
            bool isIncorect;

            Console.WriteLine("HANGMAN GAME");

            Console.WriteLine("Press 1 to start game, 2 to see high score, 3 to exit a geme.");


            do {
                isIncorect = false;
                line = Console.ReadLine();
                try
                {
                    userChoice = int.Parse(line);
                    if(userChoice>3 || userChoice < 1)
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

            switch (userChoice)
            {
                case 1:
                    bool playNextGame = false;
                    do
                    {
                        hangman.StartGame();

                        do
                        {
                            

                            do
                            {
                                isIncorect = false;
                                Console.WriteLine("1-Gueess letter 2-Guess Word");
                                line= Console.ReadLine().ToString();
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

                            switch (userChoice)
                            {
                                case 1:
                                    isIncorect = false;
                                    Console.WriteLine("Enter the letter you are guessing: ");
                                    do
                                    {
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


                                    break;
                                case 2:
                                    isIncorect = false;
                                    Console.WriteLine("Enter the word you are guessing: ");
                                    do
                                    {
                                        line = Console.ReadLine();
                                        hangman.GuessWord(line);


                                    } while (isIncorect);

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
                            try {
                                option = int.Parse(line);
                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine("Incorect format try again.");
                                isIncorect = true;
                            }
                        } while (isIncorect);

                        if(option == 1)
                        {
                            playNextGame = true;
                        }
                        else
                        {
                            playNextGame = false;
                        }

                    } while (playNextGame);
                    break;

                case 2:

                    break;

                case 3:

                    break;
            }


            

        }
    }
}
