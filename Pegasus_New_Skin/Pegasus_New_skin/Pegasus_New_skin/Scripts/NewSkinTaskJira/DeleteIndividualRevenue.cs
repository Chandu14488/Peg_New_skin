using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class DeleteIndividualRevenue : DriverTestCase
    {
        [TestMethod]
        public void deleteIndividualRevenue()
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
            var partnerAgentHelperNewSkin = new PartnerAgentHelperNewSkin(GetWebDriver());

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Go to Client page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/clients");

            //Verify title
            VerifyTitle("Clients");

            //Open on a clint
            partnerAgentHelperNewSkin.ClickElement("Client");

            //Verify title
            VerifyTitle("Company - Details");

            //Click on residual income
            partnerAgentHelperNewSkin.ClickElement("ClientIncome");

            //Verify title
            VerifyTitle(" - Residual Income");

            //Click on Set parnter revenue
            partnerAgentHelperNewSkin.doubleClick("PartnerShare");

            //Enter details
            partnerAgentHelperNewSkin.TypeText("ParnterShareInput", "1000");

            //Click on Save button
            partnerAgentHelperNewSkin.ClickElement("PartnerShareSave");

            //Verify title
            VerifyTitle(" - Residual Income");

            //Click on delete button
            partnerAgentHelperNewSkin.ClickElement("PartnerShareDelete");

            //Accept alert
            partnerAgentHelperNewSkin.AcceptAlert();

            //Verify deleted successfully
            partnerAgentHelperNewSkin.WaitForTextHide("1000",20);

            //Verify title
            VerifyTitle(" - Residual Income");

            //Click on Set parnter revenue
            partnerAgentHelperNewSkin.doubleClick("PartnerAgent");

            //Enter details
            partnerAgentHelperNewSkin.TypeText("PartnerAgentInput", "1000");

            //Click on Save button
            partnerAgentHelperNewSkin.ClickElement("PartternAgentSave");

            //Verify title
            VerifyTitle(" - Residual Income");

            //Click on delete button
            partnerAgentHelperNewSkin.ClickElement("PartnerShareDelete");

            //Accept alert
            partnerAgentHelperNewSkin.AcceptAlert();

            //Verify deleted successfully
            partnerAgentHelperNewSkin.WaitForTextHide("1000", 20);

            //Logout from the application
            GetWebDriver().Navigate().GoToUrl(log[0]);

        }
    }
}
