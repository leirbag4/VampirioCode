using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampDocManager;
using VampirioCode.UI;
using VampirioCode.UI.Controls;
using VampirioCode.UI.Controls.TabManagement;

namespace VampirioCode.Tests
{
    public partial class TabTester2 : Form
    {
        public TabTester2()
        {
            InitializeComponent();
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            tabPanel.CloseTabInvoked += OnCloseTabInvoked;

            tabPanel.Add(CreateItem());
            tabPanel.Add(CreateItem());
            tabPanel.Add(CreateItem());
            tabPanel.Add(CreateItem());
        }

        private void OnCloseTabInvoked(int index, TabItem item)
        {
            XConsole.Println("wants to close: " + item.Text);

            tabPanel.Remove(item);
        }

        private int counter = 0;

        private TabItem CreateItem()
        {
            /*TabItem item = new TabItem("document " + counter++);

            Button button = new Button();
            button.Text = "button " + (counter - 1);
            button.Dock = DockStyle.Fill;
            item.Content.Controls.Add(button);
            return item;*/


            /*DocumentTab item = DocumentTab.Create(VampDocManager.Document.NewTemporary());
            return item;*/

            TabItem item = new TabItem("document " + counter++);
            TextBox txtBox = new TextBox();
            txtBox.Multiline = true;
            txtBox.BackColor = Color.FromArgb(30, 30, 30);
            txtBox.ForeColor = Color.Silver;
            txtBox.BorderStyle = BorderStyle.None;
            txtBox.Dock = DockStyle.Fill;
            item.Content.Controls.Add(txtBox);
            return item;

        }

        private void OnClearConsolePressed(object sender, EventArgs e)
        {
            XConsole.Clear();
        }

        private void OnAddPressed(object sender, EventArgs e)
        {
            tabPanel.Add(CreateItem());
        }

        private void OnRemovePressed(object sender, EventArgs e)
        {
            tabPanel.RemoveAt(0);
        }

        private void OnRemoveSelected(object sender, EventArgs e)
        {
            tabPanel.Remove(tabPanel.SelectedTab);
        }

        private void OnSetTextPressed(object sender, EventArgs e)
        {
            tabPanel.SelectedTab.Text = tabNameInput.Text;
            tabPanel.Invalidate();
        }

        private void OnSkinPressed(object sender, EventArgs e)
        {
            int skinId = int.Parse((sender as Button).Tag.ToString());
            TabSkin skin = (TabSkin)skinId;

            tabPanel.SetSkin(skin);
        }
    }
}
