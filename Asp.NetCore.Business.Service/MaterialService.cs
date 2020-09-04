using Asp.NetCore.Business.Interface;
using Asp.NetCore.Model.Entities;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.Business.Service
{
    public class MaterialService : BaseService, IMaterialService
    {
        /// <summary>
        /// 获取合同的Option HTML代码
        /// </summary>
        /// <returns></returns>
        public string QueryMaterialOptionHtml()
        {
            string html = "<option value=\"" + "" + "\">" + "请选择" + "</option>";
            try
            {
                var mList = Query<MaterialT>(c => c.Material_Id != null);
                foreach (var item in mList)
                {
                    html += "<option value=\"" + item.Material_Id + "\">" + item.Material_Name + "</option>";
                }
            }
            catch (Exception ex)
            {
                NLogHelper.Error("查询物料下拉框HTML代码失败", ex);
            }
            return html;
        }
    }
}
