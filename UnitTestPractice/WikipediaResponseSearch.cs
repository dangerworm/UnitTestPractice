using System;

namespace UnitTestPractice
{
    public class WikipediaResponseSearch
    {
        public int Ns { get; set; }
        public string Title { get; set; }
        public int PageId { get; set; }
        public int Size { get; set; }
        public int WordCount { get; set; }
        public string Snippet { get; set; }
        public DateTime Timestamp { get; set; }
    }
}