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
            vscrollBarEx = new UI.Controls.ScrollBarEx();
            hscrollBarEx = new UI.Controls.ScrollBarEx();
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
            hscrollExOutp = new UI.Controls.DecimalTextBox();
            hscrollAdvOutp = new UI.Controls.DecimalTextBox();
            hscrollBarAdv = new UI.Controls.ScrollBarAdv();
            vscrollBarX = new UI.Controls.ScrollBarAdv();
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
            // vscrollBarEx
            // 
            vscrollBarEx.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            vscrollBarEx.ArrowColor = Color.FromArgb(200, 200, 200);
            vscrollBarEx.BackgroundColor = Color.FromArgb(70, 70, 70);
            vscrollBarEx.BorderColorAdv = Color.Black;
            vscrollBarEx.BorderColorDisabled = Color.Gray;
            vscrollBarEx.BordersVisible = false;
            vscrollBarEx.ButtonDownColor = Color.FromArgb(120, 120, 120);
            vscrollBarEx.ButtonNormalColor = Color.FromArgb(70, 70, 70);
            vscrollBarEx.ButtonOverColor = Color.FromArgb(140, 140, 140);
            vscrollBarEx.Location = new Point(588, 21);
            vscrollBarEx.Name = "vscrollBarEx";
            vscrollBarEx.Size = new Size(19, 263);
            vscrollBarEx.TabIndex = 9;
            vscrollBarEx.Text = "scrollBarAdv1";
            vscrollBarEx.ThumbDownColor = Color.FromArgb(100, 100, 100);
            vscrollBarEx.ThumbNormalColor = Color.FromArgb(130, 130, 130);
            vscrollBarEx.ThumbOverColor = Color.FromArgb(120, 120, 120);
            vscrollBarEx.TrackColor = Color.FromArgb(110, 110, 110);
            // 
            // hscrollBarEx
            // 
            hscrollBarEx.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            hscrollBarEx.ArrowColor = Color.FromArgb(200, 200, 200);
            hscrollBarEx.BackgroundColor = Color.FromArgb(70, 70, 70);
            hscrollBarEx.BorderColorAdv = Color.Black;
            hscrollBarEx.BorderColorDisabled = Color.Gray;
            hscrollBarEx.BordersVisible = false;
            hscrollBarEx.ButtonDownColor = Color.FromArgb(120, 120, 120);
            hscrollBarEx.ButtonNormalColor = Color.FromArgb(70, 70, 70);
            hscrollBarEx.ButtonOverColor = Color.FromArgb(140, 140, 140);
            hscrollBarEx.Location = new Point(30, 21);
            hscrollBarEx.Name = "hscrollBarEx";
            hscrollBarEx.Orientation = UI.Controls.ScrollBarExternal.ScrollBarOrientation.Horizontal;
            hscrollBarEx.Size = new Size(373, 19);
            hscrollBarEx.TabIndex = 10;
            hscrollBarEx.Text = "scrollBarAdv2";
            hscrollBarEx.ThumbDownColor = Color.FromArgb(100, 100, 100);
            hscrollBarEx.ThumbNormalColor = Color.FromArgb(130, 130, 130);
            hscrollBarEx.ThumbOverColor = Color.FromArgb(120, 120, 120);
            hscrollBarEx.TrackColor = Color.FromArgb(110, 110, 110);
            hscrollBarEx.Scroll += OnHScrollChanged;
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
            // hscrollExOutp
            // 
            hscrollExOutp.AllowEmptyInput = false;
            hscrollExOutp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            hscrollExOutp.Location = new Point(423, 17);
            hscrollExOutp.MaxDecimalPlaces = 0;
            hscrollExOutp.Name = "hscrollExOutp";
            hscrollExOutp.Size = new Size(104, 27);
            hscrollExOutp.TabIndex = 21;
            hscrollExOutp.UseNegativeValues = false;
            // 
            // hscrollAdvOutp
            // 
            hscrollAdvOutp.AllowEmptyInput = false;
            hscrollAdvOutp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            hscrollAdvOutp.Location = new Point(423, 115);
            hscrollAdvOutp.MaxDecimalPlaces = 0;
            hscrollAdvOutp.Name = "hscrollAdvOutp";
            hscrollAdvOutp.Size = new Size(104, 27);
            hscrollAdvOutp.TabIndex = 23;
            hscrollAdvOutp.UseNegativeValues = false;
            // 
            // hscrollBarAdv
            // 
            hscrollBarAdv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            hscrollBarAdv.ArrowColor = Color.FromArgb(200, 200, 200);
            hscrollBarAdv.ButtonDownColor = Color.FromArgb(75, 75, 75);
            hscrollBarAdv.ButtonNormalColor = Color.FromArgb(70, 70, 70);
            hscrollBarAdv.ButtonOverColor = Color.FromArgb(101, 101, 101);
            hscrollBarAdv.ButtonSize = 20;
            hscrollBarAdv.LargeChange = 10;
            hscrollBarAdv.Location = new Point(30, 115);
            hscrollBarAdv.Maximum = 100;
            hscrollBarAdv.Minimum = 0;
            hscrollBarAdv.Name = "hscrollBarAdv";
            hscrollBarAdv.Orientation = UI.Controls.ScrollBarAdvance.ScrollBarOrientation.Horizontal;
            hscrollBarAdv.Size = new Size(373, 20);
            hscrollBarAdv.SmallChange = 1;
            hscrollBarAdv.TabIndex = 24;
            hscrollBarAdv.Text = "scrollBarx1";
            hscrollBarAdv.ThumbDownColor = Color.FromArgb(100, 100, 100);
            hscrollBarAdv.ThumbNormalColor = Color.FromArgb(130, 130, 130);
            hscrollBarAdv.ThumbOverColor = Color.FromArgb(120, 120, 120);
            hscrollBarAdv.TrackDownColor = Color.FromArgb(60, 60, 60);
            hscrollBarAdv.TrackNormalColor = Color.FromArgb(50, 50, 50);
            hscrollBarAdv.TrackOverColor = Color.FromArgb(53, 53, 53);
            hscrollBarAdv.TrackOverToButtonColor = Color.FromArgb(85, 85, 85);
            hscrollBarAdv.Value = 0;
            hscrollBarAdv.Scroll += OnHScrollXChanged;
            // 
            // vscrollBarX
            // 
            vscrollBarX.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            vscrollBarX.ArrowColor = Color.FromArgb(200, 200, 200);
            vscrollBarX.ButtonDownColor = Color.FromArgb(100, 100, 100);
            vscrollBarX.ButtonNormalColor = Color.FromArgb(70, 70, 70);
            vscrollBarX.ButtonOverColor = Color.FromArgb(140, 140, 140);
            vscrollBarX.ButtonSize = 20;
            vscrollBarX.LargeChange = 10;
            vscrollBarX.Location = new Point(629, 21);
            vscrollBarX.Maximum = 100;
            vscrollBarX.Minimum = 0;
            vscrollBarX.Name = "vscrollBarX";
            vscrollBarX.Orientation = UI.Controls.ScrollBarAdvance.ScrollBarOrientation.Vertical;
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
            vscrollBarX.TrackOverToButtonColor = Color.FromArgb(85, 85, 85);
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
            buttonAdv4.Click += OnSetExPressed;
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
            Controls.Add(hscrollBarAdv);
            Controls.Add(hscrollAdvOutp);
            Controls.Add(hscrollOrigOutp);
            Controls.Add(hscrollExOutp);
            Controls.Add(hscrollBarOrig);
            Controls.Add(smallChangeInput);
            Controls.Add(labelAdv3);
            Controls.Add(largeChangeInput);
            Controls.Add(labelAdv4);
            Controls.Add(minimumInput);
            Controls.Add(labelAdv2);
            Controls.Add(maximumInput);
            Controls.Add(labelAdv1);
            Controls.Add(hscrollBarEx);
            Controls.Add(vscrollBarEx);
            Controls.Add(console);
            Name = "ScrollTester";
            Text = "ScrollTester";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UI.XConsole console;
        private UI.Controls.ScrollBarEx vscrollBarEx;
        private UI.Controls.ScrollBarEx hscrollBarEx;
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
        private UI.Controls.DecimalTextBox hscrollExOutp;
        private UI.Controls.DecimalTextBox hscrollAdvOutp;
        private UI.Controls.ScrollBarAdv hscrollBarAdv;
        private UI.Controls.ScrollBarAdv vscrollBarX;
        private UI.Controls.ButtonAdv buttonAdv1;
        private UI.Controls.ButtonAdv buttonAdv2;
        private UI.Controls.ButtonAdv buttonAdv3;
        private UI.Controls.ButtonAdv buttonAdv4;
    }
}