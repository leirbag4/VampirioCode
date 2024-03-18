using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampEditor;
using VampirioCode.UI;
using VampirioCode.UI.Controls;

namespace VampDocManager
{
    public partial class DocumentTab
    {
        private ScrollBarAdv vertScrollBar;
        private ScrollBarAdv horScrollBar;
        private Control scrollBarCorner;

        private void CreateCustomScrollBars()
        {
            vertScrollBar =                     new ScrollBarAdv();
            vertScrollBar.ThumbPaddingX =       5;
            vertScrollBar.ThumbPaddingY =       4;
            vertScrollBar.MinThumbSize =        20;
            vertScrollBar.ThumbNormalColor =    Color.FromArgb(65, 65, 65);
            vertScrollBar.ThumbOverColor =      Color.FromArgb(75, 75, 75);
            vertScrollBar.ButtonSize =          SystemInformation.VerticalScrollBarWidth;
            vertScrollBar.Width =               SystemInformation.VerticalScrollBarWidth;
            vertScrollBar.Anchor =              AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            vertScrollBar.Scroll +=             OnVertScroll;


            horScrollBar =                      new ScrollBarAdv();
            horScrollBar.Orientation =          VampirioCode.UI.Controls.ScrollBarAdvance.ScrollBarOrientation.Horizontal;
            horScrollBar.AllowMouseScrolling =  false;
            horScrollBar.ThumbPaddingX =        4;
            horScrollBar.ThumbPaddingY =        5;
            horScrollBar.MinThumbSize =         20;
            horScrollBar.ThumbNormalColor =     Color.FromArgb(65, 65, 65);
            horScrollBar.ThumbOverColor =       Color.FromArgb(75, 75, 75);
            horScrollBar.ButtonSize =           SystemInformation.HorizontalScrollBarHeight;
            horScrollBar.Height =               SystemInformation.HorizontalScrollBarHeight;
            horScrollBar.Anchor =               AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            horScrollBar.Scroll +=              OnHorScroll;


            scrollBarCorner =                   new Control();
            scrollBarCorner.BackColor =         Color.FromArgb(60, 60, 60);
            scrollBarCorner.Size =              new Size(SystemInformation.VerticalScrollBarWidth, SystemInformation.HorizontalScrollBarHeight);
            scrollBarCorner.Location =          new Point(Content.Width - scrollBarCorner.Width, Content.Height - scrollBarCorner.Height);
            scrollBarCorner.Anchor =            AnchorStyles.Bottom | AnchorStyles.Right;


            Content.Controls.Add(vertScrollBar);
            Content.Controls.Add(horScrollBar);
            Content.Controls.Add(scrollBarCorner);
            vertScrollBar.BringToFront();
            horScrollBar.BringToFront();
            scrollBarCorner.BringToFront();

            RefreshScrollBarsVisibility();

        }

        private void RefreshScrollBarsVisibility()
        {
            bool vscrollVisible = Editor.IsVerticalScrollVisible;
            bool hscrollVisible = horScrollBar.Maximum >= horScrollBar.LargeChange;


            if (hscrollVisible)
                vertScrollBar.Height = Content.Height - horScrollBar.Height;
            else
                vertScrollBar.Height = Content.Height;

            if (vscrollVisible)
                horScrollBar.Width = Content.Width - vertScrollBar.Width;
            else
                horScrollBar.Width = Content.Width;


            vertScrollBar.Location =    new Point(Content.Width - vertScrollBar.Width - scrollBarOffset, 0);
            horScrollBar.Location =     new Point(0, Content.Height - horScrollBar.Height - scrollBarOffset);


            vertScrollBar.Visible =     vscrollVisible;
            horScrollBar.Visible =      hscrollVisible;
            scrollBarCorner.Visible =   vscrollVisible && hscrollVisible;
        }


        private void OnVertScroll(int newValue, int oldValue)
        {
            Editor.FirstVisibleLine = vertScrollBar.Value;
        }

        private void OnHorScroll(int newValue, int oldValue)
        {
            Editor.XOffset = horScrollBar.Value;
        }

        private void VerticalScrollChanged(ScrollInfo scrollInfo, int position)
        {
            OnVerticalScrollChanged(scrollInfo, position);
        }

        private void HorizontalScrollChanged(ScrollInfo scrollInfo, int position)
        {
            OnHorizontalScrollChanged(scrollInfo, position);
        }

        private void OnVerticalScrollChanged(ScrollInfo scrollInfo, int position)
        {
            ScrollBarAdv scroll = vertScrollBar;

            if (scroll.Minimum !=       scrollInfo.min)         scroll.Minimum =        scrollInfo.min;
            if (scroll.Maximum !=       scrollInfo.max)         scroll.Maximum =        scrollInfo.max;
            if (scroll.LargeChange !=   scrollInfo.nPage)       scroll.LargeChange =    scrollInfo.nPage;
            if (scroll.Value !=         position)               scroll.Value =          position;
            // scroll.nTrackPos is not used here because not always has new values

            RefreshScrollBarsVisibility();
        }

        private void OnHorizontalScrollChanged(ScrollInfo scrollInfo, int position)
        {
            ScrollBarAdv scroll = horScrollBar;

            if (scroll.Minimum !=       scrollInfo.min)     scroll.Minimum =        scrollInfo.min;
            if (scroll.Maximum !=       scrollInfo.max)     scroll.Maximum =        scrollInfo.max;
            if (scroll.LargeChange !=   scrollInfo.nPage)   scroll.LargeChange =    scrollInfo.nPage;
            if (scroll.Value !=         position)           scroll.Value =          position;
            // scroll.nTrackPos is not used here because not always has new values

            RefreshScrollBarsVisibility();
        }

    }
}
