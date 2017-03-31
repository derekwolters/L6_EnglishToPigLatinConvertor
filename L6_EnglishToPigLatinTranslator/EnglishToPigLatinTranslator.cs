using System;

namespace L6_EnglishToPigLatinTranslator
{
    class EnglishToPigLatinTranslator
    {
        static void Main(string[] args)
        {
            //initialize variables
            bool keepGoing = true;

            Console.WriteLine("Let's play with Pig Latin!");
            Console.WriteLine("Enter a word or phase:");

            while (keepGoing)
            {
                //generate random number
                int randNum = genRandNum();

                //get input, calculate and display the results
                CheckInput(GetInput(), randNum);

                //exit program               
                if (ExitProgram())
                {
                    Console.WriteLine("Goodbye!");
                    System.Threading.Thread.Sleep(1000);
                    break;
                }
            }
        }

        public static String GetInput()
        {
            string input = "";
           
            input = Console.ReadLine();

            //check that there is actually some input
            if (input == "")
            {                
                Console.WriteLine("You need to enter a word or phrase!");
                return GetInput();
            }
            else { return input; }
        }

        public static string ConvertInput()
        {
            return string phrase;
        }

        //exit the program when the user wants to
        public static Boolean ExitProgram()
        {
            Console.WriteLine("Do you want to continue? Enter Y or N.");
            var KP = Console.ReadKey(true);

            while (KP.Key != ConsoleKey.N && KP.Key != ConsoleKey.Y)
            {
                Console.WriteLine("Not a vaid answer. Do you want to " +
                    "continue? Enter Y or N.");
                KP = Console.ReadKey(true);
            }

            return KP.Key == ConsoleKey.N ? true : false;
        }
    }
}
