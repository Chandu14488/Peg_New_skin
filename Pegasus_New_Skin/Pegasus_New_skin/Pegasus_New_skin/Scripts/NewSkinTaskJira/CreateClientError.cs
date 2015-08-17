using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class CreateClientError : DriverTestCase
    {
        [TestMethod]
        public void createClientError()
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

            //navigate to the Create client page.
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/clients/create");

            //verify title
            VerifyTitle("Create a Client");

            //Select Status
            partnerAgentHelperNewSkin.SelectByText("ClientStatus", "Agreement");

            //Select Responsibility
            partnerAgentHelperNewSkin.SelectByText("ClientRespo", "Aslam Khan");

            //Click on Company details tab
            partnerAgentHelperNewSkin.ClickElement("ClientCompany");

            //Verify field available for company DBA name
            partnerAgentHelperNewSkin.verifyElementPresent("ClientDBAName");

            //Enter DBA name
            partnerAgentHelperNewSkin.TypeText("ClientDBAName", "DBA");

            //Enter legal name
            partnerAgentHelperNewSkin.TypeText("ClientLegalName", RandomNumber(1,1000).ToString());

            //Click on Save button
            partnerAgentHelperNewSkin.ClickElement("OfficeSave");

            //Verify error not displayed
            partnerAgentHelperNewSkin.VerifyTextNotPresent("Already Exist");


        }
    }
}
