using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static int GetInput()
        {
            string input = "";
            int temp;

            input = Console.ReadLine();

            if (!int.TryParse(input, out temp))
            {
                //check that input is an integer & ask for reentry if not
                Console.WriteLine("Input should be a whole number. " +
                    "Try again.");
                return GetInput();
            }
            else if (temp < minNum || temp > maxNum)
            {
                //check that input is withing range & ask for reentry if not
                Console.WriteLine("Input should between 1 and 100");
                return GetInput();
            }
            else { return temp; }
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
