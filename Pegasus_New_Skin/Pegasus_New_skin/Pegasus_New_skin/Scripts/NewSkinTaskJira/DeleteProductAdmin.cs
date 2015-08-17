using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class DeleteProductAdmin : DriverTestCase
    {
        [TestMethod]
        public void deleteProductAdmin()
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

            //Redirect To Admin
        //    clientHelperNewSkin.ClickElement("https://www.pegasus-test.com/selcorp/seloffice/admin");
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/admin");
            clientHelperNewSkin.WaitForWorkAround(3000);

            //Click Product Tab Admin
            clientHelperNewSkin.ClickElement("ClickProductTabAdmin");
            
            //Redirect To
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/products");
            clientHelperNewSkin.WaitForWorkAround(3000);

            //ClickOnCreate
            clientHelperNewSkin.ClickElement("ClickOnCreate");

            //Enter ProductName
            clientHelperNewSkin.TypeText("EnterNamePrd","Delete Product");

            //SelectCategoryProd
        //    clientHelperNewSkin.Select("SelectCategoryProd", "30");
            clientHelperNewSkin.WaitForWorkAround(3000);

            //Click on Add Custom field
  //         clientHelperNewSkin.ClickElement("AddCustomField");

            //Enter field name
 //           clientHelperNewSkin.TypeText("EnterFeildName", "FieldSelect");

            //SelectFieldType
  //          clientHelperNewSkin.Select("SelectFieldType", "select");

            //ClickSaveProdBtn
            clientHelperNewSkin.ClickElement("SaveProduct");
           // clientHelperNewSkin.ClickElement("ClickSaveProdBtn");
            clientHelperNewSkin.WaitForWorkAround(3000);
            clientHelperNewSkin.VerifyPageText("Product Created Successfully");
            clientHelperNewSkin.WaitForWorkAround(3000);

            //Redirect 
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/products");
            clientHelperNewSkin.WaitForWorkAround(3000);

            //Search Product
            clientHelperNewSkin.TypeText("SearchProdcut", "Delete Product");
            clientHelperNewSkin.WaitForWorkAround(3000);

            //Click on delete product
            clientHelperNewSkin.ClickElement("DeleteProduct");
            clientHelperNewSkin.AcceptAlert();
            clientHelperNewSkin.WaitForWorkAround(3000);
            clientHelperNewSkin.VerifyPageText("Product Deleted Successfully");
            clientHelperNewSkin.WaitForWorkAround(3000);

                }
            }
        }
    

