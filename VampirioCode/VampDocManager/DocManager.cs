using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.UI;
using VampirioCode.UI.Controls;

namespace VampDocManager
{
    public class DocManager : UserControl
    {
        public DocumentTab CurrDocumentTab { get { return (DocumentTab)tabControl.SelectedTab; } }

        private TabControlVamp tabControl;

        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem closeItem;
        private ToolStripMenuItem closeAllItem;
        private ToolStripMenuItem closeAllButThis;

        public DocManager() 
        {
            tabControl =            new TabControlVamp();
            tabControl.Dock =       DockStyle.Fill;
            tabControl.BackColor =  Color.FromArgb(30, 30, 30);
            tabControl.Margin =     new Padding(0);
            tabControl.Padding =    new Point(0, 0);
            tabControl.SetSkin(25, CColor(30, 30, 30), CColor(39, 40, 34), CColor(170, 60, 85), CColor(255, 255, 255));
            CreateContextItems();

            //tabControl.DragAndDrop = true;
            //tabControl.AllowDrop = true;
            this.Controls.Add(tabControl);

            NewDocument();
        }

        private static Color CColor(int red, int green, int blue)
        {
            return Color.FromArgb(red, green, blue);
        }

        private void CreateContextItems()
        {
            closeItem =         new ToolStripMenuItem("Close");                 closeItem.Click +=          OnCloseTabPressed;
            closeAllItem =      new ToolStripMenuItem("Close All");             closeAllItem.Click +=       OnCloseAllPressed;
            closeAllButThis =   new ToolStripMenuItem("Close All but this");    closeAllButThis.Click +=    OnCloseAllButThisPressed;

            contextMenu = new ContextMenuStrip(); 
            contextMenu.Items.AddRange(new ToolStripMenuItem[] { closeItem, closeAllItem, closeAllButThis });
            tabControl.ContextMenuStrip = contextMenu;
            tabControl.ContextMenuStrip.ForeColor = Color.Silver;
            tabControl.ContextMenuStrip.Renderer =  new VampGraphics.ToolStripRendererVamp();
        }

        public void NewDocument()
        {
            DocumentTab page = new DocumentTab();
            page.Text = "capitan.cs";

            tabControl.TabPages.Add(page);

            DocumentTab page2 = new DocumentTab();
            page2.Text = "lepronito.cs";

            tabControl.TabPages.Add(page2);

            //TabDocument

        }

        private void OnCloseTabPressed(object sender, EventArgs e)
        {
            //MessageBox.Show("is: " + CurrDocumentTab.Document.Filename);
        }

        private void OnCloseAllPressed(object sender, EventArgs e)
        {

        }

        private void OnCloseAllButThisPressed(object sender, EventArgs e)
        {

        }
    }

    
}
