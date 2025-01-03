using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniteSeaCore;
using SeleniteSeaExecutor;
using SeleniteSeaEditor;
using SeleniteSeaEditor.controls.Displays;
using SeleniteSeaEditor.controls.Editors;
using SeleniteSeaEditor.modding;
using SS_Selenium_Mod.Actions;
using System.IO;
using SeleniteSeaCore.variables;
using SS_Selenium_Mod.Comparators;
using SS_Selenium_Mod.Editors;

namespace SS_Selenium_Mod
{
    public class ModCore : EditorMod
    {
        public override string Name => "Selenium Mod";

        public override string Description => "Adds the selenium package functionality for chrome browser manipulation";

        public override string Version => "0.1";

        public override string Author => "Ancheey";
        public override void OnLoad()
        {
            if (!Directory.Exists(ExeCore.LocalDirectory + @"\dependencies\webdriver\"))
                Directory.CreateDirectory(ExeCore.LocalDirectory + @"\dependencies\webdriver\");
            if(!File.Exists(ExeCore.LocalDirectory + @"\dependencies\webdriver\chromedriver.exe"))
            {
                throw new Exception("No chromedriver found in the /dependencies/webdriver folder! go to https://developer.chrome.com/docs/chromedriver/downloads and download one for your chrome version");
            }

            Comparers.Register<ComparatorCheckCurrentWebsiteLink>();
            Comparers.Register<ComparatorDoesElementWithIDContainText>();
            Comparers.Register<ComparatorIsElementWithIDDisplayed>();
        }
        public override void OnRegisterActions()
        {
            EditorRegistry.RegisterAction<ActionOpenPage>(new("(Web) Open Page", "Opens a webpage with specified an URL", typeof(DisplaySSBlock), typeof(EditorSSBlockActionBasic)));
            EditorRegistry.RegisterAction<ActionRefresh>(new("(Web) Refresh Page", "Refreshes the current webpage", typeof(DisplaySSBlock), null, Editable: false));
            EditorRegistry.RegisterAction<ActionForward>(new("(Web) Browser Forward", "Orders the browser to move forward specified amount of times", typeof(DisplaySSBlock), typeof(EditorSSBlockActionBasic)));
            EditorRegistry.RegisterAction<ActionBack>(new("(Web) Browser Back", "Orders the browser to move back specified amount of times", typeof(DisplaySSBlock), typeof(EditorSSBlockActionBasic)));
            EditorRegistry.RegisterAction<ActionGetContentBy>(new("(Web) Get Content", "Gets the content of a web element", typeof(DisplaySSBlock), typeof(EditorActionBaseForWebSelector)));
            EditorRegistry.RegisterAction<ActionClickElement>(new("(Web) Click Element", "Clicks a web element", typeof(DisplaySSBlock), typeof(EditorActionBaseForWebSelector)));
            EditorRegistry.RegisterAction<ActionExecuteJavaScript>(new("(Web) Execute JS", "Execute a JavaScript script", typeof(DisplaySSBlock), typeof(EditorSSBlockActionBasic)));
            EditorRegistry.RegisterAction<ActionInput>(new("(Web) Input Text", "Input text into a field as if clicked on a keyboard", typeof(DisplaySSBlock), typeof(EditorActionBaseForWebSelector)));
        }

        public override void OnRegisterExecutor()
        {
            TypeRegistry.RegisterType<ActionOpenPage>();
            TypeRegistry.RegisterType<ActionRefresh>();
            TypeRegistry.RegisterType<ActionForward>();
            TypeRegistry.RegisterType<ActionBack>();
            TypeRegistry.RegisterType<ActionGetContentBy>();
            TypeRegistry.RegisterType<ActionClickElement>();
            TypeRegistry.RegisterType<ActionExecuteJavaScript>();
            TypeRegistry.RegisterType<ActionInput>();
        }
        public override void AfterExecution()
        {
            SeleniumEngine.Driver.Quit();
        }
        public override void OnUnload()
        {
            SeleniumEngine.Dispose();
        }
    }
}
