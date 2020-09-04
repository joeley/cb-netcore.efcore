using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.NetCore.Model.Entities
{
    public class ContractT
    {
        [Key]
        public long? Contract_Id { get; set; }//合同ID
        [StringLength(100)]
        public string Contract_Code { get; set; }//合同编号
        [StringLength(100)]
        public string Contract_Name { get; set; }//合同名称
        public long? SendGroup_Id { get; set; }//发货单位
        public long? ReceiveGroup_Id { get; set; }//收货单位ID
        public long? Material_Id { get; set; }//物料ID
        public double? LeftValue { get; set; }//剩余量
        public double? Perprice { get; set; }//单价
        public int? ContractState { get; set; }//合同状态

    }
}
