using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class ExportError : DriverTestCase
    {
        [TestMethod]
        public void exportError()
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

            //navigate to the detailed payout page.
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/rir/detailed_payouts");

            //verify title
            VerifyTitle("Residual Income - Payouts");

            //Click on Advance filter
            partnerAgentHelperNewSkin.ClickElement("Advance");

            //Select Total Sale $
            //partnerAgentHelperNewSkin.ClickElement("TotalSales");

            //Select Total trans
            //partnerAgentHelperNewSkin.ClickElement("TotalTrans");

            //Click on Add arrow
            //partnerAgentHelperNewSkin.ClickElement("AddArrow");

            //Click on Apply buton
            partnerAgentHelperNewSkin.ClickElement("Apply");

            //Click on Export buton
            partnerAgentHelperNewSkin.ClickElement("Exp");

            //Click on Export as csv link
            partnerAgentHelperNewSkin.ClickElement("ExpCSV");

            //Click on Advance filter
            partnerAgentHelperNewSkin.ClickElement("Advance");
/*
            //Select Total Sale $
            partnerAgentHelperNewSkin.ClickElement("RemTotalSales");

            //Select Total trans
            partnerAgentHelperNewSkin.ClickElement("RemTotalTrans");

            //Click on Add arrow
            partnerAgentHelperNewSkin.ClickElement("RemoveArrow");

            //Click on Apply buton
            partnerAgentHelperNewSkin.ClickElement("Apply");
*/
        }
    }
}
