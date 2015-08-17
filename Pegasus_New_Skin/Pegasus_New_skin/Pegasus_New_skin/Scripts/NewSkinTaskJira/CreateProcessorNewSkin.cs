using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class CreateProcessorNewSkin : DriverTestCase
    {
        [TestMethod]
        public void createProcessorNewSkin()
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
           // clientHelperNewSkin.ClickElement("ClickOnMasterDataCorp");


           //ClickOnCreateClient
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/masterdata/processor_types");
           clientHelperNewSkin.WaitForWorkAround(3000);

            //Click on Create
           clientHelperNewSkin.ClickElement("ClickOnCreateBtn");
           clientHelperNewSkin.WaitForWorkAround(3000);

           //Click save
           clientHelperNewSkin.ClickElement("ClickOnSavePro");
           clientHelperNewSkin.WaitForWorkAround(3000);

           //EnterProcessorName
           var procnam = "TestPro" + RandomNumber(1,99);
           clientHelperNewSkin.TypeText("EnterProcessorName",procnam);

           //EnterProcessorName
           var Code = "1" + RandomNumber(1, 99);
           clientHelperNewSkin.TypeText("EnterCode", Code);

            //Click save
           clientHelperNewSkin.ClickElement("ClickOnSavePro");
           clientHelperNewSkin.WaitForWorkAround(3000);

            
            //Verify 
           clientHelperNewSkin.VerifyPageText("Processor is successfully created!!");







                }
            }
        }
    

