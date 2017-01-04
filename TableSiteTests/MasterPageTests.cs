using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// Local
using Pages;
// NuGet
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using Protractor;


namespace TableSiteTests 
{
    /// <summary>
    /// Contains tests specific to the https://patterns.presencelearning.com master page
    /// </summary>
    [TestClass]
    public class MasterPageTests : MasterTestBase
    {
        #region Setup and Teardown
        [ClassInitialize()]
        public static void ClassIni(TestContext testContext) { }

        [ClassCleanup()]
        public static void ClassCleanup() { }
        
        [TestInitialize()]
        public void TestIni() { }
     
        [TestCleanup()]
        public void TestCleanup() { }
        #endregion

        #region Test Methods
        [TestMethod, TestCategory("Selenium"), TestCategory("Protractor"), TestCategory("Regression"), TestCategory("PlPatternLibrary")]
        public void PageLdTest()
        {
            // table Page
            {
                TablesPage tablesPage = new TablesPage(driver);

                driver.WrappedDriver.Url = baseUrl;

                if (driver.Title.Contains(tablesPage.title) == false)
                    Assert.Fail("Failed to find expected page title: " + tablesPage.title);
            }
        }

        #region Top Tabs
        [TestMethod, TestCategory("Selenium"), TestCategory("Protractor"), TestCategory("Regression"), TestCategory("TopTabs"), TestCategory("PlPatternLibrary")]
        public void PrinciplesTabTest()
        {
            // table Page
            {
                TablesPage tablesPage = new TablesPage(driver);
                tablesPage.TabPrinciples.Click();
            }

        }

        [TestMethod, TestCategory("Selenium"), TestCategory("Protractor"), TestCategory("Regression"), TestCategory("TopTabs"), TestCategory("PlPatternLibrary")]
        public void ButtonsTabTest()
        {
            // table Page
            {
                TablesPage tablesPage = new TablesPage(driver);
                tablesPage.TabButtons.Click();
            }
        }

        [TestMethod, TestCategory("Selenium"), TestCategory("Protractor"), TestCategory("Regression"), TestCategory("TopTabs"), TestCategory("PlPatternLibrary")]
        public void ColorsTabTest()
        {
            // table Page
            {
                TablesPage tablesPage = new TablesPage(driver);
                tablesPage.TabColors.Click();
            }
        }

        [TestMethod, TestCategory("Selenium"), TestCategory("Protractor"), TestCategory("Regression"), TestCategory("TopTabs"), TestCategory("PlPatternLibrary")]
        public void GridTabTest()
        {
            // table Page
            {
                TablesPage tablesPage = new TablesPage(driver);
                tablesPage.TabGrid.Click();
            }
        }

        [TestMethod, TestCategory("Selenium"), TestCategory("Protractor"), TestCategory("Regression"), TestCategory("TopTabs"), TestCategory("PlPatternLibrary")]
        public void InputsTabTest()
        {
            // table Page
            {
                TablesPage tablesPage = new TablesPage(driver);
                tablesPage.TabInputs.Click();
            }
        }

        [TestMethod, TestCategory("Selenium"), TestCategory("Protractor"), TestCategory("Regression"), TestCategory("TopTabs"), TestCategory("PlPatternLibrary")]
        public void MiscTabTest()
        {
            // table Page
            {
                TablesPage tablesPage = new TablesPage(driver);
                tablesPage.TabMisc.Click();
            }
        }

        [TestMethod, TestCategory("Selenium"), TestCategory("Protractor"), TestCategory("Regression"), TestCategory("TopTabs"), TestCategory("PlPatternLibrary")]
        public void NavsTabTest()
        {
            // table Page
            {
                TablesPage tablesPage = new TablesPage(driver);
                tablesPage.TabNavs.Click();
            }
        }

        [TestMethod, TestCategory("Selenium"), TestCategory("Protractor"), TestCategory("Regression"), TestCategory("TopTabs"), TestCategory("PlPatternLibrary")]
        public void OverlaysTabTest()
        {
            // table Page
            {
                TablesPage tablesPage = new TablesPage(driver);
                tablesPage.TabOverlays.Click();
            }
        }

        [TestMethod, TestCategory("Selenium"), TestCategory("Protractor"), TestCategory("Regression"), TestCategory("TopTabs"), TestCategory("PlPatternLibrary")]
        public void TablesTabTest()
        {
            // table Page
            {
                TablesPage tablesPage = new TablesPage(driver);
                tablesPage.TabTables.Click();
            }
        }

        [TestMethod, TestCategory("Selenium"), TestCategory("Protractor"), TestCategory("Regression"), TestCategory("TopTabs"), TestCategory("PlPatternLibrary")]
        public void TypographyTabTest()
        {
            // table Page
            {
                TablesPage tablesPage = new TablesPage(driver);
                tablesPage.TabTypography.Click();
            }
        }
        #endregion 
        #endregion
    }
}

