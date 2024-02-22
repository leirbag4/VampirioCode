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
            console = new UI.XConsole();
            clearButton = new UI.Controls.ButtonAdv();
            buttonAdv1 = new UI.Controls.ButtonAdv();
            buttonAdv2 = new UI.Controls.ButtonAdv();
            buttonAdv3 = new UI.Controls.ButtonAdv();
            button36 = new Button();
            tabNameInput = new TextBox();
            tabPanel = new UI.Controls.TabPanel();
            buttonAdv4 = new UI.Controls.ButtonAdv();
            buttonAdv5 = new UI.Controls.ButtonAdv();
            buttonAdv6 = new UI.Controls.ButtonAdv();
            buttonAdv7 = new UI.Controls.ButtonAdv();
            buttonAdv8 = new UI.Controls.ButtonAdv();
            buttonAdv9 = new UI.Controls.ButtonAdv();
            buttonAdv10 = new UI.Controls.ButtonAdv();
            buttonAdv11 = new UI.Controls.ButtonAdv();
            buttonAdv12 = new UI.Controls.ButtonAdv();
            buttonAdv13 = new UI.Controls.ButtonAdv();
            buttonAdv14 = new UI.Controls.ButtonAdv();
            buttonAdv15 = new UI.Controls.ButtonAdv();
            buttonAdv16 = new UI.Controls.ButtonAdv();
            buttonAdv17 = new UI.Controls.ButtonAdv();
            buttonAdv18 = new UI.Controls.ButtonAdv();
            SuspendLayout();
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
            // tabPanel
            // 
            tabPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabPanel.BackColor = Color.FromArgb(30, 30, 30);
            tabPanel.Location = new Point(24, 12);
            tabPanel.Name = "tabPanel";
            tabPanel.PaintMode = UI.Controls.TabManagement.TabPaintMode.UserPaintOver;
            tabPanel.Size = new Size(513, 322);
            tabPanel.TabIndex = 43;
            tabPanel.Text = "tabPanel1";
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
            buttonAdv4.Location = new Point(577, 12);
            buttonAdv4.Name = "buttonAdv4";
            buttonAdv4.PaintImageOnSelected = true;
            buttonAdv4.processEnterKey = true;
            buttonAdv4.resizeImage = new Point(0, 0);
            buttonAdv4.Selected = false;
            buttonAdv4.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv4.Size = new Size(192, 29);
            buttonAdv4.TabIndex = 44;
            buttonAdv4.Tag = "0";
            buttonAdv4.Text = "DarkRect";
            buttonAdv4.UseVisualStyleBackColor = true;
            buttonAdv4.Click += OnSkinPressed;
            // 
            // buttonAdv5
            // 
            buttonAdv5.BorderColor = Color.DarkGray;
            buttonAdv5.BorderSize = 1;
            buttonAdv5.CStyle = UI.Controls.ButtonAdv.CustomStyle.NORMAL;
            buttonAdv5.expandImage = false;
            buttonAdv5.extraText = "";
            buttonAdv5.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv5.extraTextColor = Color.Black;
            buttonAdv5.extraTextFont = null;
            buttonAdv5.extraTextOffset = new Point(0, 0);
            buttonAdv5.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv5.FocusEnabled = false;
            buttonAdv5.Location = new Point(577, 47);
            buttonAdv5.Name = "buttonAdv5";
            buttonAdv5.PaintImageOnSelected = true;
            buttonAdv5.processEnterKey = true;
            buttonAdv5.resizeImage = new Point(0, 0);
            buttonAdv5.Selected = false;
            buttonAdv5.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv5.Size = new Size(192, 29);
            buttonAdv5.TabIndex = 45;
            buttonAdv5.Tag = "1";
            buttonAdv5.Text = "DarkRectWClose";
            buttonAdv5.UseVisualStyleBackColor = true;
            buttonAdv5.Click += OnSkinPressed;
            // 
            // buttonAdv6
            // 
            buttonAdv6.BorderColor = Color.DarkGray;
            buttonAdv6.BorderSize = 1;
            buttonAdv6.CStyle = UI.Controls.ButtonAdv.CustomStyle.NORMAL;
            buttonAdv6.expandImage = false;
            buttonAdv6.extraText = "";
            buttonAdv6.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv6.extraTextColor = Color.Black;
            buttonAdv6.extraTextFont = null;
            buttonAdv6.extraTextOffset = new Point(0, 0);
            buttonAdv6.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv6.FocusEnabled = false;
            buttonAdv6.Location = new Point(577, 132);
            buttonAdv6.Name = "buttonAdv6";
            buttonAdv6.PaintImageOnSelected = true;
            buttonAdv6.processEnterKey = true;
            buttonAdv6.resizeImage = new Point(0, 0);
            buttonAdv6.Selected = false;
            buttonAdv6.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv6.Size = new Size(192, 29);
            buttonAdv6.TabIndex = 46;
            buttonAdv6.Tag = "3";
            buttonAdv6.Text = "DarkRectExtra";
            buttonAdv6.UseVisualStyleBackColor = true;
            buttonAdv6.Click += OnSkinPressed;
            // 
            // buttonAdv7
            // 
            buttonAdv7.BorderColor = Color.DarkGray;
            buttonAdv7.BorderSize = 1;
            buttonAdv7.CStyle = UI.Controls.ButtonAdv.CustomStyle.NORMAL;
            buttonAdv7.expandImage = false;
            buttonAdv7.extraText = "";
            buttonAdv7.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv7.extraTextColor = Color.Black;
            buttonAdv7.extraTextFont = null;
            buttonAdv7.extraTextOffset = new Point(0, 0);
            buttonAdv7.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv7.FocusEnabled = false;
            buttonAdv7.Location = new Point(577, 167);
            buttonAdv7.Name = "buttonAdv7";
            buttonAdv7.PaintImageOnSelected = true;
            buttonAdv7.processEnterKey = true;
            buttonAdv7.resizeImage = new Point(0, 0);
            buttonAdv7.Selected = false;
            buttonAdv7.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv7.Size = new Size(192, 29);
            buttonAdv7.TabIndex = 47;
            buttonAdv7.Tag = "4";
            buttonAdv7.Text = "DarkRectExtraWClose";
            buttonAdv7.UseVisualStyleBackColor = true;
            buttonAdv7.Click += OnSkinPressed;
            // 
            // buttonAdv8
            // 
            buttonAdv8.BorderColor = Color.DarkGray;
            buttonAdv8.BorderSize = 1;
            buttonAdv8.CStyle = UI.Controls.ButtonAdv.CustomStyle.NORMAL;
            buttonAdv8.expandImage = false;
            buttonAdv8.extraText = "";
            buttonAdv8.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv8.extraTextColor = Color.Black;
            buttonAdv8.extraTextFont = null;
            buttonAdv8.extraTextOffset = new Point(0, 0);
            buttonAdv8.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv8.FocusEnabled = false;
            buttonAdv8.Location = new Point(577, 253);
            buttonAdv8.Name = "buttonAdv8";
            buttonAdv8.PaintImageOnSelected = true;
            buttonAdv8.processEnterKey = true;
            buttonAdv8.resizeImage = new Point(0, 0);
            buttonAdv8.Selected = false;
            buttonAdv8.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv8.Size = new Size(192, 29);
            buttonAdv8.TabIndex = 48;
            buttonAdv8.Tag = "6";
            buttonAdv8.Text = "DarkRound";
            buttonAdv8.UseVisualStyleBackColor = true;
            buttonAdv8.Click += OnSkinPressed;
            // 
            // buttonAdv9
            // 
            buttonAdv9.BorderColor = Color.DarkGray;
            buttonAdv9.BorderSize = 1;
            buttonAdv9.CStyle = UI.Controls.ButtonAdv.CustomStyle.NORMAL;
            buttonAdv9.expandImage = false;
            buttonAdv9.extraText = "";
            buttonAdv9.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv9.extraTextColor = Color.Black;
            buttonAdv9.extraTextFont = null;
            buttonAdv9.extraTextOffset = new Point(0, 0);
            buttonAdv9.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv9.FocusEnabled = false;
            buttonAdv9.Location = new Point(577, 288);
            buttonAdv9.Name = "buttonAdv9";
            buttonAdv9.PaintImageOnSelected = true;
            buttonAdv9.processEnterKey = true;
            buttonAdv9.resizeImage = new Point(0, 0);
            buttonAdv9.Selected = false;
            buttonAdv9.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv9.Size = new Size(192, 29);
            buttonAdv9.TabIndex = 49;
            buttonAdv9.Tag = "7";
            buttonAdv9.Text = "DarkRoundWClose";
            buttonAdv9.UseVisualStyleBackColor = true;
            buttonAdv9.Click += OnSkinPressed;
            // 
            // buttonAdv10
            // 
            buttonAdv10.BorderColor = Color.DarkGray;
            buttonAdv10.BorderSize = 1;
            buttonAdv10.CStyle = UI.Controls.ButtonAdv.CustomStyle.NORMAL;
            buttonAdv10.expandImage = false;
            buttonAdv10.extraText = "";
            buttonAdv10.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv10.extraTextColor = Color.Black;
            buttonAdv10.extraTextFont = null;
            buttonAdv10.extraTextOffset = new Point(0, 0);
            buttonAdv10.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv10.FocusEnabled = false;
            buttonAdv10.Location = new Point(577, 82);
            buttonAdv10.Name = "buttonAdv10";
            buttonAdv10.PaintImageOnSelected = true;
            buttonAdv10.processEnterKey = true;
            buttonAdv10.resizeImage = new Point(0, 0);
            buttonAdv10.Selected = false;
            buttonAdv10.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv10.Size = new Size(192, 29);
            buttonAdv10.TabIndex = 50;
            buttonAdv10.Tag = "2";
            buttonAdv10.Text = "DarkRectWCloseSel";
            buttonAdv10.UseVisualStyleBackColor = true;
            buttonAdv10.Click += OnSkinPressed;
            // 
            // buttonAdv11
            // 
            buttonAdv11.BorderColor = Color.DarkGray;
            buttonAdv11.BorderSize = 1;
            buttonAdv11.CStyle = UI.Controls.ButtonAdv.CustomStyle.NORMAL;
            buttonAdv11.expandImage = false;
            buttonAdv11.extraText = "";
            buttonAdv11.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv11.extraTextColor = Color.Black;
            buttonAdv11.extraTextFont = null;
            buttonAdv11.extraTextOffset = new Point(0, 0);
            buttonAdv11.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv11.FocusEnabled = false;
            buttonAdv11.Location = new Point(577, 202);
            buttonAdv11.Name = "buttonAdv11";
            buttonAdv11.PaintImageOnSelected = true;
            buttonAdv11.processEnterKey = true;
            buttonAdv11.resizeImage = new Point(0, 0);
            buttonAdv11.Selected = false;
            buttonAdv11.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv11.Size = new Size(192, 29);
            buttonAdv11.TabIndex = 51;
            buttonAdv11.Tag = "5";
            buttonAdv11.Text = "DarkRectWCloseSel";
            buttonAdv11.UseVisualStyleBackColor = true;
            buttonAdv11.Click += OnSkinPressed;
            // 
            // buttonAdv12
            // 
            buttonAdv12.BorderColor = Color.DarkGray;
            buttonAdv12.BorderSize = 1;
            buttonAdv12.CStyle = UI.Controls.ButtonAdv.CustomStyle.NORMAL;
            buttonAdv12.expandImage = false;
            buttonAdv12.extraText = "";
            buttonAdv12.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv12.extraTextColor = Color.Black;
            buttonAdv12.extraTextFont = null;
            buttonAdv12.extraTextOffset = new Point(0, 0);
            buttonAdv12.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv12.FocusEnabled = false;
            buttonAdv12.Location = new Point(577, 323);
            buttonAdv12.Name = "buttonAdv12";
            buttonAdv12.PaintImageOnSelected = true;
            buttonAdv12.processEnterKey = true;
            buttonAdv12.resizeImage = new Point(0, 0);
            buttonAdv12.Selected = false;
            buttonAdv12.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv12.Size = new Size(192, 29);
            buttonAdv12.TabIndex = 52;
            buttonAdv12.Tag = "8";
            buttonAdv12.Text = "DarkRoundWCloseSel";
            buttonAdv12.UseVisualStyleBackColor = true;
            buttonAdv12.Click += OnSkinPressed;
            // 
            // buttonAdv13
            // 
            buttonAdv13.BorderColor = Color.DarkGray;
            buttonAdv13.BorderSize = 1;
            buttonAdv13.CStyle = UI.Controls.ButtonAdv.CustomStyle.NORMAL;
            buttonAdv13.expandImage = false;
            buttonAdv13.extraText = "";
            buttonAdv13.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv13.extraTextColor = Color.Black;
            buttonAdv13.extraTextFont = null;
            buttonAdv13.extraTextOffset = new Point(0, 0);
            buttonAdv13.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv13.FocusEnabled = false;
            buttonAdv13.Location = new Point(785, 82);
            buttonAdv13.Name = "buttonAdv13";
            buttonAdv13.PaintImageOnSelected = true;
            buttonAdv13.processEnterKey = true;
            buttonAdv13.resizeImage = new Point(0, 0);
            buttonAdv13.Selected = false;
            buttonAdv13.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv13.Size = new Size(192, 29);
            buttonAdv13.TabIndex = 55;
            buttonAdv13.Tag = "11";
            buttonAdv13.Text = "DarkRectThinWCloseSel";
            buttonAdv13.UseVisualStyleBackColor = true;
            buttonAdv13.Click += OnSkinPressed;
            // 
            // buttonAdv14
            // 
            buttonAdv14.BorderColor = Color.DarkGray;
            buttonAdv14.BorderSize = 1;
            buttonAdv14.CStyle = UI.Controls.ButtonAdv.CustomStyle.NORMAL;
            buttonAdv14.expandImage = false;
            buttonAdv14.extraText = "";
            buttonAdv14.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv14.extraTextColor = Color.Black;
            buttonAdv14.extraTextFont = null;
            buttonAdv14.extraTextOffset = new Point(0, 0);
            buttonAdv14.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv14.FocusEnabled = false;
            buttonAdv14.Location = new Point(785, 47);
            buttonAdv14.Name = "buttonAdv14";
            buttonAdv14.PaintImageOnSelected = true;
            buttonAdv14.processEnterKey = true;
            buttonAdv14.resizeImage = new Point(0, 0);
            buttonAdv14.Selected = false;
            buttonAdv14.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv14.Size = new Size(192, 29);
            buttonAdv14.TabIndex = 54;
            buttonAdv14.Tag = "10";
            buttonAdv14.Text = "DarkRectThinWClose";
            buttonAdv14.UseVisualStyleBackColor = true;
            buttonAdv14.Click += OnSkinPressed;
            // 
            // buttonAdv15
            // 
            buttonAdv15.BorderColor = Color.DarkGray;
            buttonAdv15.BorderSize = 1;
            buttonAdv15.CStyle = UI.Controls.ButtonAdv.CustomStyle.NORMAL;
            buttonAdv15.expandImage = false;
            buttonAdv15.extraText = "";
            buttonAdv15.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv15.extraTextColor = Color.Black;
            buttonAdv15.extraTextFont = null;
            buttonAdv15.extraTextOffset = new Point(0, 0);
            buttonAdv15.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv15.FocusEnabled = false;
            buttonAdv15.Location = new Point(785, 12);
            buttonAdv15.Name = "buttonAdv15";
            buttonAdv15.PaintImageOnSelected = true;
            buttonAdv15.processEnterKey = true;
            buttonAdv15.resizeImage = new Point(0, 0);
            buttonAdv15.Selected = false;
            buttonAdv15.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv15.Size = new Size(192, 29);
            buttonAdv15.TabIndex = 53;
            buttonAdv15.Tag = "9";
            buttonAdv15.Text = "DarkRectThin";
            buttonAdv15.UseVisualStyleBackColor = true;
            buttonAdv15.Click += OnSkinPressed;
            // 
            // buttonAdv16
            // 
            buttonAdv16.BorderColor = Color.DarkGray;
            buttonAdv16.BorderSize = 1;
            buttonAdv16.CStyle = UI.Controls.ButtonAdv.CustomStyle.NORMAL;
            buttonAdv16.expandImage = false;
            buttonAdv16.extraText = "";
            buttonAdv16.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv16.extraTextColor = Color.Black;
            buttonAdv16.extraTextFont = null;
            buttonAdv16.extraTextOffset = new Point(0, 0);
            buttonAdv16.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv16.FocusEnabled = false;
            buttonAdv16.Location = new Point(785, 323);
            buttonAdv16.Name = "buttonAdv16";
            buttonAdv16.PaintImageOnSelected = true;
            buttonAdv16.processEnterKey = true;
            buttonAdv16.resizeImage = new Point(0, 0);
            buttonAdv16.Selected = false;
            buttonAdv16.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv16.Size = new Size(192, 29);
            buttonAdv16.TabIndex = 58;
            buttonAdv16.Tag = "14";
            buttonAdv16.Text = "DarkMiddleRountWCloseSel";
            buttonAdv16.UseVisualStyleBackColor = true;
            buttonAdv16.Click += OnSkinPressed;
            // 
            // buttonAdv17
            // 
            buttonAdv17.BorderColor = Color.DarkGray;
            buttonAdv17.BorderSize = 1;
            buttonAdv17.CStyle = UI.Controls.ButtonAdv.CustomStyle.NORMAL;
            buttonAdv17.expandImage = false;
            buttonAdv17.extraText = "";
            buttonAdv17.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv17.extraTextColor = Color.Black;
            buttonAdv17.extraTextFont = null;
            buttonAdv17.extraTextOffset = new Point(0, 0);
            buttonAdv17.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv17.FocusEnabled = false;
            buttonAdv17.Location = new Point(785, 288);
            buttonAdv17.Name = "buttonAdv17";
            buttonAdv17.PaintImageOnSelected = true;
            buttonAdv17.processEnterKey = true;
            buttonAdv17.resizeImage = new Point(0, 0);
            buttonAdv17.Selected = false;
            buttonAdv17.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv17.Size = new Size(192, 29);
            buttonAdv17.TabIndex = 57;
            buttonAdv17.Tag = "13";
            buttonAdv17.Text = "DarkMiddleRoundWClose";
            buttonAdv17.UseVisualStyleBackColor = true;
            buttonAdv17.Click += OnSkinPressed;
            // 
            // buttonAdv18
            // 
            buttonAdv18.BorderColor = Color.DarkGray;
            buttonAdv18.BorderSize = 1;
            buttonAdv18.CStyle = UI.Controls.ButtonAdv.CustomStyle.NORMAL;
            buttonAdv18.expandImage = false;
            buttonAdv18.extraText = "";
            buttonAdv18.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv18.extraTextColor = Color.Black;
            buttonAdv18.extraTextFont = null;
            buttonAdv18.extraTextOffset = new Point(0, 0);
            buttonAdv18.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv18.FocusEnabled = false;
            buttonAdv18.Location = new Point(785, 253);
            buttonAdv18.Name = "buttonAdv18";
            buttonAdv18.PaintImageOnSelected = true;
            buttonAdv18.processEnterKey = true;
            buttonAdv18.resizeImage = new Point(0, 0);
            buttonAdv18.Selected = false;
            buttonAdv18.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv18.Size = new Size(192, 29);
            buttonAdv18.TabIndex = 56;
            buttonAdv18.Tag = "12";
            buttonAdv18.Text = "DarkMiddleRound";
            buttonAdv18.UseVisualStyleBackColor = true;
            buttonAdv18.Click += OnSkinPressed;
            // 
            // TabTester2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            ClientSize = new Size(1130, 651);
            Controls.Add(buttonAdv16);
            Controls.Add(buttonAdv17);
            Controls.Add(buttonAdv18);
            Controls.Add(buttonAdv13);
            Controls.Add(buttonAdv14);
            Controls.Add(buttonAdv15);
            Controls.Add(buttonAdv12);
            Controls.Add(buttonAdv11);
            Controls.Add(buttonAdv10);
            Controls.Add(buttonAdv9);
            Controls.Add(buttonAdv8);
            Controls.Add(buttonAdv7);
            Controls.Add(buttonAdv6);
            Controls.Add(buttonAdv5);
            Controls.Add(buttonAdv4);
            Controls.Add(tabPanel);
            Controls.Add(button36);
            Controls.Add(tabNameInput);
            Controls.Add(buttonAdv3);
            Controls.Add(buttonAdv2);
            Controls.Add(buttonAdv1);
            Controls.Add(clearButton);
            Controls.Add(console);
            Name = "TabTester2";
            Text = "TabTester2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private UI.XConsole console;
        private UI.Controls.ButtonAdv clearButton;
        private UI.Controls.ButtonAdv buttonAdv1;
        private UI.Controls.ButtonAdv buttonAdv2;
        private UI.Controls.ButtonAdv buttonAdv3;
        private Button button36;
        private TextBox tabNameInput;
        private UI.Controls.TabPanel tabPanel;
        private UI.Controls.ButtonAdv buttonAdv4;
        private UI.Controls.ButtonAdv buttonAdv5;
        private UI.Controls.ButtonAdv buttonAdv6;
        private UI.Controls.ButtonAdv buttonAdv7;
        private UI.Controls.ButtonAdv buttonAdv8;
        private UI.Controls.ButtonAdv buttonAdv9;
        private UI.Controls.ButtonAdv buttonAdv10;
        private UI.Controls.ButtonAdv buttonAdv11;
        private UI.Controls.ButtonAdv buttonAdv12;
        private UI.Controls.ButtonAdv buttonAdv13;
        private UI.Controls.ButtonAdv buttonAdv14;
        private UI.Controls.ButtonAdv buttonAdv15;
        private UI.Controls.ButtonAdv buttonAdv16;
        private UI.Controls.ButtonAdv buttonAdv17;
        private UI.Controls.ButtonAdv buttonAdv18;
    }
}