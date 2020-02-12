using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>() { "the", "bike", "this", "it", "tenth", "mathematics" };
            SubstringTH(words);

            List<string> names = new List<string>() { "Mike", "Brad", "Nevin", "Ian", "Mike" };
            DuplicateRemoval(names);

            List<string> classGrades = new List<string>()
            {
            "80,100,92,89,65",
            "93,81,78,84,69",
            "73,88,83,99,64",
            "98,100,66,74,55"
            };

            Console.WriteLine(GradeAverage(classGrades));
            Console.ReadLine();
            string name = "Terrill";
            Console.WriteLine(LetterCount(name));
            Console.ReadLine();

        }

        static List<string> SubstringTH(List<string> input)
        {
            return input.Where(x => x.Contains("th")).ToList();
        }

        static List<string> DuplicateRemoval(List<string> input)
        {
            return input.Distinct().ToList();
        }

        static double GradeAverage(List<string> input)
        {
            var output = input.Select(x => x.Split(',').Select(element => Convert.ToDouble(element)).ToList()).ToList();

            output = output.Where(x => x.Remove(x.Min())).ToList();

            var result = output.Select(x => x.Average());
            return result.Average();
        }

        static string LetterCount(string letters)
        {
            var sorted = letters.ToLower().ToCharArray().OrderBy(x => x).ToList();
            var counts = sorted.Distinct().ToList().Select(x => (sorted.LastIndexOf(x) - sorted.IndexOf(x)) + 1);
            return String.Join("", sorted.Distinct().ToList().Zip(counts, (x, y) => String.Concat(x, y)).ToList());

        }
    }
}
