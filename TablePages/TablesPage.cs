using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
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

namespace Pages
{
    public class TablesPage : PresenceLearningComPage
    {
        public TablesPage(NgWebDriver driver) : base(driver)
        {
            url = "https://patterns.presencelearning.com/table";
            title = "PL Pattern Library";
        }

        #region   ╔════════════─▶ 𝗣𝖆𝖌𝖊 𝗘𝖑𝖊𝖒𝖊𝖓𝖙𝖘 ◀️─══════════════╗

        public NgWebElement lnkAddFilter { get { return driver.FindElement(By.CssSelector("button[ng-click='addFilterRow()'")); } }

        #region    ╔═══─▶ 𝔽ilt𝖊r ∩ ℇl𝖊m𝖊nt𝓼 ◀️─════╗
        public NgWebElement selName { get { return driver.FindElement(By.CssSelector(".pl-table-filter-row > span:nth-child(1) > div:nth-child(1) > select:nth-child(1)")); } }
        public NgWebElement selNameFirstNameOption { get { return driver.FindElement(By.CssSelector(".ready-to-open > div:nth-child(2) > div:nth-child(2) > div:nth-child(2) > div:nth-child(1)")); } }
        public NgWebElement selNameLastNameOption { get { return driver.FindElement(By.CssSelector(".ready-to-open > div:nth-child(2) > div:nth-child(2) > div:nth-child(2) > div:nth-child(2)")); } }


        public NgWebElement selItemsPerPage { get { return driver.FindElement(By.CssSelector(".pl-paging-size > div:nth-child(1) > div:nth-child(2) > div:nth-child(1)")); } } 
        public NgWebElement selItemsPerPage25Option { get { return driver.FindElement(By.CssSelector("body > main > div > div > section > div > div:nth-child(2) > div > pl-table > div > div.pl-table-main > div.pl-pagination-bar.ng-scope > span.pl-paging-size > div > div > div.options-container > div.options > div:nth-child(3)")); } }
        public NgWebElement selItemsPerPage100Option { get { return driver.FindElement(By.CssSelector("body > main > div > div > section > div > div:nth-child(2) > div > pl-table > div > div.pl-table-main > div.pl-pagination-bar.ng-scope > span.pl-paging-size > div > div > div.options-container > div.options > div:nth-child(5)")); } }

        public NgWebElement selSubSetTypeOperator { get { return driver.FindElement(By.CssSelector("span[class='pl-table-filter-element'")); } }

        public NgWebElement txtEnterData { get { return driver.FindElement(By.CssSelector("input[placeholder^='Enter']")); } }

        #endregion ╚════════════════════════════════╝

        #region ╓──── →  𝗕utton Ⓔlements ← ───╖
        public NgWebElement btnNextPage { get { return driver.FindElement(By.CssSelector("button[class='link next']")); } }
        public NgWebElement btnLastPage { get { return driver.FindElement(By.CssSelector("button[class='link']")); } }
        public NgWebElement btnToggleFilters { get { return driver.FindElement(By.CssSelector("button[ng-click*='toggleShowFilters']")); } }
        #endregion

        #region ╓───── → 𝓣able 𝔼𝕝ement𝕤 ⟨Properties and Methods⟩ ← ────╖
        public NgWebElement tblPeopleData { get { return driver.FindElement(By.CssSelector("table[id='DataTables_Table_0']")); } }

        public NgWebElement thFirstName { get { return driver.FindElement(By.CssSelector("th[aria-label^='First Name']")); } }
        public NgWebElement thLastName { get { return driver.FindElement(By.CssSelector("th[aria-label^='Last Name']")); } }
        public NgWebElement thBirthdate { get { return driver.FindElement(By.CssSelector("th[aria-label^='Birthdate']")); } }
        public NgWebElement thStatus { get { return driver.FindElement(By.CssSelector("th[aria-label^='Status']")); } }

        public NgWebElement tblFirstNameR1 { get { return driver.FindElement(By.CssSelector("tbody > tr:nth-child(1) > td:nth-child(1)")); } }
        public NgWebElement tblLastNameR1 { get { return driver.FindElement(By.CssSelector("tbody > tr:nth-child(1) > td:nth-child(2)")); } }
        public NgWebElement tblBirthDateR1 { get { return driver.FindElement(By.CssSelector("tbody > tr:nth-child(1) > td:nth-child(3)")); } }
        public NgWebElement tblStatusR1 { get { return driver.FindElement(By.CssSelector("tbody > tr:nth-child(1) > td:nth-child(4)")); } }

        public NgWebElement tdFirstName(int row)
        {
            return driver.FindElement(By.CssSelector("tbody > tr:nth-child(" + row + ") > td:nth-child(1)")); // #DataTables_Table_2 > tbody > tr:nth-child(1) > td.sorting_1
        }

        public NgWebElement tdLastName(int row)
        {
            return driver.FindElement(By.CssSelector("tbody > tr:nth-child(" + row + ") > td:nth-child(2)"));
        }

        public NgWebElement tdBirthdate(int row)
        {
            return driver.FindElement(By.CssSelector("tbody > tr:nth-child(" + row + ") > td:nth-child(3)"));
        }

        public NgWebElement tdStatus(int row)
        {
            return driver.FindElement(By.CssSelector("tbody > tr:nth-child(" + row + ") > td:nth-child(4)"));
        }
        #endregion
        #endregion ╚═════════════════════════════════════════════╝
    }
}
