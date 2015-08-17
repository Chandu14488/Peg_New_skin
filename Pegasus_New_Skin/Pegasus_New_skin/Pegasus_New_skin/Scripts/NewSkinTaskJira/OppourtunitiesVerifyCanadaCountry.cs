using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class OppourtunitiesVerifyCanadaCountry : DriverTestCase
    {
        [TestMethod]
        public void oppourtunitiesVerifyCanadaCountry()
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
            clientHelperNewSkin.ClickElement("ClickOnOpporTab");

           //ClickOnCreateClient
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/opportunities/create");
           clientHelperNewSkin.WaitForWorkAround(3000);

            //Select Mailing Country
           clientHelperNewSkin.Select("SelectAddressCountryOpp", "Canada");
            clientHelperNewSkin.WaitForWorkAround(3000);


            //Select Location counrty
            clientHelperNewSkin.Select("SelectMailingOppCountry", "Canada");
            clientHelperNewSkin.WaitForWorkAround(3000);

              
                }
            }
        }
    

