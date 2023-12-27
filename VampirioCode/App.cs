using System.Drawing.Drawing2D;
using VampirioCode.UI;

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
