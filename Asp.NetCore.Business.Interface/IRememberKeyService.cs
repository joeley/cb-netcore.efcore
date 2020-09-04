using Asp.NetCore.Model.Vo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.Business.Interface
{
    public interface IRememberKeyService
    {
        /// <summary>
        /// 校验Token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Response CheckToken(string token);

        /// <summary>
        /// 在服务器端创建token
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Response CreateToken(long userId, string token);
    }
}
