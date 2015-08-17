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
    public class VerifyUserRedirectToShippingOnCancel : DriverTestCase
    {
        [TestMethod]
        public void verifyUserRedirectToShippingOnCancel()
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
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/manage_shipping_carriers");

//################################# Create Equipments #############################################


            // Click On Cancel
            equiomentHelperAdmin.ClickElement("ClickCancelBtn");
            equiomentHelperAdmin.WaitForWorkAround(3000);

            //Verify
            equiomentHelperAdmin.VerifyText("VerifyTextHedaing", "Shipping Carriers");
            equiomentHelperAdmin.WaitForWorkAround(3000);
        }
    }
}
