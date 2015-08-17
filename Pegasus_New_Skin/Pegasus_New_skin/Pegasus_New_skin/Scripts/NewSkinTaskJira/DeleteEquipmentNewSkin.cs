using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class DeleteEquipmentNewSkin : DriverTestCase
    {
        [TestMethod]
        public void deleteEquipmentNewSkin()
        {
            string[] username = null;
            string[] password = null;

            XMLParse oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username");
            password = oXMLData.getData("settings/Credentials", "password");

            //Initializing the objects
            var loginHelper = new LoginHelper(GetWebDriver());
            var clientHelper = new ClientsHelper(GetWebDriver());
            var equiomentHelperAdmin = new EquiomentHelperAdmin(GetWebDriver());

            //Variable 
            String  name = "Test" + RandomNumber(1,99);
            String Id = "12345" + RandomNumber(1, 99);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click on Clients in Topmenu
//            clientHelper.clickClients();

            //Click to open client info
   //         clientHelper.OpenClient();

//#######################  MOVE HOVER TO THE WELCOME
            //Click on Move over
            equiomentHelperAdmin.ClickElement("MoveHover");

            //Click On  Admin
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/admin");

//################################# Terminal And Equipment Tab #############################################

            //Click on Terminal And Equipment Tab
            equiomentHelperAdmin.ClickElement("ClickOnEquipmentTab");

//##################  Redirect To Url

            //Redirect To URL
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/equipment");

//################################# Create Equipments #############################################

            // Click On Create
            equiomentHelperAdmin.ClickElement("ClickOnCreate");
            equiomentHelperAdmin.WaitForWorkAround(3000);

            //Enter Equipment Name
            equiomentHelperAdmin.TypeText("EqpName", "Delete Equip");

            //Enter DownloadsIDName
            equiomentHelperAdmin.Select("Type", "Check Reader");

            //Enter Equipment Id
            equiomentHelperAdmin.TypeText("EquipmentId", Id);

            //Enter Category
        //    equiomentHelperAdmin.Select("Category", "68");

            //Enter Version
            equiomentHelperAdmin.TypeText("Version", "Testing");

            //Enter Description
            equiomentHelperAdmin.TypeText("Description", "This is Testing Description");

            //Click On First CheckBox
       //     equiomentHelperAdmin.ClickElement("ClickOnFirstCheckBox");

            //Click On First CheckBox
      //      equiomentHelperAdmin.ClickElement("ClickOn2CheckBox");

            //######################## CLICK ON SAVE BUTTON  ########################################
            // Click on Save button   
            equiomentHelperAdmin.ClickElement("SaveBtn");
            equiomentHelperAdmin.WaitForWorkAround(5000);


            //Enter Name in seacrh field
            equiomentHelperAdmin.TypeText("SearchEquipmenmt", "Delete Equip");
            equiomentHelperAdmin.WaitForWorkAround(5000);

            //Delete Permanently Equip
            equiomentHelperAdmin.ClickElement("DeletePermanentlyEquip");
            equiomentHelperAdmin.AcceptAlert();
            equiomentHelperAdmin.WaitForWorkAround(3000);
            equiomentHelperAdmin.VerifyPageText("Equipment deleted successfully.");
            equiomentHelperAdmin.WaitForWorkAround(3000);



        }
    }
}
