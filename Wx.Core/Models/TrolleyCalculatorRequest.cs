using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wx.Core.Models
{
    public class TrolleyCalculatorRequest
    {
        public List<Product> products { get; set; }
        public List<Special> specials { get; set; }
        public List<Quantity2> quantities { get; set; }

        public class Product
        {
            public string name { get; set; }
            public string price { get; set; }
        }

        public class Quantity
        {
            public string name { get; set; }
            public int quantity { get; set; }
        }

        public class Special
        {
            public List<Quantity> quantities { get; set; }
            public string total { get; set; }
        }

        public class Quantity2
        {
            public string name { get; set; }
            public int quantity { get; set; }
        }
    }
}
