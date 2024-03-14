namespace VampirioCode.Tests
{
    partial class ScrollTester
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
            components = new System.ComponentModel.Container();
            console = new UI.XConsole();
            vscrollBar = new UI.Controls.ScrollBarAdv();
            hscrollBar = new UI.Controls.ScrollBarAdv();
            labelAdv1 = new UI.Controls.LabelAdv();
            labelAdv2 = new UI.Controls.LabelAdv();
            maximumInput = new UI.Controls.DecimalTextBox();
            minimumInput = new UI.Controls.DecimalTextBox();
            smallChangeInput = new UI.Controls.DecimalTextBox();
            labelAdv3 = new UI.Controls.LabelAdv();
            largeChangeInput = new UI.Controls.DecimalTextBox();
            labelAdv4 = new UI.Controls.LabelAdv();
            hscrollBarOrig = new HScrollBar();
            hscrollOrigOutp = new UI.Controls.DecimalTextBox();
            hscrollOutp = new UI.Controls.DecimalTextBox();
            hscrollXOutp = new UI.Controls.DecimalTextBox();
            hscrollBarX = new UI.Controls.ScrollBarX();
            vscrollBarX = new UI.Controls.ScrollBarX();
            buttonAdv1 = new UI.Controls.ButtonAdv();
            buttonAdv2 = new UI.Controls.ButtonAdv();
            buttonAdv3 = new UI.Controls.ButtonAdv();
            buttonAdv4 = new UI.Controls.ButtonAdv();
            SuspendLayout();
            // 
            // console
            // 
            console.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            console.BackColor = Color.FromArgb(40, 40, 40);
            console.Location = new Point(12, 333);
            console.Name = "console";
            console.Size = new Size(667, 193);
            console.TabIndex = 8;
            // 
            // vscrollBar
            // 
            vscrollBar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            vscrollBar.ArrowColor = Color.FromArgb(200, 200, 200);
            vscrollBar.BackgroundColor = Color.FromArgb(70, 70, 70);
            vscrollBar.BorderColorAdv = Color.Black;
            vscrollBar.BorderColorDisabled = Color.Gray;
            vscrollBar.BordersVisible = false;
            vscrollBar.ButtonDownColor = Color.FromArgb(120, 120, 120);
            vscrollBar.ButtonNormalColor = Color.FromArgb(70, 70, 70);
            vscrollBar.ButtonOverColor = Color.FromArgb(140, 140, 140);
            vscrollBar.Location = new Point(588, 21);
            vscrollBar.Name = "vscrollBar";
            vscrollBar.Size = new Size(19, 263);
            vscrollBar.TabIndex = 9;
            vscrollBar.Text = "scrollBarAdv1";
            vscrollBar.ThumbDownColor = Color.FromArgb(100, 100, 100);
            vscrollBar.ThumbNormalColor = Color.FromArgb(130, 130, 130);
            vscrollBar.ThumbOverColor = Color.FromArgb(120, 120, 120);
            vscrollBar.TrackColor = Color.FromArgb(110, 110, 110);
            // 
            // hscrollBar
            // 
            hscrollBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            hscrollBar.ArrowColor = Color.FromArgb(200, 200, 200);
            hscrollBar.BackgroundColor = Color.FromArgb(70, 70, 70);
            hscrollBar.BorderColorAdv = Color.Black;
            hscrollBar.BorderColorDisabled = Color.Gray;
            hscrollBar.BordersVisible = false;
            hscrollBar.ButtonDownColor = Color.FromArgb(120, 120, 120);
            hscrollBar.ButtonNormalColor = Color.FromArgb(70, 70, 70);
            hscrollBar.ButtonOverColor = Color.FromArgb(140, 140, 140);
            hscrollBar.Location = new Point(30, 21);
            hscrollBar.Name = "hscrollBar";
            hscrollBar.Orientation = UI.Controls.ScrollBarManagement.ScrollBarOrientation.Horizontal;
            hscrollBar.Size = new Size(373, 19);
            hscrollBar.TabIndex = 10;
            hscrollBar.Text = "scrollBarAdv2";
            hscrollBar.ThumbDownColor = Color.FromArgb(100, 100, 100);
            hscrollBar.ThumbNormalColor = Color.FromArgb(130, 130, 130);
            hscrollBar.ThumbOverColor = Color.FromArgb(120, 120, 120);
            hscrollBar.TrackColor = Color.FromArgb(110, 110, 110);
            hscrollBar.Scroll += OnHScrollChanged;
            // 
            // labelAdv1
            // 
            labelAdv1.AutoSize = true;
            labelAdv1.BorderColor = Color.DarkGray;
            labelAdv1.BorderSize = 1;
            labelAdv1.CStyle = UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv1.ForeColor = Color.Silver;
            labelAdv1.Location = new Point(138, 176);
            labelAdv1.ModifyClampMax = 0F;
            labelAdv1.ModifyClampMin = 0F;
            labelAdv1.ModifyControlName = "";
            labelAdv1.ModifyScale = 1F;
            labelAdv1.Name = "labelAdv1";
            labelAdv1.Size = new Size(72, 20);
            labelAdv1.TabIndex = 12;
            labelAdv1.Text = "Minimum";
            // 
            // labelAdv2
            // 
            labelAdv2.AutoSize = true;
            labelAdv2.BorderColor = Color.DarkGray;
            labelAdv2.BorderSize = 1;
            labelAdv2.CStyle = UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv2.ForeColor = Color.Silver;
            labelAdv2.Location = new Point(138, 211);
            labelAdv2.ModifyClampMax = 0F;
            labelAdv2.ModifyClampMin = 0F;
            labelAdv2.ModifyControlName = "";
            labelAdv2.ModifyScale = 1F;
            labelAdv2.Name = "labelAdv2";
            labelAdv2.Size = new Size(75, 20);
            labelAdv2.TabIndex = 14;
            labelAdv2.Text = "Maximum";
            // 
            // maximumInput
            // 
            maximumInput.AllowEmptyInput = false;
            maximumInput.Location = new Point(28, 208);
            maximumInput.MaxDecimalPlaces = 0;
            maximumInput.Name = "maximumInput";
            maximumInput.Size = new Size(104, 27);
            maximumInput.TabIndex = 13;
            maximumInput.UseNegativeValues = false;
            maximumInput.EnterPressed += OnInputEnterPressed;
            maximumInput.TextChanged += OnInputTextChanged;
            // 
            // minimumInput
            // 
            minimumInput.AllowEmptyInput = false;
            minimumInput.Location = new Point(28, 175);
            minimumInput.MaxDecimalPlaces = 0;
            minimumInput.Name = "minimumInput";
            minimumInput.Size = new Size(104, 27);
            minimumInput.TabIndex = 15;
            minimumInput.UseNegativeValues = false;
            minimumInput.EnterPressed += OnInputEnterPressed;
            minimumInput.TextChanged += OnInputTextChanged;
            // 
            // smallChangeInput
            // 
            smallChangeInput.AllowEmptyInput = false;
            smallChangeInput.Location = new Point(28, 241);
            smallChangeInput.MaxDecimalPlaces = 0;
            smallChangeInput.Name = "smallChangeInput";
            smallChangeInput.Size = new Size(104, 27);
            smallChangeInput.TabIndex = 19;
            smallChangeInput.UseNegativeValues = false;
            smallChangeInput.EnterPressed += OnInputEnterPressed;
            smallChangeInput.TextChanged += OnInputTextChanged;
            // 
            // labelAdv3
            // 
            labelAdv3.AutoSize = true;
            labelAdv3.BorderColor = Color.DarkGray;
            labelAdv3.BorderSize = 1;
            labelAdv3.CStyle = UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv3.ForeColor = Color.Silver;
            labelAdv3.Location = new Point(138, 277);
            labelAdv3.ModifyClampMax = 0F;
            labelAdv3.ModifyClampMin = 0F;
            labelAdv3.ModifyControlName = "";
            labelAdv3.ModifyScale = 1F;
            labelAdv3.Name = "labelAdv3";
            labelAdv3.Size = new Size(96, 20);
            labelAdv3.TabIndex = 18;
            labelAdv3.Text = "LargeChange";
            // 
            // largeChangeInput
            // 
            largeChangeInput.AllowEmptyInput = false;
            largeChangeInput.Location = new Point(28, 274);
            largeChangeInput.MaxDecimalPlaces = 0;
            largeChangeInput.Name = "largeChangeInput";
            largeChangeInput.Size = new Size(104, 27);
            largeChangeInput.TabIndex = 17;
            largeChangeInput.UseNegativeValues = false;
            largeChangeInput.EnterPressed += OnInputEnterPressed;
            largeChangeInput.TextChanged += OnInputTextChanged;
            // 
            // labelAdv4
            // 
            labelAdv4.AutoSize = true;
            labelAdv4.BorderColor = Color.DarkGray;
            labelAdv4.BorderSize = 1;
            labelAdv4.CStyle = UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv4.ForeColor = Color.Silver;
            labelAdv4.Location = new Point(138, 242);
            labelAdv4.ModifyClampMax = 0F;
            labelAdv4.ModifyClampMin = 0F;
            labelAdv4.ModifyControlName = "";
            labelAdv4.ModifyScale = 1F;
            labelAdv4.Name = "labelAdv4";
            labelAdv4.Size = new Size(96, 20);
            labelAdv4.TabIndex = 16;
            labelAdv4.Text = "SmallChange";
            // 
            // hscrollBarOrig
            // 
            hscrollBarOrig.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            hscrollBarOrig.Location = new Point(30, 66);
            hscrollBarOrig.Name = "hscrollBarOrig";
            hscrollBarOrig.Size = new Size(373, 26);
            hscrollBarOrig.TabIndex = 20;
            hscrollBarOrig.Scroll += OnHScrollOrigChanged;
            // 
            // hscrollOrigOutp
            // 
            hscrollOrigOutp.AllowEmptyInput = false;
            hscrollOrigOutp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            hscrollOrigOutp.Location = new Point(423, 66);
            hscrollOrigOutp.MaxDecimalPlaces = 0;
            hscrollOrigOutp.Name = "hscrollOrigOutp";
            hscrollOrigOutp.Size = new Size(104, 27);
            hscrollOrigOutp.TabIndex = 22;
            hscrollOrigOutp.UseNegativeValues = false;
            // 
            // hscrollOutp
            // 
            hscrollOutp.AllowEmptyInput = false;
            hscrollOutp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            hscrollOutp.Location = new Point(423, 17);
            hscrollOutp.MaxDecimalPlaces = 0;
            hscrollOutp.Name = "hscrollOutp";
            hscrollOutp.Size = new Size(104, 27);
            hscrollOutp.TabIndex = 21;
            hscrollOutp.UseNegativeValues = false;
            // 
            // hscrollXOutp
            // 
            hscrollXOutp.AllowEmptyInput = false;
            hscrollXOutp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            hscrollXOutp.Location = new Point(423, 115);
            hscrollXOutp.MaxDecimalPlaces = 0;
            hscrollXOutp.Name = "hscrollXOutp";
            hscrollXOutp.Size = new Size(104, 27);
            hscrollXOutp.TabIndex = 23;
            hscrollXOutp.UseNegativeValues = false;
            // 
            // hscrollBarX
            // 
            hscrollBarX.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            hscrollBarX.ArrowColor = Color.FromArgb(200, 200, 200);
            hscrollBarX.BackgroundColor = Color.FromArgb(70, 70, 70);
            hscrollBarX.BorderColor = Color.Black;
            hscrollBarX.BorderColorDisabled = Color.Gray;
            hscrollBarX.BordersVisible = false;
            hscrollBarX.ButtonDownColor = Color.FromArgb(100, 100, 100);
            hscrollBarX.ButtonNormalColor = Color.FromArgb(70, 70, 70);
            hscrollBarX.ButtonOverColor = Color.FromArgb(140, 140, 140);
            hscrollBarX.ButtonSize = 20;
            hscrollBarX.LargeChange = 10;
            hscrollBarX.Location = new Point(30, 115);
            hscrollBarX.Maximum = 100;
            hscrollBarX.Minimum = 0;
            hscrollBarX.Name = "hscrollBarX";
            hscrollBarX.Orientation = UI.Controls.ScrollBarMan.ScrollBarOrientation.Horizontal;
            hscrollBarX.Size = new Size(373, 27);
            hscrollBarX.SmallChange = 1;
            hscrollBarX.TabIndex = 24;
            hscrollBarX.Text = "scrollBarx1";
            hscrollBarX.ThumbDownColor = Color.FromArgb(100, 100, 100);
            hscrollBarX.ThumbNormalColor = Color.FromArgb(130, 130, 130);
            hscrollBarX.ThumbOverColor = Color.FromArgb(120, 120, 120);
            hscrollBarX.TrackDownColor = Color.FromArgb(70, 70, 70);
            hscrollBarX.TrackNormalColor = Color.FromArgb(50, 50, 50);
            hscrollBarX.TrackOverColor = Color.FromArgb(60, 60, 60);
            hscrollBarX.Value = 0;
            hscrollBarX.Scroll += OnHScrollXChanged;
            // 
            // vscrollBarX
            // 
            vscrollBarX.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            vscrollBarX.ArrowColor = Color.FromArgb(200, 200, 200);
            vscrollBarX.BackgroundColor = Color.FromArgb(70, 70, 70);
            vscrollBarX.BorderColor = Color.Black;
            vscrollBarX.BorderColorDisabled = Color.Gray;
            vscrollBarX.BordersVisible = false;
            vscrollBarX.ButtonDownColor = Color.FromArgb(100, 100, 100);
            vscrollBarX.ButtonNormalColor = Color.FromArgb(70, 70, 70);
            vscrollBarX.ButtonOverColor = Color.FromArgb(140, 140, 140);
            vscrollBarX.ButtonSize = 20;
            vscrollBarX.LargeChange = 10;
            vscrollBarX.Location = new Point(629, 21);
            vscrollBarX.Maximum = 100;
            vscrollBarX.Minimum = 0;
            vscrollBarX.Name = "vscrollBarX";
            vscrollBarX.Orientation = UI.Controls.ScrollBarMan.ScrollBarOrientation.Vertical;
            vscrollBarX.Size = new Size(23, 263);
            vscrollBarX.SmallChange = 1;
            vscrollBarX.TabIndex = 25;
            vscrollBarX.Text = "scrollBarx2";
            vscrollBarX.ThumbDownColor = Color.FromArgb(100, 100, 100);
            vscrollBarX.ThumbNormalColor = Color.FromArgb(130, 130, 130);
            vscrollBarX.ThumbOverColor = Color.FromArgb(120, 120, 120);
            vscrollBarX.TrackDownColor = Color.FromArgb(70, 70, 70);
            vscrollBarX.TrackNormalColor = Color.FromArgb(50, 50, 50);
            vscrollBarX.TrackOverColor = Color.FromArgb(60, 60, 60);
            vscrollBarX.Value = 0;
            // 
            // buttonAdv1
            // 
            buttonAdv1.BorderColor = Color.DarkGray;
            buttonAdv1.BorderSize = 1;
            buttonAdv1.CStyle = UI.Controls.ButtonAdv.CustomStyle.NORMAL;
            buttonAdv1.expandImage = false;
            buttonAdv1.extraText = "";
            buttonAdv1.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv1.extraTextColor = Color.Black;
            buttonAdv1.extraTextFont = null;
            buttonAdv1.extraTextOffset = new Point(0, 0);
            buttonAdv1.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv1.FocusEnabled = false;
            buttonAdv1.Location = new Point(423, 167);
            buttonAdv1.Name = "buttonAdv1";
            buttonAdv1.PaintImageOnSelected = true;
            buttonAdv1.processEnterKey = true;
            buttonAdv1.resizeImage = new Point(0, 0);
            buttonAdv1.Selected = false;
            buttonAdv1.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv1.Size = new Size(104, 29);
            buttonAdv1.TabIndex = 26;
            buttonAdv1.Text = "Set Value";
            buttonAdv1.UseVisualStyleBackColor = true;
            buttonAdv1.Click += OnSetValuePressed;
            // 
            // buttonAdv2
            // 
            buttonAdv2.BorderColor = Color.DarkGray;
            buttonAdv2.BorderSize = 1;
            buttonAdv2.CStyle = UI.Controls.ButtonAdv.CustomStyle.NORMAL;
            buttonAdv2.expandImage = false;
            buttonAdv2.extraText = "";
            buttonAdv2.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv2.extraTextColor = Color.Black;
            buttonAdv2.extraTextFont = null;
            buttonAdv2.extraTextOffset = new Point(0, 0);
            buttonAdv2.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv2.FocusEnabled = false;
            buttonAdv2.Location = new Point(423, 211);
            buttonAdv2.Name = "buttonAdv2";
            buttonAdv2.PaintImageOnSelected = true;
            buttonAdv2.processEnterKey = true;
            buttonAdv2.resizeImage = new Point(0, 0);
            buttonAdv2.Selected = false;
            buttonAdv2.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv2.Size = new Size(104, 29);
            buttonAdv2.TabIndex = 27;
            buttonAdv2.Text = "Read Values";
            buttonAdv2.UseVisualStyleBackColor = true;
            buttonAdv2.Click += OnReadValuesPressed;
            // 
            // buttonAdv3
            // 
            buttonAdv3.BorderColor = Color.DarkGray;
            buttonAdv3.BorderSize = 1;
            buttonAdv3.CStyle = UI.Controls.ButtonAdv.CustomStyle.NORMAL;
            buttonAdv3.expandImage = false;
            buttonAdv3.extraText = "";
            buttonAdv3.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv3.extraTextColor = Color.Black;
            buttonAdv3.extraTextFont = null;
            buttonAdv3.extraTextOffset = new Point(0, 0);
            buttonAdv3.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv3.FocusEnabled = false;
            buttonAdv3.Location = new Point(533, 65);
            buttonAdv3.Name = "buttonAdv3";
            buttonAdv3.PaintImageOnSelected = true;
            buttonAdv3.processEnterKey = true;
            buttonAdv3.resizeImage = new Point(0, 0);
            buttonAdv3.Selected = false;
            buttonAdv3.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv3.Size = new Size(42, 29);
            buttonAdv3.TabIndex = 28;
            buttonAdv3.Text = "Set Value";
            buttonAdv3.UseVisualStyleBackColor = true;
            buttonAdv3.Click += OnSetOriginalPressed;
            // 
            // buttonAdv4
            // 
            buttonAdv4.BorderColor = Color.DarkGray;
            buttonAdv4.BorderSize = 1;
            buttonAdv4.CStyle = UI.Controls.ButtonAdv.CustomStyle.NORMAL;
            buttonAdv4.expandImage = false;
            buttonAdv4.extraText = "";
            buttonAdv4.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv4.extraTextColor = Color.Black;
            buttonAdv4.extraTextFont = null;
            buttonAdv4.extraTextOffset = new Point(0, 0);
            buttonAdv4.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv4.FocusEnabled = false;
            buttonAdv4.Location = new Point(533, 16);
            buttonAdv4.Name = "buttonAdv4";
            buttonAdv4.PaintImageOnSelected = true;
            buttonAdv4.processEnterKey = true;
            buttonAdv4.resizeImage = new Point(0, 0);
            buttonAdv4.Selected = false;
            buttonAdv4.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv4.Size = new Size(42, 29);
            buttonAdv4.TabIndex = 29;
            buttonAdv4.Text = "Set Value";
            buttonAdv4.UseVisualStyleBackColor = true;
            buttonAdv4.Click += OnSetAdvPressed;
            // 
            // ScrollTester
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            ClientSize = new Size(691, 538);
            Controls.Add(buttonAdv4);
            Controls.Add(buttonAdv3);
            Controls.Add(buttonAdv2);
            Controls.Add(buttonAdv1);
            Controls.Add(vscrollBarX);
            Controls.Add(hscrollBarX);
            Controls.Add(hscrollXOutp);
            Controls.Add(hscrollOrigOutp);
            Controls.Add(hscrollOutp);
            Controls.Add(hscrollBarOrig);
            Controls.Add(smallChangeInput);
            Controls.Add(labelAdv3);
            Controls.Add(largeChangeInput);
            Controls.Add(labelAdv4);
            Controls.Add(minimumInput);
            Controls.Add(labelAdv2);
            Controls.Add(maximumInput);
            Controls.Add(labelAdv1);
            Controls.Add(hscrollBar);
            Controls.Add(vscrollBar);
            Controls.Add(console);
            Name = "ScrollTester";
            Text = "ScrollTester";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UI.XConsole console;
        private UI.Controls.ScrollBarAdv vscrollBar;
        private UI.Controls.ScrollBarAdv hscrollBar;
        private UI.Controls.LabelAdv labelAdv1;
        private UI.Controls.LabelAdv labelAdv2;
        private UI.Controls.DecimalTextBox maximumInput;
        private UI.Controls.DecimalTextBox minimumInput;
        private UI.Controls.DecimalTextBox smallChangeInput;
        private UI.Controls.LabelAdv labelAdv3;
        private UI.Controls.DecimalTextBox largeChangeInput;
        private UI.Controls.LabelAdv labelAdv4;
        private HScrollBar hscrollBarOrig;
        private UI.Controls.DecimalTextBox hscrollOrigOutp;
        private UI.Controls.DecimalTextBox hscrollOutp;
        private UI.Controls.DecimalTextBox hscrollXOutp;
        private UI.Controls.ScrollBarX hscrollBarX;
        private UI.Controls.ScrollBarX vscrollBarX;
        private UI.Controls.ButtonAdv buttonAdv1;
        private UI.Controls.ButtonAdv buttonAdv2;
        private UI.Controls.ButtonAdv buttonAdv3;
        private UI.Controls.ButtonAdv buttonAdv4;
    }
}