using System;
using System.Text.RegularExpressions;

namespace L6_EnglishToPigLatinTranslator
{
    class EnglishToPigLatinTranslator
    {
        static void Main(string[] args)
        {
            //initialize variables
            bool keepGoing = true;

            Console.WriteLine("Let's play with Pig Latin!");
            //Console.WriteLine("Enter a word or phase:");

            while (keepGoing)
            {
                //generate random number
                //int randNum = genRandNum();

                //get input, calculate and display the results
                ConvertInput(GetInput());

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

            Console.WriteLine("Enter a word or phrase:");
            input = Console.ReadLine();

            //check that there is actually some input
            if (input == "")
            {                
                return GetInput();
            }
            else { return input; }
        }

        public static string ConvertInput(string phrase)
        {
            string[] words = Regex.Split(phrase, "\\s");
            string[] vowel = {
                "e", "a", "o", "i", "u" , "E", "A", "O", "I", "U"
            };
            string[] consonant = {
               "t" , "n" , "s" , "r" , "h" , "l" , "d" , "c" , "m" , "f" , "p" ,
               "g" , "w" , "y" , "b" , "v" , "k" , "x" , "j" , "q" , "z" ,
               "T" , "N" , "S" , "R" , "H" , "L" , "D" , "C" , "M" , "F" , "P" ,
               "G" , "W" , "Y" , "B" , "V" , "K" , "X" , "J" , "Q" , "Z"
            };
            int firstVowel = 0;
            string moveLetters = "";

            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine("array:" + words[i]);
                //check for words starting with vowel
                foreach (string v in vowel)
                {
                    //check for words starting with vowel
                    if (words[i].Substring(0, 1).Contains(v))
                    {
                        words[i] = words[i] + "way";
                    }
                }
                //check for words starting with consanant
                foreach (string c in consonant)
                {                    
                    if (words[i].Substring(0, 1).Contains(c))
                    {
                        Console.WriteLine("before:" + words[i]);

                        foreach (string v in vowel)
                        {
                            if (words[i].Contains(v))
                            {
                                firstVowel = words[i].IndexOf(v);
                                moveLetters = words[i].Substring(0, firstVowel);
                                words[i] = words[i].Remove(0,firstVowel);
                                words[i] = words[i] + moveLetters;
                            }
                        }
                        words[i] = words[i] + "ay";
                        Console.WriteLine("after:" + words[i]);
                    }        
                }
            }
            return phrase;
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
