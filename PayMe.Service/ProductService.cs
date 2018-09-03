using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayMe.Service.Contract;
using PayMe.Service.Models;
using PayMe.Model;
using PayMe.Repository.Contract;
using PayMe.Repository;

namespace PayMe.Service
{
    public class ProductService : IProductService
    {
        private IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository )
        {
            _productRepository = productRepository;
        }
        public ProductServiceInfoModel GetProductListData()
        {
            ProductServiceInfoModel rModel = new ProductServiceInfoModel();
            try
            {
                rModel.ProductData = _productRepository.GetAll().Select(x => new ProductServiceListModel
                {
                    Id = x.Id,
                    Description = x.Description.Trim(),
                    Name = x.Name.Trim(),
                    Price = Convert.ToInt32(x.Price),
                    Stock = x.Stock
                }).ToList();
                rModel.Success = true;
                rModel.Update = false;
                rModel.Id = 0;
                return rModel;
            }
            catch(Exception error)
            {
                rModel.Success = false;
                rModel.Update = false;
                rModel.Id = 0;
                return rModel;
            }
        }
    }
}
