using System;

namespace Wx.Core.Models
{
    internal class JsonPropertyAttribute : Attribute
    {
        public string PropertyName { get; set; }
    }
}