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
        /// 连接展示主面板
        /// </summary>
        /// <param name="ConnectionName"></param>
        /// <returns></returns>
        public IActionResult MainPanel(string ConnectionName)
        {
            ViewData.Add("ConnectionName", ConnectionName);
            return View();
        }
    }
}
