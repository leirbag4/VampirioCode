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
            treeView.Size = new Size(510, 413);
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
            treeViewAdv.Size = new Size(459, 413);
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
            labelAdv1.Location = new Point(534, 439);
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
            nodeHeightInput.Location = new Point(534, 462);
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
            NodeIndentInput.Location = new Point(666, 462);
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
            labelAdv2.Location = new Point(666, 439);
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
            fontSizeInput.Location = new Point(534, 529);
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
            labelAdv3.Location = new Point(534, 506);
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
            icon1EnableCKBox.Location = new Point(666, 529);
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
            icon2EnableCKBox.Location = new Point(797, 529);
            icon2EnableCKBox.Name = "icon2EnableCKBox";
            icon2EnableCKBox.Size = new Size(112, 24);
            icon2EnableCKBox.TabIndex = 11;
            icon2EnableCKBox.Text = "icon2 Enable";
            icon2EnableCKBox.UseVisualStyleBackColor = true;
            icon2EnableCKBox.CheckedChanged += OnIcon2CheckedChanged;
            // 
            // JSonViewer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            ClientSize = new Size(995, 586);
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
    }
}