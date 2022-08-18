using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countdown
{
    static class Extensions
    {
        public static string Scramble(this string s)
        {
            return new string(s.ToCharArray().OrderBy(x => Guid.NewGuid()).ToArray());
        }

        public static int LengthIEnumerable(this IEnumerable<string> sarr)
        {
            int length = 0;

            foreach (string str in sarr)
            {
                length++;
            }

            return length;
        }

    }

    static class Questions
    {
        static Random random = new Random();

        public static bool AskWord()
        {
            string[] dictionary = System.IO.File.ReadAllLines(@"../../dict.txt");
            string question = "";

            for (int i = 0; i <= 9; i++)
            {
                Console.WriteLine("Vowel or Consonant? V / C: ");
                string cons_vowl = Console.ReadLine();
                if (cons_vowl.ToLower() == "v")
                {
                    int v = random.Next(4);
                    question += (v == 0) ? 'A' : (v == 1) ? 'E' : (v == 2) ? 'I' : (v == 3) ? 'O' : 'U';
                } else
                {
                    int v = random.Next(19);
                    question += (v == 0) ? 'B' : 
                        (v == 1) ? 'C' : 
                        (v == 2) ? 'D' : 
                        (v == 3) ? 'F' : 
                        (v == 4) ? 'G' : 
                        (v == 5) ? 'H' : 
                        (v == 6) ? 'J' : 
                        (v == 7) ? 'K' : 
                        (v == 8) ? 'L' : 
                        (v == 9) ? 'M' : 
                        (v == 10) ? 'N' : 
                        (v == 11) ? 'P' : 
                        (v == 12) ? 'Q' : 
                        (v == 13) ? 'R' : 
                        (v == 14) ? 'S' : 
                        (v == 15) ? 'T' : 
                        (v == 16) ? 'V' : 
                        (v == 17) ? 'W' : 
                        (v == 18) ? 'X' : 
                        (v == 19) ? 'Y' : 'Z';
                }
            }

            Console.WriteLine(question);

            Console.WriteLine("\nWord?: ");
            string psbword = Console.ReadLine();

            bool inDict = false;

            foreach (string str in dictionary) {
                if (str == psbword)
                {
                    inDict = true;
                    break;
                }
            }

            if (inDict)
            {
                string[] words = psbword.Split(' ');
                var result = words.Where(w => question.All(w.Contains));

                return Extensions.LengthIEnumerable(result) > 0;
            } else
            {
                Console.WriteLine("Word is not in dictionary.");
            }
            return false;
        }
    }

    class Program
    { 
        static void Main(string[] args)
        {
            if (Questions.AskWord())
            {
                Console.WriteLine("Correct!");
            }
        }
    }
}
