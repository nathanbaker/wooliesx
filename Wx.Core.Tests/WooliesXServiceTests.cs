using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Wx.Core.Clients;
using Wx.Core.Configuration;
using Wx.Core.Models;
using Xunit;

namespace Wx.Core.Tests
{
    public class WooliesXServiceTests
    {
        [Fact]
        public void GetProducts_Returns_Products()
        {
            var wxConfig = new WxConfig()
            {
                Token = "c8e0d9d2-7d0d-4aa4-8cf1-a48c40384988",
                WolliesXEndPoint = "http://dev-wooliesx-recruitment.azurewebsites.net/api/"
            };

            var service = new WooliesXService(wxConfig);

            var result = service.GetProducts();

            Assert.NotNull(result);
        }

        [Fact]
        public void GetShopperHistory_Returns_ShopperHistory()
        {
            var wxConfig = new WxConfig()
            {
                Token = "c8e0d9d2-7d0d-4aa4-8cf1-a48c40384988",
                WolliesXEndPoint = "http://dev-wooliesx-recruitment.azurewebsites.net/api/"
            };

            var service = new WooliesXService(wxConfig);

            var result = service.GetShopperHistory();

            Assert.NotNull(result);
        }

        [Fact]
        public void RequestTrolleyPrice_Returns_Correct_Value()
        {
            var wxConfig = new WxConfig()
            {
                Token = "c8e0d9d2-7d0d-4aa4-8cf1-a48c40384988",
                WolliesXEndPoint = "http://dev-wooliesx-recruitment.azurewebsites.net/api/"
            };

            var service = new WooliesXService(wxConfig);
            var exampleRequestJson = @"{
                  'products': [
                    {
                      'name': 'product1',
                      'price': 100
                    }
                  ],
                  'specials': [
                    {
                      'quantities': [
                        {
                          'name': 'sepcial',
                          'quantity': 13
                        }
                      ],
                      'total': 15
                    }
                  ],
                  'quantities': [
                    {
                      'name': 'string',
                      'quantity': 10
                    }
                  ]
                }";

            var req =  JsonConvert.DeserializeObject<TrolleyCalculatorRequest>(exampleRequestJson);

            var result = service.RequestTrolleyPrice(req);

            var expected = 0;

           Assert.Equal<decimal>(expected, result);
        }
    }
}
