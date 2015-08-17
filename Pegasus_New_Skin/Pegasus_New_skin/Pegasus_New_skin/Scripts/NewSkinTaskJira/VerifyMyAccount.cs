using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class VerifyMyAccount : DriverTestCase
    {
        [TestMethod]
        public void verifyMyAccount()
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

            //Verify title
            VerifyTitle("Login");

            //Click on Verify my account
            partnerAgentHelperNewSkin.ClickElement("VerifyAccount");

            //Enter username
            partnerAgentHelperNewSkin.TypeText("VerifyUsername", "aslamKhan");

            //Click on V
            partnerAgentHelperNewSkin.ClickElement("VerifyBody");

            //Verify error not displayed
            partnerAgentHelperNewSkin.VerifyTextNotPresent("Please include an '@' in the email address");
        }
    }
}