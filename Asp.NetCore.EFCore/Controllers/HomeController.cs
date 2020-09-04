using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Asp.NetCore.EFCore.Models;
using Asp.NetCore.Business.Interface;
using Asp.NetCore.Business.Service;
using Asp.NetCore.Model.Business;
using System.Text;
using Asp.NetCore.DBFactory;

namespace Asp.NetCore.EFCore.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;   //???????
        private readonly IMenuService _IMenuService;

        public HomeController(ILogger<HomeController> logger,
            IRememberKeyService rememberKeyService,
            IMenuService menuService) :
            base(rememberKeyService)
        {
            _logger = logger;
            _IMenuService = menuService;
        }


        public IActionResult Index()
        {
            UserView userView = GetSession<UserView>(HttpContext.Session, "user");//存储在session中的UserView对象，
            string result = _IMenuService.GetMenu((long)userView.User_Id);
            if (result == "")
            {
                return Content(string.Format(@"<script>alert('用户无权限');location.href='/Login/Index'</script>"), "text/html", Encoding.GetEncoding("GB2312"));
            }
            //从Controller给View写HTML
            ViewData["NavigationBar"] = result;//导航栏的HTML
            ViewData["UserId"] = userView.User_Id;
            ViewData["UserName"] = userView.User_Name;
            ViewData["RoleName"] = userView.Role_Name;
            ViewData["RoleId"] = userView.Role_Id;
            return View();
        }

    }
}
