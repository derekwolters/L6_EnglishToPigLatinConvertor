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
                "a", "e", "i", "o", "u" , "A", "E", "I", "O", "U"
            };
            string[] consonant = {
               "t" , "n" , "s" , "r" , "h" , "l" , "d" , "c" , "m" , "f" , "p" ,
               "g" , "w" , "y" , "b" , "v" , "k" , "x" , "j" , "q" , "z" ,
               "T" , "N" , "S" , "R" , "H" , "L" , "D" , "C" , "M" , "F" , "P" ,
               "G" , "W" , "Y" , "B" , "V" , "K" , "X" , "J" , "Q" , "Z"
            };

            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine("array:" + words[i]);
                //check for words starting with vowel
                foreach (string v in vowel)
                {
                    //check for words starting with vowel
                    if (words[i].Substring(0, 1).Contains(v))
                    {
                        Console.WriteLine("before:" + words[i]);
                        words[i] = words[i] + "way";
                        Console.WriteLine("after:" + words[i]);
                    }
                }
                //check for words starting with consanant
                foreach (string c in consonant)
                {
                    
                    if (words[i].Substring(0, 1).Contains(c))
                    {
                        Console.WriteLine("before:" + words[i]);
                        words[i] = words[i] + "way";
                        Console.WriteLine("after:" + words[i]);
                    }
                        
                   
                }
            }
            
            //foreach (string word in words)
            //{
            //    Console.WriteLine("1st foreach: " + word);
            //    foreach (string x in vowels)
            //    {
            //        Console.WriteLine("vowel:" + x);
            //        Console.WriteLine("2nd foreach: " + word);
            //        Console.WriteLine("substring: " + word.Substring(0, 1));
            //        if (word.Substring(0,1).Contains(x))
            //        {                        
            //            Console.WriteLine("before:" + word);
            //            word.Replace(word , word + "way");
            //            Console.WriteLine("after:" + word);
            //        }
            //    }
            //}

            

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
