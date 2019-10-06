using Masivian.BinaryTreeAPI.Models;

namespace Masivian.BinaryTreeAPI.Service
{
    /// <summary>
    /// Interface para poder inyectarla como dependencia desde Startup.cs
    /// </summary>
    public interface IServiceBinTree
    {
        BinaryTree CreateTree(int nodes);
        Node ReturnCloseAncest(int Tree, int firstNode, int secondNode);
    }
}
