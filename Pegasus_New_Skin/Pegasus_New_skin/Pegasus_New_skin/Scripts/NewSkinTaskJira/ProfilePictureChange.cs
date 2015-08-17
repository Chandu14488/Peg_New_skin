﻿using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class ProfilePictureChange : DriverTestCase
    {
        [TestMethod]
        public void profilePictureChange()
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

            //Go to Profile page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/myprofile");

            //Verify title
            VerifyTitle("My Profile");

            //Click on Edit profile button
            partnerAgentHelperNewSkin.ClickElement("ProfileEdit");

            //Verify title
            VerifyTitle("Edit Profile");

            //Upload image
            string path = GetPathToFile() + "index.jpg";
            partnerAgentHelperNewSkin.UploadImage("UploadImage", path);

            //Click on Save button
            partnerAgentHelperNewSkin.ClickElement("OfficeSave");

            //Verify title
            VerifyTitle("My Profile");

            //Check default image not displayed
            partnerAgentHelperNewSkin.verifyElementNotPresent("ProfileDefault");
            
            //Logout from the application
            GetWebDriver().Navigate().GoToUrl(log[0]);

        }
    }
}
