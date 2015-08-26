using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class CreatePickList : DriverTestCase
    {
        [TestMethod]
        public void createPickList()
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

            //Go to picklist page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/pick-lists");

            //Verify title
            VerifyTitle("Picklists");

            // Open the first picklist
            partnerAgentHelperNewSkin.ClickElement("EditPick");

            //Veirfy title
            VerifyTitle("Add/Edit Picklist Items");
            
            //Click on Add button
            partnerAgentHelperNewSkin.ClickElement("AddPick");
            partnerAgentHelperNewSkin.WaitForWorkAround(2000);

            //Enter name
            partnerAgentHelperNewSkin.TypeText("PickType","Pick"+GetRandomNumber());

            //Click on Save button
            partnerAgentHelperNewSkin.ClickElement("PickSave");


            //Wait for text
            partnerAgentHelperNewSkin.WaitForText("The picklist value is added successfully", 30);

            //Logout from the application
            GetWebDriver().Navigate().GoToUrl(log[0]);

        }
    }
}
