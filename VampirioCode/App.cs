using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VampDocManager;
using VampirioCode.SaveData;
using VampirioCode.UI;

namespace VampirioCode
{
    public partial class App : Form
    {
        private VampEditor.VampirioEditor editor2;

        public App()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            Config.Initialize();

            //tabControl.DrawMode = TabDrawMode.Normal;

            menuStrip.Renderer = new VampGraphics.MenuStripRenderer();
            menuStrip.BackColor = Color.FromArgb(30, 30, 30);
            menuStrip.ForeColor = Color.Silver;

            OpenLastDocuments();

            base.OnLoad(e);
        }

        private Color CColor(int red, int green, int blue)
        {
            return Color.FromArgb(red, green, blue);
        }

        private void OnFilePressed(object sender, EventArgs e)
        {
            string sel = (string)((ToolStripMenuItem)sender).Tag;

            if (sel == "new")
            {
                New();
            }
            else if (sel == "open")
            {
                Open();
            }
            else if (sel == "save")
            {
                Save();
            }
            else if (sel == "save_as")
            {
                SaveAs();
            }
            else if (sel == "close")
            {
                CloseDoc();
            }
            else if (sel == "close_all")
            {
                CloseAll();
            }
            else if (sel == "exit")
            {
                Exit();
            }
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
        
        }

        private void SaveAs()
        { 
        
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

        private void OpenLastDocuments()
        {
            SavedDocument[] docs = Config.LastOpenDocuments;
            
            foreach (SavedDocument doc in docs) 
            {
                docManager.OpenDocument(doc.FullFilePath);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {

            Document[] docs = docManager.Documents;
            SavedDocument[] savedDocs = new SavedDocument[docs.Length];

            for(int a = 0; a < savedDocs.Length; a++)
            {
                Document doc = docs[a];
                savedDocs[a] = new SavedDocument() { FullFilePath = doc.FullFilePath, IsTemporal = doc.IsTemporal };
            }

            Config.LastOpenDocuments = savedDocs;
            Config.Save();

            base.OnClosing(e);
        }
    }
}
