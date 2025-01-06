using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VampirioCode.BuilderInstall.UI
{
    public partial class FileInput : UserControl
    {
        public string FilePath { get { return input.Text; } set { input.Text = value; } }

        private string extension = "";
        private string description = "";

        public FileInput()
        {
            InitializeComponent();
        }

        public void Setup(string extension, string description)
        { 
            this.extension = extension;
            this.description = description;
        }

        private void OnBrowsePressed(object sender, EventArgs e)
        {


            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select a file";
            //dialog.Filter = "Executable files (*.exe)|*.exe";
            //dialog.DefaultExt = ".exe";
            dialog.Filter =     $"{description} (*{extension})|*{extension}";
            dialog.DefaultExt = extension;
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string selectedFile = dialog.FileName;
                input.Text = selectedFile;
            }
        }

    }
}
