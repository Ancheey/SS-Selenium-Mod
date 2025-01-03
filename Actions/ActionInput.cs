using SeleniteSeaCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_Selenium_Mod.Actions
{
    public class ActionInput : ActionBaseForWebSelector
    {
        public ActionInput()
        {
            PublicValues.Add("Text", new(""));
        }
        public override string Title => $"Insert {PublicValues["Text"].Data} into element found {Selector.Text.ToLower()}: {SelectorValue.Data}";

        public override void DeserializeAndApplyMetadata(params string[] args)
        {
            SelectorValue.Data = args[0];
            Selector = WebSelectors.Registry[args[1]];
            PublicValues["Text"].Data = args[2];
        }

        public override bool Execute(ExecutionData data)
        {
            SeleniumEngine.Driver
                .FindElement(Selector.GetSelector(SelectorValue.GetInterpolatedValue(data.RuntimeVariables)))
                .SendKeys(PublicValues["Text"].GetInterpolatedValue(data.RuntimeVariables));
            return true;
        }

        public override string[] GetSerializedMetadata() => [PublicValues["Text"].Data, SelectorValue.Data, Selector.GetType().ToString()];
    }
}
