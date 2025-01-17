namespace VampirioCode
{
    partial class App
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(App));
            footer = new UI.FooterUI();
            splitContainer = new SplitContainer();
            docManager = new VampDocManager.DocManager();
            xconsole = new UI.XConsole();
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            newProjectToolStripMenuItem = new ToolStripMenuItem();
            cToolStripMenuItem = new ToolStripMenuItem();
            sDL2ToolStripMenuItem = new ToolStripMenuItem();
            basicToolStripMenuItem = new ToolStripMenuItem();
            basicCodeToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            basicMaincToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripSeparator();
            basicMaincppToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripSeparator();
            jSBasicCodeToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripSeparator();
            jAVABasicProgramToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem6 = new ToolStripSeparator();
            pHPBasicProgramToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem7 = new ToolStripSeparator();
            hTMLBasicPageToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            closeAllToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();
            cutToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            renameToolStripMenuItem = new ToolStripMenuItem();
            languageToolStripMenuItem = new ToolStripMenuItem();
            csharpToolStripMenuItem = new ToolStripMenuItem();
            cppToolStripMenuItem = new ToolStripMenuItem();
            jsToolStripMenuItem = new ToolStripMenuItem();
            javaToolStripMenuItem = new ToolStripMenuItem();
            phpToolStripMenuItem = new ToolStripMenuItem();
            htmlToolStripMenuItem = new ToolStripMenuItem();
            cmakeToolStripMenuItem = new ToolStripMenuItem();
            builderToolStripMenuItem = new ToolStripMenuItem();
            builderSettingsToolStripMenuItem = new ToolStripMenuItem();
            setupBuildToolStripMenuItem = new ToolStripMenuItem();
            clearBuildSettingsToolStripMenuItem = new ToolStripMenuItem();
            moveBuildToolStripMenuItem = new ToolStripMenuItem();
            configToolStripMenuItem = new ToolStripMenuItem();
            setupCompilersInterpreterToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            debugToolStripMenuItem = new ToolStripMenuItem();
            syntaxColorChangerToolStripMenuItem = new ToolStripMenuItem();
            debugCurrDocumentToolStripMenuItem = new ToolStripMenuItem();
            loggerToolStripMenuItem = new ToolStripMenuItem();
            openAppFolderToolStripMenuItem = new ToolStripMenuItem();
            jsonViewerToolStripMenuItem = new ToolStripMenuItem();
            jsonTesterToolStripMenuItem = new ToolStripMenuItem();
            workspaceDebugToolStripMenuItem = new ToolStripMenuItem();
            configDebugToolStripMenuItem = new ToolStripMenuItem();
            debugBuildersToolStripMenuItem = new ToolStripMenuItem();
            resetConfigFileToolStripMenuItem = new ToolStripMenuItem();
            toolBar = new UI.ToolBar();
            configResetConfigFileToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // footer
            // 
            footer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            footer.BackColor = Color.FromArgb(20, 20, 20);
            footer.Location = new Point(4, 505);
            footer.Margin = new Padding(3, 2, 3, 2);
            footer.Name = "footer";
            footer.Size = new Size(693, 20);
            footer.TabIndex = 2;
            // 
            // splitContainer
            // 
            splitContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer.BackColor = Color.FromArgb(30, 30, 30);
            splitContainer.Location = new Point(4, 53);
            splitContainer.Margin = new Padding(0);
            splitContainer.Name = "splitContainer";
            splitContainer.Orientation = Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(docManager);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(xconsole);
            splitContainer.Size = new Size(693, 452);
            splitContainer.SplitterDistance = 339;
            splitContainer.SplitterWidth = 3;
            splitContainer.TabIndex = 3;
            // 
            // docManager
            // 
            docManager.CurrIndex = -1;
            docManager.Dock = DockStyle.Fill;
            docManager.Location = new Point(0, 0);
            docManager.Margin = new Padding(3, 2, 3, 2);
            docManager.Name = "docManager";
            docManager.Size = new Size(693, 339);
            docManager.TabIndex = 0;
            // 
            // xconsole
            // 
            xconsole.BackColor = Color.FromArgb(30, 30, 30);
            xconsole.Location = new Point(0, 1);
            xconsole.Margin = new Padding(3, 2, 3, 2);
            xconsole.Name = "xconsole";
            xconsole.Size = new Size(693, 108);
            xconsole.TabIndex = 0;
            // 
            // menuStrip
            // 
            menuStrip.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            menuStrip.AutoSize = false;
            menuStrip.Dock = DockStyle.None;
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, languageToolStripMenuItem, builderToolStripMenuItem, builderSettingsToolStripMenuItem, configToolStripMenuItem, helpToolStripMenuItem, debugToolStripMenuItem });
            menuStrip.Location = new Point(4, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(5, 2, 0, 2);
            menuStrip.Size = new Size(693, 27);
            menuStrip.TabIndex = 4;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, newProjectToolStripMenuItem, basicCodeToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, closeToolStripMenuItem, closeAllToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 23);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.ForeColor = Color.Silver;
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(132, 22);
            newToolStripMenuItem.Tag = "new";
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += OnFilePressed;
            // 
            // newProjectToolStripMenuItem
            // 
            newProjectToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cToolStripMenuItem });
            newProjectToolStripMenuItem.ForeColor = Color.Silver;
            newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            newProjectToolStripMenuItem.Size = new Size(132, 22);
            newProjectToolStripMenuItem.Text = "New Build";
            // 
            // cToolStripMenuItem
            // 
            cToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sDL2ToolStripMenuItem, basicToolStripMenuItem });
            cToolStripMenuItem.ForeColor = Color.Silver;
            cToolStripMenuItem.Name = "cToolStripMenuItem";
            cToolStripMenuItem.Size = new Size(98, 22);
            cToolStripMenuItem.Text = "C++";
            // 
            // sDL2ToolStripMenuItem
            // 
            sDL2ToolStripMenuItem.ForeColor = Color.Silver;
            sDL2ToolStripMenuItem.Name = "sDL2ToolStripMenuItem";
            sDL2ToolStripMenuItem.Size = new Size(101, 22);
            sDL2ToolStripMenuItem.Tag = "cpp_msvc_sdl2";
            sDL2ToolStripMenuItem.Text = "SDL2";
            sDL2ToolStripMenuItem.Click += OnCustomBuildPressed;
            // 
            // basicToolStripMenuItem
            // 
            basicToolStripMenuItem.ForeColor = Color.Silver;
            basicToolStripMenuItem.Name = "basicToolStripMenuItem";
            basicToolStripMenuItem.Size = new Size(101, 22);
            basicToolStripMenuItem.Tag = "cpp_gnu_gpp_wsl_basic";
            basicToolStripMenuItem.Text = "Basic";
            basicToolStripMenuItem.Click += OnCustomBuildPressed;
            // 
            // basicCodeToolStripMenuItem
            // 
            basicCodeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, basicMaincToolStripMenuItem, toolStripMenuItem3, basicMaincppToolStripMenuItem, toolStripMenuItem4, jSBasicCodeToolStripMenuItem, toolStripMenuItem5, jAVABasicProgramToolStripMenuItem, toolStripMenuItem6, pHPBasicProgramToolStripMenuItem, toolStripMenuItem7, hTMLBasicPageToolStripMenuItem });
            basicCodeToolStripMenuItem.ForeColor = Color.Silver;
            basicCodeToolStripMenuItem.Name = "basicCodeToolStripMenuItem";
            basicCodeToolStripMenuItem.Size = new Size(132, 22);
            basicCodeToolStripMenuItem.Text = "Basic Code";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(179, 6);
            // 
            // basicMaincToolStripMenuItem
            // 
            basicMaincToolStripMenuItem.ForeColor = Color.Silver;
            basicMaincToolStripMenuItem.Name = "basicMaincToolStripMenuItem";
            basicMaincToolStripMenuItem.Size = new Size(182, 22);
            basicMaincToolStripMenuItem.Tag = "cpp_basic_main";
            basicMaincToolStripMenuItem.Text = "C++ Basic main.cpp";
            basicMaincToolStripMenuItem.Click += OnBasicCodePressed;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(179, 6);
            // 
            // basicMaincppToolStripMenuItem
            // 
            basicMaincppToolStripMenuItem.ForeColor = Color.Silver;
            basicMaincppToolStripMenuItem.Name = "basicMaincppToolStripMenuItem";
            basicMaincppToolStripMenuItem.Size = new Size(182, 22);
            basicMaincppToolStripMenuItem.Tag = "csharp_basic_main";
            basicMaincppToolStripMenuItem.Text = "C# Basic Program.cs";
            basicMaincppToolStripMenuItem.Click += OnBasicCodePressed;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(179, 6);
            // 
            // jSBasicCodeToolStripMenuItem
            // 
            jSBasicCodeToolStripMenuItem.ForeColor = Color.Silver;
            jSBasicCodeToolStripMenuItem.Name = "jSBasicCodeToolStripMenuItem";
            jSBasicCodeToolStripMenuItem.Size = new Size(182, 22);
            jSBasicCodeToolStripMenuItem.Tag = "js_basic_script";
            jSBasicCodeToolStripMenuItem.Text = "JS Basic Script";
            jSBasicCodeToolStripMenuItem.Click += OnBasicCodePressed;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.ForeColor = Color.Silver;
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(179, 6);
            // 
            // jAVABasicProgramToolStripMenuItem
            // 
            jAVABasicProgramToolStripMenuItem.ForeColor = Color.Silver;
            jAVABasicProgramToolStripMenuItem.Name = "jAVABasicProgramToolStripMenuItem";
            jAVABasicProgramToolStripMenuItem.Size = new Size(182, 22);
            jAVABasicProgramToolStripMenuItem.Tag = "java_basic_program";
            jAVABasicProgramToolStripMenuItem.Text = "JAVA Basic Program";
            jAVABasicProgramToolStripMenuItem.Click += OnBasicCodePressed;
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.ForeColor = Color.Silver;
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new Size(179, 6);
            // 
            // pHPBasicProgramToolStripMenuItem
            // 
            pHPBasicProgramToolStripMenuItem.ForeColor = Color.Silver;
            pHPBasicProgramToolStripMenuItem.Name = "pHPBasicProgramToolStripMenuItem";
            pHPBasicProgramToolStripMenuItem.Size = new Size(182, 22);
            pHPBasicProgramToolStripMenuItem.Tag = "php_basic_program";
            pHPBasicProgramToolStripMenuItem.Text = "PHP Basic Program";
            pHPBasicProgramToolStripMenuItem.Click += OnBasicCodePressed;
            // 
            // toolStripMenuItem7
            // 
            toolStripMenuItem7.ForeColor = Color.Silver;
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            toolStripMenuItem7.Size = new Size(179, 6);
            // 
            // hTMLBasicPageToolStripMenuItem
            // 
            hTMLBasicPageToolStripMenuItem.ForeColor = Color.Silver;
            hTMLBasicPageToolStripMenuItem.Name = "hTMLBasicPageToolStripMenuItem";
            hTMLBasicPageToolStripMenuItem.Size = new Size(182, 22);
            hTMLBasicPageToolStripMenuItem.Tag = "html_basic_page";
            hTMLBasicPageToolStripMenuItem.Text = "HTML Basic Page";
            hTMLBasicPageToolStripMenuItem.Click += OnBasicCodePressed;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.ForeColor = Color.Silver;
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(132, 22);
            openToolStripMenuItem.Tag = "open";
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += OnFilePressed;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.ForeColor = Color.Silver;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(132, 22);
            saveToolStripMenuItem.Tag = "save";
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += OnFilePressed;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.ForeColor = Color.Silver;
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(132, 22);
            saveAsToolStripMenuItem.Tag = "save_as";
            saveAsToolStripMenuItem.Text = "Save As...";
            saveAsToolStripMenuItem.Click += OnFilePressed;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.ForeColor = Color.Silver;
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(132, 22);
            closeToolStripMenuItem.Tag = "close";
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += OnFilePressed;
            // 
            // closeAllToolStripMenuItem
            // 
            closeAllToolStripMenuItem.ForeColor = Color.Silver;
            closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            closeAllToolStripMenuItem.Size = new Size(132, 22);
            closeAllToolStripMenuItem.Tag = "close_all";
            closeAllToolStripMenuItem.Text = "Close All";
            closeAllToolStripMenuItem.Click += OnFilePressed;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.ForeColor = Color.Silver;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(132, 22);
            exitToolStripMenuItem.Tag = "exit";
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += OnFilePressed;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem, cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, toolStripMenuItem1, renameToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 23);
            editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.ForeColor = Color.Silver;
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.Size = new Size(117, 22);
            undoToolStripMenuItem.Tag = "undo";
            undoToolStripMenuItem.Text = "Undo";
            undoToolStripMenuItem.Click += OnEditPressed;
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.ForeColor = Color.Silver;
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.Size = new Size(117, 22);
            redoToolStripMenuItem.Tag = "redo";
            redoToolStripMenuItem.Text = "Redo";
            redoToolStripMenuItem.Click += OnEditPressed;
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.ForeColor = Color.Silver;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.Size = new Size(117, 22);
            cutToolStripMenuItem.Tag = "cut";
            cutToolStripMenuItem.Text = "Cut";
            cutToolStripMenuItem.Click += OnEditPressed;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.ForeColor = Color.Silver;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(117, 22);
            copyToolStripMenuItem.Tag = "copy";
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.Click += OnEditPressed;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.ForeColor = Color.Silver;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.Size = new Size(117, 22);
            pasteToolStripMenuItem.Tag = "paste";
            pasteToolStripMenuItem.Text = "Paste";
            pasteToolStripMenuItem.Click += OnEditPressed;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(114, 6);
            // 
            // renameToolStripMenuItem
            // 
            renameToolStripMenuItem.ForeColor = Color.Silver;
            renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            renameToolStripMenuItem.Size = new Size(117, 22);
            renameToolStripMenuItem.Tag = "rename";
            renameToolStripMenuItem.Text = "Rename";
            renameToolStripMenuItem.Click += OnEditPressed;
            // 
            // languageToolStripMenuItem
            // 
            languageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { csharpToolStripMenuItem, cppToolStripMenuItem, jsToolStripMenuItem, javaToolStripMenuItem, phpToolStripMenuItem, htmlToolStripMenuItem, cmakeToolStripMenuItem });
            languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            languageToolStripMenuItem.Size = new Size(71, 23);
            languageToolStripMenuItem.Text = "Language";
            // 
            // csharpToolStripMenuItem
            // 
            csharpToolStripMenuItem.ForeColor = Color.Silver;
            csharpToolStripMenuItem.Name = "csharpToolStripMenuItem";
            csharpToolStripMenuItem.Size = new Size(125, 22);
            csharpToolStripMenuItem.Text = "C#";
            csharpToolStripMenuItem.Click += OnLanguagePressed;
            // 
            // cppToolStripMenuItem
            // 
            cppToolStripMenuItem.ForeColor = Color.Silver;
            cppToolStripMenuItem.Name = "cppToolStripMenuItem";
            cppToolStripMenuItem.Size = new Size(125, 22);
            cppToolStripMenuItem.Text = "C++";
            cppToolStripMenuItem.Click += OnLanguagePressed;
            // 
            // jsToolStripMenuItem
            // 
            jsToolStripMenuItem.ForeColor = Color.Silver;
            jsToolStripMenuItem.Name = "jsToolStripMenuItem";
            jsToolStripMenuItem.Size = new Size(125, 22);
            jsToolStripMenuItem.Text = "Javascript";
            jsToolStripMenuItem.Click += OnLanguagePressed;
            // 
            // javaToolStripMenuItem
            // 
            javaToolStripMenuItem.ForeColor = Color.Silver;
            javaToolStripMenuItem.Name = "javaToolStripMenuItem";
            javaToolStripMenuItem.Size = new Size(125, 22);
            javaToolStripMenuItem.Text = "Java";
            javaToolStripMenuItem.Click += OnLanguagePressed;
            // 
            // phpToolStripMenuItem
            // 
            phpToolStripMenuItem.ForeColor = Color.Silver;
            phpToolStripMenuItem.Name = "phpToolStripMenuItem";
            phpToolStripMenuItem.Size = new Size(125, 22);
            phpToolStripMenuItem.Text = "PHP";
            phpToolStripMenuItem.Click += OnLanguagePressed;
            // 
            // htmlToolStripMenuItem
            // 
            htmlToolStripMenuItem.ForeColor = Color.Silver;
            htmlToolStripMenuItem.Name = "htmlToolStripMenuItem";
            htmlToolStripMenuItem.Size = new Size(125, 22);
            htmlToolStripMenuItem.Text = "HTML";
            htmlToolStripMenuItem.Click += OnLanguagePressed;
            // 
            // cmakeToolStripMenuItem
            // 
            cmakeToolStripMenuItem.ForeColor = Color.Silver;
            cmakeToolStripMenuItem.Name = "cmakeToolStripMenuItem";
            cmakeToolStripMenuItem.Size = new Size(125, 22);
            cmakeToolStripMenuItem.Text = "CMake";
            cmakeToolStripMenuItem.Click += OnLanguagePressed;
            // 
            // builderToolStripMenuItem
            // 
            builderToolStripMenuItem.Name = "builderToolStripMenuItem";
            builderToolStripMenuItem.Size = new Size(56, 23);
            builderToolStripMenuItem.Text = "Builder";
            // 
            // builderSettingsToolStripMenuItem
            // 
            builderSettingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { setupBuildToolStripMenuItem, clearBuildSettingsToolStripMenuItem, moveBuildToolStripMenuItem });
            builderSettingsToolStripMenuItem.Name = "builderSettingsToolStripMenuItem";
            builderSettingsToolStripMenuItem.Size = new Size(56, 23);
            builderSettingsToolStripMenuItem.Text = "Project";
            builderSettingsToolStripMenuItem.Click += OnProjectPressed;
            // 
            // setupBuildToolStripMenuItem
            // 
            setupBuildToolStripMenuItem.ForeColor = Color.Silver;
            setupBuildToolStripMenuItem.Name = "setupBuildToolStripMenuItem";
            setupBuildToolStripMenuItem.Size = new Size(171, 22);
            setupBuildToolStripMenuItem.Text = "Setup Build";
            setupBuildToolStripMenuItem.Click += OnSetupBuildPressed;
            // 
            // clearBuildSettingsToolStripMenuItem
            // 
            clearBuildSettingsToolStripMenuItem.ForeColor = Color.Silver;
            clearBuildSettingsToolStripMenuItem.Name = "clearBuildSettingsToolStripMenuItem";
            clearBuildSettingsToolStripMenuItem.Size = new Size(171, 22);
            clearBuildSettingsToolStripMenuItem.Text = "Clear Build Setting";
            clearBuildSettingsToolStripMenuItem.Click += OnClearBuildSettingPressed;
            // 
            // moveBuildToolStripMenuItem
            // 
            moveBuildToolStripMenuItem.ForeColor = Color.Silver;
            moveBuildToolStripMenuItem.Name = "moveBuildToolStripMenuItem";
            moveBuildToolStripMenuItem.Size = new Size(171, 22);
            moveBuildToolStripMenuItem.Text = "Move Build";
            moveBuildToolStripMenuItem.Click += OnMoveBuildPressed;
            // 
            // configToolStripMenuItem
            // 
            configToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { setupCompilersInterpreterToolStripMenuItem, configResetConfigFileToolStripMenuItem });
            configToolStripMenuItem.Name = "configToolStripMenuItem";
            configToolStripMenuItem.Size = new Size(55, 23);
            configToolStripMenuItem.Text = "Config";
            // 
            // setupCompilersInterpreterToolStripMenuItem
            // 
            setupCompilersInterpreterToolStripMenuItem.ForeColor = Color.Silver;
            setupCompilersInterpreterToolStripMenuItem.Name = "setupCompilersInterpreterToolStripMenuItem";
            setupCompilersInterpreterToolStripMenuItem.Size = new Size(230, 22);
            setupCompilersInterpreterToolStripMenuItem.Text = "Setup Compilers | Interpreters";
            setupCompilersInterpreterToolStripMenuItem.Click += OnSetupCompilersInterpreters;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 23);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.ForeColor = Color.Silver;
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(107, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += OnAboutPressed;
            // 
            // debugToolStripMenuItem
            // 
            debugToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { syntaxColorChangerToolStripMenuItem, debugCurrDocumentToolStripMenuItem, loggerToolStripMenuItem, openAppFolderToolStripMenuItem, jsonViewerToolStripMenuItem, jsonTesterToolStripMenuItem, workspaceDebugToolStripMenuItem, configDebugToolStripMenuItem, debugBuildersToolStripMenuItem, resetConfigFileToolStripMenuItem });
            debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            debugToolStripMenuItem.Size = new Size(54, 23);
            debugToolStripMenuItem.Text = "Debug";
            // 
            // syntaxColorChangerToolStripMenuItem
            // 
            syntaxColorChangerToolStripMenuItem.ForeColor = Color.Silver;
            syntaxColorChangerToolStripMenuItem.Name = "syntaxColorChangerToolStripMenuItem";
            syntaxColorChangerToolStripMenuItem.Size = new Size(191, 22);
            syntaxColorChangerToolStripMenuItem.Text = "Syntax Color Changer";
            syntaxColorChangerToolStripMenuItem.Click += OnDebugSyntaxColorChangerPressed;
            // 
            // debugCurrDocumentToolStripMenuItem
            // 
            debugCurrDocumentToolStripMenuItem.ForeColor = Color.Silver;
            debugCurrDocumentToolStripMenuItem.Name = "debugCurrDocumentToolStripMenuItem";
            debugCurrDocumentToolStripMenuItem.Size = new Size(191, 22);
            debugCurrDocumentToolStripMenuItem.Text = "Debug CurrDocument";
            debugCurrDocumentToolStripMenuItem.Click += OnDebugCurrDocument;
            // 
            // loggerToolStripMenuItem
            // 
            loggerToolStripMenuItem.ForeColor = Color.Silver;
            loggerToolStripMenuItem.Name = "loggerToolStripMenuItem";
            loggerToolStripMenuItem.Size = new Size(191, 22);
            loggerToolStripMenuItem.Text = "Logger";
            loggerToolStripMenuItem.Click += OnDebugLoggerPressed;
            // 
            // openAppFolderToolStripMenuItem
            // 
            openAppFolderToolStripMenuItem.ForeColor = Color.Silver;
            openAppFolderToolStripMenuItem.Name = "openAppFolderToolStripMenuItem";
            openAppFolderToolStripMenuItem.Size = new Size(191, 22);
            openAppFolderToolStripMenuItem.Text = "Open App Folder";
            openAppFolderToolStripMenuItem.Click += OnDebugOpenAppFolder;
            // 
            // jsonViewerToolStripMenuItem
            // 
            jsonViewerToolStripMenuItem.ForeColor = Color.Silver;
            jsonViewerToolStripMenuItem.Name = "jsonViewerToolStripMenuItem";
            jsonViewerToolStripMenuItem.Size = new Size(191, 22);
            jsonViewerToolStripMenuItem.Text = "Json Viewer";
            jsonViewerToolStripMenuItem.Click += OnJSonViewerPressed;
            // 
            // jsonTesterToolStripMenuItem
            // 
            jsonTesterToolStripMenuItem.ForeColor = Color.Silver;
            jsonTesterToolStripMenuItem.Name = "jsonTesterToolStripMenuItem";
            jsonTesterToolStripMenuItem.Size = new Size(191, 22);
            jsonTesterToolStripMenuItem.Text = "Tree View Tester";
            jsonTesterToolStripMenuItem.Click += OnTreeViewTester;
            // 
            // workspaceDebugToolStripMenuItem
            // 
            workspaceDebugToolStripMenuItem.ForeColor = Color.Silver;
            workspaceDebugToolStripMenuItem.Name = "workspaceDebugToolStripMenuItem";
            workspaceDebugToolStripMenuItem.Size = new Size(191, 22);
            workspaceDebugToolStripMenuItem.Text = "WORKSPACE debug";
            workspaceDebugToolStripMenuItem.Click += OnWorkspaceDebugPressed;
            // 
            // configDebugToolStripMenuItem
            // 
            configDebugToolStripMenuItem.ForeColor = Color.Silver;
            configDebugToolStripMenuItem.Name = "configDebugToolStripMenuItem";
            configDebugToolStripMenuItem.Size = new Size(191, 22);
            configDebugToolStripMenuItem.Text = "CONFIG FILE debug";
            configDebugToolStripMenuItem.Click += OnConfigFileDebugPressed;
            // 
            // debugBuildersToolStripMenuItem
            // 
            debugBuildersToolStripMenuItem.ForeColor = Color.Silver;
            debugBuildersToolStripMenuItem.Name = "debugBuildersToolStripMenuItem";
            debugBuildersToolStripMenuItem.Size = new Size(191, 22);
            debugBuildersToolStripMenuItem.Text = "Debug Builders";
            debugBuildersToolStripMenuItem.Click += OnDebugBuildersPressed;
            // 
            // resetConfigFileToolStripMenuItem
            // 
            resetConfigFileToolStripMenuItem.ForeColor = Color.Silver;
            resetConfigFileToolStripMenuItem.Name = "resetConfigFileToolStripMenuItem";
            resetConfigFileToolStripMenuItem.Size = new Size(191, 22);
            resetConfigFileToolStripMenuItem.Text = "Reset Config File";
            resetConfigFileToolStripMenuItem.Click += OnResetConfigFile;
            // 
            // toolBar
            // 
            toolBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            toolBar.BackColor = Color.FromArgb(30, 30, 30);
            toolBar.Location = new Point(4, 27);
            toolBar.Margin = new Padding(3, 2, 3, 2);
            toolBar.Name = "toolBar";
            toolBar.Size = new Size(693, 27);
            toolBar.TabIndex = 5;
            // 
            // configResetConfigFileToolStripMenuItem
            // 
            configResetConfigFileToolStripMenuItem.ForeColor = Color.Silver;
            configResetConfigFileToolStripMenuItem.Name = "configResetConfigFileToolStripMenuItem";
            configResetConfigFileToolStripMenuItem.Size = new Size(230, 22);
            configResetConfigFileToolStripMenuItem.Text = "Reset Config File";
            configResetConfigFileToolStripMenuItem.Click += OnConfigResetConfigFile;
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            ClientSize = new Size(700, 525);
            Controls.Add(toolBar);
            Controls.Add(splitContainer);
            Controls.Add(footer);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(317, 280);
            Name = "App";
            Text = "Vampirio Code";
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private UI.FooterUI footer;
        private SplitContainer splitContainer;
        private VampDocManager.DocManager docManager;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem closeAllToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private UI.ToolBar toolBar;
        private ToolStripMenuItem languageToolStripMenuItem;
        private ToolStripMenuItem csharpToolStripMenuItem;
        private ToolStripMenuItem cppToolStripMenuItem;
        private ToolStripMenuItem jsToolStripMenuItem;
        private ToolStripMenuItem phpToolStripMenuItem;
        private ToolStripMenuItem builderToolStripMenuItem;
        private ToolStripMenuItem cmakeToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem javaToolStripMenuItem;
        private ToolStripMenuItem debugToolStripMenuItem;
        private ToolStripMenuItem syntaxColorChangerToolStripMenuItem;
        private ToolStripMenuItem htmlToolStripMenuItem;
        private ToolStripMenuItem newProjectToolStripMenuItem;
        private ToolStripMenuItem cToolStripMenuItem;
        private ToolStripMenuItem sDL2ToolStripMenuItem;
        private ToolStripMenuItem builderSettingsToolStripMenuItem;
        private ToolStripMenuItem setupBuildToolStripMenuItem;
        private ToolStripMenuItem debugCurrDocumentToolStripMenuItem;
        private ToolStripMenuItem clearBuildSettingsToolStripMenuItem;
        private ToolStripMenuItem basicToolStripMenuItem;
        private ToolStripMenuItem loggerToolStripMenuItem;
        private ToolStripMenuItem openAppFolderToolStripMenuItem;
        private ToolStripMenuItem resetConfigFileToolStripMenuItem;
        private ToolStripMenuItem jsonViewerToolStripMenuItem;
        private ToolStripMenuItem jsonTesterToolStripMenuItem;
        private ToolStripMenuItem basicCodeToolStripMenuItem;
        private ToolStripMenuItem moveBuildToolStripMenuItem;
        private ToolStripMenuItem workspaceDebugToolStripMenuItem;
        private ToolStripMenuItem configDebugToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem renameToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem basicMaincToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem basicMaincppToolStripMenuItem;
        private ToolStripMenuItem configToolStripMenuItem;
        private ToolStripMenuItem setupCompilersInterpreterToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripMenuItem jSBasicCodeToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem5;
        private ToolStripMenuItem jAVABasicProgramToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem6;
        private ToolStripMenuItem pHPBasicProgramToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem7;
        private ToolStripMenuItem hTMLBasicPageToolStripMenuItem;
        private ToolStripMenuItem debugBuildersToolStripMenuItem;
        private UI.XConsole xconsole;
        private ToolStripMenuItem configResetConfigFileToolStripMenuItem;
    }
}
