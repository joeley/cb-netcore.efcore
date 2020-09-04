using Asp.NetCore.Model.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.Business.Interface
{
    public interface IReceiveGroupService : IBaseService
    {
        /// <summary>
        /// 获取收货单位的Option HTML代码
        /// </summary>
        /// <returns></returns>
        public string QueryReceiveGroupOptionHtml();
    }
}
