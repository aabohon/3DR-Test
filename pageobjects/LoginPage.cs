using System;
using OpenQA.Selenium;


namespace _3dLoginTest.PageObjects
{   
    class LoginPage
    {

        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement LoginEmail => driver.FindElement(By.CssSelector("input[data-test='login-email']"));
        IWebElement LoginPassword => driver.FindElement(By.CssSelector("input[data-test='login-password']"));
        IWebElement LoginError => driver.FindElement(By.CssSelector("div[data-test='login-error']"));
        
        public void LoginApp(string userName, string password)
        {
            LoginEmail.SendKeys(userName);
            LoginPassword.SendKeys(password);
            LoginPassword.SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public string GetDisplayedError()
        {
            return LoginError.Text;
        }
    }
}

