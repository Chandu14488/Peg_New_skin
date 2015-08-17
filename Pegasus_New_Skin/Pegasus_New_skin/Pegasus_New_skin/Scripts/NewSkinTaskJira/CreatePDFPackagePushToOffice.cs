using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class CreatePDFPackagePushToOffice : DriverTestCase
    {
        [TestMethod]
        public void createPDFPackagePushToOffice()
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


            //Variable random
            var name = "Push To Office" + RandomNumber(1, 999);


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


            //cLICK ON pdf
            pDFTemplateAdminHelper.ClickElement("ClickCreatePackage");
            pDFTemplateAdminHelper.WaitForWorkAround(2000);

            //Enter pakage name
            pDFTemplateAdminHelper.TypeText("PackageName", name);

            //Select Module
            pDFTemplateAdminHelper.Select("SelectModule", "20");
            pDFTemplateAdminHelper.WaitForWorkAround(6000);

            //Select
            pDFTemplateAdminHelper.SelectDropDownByText("//*[@id='PdfTemplatePdfTemplateId']", "Clone of FNPMPA");
            pDFTemplateAdminHelper.WaitForWorkAround(3000);

            //SelectCategoryPackage
            pDFTemplateAdminHelper.SelectDropDownByText("//*[@id='PdfTemplatePdfCategoryId']", "Card Service Agreements");

            //PDFAccessedByAllOffice
            pDFTemplateAdminHelper.ClickElement("PDFAccessedByAllOffice");

            //Check Display in Tab
            pDFTemplateAdminHelper.ClickElement("CheckDisplayInTab");

            //Check Can Share
            pDFTemplateAdminHelper.ClickElement("CheckCanShare");

            //CanEmailPDF
            pDFTemplateAdminHelper.ClickElement("CanEmailPDF");

            //Save PDF Package
            pDFTemplateAdminHelper.ClickElement("SavePDFPakage");
            pDFTemplateAdminHelper.WaitForWorkAround(3000);


            //ClickOnWelcomeToLogout
            pDFTemplateAdminHelper.ClickElement("ClickOnWelcomeToLogout");
            pDFTemplateAdminHelper.WaitForWorkAround(3000);

            //LogoutFromCorp
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/logout");
            pDFTemplateAdminHelper.WaitForWorkAround(3000);

            //EnterUserName
            pDFTemplateAdminHelper.TypeText("EnterUserName","AslamKhan");

            //EnterPassword
            pDFTemplateAdminHelper.TypeText("EnterPassword","1qaz!QAZ");

            //LoginButton
            pDFTemplateAdminHelper.ClickElement("LoginButton");
            pDFTemplateAdminHelper.WaitForWorkAround(4000);

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


            //EnterPDFToSerch
            pDFTemplateAdminHelper.TypeText("EnterPDFToSerch", name);
            pDFTemplateAdminHelper.WaitForWorkAround(4000);

            //verify text
            pDFTemplateAdminHelper.VerifyText("TextToVerify", name);
            pDFTemplateAdminHelper.WaitForWorkAround(2000);

           }

      }
}

