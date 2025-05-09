using System.ComponentModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VampDocManager;
using VampEditor;
using VampirioCode.Builder;
using VampirioCode.Builder.Custom;
using VampirioCode.Builder.Utils;
using VampirioCode.BuilderInstall;
using VampirioCode.BuilderSetting;
using VampirioCode.BuilderSetting.Actions;
using VampirioCode.BuilderSetting.Utils;
using VampirioCode.Command;
using VampirioCode.Command.Dotnet;
using VampirioCode.Hardcode;
using VampirioCode.IO;
using VampirioCode.SaveData;
using VampirioCode.Tests;
using VampirioCode.UI;
using VampirioCode.UI.Style;
using VampirioCode.Utils;
using VampirioCode.Workspace;
using VampirioCode.Workspace.cpp;
using static ScintillaNET.Style;

namespace VampirioCode
{
    public partial class App : Form
    {
        public Document CurrDocument { get { return docManager.CurrDocument; } }
        public DocumentTab CurrDocumentTab { get { return docManager.CurrDocumentTab; } }
        public VampirioEditor CurrEditor { get { return docManager.CurrDocumentTab.Editor; } }

        public bool FullScreen { get { return this.FormBorderStyle == FormBorderStyle.None; } set { if (value) { if (this.WindowState == FormWindowState.Maximized) this.WindowState = FormWindowState.Normal; this.FormBorderStyle = FormBorderStyle.None; this.WindowState = FormWindowState.Maximized; ResumeLayout(); } else { SuspendLayout(); this.WindowState = FormWindowState.Normal; this.FormBorderStyle = FormBorderStyle.Sizable; ResumeLayout(); } } }

        private Control screenLock;

        public App()
        {
            //DoubleBuffered = true;

            InitializeComponent();
            CreateScreenLock();
        }

