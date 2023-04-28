using Microsoft.AspNetCore.Mvc;

namespace WebshopAPI.Lib.Services
{
    public class ProductManagerService
    {

        public ProductManagerService() { }

        public async Task AddProduct(Product product)
        {
            using (SQL sql = new SQL())
            {
                if (sql.Products.Any(a => a.Name == product.Name))
                {
                    Product p = sql.Products.Single(a => a.Name == product.Name);
                    p.Stock += product.Stock;
                    await sql.SaveChangesAsync();
                }
                else
                {
                    await sql.Products.AddAsync(product);
                    await sql.SaveChangesAsync();
                }
            }
        }

        public async Task UpdateProduct(Product product)
        {
            using (SQL sql = new SQL())
            {
                if (!sql.Products.Any(a => a.Name == product.Name))
                {
                    throw new ProductNotFoundException();
                }
                ObjectValidatorService<Product> prod = new ObjectValidatorService<Product>(product);
                prod.IsValid();
                Product oldProduct = sql.Products.Single(a => a.Name == product.Name);
                oldProduct.Name = product.Name;
                oldProduct.Description = product.Description;
                oldProduct.Stock = product.Stock;
                oldProduct.Price = product.Price;

                await sql.SaveChangesAsync();
            }
        }
    }
}

