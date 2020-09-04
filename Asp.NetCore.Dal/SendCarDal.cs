using Asp.NetCore.DBFactory;
using Asp.NetCore.IDal;
using Asp.NetCore.Model.Business;
using Asp.NetCore.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asp.NetCore.Dal
{
    public class SendCarDal : ISendCarDal
    {
        /// <summary>
        /// 查询派车视图
        /// </summary>
        /// <param name="sendCarView"></param>
        /// <returns></returns>
        public List<SendCarView> QuerySendCarView(SendCarView sendCarView)
        {
            string sql = string.Format(@" select * from SendCarT A
                                            left join ContractT B on A.Contract_Id = B.Contract_Id
                                            left join MaterialT C on C.Material_Id = B.Material_Id
                                            left join SendGroupT D on D.SendGroup_Id= B.SendGroup_id
                                            left join ReceiveGroupT E on E.ReceiveGroup_Id = B.ReceiveGroup_Id
                                            where 1=1 ");
            //主键
            if (sendCarView.SendCar_Id != null)
            {
                sql += string.Format(@" and A.SendCar_Id = {0} ", sendCarView.SendCar_Id);
            }
            //收货单位
            if (sendCarView.ReceiveGroup_Id != null)
            {
                sql += string.Format(@" and E.ReceiveGroup_Id = {0} ", sendCarView.ReceiveGroup_Id);
            }
            //发货单位
            if (sendCarView.SendGroup_Id != null)
            {
                sql += string.Format(@" and D.SendGroup_Id = {0} ", sendCarView.SendGroup_Id);
            }
            //物料
            if (sendCarView.Material_Id != null)
            {
                sql += string.Format(@" and C.Material_Id = {0} ", sendCarView.Material_Id);
            }
            //合同
            if (sendCarView.Contract_Id != null)
            {
                sql += string.Format(@" and B.Contract_Id = {0} ", sendCarView.Contract_Id);
            }
            //车牌号
            if (sendCarView.TruckCode != null)
            {
                sql += string.Format(@" and A.TruckCode like '%{0}%' ", sendCarView.TruckCode);
            }
            //身份证
            if (sendCarView.DriverIdNum != null)
            {
                sql += string.Format(@" and A.DriverIdNum like '%{0}%' ", sendCarView.DriverIdNum);
            }
            //司机姓名
            if (sendCarView.DriverName != null)
            {
                sql += string.Format(@" and A.DriverName like '%{0}%' ", sendCarView.DriverName);
            }
            //司机联系方式
            if (sendCarView.DriverPhone != null)
            {
                sql += string.Format(@" and A.DriverPhone like '%{0}%' ", sendCarView.DriverPhone);
            }
            //合同名称
            if (sendCarView.Contract_Name != null)
            {
                sql += string.Format(@" and B.Contract_Name like '%{0}%' ", sendCarView.Contract_Name);
            }
            //合同编号
            if (sendCarView.Contract_Code != null)
            {
                sql += string.Format(@" and B.Contract_Code like '%{0}%' ", sendCarView.Contract_Code);
            }
            //合同编号
            if (sendCarView.WeightType != null)
            {
                sql += string.Format(@" and A.WeighType = '{0}' ", sendCarView.WeightType);
            }
            //派车人员
            if (sendCarView.SendUser != null)
            {
                sql += string.Format(@" and A.SendUser = '{0}' ", sendCarView.SendUser);
            }
            //派车状态
            if (sendCarView.SendState != null)
            {
                sql += string.Format(@" and A.SendState = '{0}' ", sendCarView.SendState);
            }
            //派车时间start
            if (sendCarView.SendTimeStart != null)
            {
                sql += string.Format(@" and A.SendTime >= convert(datetime,'{0}') ", sendCarView.SendTimeStart);
            }
            //派车时间end
            if (sendCarView.SendTimeEnd != null)
            {
                sql += string.Format(@" and A.SendTime <= convert(datetime,'{0}') ", sendCarView.SendTimeEnd);
            }
            var list = new List<SendCarView>();
            using (var db = new DBContextFactory())
            {
                list = db.Database.SqlQuery<SendCarView>(sql).ToList();
            }
            return list;
        }


    }
}
