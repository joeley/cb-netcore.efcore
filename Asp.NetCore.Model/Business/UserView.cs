using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.Model.Business
{
    public class UserView
    {
        public long? User_Id { get; set; }//用户ID
        public string User_Name { get; set; }//用户名
        public string Full_Name { get; set; }//姓名
        public string User_Password { get; set; }//密码
        public long? Role_Id { get; set; }//角色ID
        public string Role_Name { get; set; }//角色名称
        public string Remark { get; set; }//备注
    }
}
