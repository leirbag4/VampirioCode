namespace VampirioCode.Tests
{
    partial class ItemListTester
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemListTester));
            itemList = new UI.Controls.VerticalItemListAdv();
            console = new UI.XConsole();
            slider = new TrackBar();
            divisionOutp = new UI.Controls.DecimalTextBox();
            itemList2 = new BuilderSetting.ItemList();
            findPackageInput1 = new BuilderSetting.UI.FindPackageInput();
            ((System.ComponentModel.ISupportInitialize)slider).BeginInit();
            SuspendLayout();
            // 
            // itemList
            // 
            itemList.AllowPressedEvents = true;
            itemList.BackColor = Color.FromArgb(54, 54, 54);
            itemList.ItemHeight = 35;
            itemList.ItemHeightType = UI.Controls.VerticalItemList.HeightType.FIXED_SIZE;
            itemList.Location = new Point(79, 34);
            itemList.Name = "itemList";
            itemList.SelectedIndex = -1;
            itemList.SelectionEnable = true;
            itemList.Size = new Size(192, 248);
            itemList.TabIndex = 0;
            // 
            // console
            // 
            console.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            console.BackColor = Color.FromArgb(40, 40, 40);
            console.Location = new Point(12, 306);
            console.Name = "console";
            console.Size = new Size(707, 193);
            console.TabIndex = 9;
            // 
            // slider
            // 
            slider.AutoSize = false;
            slider.Location = new Point(306, 12);
            slider.Maximum = 100;
            slider.Name = "slider";
            slider.Size = new Size(183, 29);
            slider.TabIndex = 21;
            slider.TickStyle = TickStyle.None;
            slider.Value = 50;
            slider.Scroll += OnSliderChanged;
            // 
            // divisionOutp
            // 
            divisionOutp.AllowEmptyInput = false;
            divisionOutp.Location = new Point(503, 14);
            divisionOutp.MaxDecimalPlaces = 2;
            divisionOutp.Name = "divisionOutp";
            divisionOutp.Size = new Size(125, 27);
            divisionOutp.TabIndex = 22;
            divisionOutp.UseNegativeValues = false;
            // 
            // itemList2
            // 
            itemList2.BackColor = Color.FromArgb(40, 40, 40);
            itemList2.Icon = (Image)resources.GetObject("itemList2.Icon");
            itemList2.Location = new Point(480, 66);
            itemList2.Name = "itemList2";
            itemList2.Size = new Size(211, 216);
            itemList2.TabIndex = 23;
            itemList2.Title = "Main Title";
            // 
            // findPackageInput1
            // 
            findPackageInput1.BackColor = Color.FromArgb(40, 40, 40);
            findPackageInput1.Location = new Point(297, 200);
            findPackageInput1.Name = "findPackageInput1";
            findPackageInput1.SelectedPackage = "";
            findPackageInput1.Size = new Size(168, 44);
            findPackageInput1.TabIndex = 24;
            // 
            // ItemListTester
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(731, 511);
            Controls.Add(findPackageInput1);
            Controls.Add(itemList2);
            Controls.Add(divisionOutp);
            Controls.Add(slider);
            Controls.Add(console);
            Controls.Add(itemList);
            Name = "ItemListTester";
            Text = "ItemListTester";
            ((System.ComponentModel.ISupportInitialize)slider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UI.Controls.VerticalItemListAdv itemList;
        private UI.XConsole console;
        private TrackBar slider;
        private UI.Controls.DecimalTextBox divisionOutp;
        private BuilderSetting.ItemList itemList2;
        private BuilderSetting.UI.FindPackageInput findPackageInput1;
    }
}