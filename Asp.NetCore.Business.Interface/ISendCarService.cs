using Asp.NetCore.Model.Business;
using Asp.NetCore.Model.Vo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.Business.Interface
{
    public interface ISendCarService:IBaseService
    {
        /// <summary>
        /// 查询派车视图
        /// </summary>
        /// <param name="sendCarView"></param>
        /// <returns></returns>
        public List<SendCarView> QuerySendCarView(SendCarView sendCarView);
    }
}
