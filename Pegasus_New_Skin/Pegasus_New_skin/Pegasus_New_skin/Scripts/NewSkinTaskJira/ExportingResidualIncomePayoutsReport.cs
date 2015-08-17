using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class ExportingResidualIncomePayoutsReport : DriverTestCase
    {
        [TestMethod]
        public void exportingResidualIncomePayoutsReport()
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

            //navigate to the repror page.
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/rir/reports");

            //verify title
            VerifyTitle("Residual Income - Reports");           

            //Click on Excel report button
            partnerAgentHelperNewSkin.ClickElement("ExcelReoprt");

            var user = partnerAgentHelperNewSkin.CurrentUser();

            //Get newly created file name from downloads folder
            var newfilename = partnerAgentHelperNewSkin.Getnewfilename(new DirectoryInfo(@"C:\" + user + @"s\" + user + @"\Downloads\"));

            var filepath =  @"C:\" + user + @"s\" + user + @"\Downloads\" + newfilename;

            //Check file contains data
            partnerAgentHelperNewSkin.FileIsNotBlank(filepath);
        }
    }
}
