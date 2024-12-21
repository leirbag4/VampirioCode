using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampirioCode.UI.Controls;
using VampirioCode.UI.Controls.TreeViewAdvance;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VampirioCode.UI
{
    public partial class JSonViewer : Form
    {
        public JSonViewer()
        {
            InitializeComponent();
        }

        public static JSonViewer ShowJson(string json)
        {
            JSonViewer viewer = new JSonViewer();
            viewer._showJson(json);
            //viewer.Show();

            viewer.ShowDialog();
            return viewer;
        }

        private void _showJson(string json)
        {
            json = @"{
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
}";

            // clear tree view
            treeView.Nodes.Clear();

            // create the nodes
            JsonNode jsonNode = JsonNode.Parse(json);
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

            var nodeA0 = CreateNode("test A0");
            var nodeA1 = CreateNode("test A1");
            var nodeA2 = CreateNode("test A2");

            var nodeB0 = CreateNode("test B0");
            var nodeB1 = CreateNode("test B1");
            var nodeB2 = CreateNode("test B2");
            var nodeB3 = CreateNode("test B3");

            var nodeC0 = CreateNode("test C0");
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
            treeViewAdv.Invalidate();
        }

        private void OnIcon2CheckedChanged(object sender, EventArgs e)
        {
            bool check = icon2EnableCKBox.Checked;

            treeViewAdv.Icon2.Active = check;
            treeViewAdv.Invalidate();
        }
    }
}
