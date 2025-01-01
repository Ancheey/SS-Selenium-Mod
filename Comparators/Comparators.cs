using OpenQA.Selenium;
using SeleniteSeaCore.variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_Selenium_Mod.Comparators
{
    public class ComparatorCheckCurrentWebsiteLink : SSValueComparerType
    {
        public override string Text => "Is the webpage {A}?";

        public override int ComparedValues => 1;

        public override CompareResults Compare(Dictionary<string, SSValue> RuntimeVars, params SSValue[] args)
        {
            if (args.Length < ComparedValues)
                return CompareResults.NeV;
            if (SeleniumEngine.Driver.Url == args[0].GetInterpolatedValue(RuntimeVars))
                return CompareResults.True;
            return CompareResults.False;
        }
    }
    public class ComparatorIsElementWithIDDisplayed : SSValueComparerType
    {
        public override string Text => "Is element with id of {A} displayed?";

        public override int ComparedValues => 1;

        public override CompareResults Compare(Dictionary<string, SSValue> RuntimeVars, params SSValue[] args)
        {
            if (args.Length < ComparedValues)
                return CompareResults.NeV;
            var val = args[0].GetInterpolatedValue(RuntimeVars);
            if (SeleniumEngine.Driver.FindElement(By.Id(val)).Displayed)
                return CompareResults.True;
            return CompareResults.False;
        }
    }
    public class ComparatorDoesElementWithIDContainText : SSValueComparerType
    {
        public override string Text => "Does the element with the id of {A} contain text {B}?";

        public override int ComparedValues => 2;

        public override CompareResults Compare(Dictionary<string, SSValue> RuntimeVars, params SSValue[] args)
        {
            if (args.Length < ComparedValues)
                return CompareResults.NeV;
            var id = args[0].GetInterpolatedValue(RuntimeVars);
            var text = args[1].GetInterpolatedValue(RuntimeVars);
            if (SeleniumEngine.Driver.FindElement(By.Id(id)).Text.Contains(text))
                return CompareResults.True;
            return CompareResults.False;
        }
    }
}
