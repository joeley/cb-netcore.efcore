using Asp.NetCore.Model.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.Business.Interface
{
    public interface IMaterialService : IBaseService
    {
        /// <summary>
        /// 获取物料的Option HTML代码
        /// </summary>
        /// <returns></returns>
        public string QueryMaterialOptionHtml();
    }
}
