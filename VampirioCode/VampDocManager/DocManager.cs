using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampEditor;
using VampirioCode.UI;
using VampirioCode.UI.Controls;
using VampirioCode.UI.Controls.TabManagement;
using VampirioCode.UI.Style;
using VampirioCode.Utils;

namespace VampDocManager
{
    public enum CreateMode
    { 
        NewDocument,
        OpenDocument
    }

    public enum CloseMode
    { 
        Normal,
        Deleted,
        Saved
    }

    public class DocManager : UserControl
    {

        public delegate void DocumentCreatedEvent(Document document, DocumentTab documentTab, CreateMode mode);
        public delegate void DocumentRemovedEvent(Document document, DocumentTab documentTab, CloseMode mode);
        public delegate void CurrDocumentTabChangedEvent(int index, Document doc);
        public delegate void EditorContextItemPressedEvent(EditorEventType eventType, Document document);

        public event DocumentCreatedEvent DocumentCreated;
        public event DocumentRemovedEvent DocumentRemoved;
        public event CurrDocumentTabChangedEvent CurrDocumentTabChanged;
        public event EditorContextItemPressedEvent EditorContextItemPressed;

        public DocumentTab CurrDocumentTab { get { return (DocumentTab)tabControl.SelectedTab; } }
        public Document CurrDocument { get { return CurrDocumentTab.Document; } }
        public DocumentTab[] DocumentTabs { get; set; } = new DocumentTab[0];
        public Document[] Documents { get; set; } = new Document[0];
        public int CurrIndex { get { return tabControl.SelectedIndex; } set { tabControl.SelectedIndex = value; } }
        public int Totals { get { return Documents.Length; } }

        // controls
        //private TabControlVamp tabControl;
        private TabPanel tabControl;
        private Control horizontalBar;

        // context menu
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem closeItem;
        private ToolStripMenuItem closeAllItem;
        private ToolStripMenuItem closeAllButThis;
        private ToolStripMenuItem newItem;

        public DocManager()
        {
            Color tabColor = CColor(139, 70, 166); // CColor(170, 60, 85);

            tabControl = new TabPanel();
            tabControl.Dock =                   DockStyle.Fill;
            tabControl.BackColor =              Color.FromArgb(30, 30, 30);
            //tabControl.Margin =                 new Padding(0);
            //tabControl.Padding =                new Point(0, 0);
            //tabControl.SetSkin(25, CColor(30, 30, 30), CColor(39, 40, 34), tabColor, CColor(52, 53, 45) , CColor(255, 255, 255));
            tabControl.ControlAdded +=          OnDocumentTabAdded;
            //tabControl.SelectedIndexChanged +=  OnSelectedIndexChanged;
            tabControl.SelectedTabChanged +=    OnSelectedIndexChanged;
            CreateContextItems();

            //tabControl.DragAndDrop = true;
            //tabControl.AllowDrop = true;
            this.Controls.Add(tabControl);

            horizontalBar = new Control();
            horizontalBar.BackColor =   tabColor;
            horizontalBar.Size =        new Size(this.Width - 6, 2);
            horizontalBar.Dock =        DockStyle.Left;
            horizontalBar.Anchor =      AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            horizontalBar.Location =    new Point(2, 27);

           // horizontalBar.Dock = DockStyle.Fill;

            this.Controls.Add(horizontalBar);

            horizontalBar.BringToFront();
        }

        //private void OnSelectedIndexChanged(object? sender, EventArgs e)
        private void OnSelectedIndexChanged(int index, TabItem item)
        {
            RefreshDocs();

            // Focus to the editor to gain user control
            //CurrDocumentTab.Editor.Focus();

            // Events
            if (CurrDocumentTabChanged != null)
                CurrDocumentTabChanged(CurrIndex, CurrDocument);
        }

        private void OnDocumentTabAdded(object? sender, ControlEventArgs e)
        {
            RefreshDocs();
        }

        private void RefreshDocs()
        {
            List<Document> docs = new List<Document>();
            //DocumentTabs = tabControl.DocumentTabs.ToArray();
            DocumentTabs = tabControl.GetItems<DocumentTab>();

            foreach (DocumentTab doc in DocumentTabs)
                docs.Add(doc.Document);

            Documents = docs.ToArray();
        }

        private static Color CColor(int red, int green, int blue)
        {
            return Color.FromArgb(red, green, blue);
        }

