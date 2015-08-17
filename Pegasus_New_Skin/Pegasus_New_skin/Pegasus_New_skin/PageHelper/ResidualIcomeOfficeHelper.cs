using System;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using LinqToExcel;
using System.IO;
using PegasusTests.PageHelper.Comm;
using PegasusTests.Locators;

namespace PegasusTests.PageHelper
{
    public class ResidualIcomeOfficeHelper : DriverHelper
    {
        public LocatorReader locatorReader;

        public ResidualIcomeOfficeHelper(IWebDriver idriver)
            : base(idriver)
        {
            locatorReader = new LocatorReader("ResidualIncomeOfficeNewSkin.xml");
        }

// ###########################  XML  ##############


        //Type into given xml node
        public void TypeText(string Field, string text)
        {
            var locator = locatorReader.ReadLocator(Field);
            WaitForElementPresent(locator, 20);
            SendKeys(locator, text);
        }

        //Verify text of given xml node
        public void VerifyText(string XmlNode, string text)
        {
            var locator = locatorReader.ReadLocator(XmlNode);
            var value = GetText(locator);         
            Assert.IsTrue(value.Contains(text));
        }

        //Get Value
        public void VerifyValue(string Field , string Text)
    {
        var locator = locatorReader.ReadLocator(Field);
        var value = GetValue(locator);
        Assert.IsTrue(value.Contains(Text));
    }



        //Select by value
        public void Select(string xmlNode, string value)
        {
            var locator = locatorReader.ReadLocator(xmlNode);
            SelectDropDown(locator, value);
        }

        //Click 

        public void ClickElement(string xmlNode)
        {
            var locator = locatorReader.ReadLocator(xmlNode);
            WaitForElementPresent(locator, 20);
            Click(locator);
        }

        internal void MouseHover(string field)
        {
            var locator = locatorReader.ReadLocator(field);
            WaitForElementPresent(locator, 20);
            MouseOver(locator);
        }

        internal void redirectToPage()
        {
            GetWebDriver()
                .Navigate()
                .GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/partners/agents");
        }


        public void SelectByText(string xmlNode, string text)
        {
            var locator = locatorReader.ReadLocator(xmlNode);
            SelectDropDownByText(locator, text);
        }

        public FileInfo Getnewfilename(DirectoryInfo directory)
        {
            Thread.Sleep(3000);
            return directory.GetFiles().Union(directory.GetDirectories().Select(d => Getnewfilename(d)))
                .OrderByDescending(f => (f == null ? DateTime.MinValue : f.LastWriteTime))
                .FirstOrDefault();
        }

        public string CurrentUser()
        {
            string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string user = username.Substring(username.LastIndexOf('\\') + 1);
            Console.WriteLine(user);
            return user;
        }

    }
}