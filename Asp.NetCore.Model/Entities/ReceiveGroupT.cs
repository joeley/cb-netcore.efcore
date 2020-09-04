using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.NetCore.Model.Entities
{
    public partial class ReceiveGroupT
    {
        [Key]
        public long? ReceiveGroup_Id { get; set; }
        [StringLength(100)]
        public string ReceiveGroup_Code { get; set; }
        [StringLength(100)]
        public string ReceiveGroup_Name { get; set; }
    }
}
