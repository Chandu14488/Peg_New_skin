using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class VerifyButtonsForTickets : DriverTestCase
    {
        [TestMethod]
        public void verifyButtonsForTickets()
        {
            string[] username = null;
            string[] password = null;

            var oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username");
            password = oXMLData.getData("settings/Credentials", "password");

            //Initializing the objects
            var loginHelper = new LoginHelper(GetWebDriver());
            var ticketsOfficeNewSkinHelper = new TicketsOfficeNewSkinHelper(GetWebDriver());


            //Variable random
            var name = "TESTCLIENT" + RandomNumber(1,999);


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

            //Search Documet 
       //     ticketsOfficeNewSkinHelper.TypeText("SearchTicket", "TICKET");
            ticketsOfficeNewSkinHelper.WaitForWorkAround(4000);

            var locsrch = "//table[@id='list1']/tbody/tr[2]";
            if (ticketsOfficeNewSkinHelper.IsElementPresent(locsrch))
            {

                //Click on Checkbox
                ticketsOfficeNewSkinHelper.ClickElement("ClickOnTicket");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(4000);

                //Click On Edit
                ticketsOfficeNewSkinHelper.ClickElement("ClickEditTicketBtn");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(3000);

                //Verify 
                ticketsOfficeNewSkinHelper.VerifyPageText("Edit");

                //Redirect back
                GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/tickets/view/944");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(4000);

                //Verify
                ticketsOfficeNewSkinHelper.VerifyText("ClickDeleteBtn", "Delete");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(3000);

                //ClickOnDeletePer
                ticketsOfficeNewSkinHelper.ClickElement("ClickResolvedBtn");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(3000);

                //verify Document Permanently Deleted.
                ticketsOfficeNewSkinHelper.VerifyPageText("Add Resolution");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(3000);


            }

            else
            {
                //Click On Create
                ticketsOfficeNewSkinHelper.ClickElement("ClickOnCreateButton");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(3000);

                //ClickOnCreate
                ticketsOfficeNewSkinHelper.TypeText("EnterTicketName", "TICKET");

                //Attach File
                ticketsOfficeNewSkinHelper.UploadFile("//*[@id='DocumentFile']", "D:\\NEWPEG\\TestAutomationProject\\PegasusTests\\Files\\Up.jpg");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(3000);

                //Click on Client icon
                ticketsOfficeNewSkinHelper.ClickElement("ClickOnClientDisplayIcon");

                //ClickOnClient
                ticketsOfficeNewSkinHelper.ClickElement("ClickOnClient");

                //Click on Save
                ticketsOfficeNewSkinHelper.ClickElement("ClickOnSaveTicket");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(5000);

                //Verify 
                ticketsOfficeNewSkinHelper.VerifyPageText("Ticket saved successfully.");

                //Search Documet 
                ticketsOfficeNewSkinHelper.TypeText("SearchTicket", "TICKET");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(4000);

                //Click on Checkbox
                ticketsOfficeNewSkinHelper.ClickElement("ClickOnTicket");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(4000);

                //Click On Edit
                ticketsOfficeNewSkinHelper.ClickElement("ClickEditTicketBtn");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(3000);

                //Verify 
                ticketsOfficeNewSkinHelper.VerifyPageText("Edit");

                //Redirect back
                GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/tickets/view/944");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(4000);

                //Verify
                ticketsOfficeNewSkinHelper.VerifyText("ClickDeleteBtn", "Delete");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(3000);

                //ClickOnDeletePer
                ticketsOfficeNewSkinHelper.ClickElement("ClickResolvedBtn");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(3000);

                //verify Document Permanently Deleted.
                ticketsOfficeNewSkinHelper.VerifyPageText("Add Resolution");
                ticketsOfficeNewSkinHelper.WaitForWorkAround(3000);
            }
            }

        }
    }

