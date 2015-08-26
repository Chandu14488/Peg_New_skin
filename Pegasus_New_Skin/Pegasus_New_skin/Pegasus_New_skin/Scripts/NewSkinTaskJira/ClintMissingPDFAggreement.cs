using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class ClintMissingPDFAggreement : DriverTestCase
    {
        [TestMethod]
        public void clintMissingPDFAggreement()
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

            //Click on Agent in Topmenu
            clientHelperNewSkin.ClickElement("ClickOnClientTab");


           //ClickOnCreateClient
           GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/clients");
           
            //Verify Title
           VerifyTitle("Clients");

            //Open client
           clientHelperNewSkin.ClickElement("OpenClient");

            //Verify title
           VerifyTitle("- Details");

            //Click on PDF tab
           clientHelperNewSkin.ClickElement("PDFTab");

            //Verify title
           VerifyTitle("- Pdfs");

            //Verify Aggreement availabe
           clientHelperNewSkin.verifyElementVisible("Aggreement");
              
        }
    }
}
    

