using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class ZipCodeError : DriverTestCase
    {
        [TestMethod]
        public void zipCodeError()
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

            //Go to Create Opportunity page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/opportunities/create");

            //Verify title
            VerifyTitle("Create an Opportunity");

            //Enter zip code
            partnerAgentHelperNewSkin.TypeText("ZipCode", "60601");

            //Click On V
            partnerAgentHelperNewSkin.ClickElement("V");
            partnerAgentHelperNewSkin.WaitForWorkAround(3000);
           
            //Go to Create lead page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/leads/create");
            
            //Verify title
            VerifyTitle("Create a Lead");

            //Click on Company detils
            partnerAgentHelperNewSkin.ClickElement("ComDetails");

            //Verify title
            VerifyTitle("Create a Lead");

            //Enter zip code
            partnerAgentHelperNewSkin.TypeText("LeadZip", "60601");

            //Click
            partnerAgentHelperNewSkin.ClickElement("V1");

            partnerAgentHelperNewSkin.WaitForWorkAround(3000);

            //Go to Create Client page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/clients/create");

            //Verify title
            VerifyTitle("Create a Client");

            //Click on Contacts tab
            partnerAgentHelperNewSkin.ClickElement("ConTab");

            //Verify title
            VerifyTitle("Create a Client");

            //Enter zip code
            partnerAgentHelperNewSkin.TypeText("ClientZip", "60601");

            //Click
            partnerAgentHelperNewSkin.ClickElement("V2");

            partnerAgentHelperNewSkin.WaitForWorkAround(3000);

            //Logout from the application
            GetWebDriver().Navigate().GoToUrl(log[0]);

        }
    }
}
