using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class ContactOwnerTab : DriverTestCase
    {
        [TestMethod]
        public void contactOwnerTab()
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
            var clientHelperNewSkin = new ClientHelperNewSkin(GetWebDriver());

            //VARIABLE
            var name = "TestEmployee" + GetRandomNumber();


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //ClickOnCreateClient
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/clients/create");

            //Veify title
            VerifyTitle("Create a Client");

            //Click on 'Contact tab
            clientHelperNewSkin.ClickElement("ClickOnContactTab");

            //Verify title
            VerifyTitle("Create a Client");

            //Verify Owner information is not available
            clientHelperNewSkin.VerifyTextNotAvailable("Owner Information");

            //Click on 'Owner tab'
            clientHelperNewSkin.ClickElement("OwnerTab");

            //Verify title
            VerifyTitle("Create a Client");

            //Verify Contact information is not available
            clientHelperNewSkin.VerifyTextNotAvailable("Addresses");
        }
    }
}
    

