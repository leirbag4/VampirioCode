using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampirioCode.UI.Controls;
using VampirioCode.UI.Controls.TreeViewAdvance;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TreeNode = VampirioCode.UI.Controls.TreeViewAdvance.TreeNode;

namespace VampirioCode.UI
{
    public partial class JSonViewer : VampirioForm
    {
        public JSonViewer()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            input.Text = @"{
""employees"":[
  {""firstName"":""John"", ""lastName"":""Doe""},
  {""firstName"":""Anna"", ""lastName"":""Smith""},
  {""firstName"":""Peter"", ""lastName"":""Jones""}
]
}";
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
}"
            ;*/

            treeViewAdv.PopulateFromJson(json);

            return;

            JsonNode jsonNode = JsonNode.Parse(json);
            //treeViewAdv.Nodes.Clear();
            //System.Windows.Forms.TreeNode rootNode = new System.Windows.Forms.TreeNode("JSON Root");
            TreeNode rootNode = new TreeNode("root");
            //treeViewAdv.Nodes.Add(rootNode);
            treeViewAdv.AddNode(rootNode);

            //PopulateTreeView(jsonNode, rootNode);



            JsonTreeNode jsonTreeNode = new JsonTreeNode() { Text = "info : true" };
            JsonTreeNode jsonTreeNode2 = new JsonTreeNode() { Text = "value : 123" };
            JsonTreeNode jsonTreeNode3 = new JsonTreeNode() { Text = "data : \"config\"" };
            JsonTreeNode jsonTreeNode4 = new JsonTreeNode() { Text = "bin : null" };

            treeViewAdv.AddNode(jsonTreeNode);
            treeViewAdv.AddNode(jsonTreeNode2);
            treeViewAdv.AddNode(jsonTreeNode3);
            treeViewAdv.AddNode(jsonTreeNode4);

            //treeView.ExpandAll();

        }

        private void PopulateTreeView(JsonNode jsonNode, TreeNode treeNode)
        {
            if (jsonNode is JsonObject jsonObject)
            {
                foreach (var property in jsonObject)
                {
                    // Si el valor es primitivo, se agrega directamente al nodo padre.
                    if (property.Value is JsonValue jsonValue && jsonValue.TryGetValue(out object value))
                    {
                        //treeNode.Children.Add(new System.Windows.Forms.TreeNode($"{property.Key}: {value}"));
                        //treeNode.Children.Add(new System.Windows.Forms.TreeNode($"{property.Key}: {value}"));
                        treeNode.Add($"{property.Key}: {value}");
                    }
                    else
                    {
                        //System.Windows.Forms.TreeNode childNode = new System.Windows.Forms.TreeNode(property.Key);
                        //treeNode.Nodes.Add(childNode);
                        //PopulateTreeView(property.Value, childNode);
                        TreeNode node = new TreeNode(property.Key);
                        if (treeNode.Parent == null)
                        {
                            treeViewAdv.AddNode(node);
                        }
                        else
                        {
                            treeNode.Add(node);
                        }
                    }
                }
            }
            else if (jsonNode is JsonArray jsonArray)
            {
                for (int i = 0; i < jsonArray.Count; i++)
                {
                    //System.Windows.Forms.TreeNode childNode = new System.Windows.Forms.TreeNode($"[{i}]");
                    //treeNode.Nodes.Add(childNode);
                    //PopulateTreeView(jsonArray[i], childNode);

                    TreeNode childNode = new TreeNode($"[{i}]");
                    if (childNode.Parent == null)
                    {
                        treeViewAdv.AddNode(childNode);
                    }
                    else
                    {
                        treeNode.Add(childNode);
                    }

                    PopulateTreeView(jsonArray[i], childNode);
                }
            }
            else if (jsonNode is JsonValue jsonValue)
            {
                // treeNode.Nodes.Add(new System.Windows.Forms.TreeNode(jsonValue.ToString()));
                TreeNode node = new TreeNode(jsonValue.ToString());
                if (treeNode.Parent == null)
                {
                    treeViewAdv.AddNode(node);
                }
                else
                {
                    treeNode.Add(node);
                }
            }
        }

        private void OnConvertPressed(object sender, EventArgs e)
        {
            treeViewAdv.ClearNodes();
            _showJson(input.Text);
        }

        private void OnBeautifyPressed(object sender, EventArgs e)
        {
            string jsonInput = input.Text;

            var jsonElement = JsonSerializer.Deserialize<JsonElement>(jsonInput);
            string formattedJson = JsonSerializer.Serialize(jsonElement, new JsonSerializerOptions
            {
                WriteIndented = true // Opción para indentar
            });

            input.Text = formattedJson;
        }

        private void OnTreeViewToJsonPressed(object sender, EventArgs e)
        {
            input.Text = treeViewAdv.ToJson();
        }
    }
}
