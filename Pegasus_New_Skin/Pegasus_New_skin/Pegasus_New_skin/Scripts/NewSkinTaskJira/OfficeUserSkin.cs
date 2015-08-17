using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class OfficeUserSkin : DriverTestCase
    {
        [TestMethod]
        public void officeUserSkin()
        {
            string[] username = null;
            string[] password = null;
            string[] log = null;
            var oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username2");
            password = oXMLData.getData("settings/Credentials", "password2");
            log = oXMLData.getData("settings/URL", "logout");

            var name = "Office" + GetRandomNumber();
            //Initializing the objects
            var loginHelper = new LoginHelper(GetWebDriver());
            var clientHelper = new ClientsHelper(GetWebDriver());
            var partnerAgentHelperNewSkin = new PartnerAgentHelperNewSkin(GetWebDriver());

            Console.WriteLine("Username = "+name);
            
            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Go to Create office page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/offices/create");

            //Verify title
            VerifyTitle("Create an Office");

            //Enter name
            partnerAgentHelperNewSkin.TypeText("OfficeName", name);

            //Enter address
            partnerAgentHelperNewSkin.TypeText("OfficeAddress1", "Address1");

            //Enter city
            partnerAgentHelperNewSkin.TypeText("OfficeCity", "Alaska");

            //Select country
            partnerAgentHelperNewSkin.SelectByText("OfficeCountry", "Canada");

            partnerAgentHelperNewSkin.WaitForWorkAround(2000);

            //Select State
            partnerAgentHelperNewSkin.SelectByText("OfficeState", "AB");

            //Enter username
            partnerAgentHelperNewSkin.TypeText("OfficeUsername", name);

            //Click on Autogenerate
            partnerAgentHelperNewSkin.ClickElement("OfficeAutoGenerate");
            //Enter password
            partnerAgentHelperNewSkin.TypeText("OfficePassword", name);

            //Enter first name
            partnerAgentHelperNewSkin.TypeText("OfficeFirstName", name);

            //Enter last name
            partnerAgentHelperNewSkin.TypeText("OfficeLastName", "Last");

            //Enter e address
            partnerAgentHelperNewSkin.TypeText("OfficeEAddress", name+"@yopmail.com");

            //Click on Save
            partnerAgentHelperNewSkin.ClickElement("OfficeSave");

            //Verify Title
            VerifyTitle("Offices");

            //Log out from the application
            GetWebDriver().Navigate().GoToUrl(log[0]);

            //Verify title
            VerifyTitle("Login");

            //Go to yopmail
            GetWebDriver().Navigate().GoToUrl("http://www.yopmail.com/en/");

            //Verify Title
            VerifyTitle("YOPmail");

            //Enter username
            partnerAgentHelperNewSkin.TypeText("Yopmail", name);

            //Click on Button
            partnerAgentHelperNewSkin.ClickElement("YopmailClick");

            //Switch frame
            partnerAgentHelperNewSkin.switchFrame("ifinbox");

            //Click on Email
            partnerAgentHelperNewSkin.ClickElement("OfficeMail");

            //Out of the fame
            partnerAgentHelperNewSkin.outFrame();

            //Switch frame
            partnerAgentHelperNewSkin.switchFrame("ifmail");

            //Click on Link
            partnerAgentHelperNewSkin.ClickElement("OfficeLink");

            //Switch window
            partnerAgentHelperNewSkin.SwitchNewWindow("Login");

            //Verify Title
           // VerifyTitle("Login");

            //Verify page text
            //partnerAgentHelperNewSkin.VerifyPageText("Thank you, your account is activated now");
            //Login with new user
            //Login(name, name);

            //verify title
            //VerifyTitle("Dashboard");

            //Verify new skin
            //partnerAgentHelperNewSkin.verifyNewDashboard("NewDashboard");
            //partnerAgentHelperNewSkin.verifyNewDashboard("NewDashboard1");

            //Log out from the application
            //GetWebDriver().Navigate().GoToUrl(log[0]);

        }
    }
}
