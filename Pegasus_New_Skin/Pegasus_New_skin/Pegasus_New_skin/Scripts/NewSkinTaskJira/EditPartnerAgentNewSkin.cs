﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class EditPartnerAgentNewSkin : DriverTestCase
    {
        [TestMethod]
        public void editPartnerAgentNewSkin()
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


            //Search Partner Agent
            partnerAgentHelperNewSkin.TypeText("EnterAgentName", "Test Agent Tester");
            partnerAgentHelperNewSkin.WaitForWorkAround(3000);

            var Loc = "//table[@id='list1']/tbody/tr[2]/td[8]/a";

            if (partnerAgentHelperNewSkin.IsElementPresent(Loc))
            {

                //Clcik On Edit
                partnerAgentHelperNewSkin.ClickElement("EditPartnerAgent");

                //Enter LastName
                partnerAgentHelperNewSkin.TypeText("LastName", "Tester");

                //Enter Date Of Birth
                partnerAgentHelperNewSkin.TypeText("BirthDay", "1991-03-02");

                //Click on Middle name
                partnerAgentHelperNewSkin.ClickElement("ClickMiddleName");

                //Enter DBAName
                partnerAgentHelperNewSkin.TypeText("DBAName", "Test DBA");

                //Enter eAddressType
                partnerAgentHelperNewSkin.Select("eAddressType", "E-Mail");

                //Enter eAddressLebel
                partnerAgentHelperNewSkin.Select("eAddressLebel", "Work");


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


                //Clcik Edit Save
                partnerAgentHelperNewSkin.ClickElement("ClickSaveNskin");
                partnerAgentHelperNewSkin.WaitForWorkAround(4000);

            }


            else
            {

                //Click On Create
                partnerAgentHelperNewSkin.ClickElement("ClickOnCreatebtnAdjmnt");

                //Select Salutation
                partnerAgentHelperNewSkin.Select("SelectSalutation", "Mr");

                //Enter FirstNAME
                partnerAgentHelperNewSkin.TypeText("FirstNAME", "Test Agent");

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


                //CLICK Save AGENT btn
                partnerAgentHelperNewSkin.ClickElement("ClickSaveNskin");
                partnerAgentHelperNewSkin.WaitForWorkAround(5000);


                //Verify 
              //  partnerAgentHelperNewSkin.VerifyPageText("The user is successfully added");


                ////////   Edit


                //Click on Click On Partner Agent
                GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/partners/agents");


                //Search Partner Agent
                partnerAgentHelperNewSkin.TypeText("EnterAgentName", "Test Agent Tester");
                partnerAgentHelperNewSkin.WaitForWorkAround(3000);

                //Clcik On Edit
                partnerAgentHelperNewSkin.ClickElement("EditPartnerAgent");

                //Enter LastName
                partnerAgentHelperNewSkin.TypeText("LastName", "Tester");

                //Enter Date Of Birth
                partnerAgentHelperNewSkin.TypeText("BirthDay", "1991-03-02");

                //Click on Middle name
                partnerAgentHelperNewSkin.ClickElement("ClickMiddleName");

                //Enter DBAName
                partnerAgentHelperNewSkin.TypeText("DBAName", "Test DBA");

                //Enter eAddressType
                partnerAgentHelperNewSkin.Select("eAddressType", "E-Mail");

                //Enter eAddressLebel
                partnerAgentHelperNewSkin.Select("eAddressLebel", "Work");


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

                //Clcik Edit Save
                partnerAgentHelperNewSkin.ClickElement("ClikcEditSave");
                partnerAgentHelperNewSkin.WaitForWorkAround(4000);


            }


        }
    }
}