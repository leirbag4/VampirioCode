namespace VampirioCode.UI
{
    partial class JSonViewer
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
            treeViewAdv = new Controls.TreeViewAdv();
            consoleOutp = new XConsole();
            convertButton = new Controls.ButtonAdv();
            input = new RichTextBox();
            buttonAdv1 = new Controls.ButtonAdv();
            buttonAdv2 = new Controls.ButtonAdv();
            SuspendLayout();
            // 
            // treeViewAdv
            // 
            treeViewAdv.AllowTextEdition = true;
            treeViewAdv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            treeViewAdv.BackColor = Color.FromArgb(31, 31, 13);
            treeViewAdv.LinesColor = Color.FromArgb(100, 100, 100);
            treeViewAdv.Location = new Point(265, 7);
            treeViewAdv.MarginLeft = 5;
            treeViewAdv.MarginTop = 5;
            treeViewAdv.Name = "treeViewAdv";
            treeViewAdv.NodeHeight = 20;
            treeViewAdv.NodeIndent = 20;
            treeViewAdv.ScrollBarSize = 21;
            treeViewAdv.ScrollX = 0;
            treeViewAdv.ScrollY = 0;
            treeViewAdv.SelectedBackColor = Color.FromArgb(68, 68, 68);
            treeViewAdv.SelectedBorderColor = Color.FromArgb(119, 119, 119);
            treeViewAdv.Size = new Size(570, 389);
            treeViewAdv.TabIndex = 2;
            treeViewAdv.Text = "treeViewAdv1";
            treeViewAdv.TextSpace = 5;
            // 
            // consoleOutp
            // 
            consoleOutp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            consoleOutp.BackColor = Color.FromArgb(40, 40, 40);
            consoleOutp.Location = new Point(12, 402);
            consoleOutp.Name = "consoleOutp";
            consoleOutp.Size = new Size(816, 114);
            consoleOutp.TabIndex = 3;
            // 
            // convertButton
            // 
            convertButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            convertButton.BackColor = Color.FromArgb(20, 20, 20);
            convertButton.BorderColor = Color.FromArgb(70, 70, 70);
            convertButton.BorderSize = 1;
            convertButton.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            convertButton.expandImage = false;
            convertButton.extraText = "";
            convertButton.extraTextAlign = ContentAlignment.MiddleCenter;
            convertButton.extraTextColor = Color.Black;
            convertButton.extraTextFont = null;
            convertButton.extraTextOffset = new Point(0, 0);
            convertButton.FocusColor = Color.FromArgb(24, 81, 115);
            convertButton.FocusEnabled = false;
            convertButton.ForeColor = Color.Silver;
            convertButton.Location = new Point(12, 324);
            convertButton.Name = "convertButton";
            convertButton.PaintImageOnSelected = true;
            convertButton.processEnterKey = true;
            convertButton.resizeImage = new Point(0, 0);
            convertButton.Selected = false;
            convertButton.SelectedColor = Color.FromArgb(0, 122, 204);
            convertButton.Size = new Size(244, 35);
            convertButton.TabIndex = 15;
            convertButton.Text = "convert";
            convertButton.UseVisualStyleBackColor = false;
            convertButton.Click += OnConvertPressed;
            // 
            // input
            // 
            input.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            input.BackColor = Color.FromArgb(30, 30, 30);
            input.BorderStyle = BorderStyle.None;
            input.ForeColor = Color.Silver;
            input.Location = new Point(12, 7);
            input.Name = "input";
            input.Size = new Size(247, 313);
            input.TabIndex = 16;
            input.Text = "";
            // 
            // buttonAdv1
            // 
            buttonAdv1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAdv1.BackColor = Color.FromArgb(20, 20, 20);
            buttonAdv1.BorderColor = Color.FromArgb(70, 70, 70);
            buttonAdv1.BorderSize = 1;
            buttonAdv1.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            buttonAdv1.expandImage = false;
            buttonAdv1.extraText = "";
            buttonAdv1.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv1.extraTextColor = Color.Black;
            buttonAdv1.extraTextFont = null;
            buttonAdv1.extraTextOffset = new Point(0, 0);
            buttonAdv1.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv1.FocusEnabled = false;
            buttonAdv1.ForeColor = Color.Silver;
            buttonAdv1.Location = new Point(12, 361);
            buttonAdv1.Name = "buttonAdv1";
            buttonAdv1.PaintImageOnSelected = true;
            buttonAdv1.processEnterKey = true;
            buttonAdv1.resizeImage = new Point(0, 0);
            buttonAdv1.Selected = false;
            buttonAdv1.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv1.Size = new Size(116, 35);
            buttonAdv1.TabIndex = 17;
            buttonAdv1.Text = "beautify";
            buttonAdv1.UseVisualStyleBackColor = false;
            buttonAdv1.Click += OnBeautifyPressed;
            // 
            // buttonAdv2
            // 
            buttonAdv2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAdv2.BackColor = Color.FromArgb(20, 20, 20);
            buttonAdv2.BorderColor = Color.FromArgb(70, 70, 70);
            buttonAdv2.BorderSize = 1;
            buttonAdv2.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            buttonAdv2.expandImage = false;
            buttonAdv2.extraText = "";
            buttonAdv2.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv2.extraTextColor = Color.Black;
            buttonAdv2.extraTextFont = null;
            buttonAdv2.extraTextOffset = new Point(0, 0);
            buttonAdv2.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv2.FocusEnabled = false;
            buttonAdv2.ForeColor = Color.Silver;
            buttonAdv2.Location = new Point(134, 361);
            buttonAdv2.Name = "buttonAdv2";
            buttonAdv2.PaintImageOnSelected = true;
            buttonAdv2.processEnterKey = true;
            buttonAdv2.resizeImage = new Point(0, 0);
            buttonAdv2.Selected = false;
            buttonAdv2.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv2.Size = new Size(122, 35);
            buttonAdv2.TabIndex = 18;
            buttonAdv2.Text = "<--";
            buttonAdv2.UseVisualStyleBackColor = false;
            buttonAdv2.Click += OnTreeViewToJsonPressed;
            // 
            // JSonViewer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 528);
            Controls.Add(buttonAdv2);
            Controls.Add(buttonAdv1);
            Controls.Add(input);
            Controls.Add(convertButton);
            Controls.Add(consoleOutp);
            Controls.Add(treeViewAdv);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "JSonViewer";
            Text = "JSonViewer";
            ResumeLayout(false);
        }

        #endregion

        private Controls.TreeViewAdv treeViewAdv;
        private XConsole consoleOutp;
        private Controls.ButtonAdv convertButton;
        private RichTextBox input;
        private Controls.ButtonAdv buttonAdv1;
        private Controls.ButtonAdv buttonAdv2;
    }
}