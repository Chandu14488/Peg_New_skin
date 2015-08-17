using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.Corp
{
    [TestClass]
    public class DeleteOfficeNewSkin : DriverTestCase
    {
        [TestMethod]
        public void deleteOfficeNewSkin()
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
            var createOfficeHelperNewSkin = new CreateOfficeHelperNewSkin(GetWebDriver());

            //Variable random
            var usernme = "TESTUSER" + RandomNumber(44,777);
            var name = "Delete Office" + RandomNumber(99, 999);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click on Agent in Topmenu
            createOfficeHelperNewSkin.ClickElement("ClickOnOfficeTab");


//################################# CREATE A Office   #############################################

            //Click on Click On Partner Agent
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/offices");
                

            //Click on Click On Partner Agent
            createOfficeHelperNewSkin.ClickElement("CreateNewbtn");

            //Enter Name
            createOfficeHelperNewSkin.TypeText("Name", name);

            //Enter DBAName
            createOfficeHelperNewSkin.TypeText("DBAName", "TEST123");


            //Enter Website
            createOfficeHelperNewSkin.TypeText("Website", "TEST.COM");


            //Enter OfficeCode
          //  createOfficeHelperNewSkin.TypeText("OfficeCode", "12345");


            //Enter SysPrinNumber
          //  createOfficeHelperNewSkin.TypeText("SysPrinNumber", "123456");


            //Enter FDNAgentNummber
            //createOfficeHelperNewSkin.TypeText("FDNAgentNummber", "2000");

            //Enter STWShortName
            //createOfficeHelperNewSkin.TypeText("STWShortName", "TEST");

            //Enter AssocaitionId
            //createOfficeHelperNewSkin.TypeText("AssocaitionId", "123");

            //Enter STWTransFreedomCode
           // createOfficeHelperNewSkin.TypeText("STWTransFreedomCode", "12345");


            //Enter OfficeCommanEmail
            createOfficeHelperNewSkin.TypeText("OfficeCommanEmail", "tt@gmail.com");

            //Enter VenderName
            createOfficeHelperNewSkin.TypeText("VenderName", "VenderTEST");

            //Enter VenderName
            createOfficeHelperNewSkin.TypeText("VenderCode", "1234");


            //Enter VenderName
            createOfficeHelperNewSkin.TypeText("OfficephoneNumber", "1234567890");


            //Enter VenderName
            createOfficeHelperNewSkin.TypeText("BusinessPhoneNumber", "1234567890");

            //Enter VenderName
            createOfficeHelperNewSkin.TypeText("FaxNumber", "1234567890");

            //Enter VenderName
            createOfficeHelperNewSkin.TypeText("LinkedURL", "Linked.com");

            //Enter VenderName
            createOfficeHelperNewSkin.TypeText("FacebookURL", "Facebook.com");

            //Enter TwitterURL
            createOfficeHelperNewSkin.TypeText("TwitterURL", "Twitter.com");

            //##########################  ADDRESS   

            //Enter Address
            createOfficeHelperNewSkin.Select("AddressType", "Office");

            //Enter AddressLine1
            createOfficeHelperNewSkin.TypeText("AddressLine1", "FC-89");


 /*           //Enter CITY
            createOfficeHelperNewSkin.TypeText("CITY", "test");

            //Select Country
            createOfficeHelperNewSkin.Select("country", "United States");
            createOfficeHelperNewSkin.WaitForWorkAround(4000);

            // Select State
            createOfficeHelperNewSkin.Select("SelectState", "AR");    */

            //Select Zip Code
            createOfficeHelperNewSkin.TypeText("ZipCode","60601");
            createOfficeHelperNewSkin.WaitForWorkAround(4000);

            //Enter PrimaryUserName
            createOfficeHelperNewSkin.TypeText("PrimaryUserName", usernme);

            //Click on AutoGenPassword checkbox
            createOfficeHelperNewSkin.ClickElement("AutoGenPassword");

            //Enter PrimaryPassword
            createOfficeHelperNewSkin.TypeText("PrimaryPassword", "1qaz!QAZ");


//################################ USER DETAIL

            //Select Salutation
            createOfficeHelperNewSkin.Select("Salutation", "Mr");
            createOfficeHelperNewSkin.WaitForWorkAround(2000);

            //Enter FirstName
            createOfficeHelperNewSkin.TypeText("FirstName", "Test");

//############################   EMAIL AND PHONE NUMBER

            //Enter LastName
            createOfficeHelperNewSkin.TypeText("LastName", "Tester");

            //Enter eAddress
            createOfficeHelperNewSkin.TypeText("eAddress", "NewTest@yopmail.com");

            //Enter PhoneNumber
       //     createOfficeHelperNewSkin.TypeText("PhoneNumber", "1234567890");


//#################################### SAVE   
            createOfficeHelperNewSkin.ClickElement("ClickOnSaveBtn");
            createOfficeHelperNewSkin.WaitForWorkAround(6000);

            //Verify text on the page
            createOfficeHelperNewSkin.VerifyPageText("Office created successfully.");
            createOfficeHelperNewSkin.WaitForWorkAround(3000);


            //Search And Delete
            createOfficeHelperNewSkin.TypeText("EnterNameToSearch", name);
            createOfficeHelperNewSkin.WaitForWorkAround(4000);

            //Delete An Office
            createOfficeHelperNewSkin.ClickElement("DeleteAnOffice");
            createOfficeHelperNewSkin.WaitForWorkAround(4000);

            //ClickConfrmDelete
            createOfficeHelperNewSkin.ClickElement("ClickConfrmDelete");
            createOfficeHelperNewSkin.WaitForWorkAround(4000);

            //verify messsage Office deleted successfully.
            createOfficeHelperNewSkin.VerifyPageText("Office deleted successfully.");
            createOfficeHelperNewSkin.WaitForWorkAround(4000);

        }
    }
}
