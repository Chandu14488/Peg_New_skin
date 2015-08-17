using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class CheckFilter : DriverTestCase
    {
        [TestMethod]
        public void checkFilter()
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

            //Go to Detals payout page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/rir/detailed_payouts");

            //Verify title
            VerifyTitle("Residual Income - Payouts");

            //Open on advanced filter
            partnerAgentHelperNewSkin.ClickElement("Advance");

            //Verify title
            VerifyTitle("Residual Income - Payouts");

            //Get count of available item in the Available Columns


            //Get Count of available item in the Display Columns

            //Go to the transaction page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/rir/payout_summary");

            //Verify title
            VerifyTitle("Payouts Summary");

            //Click on View transaction button
            partnerAgentHelperNewSkin.ClickElement("ViewTrans");

            //Verify title
            VerifyTitle("Residual Income Import Transactions");

            //Open on advanced filter
            partnerAgentHelperNewSkin.ClickElement("Advance");



            //Logout from the application
            GetWebDriver().Navigate().GoToUrl(log[0]);

        }
    }
}
