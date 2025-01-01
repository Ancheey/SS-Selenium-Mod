using OpenQA.Selenium;
using SeleniteSeaCore.variables;
using SeleniteSeaCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_Selenium_Mod
{
    public static class WebSelectors
    {
        public static Dictionary<string, WebSelector> Registry { get; private set; } = [];
        public static void Register<T>() where T : WebSelector
        {
            try
            {
                WebSelector? a = (WebSelector?)Activator.CreateInstance(typeof(T));
                if (a is null)
                {
                    Debug.Log(StatusCode.Error, $"Failed web selector registration for {typeof(T).Name}. Lacking a constructor", null);
                    return;
                }
                Registry.Add(typeof(T).ToString(), a);
            }
            catch (Exception e)
            {
                Debug.Log(StatusCode.Error, $"Failed web selector registration for {typeof(T).Name}. {e.ToString()}", null);
            }
        }
        static WebSelectors()
        {
            Register<IDWebSelector>();
            Register<CssSelectorWebSelector>();
            Register<XPathWebSelector>();
            Register<NameWebSelector>();
            Register<ClassNameWebSelector>();
            Register<LinkTextWebSelector>();
            Register<PartialLinkTextWebSelector>();
            Register<TagNameWebSelector>();
        }
    }
    public abstract class WebSelector
    {
        public abstract string Text { get; }
        public abstract By GetSelector(string value);
        public override string ToString() => Text;
    }
    public class IDWebSelector : WebSelector
    {
        public override string Text => "By ID";
        public override By GetSelector(string value)=>By.Id(value);
    }
    public class CssSelectorWebSelector : WebSelector
    {
        public override string Text => "By Css Selector";
        public override By GetSelector(string value) => By.CssSelector(value);
    }
    public class XPathWebSelector : WebSelector
    {
        public override string Text => "By XPath";
        public override By GetSelector(string value) => By.XPath(value);
    }
    public class NameWebSelector : WebSelector
    {
        public override string Text => "By Name";
        public override By GetSelector(string value) => By.Name(value);
    }
    public class ClassNameWebSelector : WebSelector
    {
        public override string Text => "By Class Name";
        public override By GetSelector(string value) => By.ClassName(value);
    }
    public class LinkTextWebSelector : WebSelector
    {
        public override string Text => "By Link Text";
        public override By GetSelector(string value) => By.LinkText(value);
    }
    public class PartialLinkTextWebSelector : WebSelector
    {
        public override string Text => "By Partial Link Text";
        public override By GetSelector(string value) => By.PartialLinkText(value);
    }
    public class TagNameWebSelector : WebSelector
    {
        public override string Text => "By Tag Name";
        public override By GetSelector(string value) => By.TagName(value);
    }

}
