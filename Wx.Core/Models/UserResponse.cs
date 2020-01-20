using System;
using System.Collections.Generic;
using System.Text;

namespace Wx.Core.Models
{
    public class UserResponse
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
    }
}
