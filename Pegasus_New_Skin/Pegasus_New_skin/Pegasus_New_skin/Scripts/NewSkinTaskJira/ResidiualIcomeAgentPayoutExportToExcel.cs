using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;
using LinqToExcel;
using System.IO;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class ResidiualIcomeAgentPayoutExportToExcel : DriverTestCase
    {
     //   [TestMethod]
        public void residiualIcomeAgentPayoutExportToExcel()
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
            var residualIcomeOfficeHelper = new ResidualIcomeOfficeHelper(GetWebDriver());

            //Variable
            var name = "TestAgent" + GetRandomNumber();


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            residualIcomeOfficeHelper.ClickElement("ResidualIncomeTab");

            //Redirect to Agnet
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/rir/agent_payouts_summary");

            //ClickOnExport
            residualIcomeOfficeHelper.ClickElement("ClickOnExport");
            residualIcomeOfficeHelper.WaitForWorkAround(3000);

            //ExportToExcel
            residualIcomeOfficeHelper.ClickElement("ExportToExcel");
            residualIcomeOfficeHelper.WaitForWorkAround(3000);
 
            //Click on Excel report button
    //        residualIcomeOfficeHelper.ClickElement("ExcelReoprt");

            var user = residualIcomeOfficeHelper.CurrentUser();

            //Get newly created file name from downloads folder
            var newfilename = residualIcomeOfficeHelper.Getnewfilename(new DirectoryInfo(@"C:\" + user + @"s\" + user + @"\Downloads\"));

            var filepath = @"C:\" + user + @"s\" + user + @"\Downloads\" + newfilename;

            var excelFile = new ExcelQueryFactory(filepath).Worksheet(0);

            var artistAlbums = from a in excelFile select a;
            int i = 0;
            foreach (var a in artistAlbums)
            {
                if (a["Agent Name"] == "Agent Name")
                {
                }
            }
        }
    }
}

