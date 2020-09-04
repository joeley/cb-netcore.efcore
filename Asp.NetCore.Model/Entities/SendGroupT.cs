using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.NetCore.Model.Entities
{
    public partial class SendGroupT
    {
        [Key]
        public long? SendGroup_Id { get; set; }
        [StringLength(50)]
        public string SendGroup_Code { get; set; }
        [StringLength(50)]
        public string SendGroup_Name { get; set; }
    }
}
