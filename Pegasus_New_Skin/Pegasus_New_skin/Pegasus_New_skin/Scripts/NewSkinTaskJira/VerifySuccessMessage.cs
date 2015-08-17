﻿using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class VerifySuccessMessage : DriverTestCase
    {
        [TestMethod]
        public void verifySuccessMessage()
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

            //Go to Import Leads page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/leads/import");

            //Verify title
            VerifyTitle("Leads");

            string file = GetPathToFile() + "leadslist.csv";
            
            //Uplaod file
            partnerAgentHelperNewSkin.UploadFile("//*[@id='vcard_file']", file);

            //Click on Import button
            partnerAgentHelperNewSkin.ClickElement("LeadImport");

            //Verify success message
            partnerAgentHelperNewSkin.WaitForText("Records Imported Successfully.",20);
           

            //Enter ammount
            //Log out from the application
            GetWebDriver().Navigate().GoToUrl(log[0]);

        }
    }
}
