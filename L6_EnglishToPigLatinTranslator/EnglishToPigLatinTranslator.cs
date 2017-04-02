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
                Console.WriteLine(ConvertInput(GetInput()));

                

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
            string[] vowels = {
                "e", "a", "o", "i", "u" , "E", "A", "O", "I", "U"
            };
            string[] consonants = {
               "t" , "n" , "s" , "r" , "h" , "l" , "d" , "c" , "m" , "f" , "p" ,
               "g" , "w" , "y" , "b" , "v" , "k" , "x" , "j" , "q" , "z" ,
               "T" , "N" , "S" , "R" , "H" , "L" , "D" , "C" , "M" , "F" , "P" ,
               "G" , "W" , "Y" , "B" , "V" , "K" , "X" , "J" , "Q" , "Z"
            };
            string[] numschars =
            {
                "0" , "1" , "2" , "3" , "4" , "5" , "6" , "7" , "8" , "9" ,
                "$" , "+" , "@" , "-"
            };
            
            int firstVowel = 0;
            string moveLetters = "";

            //check if words contain a number or character
            for (int i = 0; i < words.Length; i++)
            {
                //check if words contain a number or character
                foreach (string n in numschars)
                {
                    //check for words starting with vowel
                    if (words[i].Contains(n))
                    {
                        i++;
                        continue;
                    }
                }

                //check for words starting with vowel
                foreach (string v in vowels)
                {
                    //check for words starting with vowel
                    if (words[i].Substring(0, 1).Contains(v))
                    {
                        words[i] = words[i] + "way";
                    }
                }
                
                //check for words starting with consanant
                foreach (string c in consonants)
                {                    
                    if (words[i].Substring(0, 1).Contains(c))
                    {
                        foreach (string v in vowels)
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
                    }        
                }


            }
            return string.Join(" ",words);
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
