using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SearchModuleEngine.InputData;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace SearchModuleEngine.Pages
{
    internal class TestPage
    {
        public TestPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            PageFactory.InitElements(driver, this);
        }

        ArticuleDetails _articleDetails = new ArticuleDetails();

        private IWebDriver driver;
        private WebDriverWait wait;

        private static string url = "https://recruitment.gobasic.dk/test";

        [FindsBy(How = How.XPath, Using = "//div[@class='search form-group']/input")]
        private IWebElement SearchField;

        [FindsBy(How = How.XPath, Using = "//div[@class='search form-group']/button")]
        private IWebElement SearchButton;

        [FindsBy(How = How.XPath, Using = "//a[@class='btn dropdown-toggle']")]
        private IWebElement TypeDropDown;

        [FindsBy(How = How.Id, Using = "year-filter-selection")]
        private IWebElement YearDropDown;

        [FindsBy(How = How.XPath, Using = "//h3[@class='heading']/a")]
        private IList<IWebElement> Headers;
        public SelectElement YearDropDownList
        {
            get { return new SelectElement(YearDropDown); }
        }

        public TestPage GoToTestPage() 
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            wait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
            return this;
        }

        public TestPage SearchArticle(string text, string articleType, string year)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(SearchButton));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", SearchButton);
            if (text != String.Empty)
            {
                SearchField.SendKeys(text);
                SearchButton.Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//span[@class='label' and text() = '{text}']")));
            }
            if (articleType != null)
            {
                TypeDropDown.Click();
                string dataId = getArticleId(articleType);
                driver.FindElement(By.XPath($"//a[@data-id='{dataId}']")).Click();
            }
            if (year != null)
            {
                YearDropDownList.SelectByValue(year);
            }
            return this;
        }

        public TestPage GetArticleHeaders(out List<string> articleHeaders)
        {
            
            Thread.Sleep(120);
            articleHeaders = new List<string>();
            if (Headers.Count>0)
            { 
                articleHeaders = Headers.Select(x => x.Text).ToList(); 
            }
            return this;
        }

        public TestPage MakeSureThatREsultListIsAsExpected(List<string> actualResult, List<string> expectedResult)
        {
            bool listsAreEqual = actualResult.OrderBy(x => x).SequenceEqual(expectedResult.OrderBy(x => x));
            listsAreEqual.Should().BeTrue();
            return this;
        }

        private string getArticleId(string articleType)
        {
            return _articleDetails.ArticleId.FirstOrDefault(x => x.Key == articleType).Value;
        }

    }
}
