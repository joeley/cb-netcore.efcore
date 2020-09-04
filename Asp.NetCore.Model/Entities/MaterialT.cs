using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.NetCore.Model.Entities
{
    public partial class MaterialT
    {
        [Key]
        public long? Material_Id { get; set; }
        [StringLength(100)]
        public string Material_Code { get; set; }
        [StringLength(100)]
        public string Material_Name { get; set; }
    }
}
