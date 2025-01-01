using SeleniteSeaCore.codeblocks.actions;
using SeleniteSeaEditor.controls.Editors;
using SeleniteSeaEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SS_Selenium_Mod.Actions;

namespace SS_Selenium_Mod.Editors
{
    /// <summary>
    /// Logika interakcji dla klasy EditorActionBaseForWebSelector.xaml
    /// </summary>
    public partial class EditorActionBaseForWebSelector : Window
    {
        private readonly ActionBaseForWebSelector Edited;
        readonly Dictionary<string, SSValueEditor> keyValuePairs = [];
        public EditorActionBaseForWebSelector(ActionBaseForWebSelector basic)
        {
            Edited = basic;
            InitializeComponent();
            foreach(var selector in WebSelectors.Registry.Values)
                BySelector.Items.Add(selector);
            BySelector.SelectedItem = Edited.Selector;
            BySelectorValue.Text = Edited.SelectorValue.Data;
            if (EditorRegistry.Actions.TryGetValue(basic.GetType(), out var item))
            {
                Title = $"{item.Name} editor";
                ItemName.Content = item.Name;
                ItemDescription.Text = item.Description;
            }
            foreach (var value in basic.PublicValues)
            {
                var editor = new SSValueEditor(value.Key, value.Value?.Data);
                Values.Children.Add(editor);
                keyValuePairs.Add(value.Key, editor);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var pair in keyValuePairs)
                Edited.PublicValues[pair.Key] = new(pair.Value.Value);
            Edited.Selector = (WebSelector)BySelector.SelectedItem;
            Edited.SelectorValue.Data = BySelectorValue.Text;
            DialogResult = true;
        }
    }
}
