using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampirioCode.UI.Controls.VerticalItemListManagement;

namespace VampirioCode.UI.Controls
{
    public class VerticalItemList : Panel
    {

        public delegate void ItemClickEvent(object sender, MouseEventArgs e);
        public delegate void ItemDoubleClickEvent(object sender);
        public delegate void ItemCreateRequestEvent(object sender, int index);
        public delegate void ItemCheckedChangedEvent(object sender, bool check);
        public delegate void ItemListChangedEvent(object sender);


        [Category("Extra Events")]
        [Description("Item Click")]
        [Browsable(true)]
        public event ItemClickEvent ItemClick;

        [Category("Extra Events")]
        [Description("Item Double Click")]
        [Browsable(true)]
        public event ItemDoubleClickEvent ItemDoubleClick;

        [Category("Extra Events")]
        [Description("Item Create Request")]
        [Browsable(true)]
        public event ItemCreateRequestEvent ItemCreateRequest;

        [Category("Extra Events")]
        [Description("Item Checked")]
        [Browsable(true)]
        public event ItemCheckedChangedEvent ItemCheckedChanged;

        [Category("Extra Events")]
        [Description("Item List Changed")]
        [Browsable(true)]
        public event ItemListChangedEvent ItemListChanged;

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Item Height")]
        [Browsable(true)]
        public int ItemHeight
        {
            set { _itemHeight = value; }
            get { return _itemHeight; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Item Height Type")]
        [Browsable(true)]
        public HeightType ItemHeightType
        {
            set { _itemHeightType = value; }
            get { return _itemHeightType; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Allow Pressed Events")]
        [Browsable(true)]
        public bool AllowPressedEvents
        {
            set { _allowPressedEvents = value; _SetEvents(_allowPressedEvents); }
            get { return _allowPressedEvents; }
        }



        public ObservableRangeCollection<Control> Items { get { return _items; } }

        private VScrollBarAdv VerticalScrollBar;
        private int _itemHeight = 35;
        //private readonly ObservableCollection<Control> _items;
        private readonly ObservableRangeCollection<Control> _items;
        private HeightType _itemHeightType = HeightType.FIXED_SIZE;
        private int totalItemsHeight = 0;
        private bool _allowPressedEvents = true;

        public enum HeightType
        {
            FIXED_SIZE,
            OWN_HEIGHT
        }

        public VerticalItemList()
        {
            DoubleBuffered = true;
            AutoScroll = false;
            VerticalScrollBar = new VScrollBarAdv();
            VerticalScrollBar.Width = SystemInformation.VerticalScrollBarWidth;
            VerticalScrollBar.Dock = DockStyle.Right;
            VerticalScrollBar.Scroll += OnVerticalScrollChanged;
            VerticalScrollBar.Visible = false;
            this.Controls.Add(VerticalScrollBar);
            VerticalScrollBar.Maximum = 50;

            BackColor = Color.FromArgb(54, 54, 54);

            _items = new ObservableRangeCollection<Control>();
            _items.CollectionChanged += OnCollectionChanged;

            //SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

        }


        public void MoveItem(int fromIndex, int toIndex)
        {
            Items.Move(fromIndex, toIndex);
        }

        public void MoveItemUp(int index)
        {
            MoveItemUp(Items[index]);
        }

        public void MoveItemDown(int index)
        {
            MoveItemDown(Items[index]);
        }

        public void MoveItemUp(Control control)
        {
            int index = Items.IndexOf(control);

            if (index > 0)
                Items.Move(index, index - 1);
        }

        public void MoveItemDown(Control control)
        {
            int index = Items.IndexOf(control);

            if (index < (Items.Count - 1))
                Items.Move(index, index + 1);
        }

        public void StartCreatingItem(object sender)
        {
            int index = Items.IndexOf((Control)sender);

            if (ItemCreateRequest != null)
                ItemCreateRequest(sender, index);
        }

        // Faster than add them all in a loop
        public void AddItems(List<Control> controls)
        {
            _items.AddRange(controls);
        }

        public void AddItemBelow(Control control, int index = -1)
        {
            if(_items.Count == 0)
                _items.Add(control);
            else if (index != -1)
                _items.Insert(index + 1, control);
            else
                _items.Add(control);
        }

        private void OnCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // this fix a bug when Items.Clear() is launched. A reset action is triggered and the code must clear all controls
            // otherwise they still exist inside this panel. Don't know why it is called twice (2 Resets). That makes some flickering
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Reset)
            {
                SuspendDrawing(this);
                totalItemsHeight = 0;
                foreach (Control con in Controls)
                    this.Controls.Remove(con);
                ResumeDrawing(this);
                //return;
            }

            if (e.OldItems != null)
            {
                //MessageBox.Show("old: " + e.OldItems.Count + " action: " + e.Action);

                for (int a = 0; a < e.OldItems.Count; a++)
                    this.Controls.Remove((Control)e.OldItems[a]);

                //
                // Recalculate Total Items Height for removed items
                //
                foreach (Control con in e.OldItems)
                {
                    totalItemsHeight -= con.Height;

                    if (_allowPressedEvents)
                    {
                        
                        con.MouseDown -=    OnItemClick;
                        con.MouseDown +=    OnItemClick;
                        con.DoubleClick -=  OnItemDoubleClick;
                        con.DoubleClick +=  OnItemDoubleClick;
                    }
                }
            }

            if (e.NewItems != null)
            {
                //MessageBox.Show("new: " + e.NewItems.Count + " action: " + e.Action);

                //
                // Recalculate Total Items Height for new added items
                //
                if (_itemHeightType == HeightType.FIXED_SIZE)
                {
                    totalItemsHeight += e.NewItems.Count * _itemHeight;

                    if (_allowPressedEvents)
                    {
                        foreach (Control con in e.NewItems)
                        {
                            con.MouseDown -= OnItemClick;
                            con.MouseDown += OnItemClick;
                            con.DoubleClick -= OnItemDoubleClick;
                            con.DoubleClick += OnItemDoubleClick;
                        }
                    }
                }
                else if (_itemHeightType == HeightType.OWN_HEIGHT)
                {
                    foreach (Control con in e.NewItems)
                    {
                        totalItemsHeight += con.Height;

                        if (_allowPressedEvents)
                        {
                            con.MouseDown -=    OnItemClick;
                            con.MouseDown +=    OnItemClick;
                            con.DoubleClick -=  OnItemDoubleClick;
                            con.DoubleClick +=  OnItemDoubleClick;
                        }
                    }
                }
            }

            SuspendDrawing(this);

           // this.Controls.AddRange(_items.ToArray());

            int prevOffset = VerticalScrollBar.Offset;



            RecalcScrollBars();
            RefreshPositions();


            if(VerticalScrollBar.Visible)
                VerticalScrollBar.Offset = prevOffset;

            if (ItemListChanged != null)
                ItemListChanged(this);

            ResumeDrawing(this);
        }

        private void RecalcTotalHeight()
        {
            if (_itemHeightType == HeightType.FIXED_SIZE)
            {
                totalItemsHeight = _items.Count * _itemHeight;
            }
            else if (_itemHeightType == HeightType.OWN_HEIGHT)
            {
                totalItemsHeight = 0;
                foreach (Control con in _items)
                    totalItemsHeight += con.Height;
            }
        }

        public void RefreshNow()
        {
            SuspendDrawing(this);

            int prevOffset = VerticalScrollBar.Offset;
            RecalcTotalHeight();
            RecalcScrollBars();
            RefreshPositions();

            if (VerticalScrollBar.Visible)
                VerticalScrollBar.Offset = prevOffset;

            ResumeDrawing(this);
        }

        protected virtual void OnItemClick(object sender, MouseEventArgs e)
        {
            if (ItemClick != null)
                ItemClick(sender, e);
        }

        protected virtual void OnItemDoubleClick(object sender, EventArgs e)
        {
            if (ItemDoubleClick != null)
                ItemDoubleClick(sender);
        }

        private void OnVerticalScrollChanged(object sender, ScrollEventArgs e)
        {
            SuspendDrawing(this);
            RefreshPositions();
            ResumeDrawing(this);
        }


        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (e.Delta < 0)
                VerticalScrollBar.MoveDown();
            else
                VerticalScrollBar.MoveUp();
        }

        protected override void OnResize(EventArgs eventargs)
        {

            base.OnResize(eventargs);
        }

        private void RecalcScrollBars()
        {
            if (totalItemsHeight > Height)
            {
                VerticalScrollBar.Visible =     true;
                VerticalScrollBar.CalcThumbSize(Height, totalItemsHeight);
            }
            else
            {
                VerticalScrollBar.Visible = false;
            }
        }




        private void RefreshPositions()
        {
            Control control;
            //int possOffset = (int)((totalItemsHeight - Height) * VerticalScrollBar.FloatValue);

            //if (!VerticalScrollBar.Visible)
            //    possOffset = 0;

            int posOffset = VerticalScrollBar.Offset;
            Point newPos;
            int y = 0;

            //
            // ITEM FIXED HEIGHT
            //
            if (_itemHeightType == HeightType.FIXED_SIZE)
            {
                for (int a = 0; a < _items.Count; a++)
                {
                    control = _items[a];

                    newPos = new Point(0, y - posOffset);

                    // if items are inside visible area
                    if (((newPos.Y + _itemHeight) >= 0) && (newPos.Y < Height))
                    {
                        control.Location = newPos;

                        if (VerticalScrollBar.Visible)
                            control.Width = this.Width - VerticalScrollBar.Width;
                        else
                            control.Width = this.Width;

                        control.Height = _itemHeight;

                        this.Controls.Add(control); // fixes an issue when dragging the control or the windows that lags the system
                        control.Visible = true;// -> do not delete this line. It is used by some components to check if they are added to control
                        control.Invalidate();
                    }
                    // these are out of the visible area
                    else
                    {
                        this.Controls.Remove(control); // fixes an issue when dragging the control or the windows that lags the system
                        control.Visible = false; // -> do not delete this line. It is used by some components to check if they are added to control
                    }

                    y += _itemHeight;
                }
            }
            //
            // ITEM OWN HEIGHT
            //
            else if (_itemHeightType == HeightType.OWN_HEIGHT)
            {
                for (int a = 0; a < _items.Count; a++)
                {
                    control = _items[a];

                    newPos = new Point(0, y - posOffset);

                    // if items are inside visible area
                    if (((newPos.Y + control.Height) >= 0) && (newPos.Y < Height))
                    {
                        control.Location = newPos;

                        if (VerticalScrollBar.Visible)
                            control.Width = this.Width - VerticalScrollBar.Width;
                        else
                            control.Width = this.Width;

                        //if(this.Controls.IndexOf(control) == -1)
                        this.Controls.Add(control); // fixes an issue when dragging the control or the windows that lags the system
                        control.Visible = true; // -> do not delete this line. It is used by some components to check if they are added to control
                        control.Invalidate();
                    }
                    // these are out of the visible area
                    else
                    {
                        //if(this.Controls.IndexOf(control) != -1)
                        this.Controls.Remove(control); // fixes an issue when dragging the control or the windows that lags the system
                        control.Visible = false; // -> do not delete this line. It is used by some components to check if they are added to control
                    }


                    y += control.Height;
                }
            }

            /*AltcoinCreator.XConsole.Println("------------");
            for (int a = 0; a < _items.Count; a++)
            {
                AltcoinCreator.XConsole.Println(a + ") " + _items[a].Visible);
            }*/
        }

        private void _SetEvents(bool useEvents)
        {
            if (useEvents)
            {
                foreach (Control con in _items)
                {
                    con.MouseDown -= OnItemClick;
                    con.MouseDown += OnItemClick;
                    con.DoubleClick -= OnItemDoubleClick;
                    con.DoubleClick += OnItemDoubleClick;
                }
            }
            else
            {
                foreach (Control con in _items)
                {
                    con.MouseDown -= OnItemClick;
                    con.DoubleClick -= OnItemDoubleClick;
                }
            }
        }

        public void TriggerCheckedChangedEvent(LItem item, bool check)
        {
            if (ItemCheckedChanged != null)
                ItemCheckedChanged(item, check);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            int prevOffset = VerticalScrollBar.Offset;

            RecalcScrollBars();
            RefreshPositions();

            if (VerticalScrollBar.Visible)
                VerticalScrollBar.Offset = prevOffset;

            base.OnSizeChanged(e);
        }


        //
        // Fix Draw lag issues
        //
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        private const int WM_SETREDRAW = 11;

        private static void SuspendDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
        }

        private static void ResumeDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
            parent.Refresh();
        }
    }
}
