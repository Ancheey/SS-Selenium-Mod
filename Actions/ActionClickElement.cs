using SeleniteSeaCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_Selenium_Mod.Actions
{
    public class ActionClickElement : ActionBaseForWebSelector
    {
        public override string Title => $"Click first element found {Selector.Text.ToLower()}: {SelectorValue.Data}";

        public override void DeserializeAndApplyMetadata(params string[] args)
        {
            SelectorValue.Data = args[0];
            Selector = WebSelectors.Registry[args[1]];
        }

        public override bool Execute(ExecutionData data)
        {
            SeleniumEngine.Driver.FindElement(Selector.GetSelector(SelectorValue.GetInterpolatedValue(data.RuntimeVariables))).Click();
            return true;
        }

        public override string[] GetSerializedMetadata() => [SelectorValue.Data, Selector.GetType().ToString()];
    }
}
