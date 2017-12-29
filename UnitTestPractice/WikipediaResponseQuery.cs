using System.Collections.Generic;

namespace UnitTestPractice
{
    public class WikipediaResponseQuery
    {
        public WikipediaResponseSearchInfo SearchInfo { get; set; }
        public List<WikipediaResponseSearch> Search { get; set; }
    }
}