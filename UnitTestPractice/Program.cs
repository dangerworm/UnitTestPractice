using System;
using System.Text;

namespace UnitTestPractice
{
    public class Program
    {
        static void Main(string[] args)
        {
            var reader = new WikipediaReader();
            var responseTask = reader.SearchTitles("JSON");
            responseTask.Wait();

            var result = responseTask.Result;

            foreach(var searchResult in result.Query.Search)
            {
                Console.Write(searchResult.Title + ": ");
                Console.WriteLine(searchResult.Snippet);
                Console.WriteLine();
            }
        }
    }
}