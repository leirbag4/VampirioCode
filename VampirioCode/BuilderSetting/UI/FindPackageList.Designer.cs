namespace VampirioCode.BuilderSetting.UI
{
    partial class FindPackageList
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
            itemList = new VampirioCode.UI.Controls.VerticalItemListAdv();
            SuspendLayout();
            // 
            // itemList
            // 
            itemList.AllowPressedEvents = true;
            itemList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            itemList.BackColor = Color.FromArgb(54, 54, 54);
            itemList.ItemHeight = 35;
            itemList.ItemHeightType = VampirioCode.UI.Controls.VerticalItemList.HeightType.FIXED_SIZE;
            itemList.Location = new Point(3, 2);
            itemList.Name = "itemList";
            itemList.SelectedIndex = -1;
            itemList.SelectionEnable = true;
            itemList.Size = new Size(224, 257);
            itemList.TabIndex = 0;
            itemList.ItemDoubleClick += OnDoubleClickPressed;
            // 
            // FindPackageList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(229, 261);
            Controls.Add(itemList);
            Name = "FindPackageList";
            Text = "Find Package";
            ResumeLayout(false);
        }

        #endregion

        private VampirioCode.UI.Controls.VerticalItemListAdv itemList;
    }
}