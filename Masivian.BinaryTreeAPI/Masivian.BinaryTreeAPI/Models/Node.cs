namespace Masivian.BinaryTreeAPI.Models
{
    /// <summary>
    /// Modelo que representa un Nodo del Arbol Binario
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Id del Nodo
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nombre del Nodo o Descripcion
        /// </summary>
        public string NodeName { get; set; }
        /// <summary>
        /// Id del Nodo padre. Cero si es el padre
        /// </summary>
        public int IdFatherNode { get; set; }
        /// <summary>
        /// Id Nodo derecho
        /// </summary>
        public int IdRightNode { get; set; }
        /// <summary>
        /// Id Nodo  Derecho
        /// </summary>
        public int IdLeftNode { get; set; }
    }
}
