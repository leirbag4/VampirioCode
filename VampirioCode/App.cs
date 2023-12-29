using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VampDocManager;
using VampirioCode.SaveData;
using VampirioCode.UI;
using VampirioCode.Utils;

namespace VampirioCode
{
    public partial class App : Form
    {
        public Document CurrDocument { get { return docManager.CurrDocument; } }
        public DocumentTab CurrDocumentTab { get { return docManager.CurrDocumentTab; } }

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
            HotKeyManager.AddHotKey(CloseDoc,       Keys.Control | Keys.C);
            HotKeyManager.AddHotKey(Find,           Keys.Control | Keys.F);
            HotKeyManager.AddHotKey(FindAndReplace, Keys.Control | Keys.H);
            HotKeyManager.AddHotKey(Save,           Keys.Control | Keys.S);
            HotKeyManager.AddHotKey(GoTo,           Keys.Control | Keys.G);
            HotKeyManager.AddHotKey(Duplicate,      Keys.Control | Keys.D);
            //HotKeyManager.AddHotKey(Function,       Keys.Control | Keys.P);
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
            //docManager.Documents
        }

        private void CloseDoc()
        { 
        
        }

        private void CloseAll()
        { 
        
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
                docManager.CurrentTabIndex = Config.LastSelectedTabIndex;
        }

        protected override void OnClosing(CancelEventArgs e)
        {

            Document[] docs = docManager.Documents;
            SavedDocument[] savedDocs = new SavedDocument[docs.Length];
            List<Document> docsToSave = new List<Document>();
            String docsToSaveNames = "\n\n";
            int maxItemsToShow = 5;

            for(int a = 0; a < savedDocs.Length; a++)
            {
                Document doc = docs[a];

                // If document was created with this app and was never saved, it lives inside 
                // a temporal folder. So it must be saved always there to hold the input text before close.
                // When a user tries to save it using [control+s or file/save], the file will be removed from
                // temporal and also the 'IsTemporal' will be set to false;
                if (doc.Modified)
                {
                    if (doc.IsTemporal)
                        doc.Save();
                    else
                    {
                        docsToSave.Add(doc);

                        if (docsToSave.Count == maxItemsToShow)    
                            docsToSaveNames += "   ...";
                        else if (docsToSave.Count > maxItemsToShow) {}
                        else                                            
                            docsToSaveNames += "   " + doc.FileName + "\n";
                    }
                }

                savedDocs[a] = new SavedDocument() { FullFilePath = doc.FullFilePath, IsTemporal = doc.IsTemporal };
            }

            if (docsToSave.Count > 0)
            {
                OptionResult option = MsgBox.Show("Save files?", "Save changes to files: " + docsToSaveNames, "Save", "Don't Save", "Cancel");

                if (option == OptionResult.None)
                    return;
                else if (option == OptionResult.OptionA) // Save
                {
                    foreach (var doc in docs) doc.Save();
                }
                else if (option == OptionResult.OptionB) // Don't Save
                { }
                else if (option == OptionResult.OptionC) // Cancel
                {
                    e.Cancel = true;
                    return;
                }
            }

            Config.LastOpenDocuments =      savedDocs;
            Config.LastSelectedTabIndex =   docManager.CurrentTabIndex;
            Config.Save();

            base.OnClosing(e);
        }
    }
}
