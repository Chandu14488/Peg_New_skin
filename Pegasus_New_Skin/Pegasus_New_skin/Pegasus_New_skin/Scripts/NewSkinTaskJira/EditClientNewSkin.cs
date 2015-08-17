using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class EditClientNewSkin : DriverTestCase
    {
        [TestMethod]
        public void editClientNewSkin()
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


           //ClickOnCreateClient
           GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/clients/create");
           clientHelperNewSkin.WaitForWorkAround(3000);

            //Select Status
           clientHelperNewSkin.Select("SelectClientStatus", "New");
           clientHelperNewSkin.WaitForWorkAround(3000);

           //SelectResponsibilty
           clientHelperNewSkin.SelectDropDownByText("//*[@id='ClientAssignedUserId']", "Aslam Khan");

           //Save Client 
           clientHelperNewSkin.ClickElement("ClickSaveClient");
           clientHelperNewSkin.WaitForWorkAround(3000);


           //EnterDBAName
           clientHelperNewSkin.TypeText("EnterDBAName","Eidt DBA Name");

            //Save Client 
           clientHelperNewSkin.ClickElement("ClickSaveClient");
           //clientHelperNewSkin.WaitForWorkAround(5000);

            //Verify 
           clientHelperNewSkin.WaitForText("Client saved successfully.",30);
           clientHelperNewSkin.WaitForWorkAround(3000);

//###############   EDIT CLIENT


            //Redirect To
           GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/clients");


            //EnterCompanyDba
           clientHelperNewSkin.TypeText("EnterCompanyDba", "Eidt DBA Name");

            //ClickOnClient
           clientHelperNewSkin.ClickElement("ClickOnClient");

            //Click on company details
           clientHelperNewSkin.ClickElement("ClickOnCompanyDetailTab");

            //Enter Company CFO
           clientHelperNewSkin.TypeText("EnterCompanyCFO", "test CFO");


            //Click on Contact tab
            clientHelperNewSkin.ClickElement("ClickOnContactTab");

            //Enter Zip Code
            clientHelperNewSkin.TypeText("EnterZipCode","60601");
            clientHelperNewSkin.WaitForWorkAround(3000);

            //Save Client 
            clientHelperNewSkin.ClickElement("ClickSaveClient");
            clientHelperNewSkin.WaitForWorkAround(3000);



              
                }
            }
        }
    

