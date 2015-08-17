using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class EditCorpEmployee : DriverTestCase
    {
        [TestMethod]
        public void editCorpEmployee()
        {
            string[] username = null;
            string[] password = null;

            var oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username2");
            password = oXMLData.getData("settings/Credentials", "password2");

            //Initializing the objects
            var loginHelper = new LoginHelper(GetWebDriver());
            var clientHelper = new ClientsHelper(GetWebDriver());
            var corpEmployeeHelper = new CorpEmployeeHelper(GetWebDriver());


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click on Agent in Topmenu
            corpEmployeeHelper.ClickElement("ClickOnEmployeeTab");
            corpEmployeeHelper.WaitForWorkAround(4000);

            //Search Employee
            corpEmployeeHelper.TypeText("SearchEmployee", "Test Tester");

            var Loc = "//table[@id='list1']/tbody/tr[2]";

            if (corpEmployeeHelper.IsElementPresent(Loc))
            {

                //Click on Edit
                corpEmployeeHelper.ClickElement("ClickOnEdit");
                corpEmployeeHelper.WaitForWorkAround(3000);

                //Enter zip code
                corpEmployeeHelper.TypeText("EnterZipCode", "60601");
                corpEmployeeHelper.WaitForWorkAround(3000);

                //Enter First Name
                corpEmployeeHelper.TypeText("EnterFirstName", "Test");

                //Enter Last Name
                corpEmployeeHelper.TypeText("EnterLastName", "Tester");


                //Click On Save
                corpEmployeeHelper.ClickElement("ClickOnSave");
                corpEmployeeHelper.WaitForWorkAround(4000);

                //Verify 
                corpEmployeeHelper.VerifyPageText("Employee Details successfully updated");
                corpEmployeeHelper.WaitForWorkAround(4000);

            }

            else
            {

                //ClickOnCreate
                corpEmployeeHelper.ClickElement("ClickOnCreate");

                //Enter User Name
                var usernme = "DemoUser" + RandomNumber(1, 999);
                corpEmployeeHelper.TypeText("EnterUserName", usernme);

                //Click On Save
                corpEmployeeHelper.ClickElement("ClickOnSave");
                corpEmployeeHelper.WaitForWorkAround(4000);

                //Verify This field is required.
                corpEmployeeHelper.VerifyPageText("This field is required.");

                //Verifytext 
                corpEmployeeHelper.VerifyPageText("This field is required.");

                //verify 
                corpEmployeeHelper.VerifyText("VerifyvALIDATION", "This field is required.");

                //Enter Phone Number
                corpEmployeeHelper.VerifyText("VerifyAvatar", "This field is required.");

                //Enter Phone Number
                corpEmployeeHelper.VerifyText("VerifyEmail", "This field is required.");

                //Enter Phone Number
                corpEmployeeHelper.VerifyText("VerifyPhoneNumber", "This field is required.");

                //Enter Phone Number
                corpEmployeeHelper.VerifyText("VerifyLastName", "This field is required.");

                //Enter First Name
                corpEmployeeHelper.TypeText("EnterFirstName", "Test");

                //Enter Last Name
                corpEmployeeHelper.TypeText("EnterLastName", "Tester");

                //Enter Primary Email
                var Email = "Email" + RandomNumber(1, 999) + "@yopmail.com";
                corpEmployeeHelper.TypeText("EnterPrimaryEmail", Email);

                //Click On Check box 
                corpEmployeeHelper.ClickElement("ClickOnCheckBox");

                //Enter Phone Number
                corpEmployeeHelper.TypeText("EnterPhneNumber", "9898777332");

                //Enter Eaddress
                var mail = "mail" + RandomNumber(1, 999) + "@yopmail.com";
                corpEmployeeHelper.TypeText("EnterEaddress", mail);

                //Click On Save
                corpEmployeeHelper.ClickElement("ClickOnSave");
                corpEmployeeHelper.WaitForWorkAround(4000);

                //verify Page Text
                corpEmployeeHelper.VerifyPageText("Employee Created Successfully.");
                corpEmployeeHelper.WaitForWorkAround(4000);

                //Search Employee
                corpEmployeeHelper.TypeText("SearchEmployee", "Test Tester");

                //Enter Email To Search
                corpEmployeeHelper.TypeText("SearchEnterEmail", Email);
                corpEmployeeHelper.WaitForWorkAround(3000);

                //Click on Edit
                corpEmployeeHelper.ClickElement("ClickOnEdit");
                corpEmployeeHelper.WaitForWorkAround(3000);

                //Enter zip code
                corpEmployeeHelper.TypeText("EnterZipCode", "60601");
                corpEmployeeHelper.WaitForWorkAround(3000);

                //Enter First Name
                corpEmployeeHelper.TypeText("EnterFirstName", "Test");

                //Enter Last Name
                corpEmployeeHelper.TypeText("EnterLastName", "Tester");


                //Click On Save
                corpEmployeeHelper.ClickElement("ClickOnSave");
                corpEmployeeHelper.WaitForWorkAround(4000);

                //Verify 
                corpEmployeeHelper.VerifyPageText("Employee Details successfully updated");
                corpEmployeeHelper.WaitForWorkAround(4000);


            }
                }
            }
  }
    

