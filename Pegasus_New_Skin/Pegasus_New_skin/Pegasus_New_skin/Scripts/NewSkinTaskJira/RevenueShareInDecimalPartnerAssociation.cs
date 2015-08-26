using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class RevenueShareInDecimalPartnerAssociation : DriverTestCase
    {
        [TestMethod]
        public void revenueShareInDecimalPartnerAssociation()
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
            var partnerAgentHelperNewSkin = new PartnerAgentHelperNewSkin(GetWebDriver());

            //Variable
            var name = "TestAgent" + GetRandomNumber();


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click on Agent in Topmenu
            partnerAgentHelperNewSkin.MouseHover("ClickOnAgentTab");


//################################# CREATE A agent   #############################################

            //Click on Click On Partner Agent
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/partners/associations");

            //verify title
            VerifyTitle("Partner Associations");

            //ClickOnRevenueShare
            partnerAgentHelperNewSkin.ClickElement("RevenueSahrnepartneragent");

            //Verify title
            VerifyTitle("Partner Associations Revenue Shares");

            //Click on Revenue Share Partner Agnet
            partnerAgentHelperNewSkin.ClickElement("RevenueSahrnepartnerasso");
            partnerAgentHelperNewSkin.WaitForWorkAround(5000);

            //SelectPartnerAgnetRS
            partnerAgentHelperNewSkin.SelectByText("AgentNameSelect", "AssociationTester");

            //Select processor
            partnerAgentHelperNewSkin.SelectByText("ProcessorSelect", "Chy Processor");

            //EnterPartnerCode
            var code = "1" + RandomNumber(99,999);
            partnerAgentHelperNewSkin.TypeText("ProcessorCodePAss", code);

            //EnterPartnerCode
            var RS = "22." + RandomNumber(1,99);
            partnerAgentHelperNewSkin.TypeText("RevenueShareps", RS);

            //ClickOnSaveRS
            partnerAgentHelperNewSkin.ClickElement("SaveRS");

            //verify message Partner agent code & revenue share saved successfully.
           partnerAgentHelperNewSkin.WaitForText("Partner association code & revenue share saved successfully.",30);

            //Enter Deciaml value
            partnerAgentHelperNewSkin.TypeText("SearchDeciaml", RS);
            partnerAgentHelperNewSkin.WaitForWorkAround(4000);

            //Verify value oin decimal
            partnerAgentHelperNewSkin.VerifyText("VerifyValueInDecimal", RS);
            partnerAgentHelperNewSkin.WaitForWorkAround(4000);

            }
        }
    }

