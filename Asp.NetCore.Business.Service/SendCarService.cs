using Asp.NetCore.Business.Interface;
using Asp.NetCore.IDal;
using Asp.NetCore.Model.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.Business.Service
{
    public class SendCarService : BaseService, ISendCarService
    {
        private readonly ISendCarDal _ISendCarDal;

        public SendCarService(ISendCarDal sendCarDal)
        {
            _ISendCarDal = sendCarDal;
        }

        /// <summary>
        /// 查询派车实体
        /// </summary>
        /// <param name="sendCarView"></param>
        /// <returns></returns>
        public List<SendCarView> QuerySendCarView(SendCarView sendCarView)
        {
            return _ISendCarDal.QuerySendCarView(sendCarView);
        }
    }
}
