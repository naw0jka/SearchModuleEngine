using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SearchModuleEngine.InputData.TestCaseSource;
using SearchModuleEngine.Pages;

namespace SearchModuleEngine.Tests
{
    [TestFixture]
    public class SearchEngineTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp() => _driver = new ChromeDriver();

        [TearDown]
        public void Teardown() => _driver.Quit();

        [TestCaseSource(typeof(SearchEngineInputData),nameof(SearchEngineInputData.SearchEngineTestCase))]
        [Test]
        public void SearchengineTest(string text, string articleType, string year, List<string> expectedHeaders)
        {
            new TestPage(_driver)
                .GoToTestPage()
                .SearchArticle(text, articleType, year)
                .GetArticleHeaders(out var articleHeaders)
                .MakeSureThatREsultListIsAsExpected(articleHeaders, expectedHeaders);
        }



    }
}