namespace VampirioCode.Tests
{
    partial class TreeViewTester
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
            treeView = new TreeView();
            treeViewAdv = new UI.Controls.TreeViewAdv();
            consoleOutp = new UI.XConsole();
            labelAdv1 = new UI.Controls.LabelAdv();
            nodeHeightInput = new UI.Controls.IntTextBox();
            NodeIndentInput = new UI.Controls.IntTextBox();
            labelAdv2 = new UI.Controls.LabelAdv();
            fontSizeInput = new UI.Controls.IntTextBox();
            labelAdv3 = new UI.Controls.LabelAdv();
            icon1EnableCKBox = new CheckBox();
            icon2EnableCKBox = new CheckBox();
            buttonAdv1 = new UI.Controls.ButtonAdv();
            buttonAdv2 = new UI.Controls.ButtonAdv();
            buttonAdv3 = new UI.Controls.ButtonAdv();
            buttonAdv4 = new UI.Controls.ButtonAdv();
            buttonAdv5 = new UI.Controls.ButtonAdv();
            delete_classic = new UI.Controls.ButtonAdv();
            collapse_classic = new UI.Controls.ButtonAdv();
            expand_classic = new UI.Controls.ButtonAdv();
            insert_classic = new UI.Controls.ButtonAdv();
            expand_tree_classic = new UI.Controls.ButtonAdv();
            buttonAdv6 = new UI.Controls.ButtonAdv();
            buttonAdv7 = new UI.Controls.ButtonAdv();
            buttonAdv8 = new UI.Controls.ButtonAdv();
            buttonAdv9 = new UI.Controls.ButtonAdv();
            pathInput = new UI.Controls.TextBoxAdv();
            buttonAdv10 = new UI.Controls.ButtonAdv();
            labelAdv4 = new UI.Controls.LabelAdv();
            buttonAdv11 = new UI.Controls.ButtonAdv();
            labelAdv5 = new UI.Controls.LabelAdv();
            storedInput = new UI.Controls.TextBoxAdv();
            buttonAdv12 = new UI.Controls.ButtonAdv();
            buttonAdv13 = new UI.Controls.ButtonAdv();
            SuspendLayout();
            // 
            // treeView
            // 
            treeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            treeView.BackColor = Color.SkyBlue;
            treeView.BorderStyle = BorderStyle.FixedSingle;
            treeView.ForeColor = Color.White;
            treeView.Location = new Point(6, 12);
            treeView.Name = "treeView";
            treeView.Size = new Size(510, 337);
            treeView.TabIndex = 0;
            // 
            // treeViewAdv
            // 
            treeViewAdv.AllowTextEdition = true;
            treeViewAdv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            treeViewAdv.BackColor = Color.FromArgb(31, 31, 13);
            treeViewAdv.LinesColor = Color.FromArgb(100, 100, 100);
            treeViewAdv.Location = new Point(524, 12);
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
            treeViewAdv.Size = new Size(459, 337);
            treeViewAdv.TabIndex = 1;
            treeViewAdv.Text = "treeViewAdv1";
            treeViewAdv.TextSpace = 5;
            // 
            // consoleOutp
            // 
            consoleOutp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            consoleOutp.BackColor = Color.FromArgb(40, 40, 40);
            consoleOutp.Location = new Point(6, 410);
            consoleOutp.Name = "consoleOutp";
            consoleOutp.Size = new Size(510, 190);
            consoleOutp.TabIndex = 2;
            // 
            // labelAdv1
            // 
            labelAdv1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelAdv1.AutoSize = true;
            labelAdv1.BorderColor = Color.DarkGray;
            labelAdv1.BorderSize = 1;
            labelAdv1.CStyle = UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv1.ForeColor = Color.Silver;
            labelAdv1.Location = new Point(524, 485);
            labelAdv1.ModifyClampMax = 0F;
            labelAdv1.ModifyClampMin = 0F;
            labelAdv1.ModifyControlName = "";
            labelAdv1.ModifyScale = 1F;
            labelAdv1.Name = "labelAdv1";
            labelAdv1.Size = new Size(95, 20);
            labelAdv1.TabIndex = 4;
            labelAdv1.Text = "Node Height";
            // 
            // nodeHeightInput
            // 
            nodeHeightInput.AllowEmptyInput = false;
            nodeHeightInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            nodeHeightInput.BackColor = Color.FromArgb(80, 80, 80);
            nodeHeightInput.BorderStyle = BorderStyle.FixedSingle;
            nodeHeightInput.ForeColor = Color.Silver;
            nodeHeightInput.Location = new Point(524, 508);
            nodeHeightInput.Name = "nodeHeightInput";
            nodeHeightInput.NumberMask = "";
            nodeHeightInput.Size = new Size(95, 27);
            nodeHeightInput.TabIndex = 5;
            nodeHeightInput.EnterPressed += OnNodeHeightEnterPressed;
            // 
            // NodeIndentInput
            // 
            NodeIndentInput.AllowEmptyInput = false;
            NodeIndentInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            NodeIndentInput.BackColor = Color.FromArgb(80, 80, 80);
            NodeIndentInput.BorderStyle = BorderStyle.FixedSingle;
            NodeIndentInput.ForeColor = Color.Silver;
            NodeIndentInput.Location = new Point(625, 508);
            NodeIndentInput.Name = "NodeIndentInput";
            NodeIndentInput.NumberMask = "";
            NodeIndentInput.Size = new Size(95, 27);
            NodeIndentInput.TabIndex = 7;
            NodeIndentInput.EnterPressed += OnNodeIndentEnterPressed;
            // 
            // labelAdv2
            // 
            labelAdv2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelAdv2.AutoSize = true;
            labelAdv2.BorderColor = Color.DarkGray;
            labelAdv2.BorderSize = 1;
            labelAdv2.CStyle = UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv2.ForeColor = Color.Silver;
            labelAdv2.Location = new Point(625, 485);
            labelAdv2.ModifyClampMax = 0F;
            labelAdv2.ModifyClampMin = 0F;
            labelAdv2.ModifyControlName = "";
            labelAdv2.ModifyScale = 1F;
            labelAdv2.Name = "labelAdv2";
            labelAdv2.Size = new Size(82, 20);
            labelAdv2.TabIndex = 6;
            labelAdv2.Text = "Indent Size";
            // 
            // fontSizeInput
            // 
            fontSizeInput.AllowEmptyInput = false;
            fontSizeInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            fontSizeInput.BackColor = Color.FromArgb(80, 80, 80);
            fontSizeInput.BorderStyle = BorderStyle.FixedSingle;
            fontSizeInput.ForeColor = Color.Silver;
            fontSizeInput.Location = new Point(524, 561);
            fontSizeInput.Name = "fontSizeInput";
            fontSizeInput.NumberMask = "";
            fontSizeInput.Size = new Size(95, 27);
            fontSizeInput.TabIndex = 9;
            fontSizeInput.EnterPressed += OnFontSizeEnterPressed;
            // 
            // labelAdv3
            // 
            labelAdv3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelAdv3.AutoSize = true;
            labelAdv3.BorderColor = Color.DarkGray;
            labelAdv3.BorderSize = 1;
            labelAdv3.CStyle = UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv3.ForeColor = Color.Silver;
            labelAdv3.Location = new Point(524, 538);
            labelAdv3.ModifyClampMax = 0F;
            labelAdv3.ModifyClampMin = 0F;
            labelAdv3.ModifyControlName = "";
            labelAdv3.ModifyScale = 1F;
            labelAdv3.Name = "labelAdv3";
            labelAdv3.Size = new Size(63, 20);
            labelAdv3.TabIndex = 8;
            labelAdv3.Text = "fontSize";
            // 
            // icon1EnableCKBox
            // 
            icon1EnableCKBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            icon1EnableCKBox.AutoSize = true;
            icon1EnableCKBox.FlatStyle = FlatStyle.Flat;
            icon1EnableCKBox.ForeColor = Color.Silver;
            icon1EnableCKBox.Location = new Point(628, 561);
            icon1EnableCKBox.Name = "icon1EnableCKBox";
            icon1EnableCKBox.Size = new Size(112, 24);
            icon1EnableCKBox.TabIndex = 10;
            icon1EnableCKBox.Text = "icon1 Enable";
            icon1EnableCKBox.UseVisualStyleBackColor = true;
            icon1EnableCKBox.CheckedChanged += OnIcon1CheckedChanged;
            // 
            // icon2EnableCKBox
            // 
            icon2EnableCKBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            icon2EnableCKBox.AutoSize = true;
            icon2EnableCKBox.FlatStyle = FlatStyle.Flat;
            icon2EnableCKBox.ForeColor = Color.Silver;
            icon2EnableCKBox.Location = new Point(759, 561);
            icon2EnableCKBox.Name = "icon2EnableCKBox";
            icon2EnableCKBox.Size = new Size(112, 24);
            icon2EnableCKBox.TabIndex = 11;
            icon2EnableCKBox.Text = "icon2 Enable";
            icon2EnableCKBox.UseVisualStyleBackColor = true;
            icon2EnableCKBox.CheckedChanged += OnIcon2CheckedChanged;
            // 
            // buttonAdv1
            // 
            buttonAdv1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAdv1.BackColor = Color.SlateBlue;
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
            buttonAdv1.ForeColor = Color.White;
            buttonAdv1.Location = new Point(522, 355);
            buttonAdv1.Name = "buttonAdv1";
            buttonAdv1.PaintImageOnSelected = true;
            buttonAdv1.processEnterKey = true;
            buttonAdv1.resizeImage = new Point(0, 0);
            buttonAdv1.Selected = false;
            buttonAdv1.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv1.Size = new Size(85, 49);
            buttonAdv1.TabIndex = 12;
            buttonAdv1.Text = "Insert Node";
            buttonAdv1.UseVisualStyleBackColor = false;
            buttonAdv1.Click += OnInsertNodePressed;
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
            buttonAdv2.Location = new Point(915, 561);
            buttonAdv2.Name = "buttonAdv2";
            buttonAdv2.PaintImageOnSelected = true;
            buttonAdv2.processEnterKey = true;
            buttonAdv2.resizeImage = new Point(0, 0);
            buttonAdv2.Selected = false;
            buttonAdv2.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv2.Size = new Size(68, 29);
            buttonAdv2.TabIndex = 13;
            buttonAdv2.Text = "refresh";
            buttonAdv2.UseVisualStyleBackColor = false;
            buttonAdv2.Click += OnRefreshPressed;
            // 
            // buttonAdv3
            // 
            buttonAdv3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAdv3.BackColor = Color.FromArgb(20, 20, 20);
            buttonAdv3.BorderColor = Color.FromArgb(70, 70, 70);
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
            buttonAdv3.ForeColor = Color.Silver;
            buttonAdv3.Location = new Point(723, 355);
            buttonAdv3.Name = "buttonAdv3";
            buttonAdv3.PaintImageOnSelected = true;
            buttonAdv3.processEnterKey = true;
            buttonAdv3.resizeImage = new Point(0, 0);
            buttonAdv3.Selected = false;
            buttonAdv3.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv3.Size = new Size(119, 29);
            buttonAdv3.TabIndex = 14;
            buttonAdv3.Text = "expand";
            buttonAdv3.UseVisualStyleBackColor = false;
            buttonAdv3.Click += OnExpandPressed;
            // 
            // buttonAdv4
            // 
            buttonAdv4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAdv4.BackColor = Color.FromArgb(20, 20, 20);
            buttonAdv4.BorderColor = Color.FromArgb(70, 70, 70);
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
            buttonAdv4.ForeColor = Color.Silver;
            buttonAdv4.Location = new Point(848, 355);
            buttonAdv4.Name = "buttonAdv4";
            buttonAdv4.PaintImageOnSelected = true;
            buttonAdv4.processEnterKey = true;
            buttonAdv4.resizeImage = new Point(0, 0);
            buttonAdv4.Selected = false;
            buttonAdv4.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv4.Size = new Size(119, 29);
            buttonAdv4.TabIndex = 15;
            buttonAdv4.Text = "collapse";
            buttonAdv4.UseVisualStyleBackColor = false;
            buttonAdv4.Click += OnCollapsePressed;
            // 
            // buttonAdv5
            // 
            buttonAdv5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAdv5.BackColor = Color.IndianRed;
            buttonAdv5.BorderColor = Color.FromArgb(70, 70, 70);
            buttonAdv5.BorderSize = 1;
            buttonAdv5.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            buttonAdv5.expandImage = false;
            buttonAdv5.extraText = "";
            buttonAdv5.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv5.extraTextColor = Color.Black;
            buttonAdv5.extraTextFont = null;
            buttonAdv5.extraTextOffset = new Point(0, 0);
            buttonAdv5.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv5.FocusEnabled = false;
            buttonAdv5.ForeColor = Color.White;
            buttonAdv5.Location = new Point(623, 355);
            buttonAdv5.Name = "buttonAdv5";
            buttonAdv5.PaintImageOnSelected = true;
            buttonAdv5.processEnterKey = true;
            buttonAdv5.resizeImage = new Point(0, 0);
            buttonAdv5.Selected = false;
            buttonAdv5.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv5.Size = new Size(85, 49);
            buttonAdv5.TabIndex = 16;
            buttonAdv5.Text = "Delete Node";
            buttonAdv5.UseVisualStyleBackColor = false;
            buttonAdv5.Click += OnDeleteNodePressed;
            // 
            // delete_classic
            // 
            delete_classic.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            delete_classic.BackColor = Color.IndianRed;
            delete_classic.BorderColor = Color.FromArgb(70, 70, 70);
            delete_classic.BorderSize = 1;
            delete_classic.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            delete_classic.expandImage = false;
            delete_classic.extraText = "";
            delete_classic.extraTextAlign = ContentAlignment.MiddleCenter;
            delete_classic.extraTextColor = Color.Black;
            delete_classic.extraTextFont = null;
            delete_classic.extraTextOffset = new Point(0, 0);
            delete_classic.FocusColor = Color.FromArgb(24, 81, 115);
            delete_classic.FocusEnabled = false;
            delete_classic.ForeColor = Color.White;
            delete_classic.Location = new Point(106, 355);
            delete_classic.Name = "delete_classic";
            delete_classic.PaintImageOnSelected = true;
            delete_classic.processEnterKey = true;
            delete_classic.resizeImage = new Point(0, 0);
            delete_classic.Selected = false;
            delete_classic.SelectedColor = Color.FromArgb(0, 122, 204);
            delete_classic.Size = new Size(85, 49);
            delete_classic.TabIndex = 20;
            delete_classic.Text = "Delete Node";
            delete_classic.UseVisualStyleBackColor = false;
            delete_classic.Click += OnClassicPressed;
            // 
            // collapse_classic
            // 
            collapse_classic.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            collapse_classic.BackColor = Color.FromArgb(20, 20, 20);
            collapse_classic.BorderColor = Color.FromArgb(70, 70, 70);
            collapse_classic.BorderSize = 1;
            collapse_classic.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            collapse_classic.expandImage = false;
            collapse_classic.extraText = "";
            collapse_classic.extraTextAlign = ContentAlignment.MiddleCenter;
            collapse_classic.extraTextColor = Color.Black;
            collapse_classic.extraTextFont = null;
            collapse_classic.extraTextOffset = new Point(0, 0);
            collapse_classic.FocusColor = Color.FromArgb(24, 81, 115);
            collapse_classic.FocusEnabled = false;
            collapse_classic.ForeColor = Color.Silver;
            collapse_classic.Location = new Point(301, 355);
            collapse_classic.Name = "collapse_classic";
            collapse_classic.PaintImageOnSelected = true;
            collapse_classic.processEnterKey = true;
            collapse_classic.resizeImage = new Point(0, 0);
            collapse_classic.Selected = false;
            collapse_classic.SelectedColor = Color.FromArgb(0, 122, 204);
            collapse_classic.Size = new Size(85, 29);
            collapse_classic.TabIndex = 19;
            collapse_classic.Text = "collapse";
            collapse_classic.UseVisualStyleBackColor = false;
            collapse_classic.Click += OnClassicPressed;
            // 
            // expand_classic
            // 
            expand_classic.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            expand_classic.BackColor = Color.FromArgb(20, 20, 20);
            expand_classic.BorderColor = Color.FromArgb(70, 70, 70);
            expand_classic.BorderSize = 1;
            expand_classic.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            expand_classic.expandImage = false;
            expand_classic.extraText = "";
            expand_classic.extraTextAlign = ContentAlignment.MiddleCenter;
            expand_classic.extraTextColor = Color.Black;
            expand_classic.extraTextFont = null;
            expand_classic.extraTextOffset = new Point(0, 0);
            expand_classic.FocusColor = Color.FromArgb(24, 81, 115);
            expand_classic.FocusEnabled = false;
            expand_classic.ForeColor = Color.Silver;
            expand_classic.Location = new Point(207, 355);
            expand_classic.Name = "expand_classic";
            expand_classic.PaintImageOnSelected = true;
            expand_classic.processEnterKey = true;
            expand_classic.resizeImage = new Point(0, 0);
            expand_classic.Selected = false;
            expand_classic.SelectedColor = Color.FromArgb(0, 122, 204);
            expand_classic.Size = new Size(85, 29);
            expand_classic.TabIndex = 18;
            expand_classic.Text = "expand";
            expand_classic.UseVisualStyleBackColor = false;
            expand_classic.Click += OnClassicPressed;
            // 
            // insert_classic
            // 
            insert_classic.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            insert_classic.BackColor = Color.SlateBlue;
            insert_classic.BorderColor = Color.FromArgb(70, 70, 70);
            insert_classic.BorderSize = 1;
            insert_classic.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            insert_classic.expandImage = false;
            insert_classic.extraText = "";
            insert_classic.extraTextAlign = ContentAlignment.MiddleCenter;
            insert_classic.extraTextColor = Color.Black;
            insert_classic.extraTextFont = null;
            insert_classic.extraTextOffset = new Point(0, 0);
            insert_classic.FocusColor = Color.FromArgb(24, 81, 115);
            insert_classic.FocusEnabled = false;
            insert_classic.ForeColor = Color.White;
            insert_classic.Location = new Point(5, 355);
            insert_classic.Name = "insert_classic";
            insert_classic.PaintImageOnSelected = true;
            insert_classic.processEnterKey = true;
            insert_classic.resizeImage = new Point(0, 0);
            insert_classic.Selected = false;
            insert_classic.SelectedColor = Color.FromArgb(0, 122, 204);
            insert_classic.Size = new Size(85, 49);
            insert_classic.TabIndex = 17;
            insert_classic.Text = "Insert Node";
            insert_classic.UseVisualStyleBackColor = false;
            insert_classic.Click += OnClassicPressed;
            // 
            // expand_tree_classic
            // 
            expand_tree_classic.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            expand_tree_classic.BackColor = Color.FromArgb(20, 20, 20);
            expand_tree_classic.BorderColor = Color.FromArgb(70, 70, 70);
            expand_tree_classic.BorderSize = 1;
            expand_tree_classic.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            expand_tree_classic.expandImage = false;
            expand_tree_classic.extraText = "";
            expand_tree_classic.extraTextAlign = ContentAlignment.MiddleCenter;
            expand_tree_classic.extraTextColor = Color.Black;
            expand_tree_classic.extraTextFont = null;
            expand_tree_classic.extraTextOffset = new Point(0, 0);
            expand_tree_classic.FocusColor = Color.FromArgb(24, 81, 115);
            expand_tree_classic.FocusEnabled = false;
            expand_tree_classic.ForeColor = Color.Silver;
            expand_tree_classic.Location = new Point(397, 355);
            expand_tree_classic.Name = "expand_tree_classic";
            expand_tree_classic.PaintImageOnSelected = true;
            expand_tree_classic.processEnterKey = true;
            expand_tree_classic.resizeImage = new Point(0, 0);
            expand_tree_classic.Selected = false;
            expand_tree_classic.SelectedColor = Color.FromArgb(0, 122, 204);
            expand_tree_classic.Size = new Size(119, 29);
            expand_tree_classic.TabIndex = 21;
            expand_tree_classic.Text = "expand tree";
            expand_tree_classic.UseVisualStyleBackColor = false;
            expand_tree_classic.Click += OnClassicPressed;
            // 
            // buttonAdv6
            // 
            buttonAdv6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAdv6.BackColor = Color.FromArgb(20, 20, 20);
            buttonAdv6.BorderColor = Color.FromArgb(70, 70, 70);
            buttonAdv6.BorderSize = 1;
            buttonAdv6.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            buttonAdv6.expandImage = false;
            buttonAdv6.extraText = "";
            buttonAdv6.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv6.extraTextColor = Color.Black;
            buttonAdv6.extraTextFont = null;
            buttonAdv6.extraTextOffset = new Point(0, 0);
            buttonAdv6.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv6.FocusEnabled = false;
            buttonAdv6.ForeColor = Color.Silver;
            buttonAdv6.Location = new Point(723, 390);
            buttonAdv6.Name = "buttonAdv6";
            buttonAdv6.PaintImageOnSelected = true;
            buttonAdv6.processEnterKey = true;
            buttonAdv6.resizeImage = new Point(0, 0);
            buttonAdv6.Selected = false;
            buttonAdv6.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv6.Size = new Size(119, 29);
            buttonAdv6.TabIndex = 22;
            buttonAdv6.Text = "expand tree";
            buttonAdv6.UseVisualStyleBackColor = false;
            buttonAdv6.Click += OnExpandTreePressed;
            // 
            // buttonAdv7
            // 
            buttonAdv7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAdv7.BackColor = Color.FromArgb(20, 20, 20);
            buttonAdv7.BorderColor = Color.FromArgb(70, 70, 70);
            buttonAdv7.BorderSize = 1;
            buttonAdv7.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            buttonAdv7.expandImage = false;
            buttonAdv7.extraText = "";
            buttonAdv7.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv7.extraTextColor = Color.Black;
            buttonAdv7.extraTextFont = null;
            buttonAdv7.extraTextOffset = new Point(0, 0);
            buttonAdv7.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv7.FocusEnabled = false;
            buttonAdv7.ForeColor = Color.Silver;
            buttonAdv7.Location = new Point(848, 390);
            buttonAdv7.Name = "buttonAdv7";
            buttonAdv7.PaintImageOnSelected = true;
            buttonAdv7.processEnterKey = true;
            buttonAdv7.resizeImage = new Point(0, 0);
            buttonAdv7.Selected = false;
            buttonAdv7.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv7.Size = new Size(119, 29);
            buttonAdv7.TabIndex = 23;
            buttonAdv7.Text = "collapse tree";
            buttonAdv7.UseVisualStyleBackColor = false;
            buttonAdv7.Click += OnCollapseTreePressed;
            // 
            // buttonAdv8
            // 
            buttonAdv8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAdv8.BackColor = Color.FromArgb(20, 20, 20);
            buttonAdv8.BorderColor = Color.FromArgb(70, 70, 70);
            buttonAdv8.BorderSize = 1;
            buttonAdv8.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            buttonAdv8.expandImage = false;
            buttonAdv8.extraText = "";
            buttonAdv8.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv8.extraTextColor = Color.Black;
            buttonAdv8.extraTextFont = null;
            buttonAdv8.extraTextOffset = new Point(0, 0);
            buttonAdv8.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv8.FocusEnabled = false;
            buttonAdv8.ForeColor = Color.Silver;
            buttonAdv8.Location = new Point(723, 425);
            buttonAdv8.Name = "buttonAdv8";
            buttonAdv8.PaintImageOnSelected = true;
            buttonAdv8.processEnterKey = true;
            buttonAdv8.resizeImage = new Point(0, 0);
            buttonAdv8.Selected = false;
            buttonAdv8.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv8.Size = new Size(119, 41);
            buttonAdv8.TabIndex = 24;
            buttonAdv8.Text = "expand all nodes";
            buttonAdv8.UseVisualStyleBackColor = false;
            buttonAdv8.Click += OnExpandAllNodes;
            // 
            // buttonAdv9
            // 
            buttonAdv9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAdv9.BackColor = Color.FromArgb(20, 20, 20);
            buttonAdv9.BorderColor = Color.FromArgb(70, 70, 70);
            buttonAdv9.BorderSize = 1;
            buttonAdv9.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            buttonAdv9.expandImage = false;
            buttonAdv9.extraText = "";
            buttonAdv9.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv9.extraTextColor = Color.Black;
            buttonAdv9.extraTextFont = null;
            buttonAdv9.extraTextOffset = new Point(0, 0);
            buttonAdv9.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv9.FocusEnabled = false;
            buttonAdv9.ForeColor = Color.Silver;
            buttonAdv9.Location = new Point(848, 425);
            buttonAdv9.Name = "buttonAdv9";
            buttonAdv9.PaintImageOnSelected = true;
            buttonAdv9.processEnterKey = true;
            buttonAdv9.resizeImage = new Point(0, 0);
            buttonAdv9.Selected = false;
            buttonAdv9.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv9.Size = new Size(119, 41);
            buttonAdv9.TabIndex = 25;
            buttonAdv9.Text = "collapse all nodes";
            buttonAdv9.UseVisualStyleBackColor = false;
            buttonAdv9.Click += OnCollapseAllNodes;
            // 
            // pathInput
            // 
            pathInput.AllowBackspace = true;
            pathInput.AllowTextEdition = true;
            pathInput.AutoEdition = false;
            pathInput.AutoSelect = false;
            pathInput.BackColor = Color.FromArgb(80, 80, 80);
            pathInput.BorderStyle = BorderStyle.FixedSingle;
            pathInput.ExcludeCharacters = null;
            pathInput.ForeColor = Color.Silver;
            pathInput.IncludeOnlyCharacters = null;
            pathInput.LeftLeadingCharacter = '\0';
            pathInput.Location = new Point(524, 439);
            pathInput.Name = "pathInput";
            pathInput.Size = new Size(118, 27);
            pathInput.TabIndex = 26;
            pathInput.Text = "/root/test B0/test B1/";
            // 
            // buttonAdv10
            // 
            buttonAdv10.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAdv10.BackColor = Color.FromArgb(20, 20, 20);
            buttonAdv10.BorderColor = Color.FromArgb(70, 70, 70);
            buttonAdv10.BorderSize = 1;
            buttonAdv10.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            buttonAdv10.expandImage = false;
            buttonAdv10.extraText = "";
            buttonAdv10.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv10.extraTextColor = Color.Black;
            buttonAdv10.extraTextFont = null;
            buttonAdv10.extraTextOffset = new Point(0, 0);
            buttonAdv10.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv10.FocusEnabled = false;
            buttonAdv10.ForeColor = Color.Silver;
            buttonAdv10.Location = new Point(685, 437);
            buttonAdv10.Name = "buttonAdv10";
            buttonAdv10.PaintImageOnSelected = true;
            buttonAdv10.processEnterKey = true;
            buttonAdv10.resizeImage = new Point(0, 0);
            buttonAdv10.Selected = false;
            buttonAdv10.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv10.Size = new Size(32, 29);
            buttonAdv10.TabIndex = 27;
            buttonAdv10.Text = "+";
            buttonAdv10.UseVisualStyleBackColor = false;
            buttonAdv10.Click += OnExpandPathPressed;
            // 
            // labelAdv4
            // 
            labelAdv4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelAdv4.AutoSize = true;
            labelAdv4.BorderColor = Color.DarkGray;
            labelAdv4.BorderSize = 1;
            labelAdv4.CStyle = UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv4.ForeColor = Color.Silver;
            labelAdv4.Location = new Point(524, 416);
            labelAdv4.ModifyClampMax = 0F;
            labelAdv4.ModifyClampMin = 0F;
            labelAdv4.ModifyControlName = "";
            labelAdv4.ModifyScale = 1F;
            labelAdv4.Name = "labelAdv4";
            labelAdv4.Size = new Size(159, 20);
            labelAdv4.TabIndex = 28;
            labelAdv4.Text = "Path collapse / expand";
            // 
            // buttonAdv11
            // 
            buttonAdv11.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAdv11.BackColor = Color.FromArgb(20, 20, 20);
            buttonAdv11.BorderColor = Color.FromArgb(70, 70, 70);
            buttonAdv11.BorderSize = 1;
            buttonAdv11.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            buttonAdv11.expandImage = false;
            buttonAdv11.extraText = "";
            buttonAdv11.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv11.extraTextColor = Color.Black;
            buttonAdv11.extraTextFont = null;
            buttonAdv11.extraTextOffset = new Point(0, 0);
            buttonAdv11.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv11.FocusEnabled = false;
            buttonAdv11.ForeColor = Color.Silver;
            buttonAdv11.Location = new Point(651, 437);
            buttonAdv11.Name = "buttonAdv11";
            buttonAdv11.PaintImageOnSelected = true;
            buttonAdv11.processEnterKey = true;
            buttonAdv11.resizeImage = new Point(0, 0);
            buttonAdv11.Selected = false;
            buttonAdv11.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv11.Size = new Size(32, 29);
            buttonAdv11.TabIndex = 29;
            buttonAdv11.Text = "-";
            buttonAdv11.UseVisualStyleBackColor = false;
            buttonAdv11.Click += OnCollapsePathPressed;
            // 
            // labelAdv5
            // 
            labelAdv5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelAdv5.AutoSize = true;
            labelAdv5.BorderColor = Color.DarkGray;
            labelAdv5.BorderSize = 1;
            labelAdv5.CStyle = UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv5.ForeColor = Color.Silver;
            labelAdv5.Location = new Point(726, 485);
            labelAdv5.ModifyClampMax = 0F;
            labelAdv5.ModifyClampMin = 0F;
            labelAdv5.ModifyControlName = "";
            labelAdv5.ModifyScale = 1F;
            labelAdv5.Name = "labelAdv5";
            labelAdv5.Size = new Size(94, 20);
            labelAdv5.TabIndex = 31;
            labelAdv5.Text = "Stored Node";
            // 
            // storedInput
            // 
            storedInput.AllowBackspace = true;
            storedInput.AllowTextEdition = true;
            storedInput.AutoEdition = false;
            storedInput.AutoSelect = false;
            storedInput.BackColor = Color.FromArgb(80, 80, 80);
            storedInput.BorderStyle = BorderStyle.FixedSingle;
            storedInput.ExcludeCharacters = null;
            storedInput.ForeColor = Color.Silver;
            storedInput.IncludeOnlyCharacters = null;
            storedInput.LeftLeadingCharacter = '\0';
            storedInput.Location = new Point(726, 508);
            storedInput.Name = "storedInput";
            storedInput.Size = new Size(118, 27);
            storedInput.TabIndex = 30;
            // 
            // buttonAdv12
            // 
            buttonAdv12.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAdv12.BackColor = Color.FromArgb(35, 35, 35);
            buttonAdv12.BorderColor = Color.FromArgb(70, 70, 70);
            buttonAdv12.BorderSize = 1;
            buttonAdv12.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            buttonAdv12.expandImage = false;
            buttonAdv12.extraText = "";
            buttonAdv12.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv12.extraTextColor = Color.Black;
            buttonAdv12.extraTextFont = null;
            buttonAdv12.extraTextOffset = new Point(0, 0);
            buttonAdv12.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv12.FocusEnabled = false;
            buttonAdv12.ForeColor = Color.Silver;
            buttonAdv12.Location = new Point(850, 485);
            buttonAdv12.Name = "buttonAdv12";
            buttonAdv12.PaintImageOnSelected = true;
            buttonAdv12.processEnterKey = true;
            buttonAdv12.resizeImage = new Point(0, 0);
            buttonAdv12.Selected = false;
            buttonAdv12.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv12.Size = new Size(119, 29);
            buttonAdv12.TabIndex = 32;
            buttonAdv12.Text = "store";
            buttonAdv12.UseVisualStyleBackColor = false;
            buttonAdv12.Click += OnStoreNodePressed;
            // 
            // buttonAdv13
            // 
            buttonAdv13.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAdv13.BackColor = Color.FromArgb(35, 35, 35);
            buttonAdv13.BorderColor = Color.FromArgb(70, 70, 70);
            buttonAdv13.BorderSize = 1;
            buttonAdv13.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            buttonAdv13.expandImage = false;
            buttonAdv13.extraText = "";
            buttonAdv13.extraTextAlign = ContentAlignment.MiddleCenter;
            buttonAdv13.extraTextColor = Color.Black;
            buttonAdv13.extraTextFont = null;
            buttonAdv13.extraTextOffset = new Point(0, 0);
            buttonAdv13.FocusColor = Color.FromArgb(24, 81, 115);
            buttonAdv13.FocusEnabled = false;
            buttonAdv13.ForeColor = Color.Silver;
            buttonAdv13.Location = new Point(850, 520);
            buttonAdv13.Name = "buttonAdv13";
            buttonAdv13.PaintImageOnSelected = true;
            buttonAdv13.processEnterKey = true;
            buttonAdv13.resizeImage = new Point(0, 0);
            buttonAdv13.Selected = false;
            buttonAdv13.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv13.Size = new Size(119, 29);
            buttonAdv13.TabIndex = 33;
            buttonAdv13.Text = "restore";
            buttonAdv13.UseVisualStyleBackColor = false;
            buttonAdv13.Click += OnRestoreNodePressed;
            // 
            // TreeViewTester
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            ClientSize = new Size(995, 602);
            Controls.Add(buttonAdv13);
            Controls.Add(buttonAdv12);
            Controls.Add(labelAdv5);
            Controls.Add(storedInput);
            Controls.Add(buttonAdv11);
            Controls.Add(labelAdv4);
            Controls.Add(buttonAdv10);
            Controls.Add(pathInput);
            Controls.Add(buttonAdv9);
            Controls.Add(buttonAdv8);
            Controls.Add(buttonAdv7);
            Controls.Add(buttonAdv6);
            Controls.Add(expand_tree_classic);
            Controls.Add(delete_classic);
            Controls.Add(collapse_classic);
            Controls.Add(expand_classic);
            Controls.Add(insert_classic);
            Controls.Add(buttonAdv5);
            Controls.Add(buttonAdv4);
            Controls.Add(buttonAdv3);
            Controls.Add(buttonAdv2);
            Controls.Add(buttonAdv1);
            Controls.Add(icon2EnableCKBox);
            Controls.Add(icon1EnableCKBox);
            Controls.Add(fontSizeInput);
            Controls.Add(labelAdv3);
            Controls.Add(NodeIndentInput);
            Controls.Add(labelAdv2);
            Controls.Add(nodeHeightInput);
            Controls.Add(labelAdv1);
            Controls.Add(consoleOutp);
            Controls.Add(treeViewAdv);
            Controls.Add(treeView);
            Name = "TreeViewTester";
            Text = "JSon Viewer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView treeView;
        private UI.Controls.TreeViewAdv treeViewAdv;
        private VampirioCode.UI.XConsole consoleOutp;
        private VampirioCode.UI.Controls.LabelAdv labelAdv1;
        private VampirioCode.UI.Controls.IntTextBox nodeHeightInput;
        private VampirioCode.UI.Controls.IntTextBox NodeIndentInput;
        private VampirioCode.UI.Controls.LabelAdv labelAdv2;
        private VampirioCode.UI.Controls.IntTextBox fontSizeInput;
        private VampirioCode.UI.Controls.LabelAdv labelAdv3;
        private CheckBox icon1EnableCKBox;
        private CheckBox icon2EnableCKBox;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv1;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv2;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv3;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv4;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv5;
        private VampirioCode.UI.Controls.ButtonAdv delete_classic;
        private VampirioCode.UI.Controls.ButtonAdv collapse_classic;
        private VampirioCode.UI.Controls.ButtonAdv expand_classic;
        private VampirioCode.UI.Controls.ButtonAdv insert_classic;
        private VampirioCode.UI.Controls.ButtonAdv expand_tree_classic;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv6;
        private VampirioCode.UI.Controls.ButtonAdv buttonAdv7;
        private UI.Controls.ButtonAdv buttonAdv8;
        private UI.Controls.ButtonAdv buttonAdv9;
        private UI.Controls.TextBoxAdv pathInput;
        private UI.Controls.ButtonAdv buttonAdv10;
        private UI.Controls.LabelAdv labelAdv4;
        private UI.Controls.ButtonAdv buttonAdv11;
        private UI.Controls.LabelAdv labelAdv5;
        private UI.Controls.TextBoxAdv storedInput;
        private UI.Controls.ButtonAdv buttonAdv12;
        private UI.Controls.ButtonAdv buttonAdv13;
    }
}