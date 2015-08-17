using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class EditPDFTemplateNewSkin : DriverTestCase
    {
        [TestMethod]
        public void editPDFTemplateNewSkin()
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
            var pDFTemplateAdminHelper = new PDFTemplateAdminHelper(GetWebDriver());


            //Variable random
            var name = "TESTCLIENT" + RandomNumber(1,999);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Redirect To Admin
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/admin");
            pDFTemplateAdminHelper.WaitForWorkAround(4000);


            //ClickOnPdfTab
            pDFTemplateAdminHelper.ClickElement("ClickOnPdfTab");
     
            //Redirect To
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/pdf_templates/import");
            pDFTemplateAdminHelper.WaitForWorkAround(2000);


            //ChooseModule
            pDFTemplateAdminHelper.Select("ChooseModule", "20");

            var path = GetPathToFile() + "2.pdf";
            //bROWSER
            pDFTemplateAdminHelper.UploadFile("//*[@id='PdfTemplatePdfFile']", path);


            //Click import
            pDFTemplateAdminHelper.ClickElement("ClickOnImport");
            pDFTemplateAdminHelper.WaitForWorkAround(10000);

            //ClickOnNext
            pDFTemplateAdminHelper.ClickElement("ClickOnNext");

            //Select Category
            pDFTemplateAdminHelper.SelectDropDownByText("//*[@id='PdfTemplatePdfCategoryId']", "Card Service Agreements");

            //ClickOnSave
            pDFTemplateAdminHelper.ClickElement("ClickOnSave");
            pDFTemplateAdminHelper.WaitForWorkAround(3000);
            //Verify 
            pDFTemplateAdminHelper.VerifyPageText("PDF Template options saved successfully.");

            //Enter Pdf To Search
            pDFTemplateAdminHelper.TypeText("EnterPDFToSearch", "2.pdf");
            pDFTemplateAdminHelper.WaitForWorkAround(3000);

            //Click on Edit
            pDFTemplateAdminHelper.ClickElement("ClickOnEdit");
            pDFTemplateAdminHelper.WaitForWorkAround(3000);


            //Enter Template Name
            pDFTemplateAdminHelper.TypeText("EnterTemplateName","Replace Name");

            //Click On Save
            pDFTemplateAdminHelper.ClickElement("SavebuttonEDit");
            pDFTemplateAdminHelper.WaitForWorkAround(3000);

            }

        }
    }

