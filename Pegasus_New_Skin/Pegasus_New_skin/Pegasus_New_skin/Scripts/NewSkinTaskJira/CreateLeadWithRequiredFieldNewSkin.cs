using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class CreateLeadWithRequiredFieldNewSkin : DriverTestCase
    {
        [TestMethod]
        public void createLeadWithRequiredFieldNewSkin()
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
            var leadNewSkinHelper = new LeadNewSkinHelper(GetWebDriver());

            //Variable

            var FirstName = "Test" + RandomNumber(1, 99);
            var LastName = "Tester" + RandomNumber(1, 99);
            var Number = "12345678" + RandomNumber(10, 99);

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click on Clients in Topmenu
            leadNewSkinHelper.ClickElement("ClickOnLeadsTab");


//################################# CREATE A LEAD   #############################################

            //Click On Create
            //leadNewSkinHelper.ClickElement("ClickOnCreate");
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/leads/create");

            //Select Lead Type
            leadNewSkinHelper.Select("SelectLeadType", "Processing");

            //Select Lead Status
            leadNewSkinHelper.Select("SelectLeadStatus", "New");

            //Select Responsibity
            leadNewSkinHelper.Select("SelectResponsibility", "637");

            //Click on Company detail tab
       //     leadNewSkinHelper.ClickElement("ClickOnCompanyDetails");

            // Click on Create Dublicate button
            // leadNewSkinHelper.DudlicateClick();
            leadNewSkinHelper.ClickElement("SaveLeadNewSkin");
            leadNewSkinHelper.WaitForWorkAround(3000);
      


            //Select Salutation
            leadNewSkinHelper.Select("SelectSalutaionLead", "Mr");

            //Enter First Name
            leadNewSkinHelper.TypeText("FirstNAME", FirstName);

            leadNewSkinHelper.TypeText("LeadLastName", "Last");

            //Enter Company Name  
            leadNewSkinHelper.TypeText("CompanyName", "TEST COMPANY");

            // Click on Create Dublicate button
           leadNewSkinHelper.DudlicateClick();
            leadNewSkinHelper.WaitForWorkAround(3000);
            leadNewSkinHelper.VerifyPageText("Lead saved successfully. .");

        }
    }
}
