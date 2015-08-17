using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class EmployeeAgentNS : DriverTestCase
    {
        [TestMethod]
        public void employeeAgentNS()
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


            //Click On Create Employee Btn
            employeeNewSkinHelper.ClickElement("ClickOnaCreateEmployeeBtn");

            //Select Salutation
            employeeNewSkinHelper.Select("SelectSalutation", "Mr");

            //Enter FirstNAME
            employeeNewSkinHelper.TypeText("FirstNAME", "Test Agent");

            //Enter LastName
            employeeNewSkinHelper.TypeText("LastName", "Tester");

            //Enter Date Of Birth
            employeeNewSkinHelper.TypeText("BirthDay", "1991-03-02");


//############### CONTACT INFORMATION ###################################

            //Enter eAddressType
            employeeNewSkinHelper.Select("eAddressType", "E-Mail");

            //Enter eAddressLebel
            employeeNewSkinHelper.Select("eAddressLebel", "Work");

            //Enter eAddressType
            employeeNewSkinHelper.TypeText("eAddress", "Test@gmail.com");

//################## PHONE ###########################

            //Enter SelectPhoneType
            employeeNewSkinHelper.Select("SelectPhoneType", "Work");

            //Enter PhoneNumber
            employeeNewSkinHelper.TypeText("PhoneNumber", "121212121");

//##################### ADDRESS TYPE

            //Enter Address Type    
            employeeNewSkinHelper.Select("AddressType", "Office");

            //Enter AddressLine1
            employeeNewSkinHelper.TypeText("AddressLine1", "FC 89");

            //Enter PhoneNumber
            employeeNewSkinHelper.TypeText("PostalCode", "60601");
            employeeNewSkinHelper.WaitForWorkAround(3000);

//########################## DEPARTMENT ROLE   ###############################

    /*        //Click On Department 
            employeeNewSkinHelper.ClickElement("ClickOnDeppartmentTeam");

            //Select Department
            employeeNewSkinHelper.Select("SelectDepartment", "78");

            //Select Select Role
            employeeNewSkinHelper.Select("SelectRole", "76");

            //Select Primary  Team
            employeeNewSkinHelper.Select("PrimaryTeam", "68");           */

            //CLICK DoNotSolicit
            employeeNewSkinHelper.ClickElement("ClickSaveNskin");
            employeeNewSkinHelper.VerifyPageText("The employee is successfully added");
        }
    }
}
