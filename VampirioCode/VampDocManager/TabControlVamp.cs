using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Design;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;

namespace VampDocManager
{
    public class PolyObject
    {

        public Point[] points
        {
            get { return _points.ToArray(); }
        }

        public int x, y, width, height;
        public Color color = Color.Black;
        private List<Point> _points;

        public PolyObject()
        {
            x = y = width = height = 0;
            _points = new List<Point>();
        }

        public void addPoint(int x, int y)
        {
            _points.Add(new Point(x, y));
            refresh();
        }

        private void refresh()
        {
            int minX = 0;
            int maxX = 0;
            int minY = 0;
            int maxY = 0;

            Point point;

            for (int a = 0; a < _points.Count; a++)
            {
                point = _points[a];

                if (point.X >= maxX)
                    maxX = point.X;

                if (point.Y >= maxY)
                    maxY = point.Y;
            }

            minX = maxX;
            minY = maxY;

            for (int a = 0; a < _points.Count; a++)
            {
                point = _points[a];

                if (point.X <= minX)
                    minX = point.X;

                if (point.Y <= minY)
                    minY = point.Y;
            }

            //--------------------

            width = maxX - minX;
            height = maxY - minY;
        }

        public void paint(Graphics g)
        {
            List<Point> p = new List<Point>();

            for (int a = 0; a < points.Length; a++)
                p.Add(new Point(points[a].X + x, points[a].Y + y));

            g.FillPolygon(new SolidBrush(color), p.ToArray());
        }

    }


    internal class Win32
    {
        /*
		 * GetWindow() Constants
		 */
        public const int GW_HWNDFIRST = 0;
        public const int GW_HWNDLAST = 1;
        public const int GW_HWNDNEXT = 2;
        public const int GW_HWNDPREV = 3;
        public const int GW_OWNER = 4;
        public const int GW_CHILD = 5;

        public const int WM_NCCALCSIZE = 0x83;
        public const int WM_WINDOWPOSCHANGING = 0x46;
        public const int WM_PAINT = 0xF;
        public const int WM_CREATE = 0x1;
        public const int WM_NCCREATE = 0x81;
        public const int WM_NCPAINT = 0x85;
        public const int WM_PRINT = 0x317;
        public const int WM_DESTROY = 0x2;
        public const int WM_SHOWWINDOW = 0x18;
        public const int WM_SHARED_MENU = 0x1E2;
        public const int HC_ACTION = 0;
        public const int WH_CALLWNDPROC = 4;
        public const int GWL_WNDPROC = -4;

        public Win32()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowDC(IntPtr handle);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr ReleaseDC(IntPtr handle, IntPtr hDC);

