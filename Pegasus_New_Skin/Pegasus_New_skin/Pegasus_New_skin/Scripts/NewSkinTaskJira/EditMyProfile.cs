using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class EditMyProfile : DriverTestCase
    {
        [TestMethod]
        public void editMyProfile()
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
            var clientHelperNewSkin = new ClientHelperNewSkin(GetWebDriver());

            //VARIABLE
            var name = "TestEmployee" + GetRandomNumber();


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Redirect 
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/myprofile");

            //Click On EditProfile
            clientHelperNewSkin.ClickElement("ClickOnEditProfile");


            //SelectCountryMP
       //     clientHelperNewSkin.Select("SelectCountryMP", "Canada");
         

            //SelectStateMP
   //         clientHelperNewSkin.Select("SelectStateMP", "NU");
        //    clientHelperNewSkin.WaitForWorkAround(4000);

            //Enter Zip Code
            clientHelperNewSkin.TypeText("EmplyEditNs","60601");
            clientHelperNewSkin.WaitForWorkAround(4000);


            //ClickSaveMP
            clientHelperNewSkin.ClickElement("ClickSaveMP");
            clientHelperNewSkin.WaitForWorkAround(6000);


            //Verify Your profile has been successfully updated. 
            clientHelperNewSkin.VerifyPageText("Your profile has been successfully updated.");

             }
       }
 }
    

