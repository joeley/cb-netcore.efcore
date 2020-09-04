using Asp.NetCore.Business.Interface;
using Asp.NetCore.Model.Entities;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.Business.Service
{
    public class SendGroupService : BaseService, ISendGroupService
    {
        /// <summary>
        /// 获取发货单位的Option HTML代码
        /// </summary>
        /// <returns></returns>
        public string QuerySendGroupOptionHtml()
        {
            string html = "<option value=\"" + "" + "\">" + "请选择" + "</option>";
            try
            {
                var mList = Query<SendGroupT>(c => c.SendGroup_Id != null);
                foreach (var item in mList)
                {
                    html += "<option value=\"" + item.SendGroup_Id + "\">" + item.SendGroup_Name + "</option>";
                }
            }
            catch (Exception ex)
            {
                NLogHelper.Error("查询发货单位下拉框HTML代码失败", ex);
            }
            return html;
        }
    }
}
