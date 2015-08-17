using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class ProcessorDeleteTypo : DriverTestCase
    {
        [TestMethod]
        public void processorDeleteTypo()
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

            //Go to processor page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/masterdata/processor_types");

            //Verify title
            VerifyTitle("Master Processors");

            //Click on 'Delete' button
            partnerAgentHelperNewSkin.ClickElement("ProcessorDelete");

            //Verify Alert text
            partnerAgentHelperNewSkin.VerifyAlertText("Are you sure you want to delete this processor permanently?");

            //Logout from the application
            GetWebDriver().Navigate().GoToUrl(log[0]);
        }
    }
}
