using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
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
    /// Contains tests specific to the https://patterns.presencelearning.com/table page
    /// </summary>
    [TestClass]
    public class TableTests : MasterTestBase
    {
        #region Setup and Teardown
        [ClassInitialize()]
        public static void ClassIni(TestContext testContext) 
        {
            Pages.TablesPage tPage = new TablesPage(driver);
            driver.WrappedDriver.Navigate().GoToUrl(tPage.url);

            driver.WrappedDriver.Manage().Window.Maximize();
        }

        [ClassCleanup()]
        public static void ClassCleanup() { }
        #region Test setup and teardown
        [TestInitialize()]
        public void TestIni() { }
        [TestCleanup()]
        public void TestCleanup() { }
        #endregion 
        #endregion

        #region ╔═══─▶ Test Methods ◀️─════╗

        [TestMethod, TestCategory("Selenium"), TestCategory("Protractor"), TestCategory("Regression"), TestCategory("DataTable"), TestCategory("PlPatternLibrary")]
        public void ToggleFiltersTest()
        {
            TestContext.WriteLine(nl + "↘ ☑ ⏩ ToggleFiltersTest() ⏪ ☒ ↙" + nl);

            #region Table Page
            {
                test.WriteLine("📄 Table Page");
                TablesPage tablesPage = new TablesPage(driver);
                tablesPage.btnToggleFilters.Click();
            }
            #endregion
        }

        [TestMethod, TestCategory("Selenium"), TestCategory("Protractor"), TestCategory("Regression"), TestCategory("DataTable"), TestCategory("PlPatternLibrary")]
        public void SortByFistNameTest()
        {
            TestContext.WriteLine(nl + "↘ ☑ ⏩ SortByFistNameTest() ⏪ ☒ ↙" + nl);

            #region Table Page
            {
                test.WriteLine("📄 Table Page");
                TablesPage tablesPage = new TablesPage(driver);

                #region Switch to 100 Items Per Page 
                tablesPage.selItemsPerPage.Click();
                tablesPage.selItemsPerPage100Option.Click();
                #endregion 

                test.WriteLine(" ∘ Clicking First Name table column header. ");
                tablesPage.thFirstName.Click();

                string sortOrder = tablesPage.thFirstName.GetAttribute("aria-sort");
                if (sortOrder != "ascending")
                {
                    test.WriteLine(" ∘ Clicking First Name table column header again to set as descending. ");
                    tablesPage.thFirstName.Click();
                }
                
                #region Verify Sort
                List<String> firstNamesRaw = new List<string>();
                List<String> firstNames = new List<string>();

                try
                {
                    for (int i = 1; i <= 100; i++)
                    {
                        firstNamesRaw.Add(tablesPage.tdFirstName(i).Text);
                        firstNames.Add(tablesPage.tdFirstName(i).Text);
                    }
                }
                catch (OpenQA.Selenium.NoSuchElementException) { } // in case there are less then 100 rows

                firstNames.Sort();

                for (int i = 1; i <= firstNamesRaw.Count; i++)
                {
                    if (firstNames[i] != firstNamesRaw[i])
                    {
                        Assert.Fail("First Names were not sorted as expected. ");
                    }
                }
                #endregion 
            }
            #endregion
        }

        [TestMethod, TestCategory("Selenium"), TestCategory("Protractor"), TestCategory("Regression"), TestCategory("DataTable"), TestCategory("PlPatternLibrary")]
        public void SortByLastNameTest()
        {
            TestContext.WriteLine(nl + "↘ ☑ ⏩ SortByLastNameTest() ⏪ ☒ ↙" + nl);

            #region Table Page
            {
                test.WriteLine("📄 Table Page");
                TablesPage tablesPage = new TablesPage(driver);

                TestContext.WriteLine(" ∘ Clicking Last Name Column Header");
                tablesPage.thLastName.Click();
            }
            #endregion
        }

        [TestMethod, TestCategory("Selenium"), TestCategory("Protractor"), TestCategory("Regression"), TestCategory("DataTable"), TestCategory("PlPatternLibrary")]
        public void SortByBirthdateTest()
        {
            TestContext.WriteLine(nl + "↘ ☑ ⏩ SortByBirthdateTest() ⏪ ☒ ↙" + nl);

            #region Table Page
            {
                test.WriteLine("📄 Table Page");
                TablesPage tablesPage = new TablesPage(driver);
                tablesPage.thBirthdate.Click();
            }
            #endregion
        }

        [TestMethod, TestCategory("Selenium"), TestCategory("Protractor"), TestCategory("Regression"), TestCategory("DataTable"), TestCategory("PlPatternLibrary")]
        public void SortByStatusTest()
        {
            TestContext.WriteLine(nl + "↘ ☑ ⏩ SortByStatusTest() ⏪ ☒ ↙" + nl);

            #region Table Page
            {
                test.WriteLine("📄 Table Page");
                TablesPage tablesPage = new TablesPage(driver);
                tablesPage.thStatus.Click();
            }
            #endregion 
        }

        #region Filtering Tests
        // ToDo: Use a JQuery DataTables Javascript call to populate a System.Data.DataTable object to facilitate dynamic verification of the rendered dataset

        [TestMethod, TestCategory("Selenium"), TestCategory("Protractor"), TestCategory("Regression"), TestCategory("DataTable"), TestCategory("PlPatternLibrary")]
        public void FilterByFirstNameTest()
        {
            test.WriteLine(nl + "↘ ☑ ⏩ FilterByFirstNameTest() ⏪ ☒ ↙" + nl);

            string filterText = "ar";

            #region Table Page
            {
                test.WriteLine("📄 Table Page");
                TablesPage tablesPage = new TablesPage(driver);

                bool filtersDisplayed = tablesPage.selName.Location.X != 0;
                if (filtersDisplayed == false)
                {
                    test.WriteLine(" ∘ Clicking “Toggle Filters” button ");
                    tablesPage.btnToggleFilters.Click(); Thread.Sleep(200);
                }

                test.WriteLine(" ∘ Selecting “First Name” ");
                tablesPage.selName.Click();
                tablesPage.selNameFirstNameOption.Click();

                test.WriteLine(" ∘ Typing Filter: “" + filterText + "” ");
                tablesPage.txtEnterData.SendKeys(filterText);

                #region Verify filtered results
                try
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        bool containsFilter = tablesPage.tdFirstName(i).Text.ToLower().Contains(filterText.ToLower());
                        test.WriteLine(" ∘ Row " + i + " First Name “" + tablesPage.tdFirstName(i).Text + "” contains “" + filterText + "” = " + containsFilter.ToString());
                        if (containsFilter == false)
                        {
                            Assert.Fail(" ∘ Filter text “" + filterText + "” not found within “" + tablesPage.tdFirstName(i).Text + "” as expected ");
                        }
                    }
                }
                catch (OpenQA.Selenium.NoSuchElementException) { } // As I expect the dataset to be dynamic receiving less result rows than expected should not cause the test to fail
                #endregion 
            }
            #endregion 
        }

        [TestMethod, TestCategory("Selenium"), TestCategory("Protractor"), TestCategory("Regression"), TestCategory("DataTable"), TestCategory("PlPatternLibrary")]
        public void FilterByLastNameTest()
        {
            string filterText = "ee";

            TestContext.WriteLine(nl + "↘ ☑ ⏩ FilterByLastNameTest() ⏪ ☒ ↙" + nl);

            #region Table Page
            {
                test.WriteLine("📄 Table Page");
                TablesPage tablesPage = new TablesPage(driver);

                bool filtersDisplayed = tablesPage.selName.Location.X != 0;
                if (filtersDisplayed == false)
                {
                    test.WriteLine(" ∘ Clicking “Toggle Filters” button ");
                    tablesPage.btnToggleFilters.Click();
                }

                test.WriteLine(" ∘ Selecting “Last Name”");
                tablesPage.selName.Click();
                tablesPage.selNameLastNameOption.Click();

                test.WriteLine(" ∘ Typing Filter: “" + filterText + "” ");
                tablesPage.txtEnterData.SendKeys(filterText);

                #region Verify filtered results
                try
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        bool containsFilter = tablesPage.tdLastName(i).Text.ToLower().Contains(filterText.ToLower());
                        test.WriteLine(" ∘ Row " + i + " Last Name “" + tablesPage.tdLastName(i).Text + "” contains “" + filterText + "” = " + containsFilter.ToString());
                        if (containsFilter == false)
                        {
                            Assert.Fail(" ∘ Filter text “" + filterText + "” not found within “" + tablesPage.tdLastName(i).Text + "” as expected ");
                        }
                    }
                }
                catch (OpenQA.Selenium.NoSuchElementException) { } // As I expect the dataset to be dynamic receiving less result rows than expected should not cause the test to fail
                #endregion 
            }
            #endregion
        }

        [TestMethod, TestCategory("Selenium"), TestCategory("Protractor"), TestCategory("Regression"), TestCategory("DataTable"), TestCategory("PlPatternLibrary")]
        public void Select25ItemsPerPageTest()
        {
            TestContext.WriteLine(nl + "↘ ☑ ⏩ Select25ItemsPerPageTest() ⏪ ☒ ↙" + nl);

            #region Table Page
            {
                test.WriteLine("📄 Table Page");
                TablesPage tablesPage = new TablesPage(driver);

                tablesPage.selItemsPerPage.Click();
                tablesPage.selItemsPerPage25Option.Click();

                #region Verify 25 rows showing
                test.WriteLine(" ∘ Verifying Expected Number of Rows: ");
                test.WriteLine("┌──────────────────────────────────────────────────────────────────────────────────┐ ");
                test.WriteLine("{0,-2} {1,-12} {2,-23} {3, -12} {4,-42} {5,-2}", "│", "FirstName", "LastName", "Birthdate", "Status", "│");

                int i = 1;
                try
                {
                    for (i=1;i<=25;i++)
                    {
                        string fName = tablesPage.tdFirstName(i).Text,
                            lName = tablesPage.tdLastName(i).Text,
                            Birthdate = tablesPage.tdBirthdate(i).Text,
                            status = tablesPage.tdStatus(i).Text;

                        test.WriteLine("{0,-2} {1,-12} {2,-23} {3, -12} {4,-42} {5,-2}", "│", fName, lName, Birthdate, status, "│");
                    }
                }
                catch (OpenQA.Selenium.NoSuchElementException Ex)
                {
                    throw new AssertFailedException("Row: " + i + " was not found. ", Ex);
                }
                test.WriteLine("└──────────────────────────────────────────────────────────────────────────────────┘ ");
                #endregion
            }
            #endregion

        }

        #endregion 

        #endregion ╚═ ═ ═ ═ ═ ═╝

    }
}

#region 'Unicode Markup Symbols to Increade Readability
//─▶▷▻ ◈ ◅◁◀️─
// ➫
//╔══╗
//║  ║
//╚══╝
//┏━┓
//┃  ┃
//┗━┛
// “ ”
// ⇽⇾⇿
// ←↑→↓↔↕↖↗↘↙
// ∘
// ⌨ - Keyboard
// ⎔ - Software Function

// TestContext.WriteLine(nl + "↘ ☑ ⏩ FilterByLastNameTest() ⏪ ☒ ↙" + nl);
// TestContext.WriteLine(" ∘ ");

// ╚═ ═ ═ ═ ═ ═╝
#endregion 