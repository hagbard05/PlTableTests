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
    public class Page
    {
        public string url { get; set; }
        public string title { get; set; }
        public NgWebDriver driver { get; set; }

        public Page(NgWebDriver driver)
        {
            this.driver = driver;
        }

    }
}
