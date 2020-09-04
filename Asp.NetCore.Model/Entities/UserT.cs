using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.NetCore.Model.Entities
{
    /*
     * User表
     * */
    public class UserT
    {
        [Key]
        public long? User_Id { get; set; }//用户ID
        [StringLength(50)]
        public string User_Name { get; set; }//用户名
        [StringLength(50)]
        public string Full_Name { get; set; }//姓名
        [StringLength(50)]
        public string User_Password { get; set; }//密码
        public long? Role_Id { get; set; }//角色ID
        public long? Department_Id { get; set; }//部门ID
        [StringLength(100)]
        public string Remark { get; set; }//备注

    }
    
}
