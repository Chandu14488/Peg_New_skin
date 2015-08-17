using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class PermanentlyDeleteDocumentNewSkin : DriverTestCase
    {
        [TestMethod]
        public void permanentlyDeleteDocumentNewSkin()
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


            //ClickOnActivitiesTab
            activitiesHelperNewSkin.ClickElement("ClickOnActivitiesTab");

            //Redirect To Document
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/documents");
            activitiesHelperNewSkin.WaitForWorkAround(4000);

            //Click On Create
            activitiesHelperNewSkin.ClickElement("ClickOnDoc");
            activitiesHelperNewSkin.WaitForWorkAround(3000);

            //ClickOnCreate
            activitiesHelperNewSkin.TypeText("DocumentName", "DELETE DOCUMENT");

            string pathtofile = GetPathToFile() + "index.jpg";
            //Attach File
            activitiesHelperNewSkin.UploadFile("//*[@id='DocumentFile']", pathtofile);
            activitiesHelperNewSkin.WaitForWorkAround(3000);

            //Click on Save
            activitiesHelperNewSkin.ClickElement("ClickOnSave");

            //Verify 
            activitiesHelperNewSkin.WaitForText("Document saved successfully.",30);

            //Search Documet 
            activitiesHelperNewSkin.TypeText("SearchDocumet", "DELETE DOCUMENT");
            activitiesHelperNewSkin.WaitForWorkAround(4000);

            //Click on Checkbox
            activitiesHelperNewSkin.ClickElement("ClickOnCheckBox");

            //Click On delete
            activitiesHelperNewSkin.ClickElement("ClickOndelete");
            activitiesHelperNewSkin.AcceptAlert();
            activitiesHelperNewSkin.WaitForWorkAround(3000);

            //Verify Document deleted successfully.
            activitiesHelperNewSkin.VerifyPageText("Document deleted successfully.");


            //Click on Recycle bin
            activitiesHelperNewSkin.ClickElement("ClickOnReycleBin");
            activitiesHelperNewSkin.WaitForWorkAround(4000);

            //Search Documet 
            activitiesHelperNewSkin.TypeText("SearchDocumet", "DELETE DOCUMENT");
            activitiesHelperNewSkin.WaitForWorkAround(4000);

            //ClickOnDeletePer
            activitiesHelperNewSkin.ClickElement("ClickOnDeletePer");
            activitiesHelperNewSkin.AcceptAlert();
            activitiesHelperNewSkin.WaitForWorkAround(3000);

            //verify Document Permanently Deleted.
            activitiesHelperNewSkin.VerifyPageText("Document Permanently Deleted.");
            activitiesHelperNewSkin.WaitForWorkAround(3000);

            }

        }
    }

