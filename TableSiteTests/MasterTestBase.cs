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
    /// Base class for PL Pattern Library tests.
    /// Contains setup and teardown methods with scope to all PL Pattern Library Tests.
    /// Contains metods and properties with scope for all  PL Pattern Library Tests.
    /// All PL Pattern Library page should inheret from this class.
    /// </summary>
    [TestClass]
    public class MasterTestBase
    {
        public static NgWebDriver driver { get; set; }
        public static string nl { get { return System.Environment.NewLine; } }

        #region TestContext
        
        private TestContext _testContext;
        
        /// <summary> Provides information and functionality for the current test run. </summary>
        public TestContext TestContext { get { return _testContext; } set { _testContext = value; } }
        
        /// <summary> Provides information and functionality for the current test run. (Consise Name)</summary>
        public TestContext test { get { return _testContext; } }
        
        #endregion

        #region Timeout Values
        public static int 
            pageLoadTimeout = 31, 
            FindElementTimeout = 23, 
            RunScriptTimeout = 42;
        #endregion 

        public static string baseUrl { get { return "https://Patterns.PresenceLearning.com/"; } }
       
        #region Setup and Teardown

        #region Class Setup and Teardown
        [ClassInitialize()]
        public static void BaseClassIni(TestContext testContext) { }
        [ClassCleanup()]
        public static void BaseClassCleanup() { }
        #endregion
 
        #region Assembly Scope Setup and Teardown Methods
        [AssemblyInitialize]
        public static void AssemblyIni(TestContext testContext)
        {
            // ToDo: Check for orphaned browser driver exe's (Chrome, IE, Etc.) and terminate them.

            // Instantiate driver object // ToDo: Setup functionality to set driver type via config or at least a ENUM and variable
            driver = new NgWebDriver(new FirefoxDriver());

            //ngDriver.Url = baseUrl; // Fails with timeout error prior to opening page
            driver.WrappedDriver.Navigate().GoToUrl(baseUrl);

            #region Set Timeouts
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(RunScriptTimeout));
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(FindElementTimeout));
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(pageLoadTimeout));
            #endregion
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            driver.WrappedDriver.Quit();
            driver.WrappedDriver.Dispose();
            // ngDriver.Quit(); // Triggering detection of Firefox as not responding by windows error recovery.
        }
        #endregion 

        #region Test Setup and Teardown
        [TestInitialize()]
        public void BaseTestIni() { }
        [TestCleanup()]
        public void BaseTestCleanup() { }
        #endregion 

        #endregion
    }
}

