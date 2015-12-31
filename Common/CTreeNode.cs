using System.Collections.Generic;

namespace Common
{
    public class CTreeNode
    {
        /// <summary>
        ///     新建一个节点
        /// </summary>
        /// <param name="fullPath">用.连接的全路径</param>
        public CTreeNode(string fullPath)
        {
            Children = new List<CTreeNode>();
            Path = fullPath;
            if (fullPath.Equals(string.Empty))
            {
                IsRoot = true;
                Text = "<Root>";
            }
            else
            {
                var pathArray = fullPath.Split(".".ToCharArray());
                Text = pathArray[pathArray.Length - 1];
            }
        }

        public bool IsRoot { set; get; }

        /// <summary>
        ///     父节点
        /// </summary>
        public CTreeNode Parent { set; get; }

        /// <summary>
        ///     子节点
        /// </summary>
        public List<CTreeNode> Children { set; get; }

        /// <summary>
        ///     全路径
        /// </summary>
        public string Path { set; get; }

        /// <summary>
        ///     文本信息
        /// </summary>
        public string Text { set; get; }

        /// <summary>
        ///     Tag
        /// </summary>
        public object Tag { set; get; }

        /// <summary>
        ///     是否存在某个子节点
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public CTreeNode IsChildContains(string strKey)
        {
            foreach (var child in Children)
            {
                if (child.Text == strKey) return child;
            }
            return null;
        }

        /// <summary>
        ///     子节点挂载到Root节点
        /// </summary>
        /// <param name="root"></param>
        /// <param name="fullPath"></param>
        /// <param name="tag"></param>
        public static void AddToRootNode(CTreeNode root, string fullPath, object tag = null)
        {
            //分割路径
            var pathArray = fullPath.Split(".".ToCharArray());
            var searchNode = root;
            var newPath = string.Empty;
            for (var i = 0; i < pathArray.Length; i++)
            {
                //寻找当前SearchNode的Children里面是否有相关Node
                //1.在Root节点的时候，则Seg1.Seg2.Seg3 寻找Root的Children里面是否有Seg1
                newPath += i == 0 ? pathArray[i] : "." + pathArray[i];
                var hitNode = searchNode.IsChildContains(pathArray[i]);
                if (hitNode == null)
                {
                    var newChild = new CTreeNode(newPath);
                    newChild.Parent = searchNode;
                    searchNode.Children.Add(newChild);
                    searchNode = newChild;
                }
                else
                {
                    searchNode = hitNode;
                }
            }
            //给节点赋予Tag
            searchNode.Tag = tag;
        }
    }
}