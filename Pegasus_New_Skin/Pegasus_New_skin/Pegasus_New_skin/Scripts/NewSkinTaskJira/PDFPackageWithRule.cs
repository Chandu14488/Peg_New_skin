using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class PDFPackageWithRule : DriverTestCase
    {
        [TestMethod]
        public void pDFPackageWithRule()
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
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/pdf_templates");
            pDFTemplateAdminHelper.WaitForWorkAround(2000);


            //cLICK ON pdf
            pDFTemplateAdminHelper.ClickElement("ClickCreatePackage");
            pDFTemplateAdminHelper.WaitForWorkAround(2000);

            //Enter pakage name
            pDFTemplateAdminHelper.TypeText("PackageName","Test Pakage");

            //Select Module
            pDFTemplateAdminHelper.Select("SelectModule", "20");
            pDFTemplateAdminHelper.WaitForWorkAround(3000);

            //Click SelectPDFTempwithRule
            pDFTemplateAdminHelper.ClickElement("SelectPDFTempwithRule");
            pDFTemplateAdminHelper.WaitForWorkAround(4000);

            //Template Rule Name
            pDFTemplateAdminHelper.TypeText("TemplateRuleName", "Test Rule");

            //SelectRuleType
            pDFTemplateAdminHelper.Select("SelectRuleType", "if");
            pDFTemplateAdminHelper.WaitForWorkAround(2000);

            //SelectStatus
          //  pDFTemplateAdminHelper.Select("SelectStatus", "clients.client_type");
            pDFTemplateAdminHelper.SelectDropDownByText("//*[@id='if_field_left_0']", "Client Type");
            pDFTemplateAdminHelper.WaitForWorkAround(2000);

            //SelectStatus
            pDFTemplateAdminHelper.Select("SelectOperatorType", "li");

            //SelectStatus
         //   pDFTemplateAdminHelper.Select("StatusNew", "New");

            //SelectStatus
            pDFTemplateAdminHelper.SelectDropDownByText("//*[@id='ImportIndexPopIfFieldValue']", "Clone of FNPAdd Lo Form 2");

            //Click Add Pdf
            pDFTemplateAdminHelper.ClickElement("ADDPDF");
            pDFTemplateAdminHelper.WaitForWorkAround(2000);

            //SelectCategoryPackage
            pDFTemplateAdminHelper.Select("SelectCategoryPackage", "336");

            //Save PDF Package
            pDFTemplateAdminHelper.ClickElement("SavePDFPakage");
            pDFTemplateAdminHelper.WaitForWorkAround(3000);

            //Verify 
            pDFTemplateAdminHelper.VerifyPageText("PDF Package Template Created Successfully");
            pDFTemplateAdminHelper.WaitForWorkAround(3000);


            }

        }
    }

