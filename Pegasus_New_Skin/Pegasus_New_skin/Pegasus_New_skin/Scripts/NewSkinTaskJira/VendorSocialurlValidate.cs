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
    public class VendorSocialurlValidate : DriverTestCase
    {
        [TestMethod]
        public void vendorSocialurlValidate()
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

            //Redirect To URL
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/vendors/create");

            //Verify title
            VerifyTitle("Create a New Vendor");

            //Invalid facebook URL
            equiomentHelperAdmin.TypeText("VenFace", "INVALID");

            //Invalid Linkedln URL
            equiomentHelperAdmin.TypeText("VenLnkl", "INVALID");

            //Invalid Website URL
            equiomentHelperAdmin.TypeText("VenWeb", "INVALID");

            //Invalid Twiter URL
            equiomentHelperAdmin.TypeText("VenTwt", "INVALID");

            // Click on Save button   
            equiomentHelperAdmin.ClickElement("AllButtonSave");
           
            //Verify validation for URL displayed
            equiomentHelperAdmin.verifyElementDisplayed("VenFaceError");
            equiomentHelperAdmin.verifyElementDisplayed("VenTwtError");
            equiomentHelperAdmin.verifyElementDisplayed("VenLnklError");
            equiomentHelperAdmin.verifyElementDisplayed("VenWebError");

            //Go to create shipping page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/manage_shipping_carriers");

            //Verify title
            VerifyTitle("Manage Shipping Carrier");

            //Enter Invlalid URL
            equiomentHelperAdmin.TypeText("ShippingTrack", "INVALID");

            // Click on Save button   
            equiomentHelperAdmin.ClickElement("AllButtonSave");
        }
    }
}
