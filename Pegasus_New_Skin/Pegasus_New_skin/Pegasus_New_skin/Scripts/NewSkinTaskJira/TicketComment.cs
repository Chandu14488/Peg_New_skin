using System;
using System.IO;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;


namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class TicketComment : DriverTestCase
    {
        [TestMethod]
        public void ticketComment()
        {
            string[] username = null;
            string[] password = null;
            string[] log = null;
            var oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username");
            password = oXMLData.getData("settings/Credentials", "password");
            log = oXMLData.getData("settings/URL", "logout");

            //Initializing the objects
            var loginHelper = new LoginHelper(GetWebDriver());
            var clientHelper = new ClientsHelper(GetWebDriver());
            var partnerAgentHelperNewSkin = new PartnerAgentHelperNewSkin(GetWebDriver());
            
            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Go to Ticket open page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/ticket-search/open");

            //Verify title
            VerifyTitle("Tickets");

            //Open a ticket
            partnerAgentHelperNewSkin.ClickElement("TicketOpen");

           //Verify title
            VerifyTitle("Ticket View");

            //wait
            partnerAgentHelperNewSkin.WaitForWorkAround(2000);

            //Click on 'Add Comment' button
            partnerAgentHelperNewSkin.ClickElement("TicketEdit");

            string comment = "My Comment " + RandomNumber(1,9999);

            //wait
            partnerAgentHelperNewSkin.WaitForWorkAround(2000);
            
            //Type commment
            partnerAgentHelperNewSkin.TypeInArea("TicketComment", comment);

            //Click on save button
            partnerAgentHelperNewSkin.ClickElement("TicketCommentSave");

            //Verify No duplicate comment displayed
            partnerAgentHelperNewSkin.verifyCommentCount(comment,1);

            //Delete comment
            partnerAgentHelperNewSkin.ClickElement("TicketCommentDelete");

            //Accept alert
            partnerAgentHelperNewSkin.AcceptAlert();

            //Verify comment deleted
            Assert.IsFalse(partnerAgentHelperNewSkin.IsElementPresent("//div[contains(text()," + comment + ")]"));

            //Log out from the application
            GetWebDriver().Navigate().GoToUrl(log[0]);

        }
    }
}
