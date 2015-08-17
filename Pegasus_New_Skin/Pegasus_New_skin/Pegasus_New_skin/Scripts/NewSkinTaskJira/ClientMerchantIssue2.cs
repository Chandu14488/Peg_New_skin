﻿using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class ClientMerchantIssue2 : DriverTestCase
    {
        [TestMethod]
        public void clientMerchantIssue2()
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

            //Go to create a client page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/clients/create");

            //Verify title
            VerifyTitle("Create a Client");

            //Click on 'CustomerRelation' tab
            partnerAgentHelperNewSkin.ClickElement("CustomerRelation");

            //Verify CustomerRelation tab is highlighted
            partnerAgentHelperNewSkin.verifyElementPresent("CustomerRelationHighlighted");

            //Verify Terminals tab not highlighted
            partnerAgentHelperNewSkin.verifyElementNotPresent("TerminalsHighlighted");

            //Click on Terminals tab
            partnerAgentHelperNewSkin.ClickElement("Terminals");

            //Verify Terminals tab is highlighted
            partnerAgentHelperNewSkin.verifyElementPresent("TerminalsHighlighted");

            //Verify Products tab not highlighted
            partnerAgentHelperNewSkin.verifyElementNotPresent("ProductsHighlighted");

            //Click on Product tab
            partnerAgentHelperNewSkin.ClickElement("Products");

            //Verify Products tab is highlighted
            partnerAgentHelperNewSkin.verifyElementPresent("ProductsHighlighted");

            //Verify Terminals tab not highlighted
            partnerAgentHelperNewSkin.verifyElementNotPresent("TerminalsHighlighted");

            //Logout from the application
            GetWebDriver().Navigate().GoToUrl(log[0]);

        }
    }
}
