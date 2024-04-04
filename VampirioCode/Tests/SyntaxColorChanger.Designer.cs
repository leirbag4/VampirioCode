namespace VampirioCode.Tests
{
    partial class SyntaxColorChanger
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
            styleList = new UI.Controls.VerticalItemListAdv();
            generateButton = new UI.Controls.ButtonAdv();
            versionLabel = new UI.Controls.LabelAdv();
            redInput = new UI.Controls.IntTextBox();
            labelAdv1 = new UI.Controls.LabelAdv();
            labelAdv2 = new UI.Controls.LabelAdv();
            greenInput = new UI.Controls.IntTextBox();
            labelAdv3 = new UI.Controls.LabelAdv();
            blueInput = new UI.Controls.IntTextBox();
            copyCodeButton = new UI.Controls.ButtonAdv();
            outp = new RichTextBox();
            colorPicker = new UI.Controls.ColorButton();
            redSlider = new TrackBar();
            greenSlider = new TrackBar();
            blueSlider = new TrackBar();
            buttonAdv1 = new UI.Controls.ButtonAdv();
            buttonAdv2 = new UI.Controls.ButtonAdv();
            labelAdv5 = new UI.Controls.LabelAdv();
            generateAllCKBox = new CheckBox();
            buttonAdv3 = new UI.Controls.ButtonAdv();
            buttonAdv4 = new UI.Controls.ButtonAdv();
            docTypeLabel = new UI.Controls.LabelAdv();
            ((System.ComponentModel.ISupportInitialize)redSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)greenSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)blueSlider).BeginInit();
            SuspendLayout();
            // 
            // styleList
            // 
            styleList.AllowPressedEvents = true;
            styleList.BackColor = Color.FromArgb(54, 54, 54);
            styleList.ItemHeight = 35;
            styleList.ItemHeightType = UI.Controls.VerticalItemList.HeightType.FIXED_SIZE;
            styleList.Location = new Point(29, 22);
            styleList.Name = "styleList";
            styleList.SelectedIndex = -1;
            styleList.SelectionEnable = true;
            styleList.Size = new Size(180, 375);
            styleList.TabIndex = 0;
            // 
            // generateButton
            // 
            generateButton.BackColor = Color.FromArgb(30, 30, 30);
            generateButton.BorderColor = Color.FromArgb(10, 10, 10);
            generateButton.BorderSize = 1;
            generateButton.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            generateButton.expandImage = false;
            generateButton.extraText = "";
            generateButton.extraTextAlign = ContentAlignment.MiddleCenter;
            generateButton.extraTextColor = Color.Black;
            generateButton.extraTextFont = null;
            generateButton.extraTextOffset = new Point(0, 0);
            generateButton.FocusColor = Color.FromArgb(24, 81, 115);
            generateButton.FocusEnabled = false;
            generateButton.ForeColor = Color.FromArgb(120, 120, 120);
            generateButton.Location = new Point(240, 228);
            generateButton.Name = "generateButton";
            generateButton.PaintImageOnSelected = true;
            generateButton.processEnterKey = true;
            generateButton.resizeImage = new Point(0, 0);
            generateButton.Selected = false;
            generateButton.SelectedColor = Color.FromArgb(0, 122, 204);
            generateButton.Size = new Size(94, 29);
            generateButton.TabIndex = 7;
            generateButton.Text = "Generate";
            generateButton.UseVisualStyleBackColor = false;
            generateButton.Click += OnGeneratePressed;
            // 
            // versionLabel
            // 
            versionLabel.AutoSize = true;
            versionLabel.BorderColor = Color.DarkGray;
            versionLabel.BorderSize = 1;
            versionLabel.CStyle = UI.Controls.LabelAdv.CustomStyle.NORMAL;
            versionLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            versionLabel.ForeColor = Color.FromArgb(130, 130, 130);
            versionLabel.Location = new Point(485, 28);
            versionLabel.ModifyClampMax = 0F;
            versionLabel.ModifyClampMin = 0F;
            versionLabel.ModifyControlName = "";
            versionLabel.ModifyScale = 1F;
            versionLabel.Name = "versionLabel";
            versionLabel.Size = new Size(92, 20);
            versionLabel.TabIndex = 8;
            versionLabel.Text = "Color Picker";
            // 
            // redInput
            // 
            redInput.AllowEmptyInput = false;
            redInput.BackColor = Color.FromArgb(30, 30, 30);
            redInput.BorderStyle = BorderStyle.None;
            redInput.ForeColor = Color.Silver;
            redInput.Location = new Point(302, 78);
            redInput.Name = "redInput";
            redInput.NumberMask = "";
            redInput.Size = new Size(74, 20);
            redInput.TabIndex = 11;
            redInput.TextChanged += OnColorInputTextChanged;
            // 
            // labelAdv1
            // 
            labelAdv1.AutoSize = true;
            labelAdv1.BorderColor = Color.DarkGray;
            labelAdv1.BorderSize = 1;
            labelAdv1.CStyle = UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelAdv1.ForeColor = Color.FromArgb(130, 130, 130);
            labelAdv1.Location = new Point(240, 78);
            labelAdv1.ModifyClampMax = 0F;
            labelAdv1.ModifyClampMin = 0F;
            labelAdv1.ModifyControlName = "";
            labelAdv1.ModifyScale = 1F;
            labelAdv1.Name = "labelAdv1";
            labelAdv1.Size = new Size(36, 20);
            labelAdv1.TabIndex = 12;
            labelAdv1.Text = "Red";
            // 
            // labelAdv2
            // 
            labelAdv2.AutoSize = true;
            labelAdv2.BorderColor = Color.DarkGray;
            labelAdv2.BorderSize = 1;
            labelAdv2.CStyle = UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelAdv2.ForeColor = Color.FromArgb(130, 130, 130);
            labelAdv2.Location = new Point(240, 120);
            labelAdv2.ModifyClampMax = 0F;
            labelAdv2.ModifyClampMin = 0F;
            labelAdv2.ModifyControlName = "";
            labelAdv2.ModifyScale = 1F;
            labelAdv2.Name = "labelAdv2";
            labelAdv2.Size = new Size(51, 20);
            labelAdv2.TabIndex = 14;
            labelAdv2.Text = "Green";
            // 
            // greenInput
            // 
            greenInput.AllowEmptyInput = false;
            greenInput.BackColor = Color.FromArgb(30, 30, 30);
            greenInput.BorderStyle = BorderStyle.None;
            greenInput.ForeColor = Color.Silver;
            greenInput.Location = new Point(302, 120);
            greenInput.Name = "greenInput";
            greenInput.NumberMask = "";
            greenInput.Size = new Size(74, 20);
            greenInput.TabIndex = 13;
            greenInput.TextChanged += OnColorInputTextChanged;
            // 
            // labelAdv3
            // 
            labelAdv3.AutoSize = true;
            labelAdv3.BorderColor = Color.DarkGray;
            labelAdv3.BorderSize = 1;
            labelAdv3.CStyle = UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelAdv3.ForeColor = Color.FromArgb(130, 130, 130);
            labelAdv3.Location = new Point(240, 161);
            labelAdv3.ModifyClampMax = 0F;
            labelAdv3.ModifyClampMin = 0F;
            labelAdv3.ModifyControlName = "";
            labelAdv3.ModifyScale = 1F;
            labelAdv3.Name = "labelAdv3";
            labelAdv3.Size = new Size(40, 20);
            labelAdv3.TabIndex = 16;
            labelAdv3.Text = "Blue";
            // 
            // blueInput
            // 
            blueInput.AllowEmptyInput = false;
            blueInput.BackColor = Color.FromArgb(30, 30, 30);
            blueInput.BorderStyle = BorderStyle.None;
            blueInput.ForeColor = Color.Silver;
            blueInput.Location = new Point(302, 161);
            blueInput.Name = "blueInput";
            blueInput.NumberMask = "";
            blueInput.Size = new Size(74, 20);
            blueInput.TabIndex = 15;
            blueInput.TextChanged += OnColorInputTextChanged;
            // 
            // copyCodeButton
            // 
            copyCodeButton.BackColor = Color.FromArgb(30, 30, 30);
            copyCodeButton.BorderColor = Color.FromArgb(10, 10, 10);
            copyCodeButton.BorderSize = 1;
            copyCodeButton.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            copyCodeButton.expandImage = false;
            copyCodeButton.extraText = "";
            copyCodeButton.extraTextAlign = ContentAlignment.MiddleCenter;
            copyCodeButton.extraTextColor = Color.Black;
            copyCodeButton.extraTextFont = null;
            copyCodeButton.extraTextOffset = new Point(0, 0);
            copyCodeButton.FocusColor = Color.FromArgb(24, 81, 115);
            copyCodeButton.FocusEnabled = false;
            copyCodeButton.ForeColor = Color.FromArgb(120, 120, 120);
            copyCodeButton.Location = new Point(344, 228);
            copyCodeButton.Name = "copyCodeButton";
            copyCodeButton.PaintImageOnSelected = true;
            copyCodeButton.processEnterKey = true;
            copyCodeButton.resizeImage = new Point(0, 0);
            copyCodeButton.Selected = false;
            copyCodeButton.SelectedColor = Color.FromArgb(0, 122, 204);
            copyCodeButton.Size = new Size(94, 29);
            copyCodeButton.TabIndex = 17;
            copyCodeButton.Text = "Copy Code";
            copyCodeButton.UseVisualStyleBackColor = false;
            copyCodeButton.Click += OnCopyCode;
            // 
            // outp
            // 
            outp.BackColor = Color.FromArgb(30, 30, 30);
            outp.BorderStyle = BorderStyle.None;
            outp.ForeColor = Color.Silver;
            outp.Location = new Point(240, 277);
            outp.Name = "outp";
            outp.Size = new Size(540, 120);
            outp.TabIndex = 18;
            outp.Text = "";
            // 
            // colorPicker
            // 
            colorPicker.BorderColor = Color.Gray;
            colorPicker.BorderSize = 1;
            colorPicker.CStyle = UI.Controls.ButtonAdv.CustomStyle.NORMAL;
            colorPicker.expandImage = false;
            colorPicker.extraText = "";
            colorPicker.extraTextAlign = ContentAlignment.MiddleCenter;
            colorPicker.extraTextColor = Color.Black;
            colorPicker.extraTextFont = null;
            colorPicker.extraTextOffset = new Point(0, 0);
            colorPicker.FlatStyle = FlatStyle.Flat;
            colorPicker.FocusColor = Color.FromArgb(24, 81, 115);
            colorPicker.FocusEnabled = false;
            colorPicker.HtmlColor = "#FFFFFF";
            colorPicker.Location = new Point(439, 22);
            colorPicker.Name = "colorPicker";
            colorPicker.PaintImageOnSelected = true;
            colorPicker.processEnterKey = true;
            colorPicker.resizeImage = new Point(0, 0);
            colorPicker.Selected = false;
            colorPicker.SelectedColor = Color.White;
            colorPicker.Size = new Size(32, 33);
            colorPicker.TabIndex = 19;
            colorPicker.Text = "colorButton1";
            colorPicker.UseVisualStyleBackColor = true;
            colorPicker.ColorChanged += OnColorPickerChanged;
            // 
            // redSlider
            // 
            redSlider.AutoSize = false;
            redSlider.Location = new Point(401, 74);
            redSlider.Maximum = 255;
            redSlider.Name = "redSlider";
            redSlider.Size = new Size(183, 29);
            redSlider.TabIndex = 20;
            redSlider.TickStyle = TickStyle.None;
            redSlider.Scroll += OnSliderChanged;
            // 
            // greenSlider
            // 
            greenSlider.AutoSize = false;
            greenSlider.Location = new Point(401, 116);
            greenSlider.Maximum = 255;
            greenSlider.Name = "greenSlider";
            greenSlider.Size = new Size(183, 29);
            greenSlider.TabIndex = 21;
            greenSlider.TickStyle = TickStyle.None;
            greenSlider.Scroll += OnSliderChanged;
            // 
            // blueSlider
            // 
            blueSlider.AutoSize = false;
            blueSlider.Location = new Point(401, 157);
            blueSlider.Maximum = 255;
            blueSlider.Name = "blueSlider";
            blueSlider.Size = new Size(183, 29);
            blueSlider.TabIndex = 22;
            blueSlider.TickStyle = TickStyle.None;
            blueSlider.Scroll += OnSliderChanged;
            // 
            // buttonAdv1
            // 
            buttonAdv1.BackColor = Color.FromArgb(30, 30, 30);
            buttonAdv1.BorderColor = Color.FromArgb(10, 10, 10);
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
            buttonAdv1.ForeColor = Color.FromArgb(120, 120, 120);
            buttonAdv1.Location = new Point(603, 68);
            buttonAdv1.Name = "buttonAdv1";
            buttonAdv1.PaintImageOnSelected = true;
            buttonAdv1.processEnterKey = true;
            buttonAdv1.resizeImage = new Point(0, 0);
            buttonAdv1.Selected = false;
            buttonAdv1.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv1.Size = new Size(109, 41);
            buttonAdv1.TabIndex = 23;
            buttonAdv1.Text = "Revert Color";
            buttonAdv1.UseVisualStyleBackColor = false;
            buttonAdv1.Click += OnRevertColorPressed;
            // 
            // buttonAdv2
            // 
            buttonAdv2.BackColor = Color.FromArgb(30, 30, 30);
            buttonAdv2.BorderColor = Color.FromArgb(10, 10, 10);
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
            buttonAdv2.ForeColor = Color.FromArgb(200, 128, 128);
            buttonAdv2.Location = new Point(569, 228);
            buttonAdv2.Name = "buttonAdv2";
            buttonAdv2.PaintImageOnSelected = true;
            buttonAdv2.processEnterKey = true;
            buttonAdv2.resizeImage = new Point(0, 0);
            buttonAdv2.Selected = false;
            buttonAdv2.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv2.Size = new Size(211, 29);
            buttonAdv2.TabIndex = 24;
            buttonAdv2.Text = "Reset to Default";
            buttonAdv2.UseVisualStyleBackColor = false;
            buttonAdv2.Click += OnResetThemeToDefaultPressed;
            // 
            // labelAdv5
            // 
            labelAdv5.BorderColor = Color.DarkGray;
            labelAdv5.BorderSize = 1;
            labelAdv5.CStyle = UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv5.ForeColor = Color.FromArgb(150, 150, 150);
            labelAdv5.Location = new Point(569, 199);
            labelAdv5.ModifyClampMax = 0F;
            labelAdv5.ModifyClampMin = 0F;
            labelAdv5.ModifyControlName = "";
            labelAdv5.ModifyScale = 1F;
            labelAdv5.Name = "labelAdv5";
            labelAdv5.Size = new Size(211, 26);
            labelAdv5.TabIndex = 25;
            labelAdv5.Text = "Reset current theme to default";
            labelAdv5.TextAlign = ContentAlignment.TopCenter;
            // 
            // generateAllCKBox
            // 
            generateAllCKBox.AutoSize = true;
            generateAllCKBox.ForeColor = Color.FromArgb(120, 120, 120);
            generateAllCKBox.Location = new Point(451, 233);
            generateAllCKBox.Name = "generateAllCKBox";
            generateAllCKBox.Size = new Size(110, 24);
            generateAllCKBox.TabIndex = 26;
            generateAllCKBox.Text = "generate all";
            generateAllCKBox.UseVisualStyleBackColor = true;
            // 
            // buttonAdv3
            // 
            buttonAdv3.BackColor = Color.FromArgb(30, 30, 30);
            buttonAdv3.BorderColor = Color.FromArgb(10, 10, 10);
            buttonAdv3.BorderSize = 1;
            buttonAdv3.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            buttonAdv3.expandImage = false;
            buttonAdv3.extraText = "";
            buttonAdv3.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv3.extraTextColor = Color.Black;
            buttonAdv3.extraTextFont = null;
            buttonAdv3.extraTextOffset = new Point(0, 0);
            buttonAdv3.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv3.FocusEnabled = false;
            buttonAdv3.ForeColor = Color.FromArgb(120, 120, 170);
            buttonAdv3.Location = new Point(603, 120);
            buttonAdv3.Name = "buttonAdv3";
            buttonAdv3.PaintImageOnSelected = true;
            buttonAdv3.processEnterKey = true;
            buttonAdv3.resizeImage = new Point(0, 0);
            buttonAdv3.Selected = false;
            buttonAdv3.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv3.Size = new Size(109, 30);
            buttonAdv3.TabIndex = 27;
            buttonAdv3.Text = "Copy Color";
            buttonAdv3.UseVisualStyleBackColor = false;
            buttonAdv3.Click += OnCopyColorPressed;
            // 
            // buttonAdv4
            // 
            buttonAdv4.BackColor = Color.FromArgb(30, 30, 30);
            buttonAdv4.BorderColor = Color.FromArgb(10, 10, 10);
            buttonAdv4.BorderSize = 1;
            buttonAdv4.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            buttonAdv4.expandImage = false;
            buttonAdv4.extraText = "";
            buttonAdv4.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv4.extraTextColor = Color.Black;
            buttonAdv4.extraTextFont = null;
            buttonAdv4.extraTextOffset = new Point(0, 0);
            buttonAdv4.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv4.FocusEnabled = false;
            buttonAdv4.ForeColor = Color.FromArgb(120, 120, 170);
            buttonAdv4.Location = new Point(603, 155);
            buttonAdv4.Name = "buttonAdv4";
            buttonAdv4.PaintImageOnSelected = true;
            buttonAdv4.processEnterKey = true;
            buttonAdv4.resizeImage = new Point(0, 0);
            buttonAdv4.Selected = false;
            buttonAdv4.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv4.Size = new Size(109, 30);
            buttonAdv4.TabIndex = 28;
            buttonAdv4.Text = "Paste Color";
            buttonAdv4.UseVisualStyleBackColor = false;
            buttonAdv4.Click += OnPasteColorPressed;
            // 
            // docTypeLabel
            // 
            docTypeLabel.BorderColor = Color.DarkGray;
            docTypeLabel.BorderSize = 1;
            docTypeLabel.CStyle = UI.Controls.LabelAdv.CustomStyle.NORMAL;
            docTypeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            docTypeLabel.ForeColor = Color.FromArgb(170, 170, 210);
            docTypeLabel.Location = new Point(240, 28);
            docTypeLabel.ModifyClampMax = 0F;
            docTypeLabel.ModifyClampMin = 0F;
            docTypeLabel.ModifyControlName = "";
            docTypeLabel.ModifyScale = 1F;
            docTypeLabel.Name = "docTypeLabel";
            docTypeLabel.Size = new Size(150, 26);
            docTypeLabel.TabIndex = 29;
            docTypeLabel.Text = "Document: java";
            // 
            // SyntaxColorChanger
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 417);
            Controls.Add(docTypeLabel);
            Controls.Add(buttonAdv4);
            Controls.Add(buttonAdv3);
            Controls.Add(generateAllCKBox);
            Controls.Add(labelAdv5);
            Controls.Add(buttonAdv2);
            Controls.Add(buttonAdv1);
            Controls.Add(blueSlider);
            Controls.Add(greenSlider);
            Controls.Add(redSlider);
            Controls.Add(colorPicker);
            Controls.Add(outp);
            Controls.Add(copyCodeButton);
            Controls.Add(labelAdv3);
            Controls.Add(blueInput);
            Controls.Add(labelAdv2);
            Controls.Add(greenInput);
            Controls.Add(labelAdv1);
            Controls.Add(redInput);
            Controls.Add(versionLabel);
            Controls.Add(generateButton);
            Controls.Add(styleList);
            Name = "SyntaxColorChanger";
            Text = "SyntaxColorChanger";
            ((System.ComponentModel.ISupportInitialize)redSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)greenSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)blueSlider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UI.Controls.VerticalItemListAdv styleList;
        private UI.Controls.ButtonAdv generateButton;
        private UI.Controls.LabelAdv labelAdv4;
        private UI.Controls.LabelAdv versionLabel;
        private UI.Controls.IntTextBox redInput;
        private UI.Controls.LabelAdv labelAdv1;
        private UI.Controls.LabelAdv labelAdv2;
        private UI.Controls.IntTextBox greenInput;
        private UI.Controls.LabelAdv labelAdv3;
        private UI.Controls.IntTextBox blueInput;
        private UI.Controls.ButtonAdv copyCodeButton;
        private RichTextBox outp;
        private UI.Controls.ColorButton colorPicker;
        private TrackBar redSlider;
        private TrackBar greenSlider;
        private TrackBar blueSlider;
        private UI.Controls.ButtonAdv buttonAdv1;
        private UI.Controls.ButtonAdv buttonAdv2;
        private UI.Controls.LabelAdv labelAdv5;
        private CheckBox generateAllCKBox;
        private UI.Controls.ButtonAdv buttonAdv3;
        private UI.Controls.ButtonAdv buttonAdv4;
        private UI.Controls.LabelAdv docTypeLabel;
    }
}