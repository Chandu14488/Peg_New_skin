using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;


namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class ClientPDFInactive : DriverTestCase
    {
        [TestMethod]
        public void clientPDFInactive()
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

            //Visit to PDF template page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/pdf_templates");

            //Verify title
            VerifyTitle("PDF Templates");

            string VerifyInactive = "//table[@id='list1']/tbody/tr[2]/td/a/i[contains(@class,'thumbs-o-up')]";
            string text = "//table[@id='list1']/tbody/tr[2]/td/a[contains(@href,'view')]";

            partnerAgentHelperNewSkin.WaitForText("PDF Template is successfully",20);
            string PdfName = partnerAgentHelperNewSkin.GetText(text);
            if (!partnerAgentHelperNewSkin.IsElementPresent(VerifyInactive))
            {
                partnerAgentHelperNewSkin.ClickElement("ActivatePDF");
                partnerAgentHelperNewSkin.AcceptAlert();
                partnerAgentHelperNewSkin.WaitForWorkAround(5000);
                
            }

            //Go to client page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/clients");

            //verify title
           VerifyTitle("Clients");

            //Open client
            partnerAgentHelperNewSkin.ClickElement("ViewClient");

            //verify title
            VerifyTitle(" - Details");

           //click on pdf tab
            partnerAgentHelperNewSkin.ClickElement("ClPdf");

            //verify title
            VerifyTitle(" - Pdfs");

            //verify pdf not available
            partnerAgentHelperNewSkin.VerifyTextNotPresent(PdfName+".pdf");
            

            //Log out from the application
            GetWebDriver().Navigate().GoToUrl(log[0]);

        }
    }
}
