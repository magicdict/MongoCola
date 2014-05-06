using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Card
{
    public class BattleEnviroment
    {
        ///Role有一个IsFirst属性，通过这个属性，和FirstPlayer，SecondPlayer联系起来
        //先手
        RoleInfo FirstPlayer = new RoleInfo();
        //后手
        RoleInfo SecondPlayer = new RoleInfo();
    }
}
