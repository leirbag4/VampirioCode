namespace VampirioCode.BuilderSetting.UI
{
    partial class ItemListSources
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemListSources));
            itemList = new ItemList();
            modesCBox = new VampirioCode.UI.Controls.ComboBoxAdv();
            SuspendLayout();
            // 
            // itemList
            // 
            itemList.BackColor = Color.FromArgb(40, 40, 40);
            itemList.Dock = DockStyle.Fill;
            itemList.Enable = true;
            itemList.Icon = (Image)resources.GetObject("itemList.Icon");
            itemList.Location = new Point(0, 0);
            itemList.Margin = new Padding(3, 2, 3, 2);
            itemList.Name = "itemList";
            itemList.Size = new Size(262, 154);
            itemList.TabIndex = 0;
            itemList.Title = "Main Title";
            // 
            // modesCBox
            // 
            modesCBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            modesCBox.BackColor = Color.FromArgb(52, 52, 52);
            modesCBox.BorderColor = Color.FromArgb(100, 100, 100);
            modesCBox.BorderSize = 2;
            modesCBox.ButtonColor = SystemColors.Control;
            modesCBox.DropDownStyle = ComboBoxStyle.DropDownList;
            modesCBox.ForeColor = Color.Silver;
            modesCBox.FormattingEnabled = true;
            modesCBox.Location = new Point(3, 129);
            modesCBox.Margin = new Padding(3, 2, 3, 2);
            modesCBox.Name = "modesCBox";
            modesCBox.Size = new Size(106, 23);
            modesCBox.TabIndex = 41;
            // 
            // ItemListSources
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            Controls.Add(modesCBox);
            Controls.Add(itemList);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ItemListSources";
            Size = new Size(261, 154);
            ResumeLayout(false);
        }

        #endregion

        private ItemList itemList;
        private VampirioCode.UI.Controls.ComboBoxAdv modesCBox;
    }
}
