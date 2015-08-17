using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class EditThemeAdmin : DriverTestCase
    {
        [TestMethod]
        public void editThemeAdmin()
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
            var themeAdminHelper = new ThemeAdminHelper(GetWebDriver());

            //VARIABLE
            var name = "TestEmployee" + GetRandomNumber();


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");


            //ClickOnCreateClient
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/admin");
            themeAdminHelper.WaitForWorkAround(3000);


            //Click on Agent in Topmenu
            themeAdminHelper.ClickElement("ClickOnSystemTab");

            //Redirect  To Theme
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/themes");
            themeAdminHelper.WaitForWorkAround(3000);
            

            //EnterThemeSearch
            themeAdminHelper.TypeText("EnterThemeSearch", "test234");
            themeAdminHelper.WaitForWorkAround(3000);
            

            //SelectFontSize
            themeAdminHelper.ClickElement("ClickEditTheme");
            themeAdminHelper.WaitForWorkAround(3000);
            

            //SelectFontSize
            themeAdminHelper.SelectDropDownByText("//*[@id='ThemeOption27Value']", "10px");

            //CLickSaveButton
            themeAdminHelper.ClickElement("CLickSaveButton");
            themeAdminHelper.WaitForWorkAround(3000);
            
            
            //Verify 
            themeAdminHelper.VerifyPageText("Theme Configuration has been updated.");
            themeAdminHelper.WaitForWorkAround(3000);

              
                }
            }
        }
    

