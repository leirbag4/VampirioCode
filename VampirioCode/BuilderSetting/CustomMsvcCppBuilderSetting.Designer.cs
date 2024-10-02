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
            findPackageInput = new UI.FindPackageInput();
            labelAdv2 = new VampirioCode.UI.Controls.LabelAdv();
            postCopyDirsList = new ItemList();
            postCopyFilesList = new ItemList();
            SuspendLayout();
            // 
            // includeDirsList
            // 
            includeDirsList.BackColor = Color.FromArgb(40, 40, 40);
            includeDirsList.Icon = null;
            includeDirsList.Location = new Point(12, 12);
            includeDirsList.Name = "includeDirsList";
            includeDirsList.Size = new Size(299, 258);
            includeDirsList.TabIndex = 10;
            includeDirsList.Title = "Include Dirs";
            // 
            // libraryDirsList
            // 
            libraryDirsList.BackColor = Color.FromArgb(40, 40, 40);
            libraryDirsList.Icon = Properties.Resources.mmenu_mini_folder;
            libraryDirsList.Location = new Point(317, 12);
            libraryDirsList.Name = "libraryDirsList";
            libraryDirsList.Size = new Size(299, 258);
            libraryDirsList.TabIndex = 11;
            libraryDirsList.Title = "Library Dirs";
            // 
            // libraryFilesList
            // 
            libraryFilesList.BackColor = Color.FromArgb(40, 40, 40);
            libraryFilesList.Icon = Properties.Resources.mmenu_mini_copy_path;
            libraryFilesList.Location = new Point(623, 12);
            libraryFilesList.Name = "libraryFilesList";
            libraryFilesList.Size = new Size(299, 258);
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
            okButton.Location = new Point(706, 565);
            okButton.Name = "okButton";
            okButton.PaintImageOnSelected = true;
            okButton.processEnterKey = true;
            okButton.resizeImage = new Point(0, 0);
            okButton.Selected = false;
            okButton.SelectedColor = Color.FromArgb(0, 122, 204);
            okButton.Size = new Size(106, 30);
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
            cancelButton.Location = new Point(818, 565);
            cancelButton.Name = "cancelButton";
            cancelButton.PaintImageOnSelected = true;
            cancelButton.processEnterKey = true;
            cancelButton.resizeImage = new Point(0, 0);
            cancelButton.Selected = false;
            cancelButton.SelectedColor = Color.FromArgb(0, 122, 204);
            cancelButton.Size = new Size(106, 30);
            cancelButton.TabIndex = 25;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += OnCancelPressed;
            // 
            // macrosList
            // 
            macrosList.BackColor = Color.FromArgb(40, 40, 40);
            macrosList.Icon = Properties.Resources.omenu_mini_select_all;
            macrosList.Location = new Point(12, 287);
            macrosList.Name = "macrosList";
            macrosList.Size = new Size(299, 245);
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
            labelAdv1.Location = new Point(336, 287);
            labelAdv1.ModifyClampMax = 0F;
            labelAdv1.ModifyClampMin = 0F;
            labelAdv1.ModifyControlName = "";
            labelAdv1.ModifyScale = 1F;
            labelAdv1.Name = "labelAdv1";
            labelAdv1.Size = new Size(186, 20);
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
            exceptHandlModeCBox.Location = new Point(336, 319);
            exceptHandlModeCBox.Name = "exceptHandlModeCBox";
            exceptHandlModeCBox.Size = new Size(186, 28);
            exceptHandlModeCBox.TabIndex = 28;
            // 
            // findPackageInput
            // 
            findPackageInput.BackColor = Color.FromArgb(40, 40, 40);
            findPackageInput.Location = new Point(595, 314);
            findPackageInput.Name = "findPackageInput";
            findPackageInput.SelectedPackage = "";
            findPackageInput.Size = new Size(164, 35);
            findPackageInput.TabIndex = 29;
            // 
            // labelAdv2
            // 
            labelAdv2.AutoSize = true;
            labelAdv2.BorderColor = Color.DarkGray;
            labelAdv2.BorderSize = 1;
            labelAdv2.CStyle = VampirioCode.UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv2.ForeColor = Color.Silver;
            labelAdv2.Location = new Point(595, 287);
            labelAdv2.ModifyClampMax = 0F;
            labelAdv2.ModifyClampMin = 0F;
            labelAdv2.ModifyControlName = "";
            labelAdv2.ModifyScale = 1F;
            labelAdv2.Name = "labelAdv2";
            labelAdv2.Size = new Size(106, 20);
            labelAdv2.TabIndex = 30;
            labelAdv2.Text = "Install Package";
            // 
            // postCopyDirsList
            // 
            postCopyDirsList.BackColor = Color.FromArgb(40, 40, 40);
            postCopyDirsList.Icon = null;
            postCopyDirsList.Location = new Point(317, 371);
            postCopyDirsList.Name = "postCopyDirsList";
            postCopyDirsList.Size = new Size(299, 161);
            postCopyDirsList.TabIndex = 31;
            postCopyDirsList.Title = "Post Copy Dirs";
            // 
            // postCopyFilesList
            // 
            postCopyFilesList.BackColor = Color.FromArgb(40, 40, 40);
            postCopyFilesList.Icon = null;
            postCopyFilesList.Location = new Point(625, 371);
            postCopyFilesList.Name = "postCopyFilesList";
            postCopyFilesList.Size = new Size(299, 161);
            postCopyFilesList.TabIndex = 32;
            postCopyFilesList.Title = "Post Copy Files";
            // 
            // CustomMsvcCppBuilderSetting
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(934, 607);
            Controls.Add(postCopyFilesList);
            Controls.Add(postCopyDirsList);
            Controls.Add(labelAdv2);
            Controls.Add(findPackageInput);
            Controls.Add(exceptHandlModeCBox);
            Controls.Add(labelAdv1);
            Controls.Add(macrosList);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(libraryFilesList);
            Controls.Add(libraryDirsList);
            Controls.Add(includeDirsList);
            Name = "CustomMsvcCppBuilderSetting";
            Text = "SimpleCppBuilderSetting";
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
        private UI.FindPackageInput findPackageInput;
        private VampirioCode.UI.Controls.LabelAdv labelAdv2;
        private ItemList postCopyDirsList;
        private ItemList postCopyFilesList;
    }
}