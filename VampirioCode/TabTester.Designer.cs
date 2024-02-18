namespace VampirioCode
{
    partial class TabTester
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
            tabControlWin = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            button1 = new Button();
            button2 = new Button();
            tabBar = new UI.Controls.TabBar();
            button3 = new Button();
            button4 = new Button();
            console = new UI.XConsole();
            button5 = new Button();
            clearButton = new UI.Controls.ButtonAdv();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            button13 = new Button();
            button14 = new Button();
            button15 = new Button();
            button16 = new Button();
            button17 = new Button();
            button18 = new Button();
            button19 = new Button();
            button20 = new Button();
            button21 = new Button();
            button22 = new Button();
            button23 = new Button();
            button24 = new Button();
            button25 = new Button();
            button26 = new Button();
            button27 = new Button();
            button28 = new Button();
            button29 = new Button();
            button30 = new Button();
            button31 = new Button();
            button32 = new Button();
            button33 = new Button();
            button34 = new Button();
            button35 = new Button();
            tabNameInput = new TextBox();
            button36 = new Button();
            button37 = new Button();
            button38 = new Button();
            button39 = new Button();
            tabControlWin.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlWin
            // 
            tabControlWin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tabControlWin.Controls.Add(tabPage1);
            tabControlWin.Controls.Add(tabPage2);
            tabControlWin.Location = new Point(741, 194);
            tabControlWin.Name = "tabControlWin";
            tabControlWin.SelectedIndex = 0;
            tabControlWin.Size = new Size(364, 153);
            tabControlWin.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(356, 120);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(356, 120);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(861, 353);
            button1.Name = "button1";
            button1.Size = new Size(114, 29);
            button1.TabIndex = 1;
            button1.Text = "add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += WinAdd;
            // 
            // button2
            // 
            button2.Location = new Point(979, 353);
            button2.Name = "button2";
            button2.Size = new Size(122, 29);
            button2.TabIndex = 2;
            button2.Text = "remove";
            button2.UseVisualStyleBackColor = true;
            button2.Click += WinRemove;
            // 
            // tabBar
            // 
            tabBar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabBar.BackColor = Color.FromArgb(60, 60, 60);
            tabBar.Location = new Point(25, 12);
            tabBar.Name = "tabBar";
            tabBar.SelectedIndex = -1;
            tabBar.Size = new Size(552, 32);
            tabBar.TabIndex = 3;
            tabBar.Text = "tabControlx1";
            // 
            // button3
            // 
            button3.Location = new Point(104, 361);
            button3.Name = "button3";
            button3.Size = new Size(80, 29);
            button3.TabIndex = 5;
            button3.Text = "remove";
            button3.UseVisualStyleBackColor = true;
            button3.Click += OnRemove;
            // 
            // button4
            // 
            button4.Location = new Point(26, 361);
            button4.Name = "button4";
            button4.Size = new Size(72, 29);
            button4.TabIndex = 4;
            button4.Text = "add";
            button4.UseVisualStyleBackColor = true;
            button4.Click += OnAdd;
            // 
            // console
            // 
            console.BackColor = Color.FromArgb(40, 40, 40);
            console.Location = new Point(25, 415);
            console.Name = "console";
            console.Size = new Size(686, 193);
            console.TabIndex = 6;
            // 
            // button5
            // 
            button5.Location = new Point(455, 361);
            button5.Name = "button5";
            button5.Size = new Size(122, 29);
            button5.TabIndex = 7;
            button5.Text = "reset";
            button5.UseVisualStyleBackColor = true;
            button5.Click += OnResetPressed;
            // 
            // clearButton
            // 
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
            clearButton.Location = new Point(637, 415);
            clearButton.Name = "clearButton";
            clearButton.PaintImageOnSelected = true;
            clearButton.processEnterKey = true;
            clearButton.resizeImage = new Point(0, 0);
            clearButton.Selected = false;
            clearButton.SelectedColor = Color.FromArgb(0, 122, 204);
            clearButton.Size = new Size(69, 22);
            clearButton.TabIndex = 8;
            clearButton.Text = "clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += OnClearPressed;
            // 
            // button6
            // 
            button6.Location = new Point(209, 361);
            button6.Name = "button6";
            button6.Size = new Size(34, 29);
            button6.TabIndex = 9;
            button6.Tag = "0";
            button6.Text = "R0";
            button6.UseVisualStyleBackColor = true;
            button6.Click += OnRemoveItemNumb;
            // 
            // button7
            // 
            button7.Location = new Point(249, 361);
            button7.Name = "button7";
            button7.Size = new Size(34, 29);
            button7.TabIndex = 10;
            button7.Tag = "1";
            button7.Text = "R1";
            button7.UseVisualStyleBackColor = true;
            button7.Click += OnRemoveItemNumb;
            // 
            // button8
            // 
            button8.Location = new Point(289, 361);
            button8.Name = "button8";
            button8.Size = new Size(34, 29);
            button8.TabIndex = 11;
            button8.Tag = "2";
            button8.Text = "R2";
            button8.UseVisualStyleBackColor = true;
            button8.Click += OnRemoveItemNumb;
            // 
            // button9
            // 
            button9.Location = new Point(329, 361);
            button9.Name = "button9";
            button9.Size = new Size(34, 29);
            button9.TabIndex = 12;
            button9.Tag = "3";
            button9.Text = "R3";
            button9.UseVisualStyleBackColor = true;
            button9.Click += OnRemoveItemNumb;
            // 
            // button10
            // 
            button10.Location = new Point(369, 361);
            button10.Name = "button10";
            button10.Size = new Size(34, 29);
            button10.TabIndex = 13;
            button10.Tag = "4";
            button10.Text = "R4";
            button10.UseVisualStyleBackColor = true;
            button10.Click += OnRemoveItemNumb;
            // 
            // button11
            // 
            button11.Location = new Point(369, 396);
            button11.Name = "button11";
            button11.Size = new Size(34, 29);
            button11.TabIndex = 18;
            button11.Tag = "4";
            button11.Text = "I4";
            button11.UseVisualStyleBackColor = true;
            button11.Click += OnInsertItemNumb;
            // 
            // button12
            // 
            button12.Location = new Point(329, 396);
            button12.Name = "button12";
            button12.Size = new Size(34, 29);
            button12.TabIndex = 17;
            button12.Tag = "3";
            button12.Text = "I3";
            button12.UseVisualStyleBackColor = true;
            button12.Click += OnInsertItemNumb;
            // 
            // button13
            // 
            button13.Location = new Point(289, 396);
            button13.Name = "button13";
            button13.Size = new Size(34, 29);
            button13.TabIndex = 16;
            button13.Tag = "2";
            button13.Text = "I2";
            button13.UseVisualStyleBackColor = true;
            button13.Click += OnInsertItemNumb;
            // 
            // button14
            // 
            button14.Location = new Point(249, 396);
            button14.Name = "button14";
            button14.Size = new Size(34, 29);
            button14.TabIndex = 15;
            button14.Tag = "1";
            button14.Text = "I1";
            button14.UseVisualStyleBackColor = true;
            button14.Click += OnInsertItemNumb;
            // 
            // button15
            // 
            button15.Location = new Point(209, 396);
            button15.Name = "button15";
            button15.Size = new Size(34, 29);
            button15.TabIndex = 14;
            button15.Tag = "0";
            button15.Text = "I0";
            button15.UseVisualStyleBackColor = true;
            button15.Click += OnInsertItemNumb;
            // 
            // button16
            // 
            button16.Location = new Point(742, 353);
            button16.Name = "button16";
            button16.Size = new Size(114, 29);
            button16.TabIndex = 19;
            button16.Text = "insert";
            button16.UseVisualStyleBackColor = true;
            button16.Click += WinInsert0;
            // 
            // button17
            // 
            button17.Location = new Point(905, 431);
            button17.Name = "button17";
            button17.Size = new Size(34, 29);
            button17.TabIndex = 29;
            button17.Tag = "4";
            button17.Text = "I4";
            button17.UseVisualStyleBackColor = true;
            button17.Click += OnWinInsertPressed;
            // 
            // button18
            // 
            button18.Location = new Point(865, 431);
            button18.Name = "button18";
            button18.Size = new Size(34, 29);
            button18.TabIndex = 28;
            button18.Tag = "3";
            button18.Text = "I3";
            button18.UseVisualStyleBackColor = true;
            button18.Click += OnWinInsertPressed;
            // 
            // button19
            // 
            button19.Location = new Point(825, 431);
            button19.Name = "button19";
            button19.Size = new Size(34, 29);
            button19.TabIndex = 27;
            button19.Tag = "2";
            button19.Text = "I2";
            button19.UseVisualStyleBackColor = true;
            button19.Click += OnWinInsertPressed;
            // 
            // button20
            // 
            button20.Location = new Point(785, 431);
            button20.Name = "button20";
            button20.Size = new Size(34, 29);
            button20.TabIndex = 26;
            button20.Tag = "1";
            button20.Text = "I1";
            button20.UseVisualStyleBackColor = true;
            button20.Click += OnWinInsertPressed;
            // 
            // button21
            // 
            button21.Location = new Point(745, 431);
            button21.Name = "button21";
            button21.Size = new Size(34, 29);
            button21.TabIndex = 25;
            button21.Tag = "0";
            button21.Text = "I0";
            button21.UseVisualStyleBackColor = true;
            button21.Click += OnWinInsertPressed;
            // 
            // button22
            // 
            button22.Location = new Point(905, 396);
            button22.Name = "button22";
            button22.Size = new Size(34, 29);
            button22.TabIndex = 24;
            button22.Tag = "4";
            button22.Text = "R4";
            button22.UseVisualStyleBackColor = true;
            button22.Click += OnWinRemovePressed;
            // 
            // button23
            // 
            button23.Location = new Point(865, 396);
            button23.Name = "button23";
            button23.Size = new Size(34, 29);
            button23.TabIndex = 23;
            button23.Tag = "3";
            button23.Text = "R3";
            button23.UseVisualStyleBackColor = true;
            button23.Click += OnWinRemovePressed;
            // 
            // button24
            // 
            button24.Location = new Point(825, 396);
            button24.Name = "button24";
            button24.Size = new Size(34, 29);
            button24.TabIndex = 22;
            button24.Tag = "2";
            button24.Text = "R2";
            button24.UseVisualStyleBackColor = true;
            button24.Click += OnWinRemovePressed;
            // 
            // button25
            // 
            button25.Location = new Point(785, 396);
            button25.Name = "button25";
            button25.Size = new Size(34, 29);
            button25.TabIndex = 21;
            button25.Tag = "1";
            button25.Text = "R1";
            button25.UseVisualStyleBackColor = true;
            button25.Click += OnWinRemovePressed;
            // 
            // button26
            // 
            button26.Location = new Point(745, 396);
            button26.Name = "button26";
            button26.Size = new Size(34, 29);
            button26.TabIndex = 20;
            button26.Tag = "0";
            button26.Text = "R0";
            button26.UseVisualStyleBackColor = true;
            button26.Click += OnWinRemovePressed;
            // 
            // button27
            // 
            button27.Location = new Point(745, 479);
            button27.Name = "button27";
            button27.Size = new Size(50, 29);
            button27.TabIndex = 30;
            button27.Tag = "0";
            button27.Text = "sel 0";
            button27.UseVisualStyleBackColor = true;
            button27.Click += OnManualSelectWinIndex;
            // 
            // button28
            // 
            button28.Location = new Point(803, 479);
            button28.Name = "button28";
            button28.Size = new Size(50, 29);
            button28.TabIndex = 31;
            button28.Tag = "1";
            button28.Text = "sel 1";
            button28.UseVisualStyleBackColor = true;
            button28.Click += OnManualSelectWinIndex;
            // 
            // button29
            // 
            button29.Location = new Point(859, 479);
            button29.Name = "button29";
            button29.Size = new Size(50, 29);
            button29.TabIndex = 32;
            button29.Tag = "2";
            button29.Text = "sel 2";
            button29.UseVisualStyleBackColor = true;
            button29.Click += OnManualSelectWinIndex;
            // 
            // button30
            // 
            button30.Location = new Point(915, 479);
            button30.Name = "button30";
            button30.Size = new Size(50, 29);
            button30.TabIndex = 33;
            button30.Tag = "3";
            button30.Text = "sel 3";
            button30.UseVisualStyleBackColor = true;
            button30.Click += OnManualSelectWinIndex;
            // 
            // button31
            // 
            button31.ForeColor = Color.IndianRed;
            button31.Location = new Point(455, 396);
            button31.Name = "button31";
            button31.Size = new Size(122, 29);
            button31.TabIndex = 34;
            button31.Text = "- selected";
            button31.UseVisualStyleBackColor = true;
            button31.Click += OnRemoveSelected;
            // 
            // button32
            // 
            button32.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button32.Location = new Point(584, 12);
            button32.Name = "button32";
            button32.Size = new Size(138, 29);
            button32.TabIndex = 35;
            button32.Text = "save selected";
            button32.UseVisualStyleBackColor = true;
            button32.Click += OnSaveSelectedPressed;
            // 
            // button33
            // 
            button33.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button33.Location = new Point(584, 47);
            button33.Name = "button33";
            button33.Size = new Size(138, 29);
            button33.TabIndex = 36;
            button33.Text = "restore selected";
            button33.UseVisualStyleBackColor = true;
            button33.Click += OnRestoreSelectedPressed;
            // 
            // button34
            // 
            button34.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button34.Location = new Point(583, 108);
            button34.Name = "button34";
            button34.Size = new Size(138, 29);
            button34.TabIndex = 37;
            button34.Text = "bring to screen";
            button34.UseVisualStyleBackColor = true;
            button34.Click += OnBringToScreenPressed;
            // 
            // button35
            // 
            button35.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button35.Location = new Point(584, 318);
            button35.Name = "button35";
            button35.Size = new Size(138, 29);
            button35.TabIndex = 38;
            button35.Text = "clear";
            button35.UseVisualStyleBackColor = true;
            button35.Click += OnClearItemsPressed;
            // 
            // tabNameInput
            // 
            tabNameInput.Location = new Point(583, 194);
            tabNameInput.Name = "tabNameInput";
            tabNameInput.Size = new Size(141, 27);
            tabNameInput.TabIndex = 39;
            // 
            // button36
            // 
            button36.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button36.Location = new Point(583, 227);
            button36.Name = "button36";
            button36.Size = new Size(141, 29);
            button36.TabIndex = 40;
            button36.Text = "set text";
            button36.UseVisualStyleBackColor = true;
            button36.Click += OnSetTabTextPressed;
            // 
            // button37
            // 
            button37.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button37.Location = new Point(757, 12);
            button37.Name = "button37";
            button37.Size = new Size(122, 29);
            button37.TabIndex = 41;
            button37.Text = "set all styles";
            button37.UseVisualStyleBackColor = true;
            button37.Click += OnSetAllStylesPressed;
            // 
            // button38
            // 
            button38.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button38.Location = new Point(757, 47);
            button38.Name = "button38";
            button38.Size = new Size(122, 29);
            button38.TabIndex = 42;
            button38.Text = "set 1 tab style";
            button38.UseVisualStyleBackColor = true;
            button38.Click += OnSet1TabStylePressed;
            // 
            // button39
            // 
            button39.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button39.Location = new Point(583, 143);
            button39.Name = "button39";
            button39.Size = new Size(138, 29);
            button39.TabIndex = 43;
            button39.Text = "bng to scr saved";
            button39.UseVisualStyleBackColor = true;
            button39.Click += OnBringToScreenSaved;
            // 
            // TabTester
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            ClientSize = new Size(1157, 620);
            Controls.Add(button39);
            Controls.Add(button38);
            Controls.Add(button37);
            Controls.Add(button36);
            Controls.Add(tabNameInput);
            Controls.Add(button35);
            Controls.Add(button34);
            Controls.Add(button33);
            Controls.Add(button32);
            Controls.Add(button31);
            Controls.Add(button30);
            Controls.Add(button29);
            Controls.Add(button28);
            Controls.Add(button27);
            Controls.Add(button17);
            Controls.Add(button18);
            Controls.Add(button19);
            Controls.Add(button20);
            Controls.Add(button21);
            Controls.Add(button22);
            Controls.Add(button23);
            Controls.Add(button24);
            Controls.Add(button25);
            Controls.Add(button26);
            Controls.Add(button16);
            Controls.Add(button11);
            Controls.Add(button12);
            Controls.Add(button13);
            Controls.Add(button14);
            Controls.Add(button15);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(clearButton);
            Controls.Add(button5);
            Controls.Add(console);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(tabBar);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(tabControlWin);
            Name = "TabTester";
            Text = "TabTester";
            tabControlWin.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControlWin;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button button1;
        private Button button2;
        private UI.Controls.TabBar tabBar;
        private Button button3;
        private Button button4;
        private UI.XConsole console;
        private Button button5;
        private UI.Controls.ButtonAdv clearButton;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button button14;
        private Button button15;
        private Button button16;
        private Button button17;
        private Button button18;
        private Button button19;
        private Button button20;
        private Button button21;
        private Button button22;
        private Button button23;
        private Button button24;
        private Button button25;
        private Button button26;
        private Button button27;
        private Button button28;
        private Button button29;
        private Button button30;
        private Button button31;
        private Button button32;
        private Button button33;
        private Button button34;
        private Button button35;
        private TextBox tabNameInput;
        private Button button36;
        private Button button37;
        private Button button38;
        private Button button39;
    }
}