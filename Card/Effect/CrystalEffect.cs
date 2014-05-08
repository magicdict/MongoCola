using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Card.Player;
namespace Card.Effect
{
    public class CrystalEffect : EffectDefine
    {
        /// <summary>
        /// 对法力水晶的法术实施
        /// </summary>
        /// <param name="role"></param>
        /// <param name="magic"></param>
        public static void ModifyCrystal(PlayerBasicInfo role, EffectDefine magic)
        {
            string[] Op = magic.AddtionInfo.Split("/".ToCharArray());
            int point = 0;
            //±N/±N	增加减少 可用水晶 / 增加减少 空水晶
            //可用水晶
            if (Op[0].Substring(1, 1) != "0")
            {
                point = int.Parse(Op[0].Substring(1, 1));
                if (Op[0].Substring(0, 1) == "+")
                {
                    for (int i = 0; i < point; i++)
                    {
                        role.crystal.AddCurrentPoint();
                    }
                }
                else
                {
                    for (int i = 0; i < point; i++)
                    {
                        role.crystal.ReduceCurrentPoint();
                    }
                }
            }
            //空水晶
            if (Op[1].Substring(1, 1) != "0")
            {
                point = int.Parse(Op[1].Substring(1, 1));
                if (Op[1].Substring(0, 1) == "+")
                {
                    for (int i = 0; i < point; i++)
                    {
                        role.crystal.AddFullPoint();
                    }
                }
                else
                {
                    for (int i = 0; i < point; i++)
                    {
                        role.crystal.ReduceFullPoint();
                    }
                }
            }
        }
    }
}
