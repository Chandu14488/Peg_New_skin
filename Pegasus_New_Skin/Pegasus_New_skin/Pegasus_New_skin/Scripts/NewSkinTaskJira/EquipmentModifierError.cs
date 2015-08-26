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
    public class EquipmentModifierError : DriverTestCase
    {
        [TestMethod]
        public void equipmentModifierError()
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

            //Click on Save button
            equiomentHelperAdmin.ClickElement("SaveBtn");

            //Verify modifier is not mandatory
            Assert.IsFalse(equiomentHelperAdmin.IsElementPresent("//*[@id='EquipmentModifier-error']"));
            equiomentHelperAdmin.WaitForWorkAround(3000);

        }
    }
}
