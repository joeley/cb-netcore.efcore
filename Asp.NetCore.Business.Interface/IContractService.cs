using Asp.NetCore.Model.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.Business.Interface
{
    public interface IContractService : IBaseService
    {
        /// <summary>
        /// 获取合同的Option HTML代码
        /// </summary>
        /// <returns></returns>
        public string QueryContractOptionHtml();
    }
}
