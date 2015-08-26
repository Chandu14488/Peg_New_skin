using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class UniqueDocError : DriverTestCase
    {
        [TestMethod]
        public void uniqueDocError()
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

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Redirect To Document
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/documents/create");
            
            //Verify title
            VerifyTitle("Create a New Document");

            //ClickOnCreate
            activitiesHelperNewSkin.TypeText("DocumentName", "Doc1");

            string pathtofile = GetPathToFile() + "Upload1.pdf";
            //Attach File
            activitiesHelperNewSkin.UploadFile("//*[@id='DocumentFile']", pathtofile);
            
            //Select releted to
            activitiesHelperNewSkin.selectByText("ReletedTo", "Client");

            //Select Client
            activitiesHelperNewSkin.ClickElement("Assign");
            activitiesHelperNewSkin.WaitForWorkAround(4000);
            activitiesHelperNewSkin.ClickElement("AssignUser");
            activitiesHelperNewSkin.WaitForWorkAround(2000);

            //Click on Save
            activitiesHelperNewSkin.ClickElement("ClickOnSave");

            activitiesHelperNewSkin.WaitForText("Document saved successfully.",30);

            VerifyTitle("Documents");

            //Redirect To Document
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/documents/create");

            //Verify title
            VerifyTitle("Create a New Document");

            //ClickOnCreate
            activitiesHelperNewSkin.TypeText("DocumentName", "Doc2");

            pathtofile = GetPathToFile() + "Upload2.pdf";
            //Attach File
            activitiesHelperNewSkin.UploadFile("//*[@id='DocumentFile']", pathtofile);

            //Select releted to
            activitiesHelperNewSkin.selectByText("ReletedTo", "Client");

            //Select Client
            activitiesHelperNewSkin.ClickElement("Assign");
            activitiesHelperNewSkin.WaitForWorkAround(4000);
            activitiesHelperNewSkin.ClickElement("AssignUser");
            activitiesHelperNewSkin.WaitForWorkAround(2000);

            //Click on Save
            activitiesHelperNewSkin.ClickElement("ClickOnSave");

            activitiesHelperNewSkin.WaitForText("Document saved successfully.", 30);

            VerifyTitle("Documents");

            //Redirect To Document
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/documents/create");

            //Verify title
            VerifyTitle("Create a New Document");

            //ClickOnCreate
            activitiesHelperNewSkin.TypeText("DocumentName", "Doc3");

            pathtofile = GetPathToFile() + "Upload3.pdf";
            //Attach File
            activitiesHelperNewSkin.UploadFile("//*[@id='DocumentFile']", pathtofile);

            //Select releted to
            activitiesHelperNewSkin.selectByText("ReletedTo", "Client");

            //Select Client
            activitiesHelperNewSkin.ClickElement("Assign");
            activitiesHelperNewSkin.WaitForWorkAround(4000);
            activitiesHelperNewSkin.ClickElement("AssignUser");
            activitiesHelperNewSkin.WaitForWorkAround(2000);

            //Click on Save
            activitiesHelperNewSkin.ClickElement("ClickOnSave");

            activitiesHelperNewSkin.WaitForText("Document saved successfully.", 30);

            VerifyTitle("Documents");

            //Redirect To Document
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/documents/create");

            //Verify title
            VerifyTitle("Create a New Document");

            //ClickOnCreate
            activitiesHelperNewSkin.TypeText("DocumentName", "Doc4");

            pathtofile = GetPathToFile() + "Upload4.pdf";
            //Attach File
            activitiesHelperNewSkin.UploadFile("//*[@id='DocumentFile']", pathtofile);

            //Select releted to
            activitiesHelperNewSkin.selectByText("ReletedTo", "Client");

            //Select Client
            activitiesHelperNewSkin.ClickElement("Assign");
            activitiesHelperNewSkin.WaitForWorkAround(4000);
            activitiesHelperNewSkin.ClickElement("AssignUser");
            activitiesHelperNewSkin.WaitForWorkAround(2000);

            //Click on Save
            activitiesHelperNewSkin.ClickElement("ClickOnSave");

            activitiesHelperNewSkin.WaitForText("Document saved successfully.", 30);

            VerifyTitle("Documents");

            //Go to client page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/clients");

            //Verify title
            VerifyTitle("Clients");

            //Open the chy client
            activitiesHelperNewSkin.ClickElement("Chy");

            //Verify title
            VerifyTitle("- Details");

            //Click on info
            activitiesHelperNewSkin.ClickElement("Info");

            //Verify title
            VerifyTitle("- Details");

            
            }

        }
    }

