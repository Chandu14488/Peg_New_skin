using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.Corp
{
    [TestClass]
    public class RateAndFeesPushToOfficeBtn : DriverTestCase
    {
        [TestMethod]
        public void rateAndFeesPushToOfficeBtn()
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
            var masterDataCorpHelper = new MasterDataCorpHelper(GetWebDriver());

            //Variable
            var name = "PushToOffice" + RandomNumber(33,999);
            var Code = "1" + RandomNumber(1, 99);

            //Login with valid credential  Username
            masterDataCorpHelper.TypeText("EnterUsername", "selcorp");

            //Login with valid credential password
            masterDataCorpHelper.TypeText("EnterPassword", "seWelcome2");

            //Click On Login Button
            masterDataCorpHelper.ClickElement("LoginBtn");

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click on Residual Income tab
            masterDataCorpHelper.ClickElement("ClickMasterTab");

            //Click to Import
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/masterdata/rates_fees");

            //Click on Push To Office Button
            masterDataCorpHelper.VerifyText("ClickOnPushOffice", "Push to Offices");
            masterDataCorpHelper.WaitForWorkAround(3000);

       



        }
    }
}