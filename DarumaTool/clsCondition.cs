using System;
using System.Collections.Generic;

namespace DarumaTool
{
    class clsCondition
    {
        const String CAnd = " AND ";
        const String COr = " OR ";
        const String CBig = " > ";
        const String CBigEqual = " >= ";
        const String CSmall = " < ";
        const String CSmallEqual = " <= ";
        const String CEqual = " = ";
        const String CNotEqual = " ^= ";
        String[] MathOplst = new string[] { CBig, CBigEqual, CSmall, CSmallEqual, CEqual, CNotEqual };
        String[] LogicOplst = new string[] { CAnd, COr };
        public List<String> TopConditionLst = new List<string>();
        public List<String> TestItemLst = new List<string>();
        public String OrgCondition = String.Empty;
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="strCondition"></param>
        public clsCondition(String strCondition)
        {
            OrgCondition = strCondition;
            //"(" + 1
            //")" - 1
            int nestLV = 1;
            string subCondition = String.Empty;
            Boolean HasAdded = false;
            Boolean IsIndexOn = false;
            for (int i = 0; i < strCondition.Length; i++)
            {
                HasAdded = false;
                if (strCondition.Substring(i, 1) == "(")
                {
                    if (nestLV == 1 && (!String.IsNullOrEmpty(subCondition)))
                    {
                        IsIndexOn = true;
                    }
                    else
                    {
                        if (nestLV == 1)
                        {
                            HasAdded = true;
                        }
                        nestLV++;
                    }
                }
                if (strCondition.Substring(i, 1) == ")")
                {
                    if (IsIndexOn)
                    {
                        IsIndexOn = false;
                    }
                    else
                    {
                        nestLV--;
                        if (nestLV == 1)
                        {
                            HasAdded = true;
                        }
                    }
                }
                foreach (var logicOpt in LogicOplst)
                {
                    if (i + logicOpt.Length <= strCondition.Length && strCondition.Substring(i, logicOpt.Length) == logicOpt)
                    {
                        if (nestLV == 1)
                        {
                            if (!String.IsNullOrEmpty(subCondition))
                            {
                                TopConditionLst.Add(subCondition);
                            }
                            TopConditionLst.Add(logicOpt);
                            subCondition = String.Empty;
                            HasAdded = true;
                            i += logicOpt.Length - 1;
                        }
                    }
                }
                if (!HasAdded)
                {
                    subCondition += strCondition.Substring(i, 1);
                }
            }
            if (!string.IsNullOrEmpty(subCondition))
            {
                TopConditionLst.Add(subCondition);
                subCondition = String.Empty;
            }
            foreach (var ConditionString in TopConditionLst)
            {
                Boolean isCondition = true;
                foreach (var logicOpt in LogicOplst)
                {
                    if (ConditionString == logicOpt)
                    {
                        isCondition = false;
                    }
                }
                if (isCondition) GetTestItem(ConditionString);
            }
            if (TestItemLst.Count == 0)
            {
                TestItemLst.Add(OrgCondition.Trim());
            }
        }
        private void GetTestItem(String ConditionString)
        {
            Boolean PickerStatus = true;
            String TestItem = String.Empty;
            for (int i = 0; i < ConditionString.Length; i++)
            {
                //(Ｗ＿項目番号 = 070 OR 075) AND 端末機種別コード OF ＬＣ制御共通情報 = ★郵便局用端末機
                foreach (var MathsOpt in MathOplst)
                {
                    if (i + MathsOpt.Length <= ConditionString.Length && ConditionString.Substring(i, MathsOpt.Length) == MathsOpt)
                    {
                        if (IsConst(TestItem))
                        {
                            //如果大小比较的左侧是常数，则获得右边的东西 10 = A
                            PickerStatus = true;
                        }
                        else
                        {
                            //正常的关系式 A = 10
                            PickerStatus = false;
                            TestItemLst.Add(TestItem.Trim());
                        }
                        TestItem = String.Empty;
                        i += MathsOpt.Length - 1;
                    }
                }

                //(Ｗ＿項目番号 = 070 OR 075) 
                foreach (var LogicOpt in LogicOplst)
                {
                    if (i + LogicOpt.Length <= ConditionString.Length && ConditionString.Substring(i, LogicOpt.Length) == LogicOpt)
                    {
                        if (PickerStatus == true)
                        {
                            // 遇见了OR的时候
                            // And|Or 前面如果是 10 = A 的补偿，则需要补偿
                            if (!IsConst(TestItem))
                            {
                                TestItemLst.Add(TestItem.Trim());
                            }
                            TestItem = String.Empty;
                        }
                        PickerStatus = true;
                        i += LogicOpt.Length - 1;
                    }
                }
                if (PickerStatus)
                {
                    if (ConditionString.Substring(i, 1) != " ")
                    {
                        if (!(ConditionString.Substring(i, 1) == "(" && TestItem.Length == 0))
                        {
                            TestItem = TestItem + ConditionString.Substring(i, 1);
                        }
                    }
                    else
                    {
                        if (i + " OF ".Length <= ConditionString.Length && ConditionString.Substring(i, 4) == " OF ")
                        {
                            TestItem = TestItem + " OF ";
                            i += " OF ".Length - 1;
                        }
                    }
                }
            }
            //如果 10=A 出现在最后的是，需要补偿
            if (PickerStatus == true)
            {
                // 10 = A 的补偿
                if (!IsConst(TestItem)) TestItemLst.Add(TestItem.Trim());
                TestItem = String.Empty;
            }

        }
        private bool IsConst(String TestString)
        {
            Boolean R;
            R = false;
            int t;
            if (int.TryParse(TestString, out t))
            {
                R = true;
            }
            //常数不用加入
            if (TestString.StartsWith("☆") || TestString.StartsWith("★"))
            {
                R = true;
            }
            //引号
            if (TestString.StartsWith("\"") || TestString.StartsWith("\""))
            {
                R = true;
            }
            //NC汉字
            if (TestString.StartsWith("NC\"") || TestString.StartsWith("\""))
            {
                R = true;
            }
            return R;
        }
        /// <summary>
        /// 临界值测试
        /// </summary>
        /// <param name="Conition"></param>
        /// <returns></returns>
        private string GetBoundTestCondition(string Condition)
        {
            ///条件文
            String OpCondition = String.Empty;

            return OpCondition;
        }
        /// <summary>
        /// 获得当前条件的反条件
        /// </summary>
        /// <param name="Condition"></param>
        /// <returns></returns>
        private string GetOpsiteCondition(string Condition)
        {
            //TEST
            //GetConditionFormat(Condition);
            if (String.IsNullOrEmpty(Condition))
            {
                return string.Empty;
            }
            /// A = B => A <> B
            /// A <> B => A = B
            /// 暂时不考虑 AND OR
            const String EqualString = " = ";
            const String NotEqualString = " ^= ";
            String OpCondition = String.Empty;
            if (Condition.Contains(EqualString))
            {
                String[] SplitString = new string[1] { EqualString };
                OpCondition = Condition.Split(SplitString, 10, StringSplitOptions.RemoveEmptyEntries)[0] + NotEqualString + Condition.Split(SplitString, 10, StringSplitOptions.RemoveEmptyEntries)[1];
            }
            else
            {
                if (Condition.Contains(NotEqualString))
                {
                    String[] SplitString = new string[1] { NotEqualString };
                    OpCondition = Condition.Split(SplitString, 10, StringSplitOptions.RemoveEmptyEntries)[0] + EqualString + Condition.Split(SplitString, 10, StringSplitOptions.RemoveEmptyEntries)[1];
                }
            }
            return OpCondition;
        }
    }
}
