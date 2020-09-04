using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.Model.Business
{
    public class SendCarView
    {
        public long? SendCar_Id { get; set; }

        public string TruckCode { get; set; }
        public string DriverName { get; set; }

        public string DriverPhone { get; set; }
        public string DriverIdNum { get; set; }

        public string SendUser { get; set; }
        public DateTime? SendTime { get; set; }

        public int? SendState { get; set; }
        public long? ReceiveGroup_Id { get; set; }
        public string ReceiveGroup_Name { get; set; }

        public long? SendGroup_Id { get; set; }
        public string SendGroup_Name { get; set; }
        public double? FromGrossWeight { get; set; }

        public double? FromNetWeight { get; set; }
        public double? FromTareWeight { get; set; }

        public long? Material_Id { get; set; }
        public string Material_Name { get; set; }
        public long? Contract_Id { get; set; }
        public string Contract_Code { get; set; }
        public string Contract_Name { get; set; }
        public string WeightType { get; set; }

        public DateTime? SendTimeStart { get; set; }
        public DateTime? SendTimeEnd { get; set; }
    }
}
