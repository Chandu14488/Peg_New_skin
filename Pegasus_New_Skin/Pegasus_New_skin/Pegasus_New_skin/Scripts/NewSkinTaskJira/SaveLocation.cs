using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class SaveLocation : DriverTestCase
    {
        [TestMethod]
        public void saveLocation()
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

            //Go to Client page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/clients");

            //Verify title
            VerifyTitle("Clients");

            //Open a client
            partnerAgentHelperNewSkin.ClickElement("OpenClient");

            //Verify title
            VerifyTitle("Company - Details");

            //Click on Company detials
            partnerAgentHelperNewSkin.ClickElement("ComDetails");

            //Verify title
            VerifyTitle("Company - Details");

            int rand = RandomNumber(10, 1000);

            //Enter Location
            partnerAgentHelperNewSkin.TypeText("LocationOffice", rand.ToString());

            //CLick on Save button
            partnerAgentHelperNewSkin.ClickElement("OfficeSave");

            //Wait for text
            partnerAgentHelperNewSkin.WaitForText("Client data updated successfully.", 20);

            //Go to dashboard
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice");

            //Verify title
            VerifyTitle("Dashboard");

            //Go to Client page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/clients");

            //Verify title
            VerifyTitle("Clients");

            //Open a client
            partnerAgentHelperNewSkin.ClickElement("OpenClient");

            //Verify title
            VerifyTitle("Company - Details");

            //Click on Company detials
            partnerAgentHelperNewSkin.ClickElement("ComDetails");

            //Verify title
            VerifyTitle("Company - Details");

            //Verify location is saved
            partnerAgentHelperNewSkin.verifyLocationSaved("LocationOffice", rand);


            //Logout from the application
            GetWebDriver().Navigate().GoToUrl(log[0]);

        }
    }
}
