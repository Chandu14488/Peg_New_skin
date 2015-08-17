using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class EditProductCategoryAdmin : DriverTestCase
    {
        [TestMethod]
        public void editProductCategoryAdmin()
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

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Redirect To Admin
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/admin");
            clientHelperNewSkin.WaitForWorkAround(4000);

            //Click on Agent in Topmenu
            clientHelperNewSkin.ClickElement("ClickProductTabAdmin");

            //Redirect 
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/products/categories");
            clientHelperNewSkin.WaitForWorkAround(3000);


            //Click Create Category Admin
            clientHelperNewSkin.ClickElement("ClickCreateCategoryAdmin");
            clientHelperNewSkin.WaitForWorkAround(4000);

            //EnterCategoryName
            var name = "Test"+ RandomNumber(1,999);
            clientHelperNewSkin.TypeText("EnterCategoryName",name);
            
            //Save Category
            clientHelperNewSkin.ClickElement("SaveCategoryAdmin");
            clientHelperNewSkin.WaitForWorkAround(4000);
            
            //Verify text
            clientHelperNewSkin.WaitForText("Category Created Successfully",30);
            clientHelperNewSkin.WaitForWorkAround(4000);

            //Seacrh And Edit
            clientHelperNewSkin.SearchAndEdit(name);
            clientHelperNewSkin.WaitForWorkAround(5000);

            //Verify title
            VerifyTitle("Edit Category");

            //Click
            clientHelperNewSkin.ClickElement("ClickEditSaveBtnCa");
            clientHelperNewSkin.WaitForWorkAround(4000);





            }
        }
    }

