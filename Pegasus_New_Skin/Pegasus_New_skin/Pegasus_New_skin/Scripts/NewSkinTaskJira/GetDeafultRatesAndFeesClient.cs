using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class GetDeafultRatesAndFeesClient : DriverTestCase
    {
        [TestMethod]
        public void getDeafultRatesAndFeesClient()
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
           clientHelperNewSkin.ClickElement("ClickOnRateFees");
           clientHelperNewSkin.WaitForWorkAround(3000);

            // SelectProcessorRF
           clientHelperNewSkin.Select("SelectProcessorRF", "Processor 1186688466 Edited");
           clientHelperNewSkin.WaitForWorkAround(3000);

           // SeleectMerchantRF
           clientHelperNewSkin.Select("SeleectMerchantRF", "test");
           clientHelperNewSkin.WaitForWorkAround(3000);

           // SelectProcessorRF
           clientHelperNewSkin.Select("MethodOfAcceptingRF", "Manually swiped");
           clientHelperNewSkin.WaitForWorkAround(3000);

            //clickClickOnGetDefaultRates
           clientHelperNewSkin.ClickElement("ClickOnGetDefaultRates");
           clientHelperNewSkin.WaitForWorkAround(3000);

            //Accept ALERT
           clientHelperNewSkin.AcceptAlert();
           clientHelperNewSkin.WaitForWorkAround(4000);

            //Verify
           clientHelperNewSkin.IsElementPresent("VerifyPopulatedFiedl");
           clientHelperNewSkin.WaitForWorkAround(4000);



                }
            }
   }
    