        [DllImport("Gdi32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hwnd, char[] className, int maxCount);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindow(IntPtr hwnd, int uCmd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool IsWindowVisible(IntPtr hwnd);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern int GetClientRect(IntPtr hwnd, ref RECT lpRect);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern int GetClientRect(IntPtr hwnd, [In, Out] ref Rectangle rect);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern bool MoveWindow(IntPtr hwnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern bool UpdateWindow(IntPtr hwnd);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern bool InvalidateRect(IntPtr hwnd, ref Rectangle rect, bool bErase);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern bool ValidateRect(IntPtr hwnd, ref Rectangle rect);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern bool GetWindowRect(IntPtr hWnd, [In, Out] ref Rectangle rect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWPOS
        {
            public IntPtr hwnd;
            public IntPtr hwndAfter;
            public int x;
            public int y;
            public int cx;
            public int cy;
            public uint flags;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NCCALCSIZE_PARAMS
        {
            public RECT rgc;
            public WINDOWPOS wndpos;
        }
    }

    #region SubClass Classing Handler Class
    internal class SubClass : System.Windows.Forms.NativeWindow
    {
        public delegate int SubClassWndProcEventHandler(ref System.Windows.Forms.Message m);
        public event SubClassWndProcEventHandler SubClassedWndProc;
        private bool IsSubClassed = false;

        public SubClass(IntPtr Handle, bool _SubClass)
        {
            base.AssignHandle(Handle);
            this.IsSubClassed = _SubClass;
        }

        public bool SubClassed
        {
            get { return this.IsSubClassed; }
            set { this.IsSubClassed = value; }
        }

        protected override void WndProc(ref Message m)
        {
            if (this.IsSubClassed)
            {
                if (OnSubClassedWndProc(ref m) != 0)
                    return;
            }
            base.WndProc(ref m);
        }

        public void CallDefaultWndProc(ref Message m)
        {
            base.WndProc(ref m);
        }

        #region HiWord Message Cracker
        public int HiWord(int Number)
        {
            return ((Number >> 16) & 0xffff);
        }
        #endregion

        #region LoWord Message Cracker
        public int LoWord(int Number)
        {
            return (Number & 0xffff);
        }
        #endregion

        #region MakeLong Message Cracker
        public int MakeLong(int LoWord, int HiWord)
        {
            return (HiWord << 16) | (LoWord & 0xffff);
        }
        #endregion

        #region MakeLParam Message Cracker
        public IntPtr MakeLParam(int LoWord, int HiWord)
        {
            return (IntPtr)((HiWord << 16) | (LoWord & 0xffff));
        }
        #endregion

        private int OnSubClassedWndProc(ref Message m)
        {
            if (SubClassedWndProc != null)
            {
                return this.SubClassedWndProc(ref m);
            }

            return 0;
        }
    }
    #endregion










    /// <summary>
    /// Summary description for TabControlAdv.
    /// </summary>
    [ToolboxBitmap(typeof(System.Windows.Forms.TabControl))] //,
                                                             //Designer(typeof(Designers.FlatTabControlDesigner))]

    public class TabControlVamp : System.Windows.Forms.TabControl
    {

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Drag and Drop")]
        [Browsable(true)]
        public bool DragAndDrop
        {
            set { _dragAndDrop = value; SetDragAndDrop(_dragAndDrop); }
            get { return _dragAndDrop; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Tab Color")]
        [Browsable(true)]
        public Color TabColor
        {
            set { _tabColor = value; Invalidate(); }
            get { return _tabColor; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Tab Selected Color")]
        [Browsable(true)]
        public Color TabSelectedColor
        {
            set { _tabSelectedColor = value; Invalidate(); }
            get { return _tabSelectedColor; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Inner Border Color")]
        [Browsable(true)]
        public Color InnerBorderColor
        {
            set { _innerBorderColor = value; Invalidate(); }
            get { return _innerBorderColor; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Top Border Color")]
        [Browsable(true)]
        public Color TopBorderColor
        {
            set { _topBorderColor = value; Invalidate(); }
            get { return _topBorderColor; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Font Color")]
        [Browsable(true)]
        public Color FontColor
        {
            set { _fontColor = value; Invalidate(); }
            get { return _fontColor; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Arrows Back Color")]
        [Browsable(true)]
        public Color ArrowsBackColor
        {
            set { _arrowsBackColor = value; CreateLeftRightArrows(); Invalidate(); }
            get { return _arrowsBackColor; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Arrows Color")]
        [Browsable(true)]
        public Color ArrowsColor
        {
            set { _arrowsColor = value; CreateLeftRightArrows(); Invalidate(); }
            get { return _arrowsColor; }
        }

        public DocumentTab[] DocumentTabs 
        { 
            get 
            {
                DocumentTab[] docTabs = new DocumentTab[TabPages.Count];
                for (int a = 0; a < TabPages.Count; a++)
                    docTabs[a] = (DocumentTab)TabPages[a];

                return docTabs;
            } 
        }

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        private SubClass scUpDown = null;
        private bool bUpDown; // true when the button UpDown is required
        private ImageList leftRightImages = null;
        private const int nMargin = 5;
        private Color _backColor = SystemColors.Control;

        private bool _dragAndDrop = false;
        private Color _tabColor = Color.LightGray;
        private Color _tabSelectedColor = Color.Gray;
        private Color _innerBorderColor = Color.DarkGray;
        private Color _topBorderColor = Color.DarkGray;
        private Color _fontColor = Color.Black;
        private Color _arrowsColor = Color.Black;
        private Color _arrowsBackColor = Color.LightGray;

        public bool paintTabs = true;

        public TabControlVamp()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            AllowDrop = true;
            DragAndDrop = true;

            DrawMode = TabDrawMode.Normal;
            // TabSizeMode.Normal: tab width is dynamically calculated
            // TabSizeMode.Fixed:  tab width is fixed and can be set using ItemSize = new Size(width, 25);
            SizeMode = TabSizeMode.Normal;


            // double buffering
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            bUpDown = false;

            this.ControlAdded += new ControlEventHandler(FlatTabControl_ControlAdded);
            this.ControlRemoved += new ControlEventHandler(FlatTabControl_ControlRemoved);
            this.SelectedIndexChanged += new EventHandler(FlatTabControl_SelectedIndexChanged);

            //leftRightImages = new ImageList();
            //leftRightImages.ImageSize = new Size(16, 16); // default

            /*System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FlatTabControl));
            Bitmap updownImage = ((System.Drawing.Bitmap)(resources.GetObject("TabIcons.bmp")));

            if (updownImage != null)
            {
                updownImage.MakeTransparent(Color.White);
                leftRightImages.Images.AddStrip(updownImage);
            }*/

            CreateLeftRightArrows();
        }

        public void SetDefaultSkin()
        {
            //Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            SetSkin(Color.FromArgb(64, 64, 64), Color.FromArgb(30, 30, 30), Color.FromArgb(45, 45, 46), Color.FromArgb(0, 122, 204), Color.White, Color.FromArgb(60, 60, 60), Color.White);
            FontColor = Color.White;
        }

        public void SetSkin(Color backColor, Color innerBorderColor, Color tabColor, Color selectedTabColor, Color arrowsColor, Color arrowsBackColor, Color fontColor)
        {
            //Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.BackColor = backColor;
            this.InnerBorderColor = innerBorderColor;
            this.TabColor = tabColor;
            this.TabSelectedColor = selectedTabColor;
            this.ArrowsColor = arrowsColor;
            this.ArrowsBackColor = arrowsBackColor;
            this.TopBorderColor = Color.FromArgb(60, 60, 60);
            this.FontColor = fontColor;
        }

        public void SetSkin(int tabHeight, Color backColor, Color tabColor, Color selectedTabColor, Color fontColor)
        {
            //Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            SetSkin(backColor, backColor, tabColor, selectedTabColor, Color.White, Color.FromArgb(60, 60, 60), fontColor);
            SetTabSizeAuto(tabHeight);
        }

        public void SetTabSizeAuto(int height)
        {
            SizeMode = TabSizeMode.Normal;
            ItemSize = new Size(ItemSize.Width, height);
        }

        public void SetTabSizeFixed(int width, int height)
        {
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(width, height);
        }

        public void SetDragAndDrop(bool active)
        {
            if (active)
            {
                MouseDown += OnDrgDpMouseDown;
                MouseUp += OnDrgDpMouseUp;
                MouseMove += OnDrgDpMouseMove;
                DragOver += OnDrgDpDragOver;

                AllowDrop = true; // for drag and drop
            }
            else
            {
                MouseDown -= OnDrgDpMouseDown;
                MouseUp -= OnDrgDpMouseUp;
                MouseMove -= OnDrgDpMouseMove;
                DragOver -= OnDrgDpDragOver;

                AllowDrop = false; // for drag and drop
            }
        }


        private void CreateLeftRightArrows()
        {
            Bitmap bmpLeft, bmpRight;
            Graphics g;

            PolyObject leftArrow = new PolyObject();
            leftArrow.addPoint(0, 5);
            leftArrow.addPoint(5, 0);
            leftArrow.addPoint(5, 10);

            PolyObject rightArrow = new PolyObject();
            rightArrow.addPoint(0, 0);
            rightArrow.addPoint(5, 5);
            rightArrow.addPoint(0, 10);


            bmpLeft = new Bitmap(16, 16);
            g = Graphics.FromImage(bmpLeft);

            //g.FillRectangle(Brushes.Red, 0, 0, bmpLeft.Width, bmpLeft.Height);
            leftArrow.x = (bmpLeft.Width >> 1) - (leftArrow.width >> 1);
            leftArrow.y = (bmpLeft.Height >> 1) - (leftArrow.height >> 1);
            leftArrow.color = ArrowsColor;
            leftArrow.paint(g);

            bmpRight = new Bitmap(16, 16);
            g = Graphics.FromImage(bmpRight);

            //g.FillRectangle(Brushes.Red, 0, 0, bmpRight.Width, bmpRight.Height);
            rightArrow.x = (bmpRight.Width >> 1) - (rightArrow.width >> 1);
            rightArrow.y = (bmpRight.Height >> 1) - (rightArrow.height >> 1);
            rightArrow.color = ArrowsColor;
            rightArrow.paint(g);

            if (leftRightImages == null)
                leftRightImages = new ImageList();
            leftRightImages.Images.Clear();
            leftRightImages.Images.AddStrip(bmpRight);
            leftRightImages.Images.AddStrip(bmpLeft);
            leftRightImages.Images.AddStrip(bmpRight);
            leftRightImages.Images.AddStrip(bmpLeft);
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }

                leftRightImages.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            DrawControl(e.Graphics);
        }

        internal void DrawControl(Graphics g)
        {
            if (!Visible)
                return;

            Rectangle TabControlArea = this.ClientRectangle;
            Rectangle TabArea = this.DisplayRectangle;

            //----------------------------
            // fill client area
            Brush br = new SolidBrush(_backColor); //(SystemColors.Control); UPDATED
            g.FillRectangle(br, TabControlArea);
            br.Dispose();
            //----------------------------

            //----------------------------
            // draw border
            int nDelta = SystemInformation.Border3DSize.Width;

            Pen border = new Pen(InnerBorderColor);
            TabArea.Inflate(nDelta, nDelta);
            g.DrawRectangle(border, TabArea);
            border.Dispose();
            //----------------------------


            //----------------------------
            // clip region for drawing tabs
            Region rsaved = g.Clip;
            Rectangle rreg;

            int nWidth = TabArea.Width + nMargin;
            if (bUpDown)
            {
                // exclude updown control for painting
                if (Win32.IsWindowVisible(scUpDown.Handle))
                {
                    Rectangle rupdown = new Rectangle();
                    Win32.GetWindowRect(scUpDown.Handle, ref rupdown);
                    Rectangle rupdown2 = this.RectangleToClient(rupdown);

                    nWidth = rupdown2.X;
                }
            }

            rreg = new Rectangle(TabArea.Left, TabControlArea.Top, nWidth - nMargin, TabControlArea.Height);

            g.SetClip(rreg);

            // draw tabs
            for (int i = 0; i < this.TabCount; i++)
                DrawTab(g, this.TabPages[i], i);

            g.Clip = rsaved;
            //----------------------------


            //----------------------------
            // draw background to cover flat border areas
            if (this.SelectedTab != null)
            {
                TabPage tabPage = this.SelectedTab;
                Color color = tabPage.BackColor;
                border = new Pen(color);

                TabArea.Offset(1, 1);
                TabArea.Width -= 2;
                TabArea.Height -= 2;

                g.DrawRectangle(border, TabArea);
                TabArea.Width -= 1;
                TabArea.Height -= 1;
                g.DrawRectangle(border, TabArea);

                border.Dispose();
            }
            //----------------------------
        }

        internal void DrawTab(Graphics g, TabPage tabPage, int nIndex)
        {
            if (!paintTabs)
                return;
            Rectangle recBounds = this.GetTabRect(nIndex);
            RectangleF tabTextArea = (RectangleF)this.GetTabRect(nIndex);

            bool bSelected = (this.SelectedIndex == nIndex);

            Point[] pt = new Point[7];

            //**************************
            //**** ROUND BORDERS *******
            //**************************
            /*if (this.Alignment == TabAlignment.Top)
            {
                pt[0] = new Point(recBounds.Left, recBounds.Bottom);
                pt[1] = new Point(recBounds.Left, recBounds.Top + 3);
                pt[2] = new Point(recBounds.Left + 3, recBounds.Top);
                pt[3] = new Point(recBounds.Right - 3, recBounds.Top);
                pt[4] = new Point(recBounds.Right, recBounds.Top + 3);
                pt[5] = new Point(recBounds.Right, recBounds.Bottom);
                pt[6] = new Point(recBounds.Left, recBounds.Bottom);
            }
            else
            {
                pt[0] = new Point(recBounds.Left, recBounds.Top);
                pt[1] = new Point(recBounds.Right, recBounds.Top);
                pt[2] = new Point(recBounds.Right, recBounds.Bottom - 3);
                pt[3] = new Point(recBounds.Right - 3, recBounds.Bottom);
                pt[4] = new Point(recBounds.Left + 3, recBounds.Bottom);
                pt[5] = new Point(recBounds.Left, recBounds.Bottom - 3);
                pt[6] = new Point(recBounds.Left, recBounds.Top);
            }*/


            if (this.Alignment == TabAlignment.Top)
            {
                pt[0] = new Point(recBounds.Left, recBounds.Bottom);
                pt[1] = new Point(recBounds.Left, recBounds.Top);
                pt[2] = new Point(recBounds.Left, recBounds.Top);
                pt[3] = new Point(recBounds.Right, recBounds.Top);
                pt[4] = new Point(recBounds.Right, recBounds.Top);
                pt[5] = new Point(recBounds.Right, recBounds.Bottom);
                pt[6] = new Point(recBounds.Left, recBounds.Bottom);
            }
            else
            {
                pt[0] = new Point(recBounds.Left, recBounds.Top);
                pt[1] = new Point(recBounds.Right, recBounds.Top);
                pt[2] = new Point(recBounds.Right, recBounds.Bottom);
                pt[3] = new Point(recBounds.Right, recBounds.Bottom);
                pt[4] = new Point(recBounds.Left, recBounds.Bottom);
                pt[5] = new Point(recBounds.Left, recBounds.Bottom);
                pt[6] = new Point(recBounds.Left, recBounds.Top);
            }

            //----------------------------
            // fill this tab with background color
            Brush br;

            if (bSelected)
                br = new SolidBrush(TabSelectedColor);
            else
                br = new SolidBrush(TabColor);

            g.FillPolygon(br, pt);
            br.Dispose();
            //----------------------------

            //----------------------------
            // draw border
            //g.DrawRectangle(SystemPens.ControlDark, recBounds);
            g.DrawPolygon(new Pen(TopBorderColor), pt);

            if (bSelected)
            {
                //----------------------------
                // clear bottom lines
                Pen pen = new Pen(tabPage.BackColor);

                switch (this.Alignment)
                {
                    case TabAlignment.Top:
                        g.DrawLine(pen, recBounds.Left + 1, recBounds.Bottom, recBounds.Right - 1, recBounds.Bottom);
                        g.DrawLine(pen, recBounds.Left + 1, recBounds.Bottom + 1, recBounds.Right - 1, recBounds.Bottom + 1);
                        break;

                    case TabAlignment.Bottom:
                        g.DrawLine(pen, recBounds.Left + 1, recBounds.Top, recBounds.Right - 1, recBounds.Top);
                        g.DrawLine(pen, recBounds.Left + 1, recBounds.Top - 1, recBounds.Right - 1, recBounds.Top - 1);
                        g.DrawLine(pen, recBounds.Left + 1, recBounds.Top - 2, recBounds.Right - 1, recBounds.Top - 2);
                        break;
                }

                pen.Dispose();
                //----------------------------
            }
            //----------------------------

            //----------------------------
            // draw tab's icon
            if ((tabPage.ImageIndex >= 0) && (ImageList != null) && (ImageList.Images[tabPage.ImageIndex] != null))
            {
                int nLeftMargin = 8;
                int nRightMargin = 2;

                Image img = ImageList.Images[tabPage.ImageIndex];

                Rectangle rimage = new Rectangle(recBounds.X + nLeftMargin, recBounds.Y + 1, img.Width, img.Height);

                // adjust rectangles
                float nAdj = (float)(nLeftMargin + img.Width + nRightMargin);

                rimage.Y += (recBounds.Height - img.Height) / 2;
                tabTextArea.X += nAdj;
                tabTextArea.Width -= nAdj;

                // draw icon
                g.DrawImage(img, rimage);
            }
            //----------------------------

            //----------------------------
            // draw string
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            br = new SolidBrush(FontColor);

            g.DrawString(tabPage.Text, Font, br, tabTextArea, stringFormat);
            //----------------------------
        }

        internal void DrawIcons(Graphics g)
        {
            if ((leftRightImages == null) || (leftRightImages.Images.Count != 4))
                return;

            //----------------------------
            // calc positions
            Rectangle TabControlArea = this.ClientRectangle;

            Rectangle r0 = new Rectangle();
            Win32.GetClientRect(scUpDown.Handle, ref r0);

            Brush br = new SolidBrush(ArrowsBackColor);
            g.FillRectangle(br, r0);
            br.Dispose();

            Pen border = new Pen(InnerBorderColor);
            Rectangle rborder = r0;
            //rborder.Inflate(-1, -1);

            rborder.Width -= 1;
            rborder.Height -= 1;

            g.DrawRectangle(border, rborder);
            border.Dispose();

            int nMiddle = (r0.Width / 2);
            int nTop = (r0.Height - 16) / 2;
            int nLeft = (nMiddle - 16) / 2;

            Rectangle r1 = new Rectangle(nLeft, nTop, 16, 16);
            Rectangle r2 = new Rectangle(nMiddle + nLeft, nTop, 16, 16);
            //----------------------------

            //----------------------------
            // draw buttons
            Image img = leftRightImages.Images[1];
            if (img != null)
            {
                if (this.TabCount > 0)
                {
                    Rectangle r3 = this.GetTabRect(0);
                    if (r3.Left < TabControlArea.Left)
                        g.DrawImage(img, r1);
                    else
                    {
                        img = leftRightImages.Images[3];
                        if (img != null)
                            g.DrawImage(img, r1);
                    }
                }
            }

            img = leftRightImages.Images[0];
            if (img != null)
            {
                if (this.TabCount > 0)
                {
                    Rectangle r3 = this.GetTabRect(this.TabCount - 1);
                    if (r3.Right > (TabControlArea.Width - r0.Width))
                        g.DrawImage(img, r2);
                    else
                    {
                        img = leftRightImages.Images[2];
                        if (img != null)
                            g.DrawImage(img, r2);
                    }
                }
            }
            //----------------------------
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            FindUpDown();
        }

        private void FlatTabControl_ControlAdded(object sender, ControlEventArgs e)
        {
            FindUpDown();
            UpdateUpDown();
        }

        private void FlatTabControl_ControlRemoved(object sender, ControlEventArgs e)
        {
            FindUpDown();
            UpdateUpDown();
        }

        private void FlatTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUpDown();
            Invalidate();   // we need to update border and background colors
        }

        private void FindUpDown()
        {
            bool bFound = false;

            // find the UpDown control
            IntPtr pWnd = Win32.GetWindow(this.Handle, Win32.GW_CHILD);

            while (pWnd != IntPtr.Zero)
            {
                //----------------------------
                // Get the window class name
                char[] className = new char[33];

                int length = Win32.GetClassName(pWnd, className, 32);

                string s = new string(className, 0, length);
                //----------------------------

                if (s == "msctls_updown32")
                {
                    bFound = true;

                    if (!bUpDown)
                    {
                        //----------------------------
                        // Subclass it
                        this.scUpDown = new SubClass(pWnd, true);
                        this.scUpDown.SubClassedWndProc += new SubClass.SubClassWndProcEventHandler(scUpDown_SubClassedWndProc);
                        //----------------------------

                        bUpDown = true;
                    }
                    break;
                }

                pWnd = Win32.GetWindow(pWnd, Win32.GW_HWNDNEXT);
            }

            if ((!bFound) && (bUpDown))
                bUpDown = false;
        }

        private void UpdateUpDown()
        {
            if (bUpDown)
            {
                if (Win32.IsWindowVisible(scUpDown.Handle))
                {
                    Rectangle rect = new Rectangle();

                    Win32.GetClientRect(scUpDown.Handle, ref rect);
                    Win32.InvalidateRect(scUpDown.Handle, ref rect, true);
                }
            }
        }

        #region scUpDown_SubClassedWndProc Event Handler

        private int scUpDown_SubClassedWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case Win32.WM_PAINT:
                    {
                        //------------------------
                        // redraw
                        IntPtr hDC = Win32.GetWindowDC(scUpDown.Handle);
                        Graphics g = Graphics.FromHdc(hDC);

                        DrawIcons(g);

                        g.Dispose();
                        Win32.ReleaseDC(scUpDown.Handle, hDC);
                        //------------------------

                        // return 0 (processed)
                        m.Result = IntPtr.Zero;

                        //------------------------
                        // validate current rect
                        Rectangle rect = new Rectangle();

                        Win32.GetClientRect(scUpDown.Handle, ref rect);
                        Win32.ValidateRect(scUpDown.Handle, ref rect);
                        //------------------------
                    }
                    return 1;
            }

            return 0;
        }
        #endregion

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }


        #endregion

        #region Properties

        [Editor(typeof(TabpageExCollectionEditor), typeof(UITypeEditor))]
        public new TabPageCollection TabPages
        {
            get
            {
                return base.TabPages;
            }
        }

        new public TabAlignment Alignment
        {
            get { return base.Alignment; }
            set
            {
                TabAlignment ta = value;
                if ((ta != TabAlignment.Top) && (ta != TabAlignment.Bottom))
                    ta = TabAlignment.Top;

                base.Alignment = ta;
            }
        }

        [Browsable(false)]
        new public bool Multiline
        {
            get { return base.Multiline; }
            set { base.Multiline = false; }
        }

        [Browsable(true)]
        new public Color BackColor
        {
            get { return _backColor; }
            set { _backColor = value; this.Invalidate(); }
        }

        #endregion

        #region TabpageExCollectionEditor

        internal class TabpageExCollectionEditor : CollectionEditor
        {
            public TabpageExCollectionEditor(System.Type type) : base(type)
            {

            }

            protected override Type CreateCollectionItemType()
            {
                return typeof(TabPage);
            }
        }

        #endregion


        //************************************************
        //******         Drag and Drop Tabs       ********
        //************************************************
        #region Drag and Drop
        private void OnDrgDpMouseDown(object sender, MouseEventArgs e)
        {
            // store clicked tab
            TabControl tc = (TabControl)sender;
            int hover_index = this.DrgDpGetHoverTabIndex(tc);
            if (hover_index >= 0) { tc.Tag = tc.TabPages[hover_index]; }
        }
        private void OnDrgDpMouseUp(object sender, MouseEventArgs e)
        {
            // clear stored tab
            TabControl tc = (TabControl)sender;
            tc.Tag = null;
        }
        private void OnDrgDpMouseMove(object sender, MouseEventArgs e)
        {
            // mouse button down? tab was clicked?
            TabControl tc = (TabControl)sender;
            if ((e.Button != MouseButtons.Left) || (tc.Tag == null)) return;
            TabPage clickedTab = (TabPage)tc.Tag;
            int clicked_index = tc.TabPages.IndexOf(clickedTab);

            // start drag n drop
            tc.DoDragDrop(clickedTab, DragDropEffects.All);
        }
        private void OnDrgDpDragOver(object sender, DragEventArgs e)
        {
            TabControl tc = (TabControl)sender;

            // a tab is draged?
            //if (e.Data.GetData(typeof(TabPage)) == null) return;
            //TabPage dragTab = (TabPage)e.Data.GetData(typeof(TabPage));
            TabPage dragTab;

            if (e.Data.GetData(typeof(TabPage)) != null)
                dragTab = (TabPage)e.Data.GetData(typeof(TabPage));
            else if (e.Data.GetData(typeof(DocumentTab)) != null)
                dragTab = (DocumentTab)e.Data.GetData(typeof(DocumentTab));
            else
                dragTab = null;


            int dragTab_index = tc.TabPages.IndexOf(dragTab);

            // hover over a tab?
            int hoverTab_index = this.DrgDpGetHoverTabIndex(tc);
            if (hoverTab_index < 0) { e.Effect = DragDropEffects.None; return; }
            TabPage hoverTab = tc.TabPages[hoverTab_index];
            e.Effect = DragDropEffects.Move;

            // start of drag?
            if (dragTab == hoverTab) return;

            // swap dragTab & hoverTab - avoids toggeling
            Rectangle dragTabRect = tc.GetTabRect(dragTab_index);
            Rectangle hoverTabRect = tc.GetTabRect(hoverTab_index);

            if (dragTabRect.Width < hoverTabRect.Width)
            {
                Point tcLocation = tc.PointToScreen(tc.Location);

                if (dragTab_index < hoverTab_index)
                {
                    if ((e.X - tcLocation.X) > ((hoverTabRect.X + hoverTabRect.Width) - dragTabRect.Width))
                        this.DrgDpSwapTabPages(tc, dragTab, hoverTab);
                }
                else if (dragTab_index > hoverTab_index)
                {
                    if ((e.X - tcLocation.X) < (hoverTabRect.X + dragTabRect.Width))
                        this.DrgDpSwapTabPages(tc, dragTab, hoverTab);
                }
            }
            else this.DrgDpSwapTabPages(tc, dragTab, hoverTab);

            // select new pos of dragTab
            tc.SelectedIndex = tc.TabPages.IndexOf(dragTab);
        }

        private int DrgDpGetHoverTabIndex(TabControl tc)
        {
            for (int i = 0; i < tc.TabPages.Count; i++)
            {
                if (tc.GetTabRect(i).Contains(tc.PointToClient(Cursor.Position)))
                    return i;
            }

            return -1;
        }

        private void DrgDpSwapTabPages(TabControl tc, TabPage src, TabPage dst)
        {
            int index_src = tc.TabPages.IndexOf(src);
            int index_dst = tc.TabPages.IndexOf(dst);
            tc.TabPages[index_dst] = src;
            tc.TabPages[index_src] = dst;
            tc.Refresh();
        }
        #endregion
    }

    //#endregion
}

