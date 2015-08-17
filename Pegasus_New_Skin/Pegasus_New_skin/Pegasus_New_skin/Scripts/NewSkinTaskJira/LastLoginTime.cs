using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class LastLoginTime : DriverTestCase
    {
        [TestMethod]
        public void lastLoginTime()
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

            //Go to User user page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/users");

            var lastlogon = partnerAgentHelperNewSkin.GetData("LastLogon");

            //Logout from application
            GetWebDriver().Navigate().GoToUrl(log[0]);

            //Wait for 1 minute
            partnerAgentHelperNewSkin.WaitForWorkAround(60000);

            //Login with valid username and password
            Login(username[0], password[0]);

            VerifyTitle("Dashboard");

            //Go to User user page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/users");

            //verify loast logon time
            //partnerAgentHelperNewSkin.verifylastLogon("LastLogon",lastlogon);



        }
    }
}
