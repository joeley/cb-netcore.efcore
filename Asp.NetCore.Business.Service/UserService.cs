using Asp.NetCore.Business.Interface;
using Asp.NetCore.Dal;
using Asp.NetCore.IDal;
using Asp.NetCore.Model.Business;
using Asp.NetCore.Model.Vo;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.Business.Service
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserDal _UserDal;
        public UserService(IUserDal userDal)
        {
            _UserDal = userDal;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public Response Login(string userName, string pwd)
        {
            var response = new Response();
            try
            {
                UserView user = new UserView
                {
                    User_Name = userName,
                    User_Password = pwd
                };
                List<UserView> userViews = _UserDal.QueryUserView(user);
                if (userViews.Count > 0)
                {
                    var loginUser = userViews[0];
                    response.Code = 200;
                    response.Data = loginUser;
                    response.Message = "用户验证成功";
                }
                else
                {
                    response.Code = 400;
                    response.Message = "登录失败，用户名或密码不正确";
                }
            }
            catch(Exception ex)
            {
                response.Code = 400;
                response.Message = "登录失败，Erro：" + ex.Message;
            }
            return response;
        }

        /// <summary>
        /// 查询UserView
        /// </summary>
        /// <param name="userView"></param>
        /// <returns></returns>
        public List<UserView> QueryUserView(UserView userView)
        {
            return _UserDal.QueryUserView(userView);
        }
    }
}
