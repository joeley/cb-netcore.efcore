using Asp.NetCore.Model.Business;
using Asp.NetCore.Model.Vo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.Business.Interface
{
    public interface IUserService:IBaseService
    {
        /// <summary>
        /// 查询UserView
        /// </summary>
        /// <param name="userView"></param>
        /// <returns></returns>
        List<UserView> QueryUserView(UserView userView);

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        Response Login(string userName, string pwd);
    }
}
