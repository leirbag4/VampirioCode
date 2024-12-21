using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.TreeViewAdvance
{
    public class TreeViewTester
    {
        public static TreeViewAdv treeView;

        public TreeViewTester() 
        {
            
        }

        public static void Create()
        {
            // Crear nodos
            TreeNode node0 = new TreeNode("Node 0");
            TreeNode node1 = new TreeNode("Node 1");
            TreeNode node2 = new TreeNode("Node 2");

            TreeNode nodeB0 = new TreeNode("Node B0");
            TreeNode nodeB1 = new TreeNode("Node B1");

            node0.SetCollapseImage(0);

            // Establecer relaciones
            node0.Add(node1);
            node1.Add(node2);

            nodeB0.Add(nodeB1);

            // Crear TreeView y agregar el nodo raíz
            TreeViewAdv treeView = new TreeViewAdv();

            treeView.AddIconImage(0, Properties.Resources.play_icon);
            treeView.AddIconImage(1, Properties.Resources.mini_arrow_down_style_b);

            treeView.AddNode(node0);
            treeView.AddNode(nodeB0);

            treeView.AddIconImage(0, Properties.Resources.play_icon);
            treeView.AddIconImage(1, Properties.Resources.mini_arrow_down_style_b);

            node0.SetCollapseImage(0);


            // Imprimir el árbol
            treeView.PrintTree();

            // Acceder al padre de un nodo
            XConsole.Println($"El padre de {node2.Text} es {node2.Parent.Text}");
        }

    }
}
