using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Masivian.BinaryTreeAPI.Models;

namespace Masivian.BinaryTreeAPI.Service
{
    /// <summary>
    /// Clase que implementa la interface que arma el Arbol Binario
    /// </summary>
    public class ServiceBinTree : IServiceBinTree
    {
        public BinaryTree CreateTree(int nodes)
        {
            BinaryTree tree = new BinaryTree();
            tree = FillTree(nodes);
            CreateBinaryTree(ref tree);


            return tree;
        }

        private void CreateBinaryTree(ref BinaryTree tree)
        {
            if (tree.Nodes == null || tree.Nodes.Count == 0)
                return;

            int index = 0;
            int level = 0;
            //int brother = 0;
            Node father = new Node();
            Node SonLeft = new Node();
            Node SonRight = new Node();

            while (index < tree.Nodes.Count)
            {
                father = tree.Nodes[index];
                var index1 = index == 0 ? index + 1 : index + 2;
                var index2 = index == 0 ? index + 2 : index + 3;
                // verifico si es par
                if (index != 0 && (index % 2) == 0)
                {
                    index1++;
                    index2++;
                }
                if(level > 1)
                {
                    index1 += level;
                    index2 += level;
                }
                if (index1 < tree.Nodes.Count)
                    SonLeft = tree.Nodes[index1];
                else
                    SonLeft = new Node();

                if (index2 < tree.Nodes.Count)
                    SonRight = tree.Nodes[index2];
                else
                    SonRight = new Node();

                FillFather(ref father, SonLeft.Id != 0 ? SonLeft.Id : -1,
                                       SonRight.Id != 0 ? SonRight.Id : -1,
                                       level);
                if (index == 0)
                    father.IdFatherNode = -1;

                FillSonLeft(ref SonLeft, father.Id, -1, -1, level);
                FillSonRight(ref SonRight, father.Id, -1, -1, level);
                if ((index % 2) == 0)
                {
                    level++;
                }
                index++;
            }

        }

        private void FillSonRight(ref Node son, int fatherId, int sonLeftId, int sonRightId, int level)
        {
            son.IdLeftNode = sonLeftId;
            son.IdRightNode = sonRightId;
            son.IdFatherNode = fatherId;
            son.Level = level + 1;
        }

        private void FillSonLeft(ref Node sonLeft, int fatherId, int sonLeftId, int sonRightId, int level)
        {
            sonLeft.IdLeftNode = sonLeftId;
            sonLeft.IdRightNode = sonRightId;
            sonLeft.IdFatherNode = fatherId;
            sonLeft.Level = level + 1;
        }

        private Node FillFather(ref Node father, int sonLeft, int sonRight, int level)
        {
            father.IdLeftNode = sonLeft;
            father.IdRightNode = sonRight;
            return father;
        }

        private BinaryTree FillTree(int nodes)
        {
            BinaryTree tree = new BinaryTree()
            {
                Id = DateTime.UtcNow.Hour + DateTime.UtcNow.Minute
                        + DateTime.UtcNow.Second +
                        DateTime.UtcNow.Millisecond,
                Nodes = new List<Node>(),
                TotalNodes = nodes,
                TreeName = "Node "
            };
            // Inicializo la propiedad de lista generica

            for (int i = 0; i < nodes; i++)
            {
                tree.Nodes.Add(CreateNode(i));
            }
            return tree;
        }

        /// <summary>
        /// Crea un nodo basico en la coleccion de nodos del 
        /// Arbol binario
        /// </summary>
        /// <param name="i">El id a asignar al nodo y que hara parte de su nombre</param>
        /// <returns>Un objeto nodo</returns>
        private Node CreateNode(int i)
        {
            return new Node()
            {
                Id = i,
                NodeName = "Nodo: [" + i.ToString() + "]",
                IdFatherNode = 0,
                IdLeftNode = 0,
                IdRightNode = 0
            };
        }

        /// <summary>
        /// retorna el ancestro comun mas cercano 
        /// </summary>
        /// <param name="nodos">El numero de nodos del arbol</param>
        /// <param name="firstNode">Nodo inicial</param>
        /// <param name="secondNode">Nodo final</param>
        /// <returns></returns>
        public Node ReturnCloseAncest(int nodos, int firstNode, int secondNode)
        {
            BinaryTree tree = CreateTree( nodos);
            Node node1 = tree.Nodes.FirstOrDefault(n => n.Id == firstNode);
            Node node2 = tree.Nodes.FirstOrDefault(n => n.Id == secondNode);

            StringBuilder sbQuery = new StringBuilder();
            int father = node1.IdFatherNode;
            sbQuery.AppendLine(father.ToString());

            while (father != 0)
            {
                Node node = tree.Nodes.FirstOrDefault(n => n.Id == father);
                father = node.IdFatherNode;
                sbQuery.AppendLine(father.ToString());
            }
            string[] array1 = sbQuery.ToString().Split('\n');

            sbQuery = new StringBuilder();
            father = node2.IdFatherNode;
            sbQuery.AppendLine(father.ToString());
            string hallado = string.Empty;

            while (father != 0)
            {
                Node node = tree.Nodes.FirstOrDefault(n => n.Id == father);
                father = node.IdFatherNode;
                sbQuery.AppendLine(father.ToString());

                hallado = array1.FirstOrDefault(n => n.Trim() == father.ToString().Trim());
                if (hallado != "")
                    break;
            }

            string[] array2 = sbQuery.ToString().Split('\n');

            Node node3 = tree.Nodes.FirstOrDefault(n => n.Id == Convert.ToInt32(hallado));
            return node3;
        }
    }
}
