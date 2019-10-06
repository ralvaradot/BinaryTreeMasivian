using System.Collections.Generic;

namespace Masivian.BinaryTreeAPI.Models
{
    /// <summary>
    /// Clase del Arbol Binario
    /// </summary>
    public class BinaryTree
    {
        /// <summary>
        /// Id del arbol
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// nombre del arbol
        /// </summary>
        public string TreeName { get; set; }
        /// <summary>
        /// Numero de Nodos
        /// </summary>
        public int TotalNodes { get; set; }
        /// <summary>
        /// Arbol de Nodos
        /// </summary>
        public List<Node> Nodes { get; set; }
    }
}
