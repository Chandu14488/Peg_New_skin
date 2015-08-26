using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using PegasusTests.PageHelper.Comm;
using OpenQA.Selenium.Support.UI;
using PegasusTests.Locators;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace PegasusTests.PageHelper
{
    public class ActivitiesHelperNewSkin : DriverHelper
    {
        public LocatorReader locatorReader;

        public ActivitiesHelperNewSkin(IWebDriver idriver)
            : base(idriver)
        {
            locatorReader = new LocatorReader("ActivitiesOfficeNewSkin.xml");
        }

        //Click to given xml node
        public void ClickElement(string XmlNode)
        {
            String locator = locatorReader.ReadLocator(XmlNode);
            Click(locator);
        }

        //Type into given xml node
        public void TypeText(string XmlNode, string text)
        {
            String locator = locatorReader.ReadLocator(XmlNode);
            SendKeys(locator, text);
        }

        //Verify text of given xml node
        public void VerifyText(string XmlNode, string text)
        {
            String locator = locatorReader.ReadLocator(XmlNode);
            String value = GetText(locator);
            Assert.IsTrue(value.Contains(text));
        }

        public void Select(string Field, string value)
    {
        var locator = locatorReader.ReadLocator(Field);
        SelectDropDown(locator, value);

    
    }


        public void selectByText(string dropdown, string text)
        {
            var locator = locatorReader.ReadLocator(dropdown);
            WaitForElementVisible(locator, 30);
            SelectDropDownByText(locator, text);

        }

        public void uniqueDocAvaile(string doc)
        {
            string locator = "//a[contains(text(),'"+doc+"')]";
            WaitForWorkAround(1000);
            Assert.IsTrue(IsElementPresent(locator));
        }

        public string getFiledText(string field)
        {
            var locator = locatorReader.ReadLocator(field);
            WaitForElementVisible(locator,20);
            return GetValue(locator);

        }

        public void verifyOneNotDeletable()
        {
            string locator = "//table[@class='table']/tbody/tr";
            WaitForElementVisible(locator, 20);
            int x = XpathCount(locator);
            string locator2 = "//td/a[@title='Delete Document']";
            WaitForElementVisible(locator2, 20);
            int y = XpathCount(locator2);
            Assert.IsTrue(x > y);
        }
    }


}