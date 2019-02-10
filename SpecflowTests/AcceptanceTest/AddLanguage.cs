using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;
using OpenQA.Selenium.Support.UI;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class SpecFlowFeature1Steps : Utils.Start
    {
        [Given(@"I clicked on the Language tab under Profile page")]
        public void GivenIClickedOnTheLanguageTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();


        }

        [When(@"I add a new language")]
        public void WhenIAddANewLanguage()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();

            //Add Language
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")).SendKeys("Spanish");

            //Click on Language Level
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select")).Click();

            //Choose the language level
            IWebElement Lang = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option"))[1];
            Lang.Click();

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")).Click();

        }

        [Then(@"that language should be displayed on my listings")]
        public void ThenThatLanguageShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "English";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }


        [Given(@"I clicked on the Edit button of a Language added (.*)")]
        public void GivenIClickedontheEditbuttonofaLanguageadded(string Editlang)

        {
            CommonMethods.ExtentReports();
            CommonMethods.test = CommonMethods.extent.StartTest("Edit a language");
            try
            {
                for(int i=1; i<=4; i++)
                {
                    string langinlist = Driver.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[2]/tr[1]/td[1]")).Text;
                    if (langinlist == Editlang)
                    {
                        Driver.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[3]/tr[1]/td[3]/span[1]/i[1]")).Click();
                        break;

                    }
                }
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Error in Editing Language" + e.Message);
            }


            
        }

          [When(@"I update language (.*) and its level (.*)")]
          public void WhenIupdatelanguageanditsLevel(string lang, string levels)
        { 
           try
            {
                //Enter Language
                IWebElement Language = Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
                Language.Clear();
                Language.SendKeys(lang);
                ScenarioContext.Current["Langua"] = lang;

                //Click on Language Level
                IWebElement LanguageLevel = Driver.driver.FindElement(By.XPath("//select[@name='level']"));
                     SelectElement Level = new SelectElement(LanguageLevel);
                    Level.SelectByText(levels);
                ScenarioContext.Current["level"] = levels;

                //Click on update button
                Driver.driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Language not found to edit", e.Message);
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Languagenotfound");
            }
        
        }
        

        [Then(@"that language should be edited and displayed under the lestings page")]
        public void ThenThatLanguageShouldBeEditedAndDisplayedUnderTheLestingsPage()
        {
            try
            {

                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("Edit a Language");

                Thread.Sleep(3000);
                string ExpectedValue = "Spanish";
                string ActualValue = Driver.driver.FindElement(By.XPath("//td[@class='right aligned']//i[@class='outline write icon']")).Text;
                Thread.Sleep(200);

                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Edit a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Language Edited");

                }
                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Passed");
            }

            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }


        }
        [Given(@"I clicked on the delete button of a language added (.*)")]
        public void GivenIClickedOnTheDeleteButtonOfALanguageAdded(string ToDelete)
        {

            CommonMethods.ExtentReports();
            CommonMethods.test = CommonMethods.extent.StartTest("Delete a Language");
            try
            {
                ScenarioContext.Current["ToDelete"] = ToDelete;
                for (int j = 1; j <= 4; j++)
                {
                    string LanguageToDelete = Driver.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[2]/tr[1]/td[1]")).Text;
                    if (LanguageToDelete == ToDelete)
                    {
                        Driver.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[2]/tr[1]/td[3]/span[2]/i[1]")).Click();
                        break;

                    }
                }
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "LanguageNotFound" + e.Message);
            }
        }
        

       [Then(@"that language should be deleted")]
        public void ThenThatLanguageShouldBeDeleted()
        {
            try
            {
                var LanguageToDelete = ScenarioContext.Current["ToDelete"];
                string ExpectedLanguageDeleted = LanguageToDelete.ToString();
                bool LanguageDelete = CommonMethods.ElementVisible(Driver.driver,"XPath", "//td[contains(text(),"+ExpectedLanguageDeleted+",)]");
                    if (LanguageDelete)
                {
                    CommonMethods.test.Log(LogStatus.Fail, "LanguageDeleteFailed");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageDeleteFail");
                }
                    else

                {
                    CommonMethods.test.Log(LogStatus.Pass, "LanguageDeleted Succesfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageDeleted Successfully");


                }
            }
            catch(Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "LanguageDeleteFailed" +e.Message);
            }
        }
        [Given(@"I clicked on the Skills tab under the profile page")]
        public void GivenIClickedOnTheSkillsTabUnderTheProfilePage()
        {
            //wait
            Thread.Sleep(1000);

            //Click on the Skills Tab
            Driver.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[1]/a[2]")).Click();

       
        }

        [When(@"I add a new skill")]
        public void WhenIAddANewSkill()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/table[1]/thead[1]/tr[1]/th[3]/div[1]")).Click();

            //Click on Add New Skill
            Driver.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/div[1]/div[1]/input[1]")).SendKeys("Plumber");

            //Click on Choose Skill Level
            Driver.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/div[1]/div[2]/select[1]")).Click();

            //Click on Add button
            Driver.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/div[1]/span[1]/input[1]")).Click();

        }

        [Then(@"that skill must be displayed on my listings")]
        public void ThenThatSkillMustBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a new Skill");

                Thread.Sleep(1000);
                string ExpectedValue = "Carpenter";
                string ActualValue = Driver.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[1]")).Text;

                Thread.Sleep(100);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added Skill successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Skill Added");

                }

                else

                    CommonMethods.test.Log(LogStatus.Fail, "Test Passed");
            }

            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
            
        }




    }
}

