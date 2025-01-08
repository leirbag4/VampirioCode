using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampirioCode.Builder;
using VampirioCode.BuilderInstall.cpp;
using VampirioCode.BuilderInstall.csharp;
using VampirioCode.BuilderInstall.Java;
using VampirioCode.BuilderInstall.Javascript;
using VampirioCode.BuilderInstall.PHP;
using VampirioCode.SaveData;
using VampirioCode.UI;
using VampirioCode.UI.Controls;
using VampirioCode.UI.Controls.VerticalItemListManagement;
using VampirioCode.UI.Controls.VerticalItemListManagement.Components;

namespace VampirioCode.BuilderInstall
{
    public partial class BuildToolSelector : VampirioForm
    {
        private BuildSetupBase CurrSetup = null;

        public BuildToolSelector()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            CreateTitleItem("C++");
            CreateItem("C++ MSVC",          BuilderKind.CppMsvc);
            CreateItem("C++ GNU g++",       BuilderKind.CppGnuGpp);
            CreateItem("C++ CLang",         BuilderKind.CppCLang);
            CreateItem("C++ Emscripten",    BuilderKind.CppEmscripten);
            CreateTitleItem("C#");
            CreateItem("C# Dotnet",         BuilderKind.CSharpDotnet);
            CreateTitleItem("Javascript");
            CreateItem("JS NodeJS",         BuilderKind.JavascriptNodeJs);
            CreateTitleItem("Java");
            CreateItem("Java javac",        BuilderKind.JavaJavac);
            CreateTitleItem("PHP");
            CreateItem("PHP Xampp",         BuilderKind.PhpXampp);


            XConsole.Push();
            XConsole.SetOutput(outp);

            list.SelectedItemChanged += OnSelectedItemChanged;

            list.SelectedIndex = 1;
        }

        private void OnSelectedItemChanged(object sender)
        {

            SItem item = list.SelectedItem as SItem;
            BuilderKind builderKind = (BuilderKind)item.Tag;

            SaveAndRemovePrevBuilder();

            switch (builderKind)
            { 
                case BuilderKind.CppMsvc:
                    SetBuilder(new MsvcBuildSetup());
                    break;

                case BuilderKind.CppGnuGpp:
                    SetBuilder(new GnuGppBuildSetup());
                    break;

                case BuilderKind.CppCLang:
                    SetBuilder(new CLangBuildSetup());
                    break;

                case BuilderKind.CppEmscripten:
                    SetBuilder(new EmscriptenBuildSetup());
                    break;

                case BuilderKind.CSharpDotnet:
                    SetBuilder(new DotnetBuildSetup());
                    break;

                case BuilderKind.JavascriptNodeJs:
                    SetBuilder(new NodeJsBuildSetup());
                    break;

                case BuilderKind.JavaJavac:
                    SetBuilder(new JavacBuildSetup());
                    break;

                case BuilderKind.PhpXampp:
                    SetBuilder(new XamppBuildSetup());
                    break;
            }

        }

        private void SaveAndRemovePrevBuilder()
        {
            if (CurrSetup != null)
            {
                CurrSetup.SaveData();
                CurrSetup.Parent.Controls.Remove(CurrSetup);
                CurrSetup = null;
            }
        }

        private void SetBuilder(BuildSetupBase buildSetup)
        {
            CurrSetup = buildSetup;
            buildContainer.Controls.Add(CurrSetup);
            CurrSetup.LoadData();
        }

        private void CreateItem(string name, BuilderKind builderKind)
        {
            SItem item = new SItem();

            item.Text0.Text = name;
            item.Text0.Offsets = new Point(5, 0);
            item.Text0.TextAlign = ContentAlignment.MiddleLeft;
            item.Image0 = new SItemImage(Properties.Resources.med_tick_off);
            item.Image0.ImageAlign = ContentAlignment.MiddleRight;
            item.Image0.Offsets = new Point(-5, 0);
            item.Tag = builderKind;

            list.AddItem(item);
        }

        private void CreateTitleItem(string title)
        {
            SItem item = new SItem();

            item.Text = title;
            item.Enabled = false;
            item.Text0.SetColors(Color.White, Color.Green, Color.Blue);
            item.UpColor = Color.FromArgb(115, 115, 255);

            list.AddItem(item);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            if (CurrSetup != null)
            {
                CurrSetup.SaveData();
            }

            Config.Save();

            XConsole.Pop();
        }
    }
}
