using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VampDocManager;
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

        private Dotnet dotnet;
        public App()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            Config.Initialize();
            MsgBox.Setup(this);
            RegisterCmdKeys();

            menuStrip.Renderer = new VampirioCode.UI.VampGraphics.MenuStripRenderer();
            menuStrip.BackColor = Color.FromArgb(30, 30, 30);
            menuStrip.ForeColor = Color.Silver;

            OpenLastDocuments();


            dotnet = new Dotnet();

            base.OnLoad(e);
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
            HotKeyManager.AddHotKey(Build,          Keys.F4);
            HotKeyManager.AddHotKey(BuildAndRun,    Keys.F5);
            //HotKeyManager.AddHotKey(Function,       Keys.Control | Keys.P);
        }

        private async void Build()
        {
            var result = await dotnet.BuildAsync(@"C:\dotnet_test\projects\Capitan");
        }

        private async void BuildAndRun()
        {
            var result = await dotnet.NewAsync("console", @"C:\dotnet_test\projects\Patasucia3", "");
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
            XConsole.Alert("find");
        }

        private void FindAndReplace()
        {
            XConsole.Alert("find and replace");
        }

        private void GoTo()
        {
            XConsole.Alert("goto");
        }

        private void Duplicate()
        {
            XConsole.Alert("duplicate");
        }

        private void OpenLastDocuments()
        {
            SavedDocument[] docs = Config.LastOpenDocuments;
            
            foreach (SavedDocument doc in docs) 
            {
                docManager.OpenDocument(doc.FullFilePath);
            }

            if(Config.LastSelectedTabIndex < docManager.Documents.Length)
                docManager.CurrIndex = Config.LastSelectedTabIndex;

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

        protected override void OnClosing(CancelEventArgs e)
        {

            Document[] docs = docManager.Documents;
            SavedDocument[] lastOpenDocs = new SavedDocument[docs.Length];
            List<Document> docsToSave = new List<Document>();
            String docsToSaveNames = "\n\n";
            int maxItemsToShow = 5;

            for(int a = 0; a < docs.Length; a++)
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
                             if (docsToSave.Count == maxItemsToShow)    docsToSaveNames += "   ...";
                        else if (docsToSave.Count > maxItemsToShow)     {}
                        else                                            docsToSaveNames += "   " + doc.FileName + "\n";
                    }
                }

                lastOpenDocs[a] = new SavedDocument() { FullFilePath = doc.FullFilePath, IsTemporary = doc.IsTemporary };
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

            Config.LastOpenDocuments =      lastOpenDocs;
            Config.LastSelectedTabIndex =   docManager.CurrIndex;
            Config.Save();

            base.OnClosing(e);
        }
    }
}
