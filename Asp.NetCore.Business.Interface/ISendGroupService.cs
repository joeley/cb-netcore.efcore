using Asp.NetCore.Model.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.Business.Interface
{
    public interface ISendGroupService : IBaseService
    {
        /// <summary>
        /// 获取发货单位的Option HTML代码
        /// </summary>
        /// <returns></returns>
        public string QuerySendGroupOptionHtml();
    }
}
