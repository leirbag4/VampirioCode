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
using VampirioCode.UI.Controls;

namespace VampirioCode
{





    public partial class TabTester : Form
    {
        public TabTester()
        {
            InitializeComponent();
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            tabControlWin.TabPages.Insert(0, "some");
            //tabControlWin.TabPages.Insert()
        }

        private void button2_Click(object sender, EventArgs e)
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
    }
}
