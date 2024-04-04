using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampirioCode.UI.Controls.VerticalItemListManagement;

namespace VampirioCode.UI.Controls
{
    public class VerticalItemListAdv : VerticalItemList
    {

        public delegate void SelectedItemChangedEvent(object sender);
        //public delegate void ItemDoubleClickEvent(object sender);


        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Selection Enable")]
        [Browsable(true)]
        public bool SelectionEnable
        {
            set { _selectionEnable = value; }
            get { return _selectionEnable; }
        }

        [Category("Extra Events")]
        [Description("Selected Item Changed")]
        [Browsable(true)]
        public event SelectedItemChangedEvent SelectedItemChanged;

        [Category("Extra Events")]
        [Description("Selected Item Changed")]
        [Browsable(true)]
        public int SelectedIndex
        {
            set
            {
                if (value == -1) // do nothing - DO not delete!
                { } 
                else if (value > (Items.Count - 1))
                    return;

                for (int a = 0; a < Items.Count; a++)
                {
                    LItem item = (LItem)Items[a];

                    if (item.Selected)
                        item.Selected = false;
                }

                if (value > -1)
                {
                    ((LItem)Items[value]).Selected = true;
                    if(SelectedItemChanged != null)
                        SelectedItemChanged(Items[value]);
                }
            }
            get
            {
                for (int a = 0; a < Items.Count; a++)
                {
                    if (((LItem)Items[a]).Selected)
                        return a;
                }
                return -1;
            }
        }

        public LItem SelectedItem
        {
            get { if (SelectedIndex == -1) return null; else return (LItem)Items[SelectedIndex]; }
        }

        private bool _selectionEnable = true;

        protected override void OnItemClick(object sender, MouseEventArgs e)
        {
            LItem currItem = sender as LItem;
            LItem item;

            if (!currItem.Selected)
            {
                for (int a = 0; a < Items.Count; a++)
                {
                    item = (LItem)Items[a];

                    if (item.Selected)
                    {
                        item.Selected = false;
                        item.Invalidate();
                    }
                }

                currItem.Selected = true;
                currItem.Invalidate();

                if (SelectedItemChanged != null)
                    SelectedItemChanged(sender);
            }


            base.OnItemClick(sender, e);
        }

    }
}
