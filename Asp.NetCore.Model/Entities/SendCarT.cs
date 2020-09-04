using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.NetCore.Model.Entities
{
    public class SendCarT
    {
        [Key]
        public long? SendCar_Id { get; set; }
        [StringLength(50)]
        public string TruckCode { get; set; }
        [StringLength(50)]
        public string DriverName { get; set; }
        [StringLength(50)]
        public string DriverPhone { get; set; }
        [StringLength(50)]
        public string DriverIdNum { get; set; }
        [StringLength(50)]
        public string SendUser { get; set; }
        public DateTime? SendTime { get; set; }

        public int? SendState { get; set; }
        public double? FromGrossWeight { get; set; }

        public double? FromNetWeight { get; set; }
        public double? FromTareWeight { get; set; }
        public long? Contract_Id { get; set; }
        [StringLength(20)]
        public string WeightType { get; set; }
    }
}
