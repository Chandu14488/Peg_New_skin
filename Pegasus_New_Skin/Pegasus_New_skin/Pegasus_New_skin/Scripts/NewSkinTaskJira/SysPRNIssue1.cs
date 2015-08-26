using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class SysPRNIssue1 : DriverTestCase
    {
        [TestMethod]
        public void sysPRNIssue1()
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
            var partnerAgentHelperNewSkin = new PartnerAgentHelperNewSkin(GetWebDriver());

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Go to office code management
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/office_codes_management");

            //Verify title
            VerifyTitle("Office Codes Management");

         //Select Sysprins
            partnerAgentHelperNewSkin.SelectByText("SelectSys", "Sysprins");
            partnerAgentHelperNewSkin.WaitForWorkAround(3000);

            //Enter value1
            partnerAgentHelperNewSkin.TypeText("Value1", GetRandomNumber().ToString());

            //Click on Add button
            partnerAgentHelperNewSkin.ClickElement("AddAnother");

            partnerAgentHelperNewSkin.WaitForWorkAround(1000);

           //Click on Second primary option
            partnerAgentHelperNewSkin.ClickElement("SecOp");

            //Click on Save button
            partnerAgentHelperNewSkin.ClickElement("RMPSave");
            partnerAgentHelperNewSkin.WaitForWorkAround(3000);

            // verify error not displayed
            //partnerAgentHelperNewSkin.VerifyTextNotAvailable("blank Sys/Prin Number has been removed and now there is no longer a Primary Sys/Prin");

        }
    }
}
