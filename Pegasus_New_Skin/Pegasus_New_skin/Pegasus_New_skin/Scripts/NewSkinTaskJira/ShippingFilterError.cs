using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;


namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class ShippingFilterError : DriverTestCase
    {
        [TestMethod]
        public void shippingFilterError()
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
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/shipping_carriers");

            //Verify title
            VerifyTitle("Shipping Carriers");

            //Apply Filter
            partnerAgentHelperNewSkin.TypeText("FilterName", GetRandomNumber().ToString());
            partnerAgentHelperNewSkin.WaitForWorkAround(3000);

            //Verify filter available
            partnerAgentHelperNewSkin.verifyElementNotPresent("NonFilter");

            //Click on Refresh button
            partnerAgentHelperNewSkin.ClickElement("RefreshButton");

            //verify title
            VerifyTitle("Shipping Carriers");

            //Verify filter reset
            partnerAgentHelperNewSkin.verifyElementPresent("NonFilter");

            //Log out from the application
            GetWebDriver().Navigate().GoToUrl(log[0]);

        }
    }
}
