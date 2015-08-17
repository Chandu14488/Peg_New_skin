using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class LoginError1 : DriverTestCase
    {
        [TestMethod]
        public void loginError1()
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

            //Refresh the page
            RefreshPage();

            //Verify title
            VerifyTitle("Login");

            //Click on Verify my account
            partnerAgentHelperNewSkin.ClickElement("VerifyAccount");

            //Verify field is blank
            partnerAgentHelperNewSkin.VerifyTextNotPresent("aslamKhan");

            //Enter username
            partnerAgentHelperNewSkin.TypeText("VerifyUsername", "aslamKhan");

            //Click on Send email button
            partnerAgentHelperNewSkin.ClickElement("VerifySend");

            //Wait for text
            partnerAgentHelperNewSkin.WaitForText("Your email is already verified",30);

        }
    }
}
