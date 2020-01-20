using System.Collections.Generic;
using Wx.Core.Models;

namespace Wx.Core.Clients
{
    public interface IWooliesXService
    {
        List<Product> GetProducts();
        List<CustomerShopperHistory> GetShopperHistory();
        decimal RequestTrolleyPrice(TrolleyCalculatorRequest req);
    }
}