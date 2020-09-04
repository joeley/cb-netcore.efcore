using Asp.NetCore.Model.Business;
using System;
using System.Collections.Generic;

namespace Asp.NetCore.IDal
{
    public interface ISendCarDal
    {
        /// <summary>
        /// 查询SendCar视图
        /// </summary>
        /// <param name="sendCarView"></param>
        /// <returns></returns>
        List<SendCarView> QuerySendCarView(SendCarView sendCarView);
    }
}
