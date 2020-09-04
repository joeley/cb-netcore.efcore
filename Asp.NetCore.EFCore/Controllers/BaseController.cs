using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.NetCore.Business.Interface;
using Asp.NetCore.Model.Business;
using Asp.NetCore.Model.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Asp.NetCore.EFCore.Controllers
{
    public class BaseController : HttpController
    {
        public const string Token = "Token";//Token
        private readonly IRememberKeyService _RememberKeyService;

        public BaseController(IRememberKeyService rememberKeyService)
        {
            _RememberKeyService = rememberKeyService;
        }

        /// <summary>
        /// 在此处过滤
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                var token = "";

                //Token by QueryString
                token = GetCookies("Token");
                //以session是否为空来判断用户是否登陆
                if (GetSession<UserView>(HttpContext.Session, "user") == null)
                {
                    //token为空，会话丢失
                    if (string.IsNullOrEmpty(token))
                    {
                        //跳转登录
                        filterContext.Result = LoginResult("");
                        return;
                    }
                    //验证token是否有效
                    //将token传置后台数据库中查询，判断token是否有效，无效token跳转到登陆页面 
                    //token有效时用token查询用户信息进行登陆
                    var response = _RememberKeyService.CheckToken(token);
                    if(response.Code == 200)
                    {
                        UserT user = (UserT)response.Data;
                        //自动登录
                        filterContext.Result = new RedirectResult("/Login/LoginNoEncryption/?username=" + user.User_Name + "&&pwd=" + user.User_Password);
                        return;
                    }
                    else
                    {
                        //返回登录
                        filterContext.Result = LoginResult("");
                        return;
                    }


                }
            }
            catch (Exception ex)
            {
                NLogHelper.Error("过滤失败", ex);
                filterContext.Result = LoginResult("");
                return;
            }

            base.OnActionExecuting(filterContext);
        }


        /// <summary>
        /// 会话丢失，跳转到登陆页面
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public virtual IActionResult LoginResult(string username)
        {
            return new RedirectResult("/Login/Index");
        }

    }
}
