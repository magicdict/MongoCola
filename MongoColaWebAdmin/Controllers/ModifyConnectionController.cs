using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MongoColaWebAdmin.Controllers
{
    public class ModifyConnectionController : Controller
    {
        /// <summary>
        /// 修改连接
        /// </summary>
        /// <param name="ConnectionName"></param>
        /// <returns></returns>
        public IActionResult Index(string ConnectionName)
        {
            ViewData.Add("ConnectionName", ConnectionName);
            return View();
        }
    }
}
