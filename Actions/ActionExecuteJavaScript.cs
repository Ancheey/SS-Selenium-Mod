using OpenQA.Selenium.Support.Extensions;
using SeleniteSeaCore;
using SeleniteSeaCore.codeblocks.actions;
using SeleniteSeaEditor.controls.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_Selenium_Mod.Actions
{
    public class ActionExecuteJavaScript : SSBlockActionBasic
    {
        public ActionExecuteJavaScript()
        {
            PublicValues.Add("Script", new(""));
        }

        public override string Title => $"Execute JavaScript ({PublicValues["Script"]})";

        public override void DeserializeAndApplyMetadata(params string[] args)
        {
            PublicValues["Script"].Data = args[0];
        }

        public override bool Execute(ExecutionData data)
        {
            SeleniumEngine.Driver.ExecuteJavaScript(PublicValues["Script"].GetInterpolatedValue(data.RuntimeVariables));
            return true;
        }

        public override string[] GetSerializedMetadata() => [PublicValues["Script"].Data];
    }
}
