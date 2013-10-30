using System;
using System.Collections.Generic;

namespace DarumaTool
{
    public partial class IDL2PgmStruct
    {
        #region "嵌套"
        /// <summary>
        /// 顶层列表
        /// </summary>
        public List<List<Syntax>> TopSyntax = new List<List<Syntax>>();
        /// <summary>
        /// 分歧控制用变量集合
        /// </summary>
        public HashSet<String> ControlVar = new HashSet<string>();
        /// <summary>
        /// 顶层的整理
        /// </summary>
        /// <param name="SyntaxList"></param>
        private void ReSyntax(List<Syntax> SyntaxList)
        {
            //TopSyntax的整理
            List<Syntax> OneSyntax = new List<Syntax>();
            foreach (var syntax in SyntaxList)
            {
                //第一层为基准的整理
                if (syntax.NestLv == 1)
                {
                    if (isStartSyntax(syntax) || isMidSyntax(syntax))
                    {
                        //LV = 1 
                        OneSyntax.Add(syntax);
                    }
                    if (isEndSyntax(syntax))
                    {
                        TopSyntax.Add(OneSyntax);
                        OneSyntax = new List<Syntax>();
                    }
                }
                else
                {
                    //其他层,非终止，这里必须要将CALL，ASSIGN等包括进来
                    //然后在接下来的步骤里面吸收到分歧/内容,迁移等等
                    if (!isEndSyntax(syntax))
                    {
                        if (syntax.SyntaxType != "CASE") OneSyntax.Add(syntax);
                    }
                }
                //控制变量的收集
                if (syntax.Cond != null)
                {
                    foreach (var item in syntax.Cond.TestItemLst)
                    {
                        if (!ControlVar.Contains(item))
                        {
                            ControlVar.Add(item);
                        }
                    }
                }
            }
            List<List<Syntax>> ReTopSyntax = new List<List<Syntax>>();
            //迁移情报预整理
            foreach (List<Syntax> Syntaxlst in TopSyntax)
            {
                ReTopSyntax.Add(Cleaning(Syntaxlst));
            }
            TopSyntax = ReTopSyntax;
            foreach (var item in TopSyntax)
            {
                foreach (Section Section in SectionList)
                {
                    if (Section.SectionName == item[0].SectionName)
                    {
                        Section.SyntaxList.Add(item);
                    }
                }
            }
        }
        /// <summary>
        /// 迁移情报预整理
        /// </summary>
        /// <param name="Syntaxlst"></param>
        /// <returns></returns>
        private List<Syntax> Cleaning(List<Syntax> Syntaxlst)
        {
            ///关键的和迁移有关的变量，PERFORM记载在迁移情报之中，其他不用记载
            List<Syntax> ReSyntaxlst = new List<Syntax>();
            foreach (var syntax in Syntaxlst)
            {
                switch (syntax.SyntaxType)
                {
                    case "ASSIGN":
                        if (ControlVar.Contains(syntax.ExtendInfo.Substring(1, syntax.ExtendInfo.IndexOf("」") - 1)))
                        {
                            //最近的父亲！不是上一个
                            for (int i = ReSyntaxlst.Count - 1; i >= 0; i--)
                            {
                                if (ReSyntaxlst[i].NestLv == syntax.NestLv -1 ){
                                    ReSyntaxlst[i].JumpInfo.Add(syntax);
                                    break;
                                }
                            }
                        }
                        break;
                    case "PERFORM":
                    case "ERROR":
                        //最近的父亲！不是上一个
                        for (int i = ReSyntaxlst.Count - 1; i >= 0; i--)
                        {
                            if (ReSyntaxlst[i].NestLv == syntax.NestLv - 1)
                            {
                                ReSyntaxlst[i].JumpInfo.Add(syntax);
                                break;
                            }
                        }
                        break;
                    default:
                        if (isStartSyntax(syntax) || isMidSyntax(syntax))
                        {
                            //所有的非语法终止节点
                            ReSyntaxlst.Add(syntax);
                        }
                        break;
                }
            }
            return ReSyntaxlst;
        }
        /// <summary>
        /// 是否为语法
        /// </summary>
        /// <param name="syntax"></param>
        /// <returns></returns>
        public static bool isSyntax(Syntax syntax)
        {
            return (isStartSyntax(syntax) || isEndSyntax(syntax) || isMidSyntax(syntax));
        }
        /// <summary>
        /// 是否为开始语法
        /// </summary>
        /// <param name="syntax"></param>
        /// <returns></returns>
        public static bool isStartSyntax(Syntax syntax)
        {
            switch (syntax.SyntaxType)
            {
                case "IF":
                case "GET":
                case "WHILE":
                case "REPEAT":
                case "CASE":
                case "FOR":
                case "LOOP":
                    return true;
                default:
                    return false;
            }
        }
        /// <summary>
        /// 是否为结束语法
        /// </summary>
        /// <param name="syntax"></param>
        /// <returns></returns>
        public static bool isMidSyntax(Syntax syntax)
        {
            switch (syntax.SyntaxType)
            {
                case "ELSE":
                case "WHEN":
                    //case "OTHER":
                    return true;
                default:
                    return false;
            }
        }
        /// <summary>
        /// 是否为结束语法
        /// </summary>
        /// <param name="syntax"></param>
        /// <returns></returns>
        public static bool isEndSyntax(Syntax syntax)
        {
            switch (syntax.SyntaxType)
            {
                case "END-IF":
                case "END-GET":
                case "END-WHILE":
                case "END-REPEAT":
                case "END-CASE":
                case "END-FOR":
                case "END-LOOP":
                    return true;
                default:
                    return false;
            }
        }
        #endregion
    }
}
