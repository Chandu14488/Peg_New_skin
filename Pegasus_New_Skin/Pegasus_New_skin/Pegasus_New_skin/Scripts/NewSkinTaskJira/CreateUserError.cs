using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class CreateUserError : DriverTestCase
    {
        [TestMethod]
        public void createUserError()
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
            var clientHelper = new ClientsHelper(GetWebDriver());
            var partnerAgentHelperNewSkin = new PartnerAgentHelperNewSkin(GetWebDriver());
            
            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");

            //Go to Create user page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/users/create");

            //Verify title
            VerifyTitle("Create User");

            //Select User type
            partnerAgentHelperNewSkin.SelectByText("Usertype", "Employee");

            //Click on Create new
            partnerAgentHelperNewSkin.ClickElement("UserCreate");

            //Enter primary email
            partnerAgentHelperNewSkin.TypeText("UserEmail", "INVALID");

            //Click on 'Save' button
            partnerAgentHelperNewSkin.ClickElement("UserSave");

            //Wait for text
            partnerAgentHelperNewSkin.WaitForText("Please enter a valid email address.",50);

            //Verify error not displayed
            partnerAgentHelperNewSkin.VerifyTextNotPresent("Internal server error page");

            //Logout from the application
            GetWebDriver().Navigate().GoToUrl(log[0]);
        }
    }
}
