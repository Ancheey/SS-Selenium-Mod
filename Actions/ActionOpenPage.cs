using SeleniteSeaCore;
using SeleniteSeaCore.codeblocks.actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_Selenium_Mod.Actions
{
    public class ActionOpenPage : SSBlockActionBasic
    {
        public ActionOpenPage()
        {
            PublicValues.Add("URL", new("https://www."));
        }

        public override string Title => $"Open {PublicValues["URL"]} in the browser.";

        public override void DeserializeAndApplyMetadata(params string[] args)
        {
            PublicValues["URL"].Data = args[0];
        }

        public override bool Execute(ExecutionData data)
        {
            string link = PublicValues["URL"].GetInterpolatedValue(data.RuntimeVariables);
            SeleniumEngine.Driver.Navigate().GoToUrl(link);
            return true;
        }

        public override string[] GetSerializedMetadata() => [PublicValues["URL"].Data];
    }
}
