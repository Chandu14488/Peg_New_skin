using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class AgentEmployeePage : DriverTestCase
    {
        [TestMethod]
        public void agentEmployeePage()
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
            var employeeNewSkinHelper = new EmployeeNewSkinHelper(GetWebDriver());

           //VARIABLE
            var name = "TestEmployee" + GetRandomNumber();


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click on Agent in Topmenu
            employeeNewSkinHelper.ClickElement("ClickOnAgentTab");


//################################# CREATE A agent   #############################################

            //Click on Click On Partner Agent
          GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/employees");
//            employeeNewSkinHelper.Click("//a[@title='Employees']");
            
            //Verify title
          VerifyTitle("selOffice's Employees");

            employeeNewSkinHelper.WaitForWorkAround(4000);

            }
        }
    }

