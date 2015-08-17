using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class GetDeafultRatesAndFeesLead : DriverTestCase
    {
        [TestMethod]
        public void getDeafultRatesAndFeesLead()
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
            clientHelperNewSkin.ClickElement("ClickOnLeadTab");


           //ClickOnCreateClient
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/leads/create");
           clientHelperNewSkin.WaitForWorkAround(3000);

            //ClickOnContactTab
           clientHelperNewSkin.ClickElement("ClickOnRateFees");
           clientHelperNewSkin.WaitForWorkAround(3000);

            // SelectProcessorRF
           clientHelperNewSkin.Select("SelectProcessorRFL", "Processor 1186688466 Edited");
           clientHelperNewSkin.WaitForWorkAround(5000);

           // SeleectMerchantRF
           clientHelperNewSkin.Select("SeleectMerchantRFL", "test");
           clientHelperNewSkin.WaitForWorkAround(3000);

           // SelectProcessorRF
           clientHelperNewSkin.Select("LeadAcceptingMethod", "Manually Swiped");
           clientHelperNewSkin.WaitForWorkAround(3000);

            //clickClickOnGetDefaultRates
           clientHelperNewSkin.ClickElement("ClickOnGetDefaultRatesL");
           clientHelperNewSkin.WaitForWorkAround(3000);

            //Accept ALERT
           clientHelperNewSkin.AcceptAlert();
           clientHelperNewSkin.WaitForWorkAround(4000);

            //Verify
           clientHelperNewSkin.IsElementPresent("VerifyPopulatedFiedlL");
           clientHelperNewSkin.WaitForWorkAround(4000);



                }
            }
   }
    

