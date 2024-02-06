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
            clearButton = new UI.Controls.ButtonAdv();
            xconsole = new UI.XConsole();
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
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
            languageToolStripMenuItem = new ToolStripMenuItem();
            csharpToolStripMenuItem = new ToolStripMenuItem();
            cppToolStripMenuItem = new ToolStripMenuItem();
            jsToolStripMenuItem = new ToolStripMenuItem();
            phpToolStripMenuItem = new ToolStripMenuItem();
            toolBar = new UI.ToolBar();
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
            footer.Location = new Point(4, 673);
            footer.Name = "footer";
            footer.Size = new Size(792, 26);
            footer.TabIndex = 2;
            // 
            // splitContainer
            // 
            splitContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer.BackColor = Color.FromArgb(30, 30, 30);
            splitContainer.Location = new Point(4, 60);
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
            splitContainer.Panel2.Controls.Add(clearButton);
            splitContainer.Panel2.Controls.Add(xconsole);
            splitContainer.Size = new Size(792, 615);
            splitContainer.SplitterDistance = 462;
            splitContainer.TabIndex = 3;
            // 
            // docManager
            // 
            docManager.CurrIndex = -1;
            docManager.Dock = DockStyle.Fill;
            docManager.Location = new Point(0, 0);
            docManager.Name = "docManager";
            docManager.Size = new Size(792, 462);
            docManager.TabIndex = 0;
            // 
            // clearButton
            // 
            clearButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            clearButton.BorderColor = Color.FromArgb(20, 20, 20);
            clearButton.BorderSize = 1;
            clearButton.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            clearButton.expandImage = false;
            clearButton.extraText = "";
            clearButton.extraTextAlign = ContentAlignment.MiddleCenter;
            clearButton.extraTextColor = Color.Black;
            clearButton.extraTextFont = null;
            clearButton.extraTextOffset = new Point(0, 0);
            clearButton.FocusColor = Color.FromArgb(24, 81, 115);
            clearButton.FocusEnabled = false;
            clearButton.ForeColor = Color.Silver;
            clearButton.Location = new Point(719, 2);
            clearButton.Name = "clearButton";
            clearButton.PaintImageOnSelected = true;
            clearButton.processEnterKey = true;
            clearButton.resizeImage = new Point(0, 0);
            clearButton.Selected = false;
            clearButton.SelectedColor = Color.FromArgb(0, 122, 204);
            clearButton.Size = new Size(69, 22);
            clearButton.TabIndex = 1;
            clearButton.Text = "clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += OnClearPressed;
            // 
            // xconsole
            // 
            xconsole.BackColor = Color.FromArgb(40, 40, 40);
            xconsole.Dock = DockStyle.Fill;
            xconsole.Location = new Point(0, 0);
            xconsole.Name = "xconsole";
            xconsole.Size = new Size(792, 149);
            xconsole.TabIndex = 0;
            // 
            // menuStrip
            // 
            menuStrip.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            menuStrip.AutoSize = false;
            menuStrip.Dock = DockStyle.None;
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, languageToolStripMenuItem });
            menuStrip.Location = new Point(4, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(792, 28);
            menuStrip.TabIndex = 4;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, closeToolStripMenuItem, closeAllToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.ForeColor = Color.Silver;
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(152, 26);
            newToolStripMenuItem.Tag = "new";
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += OnFilePressed;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.ForeColor = Color.Silver;
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(152, 26);
            openToolStripMenuItem.Tag = "open";
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += OnFilePressed;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.ForeColor = Color.Silver;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(152, 26);
            saveToolStripMenuItem.Tag = "save";
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += OnFilePressed;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.ForeColor = Color.Silver;
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(152, 26);
            saveAsToolStripMenuItem.Tag = "save_as";
            saveAsToolStripMenuItem.Text = "Save As...";
            saveAsToolStripMenuItem.Click += OnFilePressed;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.ForeColor = Color.Silver;
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(152, 26);
            closeToolStripMenuItem.Tag = "close";
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += OnFilePressed;
            // 
            // closeAllToolStripMenuItem
            // 
            closeAllToolStripMenuItem.ForeColor = Color.Silver;
            closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            closeAllToolStripMenuItem.Size = new Size(152, 26);
            closeAllToolStripMenuItem.Tag = "close_all";
            closeAllToolStripMenuItem.Text = "Close All";
            closeAllToolStripMenuItem.Click += OnFilePressed;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.ForeColor = Color.Silver;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(152, 26);
            exitToolStripMenuItem.Tag = "exit";
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += OnFilePressed;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem, cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(49, 24);
            editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.ForeColor = Color.Silver;
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.Size = new Size(128, 26);
            undoToolStripMenuItem.Tag = "undo";
            undoToolStripMenuItem.Text = "Undo";
            undoToolStripMenuItem.Click += OnEditPressed;
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.ForeColor = Color.Silver;
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.Size = new Size(128, 26);
            redoToolStripMenuItem.Tag = "redo";
            redoToolStripMenuItem.Text = "Redo";
            redoToolStripMenuItem.Click += OnEditPressed;
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.ForeColor = Color.Silver;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.Size = new Size(128, 26);
            cutToolStripMenuItem.Tag = "cut";
            cutToolStripMenuItem.Text = "Cut";
            cutToolStripMenuItem.Click += OnEditPressed;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.ForeColor = Color.Silver;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(128, 26);
            copyToolStripMenuItem.Tag = "copy";
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.Click += OnEditPressed;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.ForeColor = Color.Silver;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.Size = new Size(128, 26);
            pasteToolStripMenuItem.Tag = "paste";
            pasteToolStripMenuItem.Text = "Paste";
            pasteToolStripMenuItem.Click += OnEditPressed;
            // 
            // languageToolStripMenuItem
            // 
            languageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { csharpToolStripMenuItem, cppToolStripMenuItem, jsToolStripMenuItem, phpToolStripMenuItem });
            languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            languageToolStripMenuItem.Size = new Size(88, 24);
            languageToolStripMenuItem.Text = "Language";
            // 
            // csharpToolStripMenuItem
            // 
            csharpToolStripMenuItem.ForeColor = Color.Silver;
            csharpToolStripMenuItem.Name = "csharpToolStripMenuItem";
            csharpToolStripMenuItem.Size = new Size(156, 26);
            csharpToolStripMenuItem.Text = "C#";
            csharpToolStripMenuItem.Click += OnLanguagePressed;
            // 
            // cppToolStripMenuItem
            // 
            cppToolStripMenuItem.ForeColor = Color.Silver;
            cppToolStripMenuItem.Name = "cppToolStripMenuItem";
            cppToolStripMenuItem.Size = new Size(156, 26);
            cppToolStripMenuItem.Text = "C++";
            cppToolStripMenuItem.Click += OnLanguagePressed;
            // 
            // jsToolStripMenuItem
            // 
            jsToolStripMenuItem.ForeColor = Color.Silver;
            jsToolStripMenuItem.Name = "jsToolStripMenuItem";
            jsToolStripMenuItem.Size = new Size(156, 26);
            jsToolStripMenuItem.Text = "Javascript";
            jsToolStripMenuItem.Click += OnLanguagePressed;
            // 
            // phpToolStripMenuItem
            // 
            phpToolStripMenuItem.ForeColor = Color.Silver;
            phpToolStripMenuItem.Name = "phpToolStripMenuItem";
            phpToolStripMenuItem.Size = new Size(156, 26);
            phpToolStripMenuItem.Text = "PHP";
            phpToolStripMenuItem.Click += OnLanguagePressed;
            // 
            // toolBar
            // 
            toolBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            toolBar.BackColor = Color.FromArgb(30, 30, 30);
            toolBar.Location = new Point(4, 28);
            toolBar.Name = "toolBar";
            toolBar.Size = new Size(792, 32);
            toolBar.TabIndex = 5;
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            ClientSize = new Size(800, 700);
            Controls.Add(toolBar);
            Controls.Add(splitContainer);
            Controls.Add(footer);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            MinimumSize = new Size(360, 360);
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
        private UI.XConsole xconsole;
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
        private UI.Controls.ButtonAdv clearButton;
        private ToolStripMenuItem languageToolStripMenuItem;
        private ToolStripMenuItem csharpToolStripMenuItem;
        private ToolStripMenuItem cppToolStripMenuItem;
        private ToolStripMenuItem jsToolStripMenuItem;
        private ToolStripMenuItem phpToolStripMenuItem;
    }
}
