using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.Corp
{
    [TestClass]
    public class ProfilePicUplaodField : DriverTestCase
    {
        [TestMethod]
        public void profilePicUplaodField()
        {
              string[] username = null;
             string[] password = null;

            var oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

              username = oXMLData.getData("settings/Credentials", "username");
               password = oXMLData.getData("settings/Credentials", "password");

            //Initializing the objects
            var loginHelper = new LoginHelper(GetWebDriver());

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            
            //Go to Edit profile page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/editProfile");
                
            //Verify title
            VerifyTitle("Edit Profile");

            //Verify upload file field availabe
            Assert.IsTrue(loginHelper.IsElementVisible("//*[@id='EmployeeProfileImage']"));
           
        }
    }
}
