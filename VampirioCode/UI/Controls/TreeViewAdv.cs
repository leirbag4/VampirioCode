using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using VampirioCode.UI.Controls.TreeViewAdvance;
using VampirioCode.UI.VampGraphics;
using TreeNode = VampirioCode.UI.Controls.TreeViewAdvance.TreeNode;

namespace VampirioCode.UI.Controls
{
    public class TreeViewAdv : Control
    {
        public override Font Font
        {
            get { return _font; }
            set
            {
                if (value == null) 
                    throw new ArgumentNullException(nameof(value));
                
                _font = value;
                _nodeHeight = (int)VampirioGraphics.GetStringSize(_font, "A").Height;
                RecalcNodeTextsSize();

                Invalidate();
            }
        }

        private Font _font = new Font("Arial", 12);

        public TIcon CollapseIcon { get { return _collapseIcon; } }
        public TIcon Icon1 { get { return _icon0; } }
        public TIcon Icon2 { get { return _icon1; } }
        public int TextSpace { get; set; } = 0;
        public CollapseStyle NormalCollapseStyle { get; set; } = null;
        public CollapseStyle OverCollapseStyle { get; set; } = null;
        public Color LinesColor { get { return _linesColor; } set { _linesColor = value; _linesPenColor = new Pen(_linesColor); } }
        public int NodeHeight { get { return _nodeHeight; } set { _nodeHeight = value; Invalidate(); } }
        public int NodeIndent { get { return _nodeIndent; } set { _nodeIndent = value; Invalidate(); } }

        private ScrollBarAdv verticalScrollBar;
        private ScrollBarAdv horizontalScrollBar;

        private List<TreeNode> _rootNodes;
        private int _mouseX = -1;
        private int _mouseY = -1;
        private bool _mouseDown = false;

        private int _nodeHeight = 20;
        private int _nodeIndent = 20;

        private TIcon _collapseIcon;
        private TIcon _icon0;
        private TIcon _icon1;

        private Color _linesColor = Color.FromArgb(100, 100, 100);
        private Pen _linesPenColor = new Pen(Color.FromArgb(100, 100, 100));

        private List<TLine> _lines;

        public int ScrollX { get { return horizontalScrollBar.Value; } set { horizontalScrollBar.Value = value; } }
        public int ScrollY { get { return verticalScrollBar.Value; } set { verticalScrollBar.Value = value; } }

        public int ScrollBarSize { get { return _scrollBarSize; } set { _scrollBarSize = value; RecalcScrollbars(); } }

        private int HScroll { get { return horizontalScrollBar.Value; } }
        private int VScroll { get { return verticalScrollBar.Value; } }

        private int _scrollBarSize = 21;
        private Dictionary<int, Bitmap> _iconBitmaps;

        private const int HorizontalLineWidth = 10;

        public TreeViewAdv()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // ------------- Icons ---------------
            _iconBitmaps =  new Dictionary<int, Bitmap>();
            _collapseIcon = new TIcon(12, 12, 0, true);
            _icon0 =        new TIcon(14, 14, 5, false);
            _icon1 =        new TIcon(14, 14, 5, false);
            TextSpace =     5;

            // ------------- Lines ---------------
            _lines = new List<TLine>();

            // ------------- Design --------------
            this.Width = 200;
            this.Height = 200;
            BackColor = Color.FromArgb(60, 60, 60);
            verticalScrollBar = new ScrollBarAdv();
            verticalScrollBar.Orientation = ScrollBarAdvance.ScrollBarOrientation.Vertical;

            horizontalScrollBar = new ScrollBarAdv();
            horizontalScrollBar.Orientation = ScrollBarAdvance.ScrollBarOrientation.Horizontal;

            horizontalScrollBar.Scroll +=   OnHorizontalScroll;
            verticalScrollBar.Scroll +=     OnVerticalScroll;

            RecalcScrollbars();

