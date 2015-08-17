using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class ClientResidualAdjustment : DriverTestCase
    {
        [TestMethod]
        public void clientResidualAdjustment()
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

            //Click on Agent in Topmenu
            clientHelperNewSkin.ClickElement("ClickOnClientTab");

            //Enter Company DBA Name
            clientHelperNewSkin.TypeText("EnterCompanyDba", "Client Adjustment");
            clientHelperNewSkin.WaitForWorkAround(6000);

            var loc = "//table[@id='list1']/tbody/tr[2]/td[@aria-describedby='list1_company_dba_name']/a";

            if (clientHelperNewSkin.IsElementPresent(loc))
            {
                //Click on Clinet
                clientHelperNewSkin.ClickElement("ClickOnClient");
                clientHelperNewSkin.WaitForWorkAround(3000);

                //Cliclk on Residual Income
                clientHelperNewSkin.ClickElement("ClickOnResidualIncomeLink");
                clientHelperNewSkin.WaitForWorkAround(4000);


                //ClickOnCreateRA
                clientHelperNewSkin.ClickElement("ClickOnCreateRA");
                clientHelperNewSkin.WaitForWorkAround(2000);

                //EnterAdjustmentName
                clientHelperNewSkin.TypeText("EnterAdjustmentName", "Client Adjustment");

                //SelectAdjustmentFor
                clientHelperNewSkin.Select("SelectAdjustmentFor", "Agent");

                //SelectAdjustmentFor
                clientHelperNewSkin.Select("AdjustmentType", "Transaction");


                //SelectAdjustmentFor
                clientHelperNewSkin.Select("SelectReportingPeriod", "00");

                //SelectProcessor
                clientHelperNewSkin.Select("SelectProcessor", "Any");


                //SelectAdjustmentFor
                clientHelperNewSkin.Select("SelectRuleType", "1");

                //Enter Amount
                clientHelperNewSkin.TypeText("EnterAmount", "20");

                //AddRemove
                clientHelperNewSkin.Select("AddRemove", "Add");

                //ClickOnSaveBtnAdjustmnet
                clientHelperNewSkin.ClickElement("ClickOnSaveBtnAdjustmnet");
                clientHelperNewSkin.WaitForWorkAround(3000);

                //Verify 
                clientHelperNewSkin.VerifyPageText("Master Adjustment Rules Created Successfully.");



            }
            else 
            {

                //ClickOnCreateClient
                GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/clients/create");
                //clientHelperNewSkin.ClickElement("ClickOnCreateClient");
                clientHelperNewSkin.WaitForWorkAround(3000);


                //Select Client Status
                clientHelperNewSkin.Select("SelectClientStatus", "Agreement");

                //Select Responsibility
                clientHelperNewSkin.Select("SelectResponsibilty", "637");

                //Click on Save
                clientHelperNewSkin.ClickElement("ClickSaveClient");

                //Enter DBA Name
                clientHelperNewSkin.TypeText("EnterDBAName", "Client Adjustment");

                //Click on Save
                clientHelperNewSkin.ClickElement("ClickSaveClient");

            /*    var dub = "//button[text()='Create Duplicate']";
                if (clientHelperNewSkin.IsElementPresent(loc))
                {
                    clientHelperNewSkin.ClickElement("CreateDublicateClient");
                }  */

                
                    //Cliclk on Residual Income
                    clientHelperNewSkin.ClickElement("ClickOnResidualIncomeLink");

                    //ClickOnCreateRA
                    clientHelperNewSkin.ClickElement("ClickOnCreateRA");
                    clientHelperNewSkin.WaitForWorkAround(2000);

                    //EnterAdjustmentName
                    clientHelperNewSkin.TypeText("EnterAdjustmentName", "Client Adjustment");

                    //SelectAdjustmentFor
                    clientHelperNewSkin.Select("SelectAdjustmentFor", "Agent");

                    //SelectAdjustmentFor
                    clientHelperNewSkin.Select("AdjustmentType", "Transaction");


                    //SelectAdjustmentFor
                    clientHelperNewSkin.Select("SelectReportingPeriod", "00");

                    //SelectProcessor
                    clientHelperNewSkin.Select("SelectProcessor", "Any");


                    //SelectAdjustmentFor
                    clientHelperNewSkin.Select("SelectRuleType", "1");

                    //Enter Amount
                    clientHelperNewSkin.TypeText("EnterAmount", "20");

                    //AddRemove
                    clientHelperNewSkin.Select("AddRemove", "Add");

                    //ClickOnSaveBtnAdjustmnet
                    clientHelperNewSkin.ClickElement("ClickOnSaveBtnAdjustmnet");
                    clientHelperNewSkin.WaitForWorkAround(3000);

                    //Verify 
                    clientHelperNewSkin.VerifyPageText("Master Adjustment Rules Created Successfully.");

                }
            }
        }
    }

