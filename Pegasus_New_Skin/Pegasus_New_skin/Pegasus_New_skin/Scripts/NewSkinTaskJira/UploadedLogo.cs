using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class UploadedLogo : DriverTestCase
    {
        [TestMethod]
        public void uploadedLogo()
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
            var partnerAgentHelperNewSkin = new PartnerAgentHelperNewSkin(GetWebDriver());

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click on Edit profile button
            partnerAgentHelperNewSkin.ClickElement("CorpProfile");

            //Verify title
            VerifyTitle("Edit SelCorp Corporate");

            //Upload image
            string path = GetPathToFile() + "index2.png";
            partnerAgentHelperNewSkin.UploadImage("UploadLogo", path);

            //Wait
            partnerAgentHelperNewSkin.WaitForWorkAround(3000);
            //Click on Save button
            partnerAgentHelperNewSkin.ClickElement("OfficeSave");

            //Verify title
            VerifyTitle("Dashboard");

            //Check default image not displayed
            partnerAgentHelperNewSkin.verifyElementNotPresent("LogoDefault");
            
            //Logout from the application
            GetWebDriver().Navigate().GoToUrl(log[0]);

        }
    }
}
