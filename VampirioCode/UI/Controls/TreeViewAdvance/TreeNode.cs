using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.TreeViewAdvance
{
    using System;
    using System.Collections.Generic;

    public class TreeNode
    {
        public string Text { get { return _ttext.Text; } set { _text = value; _ttext.Text = value; OnTextChanged(value, _ttext); } }
        public TreeNode Parent { get; private set; }
        public List<TreeNode> Children { get; private set; }
        public int Level => Parent == null ? 0 : Parent.Level + 1;
        public bool Selected { get { return _selected; } set { _selected = value; if(_selected) treeView.TriggerSelected(this); } }

        //public Font Font { get { return _font; } set { _font = value; gnode.RecalcTextSize(true); /*gnode.Refresh();*/ } }
        public Font Font
        {
            get => _font;
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                    _font = value;
               
                gnode.RecalcTextSize(true);
            }
        }


        // Has [-] or [+] ???
        public bool IsExpandible { get { return Children.Count > 0; } }

        // [-] = true, [+] = false
        public bool IsExpanded { get; set; } = false;

        //public TIcon CollapseIcon { get { return gnode.CollapseIcon; } }
        //public TIcon Icon1 { get{ return gnode.Icon1; } }
        //public TIcon Icon2 { get{ return gnode.Icon2; } }


        public GNode gnode;

        private TreeViewAdv treeView;
        private string _text = "";
        private TText _ttext = new TText();
        private Font _font = null;
        private bool _selected = false;

        public TreeNode(string text = "")
        {
            Parent = null; // By default, hasn't parent
            Children = new List<TreeNode>();

            // Graphic Node
            gnode = new GNode(this, _ttext);

            Text = text;
        }

        public void Add(TreeNode child)
        {
            if (child == null)
                throw new ArgumentNullException(nameof(child), "child node can't be null.");

            child.Parent = this;
            if(treeView != null)
                child.SetTreeView(treeView);
            Children.Add(child);
        }

        public void SetTreeView(TreeViewAdv treeView)
        {
            this.treeView = treeView;
            this.gnode.SetTreeView(treeView);
        }

        public void Expand()
        { 
            this.IsExpanded = true;
        }

        public void Collapse()
        {
            this.IsExpanded = false;
        }

        public void ToggleCollapse()
        {
            this.IsExpanded = !this.IsExpanded;
        }

        public void SetCollapseImage(int key, SelectionType selectionType = SelectionType.Both)
        {
            if (selectionType == SelectionType.Both)
            {
                gnode.collapseIconKey = key;
                gnode.collapseIconSelectedKey = key;
            }
            else if (selectionType == SelectionType.Normal)
                gnode.collapseIconKey = key;
            else if(selectionType == SelectionType.Selected)
                gnode.collapseIconSelectedKey = key;
        }

        public void SetIcon1Image(int key, SelectionType selectionType = SelectionType.Both)
        {
            if (selectionType == SelectionType.Both)
            {
                gnode.icon1Key = key;
                gnode.icon1SelectedKey = key;
            }
            else if (selectionType == SelectionType.Normal)
                gnode.icon1SelectedKey = key;
            else if(selectionType == SelectionType.Selected)
                gnode.icon1SelectedKey = key;
        }

        public void SetIcon2Image(int key, SelectionType selectionType = SelectionType.Both)
        {
            if (selectionType == SelectionType.Both)
            {
                gnode.icon2Key = key;
                gnode.icon2SelectedKey = key;
            }
            else if (selectionType == SelectionType.Normal)
                gnode.icon2SelectedKey = key;
            else if(selectionType == SelectionType.Selected)
                gnode.icon2SelectedKey = key;
        }

        public void RemoveCollapseImage()
        {
            gnode.collapseIconKey = -1;
            gnode.collapseIconSelectedKey = -1;
        }

        public void RemoveIcon1Image()
        {
            gnode.icon1Key = -1;
            gnode.icon1SelectedKey = -1;
        }

        public void RemoveIcon2Image()
        {
            gnode.icon2Key = -1;
            gnode.icon2SelectedKey = -1;
        }

        // events
        private void OnTextChanged(string text, TText ttext)
        {
            gnode.OnTextChanged(text, ttext);
        }

        // paint
        public void Paint(Graphics g)
        {
            gnode.Paint(g);
        }

        public override string ToString()
        {
            return Text;
        }
    }

}
