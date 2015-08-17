using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.Corp
{
    [TestClass]
    public class MasterDataProcessorPushToOfficeNewSkin : DriverTestCase
    {
        [TestMethod]
        public void masterDataProcessorPushToOfficeNewSkin()
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
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/masterdata/processor_types");

            //Click On Create
            masterDataCorpHelper.ClickElement("ClickOnCreate");

            //Click On Save Btn
            masterDataCorpHelper.ClickElement("ClickOnSaveBtn");
            masterDataCorpHelper.WaitForWorkAround(5000);

            //Enter Processor name
            masterDataCorpHelper.TypeText("ProcessorName", name);

            //Enter ProcessorCode
            masterDataCorpHelper.TypeText("ProcessorCode", Code);

            //Click On Save Btn
            masterDataCorpHelper.ClickElement("ClickOnSaveBtn");
            masterDataCorpHelper.WaitForWorkAround(3000);

            //Verify text present
            masterDataCorpHelper.VerifyPageText("Processor is successfully created!!");
            masterDataCorpHelper.WaitForWorkAround(3000);

            //Click on Push TO office
            masterDataCorpHelper.ClickElement("ClickOnPushOffice");
            masterDataCorpHelper.AcceptAlert();
            masterDataCorpHelper.WaitForWorkAround(3000);
            masterDataCorpHelper.VerifyPageText("Processors successfully pushed to offices.");

            //Mouse Hover To 
            masterDataCorpHelper.MouseOver("//*[@id='page-wrapper']/div[1]/nav/ul/li[2]/a/span");

            //Click On Logout
            masterDataCorpHelper.ClickElement("ClickOnLogout");
            masterDataCorpHelper.WaitForWorkAround(3000);



            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");
            

            //Navigate to Admin
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/admin");


            //Click on
            masterDataCorpHelper.ClickElement("ClickOnMaterOff");
             

            //Redirect To Processor
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/processor_types");

            //Enter SearchProcessor
            masterDataCorpHelper.TypeText("SearchProcessor",name);
            masterDataCorpHelper.WaitForWorkAround(3000);


           //Enter Processor
            masterDataCorpHelper.TypeText("EnterCode", Code);
           masterDataCorpHelper.WaitForWorkAround(6000);

            //Verify 
            masterDataCorpHelper.VerifyPageText(name);

            //Verify
            masterDataCorpHelper.VerifyPageText(Code);
            masterDataCorpHelper.WaitForWorkAround(3000);



        }
    }
}