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

    static class Problems
    {
        static Random random = new Random();
        const int ITERATIONS = 10;

        public static bool AskWord()
        {
            string[] dictionary = System.IO.File.ReadAllLines(@"../../dict.txt");

            // Random line chosen
            string word = "";
            while (true)
            {
                word = dictionary[random.Next(0, dictionary.Length)];
                if (word.Length == 9)
                {
                    break;
                }
            }

            string question_word = Extensions.Scramble(word);

            Console.WriteLine("Word is: " + question_word);

            // Answer
            Console.WriteLine("\nAnswer: ");
            string psbword = Console.ReadLine();

            // Answer validation
            string[] words = psbword.Split(' ');
            var result = words.Where(w => word.All(w.Contains));

            return Extensions.LengthIEnumerable(result) > 0;
        }
    }

    class Program
    { 
        static void Main(string[] args)
        {
            
        }
    }
}
