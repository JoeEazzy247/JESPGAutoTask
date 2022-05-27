using JESPGAutoTask.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JESPGAutoTask.Pages
{
    public class SPGTestPage : DriverHelper
    {
        public By Runbtn = By.Id("run-button");

        public By Sharebtn = By.Id("Share");

        public By Sharedialoguebtn = By.Id("share-dialog");

        public By SharedialogueLkn = By.Id("ShareLink");

        public By Output = By.ClassName("output-pane");

        public By search = By.CssSelector("input[type=search]");

        public By menu = By.CssSelector("ul[id=menu]");

        public By package(string value) => By.XPath($"//a[@package-id='NUnit'][.='{value}']");

        public By version(string value) => By.XPath($"//a[@package-id='NUnit'][.='{value}']");

        public By versionMenu = By.CssSelector("ul[aria-expanded='true']");

        public By SelectedPackage => By.XPath($"//ul[@class='nuget-packages']");
        public By SliderBlockOption => By.XPath("//div[@class='sidebar-block'][1]");
        public By SliderIcon => By.XPath("(//div[@class='sidebar-block'][1]/button)[1]");
        public By Save => By.Id("save-button");
        public By LoginModal => By.XPath("(//div[@class='modal-content'])[1]");
        public By gettingstartedbtn => By.CssSelector("a[href='/GettingStarted/']");
        public By backtoeditor => By.XPath("//a[@class='btn btn-default' and @href='/']");


        public void Sleep(int time)=> Thread.Sleep(time);
    }
}
