using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class MeetingClientEmail : DriverTestCase
    {
        [TestMethod]
        public void meetingClientEmail()
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

            //Go to Create Meeting page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/meetings/create");

            //Verify title
            VerifyTitle("Create a Meeting");

            //Select Releted to
            partnerAgentHelperNewSkin.SelectByText("ReletedTo", "Client");

            //Click on Assign icon
            partnerAgentHelperNewSkin.ClickElement("AssignMeeting");
            partnerAgentHelperNewSkin.WaitForWorkAround(5000);

            //Click on User
            partnerAgentHelperNewSkin.ClickElement("AssignedUser");
            partnerAgentHelperNewSkin.WaitForWorkAround(5000);

            //Verify email displayed
            partnerAgentHelperNewSkin.verifyElementAvailable("EmailField");

           //Select Releted to
            partnerAgentHelperNewSkin.SelectByText("ReletedTo", "Lead");

            //Verify email removed
            partnerAgentHelperNewSkin.verifyElementNotAvailable("EmailField");

            //Logout from the application
            GetWebDriver().Navigate().GoToUrl(log[0]);

        }
    }
}
