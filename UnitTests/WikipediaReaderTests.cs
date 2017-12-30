using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestPractice;

namespace UnitTests
{
    [TestClass]
    public class WikipediaReaderTests
    {
        [TestMethod]
        public async Task TestSearchTitles()
        {
            var reader = new WikipediaReader();
            Assert.IsNotNull(reader);

            WikipediaSearchResult result;
            foreach (var value in new[] { null, "", " ", "" })
            {
                await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () =>
                {
                    await reader.SearchTitles(value);
                });
            }

            result = await reader.SearchTitles("Archer");
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Query.Search.Count > 0);

            var output = result.Query.Search.Count;

            Debug.WriteLine(output);
        }
    }
}
