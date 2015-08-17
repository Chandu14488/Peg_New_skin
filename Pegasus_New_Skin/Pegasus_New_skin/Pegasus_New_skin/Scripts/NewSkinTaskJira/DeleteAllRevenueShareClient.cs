using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class DeleteAllRevenueShareClient : DriverTestCase
    {
        [TestMethod]
        public void deleteAllRevenueShareClient()
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

            //Redirect To
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/clients");

 
           //EnterCompanyDba
           clientHelperNewSkin.TypeText("EnterCompanyDba", "Eidt DBA Name");
           clientHelperNewSkin.WaitForWorkAround(5000);
        
           var loc = "//table[@id='list1']/tbody/tr[2]";

           if (clientHelperNewSkin.IsElementPresent(loc)) {

               //ClickOnClient
               clientHelperNewSkin.ClickElement("ClickOnClient");

               //ClickOnResidualIncomeLink
               clientHelperNewSkin.ClickElement("ClickOnResidualIncomeLink");

               //DoubleClickOnSaleAgent
               clientHelperNewSkin.doubleClick("DoubleClickOnSaleAgent");
               clientHelperNewSkin.WaitForWorkAround(3000);

               //Select Agent
               clientHelperNewSkin.SelectDropDownByText("//*[@id='manager']/form/select", "Aslam Khan");
               clientHelperNewSkin.WaitForWorkAround(3000);

               //ClickSaveSaleAgent
               clientHelperNewSkin.ClickElement("ClickSaveSaleAgent");
               clientHelperNewSkin.WaitForWorkAround(3000);

               //DoubleClickOnSetRevenue
               clientHelperNewSkin.doubleClick("VerifySelectsET");
               clientHelperNewSkin.WaitForWorkAround(3000);

               //EnterRevenbueShareR1A
               clientHelperNewSkin.TypeText("EnterRevenbueShareR1A","20");
               clientHelperNewSkin.WaitForWorkAround(3000);

               //ClickSaveSetRI
               clientHelperNewSkin.ClickElement("ClickSaveSetRI");
               clientHelperNewSkin.WaitForWorkAround(5000);

               //Delete AL
               clientHelperNewSkin.ClickElement("DeleteAllRevenueShare");
               clientHelperNewSkin.WaitForWorkAround(3000);

               //Accept Alert
               clientHelperNewSkin.AcceptAlert();
               clientHelperNewSkin.WaitForWorkAround(4000);

               //Verify 
               clientHelperNewSkin.VerifyText("VerifySelectsET", "Set Revenue Share");
               clientHelperNewSkin.WaitForWorkAround(2000);

           }

            else{

           //ClickOnCreateClient
           GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/clients/create");
           clientHelperNewSkin.WaitForWorkAround(3000);

            //Select Status
           clientHelperNewSkin.Select("SelectClientStatus", "New");
           clientHelperNewSkin.WaitForWorkAround(3000);

           //SelectResponsibilty
           clientHelperNewSkin.SelectDropDownByText("//*[@id='ClientAssignedUserId']", "Aslam Khan");

           //ClickOnCompanyDetailTab
           clientHelperNewSkin.ClickElement("ClickOnCompanyDetailTab");

           //EnterDBAName
           clientHelperNewSkin.TypeText("EnterDBAName","Eidt DBA Name");

            //Save Client 
           clientHelperNewSkin.ClickElement("ClickSaveClient");
           clientHelperNewSkin.WaitForWorkAround(3000);


            //Redirect To
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/clients");
            clientHelperNewSkin.WaitForWorkAround(5000);


              //EnterCompanyDba
            clientHelperNewSkin.TypeText("EnterCompanyDba", "Eidt DBA Name");

               //ClickOnClient
               clientHelperNewSkin.ClickElement("ClickOnClient");

               //ClickOnResidualIncomeLink
               clientHelperNewSkin.ClickElement("ClickOnResidualIncomeLink");

               //DoubleClickOnSaleAgent
               clientHelperNewSkin.doubleClick("DoubleClickOnSaleAgent");
               clientHelperNewSkin.WaitForWorkAround(3000);

               //Select Agent
               clientHelperNewSkin.SelectDropDownByText("//*[@id='manager']/form/select", "Aslam Khan");
               clientHelperNewSkin.WaitForWorkAround(3000);

               //ClickSaveSaleAgent
               clientHelperNewSkin.ClickElement("ClickSaveSaleAgent");
               clientHelperNewSkin.WaitForWorkAround(3000);

               //DoubleClickOnSetRevenue
               clientHelperNewSkin.ClickElement("DoubleClickOnSetRevenue");
               clientHelperNewSkin.WaitForWorkAround(3000);

               //EnterRevenbueShareR1A
               clientHelperNewSkin.TypeText("EnterRevenbueShareR1A","20");
               clientHelperNewSkin.WaitForWorkAround(3000);

               //Accept Alert
               clientHelperNewSkin.AcceptAlert();
               clientHelperNewSkin.WaitForWorkAround(4000);

               //Verify 
               clientHelperNewSkin.VerifyText("VerifySelectsET", "Set Revenue Share");
               clientHelperNewSkin.WaitForWorkAround(2000);

              
                }
            }
        }
    }  

