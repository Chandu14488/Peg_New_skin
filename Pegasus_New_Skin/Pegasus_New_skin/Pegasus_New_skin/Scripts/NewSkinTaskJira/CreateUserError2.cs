using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class CreateUserError2 : DriverTestCase
    {
        [TestMethod]
        public void createUserError2()
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

            //Enter first name
            partnerAgentHelperNewSkin.TypeText("UserFirstName", "Aslam");

            //Enter last Name
            partnerAgentHelperNewSkin.TypeText("UserLastName", "Khan");

            //Enter existing user name
            partnerAgentHelperNewSkin.TypeText("Userusername", username[0]);

            //Click on Password checkbox
            partnerAgentHelperNewSkin.ClickElement("UserAutoGenerate");

            //Enter password
            partnerAgentHelperNewSkin.TypeText("UserPassword", "1");

            //Enter primary email
            partnerAgentHelperNewSkin.TypeText("UserEmail", "Test@yopmail.com");

            //Click on 'Save' button
            partnerAgentHelperNewSkin.ClickElement("UserSave");

            //Verify Checkbox not checked
            partnerAgentHelperNewSkin.verifyElementNotAvailable("UserCheckNotCheck");

            //Logout from the application
            GetWebDriver().Navigate().GoToUrl(log[0]);
        }
    }
}
