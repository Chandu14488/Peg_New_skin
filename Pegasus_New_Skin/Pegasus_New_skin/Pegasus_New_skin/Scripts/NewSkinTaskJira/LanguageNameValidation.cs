using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class LanguageNameValidation : DriverTestCase
    {
        [TestMethod]
        public void languageNameValidation()
        {
            string[] username = null;
            string[] password = null;
            string[] log = null;
            var oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username2");
            password = oXMLData.getData("settings/Credentials", "password2");
            log = oXMLData.getData("settings/URL", "logout");

            //Initializing the objects
            var loginHelper = new LoginHelper(GetWebDriver());
            var clientHelper = new ClientsHelper(GetWebDriver());
            var partnerAgentHelperNewSkin = new PartnerAgentHelperNewSkin(GetWebDriver());
            
            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");

            //Go to Language page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/languages");

            //Verify title
            VerifyTitle("Languages");

            //Click on 'Create' button
            partnerAgentHelperNewSkin.ClickElement("LanguageCreate");

            //Wait for text
            partnerAgentHelperNewSkin.WaitForText("Add New Language", 30);
            partnerAgentHelperNewSkin.WaitForWorkAround(3000);

            //Enter language name
            partnerAgentHelperNewSkin.TypeText("LanguageName", "Test");

            //Click on Save button
            partnerAgentHelperNewSkin.ClickElement("LanguageSave");

            //Wait for text
            partnerAgentHelperNewSkin.WaitForText("Language Created Successfully",40);

            //Click on Edit button
            partnerAgentHelperNewSkin.ClickElement("LanguageEdit");

            //Remove text from the field
            partnerAgentHelperNewSkin.removeText("LanguageBlank");

            //Click on box
            partnerAgentHelperNewSkin.Click("//div[@class='ibox-title']");

            //Click on Save button
            partnerAgentHelperNewSkin.ClickElement("LanguageSave1");

            //Verify error message
            partnerAgentHelperNewSkin.VerifyPageText("Name: Field is required");

            //Click on Close button
            partnerAgentHelperNewSkin.ClickElement("LanguageClose");

            //Click on Cancel button
            partnerAgentHelperNewSkin.ClickElement("LanguageCancel");

            //Click on Delete button
            partnerAgentHelperNewSkin.ClickElement("LanguageDelete");

            //Click on OK button
            partnerAgentHelperNewSkin.ClickElement("LanguageOK");

            //verify language deleted
            //partnerAgentHelperNewSkin.

            //Logout from the application
            GetWebDriver().Navigate().GoToUrl(log[0]);
        }
    }
}