            // ------------- Styles --------------
            NormalCollapseStyle =   new CollapseStyle(Color.FromArgb(133, 133, 133), Color.FromArgb(60, 60, 60), Color.FromArgb(60, 60, 60));
            OverCollapseStyle =     new CollapseStyle(Color.FromArgb(160, 160, 160), Color.FromArgb(60, 60, 60), Color.FromArgb(60, 60, 60));

            this.Controls.Add(verticalScrollBar);
            this.Controls.Add(horizontalScrollBar);

            // ------------ Logic -----------------
            _rootNodes = new List<TreeNode>();

        }

        private void OnHorizontalScroll(int newValue, int oldValue)
        {
            Invalidate();
        }

        private void OnVerticalScroll(int newValue, int oldValue)
        {
            Invalidate();
        }


        public void AddNode(TreeNode node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node), "Node can't be null.");

            if (node.Parent != null)
                throw new InvalidOperationException("Root nodes can only be added to a TreeView.");

            TraverseSetTreeView(node, this);//node.SetTreeView(this);

            _rootNodes.Add(node);
        }

        public List<TreeNode> GetRootNodes()
        {
            return _rootNodes;
        }

        public void AddIconImage(int key, Bitmap image)
        {
            if(!_iconBitmaps.ContainsKey(key))
                _iconBitmaps.Add(key, image);
        }

        public void RemoveIconImage(int key)
        {
            if (_iconBitmaps.ContainsKey(key))
                _iconBitmaps.Remove(key);
        }

        public Bitmap GetIconImage(int key)
        {
            return _iconBitmaps[key];
        }

        private void TraverseGetAllNodes(TreeNode node, ref List<TreeNode> nodes)
        {
            nodes.Add(node);

            if (node.IsExpanded)
            {
                foreach (var child in node.Children)
                {
                    TraverseGetAllNodes(child, ref nodes);
                }
            }
        }

        public List<TreeNode> GetAllNodes()
        {
            List<TreeNode> nodes = new List<TreeNode>();
            
            foreach(var node in _rootNodes)
                TraverseGetAllNodes(node, ref nodes);

            return nodes;
        }

        public void PrintTree()
        {
            foreach (var rootNode in _rootNodes)
            {
                PrintNode(rootNode, 0);
            }
        }

        private void PrintNode(TreeNode node, int indent)
        {
            XConsole.Println(new string(' ', indent * 2) + node.Text);
            foreach (var child in node.Children)
            {
                PrintNode(child, indent + 1);
            }
        }

        private void RecalcScrollbars()
        { 
            verticalScrollBar.Width =       ScrollBarSize;
            verticalScrollBar.Height =      this.Height - _scrollBarSize;
            verticalScrollBar.Location =    new Point(this.Width - verticalScrollBar.Width, 0);
            verticalScrollBar.Anchor =      AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;

            horizontalScrollBar.Height =    ScrollBarSize;
            horizontalScrollBar.Width =     this.Width - _scrollBarSize;
            horizontalScrollBar.Location =  new Point(0, this.Height - horizontalScrollBar.Height);
            horizontalScrollBar.Anchor =    AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        }

        private void TraverseSetTreeView(TreeNode node, TreeViewAdv treeView)
        {
            node.SetTreeView(treeView);

            foreach (var child in node.Children)
            {
                TraverseSetTreeView(child, treeView);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            /*CheckExpandCollapse(e.Location);
            Invalidate(); // Redibuja el árbol
            XConsole.Println("dale");*/

            _mouseX = e.X;
            _mouseY = e.Y;
            _mouseDown = true;

            MouseUpdate(_mouseX, _mouseY, _mouseDown);
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            _mouseX = e.X;
            _mouseY = e.Y;
            _mouseDown = false;
            
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            _mouseX = e.X;
            _mouseY = e.Y;
            _mouseDown = false;

            MouseUpdate(_mouseX, _mouseY, _mouseDown);
            Invalidate();
        }


        private void TraverseMouseUpdate(TreeNode node, int mouseX, int mouseY, bool click)
        {
            if (node.gnode.IsOverCollapse(mouseX, mouseY))
            {
                if (click)
                {
                    node.ToggleCollapse();
                    UpdateNodes();
                    return;
                }
                else
                {
                    node.gnode.SetOverState(true);
                }
            }
            else
            {
                node.gnode.SetOverState(false);
            }

            if (node.IsExpanded)
            {
                foreach (var child in node.Children)
                {
                    TraverseMouseUpdate(child, mouseX, mouseY, click);
                }
            }
        }

        private void MouseUpdate(int mouseX, int mouseY, bool click)
        {
            foreach (var rootNode in _rootNodes)
            {
                TraverseMouseUpdate(rootNode, mouseX, mouseY, click);
            }
        }

        private void TraverseRecalcNodesTextSize(TreeNode node)
        {
            node.gnode.RecalcTextSize(true);

            foreach (var child in node.Children)
            {
                TraverseRecalcNodesTextSize(child);
            }
        }

        private void RecalcNodeTextsSize()
        {

            foreach (var rootNode in _rootNodes)
            {
                TraverseRecalcNodesTextSize(rootNode);
            }

        }

        private void PaintLines(Graphics g)
        {
            foreach (TLine line in _lines)
                line.Paint(g, _linesPenColor);
        }

        private void TraverseUpdate(TreeNode node, int xIndent, ref int y)
        {
            node.gnode.SetPos(xIndent - HScroll, y - VScroll);

            // Calculate Horizontal Line [----]
            if (node.Parent != null)
            {
                TLine line = new TLine();
                line.X =  node.gnode.GetCollapseRect().CenterX;
                line.Y =  node.gnode.GetCollapseRect().CenterY;
                line.X2 = line.X + HorizontalLineWidth;
                line.Y2 = line.Y;
                _lines.Add(line);
            }

            y += NodeHeight;

            TreeNode prevChild = null;

            if (node.IsExpanded)
            {
                foreach (var child in node.Children)
                {
                    if ((prevChild != null))
                    {
                        TLine line = new TLine();

                        line.X =    prevChild.gnode.GetCollapseRect().CenterX;
                        line.Y =    prevChild.gnode.GetCollapseRect().CenterY;
                        line.X2 =   line.X;
                        line.Y2 =   child.gnode.LocalY + (NodeHeight >> 1);

                        _lines.Add(line);
                    }
                    else
                    {
                        TLine line = new TLine();
                        line.X =    child.gnode.GetCollapseRect().CenterX;
                        line.Y =    child.Parent.gnode.GetCollapseRect().CenterY + (NodeHeight >> 1);
                        line.X2 =   line.X;
                        line.Y2 =   child.gnode.LocalY + (NodeHeight >> 1);
                        _lines.Add(line);
                    }

                    prevChild = child;
                    TraverseUpdate(child, xIndent + NodeIndent, ref y);
                }
            }
        }

        private void UpdateNodes()
        {
            int y = 0;

            _lines = new List<TLine>();

            foreach (var rootNode in _rootNodes)
            {
                TraverseUpdate(rootNode, NodeIndent, ref y);
            }

        }

        private void TraverseNodesPaint(Graphics g, TreeNode node)
        {
            node.Paint(g);

            if (node.IsExpanded)
            {
                foreach (var child in node.Children)
                {
                    TraverseNodesPaint(g, child);
                }
            }
        }

        private void PaintNodes(Graphics g)
        {

            foreach (var rootNode in _rootNodes)
            {
                TraverseNodesPaint(g, rootNode);
            }

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            VampirioGraphics.FillRect(g, Color.FromArgb(80, 80, 50), 0, 0, Width, Height);

            UpdateNodes();
            PaintNodes(g);
            PaintLines(g);
        }
    }
}
