using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MongoColaWebAdmin.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 主面板
        /// </summary>
        /// <param name="ConnectionName"></param>
        /// <returns></returns>
        public IActionResult MainPanel(string ConnectionName)
        {
            return View();
        }
    }
}
