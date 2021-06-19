using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FindReferences
{
    class Program
    {
        static List<string> result = new();
        static List<string[]> SearchTask = new();
        static string[] allFiles;
        static string Searchkeyword = string.Empty;
        static async Task Main(string[] args)
        {
            try
            {
                //GetFiles
                Console.WriteLine("Enter File Path: ");
                string path = Console.ReadLine();
                allFiles = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

                //GetSearchkeyword
                Console.WriteLine("Enter Search Content:  ");
                Searchkeyword = Console.ReadLine();

                //Searching Process
                await DivideTaskAndExecute();

                Console.Clear();
                Console.WriteLine($"\n\nCompleted Total Result Found = { result.Count}\nPress Enter to See Result");

                //Final Result
                await PrintResult();
            }
            catch (Exception exp) { Console.WriteLine(exp.ToString()); }
        }

        public static async Task DivideTaskAndExecute()
        {
            if (string.IsNullOrEmpty(Searchkeyword)) return;
            if (allFiles.Length <= 20) { await FindRefereces(allFiles); return; }

            Console.Write("\nPlease Wait Searching.... ");
            int size = allFiles.Length / 20;
            while (allFiles.Length > 0)
            {
                string[] temp = allFiles.Take(size).Select(i => i.ToString()).ToArray();
                SearchTask.Add(temp);
                allFiles = allFiles.Where(x => !temp.Contains(x)).ToArray();
            }
            
            Searchkeyword = Searchkeyword.ToLower();
            var task1 = FindRefereces(SearchTask.ElementAt(0));
            var task2 = FindRefereces(SearchTask.ElementAt(1));
            var task3 = FindRefereces(SearchTask.ElementAt(2));
            var task4 = FindRefereces(SearchTask.ElementAt(3));
            var task5 = FindRefereces(SearchTask.ElementAt(4));
            var task6 = FindRefereces(SearchTask.ElementAt(5));
            var task7 = FindRefereces(SearchTask.ElementAt(6));
            var task8 = FindRefereces(SearchTask.ElementAt(7));
            var task9 = FindRefereces(SearchTask.ElementAt(8));
            var task10 = FindRefereces(SearchTask.ElementAt(9));
            var task11 = FindRefereces(SearchTask.ElementAt(10));
            var task12 = FindRefereces(SearchTask.ElementAt(11));
            var task13 = FindRefereces(SearchTask.ElementAt(12));
            var task14 = FindRefereces(SearchTask.ElementAt(13));
            var task15 = FindRefereces(SearchTask.ElementAt(14));
            var task16 = FindRefereces(SearchTask.ElementAt(15));
            var task17 = FindRefereces(SearchTask.ElementAt(16));
            var task18 = FindRefereces(SearchTask.ElementAt(17));
            var task19 = FindRefereces(SearchTask.ElementAt(18));
            var task20 = FindRefereces(SearchTask.ElementAt(19));
            var task21 = FindRefereces(SearchTask.ElementAt(20));
            await Task.WhenAll(task1, task2, task3, task4, task5, task6, task7, task8, task9, task10,
           task11, task12, task13, task14, task15, task16, task17, task18, task19, task20, task21);
        }

        public static async Task FindRefereces(string[] Files)
        {
            Parallel.ForEach(Files, file =>
            {
                bool found = File.ReadAllText(file).ToLower().Contains(Searchkeyword.Trim());
                if (found) result.Add(file);
            });
            await Task.CompletedTask;
        }

        public static async Task PrintResult()
        {
            Console.ReadLine();
            Parallel.ForEach(result, r => { Console.WriteLine(r); });
            await Task.CompletedTask;
        }
    }
}
