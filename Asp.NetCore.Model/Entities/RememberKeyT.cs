using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.NetCore.Model.Entities
{
    public class RememberKeyT
    {
        [Key]
        public long? RememberKey_Id { get; set; }//ID主键

        public long? User_Id { get; set; }//用户ID
        [StringLength(100)]
        public string Token { get; set; }//Token
        public DateTime? Expires_date { get; set; }//到期时间
        public DateTime? Create_time { get; set; }//创建时间
        public DateTime? Update_time { get; set; }//修改时间


    }
}
