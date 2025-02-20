﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.TreeViewAdvance
{
    using System;
    using System.Collections.Generic;
    using VampirioCode.UI.VampGraphics;

    public class TreeNode
    {
        public string Text { get { return _titem.Text; } set { _text = value; _titem.Text = value; OnTextChanged(value, _titem); } }
        public TreeNode Parent { get; private set; }
        public List<TreeNode> Children { get; private set; }
        public int Level => Parent == null ? 0 : Parent.Level + 1;
        public bool Selected { get { return _selected; } set { _selected = value; if(_selected) treeView.TriggerSelected(this); } }
        public TItem TItem { get { return _titem; } }

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
        private TItem _titem = new TItem();
        private Font _font = null;
        private bool _selected = false;

        public TreeNode(string text = "")
        {
            Parent = null; // By default, hasn't parent
            Children = new List<TreeNode>();

            // Graphic Node
            gnode = new GNode(this, _titem);

            Text = text;
        }

        public TreeNode Add(string text)
        {
            TreeNode node = new TreeNode(text);
            Add(node);
            return node;
        }

        public TreeNode Add(TreeNode child)
        {
            if (child == null)
                throw new ArgumentNullException(nameof(child), "child node can't be null.");

            child.Parent = this;
            if(treeView != null)
                child.SetTreeView(treeView);
            Children.Add(child);

            // event
            if(treeView != null)
                treeView.TriggerNodeAdded(child);

            return child;
        }

        public void Remove(TreeNode child)
        {
            if (child == null)
                throw new ArgumentNullException(nameof(child), "child node can't be null.");

            Children.Remove(child);

            // event
            if (treeView != null)
                treeView.TriggerNodeRemoved(child);
        }

        public void SetTreeView(TreeViewAdv treeView)
        {
            this.treeView = treeView;
            this.gnode.SetTreeView(treeView);
        }

        public void Expand()
        { 
            this.IsExpanded = true;
            RefreshTreeView();

            // event
            if (treeView != null)
                treeView.TriggerNodeExpanded(this, true);
        }

        public void Collapse()
        {
            this.IsExpanded = false;
            RefreshTreeView();

            // event
            if(treeView != null)
                treeView.TriggerNodeCollapsed(this, true);
        }

        private void TraverseExpandAll(TreeNode node)
        {
            node.IsExpanded = true;

            if(treeView != null)
                treeView.TriggerNodeExpanded(node);

            foreach (var child in node.Children)
            {
                TraverseExpandAll(child);
            }
        }

        public void ExpandAll()
        {
            TraverseExpandAll(this);

            // event
            if (treeView != null)
                treeView.RefreshScrollBars(true);
        }

        private void TraverseCollapseAll(TreeNode node)
        {
            node.IsExpanded = false;

            if (treeView != null)
                treeView.TriggerNodeCollapsed(node);

            foreach (var child in node.Children)
            {
                TraverseCollapseAll(child);
            }
        }

        public void CollapseAll()
        {
            TraverseCollapseAll(this);

            // event
            if (treeView != null)
                treeView.RefreshScrollBars(true);
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
        private void OnTextChanged(string text, TItem titem)
        {
            gnode.OnTextChanged(text, titem);
        }

        private void RefreshTreeView()
        {
            if (treeView != null)
                treeView.RefreshAll();
        }

        // paint
        public void Paint(Graphics g)
        {
            //TRect rect =    gnode.GetTextRect();
            //Font font =     gnode.GetFont();
            //String text =   Text;
            
            gnode.Paint(g);
        }

        public virtual void OnTextPaint(Graphics g, Font font, TRect rect, string text)
        {
            VampirioGraphics.DrawString(g, font, Text, Color.Silver, rect.X, rect.Y);
        }

        public override string ToString()
        {
            return Text;
        }
    }

}
