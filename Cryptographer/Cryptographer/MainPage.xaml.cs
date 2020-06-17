using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Cryptographer
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Type = typeof(ArgumentFields);
            foreach (var c in Settings.AvaliableCryptographies)
                AddItem(c);
            SetArgVisible(1, false);
            SetArgVisible(2, false);
        }
        void HideAllArgs()
        {
            int biggest = 0;
            foreach (var f in Type.GetFields())
                if (f.Name.Contains("arg"))
                { var v = int.Parse(Regex.Match(f.Name, @"arg\w+_(\d)").Groups[1].Value); if (v > biggest) biggest = v; }

            // SetArgsVisible(biggest);
        }
        void AddItem(object o)
        {
            cryptos.Items.Add(o.GetType().GetProperty("Name").GetValue(o) as string);
            MethodInfo encrypt = (MethodInfo)o.GetType().GetProperty("Encrypt").GetValue(o);

        }
        public static implicit operator string(MainPage v)
        {
            if (v.cryptos.SelectedItem != null)
                return v.cryptos.SelectedItem.ToString();
            else return null;
        }
        void SetArgsVisible(int ammount)
        {
            var total = 4;

        }
        void SetArgNames(string[] names)
        {

        }
        System.Type Type { get; set; }
        void SetArgVisible(int index, bool visibility)
        {
            switch (index)
            {
                case 1:
                    argName_1.IsVisible = visibility;
                    argInput_1.IsVisible = visibility;
                    break;
                case 2:
                    argName_2.IsVisible = visibility;
                    argInput_2.IsVisible = visibility;
                    break;
                case 3:
                    argName_3.IsVisible = visibility;
                    argInput_3.IsVisible = visibility;
                    break;
                case 4:
                    argName_4.IsVisible = visibility;
                    argInput_4.IsVisible = visibility;
                    break;

            }
        }
        void SetArgName(int index, string name)
        {
            var f = Type.GetField("argName_" + (index + 1).ToString()).GetValue(this);
            if (f != null)
                f.GetType().GetProperty("Text").SetValue(f, name);
        }
        string GetArgName(int index)
        {
            var f = Type.GetField("argName_" + (index + 1).ToString()).GetValue(this);
            if (f == null)
                return null;
            else
                return f.GetType().GetProperty("Text").GetValue(f) as string;
        }
        void SetArg(int index, object arg)
        {
            var f = Type.GetField("argInput_" + (index + 1).ToString()).GetValue(this);
            if (f != null)
                f.GetType().GetProperty("Text").SetValue(f, arg.ToString());
        }
        T GetArg<T>(int index, T defaultReturn = null) where T : class
        {
            var f = Type.GetField("argInput_" + (index + 1).ToString()).GetValue(this);
            if (f != null)
                return (T)System.Convert.ChangeType(f.GetType().GetProperty("Text").GetValue(f), typeof(T));
            else
                return defaultReturn;
        }
        private void cryptos_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var cr = Settings.AvaliableCryptographies[((Picker)sender).SelectedIndex];
            var encrypt = (MethodInfo)cr.GetType().GetProperty("Encrypt").GetValue(cr);
            var prms = encrypt.GetParameters();
            SetArgsVisible(prms.Length);
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {

        }

        private void Button_Clicked_1(object sender, System.EventArgs e)
        {
            SetArgVisible(1, false);
        }
    }
}
