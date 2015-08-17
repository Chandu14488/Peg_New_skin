using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;


namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class VendorEmailVerification : DriverTestCase
    {
        [TestMethod]
        public void vendorEmailVerification()
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

            //Visit to create vendor page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/vendors/create");

            //Verify title
            VerifyTitle("Create a New Vendor");

            //Click on 'Save' button without entering details
            partnerAgentHelperNewSkin.ClickElement("OfficeSave");

            //Verify Validation message displayed for email
            partnerAgentHelperNewSkin.verifyElementPresent("EmailVerification");

            //Enter invalid email
            partnerAgentHelperNewSkin.TypeText("EmailVendor", "INVALID");

            //Click on 'Save' button after entering invalid email
            partnerAgentHelperNewSkin.ClickElement("OfficeSave");

            //Verify email validate
            partnerAgentHelperNewSkin.verifyElementPresent("EmailVerification");
            partnerAgentHelperNewSkin.VerifyPageText("Please enter a valid email address");
            

            //Log out from the application
            GetWebDriver().Navigate().GoToUrl(log[0]);

        }
    }
}
