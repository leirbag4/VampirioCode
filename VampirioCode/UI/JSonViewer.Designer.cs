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
            treeView = new TreeView();
            treeViewAdv = new Controls.TreeViewAdv();
            consoleOutp = new XConsole();
            labelAdv1 = new Controls.LabelAdv();
            nodeHeightInput = new Controls.IntTextBox();
            NodeIndentInput = new Controls.IntTextBox();
            labelAdv2 = new Controls.LabelAdv();
            fontSizeInput = new Controls.IntTextBox();
            labelAdv3 = new Controls.LabelAdv();
            icon1EnableCKBox = new CheckBox();
            icon2EnableCKBox = new CheckBox();
            buttonAdv1 = new Controls.ButtonAdv();
            buttonAdv2 = new Controls.ButtonAdv();
            buttonAdv3 = new Controls.ButtonAdv();
            buttonAdv4 = new Controls.ButtonAdv();
            buttonAdv5 = new Controls.ButtonAdv();
            delete_classic = new Controls.ButtonAdv();
            collapse_classic = new Controls.ButtonAdv();
            expand_classic = new Controls.ButtonAdv();
            insert_classic = new Controls.ButtonAdv();
            expand_tree_classic = new Controls.ButtonAdv();
            buttonAdv6 = new Controls.ButtonAdv();
            buttonAdv7 = new Controls.ButtonAdv();
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
            treeView.Size = new Size(510, 356);
            treeView.TabIndex = 0;
            // 
            // treeViewAdv
            // 
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
            treeViewAdv.Size = new Size(459, 356);
            treeViewAdv.TabIndex = 1;
            treeViewAdv.Text = "treeViewAdv1";
            treeViewAdv.TextSpace = 5;
            // 
            // consoleOutp
            // 
            consoleOutp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            consoleOutp.BackColor = Color.FromArgb(40, 40, 40);
            consoleOutp.Location = new Point(6, 431);
            consoleOutp.Name = "consoleOutp";
            consoleOutp.Size = new Size(510, 153);
            consoleOutp.TabIndex = 2;
            // 
            // labelAdv1
            // 
            labelAdv1.AutoSize = true;
            labelAdv1.BorderColor = Color.DarkGray;
            labelAdv1.BorderSize = 1;
            labelAdv1.CStyle = UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv1.ForeColor = Color.Silver;
            labelAdv1.Location = new Point(534, 469);
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
            nodeHeightInput.BackColor = Color.FromArgb(80, 80, 80);
            nodeHeightInput.BorderStyle = BorderStyle.FixedSingle;
            nodeHeightInput.ForeColor = Color.Silver;
            nodeHeightInput.Location = new Point(534, 492);
            nodeHeightInput.Name = "nodeHeightInput";
            nodeHeightInput.NumberMask = "";
            nodeHeightInput.Size = new Size(95, 27);
            nodeHeightInput.TabIndex = 5;
            nodeHeightInput.EnterPressed += OnNodeHeightEnterPressed;
            // 
            // NodeIndentInput
            // 
            NodeIndentInput.AllowEmptyInput = false;
            NodeIndentInput.BackColor = Color.FromArgb(80, 80, 80);
            NodeIndentInput.BorderStyle = BorderStyle.FixedSingle;
            NodeIndentInput.ForeColor = Color.Silver;
            NodeIndentInput.Location = new Point(666, 492);
            NodeIndentInput.Name = "NodeIndentInput";
            NodeIndentInput.NumberMask = "";
            NodeIndentInput.Size = new Size(95, 27);
            NodeIndentInput.TabIndex = 7;
            NodeIndentInput.EnterPressed += OnNodeIndentEnterPressed;
            // 
            // labelAdv2
            // 
            labelAdv2.AutoSize = true;
            labelAdv2.BorderColor = Color.DarkGray;
            labelAdv2.BorderSize = 1;
            labelAdv2.CStyle = UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv2.ForeColor = Color.Silver;
            labelAdv2.Location = new Point(666, 469);
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
            fontSizeInput.BackColor = Color.FromArgb(80, 80, 80);
            fontSizeInput.BorderStyle = BorderStyle.FixedSingle;
            fontSizeInput.ForeColor = Color.Silver;
            fontSizeInput.Location = new Point(534, 545);
            fontSizeInput.Name = "fontSizeInput";
            fontSizeInput.NumberMask = "";
            fontSizeInput.Size = new Size(95, 27);
            fontSizeInput.TabIndex = 9;
            fontSizeInput.EnterPressed += OnFontSizeEnterPressed;
            // 
            // labelAdv3
            // 
            labelAdv3.AutoSize = true;
            labelAdv3.BorderColor = Color.DarkGray;
            labelAdv3.BorderSize = 1;
            labelAdv3.CStyle = UI.Controls.LabelAdv.CustomStyle.NORMAL;
            labelAdv3.ForeColor = Color.Silver;
            labelAdv3.Location = new Point(534, 522);
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
            icon1EnableCKBox.AutoSize = true;
            icon1EnableCKBox.FlatStyle = FlatStyle.Flat;
            icon1EnableCKBox.ForeColor = Color.Silver;
            icon1EnableCKBox.Location = new Point(666, 545);
            icon1EnableCKBox.Name = "icon1EnableCKBox";
            icon1EnableCKBox.Size = new Size(112, 24);
            icon1EnableCKBox.TabIndex = 10;
            icon1EnableCKBox.Text = "icon1 Enable";
            icon1EnableCKBox.UseVisualStyleBackColor = true;
            icon1EnableCKBox.CheckedChanged += OnIcon1CheckedChanged;
            // 
            // icon2EnableCKBox
            // 
            icon2EnableCKBox.AutoSize = true;
            icon2EnableCKBox.FlatStyle = FlatStyle.Flat;
            icon2EnableCKBox.ForeColor = Color.Silver;
            icon2EnableCKBox.Location = new Point(797, 545);
            icon2EnableCKBox.Name = "icon2EnableCKBox";
            icon2EnableCKBox.Size = new Size(112, 24);
            icon2EnableCKBox.TabIndex = 11;
            icon2EnableCKBox.Text = "icon2 Enable";
            icon2EnableCKBox.UseVisualStyleBackColor = true;
            icon2EnableCKBox.CheckedChanged += OnIcon2CheckedChanged;
            // 
            // buttonAdv1
            // 
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
            buttonAdv1.Location = new Point(522, 374);
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
            buttonAdv2.Location = new Point(915, 545);
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
            buttonAdv3.Location = new Point(723, 374);
            buttonAdv3.Name = "buttonAdv3";
            buttonAdv3.PaintImageOnSelected = true;
            buttonAdv3.processEnterKey = true;
            buttonAdv3.resizeImage = new Point(0, 0);
            buttonAdv3.Selected = false;
            buttonAdv3.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv3.Size = new Size(85, 29);
            buttonAdv3.TabIndex = 14;
            buttonAdv3.Text = "expand";
            buttonAdv3.UseVisualStyleBackColor = false;
            buttonAdv3.Click += OnExpandPressed;
            // 
            // buttonAdv4
            // 
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
            buttonAdv4.Location = new Point(824, 374);
            buttonAdv4.Name = "buttonAdv4";
            buttonAdv4.PaintImageOnSelected = true;
            buttonAdv4.processEnterKey = true;
            buttonAdv4.resizeImage = new Point(0, 0);
            buttonAdv4.Selected = false;
            buttonAdv4.SelectedColor = Color.FromArgb(0, 122, 204);
            buttonAdv4.Size = new Size(85, 29);
            buttonAdv4.TabIndex = 15;
            buttonAdv4.Text = "collapse";
            buttonAdv4.UseVisualStyleBackColor = false;
            buttonAdv4.Click += OnCollapsePressed;
            // 
            // buttonAdv5
            // 
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
            buttonAdv5.Location = new Point(623, 374);
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
            delete_classic.Location = new Point(106, 374);
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
            collapse_classic.Location = new Point(301, 374);
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
            expand_classic.Location = new Point(207, 374);
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
            insert_classic.Location = new Point(5, 374);
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
            expand_tree_classic.Location = new Point(397, 374);
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
            buttonAdv6.Location = new Point(723, 409);
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
            buttonAdv7.Location = new Point(848, 409);
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
            // JSonViewer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            ClientSize = new Size(995, 586);
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
            Name = "JSonViewer";
            Text = "JSon Viewer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView treeView;
        private Controls.TreeViewAdv treeViewAdv;
        private XConsole consoleOutp;
        private Controls.LabelAdv labelAdv1;
        private Controls.IntTextBox nodeHeightInput;
        private Controls.IntTextBox NodeIndentInput;
        private Controls.LabelAdv labelAdv2;
        private Controls.IntTextBox fontSizeInput;
        private Controls.LabelAdv labelAdv3;
        private CheckBox icon1EnableCKBox;
        private CheckBox icon2EnableCKBox;
        private Controls.ButtonAdv buttonAdv1;
        private Controls.ButtonAdv buttonAdv2;
        private Controls.ButtonAdv buttonAdv3;
        private Controls.ButtonAdv buttonAdv4;
        private Controls.ButtonAdv buttonAdv5;
        private Controls.ButtonAdv delete_classic;
        private Controls.ButtonAdv collapse_classic;
        private Controls.ButtonAdv expand_classic;
        private Controls.ButtonAdv insert_classic;
        private Controls.ButtonAdv expand_tree_classic;
        private Controls.ButtonAdv buttonAdv6;
        private Controls.ButtonAdv buttonAdv7;
    }
}