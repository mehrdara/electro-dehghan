using identityMVC.Models;
using OnlineShop.Models;

namespace IdentityMVC.ViewModels
{
    class OrderViewModel
    {
        public IEnumerable<ProductItem> ProductItems { get; set; }
        public Order Order { get; set; }

    }
}