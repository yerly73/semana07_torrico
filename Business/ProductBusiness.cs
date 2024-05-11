using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProductBusiness
    {
        public List<Product> Get()
        {
            ProductData data = new ProductData();
            var product = data.Get();
            return product;
        }
        public void InsertarProducto(Product product)
        {
            ProductData eProducto = new ProductData();
            eProducto.RegisterProduct(product);
        }
        public void eliminar(int ID_product)
        {
            ProductData eProducto = new ProductData();
            eProducto.eliminar(ID_product);
        }
    }
}
