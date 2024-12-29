using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniteSeaCore;
using SeleniteSeaEditor.modding;

namespace SS_Selenium_Mod
{
    public class ModCore : EditorMod
    {
        public override string Name => "Selenium Mod";

        public override string Description => "Adds the selenium package functionality for chrome browser manipulation";

        public override string Version => "0.1";

        public override string Author => "Ancheey";

        public override void OnLoad()
        {
            Debug.Log(StatusCode.Success,"Załadowano moda",null);
        }

        public override void OnRegisterActions()
        {
            Debug.Log(StatusCode.Success, "Zarejestrowano moda w edytorze", null);
        }

        public override void OnRegisterExecutor()
        {
            Debug.Log(StatusCode.Success, "Zarejestrowano moda w egzekutorze", null);
        }
    }
}
