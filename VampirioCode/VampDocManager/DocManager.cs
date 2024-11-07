using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampEditor;
using VampirioCode;
using VampirioCode.Builder.Utils;
using VampirioCode.IO;
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
        public delegate void CurrDocumentTextChangedEvent(Document doc);
        public delegate void CurrDocumentModifiedChangedEvent(Document doc);

        public event DocumentCreatedEvent DocumentCreated;
        public event DocumentRemovedEvent DocumentRemoved;
        public event CurrDocumentTabChangedEvent CurrDocumentTabChanged;
        public event EditorContextItemPressedEvent EditorContextItemPressed;
        public event CurrDocumentTextChangedEvent CurrDocumentTextChanged;
        public event CurrDocumentModifiedChangedEvent CurrDocumentModifiedChanged;

        public DocumentTab CurrDocumentTab { get { return (DocumentTab)tabPanel.SelectedTab; } }
        public Document CurrDocument { get { return CurrDocumentTab.Document; } }
        public DocumentTab[] DocumentTabs { get; set; } = new DocumentTab[0];
        public Document[] Documents { get; set; } = new Document[0];
        public int CurrIndex { get { return tabPanel.SelectedIndex; } set { tabPanel.SelectedIndex = value; } }
        public int Totals { get { return Documents.Length; } }

        // controls
        private TabPanel tabPanel;
        ToolTipAdv toolTipPath;

        // others
        DocumentTab prevDocumentTab = null;

        // context menu
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem closeItem;
        private ToolStripMenuItem closeAllItem;
        private ToolStripMenuItem closeAllButThis;
        private ToolStripMenuItem newItem;

        public DocManager()
        {
            Color tabColor = CColor(139, 70, 166); // CColor(170, 60, 85);

            tabPanel =      new TabPanel();
            toolTipPath =   new ToolTipAdv();

            SetTheme(Theme.DarkMiddleRound);


            tabPanel.ControlAdded +=            OnDocumentTabAdded;
            tabPanel.SelectedTabChanged +=      OnSelectedIndexChanged;
            tabPanel.TabIndexPositionChanged += OnTabIndexPositionChanged;
            tabPanel.OverTabElapsedTime +=      OnOverTabElapsedTime;
            tabPanel.OverTabChanged +=          OnOverTabChanged;
            tabPanel.CloseTabInvoked +=         OnCloseButtonPressed;
            CreateContextItems();

            //tabControl.DragAndDrop = true;
            //tabControl.AllowDrop = true;
            this.Controls.Add(tabPanel);
        }

        private void OnOverTabChanged(int index, TabItem item)
        {
            if (item == null)
                toolTipPath.Hide(this);
        }

        public void SetTheme(Theme theme)
        {
            //
            // DarkRect
            //
            if (theme == Theme.DarkRect)
            {
                tabPanel.TabBarHeight = 28;
                tabPanel.Dock =                         DockStyle.Fill;
                tabPanel.BackColor =                    Color.FromArgb(30, 30, 30);


                tabPanel.SetSkin(TabSkin.DarkRectWClose);
                tabPanel.TabBar.BackColor =           CColor(30, 30, 30);
            
                tabPanel.SelectedStyle.BackColor =    CColor(139, 70, 166);
                tabPanel.SelectedStyle.BorderColor =  CColor(139, 70, 166);
                tabPanel.SelectedStyle.TextColor =    Color.White;

                tabPanel.NormalStyle.BackColor =      CColor(39, 40, 34);
                tabPanel.NormalStyle.TextColor =      Color.White;

                tabPanel.OverStyle.BackColor =        CColor(44, 45, 39);
                tabPanel.OverStyle.TextColor =        Color.White;

                tabPanel.SubButtonsBorderSize = 0;
                tabPanel.SubButtonsSelectedStyle.BackColor =      CColor(139, 70, 166);
                tabPanel.SubButtonsSelectedOverStyle.BackColor =  CColor(116, 53, 137);
                tabPanel.SubButtonsNormalStyle.BackColor =        CColor(39, 40, 34);
                tabPanel.SubButtonsOverStyle.BackColor =          CColor(59, 60, 54);
                tabPanel.SubButtonsParentOverStyle.BackColor =    CColor(44, 45, 39);

                tabPanel.TabBorderSize = 1;

                tabPanel.ArrowButtonNormalStyle =   new TabArrowButtonStyle(CColor(40), CColor(30), CColor(60));
                tabPanel.ArrowButtonOverStyle =     new TabArrowButtonStyle(CColor(45), CColor(35), CColor(65));
                tabPanel.ArrowButtonDownStyle =     new TabArrowButtonStyle(CColor(50), CColor(40), CColor(70));

                tabPanel.SplitBarColor =      Color.FromArgb(139, 70, 166);
                tabPanel.SplitBarSize =       2;
                tabPanel.SplitBarVisible =    true;
            }

            //
            // DarkMiddleRound
            //
            else if (theme == Theme.DarkMiddleRound)
            { 

                tabPanel.TabBarHeight = 28;
                tabPanel.Dock =                   DockStyle.Fill;
                tabPanel.BackColor =              Color.FromArgb(30, 30, 30);


                tabPanel.SetSkin(TabSkin.DarkMiddleRoundWClose);
                tabPanel.TabBar.BackColor =           CColor(30, 30, 30);
            
                tabPanel.SelectedStyle.BackColor =    CColor(139, 70, 166);
                tabPanel.SelectedStyle.BorderColor =  CColor(139, 70, 166);
                tabPanel.SelectedStyle.TextColor =    Color.White;

                tabPanel.NormalStyle.BackColor =      CColor(39, 40, 34);
                tabPanel.NormalStyle.TextColor =      Color.White;

                tabPanel.OverStyle.BackColor =        CColor(44, 45, 39);
                tabPanel.OverStyle.TextColor =        Color.White;

                tabPanel.SubButtonsBorderSize = 0;
                tabPanel.SubButtonsSelectedStyle.BackColor =      CColor(139, 70, 166);
                tabPanel.SubButtonsSelectedOverStyle.BackColor =  CColor(116, 53, 137);
                tabPanel.SubButtonsNormalStyle.BackColor =        CColor(39, 40, 34);
                tabPanel.SubButtonsOverStyle.BackColor =          CColor(59, 60, 54);
                tabPanel.SubButtonsParentOverStyle.BackColor =    CColor(44, 45, 39);

                tabPanel.TabBorderSize = 1;

                tabPanel.ArrowButtonNormalStyle =   new TabArrowButtonStyle(CColor(40), CColor(30), CColor(60));
                tabPanel.ArrowButtonOverStyle =     new TabArrowButtonStyle(CColor(45), CColor(35), CColor(65));
                tabPanel.ArrowButtonDownStyle =     new TabArrowButtonStyle(CColor(50), CColor(40), CColor(70));

                tabPanel.SplitBarColor =      Color.FromArgb(139, 70, 166);
                tabPanel.SplitBarSize =       2;
                tabPanel.SplitBarVisible =    true;

                tabPanel.TabBorderSize = 0;
            }
        }

        private void OnSelectedIndexChanged(int index, TabItem item)
        {
            RefreshDocs();

            
            // Events
            if (index == -1)
            {
                if (CurrDocumentTabChanged != null)
                    CurrDocumentTabChanged(-1, null);
            }
            else
            {
                if (CurrDocumentTabChanged != null)
                    CurrDocumentTabChanged(CurrIndex, CurrDocument);


                // Remove events from previous tab       (not left tab)
                if (prevDocumentTab != null)
                {
                    prevDocumentTab.TextChanged -=      OnCurrDocumentTextChanged;
                    prevDocumentTab.ModifiedChanged -=  OnCurrDocumentModifiedChanged;
                }

                // Add this events only for current document
                CurrDocumentTab.TextChanged +=      OnCurrDocumentTextChanged;
                CurrDocumentTab.ModifiedChanged +=  OnCurrDocumentModifiedChanged;

                prevDocumentTab = CurrDocumentTab;

                // Focus to the editor to gain user control
                CurrDocumentTab.Editor.Focus();
            }
        }

        private void OnCurrDocumentTextChanged(Document document)
        {
            if (CurrDocumentTextChanged != null)
                CurrDocumentTextChanged(document);
        }

        private void OnCurrDocumentModifiedChanged(Document document)
        {
            if (CurrDocumentModifiedChanged != null)
                CurrDocumentModifiedChanged(document);
        }

        private void OnTabIndexPositionChanged(int oldIndex, int newIndex)
        {
            RefreshDocs();
        }

        private void OnOverTabElapsedTime(int index, TabItem item, int positionX)
        {
            DocumentTab doc = (DocumentTab)item;
            string outPath;

            if (doc.Document.IsTemporary)
                outPath = doc.Document.FileName;
            else
                outPath = doc.Document.FullFilePath;

            toolTipPath.Hide(this);
            toolTipPath.Show(outPath, this, positionX < 0 ? 0 : positionX + 10, tabPanel.TabBarHeight);
        }

        private void OnDocumentTabAdded(object? sender, ControlEventArgs e)
        {
            RefreshDocs();
        }

        private void OnCloseButtonPressed(int index, TabItem item)
        {
            CloseDocumentAt(index);
        }

        private void RefreshDocs()
        {
            List<Document> docs = new List<Document>();
            DocumentTabs = tabPanel.GetItems<DocumentTab>();

            foreach (DocumentTab doc in DocumentTabs)
                docs.Add(doc.Document);

            Documents = docs.ToArray();
        }

        private static Color CColor(int red, int green, int blue)
        {
            return Color.FromArgb(red, green, blue);
        }

        private static Color CColor(int rgb)
        {
            return Color.FromArgb(rgb, rgb, rgb);
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

            tabPanel.ContextMenuStrip = contextMenu;
            tabPanel.ContextMenuStrip.ForeColor = Color.Silver;
            tabPanel.ContextMenuStrip.Renderer =  new VampirioCode.UI.VampGraphics.ToolStripRendererVamp();
        }

        private DocumentTab CreateDocument(Document doc)
        {
            DocumentTab docTab =            DocumentTab.Create(doc);
            docTab.ContextItemPressed +=    OnContextItemPressed;
            tabPanel.Add(docTab);
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
                    {
                        doc.DocType =       settings.DocType;
                        doc.BuilderType =   settings.BuilderType;
                        doc.CustomBuild =   settings.Custom;
                    }
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
            tabPanel.Repaint(); // fix issue when message box is called and stop drawing

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

                    BuilderUtils.DeleteProject(doc);
                }
                else if ((result == OptionResult.OptionC) || (result == OptionResult.None)) // Cancel
                {
                    return false;
                }
            }
            else if (CurrDocument.IsTemporary)
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
                        BuilderUtils.DeleteProject(doc);
                    }
                    else if ((result == OptionResult.OptionC) || (result == OptionResult.None)) // Cancel
                    {
                        return false;
                    }
                }
            }
            // Is a UserFile with a custom name like c:\\tests\\testermon.cpp
            else
            {
                BuilderUtils.DeleteProject(doc);
            }



            // Removed Event
            CloseMode closeMode =   CloseMode.Normal;
            if (saved && deleted)   throw new Exception("Can't save and delete a document at the same time. Check for bug here");
            else if (saved)         closeMode = CloseMode.Saved;
            else if (deleted)       closeMode = CloseMode.Deleted;

            if (DocumentRemoved != null)
                DocumentRemoved(Documents[index], DocumentTabs[index], closeMode);

            // Remove from tabs
            tabPanel.RemoveAt(index);

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
            
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title =      "Save file as";
            dialog.Filter =     "All Files (*.*)|*.*|Text Files (*.txt)|*.txt";
            dialog.FilterIndex = 1; // set first index

            dialog.ShowDialog();
            string newFilePath = dialog.FileName;

            if (newFilePath != "")
            {
                ResultInfo info = CurrDocument.Move(newFilePath);

                if (info.IsOk)
                {
                    return true;
                }
                else //if (info.HasErrors)
                {
                    MsgBox.Error(info.ErrorInfo.Message, info.ErrorInfo.Exception);
                    return true;
                }
            }
            else
                return false;

            /*String text;
             
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
                        File.WriteAllText(newFilePath, "");
                        text = CurrDocument.Text;
                        //File.Delete(CurrDocument.FullFilePath);
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
                return false;*/
        }

        public void SelectTab(DocumentTab docTab)
        { 
            if(docTab != null)
                tabPanel.SelectTab(docTab, true);
        }

        public void SelectTabAt(int index)
        {
            if(index > -1)
                tabPanel.SelectTab(index, true);
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
