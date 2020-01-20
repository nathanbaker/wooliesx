using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wx.Core.Configuration;
using Wx.Core.Models;

namespace Wx.WebApiNET.Controllers
{
    [Route("api/answers/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly WxConfig config;

        public UserController(IOptionsMonitor<WxConfig> wxConfig) {

            this.config = wxConfig.CurrentValue;
        }

        public ActionResult<UserResponse> Get()
        {
            var user = new UserResponse()
            {
                Name = "Nathan Baker",
                Token = config.Token
            };

            return user;
        }

    }
}