        protected override void OnLoad(EventArgs e)
        {
            DarkTitleBarHelper.UseImmersiveDarkMode(Handle, true);

            FilesStructInit();
            Display.Initialize();
            DocumentTypeInfo.Initialize();
            Config.Initialize();
            MsgBox.Setup(this);
            XConsole.Setup(footer);
            Builders.Initialize();
            CustomBuilders.Initialize();
            BuilderUtils.Initialize();
            RegisterCmdKeys();

            DefineUtils.HideIfDebug(new ToolStripMenuItem[] {debugCurrDocumentToolStripMenuItem, openAppFolderToolStripMenuItem, jsonTesterToolStripMenuItem, debugBuildersToolStripMenuItem, resetConfigFileToolStripMenuItem });

            // theme
            menuStrip.Renderer = new VampirioCode.UI.VampGraphics.MenuStripRenderer();
            menuStrip.BackColor = Color.FromArgb(30, 30, 30);
            menuStrip.ForeColor = Color.Silver;

            // doc manager events
            docManager.CurrDocumentTabChanged += OnCurrDocumentTabChanged;
            docManager.CurrDocumentTextChanged += OnCurrDocumentTextChanged;
            docManager.CurrDocumentModifiedChanged += OnCurrDocumentModifiedChanged;
            docManager.EditorContextItemPressed += OnEditorContextItemPressed;
            docManager.DocumentCreated += OnDocumentCreated;
            docManager.DocumentRemoved += OnDocumentRemoved;

            // tool bar events
            toolBar.StartPressed += OnStartPressed;
            toolBar.ReloadPressed += OnReloadPressed;

            // drag and drop
            this.AllowDrop = true;
            this.DragEnter += OnDragEnter;
            this.DragDrop += OnDragDrop;

            // splitter
            splitContainer.SplitterMoved += SplitContainer_SplitterMoved;

            // open last documents
            OpenLastDocuments();

            FillBuilderItems();

            Reposition();

            // if there is no saved documents on config file because of an error
            // or if application opens for the first time and config.cfg didn't exist
            if (docManager.Documents.Length == 0)
                New();

            SelectBuilderMenu(CurrDocument.DocType, CurrDocument.BuilderType);

            //VampirioCode.Tests.ItemListTester tester = new ItemListTester();
            //tester.ShowDialog();

            //BuilderSetting.CustomMsvcCppBuilderSetting bsetting = new BuilderSetting.CustomMsvcCppBuilderSetting();
            //bsetting.ShowDialog();
            //new ScrollTester().ShowDialog();
            //OnJSonViewerPressed(null, EventArgs.Empty);
            //OnTreeViewTester(null, EventArgs.Empty);

            //OnSetupCompilersInterpreters(null, EventArgs.Empty);
            //OnDebugBuildersPressed(null, EventArgs.Empty);

            base.OnLoad(e);
        }



        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);
            await DestroyScreenLock();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            HARDCODE_FIXER.XCONSOLE_FIX_LOCATION_AND_SIZE(this, xconsole, splitContainer);
            base.OnSizeChanged(e);
        }

        private void SplitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            HARDCODE_FIXER.XCONSOLE_FIX_LOCATION_AND_SIZE(this, xconsole, splitContainer);
        }


        protected void Reposition()
        {
            // resize the window to the last size
            if (Config.Maximized)
            {
                if ((Config.PosX != -1) && (Config.PosY != -1))
                    Location = new Point(Config.PosX, Config.PosY);

                WindowState = FormWindowState.Maximized;
                this.Size = new Size(Config.Width, Config.Height);
            }
            else
            {
                if ((Config.PosX != -1) && (Config.PosY != -1))
                    Location = new Point(Config.PosX, Config.PosY);

                this.Size = new Size(Config.Width, Config.Height);
            }

            // resize splitter
            if (Config.SplitterDistance != -1)
                splitContainer.SplitterDistance = Config.SplitterDistance;

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
            HotKeyManager.AddHotKey(New, Keys.Control | Keys.N);
            HotKeyManager.AddHotKey(Open, Keys.Control | Keys.O);
            HotKeyManager.AddHotKey(CloseDoc, Keys.Control | Keys.W);
            HotKeyManager.AddHotKey(Find, Keys.Control | Keys.F);
            HotKeyManager.AddHotKey(FindAndReplace, Keys.Control | Keys.H);
            HotKeyManager.AddHotKey(Save, Keys.Control | Keys.S);
            HotKeyManager.AddHotKey(GoTo, Keys.Control | Keys.G);
            HotKeyManager.AddHotKey(Duplicate, Keys.Control | Keys.D);
            HotKeyManager.AddHotKey(BuildAndRun, Keys.F5);
            HotKeyManager.AddHotKey(Build, Keys.F6);
            HotKeyManager.AddHotKey(FullScreenToggle, Keys.F11);
            HotKeyManager.AddHotKey(Undo, Keys.Control | Keys.Z);
            HotKeyManager.AddHotKey(Redo, Keys.Control | Keys.Shift | Keys.Z);
            HotKeyManager.AddHotKey(SaveAs, Keys.Control | Keys.Shift | Keys.S);
            HotKeyManager.AddHotKey(LineUp, Keys.Alt | Keys.Up);
            HotKeyManager.AddHotKey(LineDown, Keys.Alt | Keys.Down);

            //HotKeyManager.AddHotKey(Function,     Keys.Control | Keys.P);
        }

        private void FillBuilderItems()
        {
            ToolStripMenuItem[] items = Builders.CreateMenuItems();

            foreach (ToolStripMenuItem item in items)
                item.Click += OnBuilderPressed;

            builderToolStripMenuItem.DropDownItems.Clear();
            builderToolStripMenuItem.DropDownItems.AddRange(items);
        }


        private async void Build()
        {
            XConsole.Clear();
            //string projName = Path.GetFileNameWithoutExtension(CurrDocument.FullFilePath);

            if (CurrDocument.DocType == DocumentType.OTHER)
            {
                MsgBox.Show(this, "No language", "No language selected.\n\n    Please select a language from the top bar before compiling.");
            }
            else
            {
                if (CurrDocument.CustomBuild)
                {
                    Builder.Custom.CustomBuilder builder = CustomBuilders.GetBuilder(CurrDocument.FullFilePath, CurrDocument.BuilderType);
                    builder.Setup(CurrDocument.FullFilePath, CurrDocument.Text);
                    await builder.Build();
                }
                else
                {
                    Builder.Builder builder = Builders.GetBuilder(CurrDocument.BuilderType);
                    builder.Setup(CurrDocument.FullFilePath, CurrDocument.Text);
                    await builder.Build();
                }
            }
        }

        private async void BuildAndRun()
        {

            Document returnToDoc = null;


            // -------------------------------------------
            // ------ Has workspace? (custom build) ------
            // -------------------------------------------
            WorkspaceInfo workspaceInfo = BuilderUtils.GetWorkspaceInfo(CurrDocument.FullFilePath);

            if (workspaceInfo != null)
            {
                XConsole.Println("info: " + workspaceInfo.ToString());


                WorkspaceBase workspace = workspaceInfo.GetWorkspaceBase();
                XConsole.Println("wb: " + workspace.ToString());

                if (workspaceInfo.IsMainFile(workspace))
                {
                    // do nothing
                    XConsole.PrintWarning("is main file");
                }
                else
                {
                    if (workspace.Language == DocumentType.CPP)
                    {
                        CppWorkspace cppWorkspace = workspaceInfo.GetWorkspace<CppWorkspace>();

                        // Can be '.h', '.cpp' so we must check if it's allowed
                        if (cppWorkspace.IsTypeAllowed(CurrDocument.DocType))
                        {
                            XConsole.PrintWarning("type is allowed");
                            string mainFileFullPath = workspaceInfo.GetMainFile(workspace);
                            XConsole.PrintWarning("mainFileFullPath: " + mainFileFullPath);

                            returnToDoc = CurrDocument;

                            XConsole.PrintError("i: " + docManager.DocToIndex(mainFileFullPath));
                            Document openedDocument = docManager.OpenDocument(mainFileFullPath, true);
                        }

                        XConsole.Println("cppws: " + cppWorkspace.ToString());
                        XConsole.Println("main: " + cppWorkspace.MainFile);
                    }
                }
            }
            // -------------------------------------------
            // -------------------------------------------


            if (!BuilderUtils.CanCompile(CurrDocument.DocType))
            {
                XConsole.Clear();
                XConsole.PrintWarning($"This file '{CurrDocument.DocType}' can't be compiled.");

                if (returnToDoc != null)
                {
                    docManager.SelectDocument(returnToDoc);
                    docManager.Refresh();
                }

                return;
            }

            XConsole.Clear();
            //string projName = Path.GetFileNameWithoutExtension(CurrDocument.FullFilePath);

            if (CurrDocument.DocType == DocumentType.OTHER)
            {
                MsgBox.Show(this, "No language", "No language selected.\n\n    Please select a language from the top bar before compiling.");
            }
            else
            {
                if (CurrDocument.CustomBuild)
                {
                    CurrDocument.BuilderType = BuilderUtils.GetEquivalentCustomOnly(CurrDocument.BuilderType);
                    //XConsole.Alert("BuilderType: " + CurrDocument.BuilderType);

                    Builder.Custom.CustomBuilder builder = CustomBuilders.GetBuilder(CurrDocument.FullFilePath, CurrDocument.BuilderType);
                    if (builder == null)
                    {
                        MsgBox.Show("Simple Builder can't be used", "'Simple Builder' can't be used. You must 'setup' this project before using 'Project/Setup Build' because another 'builder' was set as 'Custom Builder'");
                        return;
                    }
                    builder.Setup(CurrDocument.FullFilePath, CurrDocument.Text);
                    await builder.BuildAndRun();
                }
                else
                {
                    Builder.Builder builder = Builders.GetBuilder(CurrDocument.BuilderType);
                    builder.Setup(CurrDocument.FullFilePath, CurrDocument.Text);
                    await builder.BuildAndRun();
                }
            }

            if (returnToDoc != null)
            {
                docManager.SelectDocument(returnToDoc);
                docManager.Refresh();
            }
        }



        private void OnFilePressed(object sender, EventArgs e)
        {
            string sel = (string)((ToolStripMenuItem)sender).Tag;

                 if (sel == "new") New();
            else if (sel == "open") Open();
            else if (sel == "save") Save();
            else if (sel == "save_as") SaveAs();
            else if (sel == "close") CloseDoc();
            else if (sel == "close_all") CloseAll();
            else if (sel == "exit") Exit();
        }

        private void OnCustomBuildPressed(object sender, EventArgs e)
        {
            string templateTag = (string)((ToolStripMenuItem)sender).Tag;
            BuilderTemplateInfo binfo = BuilderTemplateInfo.GetFromTag(templateTag);

            //XConsole.Alert(binfo.ToString());

            if (binfo == null)
            {
                MsgBox.Show("Not compatible build");
                return;
            }

            NewCustomBuild(binfo);
        }

        private void InsertTemplateCode(DocumentType docType, BuilderType builderType, BuilderTemplate template)
        {
            DocumentTab docTab = docManager.NewDocument();
            docTab.Document.DocType = docType;
            docTab.Document.BuilderType = builderType;
            docTab.Editor.Text = CodeDB.GetCode(template);

            //SelectLanguageMenu(docTab.Document.DocType);
            //SelectBuilderMenu(docTab.Document.DocType, docTab.Document.BuilderType);
            SetLanguage(docType, docTab.Document.BuilderType);
        }

        private void OnBasicCodePressed(object sender, EventArgs e)
        {
            string templateCode = (string)((ToolStripMenuItem)sender).Tag;

            switch (templateCode)
            {
                case "cpp_basic_main":
                    InsertTemplateCode(DocumentType.CPP, BuilderType.SimpleMsvcCpp, BuilderTemplate.CppMsvcBasic);
                    break;

                case "csharp_basic_main":
                    InsertTemplateCode(DocumentType.CSHARP, BuilderType.SimpleCSharp, BuilderTemplate.CSharpDotnetBasic);
                    break;

                case "js_basic_script":
                    InsertTemplateCode(DocumentType.JS, BuilderType.SimpleJs, BuilderTemplate.JavascriptBasic);
                    break;

                case "java_basic_program":
                    InsertTemplateCode(DocumentType.JAVA, BuilderType.SimpleJava, BuilderTemplate.JavaBasic);
                    break;

                case "php_basic_program":
                    InsertTemplateCode(DocumentType.PHP, BuilderType.SimplePhp, BuilderTemplate.PhpBasic);
                    break;

                case "html_basic_page":
                    InsertTemplateCode(DocumentType.HTML, BuilderType.None, BuilderTemplate.HtmlBasic);
                    break;
            }

        }

        private void OnProjectPressed(object sender, EventArgs e)
        {
            bool customBuild = CurrDocument.CustomBuild;

            setupBuildToolStripMenuItem.Enabled = false;
            clearBuildSettingsToolStripMenuItem.Enabled = false;
            moveBuildToolStripMenuItem.Enabled = false;

            if (CurrDocument.CustomBuild)
            {
                setupBuildToolStripMenuItem.Enabled = true;
                clearBuildSettingsToolStripMenuItem.Enabled = true;
                moveBuildToolStripMenuItem.Enabled = true;
            }
            else // SimpleBuild
            {
                if (BuilderUtils.HasEquivalent(CurrDocument.BuilderType))
                {
                    setupBuildToolStripMenuItem.Enabled = true;
                    clearBuildSettingsToolStripMenuItem.Enabled = false;
                }
                else
                {
                    setupBuildToolStripMenuItem.Enabled = false;
                    clearBuildSettingsToolStripMenuItem.Enabled = false;
                }
            }
        }

        private void OnSetupBuildPressed(object sender, EventArgs e)
        {
            //string projName = Path.GetFileNameWithoutExtension(CurrDocument.FullFilePath);

            //XConsole.Println("custom: " + CurrDocument.CustomBuild + " is: " + CurrDocument.BuilderType);

            //
            // Custom Build
            //
            if (CurrDocument.CustomBuild)
            {
                WorkspaceInfo workspaceInfo = BuilderUtils.GetWorkspaceInfo(CurrDocument.FullFilePath);

                // Workspace exists, so there is a 'Custom Project' (.bettings) created before
                // and all of its structure
                if (workspaceInfo != null)
                {
                    WorkspaceBase workspace = workspaceInfo.GetWorkspaceBase();
                    XConsole.PrintWarning("--------------------------------");
                    XConsole.Println("info: " + workspaceInfo.ToString());
                    XConsole.Println("wb: " + workspace.ToString());
                    XConsole.PrintWarning("--------------------------------");

                    //
                    // Not main File
                    //
                    if (!workspaceInfo.IsMainFile(workspace))
                    {
                        // do nothing
                        //XConsole.PrintWarning("isn't main file");
                        var result = MsgBox.Show("Already created project", "There's a project already created inside directory:\n\n'" + workspaceInfo.RootDirFullPath + "'\n\nYou can't create another one.\nDo you want to open the main project file?", DialogButtons.YesNoCancel, DialogIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            string mainFileFullPath = workspaceInfo.GetMainFile(workspace);
                            docManager.OpenDocument(mainFileFullPath);
                            docManager.Refresh();
                            OnSetupBuildPressed(null, EventArgs.Empty);
                        }

                        return;
                    }
                    //
                    // Is main File
                    //
                    else
                    {
                        //XConsole.Alert("CurrDocument.BuilderType: " + CurrDocument.BuilderType);
                        BuilderTemplateInfo binfo = BuilderTemplateInfo.GetFromType(CurrDocument.BuilderType);

                        //XConsole.Alert("binfo: " + binfo);

                        //if (binfo == null)
                        {
                            // ----------------------------------------

                            //XConsole.Alert("si: " + workspaceInfo.MainDirFullPath);
                            //BuilderKind

                            string cppMsvcPath =        Path.Combine(workspaceInfo.MainDirFullPath, BuilderKind.CppMsvc.ToString());
                            string cppGnuGppPath =      Path.Combine(workspaceInfo.MainDirFullPath, BuilderKind.CppGnuGpp.ToString());
                            string cppCLangPath =       Path.Combine(workspaceInfo.MainDirFullPath, BuilderKind.CppCLang.ToString());
                            string cppEmscriptenPath =  Path.Combine(workspaceInfo.MainDirFullPath, BuilderKind.CppEmscripten.ToString());

                            BuilderType typeCustom = BuilderUtils.GetEquivalentCustomOnly(CurrDocument.BuilderType);
                            bool exists = false;

                            if (typeCustom == BuilderType.CustomMsvcCpp)
                            {
                                exists = Directory.Exists(cppMsvcPath);
                                //XConsole.Alert("msvc exists: " + exists);
                            }
                            else if (typeCustom == BuilderType.CustomGnuGppWSLCpp)
                            {
                                exists = Directory.Exists(cppGnuGppPath);
                                //XConsole.Alert("gnu c++ exists: " + exists);
                            }
                            else if (typeCustom == BuilderType.CustomClangCpp)
                            {
                                exists = Directory.Exists(cppCLangPath);
                                //XConsole.Alert("clang++ exists: " + exists);
                            }
                            else if (typeCustom == BuilderType.CustomEmscriptenCpp)
                            {
                                exists = Directory.Exists(cppEmscriptenPath);
                                //XConsole.Alert("emscripten exists: " + exists);
                            }
                            else
                            {
                                MsgBox.Show("Beta Soft", "'Custom Builder' not finished yet.\n\nTry 'msvc' or 'gnu c++'");
                                return;
                            }

                            // ----------------------------------------

                            //XConsole.Alert("don't have binfo");
                            //return;
                            //XConsole.Alert("enter here");

                            BuilderType btypeCustom = BuilderUtils.GetEquivalentCustomOnly(CurrDocument.BuilderType);
                            CurrDocument.BuilderType = btypeCustom;
                            binfo = BuilderTemplateInfo.GetFromType(btypeCustom);

                            //XConsole.Alert(binfo.ToString());

                            if (binfo == null)
                            {
                                MsgBox.Show("Not compatible build");
                                return;
                            }

                            //NewCustomBuild(binfo);

                            //Document document = CreateCustomDocument(DocumentType.CPP, BuilderType.CustomGnuGppWSLCpp);

                            binfo.DontUpdateCode = true;

                            if (CurrDocument.BuilderType == BuilderType.CustomMsvcCpp)
                            {
                                if (!exists)
                                    CustomBuilders.Create_CPP_MSVC_BASIC(CurrDocument, CurrEditor, binfo);

                                CurrDocument.BuilderType = BuilderType.CustomMsvcCpp;
                            }
                            else if (CurrDocument.BuilderType == BuilderType.CustomGnuGppWSLCpp)
                            {
                                if (!exists)
                                    CustomBuilders.Create_CPP_GNU_GPP_WSL_BASIC(CurrDocument, CurrEditor, binfo);

                                CurrDocument.BuilderType = BuilderType.CustomGnuGppWSLCpp;
                            }
                            else if (CurrDocument.BuilderType == BuilderType.CustomClangCpp)
                            {
                                if (!exists)
                                    CustomBuilders.Create_CPP_CLANG_BASIC(CurrDocument, CurrEditor, binfo);

                                CurrDocument.BuilderType = BuilderType.CustomClangCpp;
                            }
                            else if (CurrDocument.BuilderType == BuilderType.CustomEmscriptenCpp)
                            {
                                if (!exists)
                                    CustomBuilders.Create_CPP_EMSCRIPTEN_BASIC(CurrDocument, CurrEditor, binfo);

                                CurrDocument.BuilderType = BuilderType.CustomEmscriptenCpp;
                            }
                            //return;*/
                        }
                        //CustomMsvcCppBuilderSetting builderSettings = new CustomMsvcCppBuilderSetting();
                        var builderSettings = binfo.BuilderSetting;
                        builderSettings.Open(CurrDocument.FullFilePath, CurrDocument.BuilderType);
                    }
                }
                else
                {



                    //XConsole.Alert("CurrDocument.BuilderType: " + CurrDocument.BuilderType);
                    BuilderTemplateInfo binfo = BuilderTemplateInfo.GetFromType(CurrDocument.BuilderType);

                    if (binfo == null)
                        return;

                    // Open UI
                    //CustomMsvcCppBuilderSetting builderSettings = new CustomMsvcCppBuilderSetting();
                    var builderSettings = binfo.BuilderSetting;
                    builderSettings.Open(CurrDocument.FullFilePath, CurrDocument.BuilderType);
                }
            }
            //
            // SimpleBuild
            //
            else
            {
                WorkspaceInfo workspaceInfo = BuilderUtils.GetWorkspaceInfo(CurrDocument.FullFilePath);

                // Workspace exists, so there is a 'Custom Project' (.bettings) created before
                // and all of its structure
                if (workspaceInfo != null)
                {
                    WorkspaceBase workspace = workspaceInfo.GetWorkspaceBase();
                    XConsole.Println("info: " + workspaceInfo.ToString());
                    XConsole.Println("wb: " + workspace.ToString());

                    if (!workspaceInfo.IsMainFile(workspace))
                    {
                        // do nothing
                        XConsole.PrintWarning("isn't main file");
                        var result = MsgBox.Show("Already created project", "There's a project already created inside directory:\n\n'" + workspaceInfo.RootDirFullPath + "'\n\nYou can't create another one.\nDo you want to open the main project file?", DialogButtons.YesNoCancel, DialogIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            string mainFileFullPath = workspaceInfo.GetMainFile(workspace);
                            docManager.OpenDocument(mainFileFullPath);
                            docManager.Refresh();
                            OnSetupBuildPressed(null, EventArgs.Empty);
                        }

                        return;
                    }
                }


                // Convert a Simple project like:   BuilderType.SimpleMsvcCpp to
                //              The equivalent ->   BuilderType.CustomMsvcCpp
                //XConsole.Alert("b: " + CurrDocument.BuilderType);
                //XConsole.Alert("is equiv: " + BuilderUtils.GetEquivalent(CurrDocument.BuilderType));
                BuilderUtils.ConvertSimpleToCustomBuild(CurrDocument);

            }

        }

        private void OnClearBuildSettingPressed(object sender, EventArgs e)
        {
            if (CurrDocument.CustomBuild)
            {
                if (BuilderUtils.HasEquivalent(CurrDocument.BuilderType))
                {
                    BuilderUtils.ConvertCustomToSimpleBuild(CurrDocument);
                }
            }
            else // SimpleBuild
            {
                MsgBox.Show("Already a Simple Build", "This build is already a 'Simple Build' so it's not needed to go back.\n\nIt's not a 'Custom Build'");
            }
        }

        public class FileAdv
        {
            public string FileNameOnly { get; set; }
            public string OriginalFullDir { get; private set; }
            public string NewFullDir { get; private set; }
            public string OriginalFullFile { get; private set; }
            public string NewFullFile { get; private set; }

            public FileAdv(string originalFullDir, string fileNameOnly)
            {
                this.FileNameOnly = fileNameOnly;
                this.OriginalFullDir = originalFullDir;
                this.OriginalFullFile = originalFullDir + "\\" + fileNameOnly;
            }

            public void SetNewFullDir(string newFullDir)
            {
                NewFullDir = newFullDir;
                NewFullFile = newFullDir + "\\" + FileNameOnly;
            }

            public override string ToString()
            {
                return $"[FileNameOnly:      {FileNameOnly}, \nOriginalFullDir:      {OriginalFullDir}, \nNewFullDir:            {NewFullDir}, \nOriginalFullFile:      {OriginalFullFile}, \nNewFullFilePath:     {NewFullFile}]\n";
            }
        }

        private void OnMoveBuildPressed(object sender, EventArgs e)
        {
            string newFullDir = "";


            WorkspaceInfo workspaceInfo = BuilderUtils.GetWorkspaceInfo(CurrDocument.FullFilePath);

            if (workspaceInfo != null)
            {

                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                {
                    folderBrowserDialog.Description = "Select a new project build folder";
                    folderBrowserDialog.ShowNewFolderButton = true;

                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        newFullDir = folderBrowserDialog.SelectedPath;

                        if (Directory.Exists(Path.Combine(newFullDir, AppInfo.VampTempDir)))
                        {
                            MsgBox.Show(this, "Already contains custom build", "There's another custom build project inside this folder.\n\nThis directory can't be used. Select another one.", DialogButtons.OK, DialogIcon.Warning);
                            return;
                        }

                    }
                    else
                        return;
                }

                string fromPath = workspaceInfo.RootDirFullPath;

                //XConsole.Alert("fromPath: " + fromPath);

                XConsole.Println("info: " + workspaceInfo.ToString());


                WorkspaceBase workspace = workspaceInfo.GetWorkspaceBase();
                XConsole.Println("wb: " + workspace.ToString());

                List<string> allFiles = FileUtils.GetFilesAdv(fromPath, null, null, true, false);
                List<FileAdv> allFilesAdv = new List<FileAdv>();

                foreach (var file in allFiles)
                {
                    allFilesAdv.Add(new FileAdv(fromPath, file));
                    XConsole.PrintWarning(file);
                }

                XConsole.Println("-------------------------------");


                //string newFullDir = "C:\\test2\\news\\la copia";

                foreach (var fileAdv in allFilesAdv)
                {
                    fileAdv.SetNewFullDir(newFullDir);

                    XConsole.Println(fileAdv.ToString());
                }

                XConsole.Println("=================================");

                //string toPath = folderBrowserDialog.SelectedPath;

                //
                // Copy all files from original path to the new path
                //
                XConsole.Println("copy from: " + fromPath);
                XConsole.Print("to: " + newFullDir);

                FileUtils.MoveDirectoryContents(fromPath, newFullDir);
                // -------------------------------------------------

                XConsole.Println("=================================");


                foreach (var doc in docManager.Documents)
                {
                    foreach (var fileAdv in allFilesAdv)
                    {
                        if (doc.FullFilePath == fileAdv.OriginalFullFile)
                        {
                            XConsole.PrintWarning("-> " + doc.FullFilePath + " [update]");

                            doc.IsTemporary = false;

                            if (doc.Modified)
                                doc.Save();

                            doc.Move(fileAdv.NewFullFile, true);

                            //doc.CustomBuild = true;
                            //doc.DocType = DocumentType.CPP;
                            //doc.BuilderType = BuilderType.CustomMsvcCpp;
                            //Config.LastOpenDocuments
                            //ReplaceConfigLastOpenDoc(fileAdv.OriginalFullFile, fileAdv.NewFullFile);
                        }
                    }

                    //XConsole.PrintError("-> " + doc.FullFilePath);
                }

                //Config.Save();

                XConsole.Println("-------------------------------");

                SetTitle(CurrDocument);
                SaveConfig();

                // Delete directories from 'build'
                string fromBuildPath = Utility.ReplaceLast(fromPath, AppInfo.TemporaryFilesPath, AppInfo.TemporaryBuildPath);
                Directory.Delete(fromPath, true);
                if (Directory.Exists(fromBuildPath))
                {
                    Directory.Delete(fromBuildPath, true);
                    XConsole.PrintWarning("build directory deleted [c] (" + AppInfo.TemporaryBuildPath + "): " + fromBuildPath + "\n");
                }
                XConsole.PrintWarning("directory deleted [c] (" + AppInfo.TemporaryFilesPath + "): " + fromPath);

                // -------------------------------
                MsgBox.Show(this, "Done!", "Custom build project moved done to:\n\n'" + newFullDir + "'");
            }
            else
                MsgBox.Show(this, "This is not a custom build project");
        }

        private void OnEditPressed(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            string name = item.Tag.ToString();

            if (name == "undo")
            {

            }
            else if (name == "redo")
            {

            }
            else if (name == "cut")
            {

            }
            else if (name == "copy")
            {

            }
            else if (name == "paste")
            {

            }
            else if (name == "rename")
            {
                Rename(CurrDocument);
            }
        }

        private void OnEditorContextItemPressed(EditorEventType eventType, Document document)
        {
            string prevFullFilePath = "";

            if (eventType == VampEditor.EditorEventType.OpenFileLocation)
            {
                //Process.Start("explorer.exe", string.Format("/select,\"{0}\"", document.FullFilePath));
                FileBrowserUtils.OpenAndLocateFile(document.FullFilePath);
            }
            else if (eventType == VampEditor.EditorEventType.OpenOutputFilename)
            {
                if (CurrDocument.DocType == DocumentType.OTHER)
                {
                    MsgBox.Show(this, "Language not selected", "Language was not selected. This feature only works with a language. Select one from the top.");
                }
                else
                {
                    WorkspaceInfo workspaceInfo = BuilderUtils.GetWorkspaceInfo(document.FullFilePath);

                    // Workspace exists, so there is a 'Custom Project' (.bettings) created before
                    // and all of its structure
                    if (workspaceInfo != null)
                    {
                        WorkspaceBase workspace = workspaceInfo.GetWorkspaceBase();

                        // You are not in the main file, so go to the main file to
                        // locate the output file and then return to this file
                        if (!workspaceInfo.IsMainFile(workspace))
                        {
                            prevFullFilePath = document.FullFilePath;
                            string mainFileFullPath = workspaceInfo.GetMainFile(workspace);
                            docManager.OpenDocument(mainFileFullPath);
                            docManager.Refresh();
                            //OnSetupBuildPressed(null, EventArgs.Empty);
                        }
                    }
                    // ----------------------------------------------------------------------



                    // Find the builder
                    Builder.Builder builder;

                    if (CurrDocument.CustomBuild)
                        builder = CustomBuilders.GetBuilder(CurrDocument.FullFilePath, CurrDocument.BuilderType);
                    else
                        builder = Builders.GetBuilder(CurrDocument.BuilderType);

                    builder.Setup(CurrDocument.FullFilePath, CurrDocument.Text);
                    builder.Prepare();

                    if (CurrDocument.CustomBuild)
                        ((CustomBuilder)builder).Load();

                    if (builder.OutputFilename != "")
                    {
                        if (File.Exists(builder.OutputFilename))
                            Process.Start("explorer.exe", string.Format("/select,\"{0}\"", builder.OutputFilename));
                        else
                            MsgBox.Show(this, "File does not exist", "File '" + builder.OutputFilename + "' does not exist yet.\n\nCompile it first");
                    }
                    else
                        MsgBox.Show(this, "Not available", "The output file for this document is not available.\nIt may be an interpreted file extension that doesn't need a compilation process. Try opening the file path instead.");


                    // return to the initial file if it's the case
                    if (prevFullFilePath != "")
                    {
                        docManager.OpenDocument(prevFullFilePath);
                        docManager.Refresh();
                    }
                }
            }
        }

        private void OnLanguagePressed(object sender, EventArgs e)
        {
            /*DocumentType docType = DocumentType.OTHER;

                 if (sender == csharpToolStripMenuItem) docType = DocumentType.CSHARP;
            else if (sender == cppToolStripMenuItem)    docType = DocumentType.CPP;
            else if (sender == jsToolStripMenuItem)     docType = DocumentType.JS;
            else if (sender == javaToolStripMenuItem)   docType = DocumentType.JAVA;
            else if (sender == phpToolStripMenuItem)    docType = DocumentType.PHP;
            else if (sender == htmlToolStripMenuItem)   docType = DocumentType.HTML;
            else if (sender == cmakeToolStripMenuItem)  docType = DocumentType.TXT;

            SetLanguage(docType);*/

            DocumentType docType = DocumentType.OTHER;

                 if (sender == csharpToolStripMenuItem) docType = DocumentType.CSHARP;
            else if (sender == cppToolStripMenuItem)    docType = DocumentType.CPP;
            else if (sender == jsToolStripMenuItem)     docType = DocumentType.JS;
            else if (sender == javaToolStripMenuItem)   docType = DocumentType.JAVA;
            else if (sender == phpToolStripMenuItem)    docType = DocumentType.PHP;
            else if (sender == htmlToolStripMenuItem)   docType = DocumentType.HTML;
            else if (sender == cmakeToolStripMenuItem)  docType = DocumentType.TXT;

            SetLanguage(docType);

            if (CurrDocument.DocType != docType)
            {
                CurrDocument.DocType = docType;
                CurrDocument.BuilderType = Builders.GetDefaultTypeFor(docType);
                SelectLanguageMenu(CurrDocument.DocType);
                SelectBuilderMenu(CurrDocument.DocType, CurrDocument.BuilderType);

                // change language at editor (scintilla)
                CurrDocumentTab.Editor.SetLanguage(CurrDocument.DocType, VampEditor.StyleMode.Dark);
            }
        }

        private void OnBuilderPressed(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            BuilderType prevBuilderType = CurrDocument.BuilderType;

            CurrDocument.BuilderType = (BuilderType)item.Tag;
            SelectBuilderMenu(CurrDocument.DocType, CurrDocument.BuilderType);




            // ------------------------------------------------------------





            /*
            XConsole.Println("custom" + CurrDocument.CustomBuild + ", btype: " + CurrDocument.BuilderType);

            if (CurrDocument.CustomBuild)
            {
                WorkspaceInfo workspaceInfo = BuilderUtils.GetWorkspaceInfo(CurrDocument.FullFilePath);

                // Workspace exists, so there is a 'Custom Project' (.bettings) created before
                // and all of its structure
                if (workspaceInfo != null)
                {
                    WorkspaceBase workspace = workspaceInfo.GetWorkspaceBase();


                    //
                    // Not main File
                    //
                    if (!workspaceInfo.IsMainFile(workspace))
                    {
                        // do nothing
                        XConsole.PrintWarning("isn't main file");
                        var result = MsgBox.Show("Already created project", "There's a project already created inside directory:\n\n'" + workspaceInfo.RootDirFullPath + "'\n\nYou can't create another one.\nDo you want to open the main project file?", DialogButtons.YesNoCancel, DialogIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            string mainFileFullPath = workspaceInfo.GetMainFile(workspace);
                            docManager.OpenDocument(mainFileFullPath);
                            docManager.Refresh();
                            OnSetupBuildPressed(null, EventArgs.Empty);
                        }

                        return;
                    }
                    //
                    // Is main File
                    //
                    else
                    {
                        //XConsole.Alert("CurrDocument.BuilderType: " + CurrDocument.BuilderType);
                        BuilderTemplateInfo binfo = BuilderTemplateInfo.GetFromType(CurrDocument.BuilderType);

                        if (binfo == null)
                        { }
                    }
                }
            }*/


            /*if ((CurrDocument.CustomBuild) && (prevBuilderType != CurrDocument.BuilderType))
            {
                //XConsole.Alert("NEW ->  custom: " + CurrDocument.CustomBuild + " builderType: " + CurrDocument.BuilderType + " prevBuilderType: " + prevBuilderType);

                BuilderType toBuilderType = BuilderUtils.GetEquivalentCustomOnly(CurrDocument.BuilderType);

                CurrDocument.CustomBuild = false;
                BuilderUtils.ConvertSimpleToCustomBuild(CurrDocument);

                //XConsole.Alert("to builder type: " + toBuilderType);
                //BuilderUtils.GetCategory();
                //BuilderUtils.GetCategory(selBuilderType);
            }*/

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
                //docManager.OpenDocument(filePath);
                docManager.OpenDocument(filePath, true);
            }
        }

        private void Save()
        {
            bool wasTemporary = CurrDocument.IsTemporary;
            bool saved = docManager.Save();

            if (saved && wasTemporary)
            {
                //SelectLanguageAndBuilder(CurrDocument);
                //SetLanguage(document.DocType, document.BuilderType);
                //CurrDocumentTab.Editor.SetLanguage(CurrDocument.DocType); // fixed language selection bug
                SetLanguage(CurrDocument.DocType, CurrDocument.BuilderType);
            }
        }

        private void SaveAs()
        {
            bool saved = docManager.SaveAs();

            if (saved)
            {
                SetLanguage(CurrDocument.DocType, CurrDocument.BuilderType);
                //SelectLanguageAndBuilder(CurrDocument);
                //CurrDocumentTab.Editor.SetLanguage(CurrDocument.DocType); // fixed language selection bug
            }
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

        private void Rename(Document document)
        {
            var dialogResult = InputMsgBox.Show(this, "Rename file", "New File Name", "Please select a new name for the current file.");

            if (dialogResult != DialogResult.OK)
                return;

            string newFileName = InputMsgBox.InputText;

            var result = document.Rename(newFileName, true);

            if (result.HasErrors)
            {
                MsgBox.Error(this, result.ErrorInfo.Message);
                return;
            }

            /*WorkspaceInfo workspaceInfo = BuilderUtils.GetWorkspaceInfo(document.FullFilePath);

            if (workspaceInfo != null)
            {
                XConsole.Println("info: " + workspaceInfo.ToString());

                WorkspaceBase workspace = workspaceInfo.GetWorkspaceBase();
            }*/


            SetTitle(CurrDocument);
            SaveConfig();
        }

        private Document CreateCustomDocument(DocumentType docType, BuilderType builderType)
        {
            DocumentTab tab = docManager.NewDocument();
            Document document = tab.Document;
            document.DocType = docType;
            document.BuilderType = builderType;
            document.CustomBuild = true;
            //SelectLanguageMenu(docType);
            //SelectBuilderMenu(docType, builderType);
            SetLanguage(CurrDocument.DocType, CurrDocument.BuilderType);

            return document;
        }

        private void NewCustomBuild(BuilderTemplateInfo builderTemplateInfo)
        {
            BuilderTemplate template = builderTemplateInfo.Template;

            // -----------------------------------------
            //                   MSVC
            // -----------------------------------------
            if (template == BuilderTemplate.CppMsvcBasic)
            {
                Document document = CreateCustomDocument(DocumentType.CPP, BuilderType.CustomMsvcCpp);
                CustomBuilders.Create_CPP_MSVC_BASIC(document, CurrEditor, builderTemplateInfo);
            }
            else if (template == BuilderTemplate.CppMsvcSDL2)
            {
                Document document = CreateCustomDocument(DocumentType.CPP, BuilderType.CustomMsvcCpp);
                CustomBuilders.Create_CPP_MSVC_SDL2(document, CurrEditor, builderTemplateInfo);
            }
            else if (template == BuilderTemplate.CppMsvcVampEngine)
            {
                Document document = CreateCustomDocument(DocumentType.CPP, BuilderType.CustomMsvcCpp);
                CustomBuilders.Create_CPP_MSVC_VAMP_ENGINE(document, CurrEditor, builderTemplateInfo);
            }
            else if (template == BuilderTemplate.CppMsvcVampEngineComplex)
            {
                Document document = CreateCustomDocument(DocumentType.CPP, BuilderType.CustomMsvcCpp);
                CustomBuilders.Create_CPP_MSVC_VAMP_ENGINE(document, CurrEditor, builderTemplateInfo);
            }
            // -----------------------------------------
            //               gnu g++ WSL
            // -----------------------------------------
            else if (template == BuilderTemplate.CppGnuGppWSLBasic)
            {
                Document document = CreateCustomDocument(DocumentType.CPP, BuilderType.CustomGnuGppWSLCpp);
                CustomBuilders.Create_CPP_GNU_GPP_WSL_BASIC(document, CurrEditor, builderTemplateInfo);
            }
            else if (template == BuilderTemplate.CppGnuGppSDL2)
            {
                Document document = CreateCustomDocument(DocumentType.CPP, BuilderType.CustomGnuGppWSLCpp);
                CustomBuilders.Create_CPP_GNU_GPP_WSL_SDL2(document, CurrEditor, builderTemplateInfo);
            }

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

        private void LineUp()
        {
            CurrEditor.LineUp_TODO();
        }

        private void LineDown()
        {
            CurrEditor.LineDown_TODO();
        }

        private void SetTitle(Document doc)
        {
            string title = "Vampirio Code   �   ";

            if (doc.IsTemporary)
                title += doc.FileName;
            else
                title += doc.FullFilePath;

            if (doc.Modified)
                title += " *";

            this.Text = title;
        }

        private void SetTitleState(Document doc)
        {
            if (doc.Modified)
            {
                if ((this.Text.Length > 0) && (this.Text[this.Text.Length - 1] != '*'))
                    this.Text += " *";
            }
            else
            {
                if ((this.Text.Length > 0) && (this.Text[this.Text.Length - 1] == '*'))
                    this.Text = this.Text.Substring(0, this.Text.Length - 2);
            }
        }

        private void FilesStructInit()
        {
            if (!Directory.Exists(AppInfo.TemporaryFilesPath))
                Directory.CreateDirectory(AppInfo.TemporaryFilesPath);
        }

        private void OpenLastDocuments()
        {
            bool updated = false;
            SavedDocument[] docs = Config.LastOpenDocuments;

            foreach (SavedDocument doc in docs)
            {
                if (!File.Exists(doc.FullFilePath))
                {
                    XConsole.PrintWarning("Can't find file at '" + doc.FullFilePath + "'. It will not be loaded.");
                    updated = true;
                }
                else
                    docManager.OpenDocument(doc.FullFilePath, doc.DocumentSettings);
            }

            CleanUpTempFiles();

            if (updated)
                SaveConfig();
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

            //XConsole.Alert("allTempFilesPath: " + allTempFilesPath.Length);

            foreach (var tempFile in allTempFilesPath)
            {
                //XConsole.Alert("is: " + tempFile);
                if (!loadedTempFilesPath.Contains(tempFile))
                {
                    File.Delete(tempFile);
                    XConsole.PrintWarning("old temporary file deleted: " + tempFile);
                }
            }
            
            //
            // Cleanup empty directories
            //
            string[] directories = Directory.GetDirectories(AppInfo.TemporaryFilesPath);
            string buildDir = "";

            foreach (var dir in directories)
            {
                //XConsole.Alert("d: " + dir);

                string[] files = FileUtils.GetFilesAt(dir);

                //
                // Directory is empty, no file inside
                //
                if (files.Length == 0)
                {
                    buildDir = Utility.ReplaceLast(dir, AppInfo.TemporaryFilesPath, AppInfo.TemporaryBuildPath);

                    try
                    {
                        Directory.Delete(dir, true);
                        Directory.Delete(buildDir, true);

                        XConsole.PrintWarning("directory deleted [a] (" + AppInfo.TemporaryFilesPath + "): " + dir);
                        XConsole.PrintWarning("build directory deleted [a] (" + AppInfo.TemporaryBuildPath + "): " + buildDir + "\n");
                    }
                    catch (Exception e)
                    {
                        XConsole.PrintError($"Can't delete '{dir}' or '{buildDir}'");
                    }
                }
                //
                // Error: can't be more than one file inside 'temp_files' dir
                //
                else if (files.Length > 1)
                {
                    buildDir = Utility.ReplaceLast(dir, AppInfo.TemporaryFilesPath, AppInfo.TemporaryBuildPath);

                    MsgBox.Show("Can't be more than one file inside 'temp_files' dir. Delete '" + dir + "' and '" + buildDir + "' manually.\n");
                }
                //
                // Check if file inside directory is open or it was moved
                //
                else if (files.Length == 1)
                {
                    string file = files[0];

                    if (!docManager.Exists(file))
                    {
                        buildDir = Utility.ReplaceLast(dir, AppInfo.TemporaryFilesPath, AppInfo.TemporaryBuildPath);

                        try
                        {
                            Directory.Delete(dir, true);
                            Directory.Delete(buildDir, true);

                            XConsole.PrintWarning("directory deleted [b] (" + AppInfo.TemporaryFilesPath + "): " + dir);
                            XConsole.PrintWarning("build directory deleted [b] (" + AppInfo.TemporaryBuildPath + "): " + buildDir + "\n");
                        }
                        catch (Exception e)
                        {
                            XConsole.PrintError($"Can't delete '{dir}' or '{buildDir}'");
                        }
                    }
                }
            }
        }

        private void SetLanguage(DocumentType docType, BuilderType builderType = BuilderType.None)
        {
            //if (CurrDocument.DocType != docType)
            {
                CurrDocument.DocType = docType;
                CurrDocument.BuilderType = Builders.GetDefaultTypeFor(docType);
                SelectLanguageMenu(CurrDocument.DocType);
                SelectBuilderMenu(CurrDocument.DocType, CurrDocument.BuilderType);

                // change language at editor (scintilla)
                CurrDocumentTab.Editor.SetLanguage(CurrDocument.DocType, VampEditor.StyleMode.Dark);
            }
        }

        private void SelectLanguageAndBuilder(Document document)
        {
            SelectLanguageMenu(document.DocType);
            FillBuilderItems();
            SelectBuilderMenu(document.DocType, document.BuilderType);
        }

        private void SelectLanguageMenu(DocumentType docType)
        {
            //ToolStripMenuItem[] items = new ToolStripMenuItem[] { csharpToolStripMenuItem, cppToolStripMenuItem, jsToolStripMenuItem, javaToolStripMenuItem, phpToolStripMenuItem, htmlToolStripMenuItem, cmakeToolStripMenuItem };

            Dictionary<DocumentType, ToolStripMenuItem> items2 = new Dictionary<DocumentType, ToolStripMenuItem>()
            {
                { DocumentType.CSHARP,  csharpToolStripMenuItem },
                { DocumentType.CPP,     cppToolStripMenuItem },
                { DocumentType.H,       cppToolStripMenuItem },
                { DocumentType.JS,      jsToolStripMenuItem },
                { DocumentType.JAVA,    javaToolStripMenuItem },
                { DocumentType.PHP,     phpToolStripMenuItem },
                { DocumentType.HTML,    htmlToolStripMenuItem },
                { DocumentType.TXT,     cmakeToolStripMenuItem }
            };

            foreach (var item in items2)
            {
                if (item.Value.ForeColor != Color.Silver)
                    item.Value.ForeColor = Color.Silver;
            }

            if (docType != DocumentType.OTHER)
            {
                items2[docType].ForeColor = Color.SlateBlue;
            }

            footer.DocType = docType;

            /*foreach (var item in items)
            {
                if (item.ForeColor != Color.Silver)
                    item.ForeColor = Color.Silver;
            }

                 if (docType == DocumentType.CSHARP) csharpToolStripMenuItem.ForeColor = Color.SlateBlue;
            else if (docType == DocumentType.CPP) cppToolStripMenuItem.ForeColor = Color.SlateBlue;
            else if (docType == DocumentType.JS) jsToolStripMenuItem.ForeColor = Color.SlateBlue;
            else if (docType == DocumentType.JAVA) javaToolStripMenuItem.ForeColor = Color.SlateBlue;
            else if (docType == DocumentType.PHP) phpToolStripMenuItem.ForeColor = Color.SlateBlue;
            else if (docType == DocumentType.HTML) htmlToolStripMenuItem.ForeColor = Color.SlateBlue;
            else if (docType == DocumentType.TXT) cmakeToolStripMenuItem.ForeColor = Color.SlateBlue;
            footer.DocType = docType;*/
        }

        private void SelectBuilderMenu(DocumentType docType, BuilderType selBuilderType)
        {
            //XConsole.Println("--------------");
            //XConsole.Println("docType: " + docType + "   selBuilderType: " + selBuilderType);

            BuilderCategory category = BuilderUtils.GetCategory(selBuilderType);

            if (category == BuilderCategory.Custom)
            {
                selBuilderType = BuilderUtils.GetEquivalent(selBuilderType);
                //XConsole.Println("docType: " + docType + "   [equivalent builder type]: " + selBuilderType);
            }


            // Get equivalent BuilderType if it is a custom one, so we should't 
            // have to duplicate code and check both Custom and Simple.
            // So as a result: Custom will be transform to its Simple version
            //
            // For example:
            //         From a custom  -> BuilderType.CustomMsvcCpp
            //         The equivalent -> BuilderType.SimpleMsvcCpp

            BuilderType[] allowedBuilders = Builders.GetBuilderypesFor(docType);

            // Loop for turning on and off
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
                    //String allow = "";
                    //foreach (var al in allowedBuilders)
                    //    allow += al.ToString() + ", ";
                    //XConsole.Alert("docType: " + docType + "     allowed: " + allow + " buildType: " + buildType + " contain: " + allowedBuilders.Contains(buildType));

                    // hide menu item if it doesn't belong to the language or docType
                    item.Visible = allowedBuilders.Contains(buildType);

                    if (item.ForeColor != Color.Silver)
                        item.ForeColor = Color.Silver;
                }
            }

        }

        private void OnCurrDocumentTabChanged(int index, Document doc)
        {
            if (doc != null)
            {
                SelectLanguageMenu(doc.DocType);
                SelectBuilderMenu(doc.DocType, doc.BuilderType);
                SetTitle(doc);
            }
        }

        private void OnCurrDocumentTextChanged(Document doc)
        {
            //SetTitleState(doc);
        }

        private void OnCurrDocumentModifiedChanged(Document doc)
        {
            SetTitleState(doc);
        }

        private void OnDocumentCreated(Document document, DocumentTab documentTab, OpenDocInfo openDocInfo, CreateMode mode)
        {
            documentTab.Editor.PositionChanged += OnEditorPositionChanged;

            if (openDocInfo != null)
            {
                //XConsole.Alert("doc type: " + document.DocType);
                //SelectLanguageMenu(document.DocType);
                //SelectBuilderMenu(document.DocType, document.BuilderType);
                //SelectLanguageMenu(openDocInfo.DocumentType);
                //SelectBuilderMenu(openDocInfo.DocumentType, openDocInfo.BuilderType);
            }
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
                docManager.OpenDocument(filePath, true);
            }
        }

        //
        // On Closing
        //
        protected override void OnClosing(CancelEventArgs e)
        {
            SaveConfig(e);

            base.OnClosing(e);
        }

        private void SaveConfig(CancelEventArgs e = null)
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

                lastOpenDocs[a] = new SavedDocument()
                {
                    FullFilePath = doc.FullFilePath,
                    IsTemporary = doc.IsTemporary,
                    DocumentSettings = new DocumentSettings() { DocType = doc.DocType, BuilderType = doc.BuilderType, Custom = doc.CustomBuild }
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
                    if (e != null)
                        e.Cancel = true;

                    return;
                }
            }

            // Set last documents and last index
            Config.LastOpenDocuments = lastOpenDocs;
            Config.LastSelectedTabIndex = docManager.CurrIndex;

            // Store last window width and height
            //Config.Width =  RestoreBounds.Width; 
            //Config.Height = RestoreBounds.Height;

            if (WindowState == FormWindowState.Maximized)
            {
                //Properties.Settings.Default.Location = RestoreBounds.Location;
                Config.PosX = RestoreBounds.X;
                Config.PosY = RestoreBounds.Y;
                Config.Width = RestoreBounds.Width;
                Config.Height = RestoreBounds.Height;
                Config.Maximized = true;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                //Properties.Settings.Default.Location = Location;
                Config.PosX = this.Location.X;
                Config.PosY = this.Location.Y;
                Config.Width = this.Width;
                Config.Height = this.Height;
                Config.Maximized = false;
            }

            // Splitter distance
            Config.SplitterDistance = splitContainer.SplitterDistance;

            // Save config file
            Config.Save();

            // TODO: close all pending process but needs to view revied later
            //CmdRun.KillAllProcess_TODO_FIX();
        }

        private void OnStartPressed()
        {
            BuildAndRun();
        }
        private void OnReloadPressed()
        {
            Build();
        }

        private void OnAboutPressed(object sender, EventArgs e)
        {
            AboutUI about = new AboutUI();
            about.ShowMe(this);
        }

        private void OnDebugSyntaxColorChangerPressed(object sender, EventArgs e)
        {
            if (sender == syntaxColorChangerToolStripMenuItem)
            {
                SyntaxColorChanger colorChanger = new SyntaxColorChanger();
                colorChanger.Setup(CurrEditor, CurrDocumentTab.Document);
                colorChanger.Show();
            }
        }

        private void OnDebugCurrDocument(object sender, EventArgs e)
        {
            XConsole.Println(CurrDocument.FullFilePath);
            XConsole.Println(CurrDocument.FileName);
            XConsole.Println($"CustomBuild: {CurrDocument.CustomBuild}, BuildType: {CurrDocument.BuilderType}");

            Builder.Builder builder;

            if (CurrDocument.CustomBuild)
                builder = CustomBuilders.GetBuilder(CurrDocument.FullFilePath, CurrDocument.BuilderType);
            else
                builder = Builders.GetBuilder(CurrDocument.BuilderType);

            builder.Prepare();

            XConsole.Println("----------- custom builder -----------");
            XConsole.Println("projDir: " + builder.GetProjectDir());
        }

        private void OnDebugLoggerPressed(object sender, EventArgs e)
        {
            XConsole.Detach(false);
        }

        private void OnDebugOpenAppFolder(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", AppInfo.BasePath);
        }

        private void FullScreenToggle()
        {
            FullScreen = !FullScreen;
        }

        private void OnJSonViewerPressed(object sender, EventArgs e)
        {
            //TreeViewTester.ShowJson(json);
            //JSonViewer.ShowJson();
            JSonViewer.Open();
        }



        private void OnTreeViewTester(object sender, EventArgs e)
        {
            TreeViewTester.ShowJson("");
        }

        private void OnResetConfigFile(object sender, EventArgs e)
        {
            // Reset the config file
            Config.CreateNew();
            Config.Save();

            // Do not pass through 'OnClosing(CancelEventArgs e)'
            Application.Exit();
        }

        private void OnConfigResetConfigFile(object sender, EventArgs e)
        {
            var result = MsgBox.Show("Reset Config?", "This will reset all program configurations and also will close all 'temporary' and 'non temporary' files. 'Compilers and Interpreters' paths will be removed.\n\nDo you want to continue?", DialogButtons.YesNoCancel, DialogIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Reset the config file
                Config.CreateNew();
                Config.Save();

                // Do not pass through 'OnClosing(CancelEventArgs e)'
                Application.Exit();
            }
        }

        private void OnWorkspaceDebugPressed(object sender, EventArgs e)
        {
            WorkspaceInfo workspaceInfo = BuilderUtils.GetWorkspaceInfo(CurrDocument.FullFilePath);

            if (workspaceInfo != null)
            {
                string fromPath = workspaceInfo.RootDirFullPath;
                string json = File.ReadAllText(workspaceInfo.WorkspaceFullFilePath);
                JSonViewer.ShowJson(json);
                //XConsole.Println("info: " + workspaceInfo.ToString());
            }
        }

        private void OnConfigFileDebugPressed(object sender, EventArgs e)
        {
            string json = File.ReadAllText(AppInfo.ConfigFileName);
            JSonViewer.ShowJson(json);
        }

        private void OnSetupCompilersInterpreters(object sender, EventArgs e)
        {
            BuildToolSelector buildToolSelector = new BuildToolSelector();
            buildToolSelector.ShowMe(this);
        }

        private void OnDebugBuildersPressed(object sender, EventArgs e)
        {
            BuilderDebugger debugger = new BuilderDebugger();
            debugger.Show();
        }


    }
}
