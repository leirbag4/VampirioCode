using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampirioCode.UI.Controls;
using VampirioCode.UI.Controls.VerticalItemListManagement;

namespace VampirioCode.UI
{
    public partial class BuilderDebugger : VampirioForm
    {
        public BuilderDebugger()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SItemValuePair item = new SItemValuePair();
            item.LeftValue = "cap";
            item.RightValue = "Dolp";

            list.AddItem(item);
        }

        private void OnRefreshPressed(object sender, EventArgs e)
        {

        }
    }
}
