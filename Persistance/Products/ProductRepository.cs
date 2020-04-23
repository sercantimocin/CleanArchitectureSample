using Common.Model;
using Infrastucture.Persistance;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Products;

namespace Persistance.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataHelper _dataHelper;

        public ProductRepository(IDataHelper dataHelper)
        {
            _dataHelper = dataHelper;
        }

        public Task<ProductEntity> GetProduct(int id)
        {
            string sql = "SELECT * FROM PRODUCT WHERE Id = @Id";

            return _dataHelper.QuerySingleAsync<ProductEntity>(sql, new { id });
        }
    }
}
