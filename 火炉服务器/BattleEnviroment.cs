using Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 火炉服务器
{
    public class BattleEnviroment
    {
        ///Role有一个IsFirst属性，通过这个属性，和FirstPlayer，SecondPlayer联系起来
        //先手
        public RoleInfo FirstPlayer = new RoleInfo();
        //后手
        public RoleInfo SecondPlayer = new RoleInfo();
    }
}
