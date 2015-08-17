using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class DeleteEmployee : DriverTestCase
    {
        [TestMethod]
        public void deleteEmployee()
        {
            string[] username = null;
            string[] password = null;
            string[] log = null;
            var oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username2");
            password = oXMLData.getData("settings/Credentials", "password2");
            log = oXMLData.getData("settings/URL", "logout");

            var name = "TestEmployee" + RandomNumber(0,99);

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

            //Go to Employee page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/employees/create");

            //verify title
            VerifyTitle("Employees");

            //Enter name
            partnerAgentHelperNewSkin.TypeText("EmployeeUsername", name);

            //Enter email
            partnerAgentHelperNewSkin.TypeText("EmployeeEmail", name + "@yopmail.com");


            //Enter firstname
            partnerAgentHelperNewSkin.TypeText("EmployeeFirst", name);

            //Enter lastname
            partnerAgentHelperNewSkin.TypeText("EmployeeLast", "Last");

            //Check the box
            partnerAgentHelperNewSkin.ClickElement("EmployeeCheck");

            //Enter phone
            partnerAgentHelperNewSkin.TypeText("EmployeePhone", "(2134551231");

            //Enter e adree
            partnerAgentHelperNewSkin.TypeText("EmployeeEAddress", name + "@yopmail.com");

            //Click on save button
            partnerAgentHelperNewSkin.ClickElement("EmployeeSave");

            //Wait for text
            partnerAgentHelperNewSkin.WaitForText("Refresh",30);

            //Verify title
            VerifyTitle("Employees");

            //Logout from the application
            GetWebDriver().Navigate().GoToUrl(log[0]);

            //Verify title
            VerifyTitle("Login");

            //Redirect to yopmail
            GetWebDriver().Navigate().GoToUrl("http://www.yopmail.com/en/");

            //Verify title
            VerifyTitle("YOPmail");

            //Enter email
            partnerAgentHelperNewSkin.TypeText("Yopmail", name);

            //Click on button
            partnerAgentHelperNewSkin.ClickElement("YopmailClick");

            partnerAgentHelperNewSkin.WaitForWorkAround(5000);

            //Switch to frame
            partnerAgentHelperNewSkin.switchFrame("ifinbox");

            //Click on Mail
            partnerAgentHelperNewSkin.ClickElement("UserMail");

            //Switch to default
            GetWebDriver().SwitchTo().DefaultContent();

            //Switch to frame
            partnerAgentHelperNewSkin.switchFrame("ifmail");

            //Click on URL
            partnerAgentHelperNewSkin.ClickElement("OfficeLink");

            //Switch window
            partnerAgentHelperNewSkin.SwitchNewWindow("Login");

            //Verify message
            partnerAgentHelperNewSkin.WaitForText("Thank you, your account is activated now", 30);

            //Verify title
            VerifyTitle("Login");

            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Go to Employee page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/employees/");

            //verify title
            VerifyTitle("Employees");

            //scroll to element
            partnerAgentHelperNewSkin.scrollToElement("SelectList");

            //Select 1000
            partnerAgentHelperNewSkin.SelectByText("SelectList", "1000");

            //verify title
            VerifyTitle("Employees");

            //Open user profile
            partnerAgentHelperNewSkin.Click("//a[contains(text(),'"+name+"')]");

            //Wait for text
            partnerAgentHelperNewSkin.WaitForText("Disable", 30);

            //Click on Disable button
            partnerAgentHelperNewSkin.ClickElement("UserDisable");

            //Type text
            partnerAgentHelperNewSkin.TypeInArea("DisableArea", "Testing");

            //Click on Disable overlay
            partnerAgentHelperNewSkin.ClickElement("UserOverlayDisable");








        }
    }
}
