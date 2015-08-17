﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class MakeStatusActivePDFTemplateCorp : DriverTestCase
    {
        [TestMethod]
        public void makeStatusActivePDFTemplateCorp()
        {
            string[] username = null;
            string[] password = null;

            var oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username2");
            password = oXMLData.getData("settings/Credentials", "password2");

            //Initializing the objects
            var loginHelper = new LoginHelper(GetWebDriver());
            var clientHelper = new ClientsHelper(GetWebDriver());
            var pDFTemplateAdminHelper = new PDFTemplateAdminHelper(GetWebDriver());


            //Variable random
            var name = "TESTCLIENT" + RandomNumber(1,999);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //ClickOnPdfTab
            pDFTemplateAdminHelper.ClickElement("ClickOnPdfTab");

            //Redirect To
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/pdf_templates");
            pDFTemplateAdminHelper.WaitForWorkAround(2000);


            //Enter PDF TO sEARCH
            pDFTemplateAdminHelper.TypeText("EnterPDFToSearch", "2.pdf");
            pDFTemplateAdminHelper.WaitForWorkAround(4000);

            //SelectModuleToSearch
            pDFTemplateAdminHelper.Select("SelectModuleToSearch", "clients");
            pDFTemplateAdminHelper.WaitForWorkAround(4000);

            var loc= "//table[@id='list1']/tbody/tr[2]";

            if (pDFTemplateAdminHelper.IsElementPresent(loc))
            {

                //cLICK ON pdf
                pDFTemplateAdminHelper.ClickElement("ClickEdit");

                //cLICK On Delete
                pDFTemplateAdminHelper.Select("SelectStatusCorp", "1");

                //Click Save Edit
                pDFTemplateAdminHelper.ClickElement("ClickSaveEdit");

                //Verify
                pDFTemplateAdminHelper.WaitForText("PDF Template Updated Successfully.",40);


            }
            else
            {
                //ClickOnPdfTab
                pDFTemplateAdminHelper.ClickElement("ClickOnPdfTab");

                //Redirect To Import
                GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/pdf_templates/import");

                //ChooseModule
                pDFTemplateAdminHelper.Select("ChooseModule", "20");

                var path = GetPathToFile() + "2.pdf";
                //bROWSER
                pDFTemplateAdminHelper.UploadFile("//*[@id='PdfTemplatePdfFile']", path);


                //Click import
                pDFTemplateAdminHelper.ClickElement("ClickOnImport");
                pDFTemplateAdminHelper.WaitForWorkAround(5000);

                //ClickOnNext
                pDFTemplateAdminHelper.ClickElement("ClickOnNext");

                //Select Category
                pDFTemplateAdminHelper.Select("SelectCategory", "49");

                //ClickOnSave
                pDFTemplateAdminHelper.ClickElement("ClickOnSave");
                pDFTemplateAdminHelper.WaitForWorkAround(3000);
                //Verify 
                pDFTemplateAdminHelper.VerifyPageText("PDF Template options saved successfully.");

                //Redirect To
                //   GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/pdf_templates");
                pDFTemplateAdminHelper.WaitForWorkAround(2000);

                //Enter PDF TO sEARCH
                pDFTemplateAdminHelper.TypeText("EnterPDFToSearch", "2.pdf");
                pDFTemplateAdminHelper.WaitForWorkAround(4000);

                //SelectModuleToSearch
                pDFTemplateAdminHelper.Select("SelectModuleToSearch", "clients");
                pDFTemplateAdminHelper.WaitForWorkAround(4000);

                //cLICK ON pdf
                pDFTemplateAdminHelper.ClickElement("ClickEdit");

                //cLICK On Delete
                pDFTemplateAdminHelper.Select("SelectStatusCorp", "1");

                //Click Save Edit
                pDFTemplateAdminHelper.ClickElement("ClickSaveEdit");

                //Verify
                pDFTemplateAdminHelper.VerifyPageText("PDF Template Updated Successfully.");


            }
            }

        }
    }

