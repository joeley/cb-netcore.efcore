using Asp.NetCore.DBFactory;
using Asp.NetCore.IDal;
using Asp.NetCore.Model.Business;
using Asp.NetCore.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asp.NetCore.Dal
{
    public class UserDal : IUserDal
    {
        /// <summary>
        /// 查询UserView
        /// </summary>
        /// <param name="userView"></param>
        /// <returns></returns>
        public List<UserView> QueryUserView(UserView userView)
        {
            var result = new List<UserView>();
            string sql = string.Format(@" select * from UserT A 
                                            left join RoleT B on A.Role_Id = B.Role_Id
                                            where 1=1 ");
            if (userView.User_Id != null)
            {
                sql += string.Format(@" and A.User_Id ='{0}' ", userView.User_Id);
            }
            if (userView.User_Name != null)
            {
                sql += string.Format(@" and A.User_Name = '{0}' ", userView.User_Name);
            }
            if (userView.Full_Name != null)
            {
                sql += string.Format(@" and A.Full_Name = '{0}' ", userView.Full_Name);
            }
            if (userView.Role_Id != null)
            {
                sql += string.Format(@" and A.Role_Id = '{0}' ", userView.Role_Id);
            }
            if (userView.User_Password != null)
            {
                sql += string.Format(@" and A.User_Password = '{0}' ", userView.User_Password);
            }
            using (DBContextFactory db = new DBContextFactory())
            {
                result = db.Database.SqlQuery<UserView>(sql).ToList();
            }

            return result;
        }


       }



}
