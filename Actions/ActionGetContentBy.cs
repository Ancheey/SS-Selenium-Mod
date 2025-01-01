using OpenQA.Selenium;
using SeleniteSeaCore;
using SeleniteSeaCore.codeblocks.actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace SS_Selenium_Mod.Actions
{
    public class ActionGetContentBy : ActionBaseForWebSelector
    {
        public ActionGetContentBy()
        {
            PublicValues.Add("Value if element not found", new(""));
            PublicValues.Add("Target variable name", new(""));
        }

        public override string Title => $"Read content from element found {Selector.Text.ToLower()}: {SelectorValue.Data}. If item isn't found return {PublicValues["Value if element not found"].Data} instead.";

        public override void DeserializeAndApplyMetadata(params string[] args)
        {
            SelectorValue.Data = args[0];
            PublicValues["Value if element not found"].Data = args[1];
            PublicValues["Target variable name"].Data = args[2];
            if (args.Length > 4)
                Selector = WebSelectors.Registry[args[1]];
        }

        public override bool Execute(ExecutionData data)
        {
            var id = SelectorValue.GetInterpolatedValue(data.RuntimeVariables);

            string ret;
            try
            {
                IWebElement el = SeleniumEngine.Driver.FindElement(Selector.GetSelector(id));
                ret = el.Text;
            }
            catch (NoSuchElementException)
            {
                ret = PublicValues["Value if element not found"].GetInterpolatedValue(data.RuntimeVariables);
            }
            var varname = PublicValues["Target variable name"].GetInterpolatedValue(data.RuntimeVariables);
            if (data.RuntimeVariables.TryGetValue(varname,out var val))
                val.Data = ret;
            else
                data.RuntimeVariables.Add(varname, new(ret));
            return true;
        }

        public override string[] GetSerializedMetadata() => [SelectorValue.Data, PublicValues["Value if element not found"].Data, PublicValues["Target variable name"].Data, Selector.GetType().ToString()];
    }
}
