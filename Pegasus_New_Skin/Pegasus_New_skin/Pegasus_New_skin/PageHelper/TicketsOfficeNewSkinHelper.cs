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
    public class TicketsOfficeNewSkinHelper : DriverHelper
    {
        public LocatorReader locatorReader;

        public TicketsOfficeNewSkinHelper(IWebDriver idriver)
            : base(idriver)
        {
            locatorReader = new LocatorReader("TicketsOfficeNewSkin.xml");
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
            Thread.Sleep(3000);
            String value = GetText(locator);
            Console.WriteLine(text + "\t" + value);
            Assert.IsTrue(value.Contains(text));
        }

        public void Select(string Field, string value)
    {
        var locator = locatorReader.ReadLocator(Field);
        SelectDropDown(locator, value);

    
    }

}


}