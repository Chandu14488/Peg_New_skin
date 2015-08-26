using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class HttpsError : DriverTestCase
    {
        [TestMethod]
        public void httpsError()
        {
            
            var oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");
            var loginHelper = new LoginHelper(GetWebDriver());

            //Go to mypegasus.com
            GetWebDriver().Navigate().GoToUrl("https://www.mypegasuscrm.com/login");

            //Veify title
            VerifyTitle("Login");

            //Verify no error displayed
            loginHelper.VerifyTextNotPresent("Your connection is not private");


            }
        }
    }

