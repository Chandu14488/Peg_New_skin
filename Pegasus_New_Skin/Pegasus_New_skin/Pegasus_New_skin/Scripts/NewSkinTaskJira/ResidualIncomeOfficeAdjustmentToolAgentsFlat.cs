using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class ResidualIncomeOfficeAdjustmentToolAgentsFlat : DriverTestCase
    {
        [TestMethod]
        public void residualIncomeOfficeAdjustmentToolAgentsFlat()
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
            var residualIcomeOfficeHelper = new ResidualIcomeOfficeHelper(GetWebDriver());

            //Variable
            var name = "TestAgent" + GetRandomNumber();


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

               //Click on Click On Partner Agent
               GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/rir/adjustments_tool");

            //Verify title
               VerifyTitle("Adjustments Tool");

               //Click On Create btn Adjmnt
               residualIcomeOfficeHelper.ClickElement("ClickOnCreateAdjust");

                //EnterAdjustmentName
                residualIcomeOfficeHelper.TypeText("EnterAdjustmentName", "SaleAdjustment");

                //SelectAdjustmentFor
                residualIcomeOfficeHelper.Select("SelectAdjustmentFor", "Agent");

                //SelectAdjustmentFor
                residualIcomeOfficeHelper.Select("AdjustmentType", "Transaction");


                //SelectAdjustmentFor
                residualIcomeOfficeHelper.Select("SelectReportingPeriod", "00");

                //SelectProcessor
                residualIcomeOfficeHelper.Select("SelectProcessor", "Any");

                //SelectAdjustmentFor
                residualIcomeOfficeHelper.Select("SelectRuleType", "0");

                //Enter Amount
                residualIcomeOfficeHelper.TypeText("EnterAmount", "200");

                //AddRemove
                residualIcomeOfficeHelper.Select("AddRemove", "Add");

                //ClickOnSaveBtnAdjustmnet
                residualIcomeOfficeHelper.ClickElement("ClickOnSaveBtnAdjustmnet");
                residualIcomeOfficeHelper.WaitForWorkAround(3000);

                //Verify 
                residualIcomeOfficeHelper.VerifyPageText("Master Adjustment Rules Created Successfully.");

            }
        }
    }

