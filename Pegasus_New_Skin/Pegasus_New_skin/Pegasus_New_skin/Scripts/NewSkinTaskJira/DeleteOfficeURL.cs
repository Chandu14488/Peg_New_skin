using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.Corp
{
    [TestClass]
    public class DeleteOfficeURL : DriverTestCase
    {
        [TestMethod]
        public void deleteOfficeURL()
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
            var name = "Test" + RandomNumber(99, 999);


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
                
            //Verify title
            VerifyTitle("Offices");

            //Try to delete an office via URL
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/offices/delete/1");

            //Verify User get privilage message
            createOfficeHelperNewSkin.WaitForText("You don't have privileges to delete this office.", 30);

            //Verify title
            VerifyTitle("Offices");

            //Try to delete an office via URL
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/offices/delete/2");

            //Verify User get privilage message
            createOfficeHelperNewSkin.WaitForText("You don't have privileges to delete this office.", 30);

            //Verify title
            VerifyTitle("Offices");

            //Try to delete an office via URL
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/offices/delete/3");

            //Verify User get privilage message
            createOfficeHelperNewSkin.WaitForText("You don't have privileges to delete this office.", 30);
            
            //Verify title
            VerifyTitle("Offices");

            //Try to delete an office via URL
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/offices/delete/4");

            //Verify User get privilage message
            createOfficeHelperNewSkin.WaitForText("You don't have privileges to delete this office.", 30);

            //Verify title
            VerifyTitle("Offices");

        }
    }
}
