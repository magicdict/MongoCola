using System.Collections.Generic;

namespace Common
{
    public class CTreeNode
    {
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
        ///     新建一个节点
        /// </summary>
        /// <param name="Path">用.连接的全路径</param>
        public CTreeNode(string FullPath)
        {
			Children = new List<CTreeNode> ();
            Path = FullPath;
            if (FullPath.Equals(string.Empty))
            {
                IsRoot = true;
                Text = "<Root>";
            }
            else
            {
                var PathArray = FullPath.Split(".".ToCharArray());
                Text = PathArray[PathArray.Length - 1];
            }
        }
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
        /// 子节点挂载到Root节点
        /// </summary>
        /// <param name="FullPath"></param>
        public static void AddToRootNode(CTreeNode Root, string FullPath,object Tag = null)
        {
            //分割路径
            var PathArray = FullPath.Split(".".ToCharArray());
            CTreeNode SearchNode = Root;
            var NewPath = string.Empty;
            for (int i = 0; i < PathArray.Length; i++)
            {
                //寻找当前SearchNode的Children里面是否有相关Node
                //1.在Root节点的时候，则Seg1.Seg2.Seg3 寻找Root的Children里面是否有Seg1
                NewPath += (i==0?PathArray[i]:"." + PathArray[i]);
                var HitNode = SearchNode.IsChildContains(PathArray[i]);
                if (HitNode == null) {
                    var NewChild = new CTreeNode(NewPath);
                    NewChild.Parent = SearchNode;
                    SearchNode.Children.Add(NewChild);
                    SearchNode = NewChild;
                }
                else
                {
                    SearchNode = HitNode;
                }
            }
            //给节点赋予Tag
            SearchNode.Tag = Tag;
        }
    }
}
