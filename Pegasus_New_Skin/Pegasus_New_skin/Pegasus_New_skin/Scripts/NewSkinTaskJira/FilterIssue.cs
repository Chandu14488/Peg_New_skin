using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;


namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class FilterIssue : DriverTestCase
    {
        [TestMethod]
        public void filterIssue()
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

            //Go to Client page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/clients");

            //verify title
            VerifyTitle("Clients");

            //Click on Filter
            partnerAgentHelperNewSkin.ClickElement("Advance");

            //Wait for text
            partnerAgentHelperNewSkin.WaitForText("Layout Options", 20);

           //Select processor
            if (partnerAgentHelperNewSkin.IsElementPresent("ProcessorOption"))
            {
                //Select processor
                partnerAgentHelperNewSkin.ClickElement("ProcessorOption");
                
                //Click on Add arrow
                partnerAgentHelperNewSkin.ClickElement("AddArrow");
            }

            //Click on apply button
            partnerAgentHelperNewSkin.ClickElement("Apply");

            //Verify title
            VerifyTitle("Clients");

            //Verify processor
            //partnerAgentHelperNewSkin.verifyElementPresent("VerifyProcessorAvail");

            //Log out from the application
            GetWebDriver().Navigate().GoToUrl(log[0]);

        }
    }
}
