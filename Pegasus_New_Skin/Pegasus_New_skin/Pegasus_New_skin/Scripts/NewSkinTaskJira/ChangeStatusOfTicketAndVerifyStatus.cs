using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class ChangeStatusOfTicketAndVerifyStatus : DriverTestCase
    {
        [TestMethod]
        public void changeStatusOfTicketAndVerifyStatus()
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
            var ticketsOfficeNewSkinHelper = new TicketsOfficeNewSkinHelper(GetWebDriver());


            //Variable random
            var name = "Ticket" + RandomNumber(1,999);



            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");


            //ClickOnActivitiesTab
            ticketsOfficeNewSkinHelper.ClickElement("ClickOnTicketTab");

            //Redirect To Document
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/tickets");
            ticketsOfficeNewSkinHelper.WaitForWorkAround(4000);

                //Click On Create
                ticketsOfficeNewSkinHelper.ClickElement("ClickOnCreateButton");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(3000);

                //ClickOnCreate
                ticketsOfficeNewSkinHelper.TypeText("EnterTicketName", name);

                //Attach File
             //   var Upld = GetPath() + "\\Up.jpg";
           
             //   ticketsOfficeNewSkinHelper.UploadFile("//*[@id='DocumentFile']", Upld);
                ticketsOfficeNewSkinHelper.WaitForWorkAround(3000);

                //Click on Client icon
                ticketsOfficeNewSkinHelper.ClickElement("ClickOnClientDisplayIcon");

                //ClickOnClient
                ticketsOfficeNewSkinHelper.ClickElement("ClickOnClient");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(5000);

                //Click on Save
                ticketsOfficeNewSkinHelper.ClickElement("ClickOnSaveTicket");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(5000);

                //Verify 
                ticketsOfficeNewSkinHelper.VerifyPageText("Ticket Created Successfully.");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(4000);

                //ClickOnActivitiesTab
                ticketsOfficeNewSkinHelper.ClickElement("ClickOnTicketTab");

                //Redirect To Document
                GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/tickets");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(4000);


                //Search Documet 
                ticketsOfficeNewSkinHelper.TypeText("SearchTicket", name);
                ticketsOfficeNewSkinHelper.WaitForWorkAround(4000);

                //Click on Checkbox
                ticketsOfficeNewSkinHelper.ClickElement("ClickOnTicket1");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(4000);

                //ClickOnDeletePer
                ticketsOfficeNewSkinHelper.ClickElement("ClickResolvedBtn");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(3000);

                //verify Document Permanently Deleted.
                ticketsOfficeNewSkinHelper.Select("SelectTicketResolution","Issue Resolved");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(3000);

                //Click Resolved SaveBtn
                 ticketsOfficeNewSkinHelper.ClickElement("ClickResolvedSaveBtn");
                 ticketsOfficeNewSkinHelper.WaitForWorkAround(3000);

                //Ticket Resolved Successfully
                ticketsOfficeNewSkinHelper.VerifyPageText("Ticket Resolved Successfully.");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(4000);


                //Search Documet 
                ticketsOfficeNewSkinHelper.TypeText("SearchTicket", name);
                ticketsOfficeNewSkinHelper.WaitForWorkAround(4000);

               //Verify Status
                ticketsOfficeNewSkinHelper.VerifyText("VerifyTextResolver", "Resolved");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(4000);


                //Click on Checkbox
                ticketsOfficeNewSkinHelper.ClickElement("ClickOnTicket1");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(4000);

               //Click On Closed 
                ticketsOfficeNewSkinHelper.ClickElement("ClosedTicket");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(4000);

              // Verify Ticket Closed Successfully.
                ticketsOfficeNewSkinHelper.VerifyPageText("Ticket Closed Successfully.");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(4000);


                //Search Documet 
                ticketsOfficeNewSkinHelper.TypeText("SearchTicket", name);
                ticketsOfficeNewSkinHelper.WaitForWorkAround(4000);

                //Verify Status
                ticketsOfficeNewSkinHelper.VerifyText("VerifyTextResolver", "Closed");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(4000);




            }

        }
    }

