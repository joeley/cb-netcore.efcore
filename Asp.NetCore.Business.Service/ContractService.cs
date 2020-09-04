using Asp.NetCore.Business.Interface;
using Asp.NetCore.Model.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.Business.Service
{
    public class ContractService : BaseService, IContractService
    {
        /// <summary>
        /// 获取合同的Option HTML代码
        /// </summary>
        /// <returns></returns>
        public string QueryContractOptionHtml()
        {
            string html = "<option value=\"" + "" + "\">" + "请选择" + "</option>";
            try
            {
                var mList = Query<ContractT>(c => c.Contract_Id != null);
                foreach (var item in mList)
                {
                    html += "<option value=\"" + item.Contract_Id + "\">" + item.Contract_Name + "</option>";
                }
            }
            catch (Exception ex)
            {
                NLogHelper.Error("查询合同下拉框HTML代码失败", ex);
            }
            return html;
        }

        public void Test()
        {
            Insert<ContractT>(new ContractT());
        }
    }
}
