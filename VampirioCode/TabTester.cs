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
        private TabItem saveSelected;
        private Button draggedTab = null;
        private int draggedTabOffsetX = 0;

        public TabTester()
        {
            InitializeComponent();

            tabBar.SelectedTabChanged += OnSelectedIndexChanged;
            tabBar.TabAdded += OnTabAdded;
            tabBar.TabRemoved += OnTabRemoved;
            tabBar.StartDragTab += OnStartDragTab;
            tabBar.StopDragTab += OnStopDragTab;
            tabBar.RightClickContext += OnRightClickContext;
            tabBar.TabDetached += OnTabDetached;

            tabControlWin.SelectedIndexChanged += OnWinSelIndexChanged;
            tabControlWin.ControlAdded += OnWinControlAdded;
            tabControlWin.ControlRemoved += OnWinControlRemoved;

            tabBar.AllowDetach = true;
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

        private void OnRightClickContext(TabItem item)
        {
            XConsole.PrintWarning("Right click: " + item.Text);
        }

        private void OnTabDetached(int index, TabItem item, int offsetX)
        {
            XConsole.PrintWarning("Tab detached, offsetX: " +  offsetX + "  -> " + item.Text);

            draggedTabOffsetX = offsetX;

            Point clientPos = this.PointToClient(Cursor.Position);

            int mouseX = clientPos.X;
            int mouseY = clientPos.Y;

            tabBar.Remove(item);

            draggedTab = new Button();
            draggedTab.Size = new Size(item.Width, item.Height);
            draggedTab.Text = item.Text;
            draggedTab.Left = mouseX - draggedTabOffsetX;
            draggedTab.Top = mouseY - (draggedTab.Height >> 1);
            draggedTab.ForeColor = Color.Silver;
            draggedTab.FlatStyle = FlatStyle.Flat;
            Controls.Add(draggedTab);
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


        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            draggedTab = null;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (draggedTab != null)
            {
                draggedTab.Left = e.X - draggedTabOffsetX;
                draggedTab.Top = e.Y - (draggedTab.Height >> 1);
            }
        }


        // ------------------------------------------------------------------------

        private void AddItem()
        {
            TabItem item = new TabItem("item " + counter++);
            //item.Width = 30;

            if (counter == 1) item.Width = 80;
            if (counter == 2) item.Width = 60;
            if (counter == 3) item.Width = 140;
            if (counter == 4) item.Width = 120;
            if (counter == 5) item.Width = 60;

            string[] names = new string[] { "main.cpp", "Program.cs", "Unitled document", "cfg.dat", "data.cfg", "Game Engine", "Bitcoin", "001", "no name", "cmd.run", "Linux VM 01" };

            int i = counter - 1;

            if (i < (names.Length))
                item.Text = names[i];

            tabBar.Items.Add(item);
        }

        private void RemoveItem()
        {
            tabBar.Items.RemoveAt(0);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            for (int a = 0; a < 15; a++)
                AddItem();

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            tabBar.Focus();
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
        }

        private void OnRemoveItemNumb(object sender, EventArgs e)
        {
            int numb = int.Parse(((Button)sender).Tag.ToString());
            tabBar.Items.RemoveAt(numb);
        }

        private void OnInsertItemNumb(object sender, EventArgs e)
        {
            int numb = int.Parse(((Button)sender).Tag.ToString());
            tabBar.Items.Insert(numb, new TabItem("item " + counter++));
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

        private void OnRemoveSelected(object sender, EventArgs e)
        {
            tabBar.Remove(tabBar.SelectedTab);
            //tabBar.RemoveAt(tabBar.SelectedTab.Index);
        }

        private void OnSaveSelectedPressed(object sender, EventArgs e)
        {
            saveSelected = tabBar.SelectedTab;
            XConsole.Println(saveSelected.Text + " saved");
        }

        private void OnRestoreSelectedPressed(object sender, EventArgs e)
        {
            tabBar.SelectedTab = saveSelected;
            XConsole.Println(saveSelected.Text + " retore at: " + saveSelected.Index);
        }

        private void OnBringToScreenPressed(object sender, EventArgs e)
        {
            tabBar.BringTabToScreen(tabBar.SelectedTab);
        }

        private void OnClearItemsPressed(object sender, EventArgs e)
        {
            tabBar.Items.Clear();
        }

        private void OnSetTabTextPressed(object sender, EventArgs e)
        {
            tabBar.SelectedTab.Text = tabNameInput.Text;
            tabBar.Invalidate();
        }

        private void OnSetAllStylesPressed(object sender, EventArgs e)
        {
            tabBar.NormalStyle.TextColor = Color.Red;
            Invalidate();
        }

        private void OnSet1TabStylePressed(object sender, EventArgs e)
        {
            tabBar.SelectedTab.NormalStyle = new TabStyle(Color.Red, Color.Green, Color.Blue);
            Invalidate();
        }

        private void OnBringToScreenSaved(object sender, EventArgs e)
        {
            tabBar.BringTabToScreen(saveSelected);
        }
    }
}
