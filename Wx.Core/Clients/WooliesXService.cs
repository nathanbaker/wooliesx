using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Wx.Core.Configuration;
using Wx.Core.Models;

namespace Wx.Core.Clients
{
    public class WooliesXService : IWooliesXService
    {
        public readonly WxConfig _config;

        public readonly string _url;

        public WooliesXService(WxConfig wxConfig)
        {
            _config = wxConfig;

            _url = _config.WolliesXEndPoint;
        }

        public List<Product> GetProducts()
        {
            string resource = "resource/products";

            var qs = "?token=" + _config.Token;

            string url = string.Format("{0}{1}{2}", _url, resource, qs);

            using (WebClient wc = new WebClient())
            {
                var result = wc.DownloadString(url);

                var products = JsonConvert.DeserializeObject<List<Product>>(result);

                return products;
            }

        }
        public List<CustomerShopperHistory> GetShopperHistory()
        {
            string resource = "resource/shopperHistory";

            var qs = "?token=" + _config.Token;

            string url = string.Format("{0}{1}{2}", _url, resource, qs);

            using (WebClient wc = new WebClient())
            {
                var result = wc.DownloadString(url);

                var shoppingHistory = JsonConvert.DeserializeObject<List<CustomerShopperHistory>>(result);

                return shoppingHistory;
            }

        }

        public decimal RequestTrolleyPrice(TrolleyCalculatorRequest req)
        {
            string resource = "resource/trolleyCalculator";

            var qs = "?token=" + _config.Token;

            string url = string.Format("{0}{1}{2}", _url, resource, qs);

            var requestBody = JsonConvert.SerializeObject(req);

            using (WebClient wc = new WebClient())
            {
                wc.Headers["Content-Type"] = "application/json";

                var result = wc.UploadString(url, requestBody);

                decimal price = 0;

                decimal.TryParse(result, out price);

                return price;
            }

        }
    }
}
