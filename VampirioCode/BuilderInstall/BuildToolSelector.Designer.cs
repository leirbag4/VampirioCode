namespace VampirioCode.BuilderInstall
{
    partial class BuildToolSelector
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
            okButton = new VampirioCode.UI.Controls.ButtonAdv();
            list = new VampirioCode.UI.Controls.VerticalItemListAdv();
            outp = new RichTextBox();
            buildContainer = new Panel();
            SuspendLayout();
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
            okButton.Location = new Point(825, 531);
            okButton.Name = "okButton";
            okButton.PaintImageOnSelected = true;
            okButton.processEnterKey = true;
            okButton.resizeImage = new Point(0, 0);
            okButton.Selected = false;
            okButton.SelectedColor = Color.FromArgb(0, 122, 204);
            okButton.Size = new Size(106, 30);
            okButton.TabIndex = 25;
            okButton.Text = "Ok";
            okButton.UseVisualStyleBackColor = false;
            // 
            // list
            // 
            list.AllowPressedEvents = true;
            list.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            list.BackColor = Color.FromArgb(54, 54, 54);
            list.ItemHeight = 35;
            list.ItemHeightType = VampirioCode.UI.Controls.VerticalItemList.HeightType.FIXED_SIZE;
            list.Location = new Point(12, 12);
            list.Name = "list";
            list.SelectedIndex = -1;
            list.SelectionEnable = true;
            list.Size = new Size(237, 513);
            list.TabIndex = 26;
            // 
            // outp
            // 
            outp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            outp.BackColor = Color.FromArgb(30, 30, 30);
            outp.BorderStyle = BorderStyle.None;
            outp.ForeColor = Color.Silver;
            outp.Location = new Point(12, 531);
            outp.Name = "outp";
            outp.Size = new Size(919, 88);
            outp.TabIndex = 27;
            outp.Text = "";
            // 
            // buildContainer
            // 
            buildContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buildContainer.BackColor = Color.FromArgb(35, 35, 35);
            buildContainer.Location = new Point(255, 12);
            buildContainer.Name = "buildContainer";
            buildContainer.Size = new Size(676, 513);
            buildContainer.TabIndex = 28;
            // 
            // BuildToolSelector
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(943, 631);
            Controls.Add(buildContainer);
            Controls.Add(okButton);
            Controls.Add(outp);
            Controls.Add(list);
            Name = "BuildToolSelector";
            Text = "BuildToolSelector";
            ResumeLayout(false);
        }

        #endregion

        private VampirioCode.UI.Controls.ButtonAdv okButton;
        private VampirioCode.UI.Controls.VerticalItemListAdv list;
        private RichTextBox outp;
        private Panel buildContainer;
    }
}