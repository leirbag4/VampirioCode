namespace VampirioCode.UI
{
    partial class BuilderDebugger
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
            list = new Controls.VerticalItemListAdv();
            refreshButton = new Controls.ButtonAdv();
            SuspendLayout();
            // 
            // list
            // 
            list.AllowPressedEvents = true;
            list.BackColor = Color.FromArgb(54, 54, 54);
            list.ItemHeight = 35;
            list.ItemHeightType = UI.Controls.VerticalItemList.HeightType.FIXED_SIZE;
            list.Location = new Point(73, 34);
            list.Name = "list";
            list.SelectedIndex = -1;
            list.SelectionEnable = true;
            list.Size = new Size(499, 317);
            list.TabIndex = 0;
            // 
            // refreshButton
            // 
            refreshButton.BackColor = Color.FromArgb(20, 20, 20);
            refreshButton.BorderColor = Color.FromArgb(60, 60, 60);
            refreshButton.BorderSize = 1;
            refreshButton.CStyle = UI.Controls.ButtonAdv.CustomStyle.SOLID;
            refreshButton.expandImage = false;
            refreshButton.extraText = "";
            refreshButton.extraTextAlign = ContentAlignment.MiddleCenter;
            refreshButton.extraTextColor = Color.Black;
            refreshButton.extraTextFont = null;
            refreshButton.extraTextOffset = new Point(0, 0);
            refreshButton.FocusColor = Color.FromArgb(24, 81, 115);
            refreshButton.FocusEnabled = false;
            refreshButton.ForeColor = Color.Silver;
            refreshButton.Location = new Point(652, 322);
            refreshButton.Name = "refreshButton";
            refreshButton.PaintImageOnSelected = true;
            refreshButton.processEnterKey = true;
            refreshButton.resizeImage = new Point(0, 0);
            refreshButton.Selected = false;
            refreshButton.SelectedColor = Color.FromArgb(0, 122, 204);
            refreshButton.Size = new Size(94, 29);
            refreshButton.TabIndex = 1;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = false;
            refreshButton.Click += OnRefreshPressed;
            // 
            // BuilderDebugger
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(refreshButton);
            Controls.Add(list);
            Name = "BuilderDebugger";
            Text = "BuilderDebugger";
            ResumeLayout(false);
        }

        #endregion

        private Controls.VerticalItemListAdv list;
        private Controls.ButtonAdv refreshButton;
    }
}