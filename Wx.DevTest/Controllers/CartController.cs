using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wx.Core.Configuration;
using Wx.Core.Models;
using Wx.Core.Clients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Wx.WebApiNET.Controllers
{
    [Route("api/answers/trolleyTotal")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public IWooliesXService service;

        public CartController(IOptionsMonitor<WxConfig> wxConfig)
        {
            service = new WooliesXService(wxConfig.CurrentValue);
        }

        public decimal Post([FromBody] TrolleyCalculatorRequest req)
        {
            var result = service.RequestTrolleyPrice(req);
            return result;
        }
    }
}