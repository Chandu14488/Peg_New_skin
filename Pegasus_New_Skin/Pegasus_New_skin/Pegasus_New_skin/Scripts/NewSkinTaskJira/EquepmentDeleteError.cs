using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class EquepmentDeleteError : DriverTestCase
    {
        [TestMethod]
        public void equepmentDeleteError()
        {
            string[] username = null;
            string[] password = null;

            XMLParse oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username");
            password = oXMLData.getData("settings/Credentials", "password");

            //Initializing the objects
            var loginHelper = new LoginHelper(GetWebDriver());
            var clientHelper = new ClientsHelper(GetWebDriver());
            var equiomentHelperAdmin = new EquiomentHelperAdmin(GetWebDriver());

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Redirect To URL
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/equipment");

//################################# Create Equipments #############################################

            //Verify title
            VerifyTitle("Equipment");

            //Open the second equipment
            equiomentHelperAdmin.ClickElement("SectEquip");

            //Verify title
            VerifyTitle("Equipment -");

            //Go back to equipment page
            GetWebDriver().Navigate().Back();

            //Verify title
            VerifyTitle("Equipment");

            //Open third equipment
            equiomentHelperAdmin.ClickElement("ThEquip");

            //Verify title
            VerifyTitle("Equipment -");


            //Go back to equipment page
            GetWebDriver().Navigate().Back();

            //Verify title
            VerifyTitle("Equipment");

            //Delete second equipment
            equiomentHelperAdmin.ClickElement("DelSec");
            equiomentHelperAdmin.WaitForWorkAround(2000);
            //Accept alert
            equiomentHelperAdmin.AcceptAlert();

            //navigate to other tab
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice");

            //Redirect To URL
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/equipment");

        }
    }
}
