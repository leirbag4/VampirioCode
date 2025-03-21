﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampirioCode.UI;
using VampirioCode.UI.Controls;
using VampirioCode.UI.Controls.TreeViewAdvance;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace VampirioCode.Tests
{
    public partial class TreeViewTester : Form
    {
        private UI.Controls.TreeViewAdvance.TreeNode storedNode = null;


        public TreeViewTester()
        {
            InitializeComponent();
        }

        public static TreeViewTester ShowJson(string json)
        {
            TreeViewTester viewer = new TreeViewTester();
            viewer._showJson(json);
            //viewer.Show();

            viewer.ShowDialog();
            return viewer;
        }

        private void _showJson(string json)
        {
            /*json = @"{
  ""root"": {
    ""test A0"": {
      ""test A1"": null,
      ""test A2"": null
    },
    ""test B0"": {
      ""test B1"": {
        ""test D0 capo"": null
      },
      ""test B2"": null,
      ""test B3"": null
    }
  },
  ""root2"": {
    ""test C0"": ""null"",
    ""test C1"": ""null"",
    ""test C2"": ""null"",
    ""test C3"": {
      ""test F0"": null
    }
  }
}";*/

            string globalJSON2 = @"{
  ""root"": {
    ""test A0"": {
      ""test A1"": null,
      ""test A2"": false,
      ""name"" : ""this is a testing device for every time you open this, ok?""
    },
    ""names"": [""Juan"", ""Ana"", ""Luis""],
    ""products"": [
      { ""id"": 1, ""name"": ""Laptop"", ""price"": 1200 },
      { ""id"": 2, ""name"": ""Mouse"", ""price"": 20 },
      { ""id"": 3, ""name"": ""Keyobard"", ""price"": 25.45 }
    ],
    ""test B0"": {
      ""test B1"": {
        ""test D0 capo"": true,
        ""long string"" : ""ultra long string to test the code, the device and all any kind of bug""
      },
      ""test B2"": null,
      ""test B3"": null
    }
  },
  ""root2"": {
    ""test C0"": null,
    ""test C1"": null,
    ""test C2"": null,
    ""test C3"": {
      ""test F0"": null
    },
    ""number"":34
  }
}
";

        // clear tree view
        treeView.Nodes.Clear();

            // create the nodes
            //JsonNode jsonNode = JsonNode.Parse(json);
            JsonNode jsonNode = JsonNode.Parse(globalJSON2);
            treeView.Nodes.Clear();
            System.Windows.Forms.TreeNode rootNode = new System.Windows.Forms.TreeNode("JSON Root");
            treeView.Nodes.Add(rootNode);

            ImageList imgList = new ImageList();
            imgList.Images.Add("iconA", Properties.Resources.dialog_error_info_med);
            imgList.Images.Add("iconB", Properties.Resources.dialog_question_med);
            imgList.Images.Add("iconC", Properties.Resources.mmenu_mini_copy_path);
            imgList.Images.Add("iconD", Properties.Resources.mmenu_mini_find);

            //treeView.ImageList = imgList;

            /*var node01 = new System.Windows.Forms.TreeNode("A");
            var node02 = new System.Windows.Forms.TreeNode("B");
            var node03 = new System.Windows.Forms.TreeNode("C");
            var node04 = new System.Windows.Forms.TreeNode("D");
            var node05 = new System.Windows.Forms.TreeNode("E");

            //node01.ImageKey = "iconA"; node01.SelectedImageKey = "iconA";
            //node02.ImageKey = "iconB"; node02.SelectedImageKey = "iconC";
            //node03.ImageKey = "iconC"; node03.SelectedImageKey = "iconB";
            //node04.ImageKey = "iconD"; node04.SelectedImageKey = "iconD";

            treeView.Nodes.Add(node01);
            node01.Nodes.Add(node02);
            node02.Nodes.Add(node03);
            node03.Nodes.Add(node04);
            node04.Nodes.Add(node05);

            node01.Text += node01.Level;
            node02.Text += node02.Level;
            node03.Text += node03.Level;
            node04.Text += node04.Level;
            node05.Text += node05.Level;*/


            PopulateTreeView(jsonNode, rootNode);
            treeView.ExpandAll();

            // ---------------------------------------


            // ---------------------------------------
            // ---------------------------------------
            // ---------------------------------------
            DEBUG_TREE_VIEW_ADV();
        }

        private void DEBUG_TREE_VIEW_ADV()
        {
            //TreeViewTester.Create();

            treeViewAdv.AddIconImage(0, Properties.Resources.mmenu_mini_add);
            treeViewAdv.AddIconImage(1, Properties.Resources.mmenu_mini_find);
            treeViewAdv.AddIconImage(2, Properties.Resources.mmenu_mini_copy_path);
            treeViewAdv.AddIconImage(3, Properties.Resources.mmenu_mini_sub);

            var rootNode = CreateNode("root");
            var rootNode2 = CreateNode("root2");
            var rootNode3 = CreateNode("root3");

            var nodeA0 = CreateNode("test A0 longer than anything to test");
            var nodeA1 = CreateNode("test A1 too much longer to test where to go now, for a smaller text yes yes");
            var nodeA2 = CreateNode("test A2");

            var nodeB0 = CreateNode("test B0");
            var nodeB1 = CreateNode("test B1");
            var nodeB2 = CreateNode("test B2");
            var nodeB3 = CreateNode("test B3");

            var nodeC0 = CreateNode("test C0 private void TraverseUpdate(TreeNode node, int xIndent, ref int y) private void updateNow");
            var nodeC1 = CreateNode("test C1");
            var nodeC2 = CreateNode("test C2");
            var nodeC3 = CreateNode("test C3");

            var nodeD0 = CreateNode("test D0 capo");

            var nodeF0 = CreateNode("test F0");


            rootNode.SetCollapseImage(0);
            rootNode.SetCollapseImage(3, SelectionType.Selected);
            nodeA0.SetIcon1Image(2);
            nodeA0.SetIcon2Image(1);

            nodeA0.Font = new Font("Verdana", 15, FontStyle.Bold);

            nodeA0.Add(nodeA1);
            nodeA0.Add(nodeA2);

            nodeB0.Add(nodeB1);
            nodeB0.Add(nodeB2);
            nodeB0.Add(nodeB3);

            nodeB1.Add(nodeD0);

            nodeC3.Add(nodeF0);

            rootNode2.Add(nodeC0);
            rootNode2.Add(nodeC1);
            rootNode2.Add(nodeC2);
            rootNode2.Add(nodeC3);


            rootNode.Add(nodeA0);
            rootNode.Add(nodeB0);

            treeViewAdv.AddNode(rootNode);
            treeViewAdv.AddNode(rootNode2);
            treeViewAdv.AddNode(rootNode3);

            treeViewAdv.NodeHeight = 30;
            treeViewAdv.Icon1.PositionMode = PositionMode.ScaledCentered;
            treeViewAdv.Icon1.Width = 50;
            treeViewAdv.Icon1.IconOffsetScale = 0.75f;
            //treeViewAdv.Icon1.PositionMode = PositionMode.ScaledCentered;
            //treeViewAdv.Icon1.IconOffsetY = 10;

            //treeViewAdv.CollapseIcon.Width = 8;
            //treeViewAdv.CollapseIcon.Height = 8;

            // treeViewAdv.Icon1.Active = true;
            // treeViewAdv.Icon2.Active = true;

            //treeViewAdv.AddNode(rootNode);

            treeViewAdv.RefreshAll();

            treeViewAdv.SelectedNode += SelectedNode;
            treeViewAdv.NodeTextChanged += NodeTextChanged;
            treeViewAdv.NodeAdded += OnNodeAdded;
            treeViewAdv.NodeRemoved += NodeRemoved;
            treeViewAdv.NodeExpanded += NodeExpanded;
            treeViewAdv.NodeCollapsed += NodeCollapsed;

            VampirioCode.UI.XConsole.Println("font name: " + treeViewAdv.Font.Name);
        }

        private void NodeTextChanged(UI.Controls.TreeViewAdvance.TreeNode node)
        {
            XConsole.PrintWarning("node_text_changed: " + node.Text);
        }

        private void SelectedNode(UI.Controls.TreeViewAdvance.TreeNode node)
        {
            XConsole.PrintWarning("selected_node: " + node.Text);
        }

        private void NodeCollapsed(UI.Controls.TreeViewAdvance.TreeNode node)
        {
            XConsole.PrintWarning("node_collapsed: " + node.Text);
        }

        private void NodeExpanded(UI.Controls.TreeViewAdvance.TreeNode node)
        {
            XConsole.PrintWarning("node_expanded: " + node.Text);
        }

        private void NodeRemoved(UI.Controls.TreeViewAdvance.TreeNode node)
        {
            XConsole.PrintWarning("node_removed: " + node.Text);
        }

        private void OnNodeAdded(UI.Controls.TreeViewAdvance.TreeNode node)
        {
            XConsole.PrintWarning("node_added: " + node.Text);
        }

        private VampirioCode.UI.Controls.TreeViewAdvance.TreeNode CreateNode(string text)
        {
            return new VampirioCode.UI.Controls.TreeViewAdvance.TreeNode(text);
        }

        private void PopulateTreeView(JsonNode jsonNode, System.Windows.Forms.TreeNode treeNode)
        {
            if (jsonNode is JsonObject jsonObject)
            {
                foreach (var property in jsonObject)
                {
                    // Si el valor es primitivo, se agrega directamente al nodo padre.
                    if (property.Value is JsonValue jsonValue && jsonValue.TryGetValue(out object value))
                    {
                        treeNode.Nodes.Add(new System.Windows.Forms.TreeNode($"{property.Key}: {value}"));
                    }
                    else
                    {
                        System.Windows.Forms.TreeNode childNode = new System.Windows.Forms.TreeNode(property.Key);
                        treeNode.Nodes.Add(childNode);
                        PopulateTreeView(property.Value, childNode);
                    }
                }
            }
            else if (jsonNode is JsonArray jsonArray)
            {
                for (int i = 0; i < jsonArray.Count; i++)
                {
                    System.Windows.Forms.TreeNode childNode = new System.Windows.Forms.TreeNode($"[{i}]");
                    treeNode.Nodes.Add(childNode);
                    PopulateTreeView(jsonArray[i], childNode);
                }
            }
            else if (jsonNode is JsonValue jsonValue)
            {
                treeNode.Nodes.Add(new System.Windows.Forms.TreeNode(jsonValue.ToString()));
            }
        }

        private void OnNodeHeightEnterPressed(object sender, VampirioCode.UI.Controls.Events.KeyPressedEventArgs e)
        {
            treeViewAdv.NodeHeight = nodeHeightInput.value;
        }

        private void OnNodeIndentEnterPressed(object sender, VampirioCode.UI.Controls.Events.KeyPressedEventArgs e)
        {
            treeViewAdv.NodeIndent = NodeIndentInput.value;
        }

        private void OnFontSizeEnterPressed(object sender, VampirioCode.UI.Controls.Events.KeyPressedEventArgs e)
        {
            treeViewAdv.Font = new Font(treeViewAdv.Font.Name, fontSizeInput.value);
        }

        private void OnIcon1CheckedChanged(object sender, EventArgs e)
        {
            bool check = icon1EnableCKBox.Checked;

            treeViewAdv.Icon1.Active = check;
            treeViewAdv.RefreshAll();
        }

        private void OnIcon2CheckedChanged(object sender, EventArgs e)
        {
            bool check = icon2EnableCKBox.Checked;

            treeViewAdv.Icon2.Active = check;
            treeViewAdv.RefreshAll();
        }

        private void OnInsertNodePressed(object sender, EventArgs e)
        {
            DialogResult result = VampirioCode.UI.InputMsgBox.Show(this, "New Node", "Node Name", "Create a new Node.\nSelect a name");

            if (result == DialogResult.OK)
            {
                string nodeName = VampirioCode.UI.InputMsgBox.InputText;

                VampirioCode.UI.XConsole.Println("node name: " + nodeName);
                VampirioCode.UI.XConsole.Println("sel: " + treeViewAdv.CurrSelectedNode);

                // Top root empty
                if (treeViewAdv.CurrSelectedNode == null)
                {
                    treeViewAdv.AddNode(CreateNode(nodeName));
                }
                else
                {
                    treeViewAdv.CurrSelectedNode.Add(CreateNode(nodeName));
                }
            }
        }

        private void OnDeleteNodePressed(object sender, EventArgs e)
        {
            var node = treeViewAdv.CurrSelectedNode;

            treeViewAdv.RemoveNode(node);
        }

        private void OnRefreshPressed(object sender, EventArgs e)
        {
            treeViewAdv.RefreshAll();
        }

        private void OnExpandPressed(object sender, EventArgs e)
        {
            treeViewAdv.CurrSelectedNode.Expand();
        }

        private void OnCollapsePressed(object sender, EventArgs e)
        {
            treeViewAdv.CurrSelectedNode.Collapse();
        }

        private void OnExpandTreePressed(object sender, EventArgs e)
        {
            treeViewAdv.CurrSelectedNode.ExpandAll();
        }

        private void OnCollapseTreePressed(object sender, EventArgs e)
        {
            treeViewAdv.CurrSelectedNode.CollapseAll();
        }

        private void OnExpandAllNodes(object sender, EventArgs e)
        {
            treeViewAdv.ExpandAll();
        }

        private void OnCollapseAllNodes(object sender, EventArgs e)
        {
            treeViewAdv.CollapseAll();
        }

        private void OnExpandPathPressed(object sender, EventArgs e)
        {
            treeViewAdv.ExpandPath(pathInput.Text, true);
        }

        private void OnCollapsePathPressed(object sender, EventArgs e)
        {
            treeViewAdv.CollapsePath(pathInput.Text);
        }

        private void OnStoreNodePressed(object sender, EventArgs e)
        {
            storedNode = treeViewAdv.CurrSelectedNode;
            storedInput.Text = storedNode.Text;
        }

        private void OnRestoreNodePressed(object sender, EventArgs e)
        {
            treeViewAdv.SelectNode(storedNode);
        }

        private void OnClassicPressed(object sender, EventArgs e)
        {
            string name = (sender as ButtonAdv).Name;
            VampirioCode.UI.XConsole.PrintWarning("n: " + name);

            var node = treeView.SelectedNode;
            //node.Text = "cambio";

            if (name == "insert_classic")
            {
                var result = VampirioCode.UI.InputMsgBox.Show(this, "New Node", "Node Name", "New Node Name?");

                if (result == DialogResult.OK)
                {
                    // No root node
                    if (node == null)
                    {
                        treeView.Nodes.Add(VampirioCode.UI.InputMsgBox.InputText);
                    }
                    // No parent
                    else //else if(newNode.Parent != null)
                    {
                        node.Nodes.Add(VampirioCode.UI.InputMsgBox.InputText);
                    }
                }
            }
            else if (name == "delete_classic")
            {
                treeView.Nodes.Remove(node);
            }
            else if (name == "expand_classic")
            {
                node.Expand();
            }
            else if (name == "collapse_classic")
            {

            }
            else if (name == "expand_tree_classic")
            {
                node.ExpandAll();
            }

        }


    }
}
