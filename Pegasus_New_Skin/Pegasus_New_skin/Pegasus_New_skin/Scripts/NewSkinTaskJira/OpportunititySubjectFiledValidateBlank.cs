using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class OpportunititySubjectFiledValidateBlank : DriverTestCase
    {
        [TestMethod]
        public void opportunititySubjectFiledValidateBlank()
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
            clientHelperNewSkin.ClickElement("ClickOnOpporTab");

            //Click TO View Opp
            clientHelperNewSkin.ClickElement("ClickToViewOpportunities");
            clientHelperNewSkin.WaitForWorkAround(3000);

            //ClcikAddNote
            clientHelperNewSkin.ClickElement("ClcikAddNote");
            clientHelperNewSkin.WaitForWorkAround(3000);

            //Enter Note Subject
            clientHelperNewSkin.TypeText("EnterNoteName","    ");

            //ClickSaveNoteButton
            clientHelperNewSkin.ClickElement("ClickSaveNoteButton");
            clientHelperNewSkin.WaitForWorkAround(3000);

            //Verify //*[@id='NoteName-error']
            clientHelperNewSkin.VerifyText("VerifyTextNoteValidation", "This field is required.");
            clientHelperNewSkin.WaitForWorkAround(3000);
              
                }
            }
        }
    

