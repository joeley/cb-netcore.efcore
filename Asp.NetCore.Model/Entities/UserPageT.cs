using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.NetCore.Model.Entities
{
    public class UserPageT
    {
        [Key]
        public long? UserPage_Id { get; set; }
        [StringLength(50)]
        public string Menu_Id { get; set; }
        public long? User_Id { get; set; }
        [StringLength(20)]
        public string UserPage_Type { get; set; }


    }
}
