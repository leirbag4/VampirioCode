#define USE_AUTO_SHIFT_TIMERS

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.UI.Controls.TabManagement;

namespace VampirioCode.UI.Controls
{

    public class TabBar : Control
    {
        public event SelectedTabChangedEvent SelectedTabChanged;
        public event UnselectedTabChangedEvent UnselectedTabChanged;
        public event TabAddedEvent TabAdded;
        public event TabRemovedEvent TabRemoved;
        public event StartDragTabEvent StartDragTab;
        public event StopDragTabEvent StopDragTab;
        public event RightClickContextEvent RightClickContext;
        public event TabDetachedEvent TabDetached;
        public event TabItemTextChangedEvent TabItemTextChanged;
        public event CloseTabInvokedEvent CloseTabInvoked;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabItemCollection Items { get { return items; } set { items = value; } } [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]

        public TabPaintMode PaintMode { get { return controller.PaintMode; } set { controller.PaintMode = value; } } [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabSize SelectedTabSize { get { return controller.SelectedTabSize; } set { controller.SelectedTabSize = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabSize NormalTabSize { get { return controller.NormalTabSize; } set { controller.NormalTabSize = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabSize DraggedTabSize { get { return controller.DraggedTabSize; } set { controller.DraggedTabSize = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int TabBorderSize { get { return controller.TabBorderSize; } set { controller.TabBorderSize = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabStyle SelectedStyle { get { return controller.SelectedStyle; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabStyle NormalStyle { get { return controller.NormalStyle; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabStyle OverStyle { get { return controller.OverStyle; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabStyle SubButtonsSelectedStyle { get{ return controller.SubButtonsSelectedStyle; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabStyle SubButtonsSelectedOverStyle { get{ return controller.SubButtonsSelectedOverStyle; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabStyle SubButtonsNormalStyle { get{ return controller.SubButtonsNormalStyle; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabStyle SubButtonsOverStyle { get{ return controller.SubButtonsOverStyle; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabStyle SubButtonsParentOverStyle { get { return controller.SubButtonsParentOverStyle; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int SubButtonsBorderSize { get { return controller.SubButtonsBorderSize; } set { controller.SubButtonsBorderSize = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool CloseButtonVisible { get { return controller.CloseButtonVisible; } set { controller.CloseButtonVisible = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public CloseBtnBehaviour CloseButtonBehaviour { get { return controller.CloseButtonBehaviour; } set { controller.CloseButtonBehaviour = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Color BackColor { get { return controller.BackColor; } set { controller.BackColor = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int LeftPadding { get { return controller.LeftPadding; } set { controller.LeftPadding = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int RightPadding { get { return controller.RightPadding; } set { controller.RightPadding = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabTextAlign TextAlign { get { return controller.TextAlign; } set { controller.TextAlign = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabShapeMode ShapeMode { get { return controller.ShapeMode; } set { controller.ShapeMode = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabManagement.TabSizeMode SizeMode { get { return controller.SizeMode; } set { controller.SizeMode = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int MinTabWidth { get { return controller.MinTabWidth; } set { controller.MinTabWidth = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int MaxTabWidth { get { return controller.MaxTabWidth; } set { controller.MaxTabWidth = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int TotalTabs { get { return controller.TotalTabs; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool IsDragging { get { return controller.IsDragging; } set { controller.IsDragging = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool IsAnySelected { get { return controller.IsAnySelected; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool IsOutsideBounds { get { return controller.IsOutsideBounds; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool TabsFitOnScreen { get { return controller.TabsFitOnScreen; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int TabVisibleLimit { get { return controller.TabVisibleLimit; } set { controller.TabVisibleLimit = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int SelectedIndex { get { return controller.SelectedIndex; } set { controller.SelectedIndex = value; Invalidate(); } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabItem SelectedTab { get { return controller.SelectedTab.Item; } set { controller.SelectedTab = value.tab; Invalidate(); } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool AllowDragging { get { return controller.AllowDragging; } set { controller.AllowDragging = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool AllowDetach { get { return controller.AllowDetach; } set { controller.AllowDetach = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int MinDetachThreshold { get { return controller.MinDetachThreshold; } set { controller.MinDetachThreshold = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]

        private TabItemCollection items = new TabItemCollection();
        private TabController controller;
        private bool _itemEventsEnabled = true;

        public TabBar()
        {
            controller = new TabController();

            // size
            Height = controller.Height;

            // controller events
            controller.SelectedTabChanged +=    OnSelectedTabChanged;
            controller.UnselectedTabChanged +=  OnUnselectedTabChanged;
            controller.TabAdded +=              OnTabAdded;
            controller.TabRemoved +=            OnTabRemoved;
            controller.StartDragTab +=          OnStartDragTab;
            controller.StopDragTab +=           OnStopDragTab;
            controller.TabIndexChanged +=       OnTabIndexChanged;
            controller.TabDetached +=           OnTabDetached;
            controller.TabItemTextChanged +=    OnTabItemTextChanged;
            controller.CloseTabInvoked +=       OnCloseTabInvoked;
#if USE_AUTO_SHIFT_TIMERS
            controller.TimerRepaintNeeded +=    OnTimerRepaintNeeded;
#endif

            // items events
            items.ItemAdded +=      OnItemAdded;
            items.ItemRemoved +=    OnItemRemoved;
            items.ItemModified +=   OnItemModified;
            items.ItemsCleared +=   OnItemsCleared;

            BackColor = Color.FromArgb(60, 60, 60);

            DoubleBuffered = true;
        }

        public TabController GetController()
        {
            return controller;
        }

        public T[] GetItems<T>()
        {
            return Items.OfType<T>().ToArray();
        }

        public void AddItem<T>(T item) where T : TabItem
        {
            Items.Add(item);
        }

        public void SetFont(string fontName, int fontSize, FontStyle fontStyle)
        {
            controller.SetFont(fontName, fontSize, fontStyle);
        }

        public void SelectTab(TabItem item)
        {
            controller.SelectTab(item.tab);
        }

        public void SelectTab(int index)
        {
            controller.SelectTab(index);
        }

        public void SelectTab(TabItem item, bool bringToScreen)
        {
            controller.SelectTab(item.tab, bringToScreen);
        }

        public void SelectTab(int index, bool bringToScreen)
        {
            controller.SelectTab(index, bringToScreen);
        }

        public void BringTabIntoScreen(TabItem item)
        {
            controller.BringTabIntoScreen(item.tab);
        }

        public void Add(TabItem item)
        {
            Items.Add(item);
        }

        public void Insert(int index, TabItem item) 
        {
            Items.Insert(index, item);
        }

        public void RemoveAt(int index)
        { 
            Items.RemoveAt(index);
        }

        public void Remove(TabItem tab)
        {
            Items.Remove(tab);
        }

        public void RemoveAllTabs()
        {
            Items.Clear();
        }

        public TabItem GetTabAt(int index)
        { 
            return controller.GetTabAt(index).Item;
        }

        public void BringTabToScreen(TabItem tab)
        {
            controller.BringTabIntoScreen(tab.tab);
            Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            controller.SizeChange(this.Width, this.Height);
            base.OnSizeChanged(e);
            Invalidate();
        }


        // Skin
        public void SetSkin(TabSkin skin)
        {
            _SetSkin(skin, true);
        }

        private void _SetSkin(TabSkin skin, bool refreshLayout)
        {
            // --------------------------
            //          DarkRect
            // --------------------------
            if (skin == TabSkin.DarkRect)
            {

                // shape and text mode
                ShapeMode = TabShapeMode.Box;
                SizeMode =  TabManagement.TabSizeMode.WrapToText;
                TextAlign = TabTextAlign.Center;

                // close button
                CloseButtonVisible = false;
                PaintMode = TabPaintMode.UserPaintOver;                 // Used by closeButton. Irrelevant if [CloseButtonVisible = false]
                CloseButtonBehaviour = CloseBtnBehaviour.ActiveAlways;  // Used by closeButton. Irrelevant if [CloseButtonVisible = false]

                // min and max
                MinTabWidth = 60;
                MaxTabWidth = 160;

                // padding
                LeftPadding =   5;
                RightPadding =  5;

                // position and anim
                SelectedTabSize =   new TabSize(0, 0);
                NormalTabSize =     new TabSize(2, 0);
                DraggedTabSize =    new TabSize(1, 0);

                // bar color
                BackColor = CColor(60, 60, 60);

                // tab color and border
                TabBorderSize = 2;

                SelectedStyle.BackColor =       CColor(49);
                SelectedStyle.BorderColor =     CColor(31);
                SelectedStyle.TextColor =       CColor(192);

                NormalStyle.BackColor =         CColor(68);
                NormalStyle.BorderColor =       CColor(51);
                NormalStyle.TextColor =         CColor(192);

                OverStyle.BackColor =           CColor(76);
                OverStyle.BorderColor =         CColor(57);
                OverStyle.TextColor =           CColor(192);

                // sub buttons or close button
                SubButtonsBorderSize = 1;

                SubButtonsSelectedStyle.BackColor =         CColor(49);
                SubButtonsSelectedStyle.BorderColor =       CColor(40);
                SubButtonsSelectedStyle.TextColor =         CColor(192);

                SubButtonsSelectedOverStyle.BackColor =     CColor(60);
                SubButtonsSelectedOverStyle.BorderColor =   CColor(38);
                SubButtonsSelectedOverStyle.TextColor =     CColor(192);

                SubButtonsNormalStyle.BackColor =           CColor(68);
                SubButtonsNormalStyle.BorderColor =         CColor(58);
                SubButtonsNormalStyle.TextColor =           CColor(192);

                SubButtonsOverStyle.BackColor =             CColor(95);
                SubButtonsOverStyle.BorderColor =           CColor(67);
                SubButtonsOverStyle.TextColor =             CColor(192);

                SubButtonsParentOverStyle.BackColor =       CColor(86);
                SubButtonsParentOverStyle.BorderColor =     CColor(67);
                SubButtonsParentOverStyle.TextColor =       CColor(192);
            }
            // --------------------------
            //       DarkRectWClose
            // --------------------------
            else if (skin == TabSkin.DarkRectWClose)
            { 
                _SetSkin(TabSkin.DarkRect, false);

                // shape and text mode
                TextAlign = TabTextAlign.Left;

                // close button
                CloseButtonVisible = true;
                PaintMode = TabPaintMode.UserPaintOver;
                CloseButtonBehaviour = CloseBtnBehaviour.ActiveAlways;

                // padding
                LeftPadding =   5;
                RightPadding =  10;
            }
            // --------------------------
            //     DarkRectWCloseSel
            // --------------------------
            else if (skin == TabSkin.DarkRectWCloseSel)
            { 
                _SetSkin(TabSkin.DarkRectWClose, false);

                // close button
                CloseButtonBehaviour = CloseBtnBehaviour.ActiveOnSelect;
            }



            // --------------------------
            //        DarkRectExtra
            // --------------------------
            else if (skin == TabSkin.DarkRectExtra)
            { 
                _SetSkin(TabSkin.DarkRect, false);

                // shape and text mode
                ShapeMode = TabShapeMode.BoxExtraBorders;
            }
            // --------------------------
            //    DarkRectExtraWClose
            // --------------------------
            else if (skin == TabSkin.DarkRectExtraWClose)
            { 
                _SetSkin(TabSkin.DarkRect, false);

                // shape and text mode
                ShapeMode = TabShapeMode.BoxExtraBorders;
                TextAlign = TabTextAlign.Left;

                // close button
                CloseButtonVisible = true;
                PaintMode = TabPaintMode.UserPaintOver;
                CloseButtonBehaviour = CloseBtnBehaviour.ActiveAlways;

                // padding
                LeftPadding =   5;
                RightPadding =  10;
            }
            // --------------------------
            //   DarkRectExtraWCloseSel
            // --------------------------
            else if (skin == TabSkin.DarkRectExtraWCloseSel)
            { 
                _SetSkin(TabSkin.DarkRectExtraWClose, false);

                // close button
                CloseButtonBehaviour = CloseBtnBehaviour.ActiveOnSelect;
            }



            // --------------------------
            //          DarkRound
            // --------------------------
            else if (skin == TabSkin.DarkRound)
            {
                _SetSkin(TabSkin.DarkRect, false);

                // shape and text mode
                ShapeMode = TabShapeMode.RoundBox;
            }
            // --------------------------
            //       DarkRoundWClose
            // --------------------------
            else if (skin == TabSkin.DarkRoundWClose)
            {
                _SetSkin(TabSkin.DarkRect, false);

                // shape and text mode
                ShapeMode = TabShapeMode.RoundBox;
                TextAlign = TabTextAlign.Left;
                CloseButtonBehaviour = CloseBtnBehaviour.ActiveAlways;

                // close button
                CloseButtonVisible = true;
                PaintMode = TabPaintMode.UserPaintOver;
                
                // padding
                LeftPadding =   5;
                RightPadding =  10;

                // sub buttons or close button
                SubButtonsBorderSize = 0;
                SubButtonsOverStyle.BackColor =         CColor(86);
                SubButtonsParentOverStyle.BackColor =   CColor(76);
            }
            // --------------------------
            //     DarkRoundWCloseSel
            // --------------------------
            else if (skin == TabSkin.DarkRoundWCloseSel)
            {
                _SetSkin(TabSkin.DarkRoundWClose, false);

                // shape and text mode
                CloseButtonBehaviour = CloseBtnBehaviour.ActiveOnSelect;

                // sub buttons or close button
                SubButtonsBorderSize = 0;
            }



            // --------------------------
            //       DarkRectThin
            // --------------------------
            else if (skin == TabSkin.DarkRectThin)
            {
                _SetSkin(TabSkin.DarkRect, false);

                // tab color and border
                TabBorderSize = 1;
            }
            // --------------------------
            //     DarkRectThinWClose
            // --------------------------
            else if (skin == TabSkin.DarkRectThinWClose)
            {
                _SetSkin(TabSkin.DarkRectThin, false);

                // shape and text mode
                TextAlign = TabTextAlign.Left;

                // close button
                CloseButtonVisible = true;
                PaintMode = TabPaintMode.UserPaintOver;
                CloseButtonBehaviour = CloseBtnBehaviour.ActiveAlways;

                // padding
                LeftPadding =   5;
                RightPadding =  10;
            }
            // --------------------------
            //   DarkRectThinWCloseSel
            // --------------------------
            else if (skin == TabSkin.DarkRectThinWCloseSel)
            {
                _SetSkin(TabSkin.DarkRectThinWClose, false);

                // shape and text mode
                CloseButtonBehaviour = CloseBtnBehaviour.ActiveOnSelect;
            }


            // --------------------------
            //          DarkMiddleRound
            // --------------------------
            else if (skin == TabSkin.DarkMiddleRound)
            {
                _SetSkin(TabSkin.DarkRect, false);

                // shape and text mode
                ShapeMode = TabShapeMode.RoundBox;

                // position and anim
                SelectedTabSize =   new TabSize(0, -5);
                NormalTabSize =     new TabSize(2, -5);
                DraggedTabSize =    new TabSize(1, -5);
            }
            // --------------------------
            //       DarkMiddleRoundWClose
            // --------------------------
            else if (skin == TabSkin.DarkMiddleRoundWClose)
            {
                _SetSkin(TabSkin.DarkMiddleRound, false);

                // shape and text mode
                ShapeMode = TabShapeMode.RoundBox;
                TextAlign = TabTextAlign.Left;
                CloseButtonBehaviour = CloseBtnBehaviour.ActiveAlways;

                // close button
                CloseButtonVisible = true;
                PaintMode = TabPaintMode.UserPaintOver;
                
                // padding
                LeftPadding =   5;
                RightPadding =  10;

                // sub buttons or close button
                SubButtonsBorderSize = 0;
                SubButtonsOverStyle.BackColor =         CColor(86);
                SubButtonsParentOverStyle.BackColor =   CColor(76);


            }
            // --------------------------
            //     DarkMiddleRoundWCloseSel
            // --------------------------
            else if (skin == TabSkin.DarkMiddleRoundWCloseSel)
            {
                _SetSkin(TabSkin.DarkMiddleRoundWClose, false);

                // shape and text mode
                CloseButtonBehaviour = CloseBtnBehaviour.ActiveOnSelect;

                // sub buttons or close button
                SubButtonsBorderSize = 0;
            }

            if (refreshLayout)
                controller.RefreshLayout();

            Invalidate();
        }

        private Color CColor(int red, int green, int blue)
        { 
            return Color.FromArgb(red, green, blue);
        }

        private Color CColor(int color)
        {
            return Color.FromArgb(color, color, color);
        }

        // Controller Events
        private void OnSelectedTabChanged(int index, TabItem item)
        {
            if(SelectedTabChanged != null)
                SelectedTabChanged(index, item);
        }

        private void OnUnselectedTabChanged(int index, TabItem item)
        {
            if (UnselectedTabChanged != null)
                UnselectedTabChanged(index, item);
        }

        private void OnTabAdded(int index, TabItem item)
        {
            if(TabAdded != null)
                TabAdded(index, item);
        }

        private void OnTabRemoved(int index, TabItem item)
        {
            if(TabRemoved != null)
                TabRemoved(index, item);
        }

        private void OnStartDragTab(int index, TabItem item)
        {
            if(StartDragTab != null)
                StartDragTab(index, item);
        }

        private void OnStopDragTab(int index, TabItem item)
        {
            if(StopDragTab != null)
                StopDragTab(index, item);
        }

        private void OnTimerRepaintNeeded()
        {
            Invalidate();
        }

        // Item Events
        private void OnItemAdded(int index, TabItem item)
        {
            if (!_itemEventsEnabled) return;

            controller.Insert(index, item);
            Invalidate();
        }

        private void OnItemRemoved(int index, TabItem item)
        {
            if (!_itemEventsEnabled) return;

            controller.RemoveAt(index);
            Invalidate();
        }

        private void OnItemModified(TabItem oldItem, TabItem newItem)
        {
            if (!_itemEventsEnabled) return;

            XConsole.Println("item modified: " + newItem.Text);
            Invalidate();
        }

        private void OnItemsCleared()
        {
            if (!_itemEventsEnabled) return;

            controller.RemoveAllTabs();
            Invalidate();
        }

        private void OnTabIndexChanged(int oldIndex, int newIndex)
        {
            _itemEventsEnabled = false;
            
            TabItem item = Items[oldIndex];
            Items.RemoveAt(oldIndex);
            Items.Insert(newIndex, item);

            _itemEventsEnabled = true;
        }

        private void OnTabDetached(int index, TabItem item, int offsetX)
        {
            if (TabDetached != null)
                TabDetached(index, item, offsetX);
        }

        private void OnTabItemTextChanged(int index, TabItem item)
        {
            if(TabItemTextChanged != null)
                TabItemTextChanged(index, item);

            Invalidate();
        }

        private void OnCloseTabInvoked(int index, TabItem item)
        {
            if (CloseTabInvoked != null)
                CloseTabInvoked(index, item);
        }

        protected override void OnMouseEnter(EventArgs e)
        { 
            base.OnMouseEnter(e);
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            controller.MouseDown(e.X, e.Y);
            base.OnMouseDown(e);
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            controller.MouseMove(e.X, e.Y, e.Button == MouseButtons.Left);
            base.OnMouseMove(e);
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            controller.MouseUp(e.X, e.Y);
            base.OnMouseUp(e);
            Invalidate();

            if ((e.Button == MouseButtons.Right) && (RightClickContext != null) && (controller.SelectedTab != null))
                RightClickContext(controller.SelectedTab.Item);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            controller.MouseLeave();
            base.OnMouseLeave(e);
            Invalidate();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            controller.MouseScroll(e.X, e.Y, e.Delta > 0 ? 1 : -1);
            base.OnMouseWheel(e);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(BackColor), ClientRectangle);

#if USE_AUTO_SHIFT_TIMERS
            if(controller.UpdateTimerNeeded)
                controller.UpdateTimer();
            else
                controller.Update();
#else
            controller.Update();
#endif
            controller.Paint(e.Graphics);
        }

    }
}
