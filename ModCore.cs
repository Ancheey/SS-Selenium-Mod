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

namespace SS_Selenium_Mod
{
    public class ModCore : EditorMod
    {
        public override string Name => "Selenium Mod";

        public override string Description => "Adds the selenium package functionality for chrome browser manipulation";

        public override string Version => "0.1";

        public override string Author => "Ancheey";

        public override void OnRegisterActions()
        {
            EditorRegistry.RegisterAction<ActionOpenPage>(new("Open Page", "Opens a webpage with specified an URL", typeof(DisplaySSBlock), typeof(EditorSSBlockActionBasic)));
            EditorRegistry.RegisterAction<ActionRefresh>(new("Refresh Page", "Refreshes the current webpage", typeof(DisplaySSBlock), null, Editable: false));
            EditorRegistry.RegisterAction<ActionForward>(new("Browser Forward", "Orders the browser to move forward specified amount of times", typeof(DisplaySSBlock), typeof(EditorSSBlockActionBasic)));
            EditorRegistry.RegisterAction<ActionBack>(new("Browser Back", "Orders the browser to move back specified amount of times", typeof(DisplaySSBlock), typeof(EditorSSBlockActionBasic)));
            Debug.Log(StatusCode.Success, $"Selenium support v{Version} loaded", null);
        }

        public override void OnRegisterExecutor()
        {
            TypeRegistry.RegisterType<ActionOpenPage>();
            TypeRegistry.RegisterType<ActionRefresh>();
            TypeRegistry.RegisterType<ActionForward>();
            TypeRegistry.RegisterType<ActionBack>();
            Debug.Log(StatusCode.Success, $"Selenium support v{Version} loaded", null);
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
