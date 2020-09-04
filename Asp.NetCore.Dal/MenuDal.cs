using Asp.NetCore.DBFactory;
using Asp.NetCore.IDal;
using Asp.NetCore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asp.NetCore.Dal
{
    public class MenuDal : IMenuDal
    {
        /// <summary>
        /// 通过userId查询主菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<MainMenuT> QueryMainMenu(long userId)
        {
            var list = new List<MainMenuT>();
            string sql = string.Format(@"select B.MainMenu_Id,B.MainMenu_Name,B.node_index,B.node_targeturl,B.iconClass from UserPageT A
                                                    left join MainMenuT B on A.Menu_Id = B.MainMenu_Id
                                                    where A.user_Id = {0} and A.UserPage_Type = 'MainMenu' 
                                                    order by B.node_index", userId);
            using (var db = new DBContextFactory())
            {
                list = db.Database.SqlQuery<MainMenuT>(sql).ToList();
            }
            return list;
        }

        /// <summary>
        /// 通过userId查询二级菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<SecondMenuT> QuerySecondMenu(long userId)
        {
            var list = new List<SecondMenuT>();
            string sql = string.Format(@"select B.MainMenu_Id,B.SecondMenu_Id,B.SecondMenu_Name,B.node_targeturl,B.node_index from UserPageT A
                                                    left join SecondMenuT B on A.Menu_Id = B.SecondMenu_Id
                                                    where A.user_Id = {0} and A.UserPage_Type = 'SecondMenu'
                                                    order by B.node_index", userId);
            using (var db = new DBContextFactory())
            {
                list = db.Database.SqlQuery<SecondMenuT>(sql).ToList();
            }
            return list;
        }
    }
}
