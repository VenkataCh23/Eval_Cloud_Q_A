using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;

class CloudQaAutomation
{
    static void Main()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();

        try
        {
            driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");

            IWebElement heading = driver.FindElement(By.XPath("//h1[contains(text(),'IFrame without ID')]"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", heading);
            Thread.Sleep(2000);

            driver.Navigate().GoToUrl("https://app.cloudqa.io/Home/IFrame");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));

            IWebElement firstName = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='fname']")));
            firstName.Clear();
            firstName.SendKeys("Venkata");
            Thread.Sleep(1000);

            IWebElement lastName = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='lname']")));
            lastName.Clear();
            lastName.SendKeys("Charan");
            Thread.Sleep(1000);

            IWebElement maleRadio = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='male']")));
            if (!maleRadio.Selected)
                maleRadio.Click();
            Thread.Sleep(1000);

            IWebElement dobField = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='dob']")));
            dobField.Clear();
            dobField.SendKeys("1999-10-11");
            Thread.Sleep(1000);

            IWebElement countryDropdown = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='state']")));
            SelectElement selectCountry = new SelectElement(countryDropdown);
            selectCountry.SelectByText("India");
            Thread.Sleep(1000);

            IWebElement agreeCheckbox = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='Agree']")));
            if (!agreeCheckbox.Selected)
                agreeCheckbox.Click();
            Thread.Sleep(1000);

            IWebElement submitButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='automationtestform']/div[4]/button[1]")));
            submitButton.Click();
            Thread.Sleep(1000);

            Console.WriteLine("Form submitted successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            System.Threading.Thread.Sleep(3000);
            driver.Quit();
        }
    }
}
