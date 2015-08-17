using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class FDNRequirement : DriverTestCase
    {
        [TestMethod]
        public void fDNRequirement()
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

            //Go to Create office page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/offices/create");

            //Verify title
            VerifyTitle("Create an Office");

            //Click on 'Save' button
            partnerAgentHelperNewSkin.ClickElement("OfficeSave");

            //Verify FDN field is not mandatory
            partnerAgentHelperNewSkin.verifyElementNotPresent("OfficeFDN");

            //Logout from the application
            GetWebDriver().Navigate().GoToUrl(log[0]);
        }
    }
}
