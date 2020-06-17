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
            Type = GetType();
            foreach (var c in Settings.AvaliableCryptographies)
                AddItem(c);
            HideAllArgs();
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

        }
        void SetArgNames(string[] names)
        {

        }
        System.Type Type { get; set; }
        void SetArgVisible(int index, bool visibility)
        {
            var f = Type.GetField("argName_" + index.ToString()).G;
            if (f == null)
                return;
            f.GetType().GetProperty("IsVisible").SetValue(f, visibility);
            f = Type.GetField("argInput_" + index.ToString());
            if (f == null)
                return;
            f.GetType().GetProperty("IsVisible").SetValue(f, visibility);
        }
        void SetArgName(int index, string name)
        {
            var f = Type.GetField("argName_" + index.ToString());
            if (f != null)
                f.GetType().GetProperty("Text").SetValue(f, name);
        }
        string GetArgName(int index)
        {
            var f = Type.GetField("argName_" + index.ToString());
            if (f == null)
                return null;
            else
                return f.GetType().GetProperty("Text").GetValue(f) as string;
        }
        void SetArg(int index, object arg)
        {
            var f = Type.GetField("argInput_" + index.ToString());
            if (f != null)
                f.GetType().GetProperty("Text").SetValue(f, arg.ToString());
        }
        T GetArg<T>(int index, T defaultReturn = null) where T : class
        {
            var f = Type.GetField("argInput_" + index.ToString());
            if (f != null)
                return (T)System.Convert.ChangeType(f.GetType().GetProperty("Text").GetValue(f), typeof(T));
            else
                return defaultReturn;
        }
        private void cryptos_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }
    }
    public static class ArgumentFields
    {
        public static Label argName_1;
        public static Label argName_2;
        public static Label argName_3;
        public static Label argName_4;
        public static Label argName_5;
        public static Label argName_6;
        public static Label argName_7;
        public static Label argName_8;
        public static Label argName_9;
        public static Entry argInput_1;
        public static Entry argInput_2;
        public static Entry argInput_3;
        public static Entry argInput_4;
        public static Entry argInput_5;
        public static Entry argInput_6;
        public static Entry argInput_7;
        public static Entry argInput_8;
        public static Entry argInput_9;
    }
}
