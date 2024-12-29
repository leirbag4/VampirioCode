using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.TreeViewAdvance
{
    public delegate void SelectedNodeEvent(TreeNode node);
    public delegate void NodeTextChangedEvent(TreeNode node);
    public delegate void NodeAddedEvent(TreeNode node);
    public delegate void NodeRemovedEvent(TreeNode node);
    public delegate void NodeExpandedEvent(TreeNode node);
    public delegate void NodeCollapsedEvent(TreeNode node);
}
