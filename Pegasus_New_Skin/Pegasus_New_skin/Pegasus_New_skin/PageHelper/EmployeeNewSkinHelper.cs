using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PegasusTests.Locators;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.PageHelper
{
    public class EmployeeNewSkinHelper : DriverHelper
    {
        public LocatorReader locatorReader;

        public EmployeeNewSkinHelper(IWebDriver idriver)
            : base(idriver)
        {
            locatorReader = new LocatorReader("EmployeeAgentNewSkin.xml");
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
            WaitForWorkAround(3000);
        }

        internal void MouseHover(string field)
        {
            var locator = locatorReader.ReadLocator(field);
            WaitForElementPresent(locator, 20);
            MouseOver(locator);
        }

        internal void redirectToPage()
        {
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/employees");
        }


        //Select Avatar 2
        public void SelectMulEmplAvatar()
        {
            var locator1 = "//div[@class='field_100']/div/ul/li[1]/input";
            var locator2 = "//div[@class='field_100']/div/ul/li[2]/input";
            Click(locator1);
            WaitForWorkAround(3000);
            if (IsElementPresent(locator2))
            {
                Click(locator2);
                WaitForWorkAround(3000);
            }
        }



        public void SelectByText(string xmlNode, string text)
        {
            var locator = locatorReader.ReadLocator(xmlNode);
            SelectDropDownByText(locator, text);
        }


        //Import data form excel

        public void importdataExcel(string path,  string UserType , string fieldText)
        {
            GetDataFromEXL(path, UserType, fieldText);
        }

    }
}