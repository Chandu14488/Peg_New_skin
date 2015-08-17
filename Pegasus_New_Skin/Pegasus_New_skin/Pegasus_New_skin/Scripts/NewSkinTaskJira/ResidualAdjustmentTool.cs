using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class ResidualAdjustmentTool : DriverTestCase
    {
        [TestMethod]
        public void residualAdjustmentTool()
        {
            string[] username = null;
            string[] password = null;
            string[] log = null;
            var oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username2");
            password = oXMLData.getData("settings/Credentials", "password2");
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
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/rir/create");

            //Verify title
            VerifyTitle("Residual Master Rules - Create Adjustments");

            //Click on 'Save' button without filling any field
            partnerAgentHelperNewSkin.ClickElement("RMPSave");

            //Verify error message
            partnerAgentHelperNewSkin.verifyElementPresent("RMPProcessorError");
            partnerAgentHelperNewSkin.verifyElementPresent("RMPSetNameError");

            //Select Processor
            partnerAgentHelperNewSkin.SelectByText("RMPProcessor", "Chy Processor");

            //Click on 'Save' button after selecting Processor
            partnerAgentHelperNewSkin.ClickElement("RMPSave");

            //Verify error 
            partnerAgentHelperNewSkin.verifyElementPresent("RMPSetNameError");

            //Select Ammount
            partnerAgentHelperNewSkin.SelectByText("RMPRule", "Amount");

            //Enter amount in alphabets
            partnerAgentHelperNewSkin.TypeText("RMPRuleField", "Alpha");

            //Click on v
            partnerAgentHelperNewSkin.ClickElement("RMPRule");

            //Verify error displayed
            partnerAgentHelperNewSkin.verifyElementPresent("RMPRuleError");

            //Enter amount in numeric
            partnerAgentHelperNewSkin.TypeText("RMPRuleField", "123");

            //Click on v
            partnerAgentHelperNewSkin.ClickElement("RMPRule");

            //Select Percantage
            partnerAgentHelperNewSkin.SelectByText("RMPRule", "Percentage");

            //Enter Percantage in alphabets
            partnerAgentHelperNewSkin.TypeText("RMPRuleField", "Alpha");

            //Click on v
            partnerAgentHelperNewSkin.ClickElement("RMPRule");

            //Verify error displayed
            partnerAgentHelperNewSkin.verifyElementPresent("RMPRuleError");

            //Enter Percantage in numeric
            partnerAgentHelperNewSkin.TypeText("RMPRuleField", "13");

            //Click on v
            partnerAgentHelperNewSkin.ClickElement("RMPRule");

            //Verify error not displayed
//            partnerAgentHelperNewSkin.verifyElementNotPresent("RMPRuleError");

            //Select Ammount
            partnerAgentHelperNewSkin.SelectByText("RMPRule", "Amount");

            //Enter Ammount upto 3 decimal
            partnerAgentHelperNewSkin.TypeText("RMPRuleField", "123.234");

            //Click on v
            partnerAgentHelperNewSkin.ClickElement("RMPRule");

            //Verify error displayed
            partnerAgentHelperNewSkin.verifyElementPresent("RMPRuleError");

            //Select Percantage
            partnerAgentHelperNewSkin.SelectByText("RMPRule", "Percentage");

            //Enter Percantage more than 100
            partnerAgentHelperNewSkin.TypeText("RMPRuleField", "1234");

            //Click on v
            partnerAgentHelperNewSkin.ClickElement("RMPRule");

            //Verify error displayed
            partnerAgentHelperNewSkin.verifyElementPresent("RMPRuleError");

            //Click on Add another button.
            partnerAgentHelperNewSkin.ClickElement("RMPAddRule");

            //Verify Field added
            partnerAgentHelperNewSkin.verifyElementPresent("RMPRuleError");

            //Enter ammount
            //Log out from the application
            GetWebDriver().Navigate().GoToUrl(log[0]);

        }
    }
}
