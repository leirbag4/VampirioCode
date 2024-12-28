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
            SuspendLayout();
            // 
            // treeViewAdv
            // 
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
            treeViewAdv.Size = new Size(570, 370);
            treeViewAdv.TabIndex = 2;
            treeViewAdv.Text = "treeViewAdv1";
            treeViewAdv.TextSpace = 5;
            // 
            // consoleOutp
            // 
            consoleOutp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            consoleOutp.BackColor = Color.FromArgb(40, 40, 40);
            consoleOutp.Location = new Point(12, 383);
            consoleOutp.Name = "consoleOutp";
            consoleOutp.Size = new Size(816, 114);
            consoleOutp.TabIndex = 3;
            // 
            // convertButton
            // 
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
            convertButton.Location = new Point(12, 342);
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
            input.BackColor = Color.FromArgb(30, 30, 30);
            input.BorderStyle = BorderStyle.None;
            input.ForeColor = Color.Silver;
            input.Location = new Point(12, 7);
            input.Name = "input";
            input.Size = new Size(247, 329);
            input.TabIndex = 16;
            input.Text = "";
            // 
            // JSonViewer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 509);
            Controls.Add(input);
            Controls.Add(convertButton);
            Controls.Add(consoleOutp);
            Controls.Add(treeViewAdv);
            Name = "JSonViewer";
            Text = "JSonViewer";
            ResumeLayout(false);
        }

        #endregion

        private Controls.TreeViewAdv treeViewAdv;
        private XConsole consoleOutp;
        private Controls.ButtonAdv convertButton;
        private RichTextBox input;
    }
}