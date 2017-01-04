using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
// NuGet
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using Protractor;

namespace Pages
{
    public class PresenceLearningComPage : Page
    {
        public PresenceLearningComPage(NgWebDriver driver) : base(driver)
        {
            url = "https://patterns.presencelearning.com/";
            title = "PL Pattern Library";
        }

        #region 𝓟𝔞𝖌𝓮 𝐄l𝓮m𝓮nt𝔰
        public NgWebElement TabPrinciples { get { return driver.FindElement(By.CssSelector("a[ui-sref='docs.principles']")); } }
        public NgWebElement TabTypography { get { return driver.FindElement(By.CssSelector("a[ui-sref='docs.typography']")); } }
        public NgWebElement TabColors { get { return driver.FindElement(By.CssSelector("a[ui-sref='docs.colors']")); } }
        public NgWebElement TabGrid { get { return driver.FindElement(By.CssSelector("a[ui-sref='docs.grid']")); } }
        public NgWebElement TabButtons { get { return driver.FindElement(By.CssSelector("a[ui-sref='docs.buttons']")); } }
        public NgWebElement TabInputs { get { return driver.FindElement(By.CssSelector("a[ui-sref='docs.inputs']")); } }
        public NgWebElement TabNavs { get { return driver.FindElement(By.CssSelector("a[ui-sref='docs.navs']")); } }
        public NgWebElement TabOverlays { get { return driver.FindElement(By.CssSelector("a[ui-sref='docs.overlays']")); } }
        public NgWebElement TabTables { get { return driver.FindElement(By.CssSelector("a[ui-sref='docs.table']")); } }
        public NgWebElement TabMisc { get { return driver.FindElement(By.CssSelector("a[ui-sref='docs.misc']")); } }
        #endregion 
    }
}
