using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3dLoginTest.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace _3dLoginTest
{
    [TestClass]
    public class LoginTest
    {
        IWebDriver driver;
        LoginPage page;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver(@"C:\Users\Alain\Desktop\Selenium\bin\Debug\netcoreapp2.1");
            driver.Navigate().GoToUrl("https://sitescan-staging.3dr.com/auth");
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void LoginTest1()
        {
            page = new LoginPage(driver);
            page.LoginApp("simple@test.com", "jude");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Assert.AreEqual("Incorrect username or password",page.GetDisplayedError());
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Close();
        }
    }
}
