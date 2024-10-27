using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampirioCode.UI.Controls.VerticalItemListManagement;

namespace VampirioCode.BuilderSetting
{
    public partial class ItemList : UserControl
    {
        struct ValuePairInfo
        {
            public bool leftEditable;
            public bool rightEditable;

            public ValuePairInfo(bool leftEditable, bool rightEditable)
            { 
                this.leftEditable = leftEditable;
                this.rightEditable = rightEditable;
            }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Icon")]
        [Browsable(true)]
        public Image Icon { get { return iconImg.Image; } set { iconImg.Image = value; } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Title")]
        [Browsable(true)]
        public string Title { get { return titleLabel.Text; } set { titleLabel.Text = value; }  }

        public bool Enable { get { return addButton.Enabled; } set { addButton.Enabled = removeButton.Enabled = list.Enabled = upButton.Enabled = downButton.Enabled = value; if (value) titleLabel.ForeColor = Color.Silver; else titleLabel.ForeColor = Color.FromArgb(80, 80, 80); } }

        public ObservableRangeCollection<Control> Items { get { return list.Items; } }

        // Events
        public event ValueChangedEvent ValueChanged;
        public event ItemModifiedEvent ItemModified;

        public SItemType Type { get { return _type; } }
        
        private BrowseMode _mode;
        private BrowseInfo _browseInfo;
        private SItemType _type = SItemType.SItem;
        private float _division = 0.5f;
        private ValuePairInfo _valuePairInfo;
        private ValuePairBrowseInfo _valuePairBrowseInfo = null;

        public ItemList()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            if (list.Items.Count > 0)
            {
                Items.RemoveRange(0, list.Items.Count - 1);
                Items.Remove(list.Items[list.Items.Count - 1]);
            }
        }

        public void SetupDirMode()
        {
            _type =         SItemType.Browsable;
            _mode =         BrowseMode.Directory;
            _browseInfo =   new DirBrowseInfo();
        }

        public void SetupFileMode(FileBrowseInfo browseInfo)
        {
            _type =         SItemType.Browsable;
            _mode =         BrowseMode.File;
            _browseInfo =   browseInfo;
        }

        public void SetupValuePair(float division = 0.5f, bool leftEditable = true, bool rightEditable = true)
        {
            _type =             SItemType.ValuePairEditable;
            _division =         division;
            _valuePairInfo =    new ValuePairInfo(leftEditable, rightEditable);
        }

        public void SetupValuePairBrowsable(ValuePairBrowseInfo valuePairBrowseInfo)
        {
            SetupValuePairBrowsable(0.5f, true, true, valuePairBrowseInfo);
        }
        public void SetupValuePairBrowsable(float division = 0.5f, bool leftEditable = true, bool rightEditable = true, ValuePairBrowseInfo valuePairBrowseInfo = null)
        {
            _type =                 SItemType.ValuePairBrowsable;
            _division =             division;
            _valuePairInfo =        new ValuePairInfo(leftEditable, rightEditable);
            _valuePairBrowseInfo =  valuePairBrowseInfo;
        }

        public void Add(SItemBrowsable item)
        {
            item.BrowseInfo = _browseInfo;

            // Events
            item.ValueChanged -= OnValueChanged;
            item.ValueChanged += OnValueChanged;

            list.Items.Add(item);
        }

        public void Add(SItemValuePairEditable item)
        {
            // Events
            item.LeftValueChanged += OnValueChanged;
            item.RightValueChanged += OnValueChanged;

            list.Items.Add(item);
        }

        public void Add(SItemValuePairBrowsable item)
        {
            // Events
            item.LeftValueChanged += OnValueChanged;
            item.RightValueChanged += OnValueChanged;

            list.Items.Add(item);
        }

        private void OnValueChanged(VampirioCode.UI.Controls.VerticalItemListManagement.Components.SItemText itext, string text)
        {
            if (ValueChanged != null)
                ValueChanged(itext, text);

            TriggerItemModifiedEvent();
        }

        private void OnAddPressed(object sender, EventArgs e)
        {
            if (Type == SItemType.Browsable)
            {
                SItemBrowsable item = new SItemBrowsable();
                item.BrowseInfo = _browseInfo;
                item.Text = "-";

                // Events
                item.ValueChanged += OnValueChanged;

                list.Items.Add(item);
            }
            else if (Type == SItemType.ValuePairEditable)
            {
                SItemValuePairEditable item = new SItemValuePairEditable();
                item.LeftValue = "-";
                item.RightValue = "-";
                item.LeftEditable = _valuePairInfo.leftEditable;
                item.RightEditable = _valuePairInfo.rightEditable;
                
                // Events
                item.LeftValueChanged += OnValueChanged;
                item.RightValueChanged += OnValueChanged;

                list.Items.Add(item);
            }
            else if (Type == SItemType.ValuePairEditable)
            {
                SItemValuePairBrowsable item = new SItemValuePairBrowsable();
                item.LeftValue = "-";
                item.RightValue = "-";
                item.LeftEditable = _valuePairInfo.leftEditable;
                item.RightEditable = _valuePairInfo.rightEditable;
                
                // Events
                item.LeftValueChanged += OnValueChanged;
                item.RightValueChanged += OnValueChanged;

                list.Items.Add(item);
            }
            else if (Type == SItemType.ValuePairBrowsable)
            {
                SItemValuePairBrowsable item = new SItemValuePairBrowsable();
                item.LeftValue =        "-";
                item.RightValue =       "-";
                item.LeftEditable =     _valuePairInfo.leftEditable;
                item.RightEditable =    _valuePairInfo.rightEditable;

                if (_valuePairBrowseInfo != null)
                {
                    item.BrowseInfo =       _valuePairBrowseInfo.BrowseInfo;
                    item.LeftBrowseInfo =   _valuePairBrowseInfo.LeftBrowseInfo;
                    item.RightBrowseInfo =  _valuePairBrowseInfo.RightBrowseInfo;
                }

                // Events
                item.LeftValueChanged += OnValueChanged;
                item.RightValueChanged += OnValueChanged;

                list.Items.Add(item);
            }

            TriggerItemModifiedEvent();
        }

        private void OnRemovePressed(object sender, EventArgs e)
        {
            if (list.SelectedIndex != -1)
            {
                list.Items.RemoveAt(list.SelectedIndex);
                TriggerItemModifiedEvent();
            }
        }

        private void OnUpPressed(object sender, EventArgs e)
        {
            if (list.SelectedIndex != -1)
            {
                list.MoveItemUp(list.SelectedIndex);
                TriggerItemModifiedEvent();
            }
        }

        private void OnDownPressed(object sender, EventArgs e)
        {
            if (list.SelectedIndex != -1)
            {
                list.MoveItemDown(list.SelectedIndex);
                TriggerItemModifiedEvent();
            }
        }

        private void TriggerItemModifiedEvent()
        {
            if (ItemModified != null)
                ItemModified();
        }
    }
}
