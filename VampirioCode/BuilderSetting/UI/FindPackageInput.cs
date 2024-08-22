using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VampirioCode.BuilderSetting.UI
{
    public partial class FindPackageInput : UserControl
    {
        public string SelectedPackage { get { return input.Text; } set { input.Text = value; } }

        public FindPackageInput()
        {
            InitializeComponent();
        }

        private void OnFindPressed(object sender, EventArgs e)
        {
            FindPackageList findPackageList = new FindPackageList();
            findPackageList.SetPackage(input.Text);
            var result = findPackageList.ShowDialog();

            SelectedPackage = findPackageList.SelectedPackage;

        }
    }
}
