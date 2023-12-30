using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampirioCode.UI;
using VampirioCode.UI.Controls;
using VampirioCode.Utils;

namespace VampDocManager
{
    public class DocManager : UserControl
    {
        public DocumentTab CurrDocumentTab { get { return (DocumentTab)tabControl.SelectedTab; } }
        public Document CurrDocument { get { return CurrDocumentTab.Document; } }
        public DocumentTab[] DocumentTabs { get; set; } = new DocumentTab[0];
        public Document[] Documents { get; set; } = new Document[0];
        public int CurrIndex { get { return tabControl.SelectedIndex; } set { tabControl.SelectedIndex = value; } }

        // controls
        private TabControlVamp tabControl;

        // context menu
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem closeItem;
        private ToolStripMenuItem closeAllItem;
        private ToolStripMenuItem closeAllButThis;
        private ToolStripMenuItem newItem;

        public DocManager()
        {
            tabControl = new TabControlVamp();
            tabControl.Dock = DockStyle.Fill;
            tabControl.BackColor = Color.FromArgb(30, 30, 30);
            tabControl.Margin = new Padding(0);
            tabControl.Padding = new Point(0, 0);
            tabControl.SetSkin(25, CColor(30, 30, 30), CColor(39, 40, 34), CColor(170, 60, 85), CColor(255, 255, 255));
            tabControl.ControlAdded += OnDocumentTabAdded;
            tabControl.SelectedIndexChanged += OnSelectedIndexChanged;
            CreateContextItems();

            //tabControl.DragAndDrop = true;
            //tabControl.AllowDrop = true;
            this.Controls.Add(tabControl);

        }

        private void OnSelectedIndexChanged(object? sender, EventArgs e)
        {
            RefreshDocs();
        }

        private void OnDocumentTabAdded(object? sender, ControlEventArgs e)
        {
            RefreshDocs();
        }

        private void RefreshDocs()
        {
            List<Document> docs = new List<Document>();
            DocumentTabs = tabControl.DocumentTabs.ToArray();

            foreach (DocumentTab doc in DocumentTabs)
                docs.Add(doc.Document);

            Documents = docs.ToArray();
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
            newItem =           new ToolStripMenuItem("New File");              newItem.Click +=            OnNewPressed;

            contextMenu = new ContextMenuStrip();
            //contextMenu.Items.AddRange(new ToolStripMenuItem[] { closeItem, closeAllItem, closeAllButThis, new ToolStripSeparator(), newItem });
            contextMenu.Items.AddRange(new ToolStripItem[] { closeItem, closeAllItem, closeAllButThis, new ToolStripSeparator(), newItem });

            tabControl.ContextMenuStrip = contextMenu;
            tabControl.ContextMenuStrip.ForeColor = Color.Silver;
            tabControl.ContextMenuStrip.Renderer =  new VampirioCode.UI.VampGraphics.ToolStripRendererVamp();
        }

        public DocumentTab NewDocument()
        {
            DocumentTab docTab = null;
            Document doc = Document.NewTemporal();
            
            if (doc != null)
            {
                docTab = DocumentTab.Create(doc);
                tabControl.TabPages.Add(docTab);
                SelectTab(docTab);
            }

            return docTab;
        }

        public Document OpenDocument(string path)
        {
            DocumentTab docTab = null;
            Document doc = Document.Load(path);
            
            if (doc != null)
            {
                docTab = DocumentTab.Create(doc);
                tabControl.TabPages.Add(docTab);
                SelectTab(docTab);
            }

            return doc;
        }

        public void Close()
        {
            CloseDocument(CurrDocument);
        }

        private void CloseDocumentAt(int index) 
        {
            //Document doc = Documents[index];
            SelectTabAt(index);
            Document doc = CurrDocument;
            int newIndex = index > 0 ? (index - 1) : 0;
            bool saved;


            if (doc.Modified)
            {
                var result = MsgBox.Show("File modified", "Save changes to '" + doc.FileName + "'?", "Save", "Don't Save", "Cancel", DialogIcon.Question);

                if (result == OptionResult.OptionA) // Save
                {
                    saved = Save();
                    if (!saved)
                        return;
                }
                else if (result == OptionResult.OptionB) // Don't Save
                {
                    if (doc.IsTemporal)
                        Document.Delete(doc);
                }
                else if (result == OptionResult.OptionC) // Cancel
                {
                    return;
                }
            }
            else if(CurrDocument.IsTemporal)
            {
                var result = MsgBox.Show("Temporal file", "Save temporal file '" + doc.FileName + "'?", "Save", "Don't Save", "Cancel", DialogIcon.Question);

                if (result == OptionResult.OptionA) // Save
                {
                    saved = Save();
                    if (!saved)
                        return;
                }
                else if (result == OptionResult.OptionB) // Don't Save
                {
                    Document.Delete(doc);
                }
                else if (result == OptionResult.OptionC) // Cancel
                {
                    return;
                }
            }


            if (Documents.Length > 0)
                SelectTabAt(newIndex);
            else
                NewDocument();

            tabControl.TabPages.RemoveAt(index);
            RefreshDocs();
        }

        private void CloseDocument(Document document)
        {
            CloseDocumentAt(DocToIndex(document));
        }

        public bool Save()
        {
            if (CurrDocument.IsTemporal)
                return SaveAs();
            else
                return CurrDocument.Save();
        }

        public bool SaveAs()
        {
            String text;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title =      "Save file as";
            dialog.Filter =     "All Files (*.*)|*.*|Text Files (*.txt)|*.txt";
            dialog.FilterIndex = 1; // set first index

            dialog.ShowDialog();
            string newFilePath = dialog.FileName;


            if (newFilePath != "")
            {
                if (CurrDocument.IsTemporal)
                {
                    try
                    {
                        text = CurrDocument.Text;
                        File.Move(CurrDocument.FullFilePath, newFilePath);
                        CurrDocument.CopyFrom(Document.Load(newFilePath));
                        CurrDocument.Text = text;
                        CurrDocument.Save();
                        return true;
                    }
                    catch (Exception e)
                    {
                        MsgBox.Error("Can't save temporal file: '" + CurrDocument.FullFilePath + "' to '" + newFilePath + "'", e);
                        return false;
                    }
                }
                else
                {
                    try
                    {
                        text = CurrDocument.Text;
                        File.Delete(CurrDocument.FullFilePath);
                        CurrDocument.CopyFrom(Document.Load(newFilePath));
                        CurrDocument.Text = text;
                        CurrDocument.Save();
                        return true;
                    }
                    catch (Exception e)
                    {
                        MsgBox.Error("Can't save file: '" + CurrDocument.FullFilePath + "' to '" + newFilePath + "'", e);
                        return false;
                    }
                }
            }
            else
                return false;
        }

        public void SelectTab(DocumentTab docTab)
        { 
            if(docTab != null)
                tabControl.SelectTab(docTab);
        }

        public void SelectTabAt(int index)
        {
            if(index > -1)
                tabControl.SelectTab(index);
        }

        public int DocToIndex(Document document)
        {
            return Documents.ToList().IndexOf(document);
        }

        private void OnCloseTabPressed(object sender, EventArgs e)
        {
            CloseDocument(CurrDocument);
        }

        private void OnCloseAllPressed(object sender, EventArgs e)
        {

        }

        private void OnCloseAllButThisPressed(object sender, EventArgs e)
        {

        }

        private void OnNewPressed(object sender, EventArgs e)
        {
            NewDocument();
        }
    }

    
}
