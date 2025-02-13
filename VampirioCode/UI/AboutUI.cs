using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampirioCode.SaveData;
using VampirioCode.UI.Controls;

namespace VampirioCode.UI
{
    public partial class AboutUI : VampirioForm
    {
        public AboutUI()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            versionLabel.Text = "version: " + Config.Version;

            base.OnLoad(e);
        }

        private void OnClosePressed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnLinkPressed(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel link = sender as LinkLabel;
            
            try
            {
                string url = link.Tag.ToString();//"https://github.com/leirbag4/VampirioCode";
                Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
            }
            catch (Exception ex)
            {
                XConsole.Alert("Can't open url");
            }
        }
    }
}
