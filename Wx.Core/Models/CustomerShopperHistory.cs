using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wx.Core.Models
{
    public class CustomerShopperHistory
    {
        public int customerId { get; set; }
        public List<Product> products { get; set; }
    }
}
