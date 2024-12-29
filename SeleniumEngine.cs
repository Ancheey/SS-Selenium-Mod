using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniteSeaExecutor;

namespace SS_Selenium_Mod
{
    public static class SeleniumEngine
    {
        private static IWebDriver? _driver;
        public static IWebDriver Driver
        {
            get
            {
                _driver ??= new ChromeDriver(ExeCore.LocalDirectory + "/mods/webdrivers");
                return Driver;
            }
        }
        public static void Dispose() => _driver?.Dispose();
    }
}