        private static Color CColor(int all)
        {
            return Color.FromArgb(all, all, all);
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

        private DocumentTab CreateDocument(Document doc)
        {
            DocumentTab docTab =            DocumentTab.Create(doc);
            docTab.ContextItemPressed +=    OnContextItemPressed;
            //tabControl.TabPages.Add(docTab);
            tabControl.Add(docTab);
            SelectTab(docTab);
            return docTab;
        }

        public DocumentTab NewDocument()
        {
            DocumentTab docTab = null;
            Document doc = Document.NewTemporary();

            if (doc != null)
            {
                docTab = CreateDocument(doc);
                if (DocumentCreated != null)
                    DocumentCreated(doc, docTab, CreateMode.NewDocument);
            }

            return docTab;
        }

        public Document OpenDocument(string path)
        {
            return OpenDocument(path, null);
        }

        public Document OpenDocument(string path, DocumentSettings settings = null)
        {
            DocumentTab docTab = null;
            Document doc = Document.Load(path);
            
            if (doc != null)
            {
                // Extra settings for the document that can be stored on a different file or project file
                if (settings != null)
                {
                    // if document type is 'OTHER', the Document.Load() method has automatically setted the document type
                    // And if Document.Load() can't find one, OTHER will be leave it here anyway
                    if (settings.DocType != DocumentType.OTHER)
                        doc.DocType = settings.DocType;
                }

                docTab = CreateDocument(doc);
                if (DocumentCreated != null)
                    DocumentCreated(doc, docTab, CreateMode.OpenDocument);
            }

            return doc;
        }

        private void OnContextItemPressed(VampEditor.EditorEventType eventType, Document document)
        {
            if (EditorContextItemPressed != null)
                EditorContextItemPressed(eventType, document);
        }

        public void Close()
        {
            CloseDocument(CurrDocument);
        }

        public void CloseAll()
        {
            List<Document> modifiedDocs =   Documents.OrderByDescending(doc => (doc.Modified || doc.IsTemporary)).
                                                      OrderByDescending(doc => doc.IsTemporary).ToList();

            foreach (var doc in modifiedDocs)
            {
                if (!CloseDocument(doc))
                    return;
            }

            //NewDocument();
        }
        private bool CloseDocument(Document document)
        {
            return CloseDocumentAt(DocToIndex(document));
        }

        // returns 'false' only if user press 'cancel' or 'escape'
        private bool CloseDocumentAt(int index) 
        {
            //Document doc = Documents[index];
            SelectTabAt(index);
            Document doc =  CurrDocument;
            int newIndex =  index > 0 ? (index - 1) : 0;
            bool saved =    false;
            bool deleted =  false;


            if (doc.Modified)
            {
                var result = MsgBox.Show("File modified", "Save changes to '" + doc.FileName + "'?", "Save", "Don't Save", "Cancel", DialogIcon.Question);

                if (result == OptionResult.OptionA) // Save
                {
                    saved = Save();
                    if (!saved)
                        return true;
                }
                else if (result == OptionResult.OptionB) // Don't Save
                {
                    if (doc.IsTemporary)
                        deleted = Document.Delete(doc);
                }
                else if ((result == OptionResult.OptionC) || (result == OptionResult.None)) // Cancel
                {
                    return false;
                }
            }
            else if(CurrDocument.IsTemporary)
            {
                // Doc is empty. User never write anything
                if (CurrDocument.Text == "")
                {
                    deleted = Document.Delete(doc);
                }
                else
                {
                    var result = MsgBox.Show("Temporary file", "Save temporary file '" + doc.FileName + "'?", "Save", "Don't Save", "Cancel", DialogIcon.Question);

                    if (result == OptionResult.OptionA) // Save
                    {
                        saved = Save();
                        if (!saved)
                            return true;
                    }
                    else if (result == OptionResult.OptionB) // Don't Save
                    {
                        deleted = Document.Delete(doc);
                    }
                    else if ((result == OptionResult.OptionC) || (result == OptionResult.None)) // Cancel
                    {
                        return false;
                    }
                }
            }

            // Removed Event
            CloseMode closeMode =   CloseMode.Normal;
            if (saved && deleted)   throw new Exception("Can't save and delete a document at the same time. Check for bug here");
            else if (saved)         closeMode = CloseMode.Saved;
            else if (deleted)       closeMode = CloseMode.Deleted;

            if (DocumentRemoved != null)
                DocumentRemoved(Documents[index], DocumentTabs[index], closeMode);


            // Remove from tabs
            //tabControl.TabPages.RemoveAt(index);
            tabControl.RemoveAt(index);
            RefreshDocs();

            if (Documents.Length > 0)
                SelectTabAt(newIndex);
            else
                NewDocument();

            return true;
        }

        public bool Save()
        {
            if (CurrDocument.IsTemporary)
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
                if (CurrDocument.IsTemporary)
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
                        MsgBox.Error("Can't save temporary file: '" + CurrDocument.FullFilePath + "' to '" + newFilePath + "'", e);
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
            CloseAll();
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
