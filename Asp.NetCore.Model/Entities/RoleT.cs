using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.NetCore.Model.Entities
{
    public class RoleT
    {
        [Key]
        public long? Role_Id { get; set; }//角色ID
        [StringLength(50)]
        public string Role_Code { get; set; }//角色Code
        [StringLength(50)]
        public string Role_Name { get; set; }//角色名称
    }
}
