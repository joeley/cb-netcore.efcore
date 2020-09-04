using Asp.NetCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.IDal
{
    public interface IMenuDal
    {
        /// <summary>
        /// 通过UserId查询主菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<MainMenuT> QueryMainMenu(long userId);

        /// <summary>
        /// 通过userId查询二级菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<SecondMenuT> QuerySecondMenu(long userId);
    }
}
