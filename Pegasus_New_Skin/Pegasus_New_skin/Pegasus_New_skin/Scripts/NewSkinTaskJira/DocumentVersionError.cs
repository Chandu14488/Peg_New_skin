using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class DocumentVersionError : DriverTestCase
    {
        [TestMethod]
        public void documentVersionError()
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

            //ClickOnActivitiesTab
            activitiesHelperNewSkin.ClickElement("ClickOnActivitiesTab");

            //Redirect To Document
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/documents/create");
            
            //Verify title
            VerifyTitle("Create a New Document");

            //Verify version is set to 1
            string value = activitiesHelperNewSkin.getFiledText("DocVersion");

            Assert.IsTrue(value.Contains("1"));

            //Redirect To Document
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/documents");

            //Verify title
            VerifyTitle("Documents");

            //Edit first doc
            activitiesHelperNewSkin.ClickElement("EditDoc");

            //Verify title
            VerifyTitle("Edit Document");

            //Verify document version is not user editable
            Console.WriteLine("CHECK = " + activitiesHelperNewSkin.GetAtrributeByLocator("//*[@id='DocumentVersion']", "readonly"));

            Assert.IsTrue(activitiesHelperNewSkin.GetAtrributeByLocator("//*[@id='DocumentVersion']", "readonly").Contains("true"));

            //Click on Add new version
            activitiesHelperNewSkin.ClickElement("NewVersion");

            activitiesHelperNewSkin.WaitForWorkAround(2000);

            //Upload file
            activitiesHelperNewSkin.UploadFile("//*[@id='DocumentFile']", GetPathToFile()+"2.pdf");

            //Enter comment
            activitiesHelperNewSkin.TypeText("DocCommnet", "Comment");

            //Click on Save button
            activitiesHelperNewSkin.ClickElement("DocSave");
            activitiesHelperNewSkin.WaitForWorkAround(3000);

            //Verify one is not deletable
            activitiesHelperNewSkin.verifyOneNotDeletable();
        }

    }
}

