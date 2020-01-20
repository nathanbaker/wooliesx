using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wx.Core.Clients;
using Wx.Core.Configuration;
using Wx.Core.Models;

namespace Wx.WebApiNET.Controllers
{
    [Route("api/answers/sort")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        public WooliesXService service; 

        public ShoppingController(IOptionsMonitor<WxConfig> wxConfig)
        {
            service = new WooliesXService(wxConfig.CurrentValue);
        }

        public IList<Product> Get(string sortOption)
        {
            List<Product> sortedResult = service.GetProducts();

            if (!string.IsNullOrWhiteSpace(sortOption))
            {
                if (sortOption == SortOption.Low.ToString()) // Order by Price
                {
                    return sortedResult.OrderBy(t => t.price).ToList(); 
                }
                else if (sortOption == SortOption.High.ToString())
                {
                    return sortedResult.OrderByDescending(t => t.price).ToList();
                }
                else if (sortOption == SortOption.Ascending.ToString())
                {
                    return sortedResult.OrderBy(t => t.name).ToList();
                }
                else if (sortOption == SortOption.Descending.ToString())
                {
                    return sortedResult.OrderByDescending(t => t.name).ToList();
                }
                else if (sortOption == SortOption.Recommended.ToString())
                {
                    return GetPopularProducts();
                }
            }

            return sortedResult;
        }

        private List<Product> GetPopularProducts()
        {

            List<CustomerShopperHistory> result = service.GetShopperHistory();

            var sortedResult = new List<Product>();

            foreach (var history in result)
            {
                foreach (var product in history.products)
                {
                    if (!sortedResult.Select(t => t.name).Contains(product.name))
                    {
                        sortedResult.Add(product);
                    }
                    else
                    {
                        // extract and append quantity
                        sortedResult.Where(t => t.name == product.name).First().quantity += product.quantity;
                    }
                }
            }

            return sortedResult.OrderByDescending(t => t.quantity).ToList();
        }


        public enum SortOption {
            Low,
            High,
            Ascending,
            Descending,
            Recommended
        }

    }
}
