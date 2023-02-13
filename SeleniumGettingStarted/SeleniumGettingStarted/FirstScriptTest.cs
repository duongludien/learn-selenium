using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumGettingStarted;

[TestClass]
public class FirstScriptTest
{
    [TestMethod]
    public void ChromeSession()
    {
        var driver = new ChromeDriver();
        
        driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");
        
        Assert.AreEqual("Web form", driver.Title);

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

        var textBox = driver.FindElement(By.Name("my-text"));
        var submitButton = driver.FindElement(By.TagName("button"));
        
        textBox.SendKeys("Selenium");
        submitButton.Click();
        
        Assert.AreEqual("Received!", driver.FindElement(By.Id("message")).Text);
        
        driver.Quit();
    }
}