using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;


namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class VerifyMailMessage : DriverTestCase
    {
        [TestMethod]
        public void verifyMailMessage()
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

            //Visit to Report page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/rir/reports");

            //Verify title
            VerifyTitle("Residual Income - Reports");

           //Select Office
            partnerAgentHelperNewSkin.ClickElement("SelOffice");

            //Wait for text in page
            partnerAgentHelperNewSkin.WaitForText("SelCorp Residual Reports", 30);

            //Click on Send button
            partnerAgentHelperNewSkin.ClickElement("SendMail");

            //Wait for text
            partnerAgentHelperNewSkin.WaitForText("From",30);

            //Click On Send button
            partnerAgentHelperNewSkin.ClickElement("MailSend");

            //Wait for text
            partnerAgentHelperNewSkin.WaitForText("Report Mail Sent Successfully.", 30);

            //Log out from the application
            GetWebDriver().Navigate().GoToUrl(log[0]);

        }
    }
}
