using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class PracticalPDFProblem : DriverTestCase
    {
        [TestMethod]
        public void practicalPDFProblem()
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
            var pDFTemplateAdminHelper = new PDFTemplateAdminHelper(GetWebDriver());

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //ClickOnPdfTab
            pDFTemplateAdminHelper.ClickElement("ClickOnPdfTab");

            //Redirect To
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/pdf_templates");
            pDFTemplateAdminHelper.WaitForWorkAround(2000);

            //Redirect To Import
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/pdf_templates/import");

            //ChooseModule
            pDFTemplateAdminHelper.Select("ChooseModule", "20");

            var path = GetPathToFile() + "Test_Final.pdf";
            
            //bROWSER
            pDFTemplateAdminHelper.UploadFile("//*[@id='PdfTemplatePdfFile']", path);


            //Click import
            pDFTemplateAdminHelper.ClickElement("ClickOnImport");
            pDFTemplateAdminHelper.WaitForWorkAround(10000);

            //Select tab
            pDFTemplateAdminHelper.SelectByText("Tab", "Business Details");
            pDFTemplateAdminHelper.WaitForWorkAround(5000);

            //Verify fields availble under section
            pDFTemplateAdminHelper.SelectByText("Section", "Merchant Account Data");
            pDFTemplateAdminHelper.WaitForWorkAround(5000);

            //Verify fields under fields
            pDFTemplateAdminHelper.SelectByText("Fields", "Merchant Type");

            //Click on Next button
            pDFTemplateAdminHelper.ClickElement("ClickOnNext");

            //Verify mapped successfully
            pDFTemplateAdminHelper.WaitForText("PDF fields mapped successfully.", 30);


            }

        }
    }

