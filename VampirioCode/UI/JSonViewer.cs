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
        private static List<JSonViewer> viewers = new List<JSonViewer>();

        public JSonViewer()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.AllowDrop = true;

            this.DragEnter += OnDragEnter;
            this.DragDrop += OnDragAndDrop;

            /*input.Text = @"{
""employees"":[
  {""firstName"":""John"", ""lastName"":""Doe""},
  {""firstName"":""Anna"", ""lastName"":""Smith""},
  {""firstName"":""Peter"", ""lastName"":""Jones""}
]
}";*/
        }

        private void OnDragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void OnDragAndDrop(object? sender, DragEventArgs e)
        {
            XConsole.Println("drop");
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length > 0)
            {
                string json = File.ReadAllText(files[0]);
                input.Text = json;
                OnBeautifyPressed(null, EventArgs.Empty);
                treeViewAdv.FillFromJson(json);
            }
        }

        public static JSonViewer ShowJson(string json)
        {
            JSonViewer viewer = new JSonViewer();
            viewer._showJson(json, true);
            

            viewer.Show();
            return viewer;
        }

        public static JSonViewer Open()
        {
            JSonViewer viewer = new JSonViewer();
            viewer.Show();
            return viewer;
        }

        public static void CloseAll()
        {
            foreach(var viewer in viewers)
                viewer.Close();

            viewers.Clear();
        }

        private void _showJson(string json, bool copyToInput = false)
        {
            treeViewAdv.FillFromJson(json);

            if (copyToInput)
            {
                input.Text = json;
                Beautify();
            }
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

        private void Beautify()
        {
            string jsonInput = input.Text;

            var jsonElement = JsonSerializer.Deserialize<JsonElement>(jsonInput);
            string formattedJson = JsonSerializer.Serialize(jsonElement, new JsonSerializerOptions
            {
                WriteIndented = true // Opción para indentar
            });

            input.Text = formattedJson;
        }

        private void OnConvertPressed(object sender, EventArgs e)
        {
            if (input.Text.Trim() == "")
                return;
            
            treeViewAdv.ClearNodes();
            _showJson(input.Text);
        }

        private void OnBeautifyPressed(object sender, EventArgs e)
        {
            Beautify();
        }

        private void OnTreeViewToJsonPressed(object sender, EventArgs e)
        {
            input.Text = treeViewAdv.ToJson();
        }

        private void OnExpandAllPressed(object sender, EventArgs e)
        {
            treeViewAdv.ExpandAll();
        }

    }
}
