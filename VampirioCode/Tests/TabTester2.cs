using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        }

        private void OnCloseTabInvoked(int index, TabItem item)
        {
            XConsole.Println("wants to close: " + item.Text);

            tabPanel.Remove(item);
        }

        private int counter = 0;

        private TabItem CreateItem()
        {
            TabItem item = new TabItem("document " + counter++);

            Button button = new Button();
            button.Text = "button " + (counter - 1);
            item.Content = button;

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
    }
}
