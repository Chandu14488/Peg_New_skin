using System;
using LinqToExcel;
using System.Linq;
using LinqToExcel.Query;
using LinqToExcel.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PegasusTests.Locators;
using PegasusTests.PageHelper.Comm;
using System.IO;

namespace PegasusTests.PageHelper
{
    public class PartnerAgentHelperNewSkin : DriverHelper
    {
        public LocatorReader locatorReader;

        public PartnerAgentHelperNewSkin(IWebDriver idriver)
            : base(idriver)
        {
            locatorReader = new LocatorReader("PartnerAgentNewSkin.xml");
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
            WaitForElementVisible(locator, 20);
            Click(locator);
        }

        internal void MouseHover(string field)
        {
            var locator = locatorReader.ReadLocator(field);
            WaitForElementPresent(locator, 20);
            WaitForWorkAround(2000);
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
            WaitForElementPresent(locator, 20);
            SelectDropDownByText(locator, text);
        }



        public string GetData(string field)
        {
            var locator = locatorReader.ReadLocator(field);
            WaitForElementPresent(locator, 30);
            WaitForElementVisible(locator, 30);
            return GetText(locator);
        }

        public void FileIsNotBlank(string filepath)
        {
            FileInfo file = new FileInfo(filepath);
            if (filepath.Substring(filepath.LastIndexOf('.')+1)=="xls")
            {
                long size = file.Length;
                Console.WriteLine("Size  = " + file.Length);
                Assert.IsTrue(size > 3);
                
            }
        }


        public void verifylastLogon(string text, string lastlogon)
        {
            Assert.IsFalse(lastlogon.Contains(GetData(text)));
        }

        public void switchFrame(string frameid)
        {
            String frame = "//iframe[@id='"+frameid+"']";
            WaitForElementPresent(frame,30);
            GetWebDriver().SwitchTo().Frame(GetWebDriver().FindElement(ByLocator(frame)));
        }

        public void outFrame()
        {
            GetWebDriver().SwitchTo().DefaultContent();
        }

        public void verifyNewDashboard(string field)
        {
            var locator = locatorReader.ReadLocator(field);
            WaitForElementPresent(locator, 30);
            Assert.IsTrue(IsElementPresent(locator));
        }

        public void deleteOffice(string name)
        {
            string locator = "//table[@id='list1']/tbody/tr[2]/td/a[@title='Delete an Office']";
            WaitForElementPresent(locator, 30);
            Click(locator);
            Click("//button[@title='Delete']");
            VerifyTextNotPresent(name);
        }

        public void verifyElementPresent(string field)
        {
            var locator = locatorReader.ReadLocator(field);
            WaitForElementPresent(locator, 30);
            Assert.IsTrue(IsElementPresent(locator));
        }

        public void verifyElementNotPresent(string field)
        {
            var locator = locatorReader.ReadLocator(field);
            WaitForWorkAround(2000);
            Assert.IsFalse(IsElementPresent(locator));
        }

        public void verifyChecked(int value)
        {
            string checkbox = "//input[@type='checkbox']";
            int checkbox_count = XpathCount(checkbox);

            if (value == 1)
            {

            }
            else
            {

            }
        }

        public int changeCount(string count)
        {
            int result = 0;
            string locator = "//select[@role='listbox']";
            WaitForElementVisible(locator, 30);
            SelectDropDownByText(locator, count);
            WaitForWorkAround(5000);
            result = XpathCount("//table[@id='list1']/tbody/tr");
            return result;
        }

        public void verifyCount(int count,int result)
        {
            Console.WriteLine(count + "\t" + result);
            Assert.IsTrue(count <= result);

        }

        public void verifyCommentCount(string comment, int count)
        {

            String locator = "//div[contains(text(),'" + comment + "')]";
            WaitForElementVisible(locator, 30);
            Assert.IsTrue(XpathCount(locator) == count);
        }

        public void TypeInArea(string field, string comment)
        {
            var locator = locatorReader.ReadLocator(field);
            WaitForWorkAround(2000);
            WaitForElementVisible(locator,30);
            WaitForElementEnabled(locator, 30);
            GetWebDriver().FindElement(ByLocator(locator)).SendKeys(comment);

        }

        public void removeText(string field)
        {
            var locator = locatorReader.ReadLocator(field);
            WaitForWorkAround(2000);
            WaitForElementVisible(locator,30);
            GetWebDriver().FindElement(ByLocator(locator)).Clear();
        }

        public void clickOnHidden(string field)
        {
             var locator = locatorReader.ReadLocator(field);
            WaitForWorkAround(2000);
            ClickViaJavaScript(locator);
        }

        public void verifyElementNotAvailable(String field)
        {
            var locator = locatorReader.ReadLocator(field);
            Assert.IsTrue(ElementNotAvailable(locator));
        }

        public void ClickMultiple(string field)
        {
            var locator = locatorReader.ReadLocator(field);
            DoubleClick(locator);
        }

        public void verifyNotBroken()
        {
            WaitForWorkAround(3000);
            int count = XpathCount("//*[@id='menu']/li");

            for (int i = 1; i <= count; i++)
            {
                WaitForWorkAround(1000);
                Click("//*[@id='menu']/li[" + i + "]/a");
            }
        }

        public void UploadImage(string field, string path)
        {
            var locator = locatorReader.ReadLocator(field);
            WaitForElementPresent(locator, 30);
            UploadFile(locator, path);
        }

        public void verifyLocationSaved(string field, int rand)
        {
            var locator = locatorReader.ReadLocator(field);
            WaitForElementPresent(locator, 30);
            string value = GetAtrributeByLocator(locator, "value");
            Assert.IsTrue(value.Contains(rand.ToString()));
        }

        public void doubleClick(string field)
        {
            var locator = locatorReader.ReadLocator(field);
            WaitForElementPresent(locator, 30);
            WaitForWorkAround(2000);
            DoubleClick(locator);
        }

        public void VerifyValue(string one, string two)
        {

        }

        public void scrollToElement(string field)
        {
            var locator = locatorReader.ReadLocator(field);
            WaitForElementPresent(locator, 30);
            WaitForWorkAround(2000);
            ScrollDown(locator);
        }
    }
}