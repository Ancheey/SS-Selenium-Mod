using SeleniteSeaCore.codeblocks.actions;
using SeleniteSeaCore.variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_Selenium_Mod.Actions
{
    public abstract class ActionBaseForWebSelector : SSBlockActionBasic
    {
        public WebSelector Selector { get; set; } = WebSelectors.Registry.First().Value;
        public SSValue SelectorValue { get; set; } = new("");
    }
}
