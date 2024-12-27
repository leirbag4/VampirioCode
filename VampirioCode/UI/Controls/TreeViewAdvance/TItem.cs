using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.TreeViewAdvance
{
    public class TItem
    {
        public string Text { get; set; } = "";
        public bool IsEditing { get { return _editing; } }

        private TEditableTextBox textBox;
        private TreeNode node;
        private TreeViewAdv treeView;
        private bool _editing = false;

        public TItem()
        { 
        }

        public void StartEditing(TreeViewAdv treeView, TreeNode node)
        { 
            TRect rect = node.gnode.GetTextRect();

            this.treeView = treeView;
            this.node = node;

            textBox = new TEditableTextBox();
            textBox.EnterPressed += OnEnterPressed;
            textBox.Text = Text;
            //textBox.Font = node.gnode.Font;
            textBox.Font = new Font(node.gnode.Font.Name, node.gnode.Font.Size - 1f, node.gnode.Font.Style);
            textBox.Width = rect.Width;

            SetPos(node.gnode.GetTextRect().Left, node.gnode.GetTextRect().Top);

            treeView.Controls.Add(textBox);

            textBox.Focus();
            textBox.SelectAll();

            _editing = true;
        }

        public void SetPos(int x, int y)
        {
            textBox.Left = x;
            textBox.Top = y + 1;
        }

        private void OnEnterPressed(object sender, Events.KeyPressedEventArgs e)
        {
            XConsole.Println("enter");
            treeView.StopEditingNode();
        }

        public void StopEditing(TreeViewAdv treeView)
        {
            node.Text = textBox.Text;
            treeView.Controls.Remove(textBox);

            _editing = false;
        }
    }
}
