using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class RevenueAdjustmentPartnerAgentAddFlatAmount : DriverTestCase
    {
        [TestMethod]
        public void revenueAdjustmentPartnerAgentAddFlatAmount()
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
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/partners/agents");


 //###########  Search and click
            //Enter 
         //   partnerAgentHelperNewSkin.TypeText("EnterAgentName", "Partner Agent Tester");

       //     partnerAgentHelperNewSkin.Select("SelectStatusAdjtmnt", "");
            partnerAgentHelperNewSkin.WaitForWorkAround(3000);


            var loc = "//table[@id='list1']/tbody/tr[2]";
            if (partnerAgentHelperNewSkin.IsElementPresent(loc))
            {


                //Click On Sale Agent
                partnerAgentHelperNewSkin.ClickElement("ClikOnPartnerAgent");

                //scroll to element
                partnerAgentHelperNewSkin.scrollToElement("ClickOnCreatebtnAdjmnt");
                //Click On Create btn Adjmnt
                partnerAgentHelperNewSkin.ClickElement("ClickOnCreatebtnAdjmnt");

                //EnterAdjustmentName
                partnerAgentHelperNewSkin.TypeText("EnterAdjustmentName", "SaleAdjustment");

                //SelectAdjustmentFor
                partnerAgentHelperNewSkin.Select("SelectAdjustmentFor", "Agent");

                //SelectAdjustmentFor
                partnerAgentHelperNewSkin.Select("AdjustmentType", "Transaction");


                //SelectAdjustmentFor
                partnerAgentHelperNewSkin.Select("SelectReportingPeriod", "00");

                //SelectProcessor
                partnerAgentHelperNewSkin.Select("SelectProcessor", "Any");

                //SelectAdjustmentFor
                partnerAgentHelperNewSkin.Select("SelectRuleType", "1");

                //Enter Amount
                partnerAgentHelperNewSkin.TypeText("EnterAmount", "20");

                //AddRemove
                partnerAgentHelperNewSkin.Select("AddRemove", "Add");

                //ClickOnSaveBtnAdjustmnet
                partnerAgentHelperNewSkin.ClickElement("ClickOnSaveBtnAdjustmnet");
                partnerAgentHelperNewSkin.WaitForWorkAround(3000);

                //Verify 
                partnerAgentHelperNewSkin.VerifyPageText("Master Adjustment Rules Created Successfully.");


            }
            else
            {


                //Click On Create
                partnerAgentHelperNewSkin.ClickElement("ClickOnCreateBtn");

                //Select Salutation
                partnerAgentHelperNewSkin.Select("SelectSalutation", "Mr");

                //Enter FirstNAME
                partnerAgentHelperNewSkin.TypeText("FirstNAME", "Partner Agent");

                //Enter LastName
                partnerAgentHelperNewSkin.TypeText("LastName", "Tester");

                //Enter Date Of Birth
                partnerAgentHelperNewSkin.TypeText("BirthDay", "1991-03-02");

                //Click on Middle name
                partnerAgentHelperNewSkin.ClickElement("ClickMiddleName");

                //Enter DBAName
                partnerAgentHelperNewSkin.TypeText("DBAName", "Test DBA");

                //Enter LinkedInUrl
                partnerAgentHelperNewSkin.TypeText("LinkedInUrl", "LinkedIn.con");


                //Enter FaceBook Url
                partnerAgentHelperNewSkin.TypeText("FaceBookUrl", "Facebook.com");


                //Enter TwitterURL
                partnerAgentHelperNewSkin.TypeText("TwitterURL", "Twitter.com");

                //Enter DBAName
                partnerAgentHelperNewSkin.Select("SelectLanguage", "English");

                //############### CONTACT INFORMATION ###################################

                //Enter eAddressType
                partnerAgentHelperNewSkin.Select("eAddressType", "E-Mail");

                //Enter eAddressLebel
                partnerAgentHelperNewSkin.Select("eAddressLebel", "Work");

                //Enter eAddressType
                var Email = "P.Agent" + RandomNumber(1, 999) + "@yopmail.com";
                partnerAgentHelperNewSkin.TypeText("eAddress", Email);

                //################## PHONE ###########################

                //Enter SelectPhoneType
                partnerAgentHelperNewSkin.Select("SelectPhoneType", "Work");

                //Enter PhoneNumber
                partnerAgentHelperNewSkin.TypeText("PhoneNumber", "1212121212");

                //##################### ADDRESS TYPE

                //Enter Address Type    
                partnerAgentHelperNewSkin.Select("AddressType", "Office");

                //Enter AddressLine1
                partnerAgentHelperNewSkin.TypeText("AddressLine1", "FC 89");

                //Enter City
                partnerAgentHelperNewSkin.TypeText("PostalCode", "60601");
                partnerAgentHelperNewSkin.WaitForWorkAround(2000);

                //################### CREATE USER ACCOUNT

                //Click On Checkbox
                partnerAgentHelperNewSkin.ClickElement("ClickONcheckBox");

                //Enter UserName
                partnerAgentHelperNewSkin.TypeText("UserName", name);

                //Click On Avatar
                partnerAgentHelperNewSkin.ClickElement("ClickOnAvatar");


                //########### click on Save Contact 

                //CLICK Save AGENT btn
                partnerAgentHelperNewSkin.ClickElement("ClickSaveNskin");
                partnerAgentHelperNewSkin.WaitForWorkAround(5000);

                //Verify Text
                partnerAgentHelperNewSkin.VerifyPageText("The user is successfully added");
                partnerAgentHelperNewSkin.WaitForWorkAround(5000);


                //Crearte Adjustment

    /*            //Enter 
                partnerAgentHelperNewSkin.TypeText("EnterAgentName", "Partner Agent Tester");
                partnerAgentHelperNewSkin.WaitForWorkAround(3000);

                //Click On Sale Agent
                partnerAgentHelperNewSkin.ClickElement("ClikOnPartnerAgent");  */

                //Click On Create btn Adjmnt
                partnerAgentHelperNewSkin.ClickElement("ClickOnCreatebtnAdjmnt");

                //EnterAdjustmentName
                partnerAgentHelperNewSkin.TypeText("EnterAdjustmentName", "SaleAdjustment");

                //SelectAdjustmentFor
                partnerAgentHelperNewSkin.Select("SelectAdjustmentFor", "Agent");

                //SelectAdjustmentFor
                partnerAgentHelperNewSkin.Select("AdjustmentType", "Transaction");


                //SelectAdjustmentFor
                partnerAgentHelperNewSkin.Select("SelectReportingPeriod", "00");

                //SelectProcessor
                partnerAgentHelperNewSkin.Select("SelectProcessor", "Any");

                //SelectAdjustmentFor
                partnerAgentHelperNewSkin.Select("SelectRuleType", "0");

                //Enter Amount
                partnerAgentHelperNewSkin.TypeText("EnterAmount", "200");

                //AddRemove
                partnerAgentHelperNewSkin.Select("AddRemove", "Add");

                //ClickOnSaveBtnAdjustmnet
                partnerAgentHelperNewSkin.ClickElement("ClickOnSaveBtnAdjustmnet");
                partnerAgentHelperNewSkin.WaitForWorkAround(3000);

                //Verify 
                partnerAgentHelperNewSkin.VerifyPageText("Master Adjustment Rules Created Successfully.");

            }
        }
    }
}
