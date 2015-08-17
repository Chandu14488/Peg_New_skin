using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class ClientDublicateMatchOverlay : DriverTestCase
    {
        [TestMethod]
        public void clientDublicateMatchOverlay()
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

           //ClickOnMerchantTab
           clientHelperNewSkin.ClickElement("ClickOnMerchantTab");
           clientHelperNewSkin.WaitForWorkAround(3000);

           //VMCMerchantid
           clientHelperNewSkin.TypeText("VMCMerchantid", "1");

           //DinarId
           clientHelperNewSkin.TypeText("DinarId", "1");
           clientHelperNewSkin.WaitForWorkAround(2000);

           //AmexMerchantId
          // clientHelperNewSkin.TypeText("AmexMerchantId", "1");
           clientHelperNewSkin.WaitForWorkAround(2000);

           //JCBID
           clientHelperNewSkin.TypeText("JCBID", "1");

           //DiscoverMercahntId
           clientHelperNewSkin.TypeText("DiscoverMercahntId", "1");

           //EDTID
           clientHelperNewSkin.TypeText("EDTID", "1");

           //VMCMerchantid
           clientHelperNewSkin.TypeText("PNSNumber", "1");

           //VMCMerchantid
           clientHelperNewSkin.TypeText("ByPassNumber", "1");

           //NashVilleIDE 
           clientHelperNewSkin.TypeText("NashVilleIDE", "1");

           //VMCMerchantid
           clientHelperNewSkin.TypeText("VitualNumberTer1", "1");

           //VMCMerchantid
           clientHelperNewSkin.TypeText("VTTerminal2", "1");

           //VMCMerchantid
           clientHelperNewSkin.TypeText("DataWireID", "1");

           //VMCMerchantid
           clientHelperNewSkin.TypeText("DebitID", "1");

           //VMCMerchantid
           clientHelperNewSkin.TypeText("CheckID", "1");

            //Save Client 
           clientHelperNewSkin.ClickElement("ClickSaveClient");
           clientHelperNewSkin.WaitForWorkAround(6000);

           var loc = "//*[@id='messageduplicate']/div[2]/div/div[1]/h3";

           if (clientHelperNewSkin.IsElementPresent(loc))
           {
               //VerifyExisting
               clientHelperNewSkin.VerifyText("VerifyExisting", "Existing Clients");
               clientHelperNewSkin.WaitForWorkAround(6000);
           }

           else
           {
               //Verify 
               clientHelperNewSkin.VerifyPageText("Client saved successfully.");
               clientHelperNewSkin.WaitForWorkAround(3000);

//Create Another Clinet
               //Click on Agent in Topmenu
               clientHelperNewSkin.ClickElement("ClickOnClientTab");


               //ClickOnCreateClient
               GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/clients/create");



               //Select Status
               clientHelperNewSkin.Select("SelectClientStatus", "New");
               clientHelperNewSkin.WaitForWorkAround(3000);

               //SelectResponsibilty
               clientHelperNewSkin.SelectDropDownByText("//*[@id='ClientAssignedUserId']", "Aslam Khan");

               //Save Client 
               clientHelperNewSkin.ClickElement("ClickSaveClient");
               clientHelperNewSkin.WaitForWorkAround(3000);


               //EnterDBAName
               clientHelperNewSkin.TypeText("EnterDBAName", "Eidt DBA Name");

               //VMCMerchantid
               clientHelperNewSkin.TypeText("VMCMerchantid", "1");

               //DinarId
               clientHelperNewSkin.TypeText("DinarId", "1");

               //AmexMerchantId
           //    clientHelperNewSkin.TypeText("AmexMerchantId", "1");

               //JCBID
               clientHelperNewSkin.TypeText("JCBID", "1");

               //DiscoverMercahntId
               clientHelperNewSkin.TypeText("DiscoverMercahntId", "1");

               //EDTID
               clientHelperNewSkin.TypeText("EDTID", "1");

               //VMCMerchantid
               clientHelperNewSkin.TypeText("PNSNumber", "1");

               //VMCMerchantid
               clientHelperNewSkin.TypeText("ByPassNumber", "1");

               //NashVilleIDE 
               clientHelperNewSkin.TypeText("NashVilleIDE", "1");

               //VMCMerchantid
               clientHelperNewSkin.TypeText("VitualNumberTer1", "1");

               //VMCMerchantid
               clientHelperNewSkin.TypeText("VTTerminal2", "1");

               //VMCMerchantid
               clientHelperNewSkin.TypeText("DataWireID", "1");

               //VMCMerchantid
               clientHelperNewSkin.TypeText("DebitID", "1");

               //VMCMerchantid
               clientHelperNewSkin.TypeText("CheckID", "1");

               //Save Client 
               clientHelperNewSkin.ClickElement("ClickSaveClient");
               clientHelperNewSkin.WaitForWorkAround(7000);

               //VerifyExisting
               clientHelperNewSkin.VerifyText("VerifyExisting", "Existing Clients");
               clientHelperNewSkin.WaitForWorkAround(6000);


                      }
              
                }
            }
      }
    

