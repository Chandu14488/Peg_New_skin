using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class FieldDisError : DriverTestCase
    {
        [TestMethod]
        public void fieldDisError()
        {
            string[] username = null;
            string[] password = null;
            string[] log = null;
            var oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username");
            password = oXMLData.getData("settings/Credentials", "password");
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
            Console.WriteLine("Redirected at Dashboard screen.");

            //Go to Create template page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/field_grouping_templates");

            //Verify title
            VerifyTitle("Field Grouping Templates");

            //Click on 'Create' button
            partnerAgentHelperNewSkin.ClickElement("TemplateCreate");

            //Enter TemplateName
            partnerAgentHelperNewSkin.TypeText("TemplateName", "DemoTemplate");

            //Select Module 
            partnerAgentHelperNewSkin.SelectByText("TemplaceModule", "Clients");

            partnerAgentHelperNewSkin.WaitForWorkAround(2000);

            //Select Tab
            partnerAgentHelperNewSkin.SelectByText("TemplateTab", "Company Details");

            partnerAgentHelperNewSkin.WaitForWorkAround(5000);
            //Select Field
            partnerAgentHelperNewSkin.SelectByText("TemplateField", "Company Legal Name");

            //Click on Add Button
            partnerAgentHelperNewSkin.ClickElement("TemplateAdd");

            //Click on Save button
            partnerAgentHelperNewSkin.ClickElement("OfficeSave");

            //Click on Delete icon
            partnerAgentHelperNewSkin.ClickElement("TemplateDelete");

            //Accept alert
            partnerAgentHelperNewSkin.AcceptAlert();

            //Verify error not displayed
            partnerAgentHelperNewSkin.VerifyTextNotPresent("An Internal Error Has Occurred");

            //Log out from the application
            GetWebDriver().Navigate().GoToUrl(log[0]);

        }
    }
}
