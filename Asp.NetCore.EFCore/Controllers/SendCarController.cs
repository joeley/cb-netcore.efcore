using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Asp.NetCore.Business.Interface;
using Asp.NetCore.Business.Service;
using Asp.NetCore.Model.Business;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore.EFCore.Controllers
{
    public class SendCarController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly ISendCarService _SendCarService;//派车
        private readonly IContractService _IContractService;//合同
        private readonly IMaterialService _MaterialService;//物料
        private readonly ISendGroupService _SendGroupService;//发货单位
        private readonly IReceiveGroupService _ReceiveGroupService;//收货单位
        public SendCarController(IRememberKeyService rememberKeyService,
            ISendCarService sendCarService,
            IContractService contractService,
            IMaterialService materialService,
            ISendGroupService sendGroupService,
            IReceiveGroupService receiveGroupService)
            :base(rememberKeyService)
        {
            _IContractService = contractService;
            _SendCarService = sendCarService;
            _MaterialService = materialService;
            _SendGroupService = sendGroupService;
            _ReceiveGroupService = receiveGroupService;
        }

        public ActionResult SendCar()
        {
            ViewData["Contract_Select"] = _IContractService.QueryContractOptionHtml();
            ViewData["Material_Select"] = _MaterialService.QueryMaterialOptionHtml();
            ViewData["SendGroup_Select"] = _SendGroupService.QuerySendGroupOptionHtml();
            ViewData["ReceiveGroup_Select"] = _ReceiveGroupService.QueryReceiveGroupOptionHtml();

            return View("/Views/SendCar/SendCar.cshtml");
        }

        /// <summary>
        /// 查询报表
        /// </summary>
        /// <param name="sendCarView"></param>
        /// <returns></returns>
        public string QuerySendCarView(SendCarView sendCarView)
        {
            var model = _SendCarService.QuerySendCarView(sendCarView);
            return JsonSerializer.Serialize(model);
        }
    }
}
