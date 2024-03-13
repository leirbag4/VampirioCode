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
            vscrollBar.Location = new Point(594, 24);
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
            hscrollBar.Location = new Point(30, 78);
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
            labelAdv1.Location = new Point(140, 134);
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
            labelAdv2.Location = new Point(140, 169);
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
            maximumInput.Location = new Point(30, 166);
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
            minimumInput.Location = new Point(30, 133);
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
            smallChangeInput.Location = new Point(30, 199);
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
            labelAdv3.Location = new Point(140, 235);
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
            largeChangeInput.Location = new Point(30, 232);
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
            labelAdv4.Location = new Point(140, 200);
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
            hscrollBarOrig.Location = new Point(30, 24);
            hscrollBarOrig.Name = "hscrollBarOrig";
            hscrollBarOrig.Size = new Size(373, 26);
            hscrollBarOrig.TabIndex = 20;
            hscrollBarOrig.Scroll += OnHScrollOrigChanged;
            // 
            // hscrollOrigOutp
            // 
            hscrollOrigOutp.AllowEmptyInput = false;
            hscrollOrigOutp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            hscrollOrigOutp.Location = new Point(423, 24);
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
            hscrollOutp.Location = new Point(423, 70);
            hscrollOutp.MaxDecimalPlaces = 0;
            hscrollOutp.Name = "hscrollOutp";
            hscrollOutp.Size = new Size(104, 27);
            hscrollOutp.TabIndex = 21;
            hscrollOutp.UseNegativeValues = false;
            // 
            // ScrollTester
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            ClientSize = new Size(691, 538);
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
    }
}