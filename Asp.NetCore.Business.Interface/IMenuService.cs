using Asp.NetCore.Model.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.Business.Interface
{
    public interface IMenuService:IBaseService
    {
        /// <summary>
        /// 查询用户授权菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Menu> QueryMenuInfoByUserId(long userId);

        /// <summary>
        /// 获取当前用户下的授权菜单HTML代码
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        string GetMenu(long userId);

    }
}
