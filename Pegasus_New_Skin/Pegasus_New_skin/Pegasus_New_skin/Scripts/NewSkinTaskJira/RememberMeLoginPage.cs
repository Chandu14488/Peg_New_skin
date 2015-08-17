using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class RememberMeLoginPage : DriverTestCase
    {
        [TestMethod]
        public void rememberMeLoginPage()
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


            //EnterUserName
            clientHelperNewSkin.TypeText("EnterUserName","AslamKhan");

            //EnterPassword
            clientHelperNewSkin.TypeText("EnterPassword", "1qaz!QAZ");

            //Click on Remmenbar me
            clientHelperNewSkin.ClickElement("ClickOnRememberMe");


            //Login BtnRem
            clientHelperNewSkin.ClickElement("LoginBtnRem");


            //Redirect To Client
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/leads");
            clientHelperNewSkin.WaitForWorkAround(4000);
            

            //Logout
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/logout");
            clientHelperNewSkin.WaitForWorkAround(4000);

            //Redirect To Client
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/leads");
            clientHelperNewSkin.WaitForWorkAround(4000);


            //EnterUserName
            clientHelperNewSkin.TypeText("EnterUserName", "AslamKhan");

            //EnterPassword
            clientHelperNewSkin.TypeText("EnterPassword", "1qaz!QAZ");

            //Click on Remmenbar me
            clientHelperNewSkin.ClickElement("ClickOnRememberMe");

            //Login BtnRem
            clientHelperNewSkin.ClickElement("LoginBtnRem");
            clientHelperNewSkin.WaitForWorkAround(7000);

            }
        }
    }

