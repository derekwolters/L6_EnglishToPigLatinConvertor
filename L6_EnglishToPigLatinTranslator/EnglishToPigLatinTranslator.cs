using System;

namespace L6_EnglishToPigLatinTranslator
{
    class EnglishToPigLatinTranslator
    {
        static string[] vowels = {
                "e", "a", "o", "i", "u" , "E", "A", "O", "I", "U"
            };
        static string[] consonants = {
               "t" , "n" , "s" , "r" , "h" , "l" , "d" , "c" , "m" , "f" , "p" ,
               "g" , "w" , "y" , "b" , "v" , "k" , "x" , "j" , "q" , "z" ,
               "T" , "N" , "S" , "R" , "H" , "L" , "D" , "C" , "M" , "F" , "P" ,
               "G" , "W" , "Y" , "B" , "V" , "K" , "X" , "J" , "Q" , "Z"
            };
        static string[] numschars =
        {
                "0" , "1" , "2" , "3" , "4" , "5" , "6" , "7" , "8" , "9" ,
                "$" , "+" , "@" , "-"
            };

        static string[] punctuation = {"." , "!" , "?" , ":" , ";"};

        static void Main(string[] args)
        {
            //initialize variables
            bool keepGoing = true;

            Console.WriteLine("Let's play with Pig Latin!");
            //Console.WriteLine("Enter a word or phase:");

            while (keepGoing)
            {
                //generate random number

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
            string[] words = phrase.Split(' ');
            int firstVowelLoc = 0;
            string moveLetters = "";

            //check if words contain a number or character
            for (int i = 0; i < words.Length; i++)
            {
                               
                
                
                
                //check if words contain a number or character
                foreach (string n in numschars)
                {                    
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

                       // words[i] = MoveEndPunctuation(words[i]);
                    }
                    else
                    {
                        continue;
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
                                firstVowelLoc = words[i].IndexOf(v);
                                moveLetters = words[i].Substring(0, firstVowelLoc);
                                words[i] = words[i].Remove(0,firstVowelLoc);
                                words[i] = words[i] + moveLetters;
                            }
                        }
                        words[i] = words[i] + "ay";

                        
                    }        
                }
                words[i] = MoveEndPunctuation(words[i]);
            }
            return string.Join(" ",words);
        }

        public static string MoveEndPunctuation(string checkWord)
        {
            int punctLoc = 0;
            string moveLetters = "";

            foreach (string p in punctuation)
            {
                if (checkWord.Contains(p))
                {
                    punctLoc = checkWord.IndexOf(p);
                    moveLetters = checkWord.Substring(punctLoc, 1);
                    checkWord = checkWord.Remove(punctLoc, 1);
                    checkWord = checkWord + moveLetters;
                }                
            }
            return checkWord;
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
