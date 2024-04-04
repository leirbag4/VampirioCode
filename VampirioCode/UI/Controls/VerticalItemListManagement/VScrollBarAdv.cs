using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VampirioCode.UI.Controls.VerticalItemListManagement
{


    public class VScrollBarAdv : VScrollBar
    {
        // IMPORTANT:
        //https://stackoverflow.com/questions/2882789/net-vertical-scrollbar-not-respecting-maximum-property
        // Value never reach Maximum. That's because of LargeChange. It's a weird situation but it works as it is.
        // You must add (LargeChange - 1) to Value and your latest value will be equal to Maximum. Yes! -1 includeded. Just ask microsoft why.
        //return (int)(((float)VerticalScrollBar.Value / (VerticalScrollBar.Maximum - (VerticalScrollBar.LargeChange - 1))) * VerticalScrollBar.Maximum);


        // This is the only way to overwrite Value
        // Just use base.Value inside this class.
        public new int Value
        {
            get { return (int)Math.Round(Maximum * _floatVal); }
            set
            {
                if (value > fullArea) value = fullArea; else if (value < 0) value = 0;
                _floatVal = value / (float)Maximum;
                int newVal = (int)((Maximum - LargeChange + 1) * _floatVal);
                if (newVal > Maximum) newVal = Maximum; // fixed issue when _floatVal has a lot of decimal errors because of the amount of items
                base.Value = newVal;

                LaunchEvent(ScrollEventType.EndScroll);
            }
        }

        public float FloatValue
        {
            get { return _floatVal; }
            set
            {
                if (value > 1f) value = 1f; else if (value < 0f) value = 0;
                _floatVal = value;
                int newVal = (int)((Maximum - LargeChange + 1) * _floatVal);
                if (newVal > Maximum) newVal = Maximum; // fixed issue when _floatVal has a lot of decimal errors because of the amount of items
                base.Value = newVal;

                LaunchEvent(ScrollEventType.EndScroll);
            }
        }

        public int Offset
        {
            get
            {
                if (!Visible)
                    return 0;
                else
                    return (int)(Math.Round(HiddenArea * _floatVal));
            }
            set
            {

                if (value > HiddenArea) value = HiddenArea; else if (value < 0f) value = 0;
                if (HiddenArea == 0)
                    FloatValue = 0;
                else
                    FloatValue = (value / (float)HiddenArea);
            }
        }

        public int HiddenArea
        {
            get { return (fullArea - visibleArea); }
        }

        // this fixes an issue with windows who cancel visible = true when scrollbar
        // isn't added to any form yet
        public new bool Visible
        {
            get { return _visible; }
            set { _visible = value; base.Visible = _visible; }
        }

        public new event ScrollEventHandler Scroll;

        private int fullArea = 0;
        private int visibleArea = 0;
        private int _value = 0;
        private float _floatVal = 0f;
        private bool _visible = true;

        public VScrollBarAdv()
        {
            DoubleBuffered = true;
        }

        public void CalcThumbSize(int visibleArea, int fullArea)
        {
            this.visibleArea = visibleArea;
            this.fullArea = fullArea;
            Maximum = fullArea;
            LargeChange = (int)(Math.Ceiling((float)visibleArea / fullArea) * visibleArea); // IMPORTANT: CHANGE to use Ceiling to fix a possible bug. (int)(((float)visibleArea / fullArea) * visibleArea);
            SmallChange = (int)Math.Ceiling(fullArea / 100f);//LargeChange / 10;
        }


        public void MoveUp()
        {
            MoveUp((int)Math.Ceiling(fullArea / 15f));
        }

        public void MoveDown()
        {
            MoveDown((int)Math.Ceiling(fullArea / 15f));
        }

        public void MoveUp(int steps)
        {
            int val = Value - steps;
            if (val < 0) val = 0;
            Value = val;

            //LaunchEvent(ScrollEventType.SmallIncrement);
        }

        public void MoveDown(int steps)
        {
            int val = Value + steps;
            if (val > Maximum) val = Maximum;
            Value = val;

            //LaunchEvent(ScrollEventType.SmallIncrement);
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            _floatVal = (float)se.NewValue / (Maximum - (LargeChange - 1));
            _value = (int)(((float)se.NewValue / (Maximum - (LargeChange - 1))) * Maximum);
            base.OnScroll(se);

            if (Scroll != null)
                Scroll(this, se);
        }

        private void LaunchEvent(ScrollEventType type)
        {
            if (Scroll != null)
                Scroll(this, new ScrollEventArgs(type, Value));
        }

    }
}
