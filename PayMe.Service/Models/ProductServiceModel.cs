using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayMe.Service.Models;

namespace PayMe.Service.Models
{
    public class ProductServiceListModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }

    public class ProductServiceInfoModel : SharedServiceModel
    {
        public List<ProductServiceListModel> ProductData { get; set; }
    }
}
