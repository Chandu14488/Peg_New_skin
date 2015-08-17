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
    public class EditOmahaAuthGripAdmin : DriverTestCase
    {
        [TestMethod]
        public void editOmahaAuthGripAdmin()
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
            var createOmahaAuthGripHelperNewSkin = new CreateOmahaAuthGripHelperNewSkin(GetWebDriver());

            //Variable
            String name = "3" + RandomNumber(1, 99);
            String code = "1" + RandomNumber(1, 99);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click on Clients in Topmenu
//            clientHelper.clickClients();

            //Click to open client info
   //         clientHelper.OpenClient();

//#######################  MOVE HOVER TO THE WELCOME
            //Click on Move over
            createOmahaAuthGripHelperNewSkin.ClickElement("MoveHover");

            //Click On  Admin
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/admin");

//################################# MASTER DATA #############################################

            //Click on MASTER DATA
            createOmahaAuthGripHelperNewSkin.ClickElement("ClickOnMasterDataTab");

//##################  Redirect To Url

            //Redirect To URL
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/omaha_auth_grids");
            createOmahaAuthGripHelperNewSkin.WaitForWorkAround(4000);

//################################# Create Product tab #############################################

            // Click On Create
            createOmahaAuthGripHelperNewSkin.ClickElement("ClickOnCreate");
            createOmahaAuthGripHelperNewSkin.WaitForWorkAround(3000);

            //Enter Grid Id
            createOmahaAuthGripHelperNewSkin.TypeText("GridId", name);

            //Enter Visa Pos Authfees
            createOmahaAuthGripHelperNewSkin.TypeText("VisaPosAuthfees", code);

            //Enter MC Pos Auth Fees
            createOmahaAuthGripHelperNewSkin.TypeText("MCPosAuthFees", name);

            //Enter Amex Pos AuthFees
            createOmahaAuthGripHelperNewSkin.TypeText("AmexPosAuthFees", name);

            //Enter Disc Pos Auth Fees
            createOmahaAuthGripHelperNewSkin.TypeText("DiscPosAuthFees", code);

            //Enter JCD Pos Auth Fees
            createOmahaAuthGripHelperNewSkin.TypeText("JCDPosAuthFees", name);

            //Enter Voice Auth Fees
            createOmahaAuthGripHelperNewSkin.TypeText("VoiceAuthFees", code);

            //Enter AVS Electronic Fees
            createOmahaAuthGripHelperNewSkin.TypeText("AVSElectronicFees", name);

            //Enter AVS Voice Fees
            createOmahaAuthGripHelperNewSkin.TypeText("AVSVoiveFees", code);

            //Enter AVS Voive Fees
            createOmahaAuthGripHelperNewSkin.TypeText("ARUFees", name);

          //  Click on Save button
            createOmahaAuthGripHelperNewSkin.ClickElement("SaveBtn");
            createOmahaAuthGripHelperNewSkin.WaitForWorkAround(3000);


            //Click on Edit 
            createOmahaAuthGripHelperNewSkin.ClickElement("ClickEdit");
            createOmahaAuthGripHelperNewSkin.WaitForWorkAround(5000);

            //Enter Grid Id
            createOmahaAuthGripHelperNewSkin.TypeText("GridId", name);

            //Enter Visa Pos Authfees
            createOmahaAuthGripHelperNewSkin.TypeText("VisaPosAuthfees", code);

            //Enter MC Pos Auth Fees
            createOmahaAuthGripHelperNewSkin.TypeText("MCPosAuthFees", name);

            //Enter Amex Pos AuthFees
            createOmahaAuthGripHelperNewSkin.TypeText("AmexPosAuthFees", name);

            //Enter Disc Pos Auth Fees
            createOmahaAuthGripHelperNewSkin.TypeText("DiscPosAuthFees", code);

            //Enter JCD Pos Auth Fees
            createOmahaAuthGripHelperNewSkin.TypeText("JCDPosAuthFees", name);

            //Enter Voice Auth Fees
            createOmahaAuthGripHelperNewSkin.TypeText("VoiceAuthFees", code);

            //Enter AVS Electronic Fees
            createOmahaAuthGripHelperNewSkin.TypeText("AVSElectronicFees", name);

            //Enter AVS Voice Fees
            createOmahaAuthGripHelperNewSkin.TypeText("AVSVoiveFees", code);

            //Enter AVS Voive Fees
            createOmahaAuthGripHelperNewSkin.TypeText("ARUFees", name);

            //  Click on Save button
            createOmahaAuthGripHelperNewSkin.ClickElement("SaveBtn");
            createOmahaAuthGripHelperNewSkin.WaitForWorkAround(3000);
            



        }
    }
}
