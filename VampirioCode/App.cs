using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VampDocManager;
using VampEditor;
using VampirioCode.Builder;
using VampirioCode.Command;
using VampirioCode.Command.Dotnet;
using VampirioCode.SaveData;
using VampirioCode.UI;
using VampirioCode.Utils;

namespace VampirioCode
{
    public partial class App : Form
    {
        public Document CurrDocument { get { return docManager.CurrDocument; } }
        public DocumentTab CurrDocumentTab { get { return docManager.CurrDocumentTab; } }
        public VampirioEditor CurrEditor { get { return docManager.CurrDocumentTab.Editor; } }

        private Dotnet dotnet;

        private Control screenLock;

        public App()
        {
            //DoubleBuffered = true;

            InitializeComponent();
            CreateScreenLock();
        }

        protected override void OnLoad(EventArgs e)
        {
            Config.Initialize();
            MsgBox.Setup(this);
            XConsole.Setup(footer);
            Builders.Initialize();
            RegisterCmdKeys();

            // theme
            menuStrip.Renderer = new VampirioCode.UI.VampGraphics.MenuStripRenderer();
            menuStrip.BackColor = Color.FromArgb(30, 30, 30);
            menuStrip.ForeColor = Color.Silver;

            // doc manager events
            docManager.CurrDocumentTabChanged +=    OnCurrDocumentTabChanged;
            docManager.EditorContextItemPressed +=  OnEditorContextItemPressed;
            docManager.DocumentCreated +=           OnDocumentCreated;
            docManager.DocumentRemoved +=           OnDocumentRemoved;

            // tool bar events
            toolBar.StartPressed +=     OnStartPressed;
            toolBar.ReloadPressed +=    OnReloadPressed;

            // drag and drop
            this.AllowDrop =    true;
            this.DragEnter +=   OnDragEnter;
            this.DragDrop +=    OnDragDrop;


            // open last documents
            OpenLastDocuments();

            // start builders
            dotnet =            new Dotnet();

            FillBuilderItems();

            Reposition();

            // if there is no saved documents on config file because of an error
            // or if application opens for the first time and config.cfg didn't exist
            if (docManager.Documents.Length == 0)
                New();

            SelectBuilder(CurrDocument.DocType, CurrDocument.BuilderType);

            base.OnLoad(e);
        }

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);
            await DestroyScreenLock();
        }


        protected void Reposition()
        {
            // resize the window to the last size
            if (Config.Maximized)
            {
                if((Config.PosX != -1) && (Config.PosY != -1))
                    Location = new Point(Config.PosX, Config.PosY);

                WindowState =   FormWindowState.Maximized;
                this.Size =     new Size(Config.Width, Config.Height);
            }
            else
            {
                if ((Config.PosX != -1) && (Config.PosY != -1))
                    Location = new Point(Config.PosX, Config.PosY);

                this.Size = new Size(Config.Width, Config.Height);
            }

            // restore last selected document
            if (Config.LastSelectedTabIndex < docManager.Documents.Length)
                docManager.SelectTabAt(Config.LastSelectedTabIndex);

        }

        // An overlay dark control that prevent white flickerings at the start of the app
        private void CreateScreenLock()
        {
            screenLock = new Control();
            screenLock.BackColor = Color.FromArgb(30, 30, 30);
            screenLock.Dock = DockStyle.Fill;
            this.Controls.Add(screenLock);
            screenLock.BringToFront();
        }

        // Destroy the overlay
        private async Task DestroyScreenLock()
        {
            await Task.Delay(100); // timer delay

            Action lambdaFunction = () =>
            {
                this.Controls.Remove(screenLock);
            };

            lambdaFunction.Invoke();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keys)
        {
            if (HotKeyManager.ProcessKeys(keys))
                return true;
            else
                return base.ProcessCmdKey(ref msg, keys);
        }

        private void RegisterCmdKeys()
        {
            HotKeyManager.AddHotKey(New,            Keys.Control | Keys.N);
            HotKeyManager.AddHotKey(Open,           Keys.Control | Keys.O);
            HotKeyManager.AddHotKey(CloseDoc,       Keys.Control | Keys.W);
            HotKeyManager.AddHotKey(Find,           Keys.Control | Keys.F);
            HotKeyManager.AddHotKey(FindAndReplace, Keys.Control | Keys.H);
            HotKeyManager.AddHotKey(Save,           Keys.Control | Keys.S);
            HotKeyManager.AddHotKey(GoTo,           Keys.Control | Keys.G);
            HotKeyManager.AddHotKey(Duplicate,      Keys.Control | Keys.D);
            HotKeyManager.AddHotKey(BuildAndRun,    Keys.F5);
            HotKeyManager.AddHotKey(Build,          Keys.F6);
            HotKeyManager.AddHotKey(Undo,           Keys.Control | Keys.Z);
            HotKeyManager.AddHotKey(Redo,           Keys.Control | Keys.Shift | Keys.Z);
            HotKeyManager.AddHotKey(SaveAs,         Keys.Control | Keys.Shift | Keys.S);

            //HotKeyManager.AddHotKey(Function,     Keys.Control | Keys.P);
        }

        private void FillBuilderItems()
        {
            ToolStripMenuItem[] items = Builders.CreateMenuItems();

            foreach(ToolStripMenuItem item in items)
                item.Click += OnBuilderPressed;

            builderToolStripMenuItem.DropDownItems.Clear();
            builderToolStripMenuItem.DropDownItems.AddRange(items);
        }


        private async void Build()
        {
            XConsole.Clear();
            string projName = Path.GetFileNameWithoutExtension(CurrDocument.FullFilePath);

            if (CurrDocument.DocType == DocumentType.OTHER)
            {
                MsgBox.Show(this, "No language", "No language selected.\n\n    Please select a language from the top bar before compiling.");
            }
            else
            {
                Builder.Builder builder = Builders.GetBuilder(CurrDocument.BuilderType);
                builder.Setup(projName, CurrDocument.Text);
                await builder.Build();
            }
        }

        private async void BuildAndRun()
        {
            //var result = await dotnet.NewAsync("console", @"C:\dotnet_test\projects\Patasucia3", "");

            //var result = await dotnet.NewListAsyc();
            //XConsole.Println(result.ToString());

            //var result = await dotnet.NewSearchAsync("console");
            //XConsole.Println(result.ToString());

            //XConsole.Clear();
            //var result = await dotnet.RunAsync(@"C:\dotnet_test\projects\Capitan", new string[] { "malo", "--chipote" });

            XConsole.Clear();
            string projName = Path.GetFileNameWithoutExtension(CurrDocument.FullFilePath);

            if (CurrDocument.DocType == DocumentType.OTHER)
            {
                MsgBox.Show(this, "No language", "No language selected.\n\n    Please select a language from the top bar before compiling.");
            }
            else
            {
                Builder.Builder builder = Builders.GetBuilder(CurrDocument.BuilderType);
                builder.Setup(projName, CurrDocument.Text);
                await builder.BuildAndRun();
            }
        }

        private void OnFilePressed(object sender, EventArgs e)
        {
            string sel = (string)((ToolStripMenuItem)sender).Tag;

                 if (sel == "new")          New();
            else if (sel == "open")         Open();
            else if (sel == "save")         Save();
            else if (sel == "save_as")      SaveAs();
            else if (sel == "close")        CloseDoc();
            else if (sel == "close_all")    CloseAll();
            else if (sel == "exit")         Exit();
        }

        private void OnEditPressed(object sender, EventArgs e)
        {

        }

        private void OnEditorContextItemPressed(EditorEventType eventType, Document document)
        {
            if (eventType == VampEditor.EditorEventType.OpenFileLocation)
            { 
                Process.Start("explorer.exe", string.Format("/select,\"{0}\"", document.FullFilePath));
            }
            else if (eventType == VampEditor.EditorEventType.OpenOutputFilename)
            {
                if (CurrDocument.DocType == DocumentType.OTHER)
                {
                    MsgBox.Show(this, "Language not selected", "Language was not selected. This feature only works with a language. Select one from the top.");
                }
                else
                {
                    string projName = Path.GetFileNameWithoutExtension(CurrDocument.FullFilePath);

                    Builder.Builder builder = Builders.GetBuilder(CurrDocument.BuilderType);
                    builder.Setup(projName, CurrDocument.Text);
                    builder.Prepare();

                    if (builder.OutputFilename != "")
                    {
                        if (File.Exists(builder.OutputFilename))
                            Process.Start("explorer.exe", string.Format("/select,\"{0}\"", builder.OutputFilename));
                        else
                            MsgBox.Show(this, "File does not exist", "File '" + builder.OutputFilename + "' does not exist yet.\n\nCompile it first");
                    }
                    else
                        MsgBox.Show(this, "Not available", "The output file for this document is not available.\nIt may be an interpreted file extension that doesn't need a compilation process. Try opening the file path instead.");
                }
            }
        }

        private void OnLanguagePressed(object sender, EventArgs e)
        {
            DocumentType docType = DocumentType.OTHER;

                 if (sender == csharpToolStripMenuItem) docType = DocumentType.CSHARP;
            else if (sender == cppToolStripMenuItem)    docType = DocumentType.CPP;
            else if (sender == jsToolStripMenuItem)     docType = DocumentType.JS;
            else if (sender == phpToolStripMenuItem)    docType = DocumentType.PHP;

            if (CurrDocument.DocType != docType)
            {
                CurrDocument.DocType =      docType;
                CurrDocument.BuilderType =  Builders.GetDefaultTypeFor(docType);
                SelectLanguage(CurrDocument.DocType);
                SelectBuilder(CurrDocument.DocType, CurrDocument.BuilderType);

                // change language at editor (scintilla)
                CurrDocumentTab.Editor.SetLanguage(CurrDocument.DocType, VampEditor.StyleMode.Dark);
            }
        }

        private void OnBuilderPressed(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            CurrDocument.BuilderType = (BuilderType)item.Tag;
            SelectBuilder(CurrDocument.DocType, CurrDocument.BuilderType);
        }

        private void New()
        {
            docManager.NewDocument();
        }

        private void Open()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select a File";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = dialog.FileName.Trim();
                docManager.OpenDocument(filePath);
            }
        }

        private void Save()
        {
            docManager.Save();
        }

        private void SaveAs()
        {
            docManager.SaveAs();
        }

        private void CloseDoc()
        {
            docManager.Close();
        }

        private void CloseAll()
        {
            docManager.CloseAll();
        }

        private void Exit()
        {
            this.Close();
        }

        private void Find()
        {
            CurrDocumentTab.ShowFind();
        }

        private void FindAndReplace()
        {
            CurrDocumentTab.ShowFind(true);
        }

        private void GoTo()
        {
            XConsole.Alert("goto");
        }

        private void Duplicate()
        {
            XConsole.Alert("duplicate");
        }

        private void Undo()
        {
            CurrEditor.Undo();
        }

        private void Redo()
        {
            CurrEditor.Redo();
        }

        private void OpenLastDocuments()
        {
            SavedDocument[] docs = Config.LastOpenDocuments;

            foreach (SavedDocument doc in docs)
            {
                docManager.OpenDocument(doc.FullFilePath, doc.DocumentSettings);
            }

            

            //if(docManager.DocumentTabs.Length > 0)
            //    docManager.

            CleanUpTempFiles();
        }

        // Check which temporary files are not used at '\temp_files' folder.
        // Those that are not used are deleted
        private void CleanUpTempFiles()
        {
            string[] allTempFilesPath = FileUtils.GetFilesAt(AppInfo.TemporaryFilesPath);
            List<string> loadedTempFilesPath = new List<string>();

            foreach (var doc in docManager.Documents)
            {
                // group temporary files which are opened right now
                if (doc.IsTemporary)
                    loadedTempFilesPath.Add(doc.FullFilePath);
            }

            foreach (var tempFile in allTempFilesPath)
            {
                if (!loadedTempFilesPath.Contains(tempFile))
                {
                    File.Delete(tempFile);
                    XConsole.PrintWarning("old temporary file deleted: " + tempFile);
                }
            }
        }

        private void SelectLanguage(DocumentType docType)
        {
            ToolStripMenuItem[] items = new ToolStripMenuItem[] { csharpToolStripMenuItem, cppToolStripMenuItem, jsToolStripMenuItem, phpToolStripMenuItem };

            foreach (var item in items)
            {
                if (item.ForeColor != Color.Silver)
                    item.ForeColor = Color.Silver;
            }

                 if (docType == DocumentType.CSHARP)    csharpToolStripMenuItem.ForeColor = Color.SlateBlue;
            else if (docType == DocumentType.CPP)       cppToolStripMenuItem.ForeColor =    Color.SlateBlue;
            else if (docType == DocumentType.JS)        jsToolStripMenuItem.ForeColor =     Color.SlateBlue;
            else if (docType == DocumentType.PHP)       phpToolStripMenuItem.ForeColor =    Color.SlateBlue;

            footer.DocType = docType;
        }

        private void SelectBuilder(DocumentType docType, BuilderType selBuilderType)
        {
            BuilderType[] allowedBuilders = Builders.GetBuilderypesFor(docType);

            foreach (ToolStripMenuItem item in builderToolStripMenuItem.DropDownItems)
            {
                BuilderType buildType = (BuilderType)item.Tag;

                // selected
                if (buildType == selBuilderType)
                {
                    item.Visible = true;

                    if (item.ForeColor != Color.SlateBlue)
                        item.ForeColor = Color.SlateBlue;
                }
                // non selected items
                else
                {
                    String allow = "";
                    foreach (var al in allowedBuilders)
                        allow += al.ToString() + ", ";

                    //XConsole.Alert("docType: " + docType + "     allowed: " + allow + " buildType: " + buildType + " contain: " + allowedBuilders.Contains(buildType));
                    
                    // hide menu item if it doesn't belong to the language or docType
                    item.Visible = allowedBuilders.Contains(buildType);

                    if (item.ForeColor != Color.Silver)
                        item.ForeColor = Color.Silver;
                }
            }

            /*// first check if builders exists on toolstrip menu
            bool foundBuilder = false;

            foreach (ToolStripMenuItem builder in builderToolStripMenuItem.DropDownItems)
            {
                BuilderType buildType = (BuilderType)builder.Tag;
                if (buildType == selBuilderType)
                {
                    foundBuilder = true;
                    break;
                }
            }

            // if no builder item found on menu strip, we must add them all
            if (!foundBuilder)
            { 
                builderToolStripMenuItem.DropDownItems.Clear();
                builderToolStripMenuItem.DropDownItems.AddRange(Builders.CreateMenuItems(docType));
            }

            // select the item
            foreach (ToolStripMenuItem item in builderToolStripMenuItem.DropDownItems)
            {
                BuilderType buildType = (BuilderType)item.Tag;

                // selected
                if (buildType == selBuilderType)
                {
                    if (item.ForeColor != Color.SlateBlue)
                        item.ForeColor = Color.SlateBlue;
                }
                // non selected items
                else
                {
                    if (item.ForeColor != Color.Silver)
                        item.ForeColor = Color.Silver;
                }
            }


            //ToolStripMenuItem

            //builderToolStripMenuItem.DropDownItems[0].visi*/
        }

        /*private Builder.Builder GetSimpleBuilder(DocumentType docType)
        {
                 if (docType == DocumentType.CSHARP)    return csBuilder;
            else if (docType == DocumentType.CPP)       return cppBuilder;
            else if (docType == DocumentType.JS)        return jsBuilder;
            else if (docType == DocumentType.PHP)       return phpBuilder;
            return null;
        }*/

        private void OnCurrDocumentTabChanged(int index, Document doc)
        {
            if (doc != null)
            {
                SelectLanguage(doc.DocType);
                SelectBuilder(doc.DocType, doc.BuilderType);
            }
        }

        private void OnDocumentCreated(Document document, DocumentTab documentTab, CreateMode mode)
        {
            documentTab.Editor.PositionChanged += OnEditorPositionChanged;
        }

        private void OnDocumentRemoved(Document document, DocumentTab documentTab, CloseMode mode)
        {

        }

        private void OnEditorPositionChanged(VampirioEditor editor, int lineNumber, int columnNumber, int position)
        {
            footer.SetLineColumn(lineNumber, columnNumber);
        }

        //
        // Drag and Drop
        //
        private void OnDragEnter(object sender, DragEventArgs e)
        {
            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string filePath in filePaths)
            {
                if (!File.Exists(filePath))
                {
                    // there is an invalid item like a directory, so cancel operation
                    e.Effect = DragDropEffects.None;
                    return;
                }
            }

            // accept the OnDragDrop event
            e.Effect = DragDropEffects.Copy;
        }

        private void OnDragDrop(object sender, DragEventArgs e)
        {
            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string filePath in filePaths)
            {
                docManager.OpenDocument(filePath);
            }
        }

        //
        // On Closing
        //
        protected override void OnClosing(CancelEventArgs e)
        {

            Document[] docs = docManager.Documents;
            SavedDocument[] lastOpenDocs = new SavedDocument[docs.Length];
            List<Document> docsToSave = new List<Document>();
            String docsToSaveNames = "\n\n";
            int maxItemsToShow = 5;

            for (int a = 0; a < docs.Length; a++)
            {
                Document doc = docs[a];

                // If document was created with this app and was never saved, it lives inside 
                // a temporary folder. So it must be saved always there to hold the input text before close.
                // When a user tries to save it using [control+s or file/save], the file will be removed from
                // temporary and also the 'IsTemporary' will be set to false;
                if (doc.Modified)
                {
                    if (doc.IsTemporary)
                        doc.Save();
                    else
                    {
                        docsToSave.Add(doc);

                        // create msgbox string like 'file1, file2 ...'
                        if (docsToSave.Count == maxItemsToShow) docsToSaveNames += "   ...";
                        else if (docsToSave.Count > maxItemsToShow) { }
                        else docsToSaveNames += "   " + doc.FileName + "\n";
                    }
                }

                lastOpenDocs[a] = new SavedDocument()   { 
                                                            FullFilePath =  doc.FullFilePath, 
                                                            IsTemporary =   doc.IsTemporary,
                                                            DocumentSettings = new DocumentSettings() { DocType = doc.DocType, BuilderType = doc.BuilderType }
                                                        };
            }

            // There are modified open documents
            // Ask user if wants to save them
            if (docsToSave.Count > 0)
            {
                OptionResult option = MsgBox.Show("Save files?", "Save changes to files: " + docsToSaveNames, "Save", "Don't Save", "Cancel");

                if (option == OptionResult.OptionA) // Save
                {
                    foreach (var doc in docs) doc.Save();
                }
                else if (option == OptionResult.OptionB) // Don't Save
                { }
                else if ((option == OptionResult.OptionC) || (option == OptionResult.None)) // Cancel
                {
                    e.Cancel = true;
                    return;
                }
            }

            // Set last documents and last index
            Config.LastOpenDocuments =      lastOpenDocs;
            Config.LastSelectedTabIndex =   docManager.CurrIndex;

            // Store last window width and height
            //Config.Width =  RestoreBounds.Width; 
            //Config.Height = RestoreBounds.Height;

            if (WindowState == FormWindowState.Maximized)
            {
                //Properties.Settings.Default.Location = RestoreBounds.Location;
                Config.PosX =       RestoreBounds.X; 
                Config.PosY =       RestoreBounds.Y;
                Config.Width =      RestoreBounds.Width;
                Config.Height =     RestoreBounds.Height;
                Config.Maximized =  true;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                //Properties.Settings.Default.Location = Location;
                Config.PosX =       this.Location.X; 
                Config.PosY =       this.Location.Y;
                Config.Width =      this.Width;
                Config.Height =     this.Height;
                Config.Maximized =  false;
            }

            // Save config file
            Config.Save();

            // TODO: close all pending process but needs to view revied later
            //CmdRun.KillAllProcess_TODO_FIX();

            base.OnClosing(e);
        }

        private void OnStartPressed()
        {
            BuildAndRun();
        }
        private void OnReloadPressed()
        {
            Build();
        }

        private void OnClearPressed(object sender, EventArgs e)
        {
            XConsole.Clear();
        }

    }
}
