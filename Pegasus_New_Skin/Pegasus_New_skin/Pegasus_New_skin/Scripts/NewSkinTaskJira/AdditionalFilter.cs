using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;


namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class AdditionalFilter : DriverTestCase
    {
        [TestMethod]
        public void additionalFilter()
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
            Console.WriteLine("Redirected at Dashboard screen.");

            //Go to payment page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/rir/detailed_payouts");

            //verify title
            VerifyTitle("Residual Income - Payouts");

            //Click on Filter
            partnerAgentHelperNewSkin.ClickElement("Advance");

            //Wait for text
            partnerAgentHelperNewSkin.WaitForText("Filter By Additional Fields", 20);

            //Verify User is able to select TransactionFile
            partnerAgentHelperNewSkin.SelectByText("TraFile", "Amex Return Sales");
            partnerAgentHelperNewSkin.SelectByText("TraFile", "Amex Return Transactions");
            partnerAgentHelperNewSkin.SelectByText("TraFile", "Assessment Fee");

            //Log out from the application
            GetWebDriver().Navigate().GoToUrl(log[0]);

        }
    }
}
