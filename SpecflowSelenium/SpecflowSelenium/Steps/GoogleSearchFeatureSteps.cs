using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SpecflowSelenium.Steps;

[Binding]
public class GoogleSearchFeatureSteps
{
    private const string _name = "google";
    private const string _url = $"https://www.{_name}.com";
    private string _searchKeyword;
    
    private readonly ChromeDriver _chromeDriver;
    private readonly By _searchInputBy;
    private readonly By _agreeCookiesBy;
    
    public GoogleSearchFeatureSteps()
    {
        _chromeDriver = new ChromeDriver();
        _searchInputBy = By.Name("q");
        _agreeCookiesBy = By.XPath("/html/body/div[2]/div[2]/div[3]/span/div/div/div/div[3]/button[2]/div");
    }
    
    [Given(@"I have navigated to google website")]
    public void GivenIHaveNavigatedToGoogleWebsite()
    {
        _chromeDriver.Navigate().GoToUrl(_url);
        
        Assert.IsTrue(_chromeDriver.Title.ToLower().Contains(_name));
    }

    [Given("I have to agree with google cookies")]
    public void GivenIHaveToAgreeWithGoogleCookies()
    {
        // wait for the element to load
        var wait = new WebDriverWait(_chromeDriver, TimeSpan.FromSeconds(2));
        wait.Until(ExpectedConditions.ElementIsVisible(_agreeCookiesBy));

        var agreeCookiesButton = _chromeDriver.FindElement(_agreeCookiesBy);
        agreeCookiesButton.Click();
    }

    [Given(@"I have entered (.*) as google search keyword")]
    public void GivenIHaveEnteredPortugalAsGoogleSearchKeyword(string searchString)
    {
        _searchKeyword = searchString.ToLower();
        
        // wait for the element to load
        var wait = new WebDriverWait(_chromeDriver, TimeSpan.FromSeconds(2));
        wait.Until(ExpectedConditions.ElementIsVisible(_searchInputBy));
        
        var searchInputBox = _chromeDriver.FindElement(_searchInputBy);
        searchInputBox.SendKeys(_searchKeyword);
    }

    [When(@"I press the google search button")]
    public void WhenIPressTheGoogleSearchButton()
    {
        var searchInputBox = _chromeDriver.FindElement(_searchInputBy);
        searchInputBox.Submit();
    }

    [Then(@"I should be navigate to google search results page")]
    public void ThenIShouldBeNavigateToSearchResultsPage()
    {
        // after search is complete the keyword should be present in url as well as page title
        Assert.IsTrue((_chromeDriver.Url.ToLower().Contains(_searchKeyword)));
        Assert.IsTrue((_chromeDriver.Title.ToLower().Contains(_searchKeyword)));
    }
}