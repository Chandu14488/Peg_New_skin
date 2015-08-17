using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class DeleteSaleAgentCodeAndRevenueShare : DriverTestCase
    {
        [TestMethod]
        public void deleteSaleAgentCodeAndRevenueShare()
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
            var saleAgentRevenueAdjustmentHelper = new SaleAgentRevenueAdjustmentHelper(GetWebDriver());


            //Variable random
            var name = "TESTCLIENT" + RandomNumber(1,999);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click on Agent in Topmenu
            saleAgentRevenueAdjustmentHelper.ClickElement("ClickOnAgentTab");
            saleAgentRevenueAdjustmentHelper.WaitForWorkAround(3000);


//################################# CREATE A agent   #############################################

            //Click on Click On Partner Agent
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/chandracorp/chandra/sales_agents");
           // saleAgentRevenueAdjustmentHelper.ClickElement("SaleAgent");

            //Enter agent name to search
            saleAgentRevenueAdjustmentHelper.TypeText("EnterAgentName", "Sale Agent Code Tester");
            saleAgentRevenueAdjustmentHelper.WaitForWorkAround(3000);

            saleAgentRevenueAdjustmentHelper.Select("SelectStatusAdjtmnt","");
            saleAgentRevenueAdjustmentHelper.WaitForWorkAround(4000);

            var loc = "//table[@id='list1']/tbody/tr[2]/td[@aria-describedby='list1_contactNm']/a";

            if (saleAgentRevenueAdjustmentHelper.IsElementPresent(loc))
            {


                //Click On Sale Agent
                saleAgentRevenueAdjustmentHelper.ClickElement("ClickOnAgent1099");
                saleAgentRevenueAdjustmentHelper.WaitForWorkAround(4000);


                //Click On Create btn Adjmnt
                saleAgentRevenueAdjustmentHelper.ClickElement("ClickAddNewAgentCode");

                //EnterAdjustmentName
                saleAgentRevenueAdjustmentHelper.Select("SelectProcessorCode", "Any");

                //SelectAdjustmentFor
                saleAgentRevenueAdjustmentHelper.TypeText("EnterSaleCode", "1009");

                //SelectAdjustmentFor
                saleAgentRevenueAdjustmentHelper.TypeText("RevenueShareAsAgent", "10");


                //SelectAdjustmentFor
                saleAgentRevenueAdjustmentHelper.TypeText("RevenueShareAsManager", "10");

                //SaveAgentCode
                saleAgentRevenueAdjustmentHelper.ClickElement("SaveAgentCode");
                saleAgentRevenueAdjustmentHelper.WaitForWorkAround(4000);

                //Clcik on Delte
                saleAgentRevenueAdjustmentHelper.ClickElement("DeleteAgentCodeRevenueShare");

                //DeleteSelectRoe
                saleAgentRevenueAdjustmentHelper.ClickElement("DeleteSelectRoe");
                saleAgentRevenueAdjustmentHelper.WaitForWorkAround(3000);



            }

            else
            {




                //Click On Click On Create SaleBtn
                saleAgentRevenueAdjustmentHelper.ClickElement("ClickOnCreateBtn");

                //Select Salutation
                saleAgentRevenueAdjustmentHelper.Select("SelectSalutation", "Mr");

                //Enter FirstNAME
                saleAgentRevenueAdjustmentHelper.TypeText("FirstNAME", "Sale Agent Code");

                //Enter LastName
                saleAgentRevenueAdjustmentHelper.TypeText("LastName", "Tester");

                //Enter Date Of Birth
                saleAgentRevenueAdjustmentHelper.TypeText("BirthDay", "1991-03-02");


                //############### CONTACT INFORMATION ###################################

                //Enter eAddressType
                saleAgentRevenueAdjustmentHelper.Select("eAddressType", "E-Mail");

                //Enter eAddressLebel
                saleAgentRevenueAdjustmentHelper.Select("eAddressLebel", "Work");

                //Enter eAddressType
                var Email = "Sale" + RandomNumber(1, 999) + "@yopmail.com";
                saleAgentRevenueAdjustmentHelper.TypeText("eAddress", Email);

                //################## PHONE ###########################

                //Enter SelectPhoneType
                saleAgentRevenueAdjustmentHelper.Select("SelectPhoneType", "Work");

                //Enter PhoneNumber
                saleAgentRevenueAdjustmentHelper.TypeText("PhoneNumber", "9828928943");

                //##################### ADDRESS TYPE

                //Enter Address Type    
                saleAgentRevenueAdjustmentHelper.Select("AddressType", "Office");

                //Enter AddressLine1
                saleAgentRevenueAdjustmentHelper.TypeText("AddressLine1", "FC 89");

                //Enter City
                saleAgentRevenueAdjustmentHelper.TypeText("City", "Test City");

                //Enter PhoneNumber
                saleAgentRevenueAdjustmentHelper.TypeText("PostalCode", "60601");
                saleAgentRevenueAdjustmentHelper.WaitForWorkAround(3000);


                //########################## DEPARTMENT ROLE   ###############################

                //Click On Department 
                //      saleAgentRevenueAdjustmentHelper.ClickElement("ClickOnDeppartmentTeam");

                //Select Department
                //    saleAgentRevenueAdjustmentHelper.Select("SelectDepartment", "78");

                //Select Select Role
                //      saleAgentRevenueAdjustmentHelper.Select("SelectRole", "76");

                //Select Primary  Team
                //       saleAgentRevenueAdjustmentHelper.Select("PrimaryTeam", "40");


                //################### CREATE USER ACCOUNT

                //Click On Checkbox
                saleAgentRevenueAdjustmentHelper.ClickElement("ClickONcheckBox");

                //Enter UserName
                saleAgentRevenueAdjustmentHelper.TypeText("UserName", name);

                //Click On Avatar
                saleAgentRevenueAdjustmentHelper.ClickElement("ClickOnSAvatarBtn");


                //##############    click on Save Contact 

                //CLICK DoNotSolicit
                saleAgentRevenueAdjustmentHelper.ClickElement("ClickSaveNskin");

                //Enter agent name to search
                saleAgentRevenueAdjustmentHelper.TypeText("EnterAgentName", "Sale Agent Code Tester");


                saleAgentRevenueAdjustmentHelper.Select("SelectStatusAdjtmnt", "");
                saleAgentRevenueAdjustmentHelper.WaitForWorkAround(4000);

                //Click On Sale Agent
                saleAgentRevenueAdjustmentHelper.ClickElement("ClickOnAgent1099");
                saleAgentRevenueAdjustmentHelper.WaitForWorkAround(4000);

                //Click On Create btn Adjmnt
                saleAgentRevenueAdjustmentHelper.ClickElement("ClickAddNewAgentCode");

                //EnterAdjustmentName
                saleAgentRevenueAdjustmentHelper.Select("SelectProcessorCode", "Any");

                //SelectAdjustmentFor
                saleAgentRevenueAdjustmentHelper.TypeText("EnterSaleCode", "1009");

                //SelectAdjustmentFor
                saleAgentRevenueAdjustmentHelper.TypeText("RevenueShareAsAgent", "10");


                //SelectAdjustmentFor
                saleAgentRevenueAdjustmentHelper.TypeText("RevenueShareAsManager", "10");

                //SaveAgentCode
                saleAgentRevenueAdjustmentHelper.ClickElement("SaveAgentCode");
                saleAgentRevenueAdjustmentHelper.WaitForWorkAround(4000);

                //Clcik on Delte
                saleAgentRevenueAdjustmentHelper.ClickElement("DeleteAgentCodeRevenueShare");

                //DeleteSelectRoe
                saleAgentRevenueAdjustmentHelper.ClickElement("DeleteSelectRoe");
                saleAgentRevenueAdjustmentHelper.WaitForWorkAround(3000);


            }

        }
    }
}
