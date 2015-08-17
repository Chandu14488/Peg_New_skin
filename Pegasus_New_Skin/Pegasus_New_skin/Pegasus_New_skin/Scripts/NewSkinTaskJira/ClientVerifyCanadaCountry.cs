using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class ClientVerifyCanadaCountry : DriverTestCase
    {
        [TestMethod]
        public void clientVerifyCanadaCountry()
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
           GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/clients/create");
           clientHelperNewSkin.WaitForWorkAround(3000);

            //ClickOnContactTab
            clientHelperNewSkin.ClickElement("ClickOnContactTab");

            //Select Mailing Country
            clientHelperNewSkin.Select("SelectMailingCountry","Canada");
            clientHelperNewSkin.WaitForWorkAround(3000);


            //Select Location counrty
            clientHelperNewSkin.Select("SelectLocationCountry","Canada");
            clientHelperNewSkin.WaitForWorkAround(3000);

            //SelectAddressCountry
            clientHelperNewSkin.Select("SelectAddressCountry","Canada");
            clientHelperNewSkin.WaitForWorkAround(3000);

            //Clkck on Owner tab
            clientHelperNewSkin.ClickElement("OwnerTab");
            //Select Owner Address country
            clientHelperNewSkin.Select("SelectOwnerAddressCountry","Canada");
            clientHelperNewSkin.WaitForWorkAround(3000);







              
                }
            }
        }
    

