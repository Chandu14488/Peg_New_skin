using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class AddMultipleContact : DriverTestCase
    {
        [TestMethod]
        public void addMultipleContact()
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
            var themeAdminHelper = new ThemeAdminHelper(GetWebDriver());

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");


            //Go to compose email page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/mails/compose");
            themeAdminHelper.WaitForWorkAround(3000);


            //Verify title
            VerifyTitle("Compose");

            //Click on select employee
            themeAdminHelper.ClickElement("ToAddress");

            themeAdminHelper.WaitForWorkAround(4000);

            //Select 1st employee
            themeAdminHelper.ClickElement("FEmployee");

            //Select 2nd employee
            themeAdminHelper.ClickElement("SEmployee");

            //Select 3rd employee
            themeAdminHelper.ClickElement("TEmployee");

            //Click on Add button
            themeAdminHelper.ClickElement("AddEmployee");
            
              
                }
            }
        }
    

