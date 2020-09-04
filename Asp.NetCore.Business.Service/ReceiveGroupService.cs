using Asp.NetCore.Business.Interface;
using Asp.NetCore.Model.Entities;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.Business.Service
{
    public class ReceiveGroupService : BaseService, IReceiveGroupService
    {
        /// <summary>
        ///  获取收货单位的Option HTML代码
        /// </summary>
        /// <returns></returns>
        public string QueryReceiveGroupOptionHtml()
        {
            string html = "<option value=\"" + "" + "\">" + "请选择" + "</option>";
            try
            {
                var mList = Query<ReceiveGroupT>(c => c.ReceiveGroup_Id != null);
                foreach (var item in mList)
                {
                    html += "<option value=\"" + item.ReceiveGroup_Id + "\">" + item.ReceiveGroup_Name + "</option>";
                }
            }
            catch (Exception ex)
            {
                NLogHelper.Error("查询收货单位下拉框HTML代码失败", ex);
            }
            return html;
        }
    }
}
