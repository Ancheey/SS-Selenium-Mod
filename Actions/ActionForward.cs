using SeleniteSeaCore;
using SeleniteSeaCore.codeblocks.actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_Selenium_Mod.Actions
{
    public class ActionForward : SSBlockActionBasic
    {
        public ActionForward()
        {
            PublicValues.Add("How many times", new("1"));
        }

        public override string Title => $"If possible, move forward {PublicValues["How many times"].Data} time/s";

        public override void DeserializeAndApplyMetadata(params string[] args)
        {
            PublicValues["How many times"].Data = args[0];
        }

        public override bool Execute(ExecutionData data)
        {
            if (!PublicValues["How many times"].TryParseNumber(data.RuntimeVariables, out var i))
                throw new ArgumentException($"Moving forward impossible because {PublicValues["How many times"].Data} after parsing ({PublicValues["How many times"].GetInterpolatedValue(data.RuntimeVariables)}) is not a number");

            for(double j = 0; j < i; j++)
                SeleniumEngine.Driver.Navigate().Forward();

            return true;
        }

        public override string[] GetSerializedMetadata() => [PublicValues["How many times"].Data];
    }
}
