using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class UserVerifyCountryCorp : DriverTestCase
    {
        [TestMethod]
        public void userVerifyCountryCorp()
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
            var clientHelperNewSkin = new ClientHelperNewSkin(GetWebDriver());

            //VARIABLE
            var name = "TestEmployee" + GetRandomNumber();


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click on Agent in Topmenu
            clientHelperNewSkin.ClickElement("OfficeTabCorp");


           //ClickOnCreateClient
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/offices/create");
           clientHelperNewSkin.WaitForWorkAround(3000);


            //Select Mailing Country
           clientHelperNewSkin.Select("SelectCountryCorp", "Canada");
            clientHelperNewSkin.WaitForWorkAround(3000);


              
                }
            }
  }
    

