using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class One000Added : DriverTestCase
    {
        [TestMethod]
        public void one000Added()
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
            var partnerAgentHelperNewSkin = new PartnerAgentHelperNewSkin(GetWebDriver());

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Go to client page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/clients");

            //Verify title
            VerifyTitle("Clients");

            //Click on Advance filter
            partnerAgentHelperNewSkin.ClickElement("Advance");

            //Veirfy website is available under the filter
            partnerAgentHelperNewSkin.verifyElementPresent("PegResult");

            //Go to contact page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/contacts");

            //Verify title
            VerifyTitle("Contacts");

            //Click on Advance filter
            partnerAgentHelperNewSkin.ClickElement("Advance");

            //Veirfy website is available under the filter
            partnerAgentHelperNewSkin.verifyElementPresent("PegResult");

            //Go to Tickets page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/tickets");

            //Verify title
            VerifyTitle("Tickets");

            //Click on Advance filter
            partnerAgentHelperNewSkin.ClickElement("Advance");

            //Veirfy website is available under the filter
            partnerAgentHelperNewSkin.verifyElementPresent("PegResult");




            //Logout from the application
            GetWebDriver().Navigate().GoToUrl(log[0]);

        }
    }
}
