namespace VampirioCode.BuilderSetting
{
    partial class CustomMsvcCppBuilderSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            includeDirsList = new ItemList();
            libraryDirsList = new ItemList();
            libraryFilesList = new ItemList();
            okButton = new VampirioCode.UI.Controls.ButtonAdv();
            cancelButton = new VampirioCode.UI.Controls.ButtonAdv();
            macrosList = new ItemList();
            labelAdv1 = new VampirioCode.UI.Controls.LabelAdv();
            exceptHandlModeCBox = new VampirioCode.UI.Controls.ComboBoxAdv();
            postCopyDirsList = new ItemList();
            postCopyFilesList = new ItemList();
            standardVersionCBox = new VampirioCode.UI.Controls.ComboBoxAdv();
            labelAdv3 = new VampirioCode.UI.Controls.LabelAdv();
            outputTypeCBox = new VampirioCode.UI.Controls.ComboBoxAdv();
            labelAdv4 = new VampirioCode.UI.Controls.LabelAdv();
            sourceFilesList = new UI.ItemListSources();
            outputNameInput = new TextBox();
            labelAdv5 = new VampirioCode.UI.Controls.LabelAdv();
            itemListPackages = new UI.ItemListPackages();
            SuspendLayout();
            // 
            // includeDirsList
            // 
            includeDirsList.BackColor = Color.FromArgb(40, 40, 40);
            includeDirsList.Enable = true;
            includeDirsList.Icon = Properties.Resources.mmenu_mini_folder;
            includeDirsList.Location = new Point(10, 9);
            includeDirsList.Margin = new Padding(3, 2, 3, 2);
            includeDirsList.Name = "includeDirsList";
            includeDirsList.Size = new Size(262, 194);
            includeDirsList.TabIndex = 10;
            includeDirsList.Title = "Include Dirs";
            // 
            // libraryDirsList
            // 
            libraryDirsList.BackColor = Color.FromArgb(40, 40, 40);
            libraryDirsList.Enable = true;
            libraryDirsList.Icon = Properties.Resources.mmenu_mini_folder;
            libraryDirsList.Location = new Point(277, 9);
            libraryDirsList.Margin = new Padding(3, 2, 3, 2);
            libraryDirsList.Name = "libraryDirsList";
            libraryDirsList.Size = new Size(262, 194);
            libraryDirsList.TabIndex = 11;
            libraryDirsList.Title = "Library Dirs";
            // 
            // libraryFilesList
            // 
            libraryFilesList.BackColor = Color.FromArgb(40, 40, 40);
            libraryFilesList.Enable = true;
            libraryFilesList.Icon = Properties.Resources.mmenu_mini_copy_path;
            libraryFilesList.Location = new Point(545, 9);
            libraryFilesList.Margin = new Padding(3, 2, 3, 2);
            libraryFilesList.Name = "libraryFilesList";
            libraryFilesList.Size = new Size(262, 194);
            libraryFilesList.TabIndex = 12;
            libraryFilesList.Title = "Library Files";
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            okButton.BackColor = Color.FromArgb(30, 30, 30);
            okButton.BorderColor = Color.FromArgb(10, 10, 10);
            okButton.BorderSize = 1;
            okButton.CStyle = VampirioCode.UI.Controls.ButtonAdv.CustomStyle.SOLID;
            okButton.expandImage = false;
            okButton.extraText = "";
            okButton.extraTextAlign = ContentAlignment.MiddleCenter;
            okButton.extraTextColor = Color.Black;
            okButton.extraTextFont = null;
            okButton.extraTextOffset = new Point(0, 0);
            okButton.FocusColor = Color.FromArgb(24, 81, 115);
            okButton.FocusEnabled = false;
            okButton.ForeColor = Color.Silver;
            okButton.Location = new Point(618, 464);
            okButton.Margin = new Padding(3, 2, 3, 2);
            okButton.Name = "okButton";
            okButton.PaintImageOnSelected = true;
            okButton.processEnterKey = true;
            okButton.resizeImage = new Point(0, 0);
            okButton.Selected = false;
            okButton.SelectedColor = Color.FromArgb(0, 122, 204);
            okButton.Size = new Size(93, 22);
            okButton.TabIndex = 24;
            okButton.Text = "Ok";
            okButton.UseVisualStyleBackColor = false;
            okButton.Click += OnOkPressed;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.BackColor = Color.FromArgb(30, 30, 30);
            cancelButton.BorderColor = Color.FromArgb(10, 10, 10);
            cancelButton.BorderSize = 1;
            cancelButton.CStyle = VampirioCode.UI.Controls.ButtonAdv.CustomStyle.SOLID;
            cancelButton.expandImage = false;
            cancelButton.extraText = "";
            cancelButton.extraTextAlign = ContentAlignment.MiddleCenter;
            cancelButton.extraTextColor = Color.Black;
            cancelButton.extraTextFont = null;
            cancelButton.extraTextOffset = new Point(0, 0);
            cancelButton.FocusColor = Color.FromArgb(24, 81, 115);
            cancelButton.FocusEnabled = false;
            cancelButton.ForeColor = Color.Silver;
            cancelButton.Location = new Point(716, 464);
            cancelButton.Margin = new Padding(3, 2, 3, 2);
            cancelButton.Name = "cancelButton";
            cancelButton.PaintImageOnSelected = true;
            cancelButton.processEnterKey = true;
            cancelButton.resizeImage = new Point(0, 0);
            cancelButton.Selected = false;
            cancelButton.SelectedColor = Color.FromArgb(0, 122, 204);
            cancelButton.Size = new Size(93, 22);
            cancelButton.TabIndex = 25;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += OnCancelPressed;
            // 
            // macrosList
            // 
            macrosList.BackColor = Color.FromArgb(40, 40, 40);
            macrosList.Enable = true;
            macrosList.Icon = Properties.Resources.omenu_mini_select_all;
            macrosList.Location = new Point(10, 333);
            macrosList.Margin = new Padding(3, 2, 3, 2);
            macrosList.Name = "macrosList";
            macrosList.Size = new Size(262, 121);
            macrosList.TabIndex = 26;
            macrosList.Title = "Preprocessor Directive Macros";
            // 
            // labelAdv1
            // 
            labelAdv1.AutoSize = true;
            labelAdv1.BorderColor = Color.DarkGray;
            labelAdv1.BorderSize = 1;
            labelAdv1.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv1.ForeColor = Color.Silver;
            labelAdv1.Location = new Point(452, 262);
            labelAdv1.ModifyClampMax = 0F;
            labelAdv1.ModifyClampMin = 0F;
            labelAdv1.ModifyControlName = "";
            labelAdv1.ModifyScale = 1F;
            labelAdv1.Name = "labelAdv1";
            labelAdv1.Size = new Size(148, 15);
            labelAdv1.TabIndex = 27;
            labelAdv1.Text = "Exception Handling Model";
            // 
            // exceptHandlModeCBox
            // 
            exceptHandlModeCBox.BackColor = Color.FromArgb(52, 52, 52);
            exceptHandlModeCBox.BorderColor = Color.FromArgb(100, 100, 100);
            exceptHandlModeCBox.BorderSize = 2;
            exceptHandlModeCBox.ButtonColor = SystemColors.Control;
            exceptHandlModeCBox.DropDownStyle = ComboBoxStyle.DropDownList;
            exceptHandlModeCBox.ForeColor = Color.Silver;
            exceptHandlModeCBox.FormattingEnabled = true;
            exceptHandlModeCBox.Location = new Point(452, 286);
            exceptHandlModeCBox.Margin = new Padding(3, 2, 3, 2);
            exceptHandlModeCBox.Name = "exceptHandlModeCBox";
            exceptHandlModeCBox.Size = new Size(163, 23);
            exceptHandlModeCBox.TabIndex = 28;
            // 
            // postCopyDirsList
            // 
            postCopyDirsList.BackColor = Color.FromArgb(40, 40, 40);
            postCopyDirsList.Enable = true;
            postCopyDirsList.Icon = Properties.Resources.mmenu_mini_folder_b;
            postCopyDirsList.Location = new Point(277, 333);
            postCopyDirsList.Margin = new Padding(3, 2, 3, 2);
            postCopyDirsList.Name = "postCopyDirsList";
            postCopyDirsList.Size = new Size(262, 121);
            postCopyDirsList.TabIndex = 31;
            postCopyDirsList.Title = "Post Copy Dirs";
            // 
            // postCopyFilesList
            // 
            postCopyFilesList.BackColor = Color.FromArgb(40, 40, 40);
            postCopyFilesList.Enable = true;
            postCopyFilesList.Icon = Properties.Resources.mmenu_mini_folder_b;
            postCopyFilesList.Location = new Point(547, 333);
            postCopyFilesList.Margin = new Padding(3, 2, 3, 2);
            postCopyFilesList.Name = "postCopyFilesList";
            postCopyFilesList.Size = new Size(262, 121);
            postCopyFilesList.TabIndex = 32;
            postCopyFilesList.Title = "Post Copy Files";
            // 
            // standardVersionCBox
            // 
            standardVersionCBox.BackColor = Color.FromArgb(52, 52, 52);
            standardVersionCBox.BorderColor = Color.FromArgb(100, 100, 100);
            standardVersionCBox.BorderSize = 2;
            standardVersionCBox.ButtonColor = SystemColors.Control;
            standardVersionCBox.DropDownStyle = ComboBoxStyle.DropDownList;
            standardVersionCBox.ForeColor = Color.Silver;
            standardVersionCBox.FormattingEnabled = true;
            standardVersionCBox.Location = new Point(297, 286);
            standardVersionCBox.Margin = new Padding(3, 2, 3, 2);
            standardVersionCBox.Name = "standardVersionCBox";
            standardVersionCBox.Size = new Size(106, 23);
            standardVersionCBox.TabIndex = 34;
            // 
            // labelAdv3
            // 
            labelAdv3.AutoSize = true;
            labelAdv3.BorderColor = Color.DarkGray;
            labelAdv3.BorderSize = 1;
            labelAdv3.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv3.ForeColor = Color.Silver;
            labelAdv3.Location = new Point(297, 262);
            labelAdv3.ModifyClampMax = 0F;
            labelAdv3.ModifyClampMin = 0F;
            labelAdv3.ModifyControlName = "";
            labelAdv3.ModifyScale = 1F;
            labelAdv3.Name = "labelAdv3";
            labelAdv3.Size = new Size(95, 15);
            labelAdv3.TabIndex = 33;
            labelAdv3.Text = "Standard Version";
            // 
            // outputTypeCBox
            // 
            outputTypeCBox.BackColor = Color.FromArgb(52, 52, 52);
            outputTypeCBox.BorderColor = Color.FromArgb(100, 100, 100);
            outputTypeCBox.BorderSize = 2;
            outputTypeCBox.ButtonColor = SystemColors.Control;
            outputTypeCBox.DropDownStyle = ComboBoxStyle.DropDownList;
            outputTypeCBox.ForeColor = Color.Silver;
            outputTypeCBox.FormattingEnabled = true;
            outputTypeCBox.Location = new Point(297, 231);
            outputTypeCBox.Margin = new Padding(3, 2, 3, 2);
            outputTypeCBox.Name = "outputTypeCBox";
            outputTypeCBox.Size = new Size(106, 23);
            outputTypeCBox.TabIndex = 36;
            // 
            // labelAdv4
            // 
            labelAdv4.AutoSize = true;
            labelAdv4.BorderColor = Color.DarkGray;
            labelAdv4.BorderSize = 1;
            labelAdv4.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv4.ForeColor = Color.Silver;
            labelAdv4.Location = new Point(297, 207);
            labelAdv4.ModifyClampMax = 0F;
            labelAdv4.ModifyClampMin = 0F;
            labelAdv4.ModifyControlName = "";
            labelAdv4.ModifyScale = 1F;
            labelAdv4.Name = "labelAdv4";
            labelAdv4.Size = new Size(72, 15);
            labelAdv4.TabIndex = 35;
            labelAdv4.Text = "Output Type";
            // 
            // sourceFilesList
            // 
            sourceFilesList.BackColor = Color.FromArgb(40, 40, 40);
            sourceFilesList.Enable = true;
            sourceFilesList.Icon = Properties.Resources.mmenu_mini_copy_path;
            sourceFilesList.Location = new Point(10, 207);
            sourceFilesList.Margin = new Padding(3, 2, 3, 2);
            sourceFilesList.Name = "sourceFilesList";
            sourceFilesList.Size = new Size(262, 119);
            sourceFilesList.TabIndex = 41;
            sourceFilesList.Title = "Source Files";
            // 
            // outputNameInput
            // 
            outputNameInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            outputNameInput.BackColor = Color.FromArgb(60, 60, 60);
            outputNameInput.BorderStyle = BorderStyle.FixedSingle;
            outputNameInput.ForeColor = Color.Silver;
            outputNameInput.Location = new Point(452, 231);
            outputNameInput.Margin = new Padding(3, 2, 3, 2);
            outputNameInput.Name = "outputNameInput";
            outputNameInput.Size = new Size(163, 23);
            outputNameInput.TabIndex = 42;
            // 
            // labelAdv5
            // 
            labelAdv5.AutoSize = true;
            labelAdv5.BorderColor = Color.DarkGray;
            labelAdv5.BorderSize = 1;
            labelAdv5.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv5.ForeColor = Color.Silver;
            labelAdv5.Location = new Point(452, 207);
            labelAdv5.ModifyClampMax = 0F;
            labelAdv5.ModifyClampMin = 0F;
            labelAdv5.ModifyControlName = "";
            labelAdv5.ModifyScale = 1F;
            labelAdv5.Name = "labelAdv5";
            labelAdv5.Size = new Size(80, 15);
            labelAdv5.TabIndex = 43;
            labelAdv5.Text = "Output Name";
            // 
            // itemListPackages
            // 
            itemListPackages.BackColor = Color.FromArgb(40, 40, 40);
            itemListPackages.Location = new Point(624, 207);
            itemListPackages.Margin = new Padding(3, 2, 3, 2);
            itemListPackages.Name = "itemListPackages";
            itemListPackages.Size = new Size(185, 119);
            itemListPackages.TabIndex = 44;
            // 
            // CustomMsvcCppBuilderSetting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(817, 494);
            Controls.Add(itemListPackages);
            Controls.Add(labelAdv5);
            Controls.Add(outputNameInput);
            Controls.Add(sourceFilesList);
            Controls.Add(outputTypeCBox);
            Controls.Add(labelAdv4);
            Controls.Add(standardVersionCBox);
            Controls.Add(labelAdv3);
            Controls.Add(postCopyFilesList);
            Controls.Add(postCopyDirsList);
            Controls.Add(exceptHandlModeCBox);
            Controls.Add(labelAdv1);
            Controls.Add(macrosList);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(libraryFilesList);
            Controls.Add(libraryDirsList);
            Controls.Add(includeDirsList);
            Margin = new Padding(3, 2, 3, 2);
            Name = "CustomMsvcCppBuilderSetting";
            Text = "Custom msvc settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ItemList includeDirsList;
        private ItemList libraryDirsList;
        private ItemList libraryFilesList;
        private VampirioCode.UI.Controls.ButtonAdv okButton;
        private VampirioCode.UI.Controls.ButtonAdv cancelButton;
        private ItemList macrosList;
        private VampirioCode.UI.Controls.LabelAdv labelAdv1;
        private VampirioCode.UI.Controls.ComboBoxAdv exceptHandlModeCBox;
        private ItemList postCopyDirsList;
        private ItemList postCopyFilesList;
        private VampirioCode.UI.Controls.ComboBoxAdv standardVersionCBox;
        private VampirioCode.UI.Controls.LabelAdv labelAdv3;
        private VampirioCode.UI.Controls.ComboBoxAdv outputTypeCBox;
        private VampirioCode.UI.Controls.LabelAdv labelAdv4;
        private UI.ItemListSources sourceFilesList;
        private TextBox outputNameInput;
        private VampirioCode.UI.Controls.LabelAdv labelAdv5;
        private UI.ItemListPackages itemListPackages;
    }
}