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
    public partial class DirectoryInput : UserControl
    {
        public delegate void DirPathChangedEvent(string path);

        public event DirPathChangedEvent DirPathChanged;
        public string DirPath { get { return input.Text; } set { input.Text = value; } }

        private string description = "";

        public DirectoryInput()
        {
            InitializeComponent();

            input.TextChanged += OnPathChanged;
        }

        public void Setup(string description)
        {
            this.description = description;
        }

        private void OnPathChanged(object? sender, EventArgs e)
        {
            if (DirPathChanged != null)
                DirPathChanged(input.Text);
        }

        private void OnBrowsePressed(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = description;
            dialog.ShowNewFolderButton = true;

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
            {
                DirPath = dialog.SelectedPath;
            }

        }
    }
}
