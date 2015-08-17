using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class AllAgentDisplayePage : DriverTestCase
    {
        [TestMethod]
        public void allAgentDisplayePage()
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
            var saleAgentRevenueAdjustmentHelper = new SaleAgentRevenueAdjustmentHelper(GetWebDriver());


            //Variable random
            var name = "TESTCLIENT" + RandomNumber(1,999);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click on Agent in Topmenu
            saleAgentRevenueAdjustmentHelper.ClickElement("ClickOnAgentTab");
            saleAgentRevenueAdjustmentHelper.WaitForWorkAround(3000);


//################################# CREATE A agent   #############################################

            //Click on Click On Partner Agent
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/agents");
           saleAgentRevenueAdjustmentHelper.WaitForWorkAround(3000);


            //Verify text 
           VerifyTitle("selOffice's All Agents");
           saleAgentRevenueAdjustmentHelper.WaitForWorkAround(2000);

            //Select SelectUserType
            saleAgentRevenueAdjustmentHelper.Select("SelectUserType","Employee");
            saleAgentRevenueAdjustmentHelper.WaitForWorkAround(2000);

             //Select SelectUserType
            saleAgentRevenueAdjustmentHelper.Select("SelectUserType","1099 Sales Agent");
            saleAgentRevenueAdjustmentHelper.WaitForWorkAround(2000);

             //Select SelectUserType
            saleAgentRevenueAdjustmentHelper.Select("SelectUserType","Partner Agent");
            saleAgentRevenueAdjustmentHelper.WaitForWorkAround(2000);
            

             //Select SelectUserType
            saleAgentRevenueAdjustmentHelper.Select("SelectUserType","Partner Association");
            saleAgentRevenueAdjustmentHelper.WaitForWorkAround(2000);


            }

        }
    }

