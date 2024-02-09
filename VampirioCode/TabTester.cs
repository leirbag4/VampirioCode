using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampirioCode.UI;
using VampirioCode.UI.Controls.TabManagement;

namespace VampirioCode
{





    public partial class TabTester : Form
    {
        public TabTester()
        {
            InitializeComponent();
            
            tabControl.SelectedTabChanged +=        OnSelectedIndexChanged;
            tabControl.TabAdded +=                  OnTabAdded;
            tabControl.TabRemoved +=                OnTabRemoved;
            tabControl.StartDragTab +=              OnStartDragTab;
            tabControl.StopDragTab +=               OnStopDragTab;

            tabControlWin.SelectedIndexChanged +=   OnWinSelIndexChanged;
            tabControlWin.ControlAdded +=           OnWinControlAdded;
            tabControlWin.ControlRemoved +=         OnWinControlRemoved;
        }


        // ------------------------------------------------------------------------

        private void OnSelectedIndexChanged(int index, TabItem item)
        {
            XConsole.PrintWarning("SelIndexChanged: " + index + " item: " + item?.Text);
        }

        private void OnTabAdded(int index, TabItem item)
        {
            XConsole.PrintWarning("tab added: " + index + " item: " + item.Text);
        }

        private void OnTabRemoved(int index, TabItem item)
        {
            XConsole.PrintWarning("tab removed: " + index + " item: " + item.Text);
        }

        private void OnStartDragTab(int index, TabItem item)
        {
            XConsole.PrintWarning("start drag: " + index + " item: " + item.Text);
        }

        private void OnStopDragTab(int index, TabItem item)
        {
            XConsole.PrintWarning("stop drag: " + index + " item: " + item.Text);
        }

        // ------------------------------------------------------------------------

        private void OnWinControlAdded(object sender, ControlEventArgs e)
        {
            XConsole.PrintError("doc added: " + e.Control.Text);
        }

        private void OnWinControlRemoved(object sender, ControlEventArgs e)
        {
            XConsole.PrintError("doc removed: " + e.Control.Text);
        }

        private void OnWinSelIndexChanged(object sender, EventArgs e)
        {
            XConsole.PrintWarning("index changed: " + tabControlWin.SelectedIndex);
        }

        // ------------------------------------------------------------------------


        private void AddItem()
        {
            TabItem item = new TabItem("item " + counter++);
            item.Width = 130;

            if (counter == 1) item.Width = 80;
            if (counter == 2) item.Width = 60;
            if (counter == 3) item.Width = 140;
            if (counter == 4) item.Width = 120;
            if (counter == 5) item.Width = 60;


            tabControl.Items.Add(item);
        }

        private void RemoveItem()
        {
            tabControl.Items.RemoveAt(0);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            for (int a = 0; a < 5; a++)
                AddItem();
        }

        int counter2 = 0;

        private void WinAdd(object sender, EventArgs e)
        {
            tabControlWin.TabPages.Add("some " + counter2++);
        }

        private void WinInsert0(object sender, EventArgs e)
        {
            tabControlWin.TabPages.Insert(0, "some" + counter2++);
        }

        private void WinRemove(object sender, EventArgs e)
        {
            tabControlWin.TabPages.RemoveAt(0);
        }

        private int counter = 0;

        private void OnAdd(object sender, EventArgs e)
        {
            AddItem();
        }

        private void OnRemove(object sender, EventArgs e)
        {
            RemoveItem();
        }

        private void OnResetPressed(object sender, EventArgs e)
        {
            counter = 0;

            for (int a = 0; a < 5; a++)
                RemoveItem();

            for (int a = 0; a < 5; a++)
                AddItem();
        }

        private void OnClearPressed(object sender, EventArgs e)
        {
            XConsole.Clear();
            /*Button b = new Button();
            b.TabIndex
            b.TabIndexChanged*/
            //tabControlWin.TabIndexChanged
            //tabControlWin.TabIndex

            /*tabControlWin.SelectedIndexChanged
             tabControlWin.Selected
             tabControlWin.SelectedIndex
             tabControlWin.SelectedTab
             tabControlWin.SelectTab(index)
             tabControlWin.TabPages
             tabControlWin.tab*/
        }

        private void OnRemoveItemNumb(object sender, EventArgs e)
        {
            int numb = int.Parse(((Button)sender).Tag.ToString());
            tabControl.Items.RemoveAt(numb);
        }

        private void OnInsertItemNumb(object sender, EventArgs e)
        {
            int numb = int.Parse(((Button)sender).Tag.ToString());
            tabControl.Items.Insert(numb, new TabItem("item " + counter++));
        }

        private void OnWinRemovePressed(object sender, EventArgs e)
        {
            int numb = int.Parse(((Button)sender).Tag.ToString());
            tabControlWin.TabPages.RemoveAt(numb);
        }

        private void OnWinInsertPressed(object sender, EventArgs e)
        {
            int numb = int.Parse(((Button)sender).Tag.ToString());
            tabControlWin.TabPages.Insert(numb, new TabPage("item " + counter++));
        }

        private void OnManualSelectWinIndex(object sender, EventArgs e)
        {
            int numb = int.Parse(((Button)sender).Tag.ToString());
            tabControlWin.SelectedIndex = numb;
        }
    }
}
