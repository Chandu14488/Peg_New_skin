using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class ResidualAdjustmentTool1 : DriverTestCase
    {
        [TestMethod]
        public void residualAdjustmentTool1()
        {
            string[] username = null;
            string[] password = null;
            string[] log = null;
            var oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username");
            password = oXMLData.getData("settings/Credentials", "password");
            log = oXMLData.getData("settings/URL", "logout");

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

            //Go to Create Residual Adjustment Tool page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/rir/adjustments_tool/create");

            //Verify title
            VerifyTitle("Create Adjustment");

           //Select Merchant
            partnerAgentHelperNewSkin.SelectByText("RPMAdjust", "Agent");

            //Click on specific agent
            partnerAgentHelperNewSkin.ClickElement("RPMSpeficAgent");

            //Click on 'Select agent'
            partnerAgentHelperNewSkin.ClickElement("RPMSelectAgent");

            //Verify Page is clickable
            partnerAgentHelperNewSkin.ClickElement("RPMClose");

            //Click on Specific Merchant
            partnerAgentHelperNewSkin.ClickElement("RPMSpeficMerchant");

            //Click on 'Select marchent'
            partnerAgentHelperNewSkin.ClickElement("RPMSelectMerchant");

            //Verify Page is clickable
            partnerAgentHelperNewSkin.ClickElement("RPMClose");

            //Select Proseccor
            partnerAgentHelperNewSkin.SelectByText("RPMSelectProcessor", "Chy Processor");

            //Verify file format contains dropdown
            partnerAgentHelperNewSkin.verifyElementPresent("RPMFileFormat");

            //Select type
            partnerAgentHelperNewSkin.SelectByText("RPMType", "Transaction");

            //Enter Name
            partnerAgentHelperNewSkin.TypeText("RPMName", "Demo");
            
            //Click on Save button
            partnerAgentHelperNewSkin.ClickElement("ClickOnSaveBtnAdjustmnet");

            //Go to Residual Adjustment Tool page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/rir/adjustments_tool");

            //Verify title
            VerifyTitle("Adjustments Tool");

            //Click on Reporting Period
            partnerAgentHelperNewSkin.ClickElement("RPMPeriod");

            //Verify Calendar available
            partnerAgentHelperNewSkin.verifyElementPresent("RPMCalender");

            //Enter ammount
            //Log out from the application
            GetWebDriver().Navigate().GoToUrl(log[0]);

        }
    }
}
