namespace VampirioCode.Tests
{
    partial class TabTester2
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
            tabPanel = new UI.Controls.TabPanel();
            console = new UI.XConsole();
            clearButton = new UI.Controls.ButtonAdv();
            buttonAdv1 = new UI.Controls.ButtonAdv();
            buttonAdv2 = new UI.Controls.ButtonAdv();
            buttonAdv3 = new UI.Controls.ButtonAdv();
            button36 = new Button();
            tabNameInput = new TextBox();
            SuspendLayout();
            // 
            // tabPanel
            // 
            tabPanel.AllowDetach = false;
            tabPanel.AllowDragging = true;
            tabPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabPanel.ArrowButtonBackColor = Color.FromArgb(40, 40, 40);
            tabPanel.ArrowButtonBorderColor = Color.FromArgb(25, 25, 25);
            tabPanel.ArrowButtonBorderSize = 2;
            tabPanel.ArrowColor = Color.FromArgb(20, 20, 20);
            tabPanel.BackColor = Color.FromArgb(30, 30, 30);
            tabPanel.IsDragging = false;
            tabPanel.Location = new Point(24, 12);
            tabPanel.MaxTabWidth = 160;
            tabPanel.MinDetachThreshold = 20;
            tabPanel.MinTabWidth = 60;
            tabPanel.Name = "tabPanel";
            tabPanel.SelectedIndex = -1;
            tabPanel.ShapeMode = UI.Controls.TabManagement.TabShapeMode.Box;
            tabPanel.Size = new Size(513, 296);
            tabPanel.SizeMode = UI.Controls.TabManagement.TabSizeMode.WrapToText;
            tabPanel.TabBorderSize = 2;
            tabPanel.TabIndex = 0;
            tabPanel.TabVisibleLimit = 10;
            tabPanel.Text = "tabPanel";
            // 
            // console
            // 
            console.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            console.BackColor = Color.FromArgb(40, 40, 40);
            console.Location = new Point(24, 446);
            console.Name = "console";
            console.Size = new Size(686, 193);
            console.TabIndex = 7;
            // 
            // clearButton
            // 
            clearButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
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
            clearButton.Location = new Point(641, 446);
            clearButton.Name = "clearButton";
            clearButton.PaintImageOnSelected = true;
            clearButton.processEnterKey = true;
            clearButton.resizeImage = new Point(0, 0);
            clearButton.Selected = false;
            clearButton.SelectedColor = Color.FromArgb(0, 122, 204);
            clearButton.Size = new Size(69, 22);
            clearButton.TabIndex = 9;
            clearButton.Text = "clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += OnClearConsolePressed;
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
            buttonAdv1.Location = new Point(24, 340);
            buttonAdv1.Name = "buttonAdv1";
            buttonAdv1.PaintImageOnSelected = true;
            buttonAdv1.processEnterKey = true;
            buttonAdv1.resizeImage = new Point(0, 0);
            buttonAdv1.Selected = false;
            buttonAdv1.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv1.Size = new Size(94, 29);
            buttonAdv1.TabIndex = 10;
            buttonAdv1.Text = "add";
            buttonAdv1.UseVisualStyleBackColor = true;
            buttonAdv1.Click += OnAddPressed;
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
            buttonAdv2.Location = new Point(124, 340);
            buttonAdv2.Name = "buttonAdv2";
            buttonAdv2.PaintImageOnSelected = true;
            buttonAdv2.processEnterKey = true;
            buttonAdv2.resizeImage = new Point(0, 0);
            buttonAdv2.Selected = false;
            buttonAdv2.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv2.Size = new Size(94, 29);
            buttonAdv2.TabIndex = 11;
            buttonAdv2.Text = "remove";
            buttonAdv2.UseVisualStyleBackColor = true;
            buttonAdv2.Click += OnRemovePressed;
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
            buttonAdv3.Location = new Point(224, 340);
            buttonAdv3.Name = "buttonAdv3";
            buttonAdv3.PaintImageOnSelected = true;
            buttonAdv3.processEnterKey = true;
            buttonAdv3.resizeImage = new Point(0, 0);
            buttonAdv3.Selected = false;
            buttonAdv3.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv3.Size = new Size(145, 29);
            buttonAdv3.TabIndex = 12;
            buttonAdv3.Text = "remove selected";
            buttonAdv3.UseVisualStyleBackColor = true;
            buttonAdv3.Click += OnRemoveSelected;
            // 
            // button36
            // 
            button36.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button36.Location = new Point(396, 375);
            button36.Name = "button36";
            button36.Size = new Size(141, 29);
            button36.TabIndex = 42;
            button36.Text = "set text";
            button36.UseVisualStyleBackColor = true;
            button36.Click += OnSetTextPressed;
            // 
            // tabNameInput
            // 
            tabNameInput.Location = new Point(396, 342);
            tabNameInput.Name = "tabNameInput";
            tabNameInput.Size = new Size(141, 27);
            tabNameInput.TabIndex = 41;
            // 
            // TabTester2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            ClientSize = new Size(1130, 651);
            Controls.Add(button36);
            Controls.Add(tabNameInput);
            Controls.Add(buttonAdv3);
            Controls.Add(buttonAdv2);
            Controls.Add(buttonAdv1);
            Controls.Add(clearButton);
            Controls.Add(console);
            Controls.Add(tabPanel);
            Name = "TabTester2";
            Text = "TabTester2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UI.Controls.TabPanel tabPanel;
        private UI.XConsole console;
        private UI.Controls.ButtonAdv clearButton;
        private UI.Controls.ButtonAdv buttonAdv1;
        private UI.Controls.ButtonAdv buttonAdv2;
        private UI.Controls.ButtonAdv buttonAdv3;
        private Button button36;
        private TextBox tabNameInput;
    }
}