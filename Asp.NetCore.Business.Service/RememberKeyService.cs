using Asp.NetCore.Business.Interface;
using Asp.NetCore.Dal;
using Asp.NetCore.IDal;
using Asp.NetCore.Model.Entities;
using Asp.NetCore.Model.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Asp.NetCore.Business.Service
{
    public class RememberKeyService : BaseService, IRememberKeyService
    {
        public RememberKeyService()
        {

        }

        /// <summary>
        /// 校验Token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Response CheckToken(string token)
        {
            var response = new Response();
            var rememberKey = Query<RememberKeyT>(r => r.Token == token).FirstOrDefault();
            if (rememberKey != null && rememberKey.Expires_date > DateTime.Now)
            {
                //有效的token 获取信息自动登陆
                //查询user信息
                long user_Id = (long)rememberKey.User_Id;
                var user = Query<UserT>(u => u.User_Id == user_Id).FirstOrDefault();
                if (user != null)
                {
                    //Token有效
                    response.Code = 200;
                    response.Data = user;
                    response.Message = "有效Token";
                }
                else
                {
                    response.Code = 400;
                    response.Message = "Token指定的用户不存在";
                }
            }
            else
            {
                response.Code = 400;
                response.Message = "无效的Token";
            }
            return response;
        }

        /// <summary>
        /// 在服务器端创建Token
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Response CreateToken(long userId, string token)
        {
            var response = new Response();
            try
            {
                ///存在执行更新，不存在执行修改
                RememberKeyT rememberKey = Query<RememberKeyT>(r => r.User_Id == userId).SingleOrDefault();
                if (rememberKey != null)
                {
                    rememberKey.Update_time = DateTime.Now;
                    rememberKey.Expires_date = DateTime.Now.AddDays(7);//有效期保持7天
                    rememberKey.Token = token;
                    Update<RememberKeyT>(rememberKey);
                }
                else
                {
                    rememberKey = new RememberKeyT();
                    rememberKey.User_Id = userId;
                    rememberKey.Create_time = DateTime.Now;
                    rememberKey.Expires_date = DateTime.Now.AddDays(7);//有效期保持7天
                    rememberKey.Token = token;
                    Insert<RememberKeyT>(rememberKey);
                }
                response.Code = 200;
                response.Message = "创建成功";
            }
            catch(Exception ex)
            {
                response.Code = 400;
                response.Message = "创建失败，erro：" + ex.Message;
            }
            return response;
            
        }
    }
}
