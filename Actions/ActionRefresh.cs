using SeleniteSeaCore;
using SeleniteSeaCore.codeblocks.actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_Selenium_Mod.Actions
{
    public class ActionRefresh : SSBlockActionBasic
    {
        public override string Title => $"Refresh current page";

        public override void DeserializeAndApplyMetadata(params string[] args){}

        public override bool Execute(ExecutionData data)
        {
            SeleniumEngine.Driver.Navigate().Refresh();
            return true;
        }

        public override string[] GetSerializedMetadata() => [];
    }
}
