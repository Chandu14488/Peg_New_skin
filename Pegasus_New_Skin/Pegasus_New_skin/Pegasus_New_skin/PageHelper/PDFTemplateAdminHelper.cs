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
    public class PDFTemplateAdminHelper : DriverHelper
    {
        public LocatorReader locatorReader;

        public PDFTemplateAdminHelper(IWebDriver idriver)
            : base(idriver)
        {
            locatorReader = new LocatorReader("PDFTemplateNewSkin.xml");
        }

        //Click to given xml node
        public void ClickElement(string XmlNode)
        {
            String locator = locatorReader.ReadLocator(XmlNode);
            WaitForElementEnabled(locator, 30);
            WaitForElementVisible(locator, 30);
            Click(locator);
        }

        //Type into given xml node
        public void TypeText(string XmlNode, string text)
        {
            String locator = locatorReader.ReadLocator(XmlNode);
            WaitForElementPresent(locator, 30);
            WaitForElementVisible(locator, 30);
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
        WaitForElementPresent(locator, 30);
        WaitForElementVisible(locator, 30);
        SelectDropDown(locator, value);

    
    }


        public void SelectByText(string Field, string text)
        {
            var locator = locatorReader.ReadLocator(Field);
            WaitForElementPresent(locator, 30);
            WaitForElementVisible(locator, 30);
            SelectDropDownByText(locator, text);
        }
    }


}