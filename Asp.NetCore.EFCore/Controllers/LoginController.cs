using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asp.NetCore.Business.Interface;
using Asp.NetCore.Model.Business;
using Asp.NetCore.Model.Vo;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore.EFCore.Controllers
{
    public class LoginController : HttpController
    {
        private readonly IRememberKeyService _RememberKeyServcei;
        private readonly IUserService _IUserService;
        public LoginController(IRememberKeyService rememberKeyService,IUserService userService)
        {
            _RememberKeyServcei = rememberKeyService;
            _IUserService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Form Action 登陆
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public IActionResult Login(string username, string pwd)
        {
            var resp = new Response();
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pwd))
                {
                    resp.Code = 500;
                    resp.Message = "账号密码不能为空";
                    return Content("<script>alert('账号密码不能为空');location.href='/Login/Index'</script>", "text/html", Encoding.GetEncoding("GB2312"));
                }
                pwd = MD5Helper.GenerateMD5(pwd);//密码加密
                return LoginNoEncryption(username, pwd);
            }
            catch (Exception e)
            {
                resp.Code = 500;
                resp.Message = e.Message;
                return Content(string.Format(@"<script>alert('{0}');location.href='/Login/Index'</script>", resp.Message), "text/html", Encoding.GetEncoding("GB2312"));
            }
        }

        /// <summary>
        /// 不加密的密码登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public IActionResult LoginNoEncryption(string username, string pwd)
        {
            var resp = new Response();
            try
            {
                var loginResult = _IUserService.Login(username, pwd);
                if (loginResult.Code == 200)
                {
                    var loginUser = (UserView)loginResult.Data;
                    //登录成功
                    //生成MD5加密的Token 由user_id 系统时间 一个0到99999的随机数组成
                    string token = MD5Helper.GenerateMD5(loginUser.User_Id + DateTime.Now.ToString("yyyyMMDDHHmmss") + new Random().Next(0, 99999));
                    //在服务端创建token
                    var tokenRes = _RememberKeyServcei.CreateToken((long)loginUser.User_Id, token);
                    if (tokenRes.Code == 400)
                    {
                        //在服务器存储token失败
                        return Content(string.Format(@"<script>alert('{0}');location.href='/Login/Index'</script>", tokenRes.Message), "text/html", Encoding.GetEncoding("GB2312"));
                    }
                    //生成一个新的Cookie,存放日期为7天
                    SetCookies("Token", token, 7);
                    resp.Code = 200;
                    resp.Message = "登录成功";
                    //把用户信息保存在Session中
                    SetSession<UserView>(HttpContext.Session, "user", loginUser);
                }
                else
                {
                    resp.Code = 400;
                    resp.Message = "用户名或密码不正确";
                }
            }
            catch (Exception e)
            {
                resp.Code = 400;
                resp.Message = e.Message;
            }

            if (resp.Code == 400)
            {
                return Content(string.Format(@"<script>alert('{0}');location.href='/Login/Index'</script>", resp.Message), "text/html", Encoding.GetEncoding("GB2312"));
            }
            else
            {
                //return Redirect("/Home/Index");
                return Content("<script>location.href='/Home/Index'</script>", "text/html", Encoding.GetEncoding("GB2312"));
                //return Content("<script>location.href='/Home/Index'</script>", resp.Message);
            }
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
            //把用户信息保存在Session中
            SetSession<UserView>(HttpContext.Session, "user", null);
            //Session["user"] = null;//清除Session
            //清除Token的Cookie
            DeleteCookies("Token");
            return RedirectToAction("Index", "Login");
        }
    }
}
