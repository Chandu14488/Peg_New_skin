using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class AgentCreateField : DriverTestCase
    {
        [TestMethod]
        public void agentCreateField()
        {
            string[] username = null;
            string[] password = null;

            var oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username");
            password = oXMLData.getData("settings/Credentials", "password");

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

            //navigate to the Create partner agent page.
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/partners/agent/create");

            //verify title
            VerifyTitle("Create a Partner Agent");

            //Click on Create an user checkbox
            partnerAgentHelperNewSkin.ClickElement("CreateCheck");

            //Verify fields displayed
            partnerAgentHelperNewSkin.verifyElementPresent("VerifyField");
            //Wait for 10 secon
            partnerAgentHelperNewSkin.WaitForWorkAround(10000);

            //Verify fields displayed
            partnerAgentHelperNewSkin.verifyElementPresent("VerifyField");

        }
    }
}
