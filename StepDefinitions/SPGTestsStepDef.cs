using JESPGAutoTask.Drivers;
using JESPGAutoTask.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace JESPGAutoTask.StepDefinitions
{
    [Binding]
    public sealed class SPGTestsStepDef : DriverHelper
    {
        WebDriverWait wait;
        SPGTestPage spgtestpage;
        string shareLink;
        public SPGTestsStepDef()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            spgtestpage = new SPGTestPage();
        }

        [Given(@"I am on \.NET Fiddle page")]
        public void GivenIAmOn_NETFiddlePage()
        {
            Assert.IsTrue(driver.Url.Contains(Enviroment.baseurl));
        }

        [When(@"I click Run button")]
        public void WhenIClickButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(spgtestpage.Runbtn)).Click();
        }

        [Then(@"output window has value '([^']*)'")]
        public void ThenOutputWindowIs(string expectedvalue)
        {
            string actualvalue = driver.FindElement(spgtestpage.Output).Text;
            Assert.AreEqual(expectedvalue, actualvalue, "values dont match");
        }

        [When(@"I search for '(.*)' if (.*),(.*) start with letter '(.*)'")]
        public void GivenNameStartWith(string searchterm,string names, string version, string param)
        {
            var options = param.Split(',');
            if (names.StartsWith(options[0]) || names.StartsWith(options[1])
                 || names.StartsWith(options[2]) || names.StartsWith(options[3]) || names.StartsWith(options[4]))
            {
                driver.FindElement(spgtestpage.search).SendKeys(searchterm);
                wait.Until(ExpectedConditions.ElementIsVisible(spgtestpage.menu));
                driver.FindElement(spgtestpage.package(searchterm)).Click();
                wait.Until(ExpectedConditions.ElementIsVisible(spgtestpage.versionMenu));
                spgtestpage.Sleep(5000);
                driver.FindElement(spgtestpage.version(version)).Click();
            }
            else if(!names.StartsWith(options[0]) || !names.StartsWith(options[1])
                 || !names.StartsWith(options[2]) || !names.StartsWith(options[3]) || !names.StartsWith(options[4]))
            {
                //throw new Exception("Name must start with A,B,C,D,E");
                Assert.Throws<Exception>(() => names.Should().StartWith(options[0], options[1], options[2], options[3], options[4]));
            }
        }

        [Then(@"Selected package is '([^']*)'")]
        public void ThenSelectedPackageIs(string expectedSelection)
        {
            var actualSelection = wait.Until(ExpectedConditions.ElementIsVisible(spgtestpage.SelectedPackage)).Text.Trim();
            Assert.AreEqual(expectedSelection, actualSelection);
        }

        [Given(@"I click '(Share|>|Save|Getting Started)' if (.*) start with letter '([^']*)'")]
        public void GivenIClickIfGeorgeStartWithLetter(string option, string names, string param)
        {
            var options = param.Split(',');
            switch (option)
            {
                case "Share":
                    if (names.StartsWith(options[0]) || names.StartsWith(options[1])
                        || names.StartsWith(options[2]) || names.StartsWith(options[3])
                        || names.StartsWith(options[4]) || names.StartsWith(options[5]))
                    {
                        wait.Until(ExpectedConditions.ElementToBeClickable(spgtestpage.Sharebtn)).Click();
                        wait.Until(ExpectedConditions.ElementIsVisible(spgtestpage.Sharedialoguebtn));
                        spgtestpage.Sleep(1000);
                        shareLink = driver.FindElement(spgtestpage.SharedialogueLkn).GetAttribute("value");
                    }
                    else if (!names.StartsWith(options[0]) || !names.StartsWith(options[1])
                         || !names.StartsWith(options[2]) || !names.StartsWith(options[3])
                         || !names.StartsWith(options[4]) || !names.StartsWith(options[5]))
                    {
                        Assert.Throws<Exception>(() =>
                        names.Should().StartWith(options[0], options[1], options[2], options[3], options[4], options[5]));
                    }
                    break;
                case ">":
                    if (names.StartsWith(options[0]) || names.StartsWith(options[1])
                        || names.StartsWith(options[2]) || names.StartsWith(options[3])
                        || names.StartsWith(options[4]))
                    {
                        wait.Until(ExpectedConditions.ElementIsVisible(spgtestpage.SliderBlockOption));
                        wait.Until(ExpectedConditions.ElementToBeClickable(spgtestpage.SliderIcon)).Click();
                        spgtestpage.Sleep(1000);
                    }
                    else if (!names.StartsWith(options[0]) || !names.StartsWith(options[1])
                        || !names.StartsWith(options[2]) || !names.StartsWith(options[3]) || !names.StartsWith(options[4]))
                    {
                        Assert.Throws<Exception>(() =>
                        names.Should().StartWith(options[0], options[1], options[2], options[3], options[4]));
                    }
                    break;
                case "Save":
                    if (names.StartsWith(options[0]) || names.StartsWith(options[1])
                        || names.StartsWith(options[2]) || names.StartsWith(options[3])
                        || names.StartsWith(options[4]))
                    {
                        wait.Until(ExpectedConditions.ElementToBeClickable(spgtestpage.Save)).Click();
                        spgtestpage.Sleep(1000);
                    }
                    else if (!names.StartsWith(options[0]) || !names.StartsWith(options[1])
                         || !names.StartsWith(options[2]) || !names.StartsWith(options[3]) || !names.StartsWith(options[4]))
                    {
                        Assert.Throws<Exception>(() =>
                        names.Should().StartWith(options[0], options[1], options[2], options[3], options[4]));
                    }
                    break;
                case "Getting Started":
                    if (names.StartsWith(options[0]) || names.StartsWith(options[1])
                        || names.StartsWith(options[2]) || names.StartsWith(options[3])
                        || names.StartsWith(options[4]))
                    {
                        wait.Until(ExpectedConditions.ElementToBeClickable(spgtestpage.gettingstartedbtn)).Click();
                        spgtestpage.Sleep(1000);
                    }
                    else if (!names.StartsWith(options[0]) || !names.StartsWith(options[1])
                         || !names.StartsWith(options[2]) || !names.StartsWith(options[3]) || !names.StartsWith(options[4]))
                    {
                        Assert.Throws<Exception>(() =>
                        names.Should().StartWith(options[0], options[1], options[2], options[3], options[4]));
                    }
                    break;
                default:
                    throw new Exception();
            }
        }

        [Then(@"i verify that link starts with '([^']*)'")]
        public void ThenIVerifyThatLinkStartsWith(string baseurl)
        {
            var actualShareLinkText = shareLink.Contains(baseurl)
                ? true : false;
            Assert.IsTrue(actualShareLinkText, $"{baseurl} not contained in {shareLink}");
        }

        [Then(@"I verify Options panel is hidden")]
        public void ThenIVerifyOptionsPanelIsHidden()
        {
            Assert.False(driver.FindElement(spgtestpage.SliderBlockOption).Displayed);
        }

        [Then(@"i verify that '(login|Back To Editor)' window appeared")]
        public void ThenIVerifyThatLoginWindowAppeared(string action)
        {
            switch (action)
            {
                case "login":
                    wait.Until(ExpectedConditions.ElementIsVisible(spgtestpage.LoginModal));
                    Assert.IsTrue(driver.FindElement(spgtestpage.LoginModal).Displayed);
                    break;
                case "Getting Started":
                    wait.Until(ExpectedConditions.ElementIsVisible(spgtestpage.backtoeditor));
                    Assert.IsTrue(driver.FindElement(spgtestpage.backtoeditor).Displayed);
                    break;
                default:
                    break;
            }
        }

    }
}