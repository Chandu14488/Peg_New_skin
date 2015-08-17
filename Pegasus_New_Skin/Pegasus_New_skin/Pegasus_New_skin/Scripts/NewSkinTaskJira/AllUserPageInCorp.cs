using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class AllUserPageInCorp : DriverTestCase
    {
        [TestMethod]
        public void allUserPageInCorp()
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
            var name = "TESTCLIENT" + RandomNumber(1,999);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Redirect To
            pDFTemplateAdminHelper.ClickElement("ClickOnOffice");

            //
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/allusers");
            pDFTemplateAdminHelper.WaitForWorkAround(4000);

            //Select User Type
            pDFTemplateAdminHelper.Select("SelectUserTypeCorp", "Employee");
            pDFTemplateAdminHelper.WaitForWorkAround(3000);

            //Select User Type
            pDFTemplateAdminHelper.Select("SelectUserTypeCorp", "1099 Sales Agent");
            pDFTemplateAdminHelper.WaitForWorkAround(3000);

            //Select User Type
            pDFTemplateAdminHelper.Select("SelectUserTypeCorp", "Client");
            pDFTemplateAdminHelper.WaitForWorkAround(3000);

            //Select User Type
            pDFTemplateAdminHelper.Select("SelectUserTypeCorp", "Partner");
            pDFTemplateAdminHelper.WaitForWorkAround(3000);


            }
            }

        }
    

