using System;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class EmailNoteWithRelatedTo : DriverTestCase
    {
        [TestMethod]
        public void emailNoteWithRelatedTo()
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
            var activitiesHelperNewSkin = new ActivitiesHelperNewSkin(GetWebDriver());


            //Variable random
            var name = "TESTCLIENT" + RandomNumber(1,999);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //ClickOnPdfTab
            activitiesHelperNewSkin.ClickElement("ClickOnActivitiesTab");
     
            //Redirect To
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/notes");
            activitiesHelperNewSkin.WaitForWorkAround(2000);

            //Clcik Create 
            activitiesHelperNewSkin.ClickElement("ClickOnCreate");
            activitiesHelperNewSkin.WaitForWorkAround(3000);

            //NoteSubject
            activitiesHelperNewSkin.TypeText("NoteSubject","Testing Subject");

            //Select Client
            activitiesHelperNewSkin.SelectDropDownByText("//*[@id='NoteParentType']", "Client");
            activitiesHelperNewSkin.WaitForWorkAround(4000);

            //cClickIconToSelectClient
            activitiesHelperNewSkin.ClickElement("ClickIconToSelectClient");
            activitiesHelperNewSkin.WaitForWorkAround(4000);

            //ClickONClientNS
            activitiesHelperNewSkin.ClickElement("ClickONClientNS");
            activitiesHelperNewSkin.WaitForWorkAround(4000);


            //SaveNoteNS
            activitiesHelperNewSkin.ClickElement("SaveNoteNS");
            activitiesHelperNewSkin.WaitForWorkAround(4000);

            //ClickOnNotes
            activitiesHelperNewSkin.ClickElement("ClickOnNotes");
            activitiesHelperNewSkin.WaitForWorkAround(4000);

            //ClickEmailNoteC
            activitiesHelperNewSkin.ClickElement("ClickEmailNoteC");
            activitiesHelperNewSkin.WaitForWorkAround(4000);

            //vERIFYcLIENTsELECTED
            activitiesHelperNewSkin.VerifyText("vERIFYcLIENTsELECTED", "Client");
            activitiesHelperNewSkin.WaitForWorkAround(4000);






            }

        }
    }

