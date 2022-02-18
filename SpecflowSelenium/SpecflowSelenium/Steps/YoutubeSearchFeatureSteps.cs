using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SpecflowSelenium.Steps;

[Binding]
public class YoutubeSearchFeatureSteps
{
    private const string _name = "youtube";
    private const string _url = $"https://www.{_name}.com";
    private string _searchKeyword;

    private readonly ChromeDriver _chromeDriver;
    private readonly By _searchInputBy;
    private readonly By _searchButtonBy;
    private readonly By _agreeCookiesBy;
    private readonly By _searchContentBy;

    public YoutubeSearchFeatureSteps()
    {
        _chromeDriver = new ChromeDriver();
        _searchInputBy = By.Name("search_query");
        _searchButtonBy = By.Id("search-icon-legacy");
        _agreeCookiesBy = By.XPath("/html/body/ytd-app/ytd-consent-bump-v2-lightbox/tp-yt-paper-dialog/div[4]/div[2]/div[5]/div[2]/ytd-button-renderer[2]/a/tp-yt-paper-button/yt-formatted-string");
        _searchContentBy = By.XPath("//*[@id=\"page-manager\"]/ytd-search");
    }

    [Given(@"I have navigated to youtube website")]
    public void GivenIHaveNavigatedToYoutubeWebsite()
    {
        _chromeDriver.Navigate().GoToUrl(_url);

        Assert.IsTrue(_chromeDriver.Title.ToLower().Contains(_name));
    }

    [Given("I have to agree with youtube cookies")]
    public void GivenIHaveToAgreeWithYoutubeCookies()
    {
        // wait for the element to load
        var wait = new WebDriverWait(_chromeDriver, TimeSpan.FromSeconds(2));
        wait.Until(ExpectedConditions.ElementIsVisible(_agreeCookiesBy));

        var agreeCookiesButton = _chromeDriver.FindElement(_agreeCookiesBy);
        agreeCookiesButton.Click();
    }

    [Given(@"I have entered (.*) as youtube search keyword")]
    public void GivenIHaveEnteredPortugalAsYoutubeSearchKeyword(string searchString)
    {
        // wait for the element to load
        var wait = new WebDriverWait(_chromeDriver, TimeSpan.FromSeconds(2));
        wait.Until(ExpectedConditions.ElementIsVisible(_searchInputBy));

        _searchKeyword = searchString.ToLower();

        var searchInputBox = _chromeDriver.FindElement(_searchInputBy);
        searchInputBox.Click(); // focus search box
        searchInputBox.SendKeys(_searchKeyword);
    }

    [When(@"I press the youtube search button")]
    public void WhenIPressTheYoutubeSearchButton()
    {
        // wait for the element to load
        var wait = new WebDriverWait(_chromeDriver, TimeSpan.FromSeconds(2));
        wait.Until(ExpectedConditions.ElementIsVisible(_searchButtonBy));

        var searchInputBox = _chromeDriver.FindElement(_searchButtonBy);
        searchInputBox.Submit();
    }

    [Then(@"I should be navigate to youtube search results page")]
    public void ThenIShouldBeNavigateToYoutubeSearchResultsPage()
    {
        // wait for the element to load
        var wait = new WebDriverWait(_chromeDriver, TimeSpan.FromSeconds(2));
        wait.Until(ExpectedConditions.ElementIsVisible(_searchContentBy));

        // after search is complete the keyword should be present in url as well as page title
        Assert.IsTrue((_chromeDriver.Url.ToLower().Contains(_searchKeyword)));
        Assert.IsTrue((_chromeDriver.Title.ToLower().Contains(_searchKeyword)));
    }
}