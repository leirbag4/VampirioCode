using System.Drawing.Drawing2D;

namespace VampirioCode
{
    public partial class App : Form
    {
        private VampEditor.VampirioEditor editor2;

        public App()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            //tabControl.DrawMode = TabDrawMode.Normal;

            tabControl.SetSkin(16, CColor(64, 64, 64), CColor(39, 40, 34), CColor(170, 60, 85), CColor(255, 255, 255));

            // CREATE CONTROL
            editor2 = new VampEditor.VampirioEditor();
            editor2.BorderStyle = ScintillaNET.BorderStyle.None;
            codeContainer.Controls.Add(editor2); //TextPanel.Controls.Add(TextArea);

            // BASIC CONFIG
            editor2.Dock = System.Windows.Forms.DockStyle.Fill;
            //TextArea.TextChanged += (this.OnTextChanged);

            // INITIAL VIEW CONFIG
            //editor2.WrapMode = WrapMode.None;
            //TextArea.IndentationGuides = IndentView.LookBoth;


            //CreateEditor();

            editor2.SetLanguage(VampEditor.LangId.CSharp, VampEditor.StyleMode.Dark);

            editor2.Text = @"using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampEditor.Language
{
    public class LanguageBase
    {
        protected VampirioEditor editor;
        protected StyleCollection Styles { get; private set; }

        public void Config(VampirioEditor editor)
        {
            string str = " + "\"this is a long short string for test\";" + @"
            this.editor = editor;
            this.Styles = editor.Styles;
            int numb = 1215;
            float numb = 15.236f;
            decimal numb = 99.3236;
        }

        public void Activate(StyleMode style)
        {
            OnActivate(style);
        }

        protected virtual void OnActivate(StyleMode style)
        { }

        protected Color CColor(int red, int green, int blue)
        {
            return Color.FromArgb(red, green, blue);
        }


    }
}";

            base.OnLoad(e);
        }

        private Color CColor(int red, int green, int blue)
        {
            return Color.FromArgb(red, green, blue);
        }
        private void OnTestPressed(object sender, EventArgs e)
        {
            editor2.DebugTest();
        }
    }
}
