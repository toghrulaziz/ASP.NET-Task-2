using ASP.NET_Task2.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Task2.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>()
        {
            new Product {Name = "Iphone 15", Description = "128 GB Green", Price = 2400, ImageUrl = "https://kontakt.az/media/catalog/product/cache/88174fa57c3607ad4c35922778a9d1bd/t/m/tm-dg-sbp-1105-sm-2471.png"},
            new Product {Name = "Iphone 15 Pro Max", Description = "512 GB Blue", Price = 4300, ImageUrl = "https://kontakt.az/media/catalog/product/cache/88174fa57c3607ad4c35922778a9d1bd/t/m/tm-dg-sbp-1105-sm-2520.png"},
            new Product {Name = "Samsung Galaxy S23 Ultra", Description = "(SM-S918B) 12/256 GB Black", Price = 2800, ImageUrl = "https://kontakt.az/media/catalog/product/cache/88174fa57c3607ad4c35922778a9d1bd/n/e/new_project_-_2023-02-13t170501.442.png"},
            new Product {Name = "Samsung Galaxy S22", Description = "(SM-S901B) Lavander", Price = 1400, ImageUrl = "https://kontakt.az/media/catalog/product/cache/88174fa57c3607ad4c35922778a9d1bd/n/e/new_project_-_2022-11-16t101848.541.png"},
            new Product {Name = "Notbuk Asus ROG Strix SCAR 16", Description = "G634JY-NM035 (2023) 90NR0D91-M002L0\r\n", Price = 8500, ImageUrl = "https://kontakt.az/media/catalog/product/cache/88174fa57c3607ad4c35922778a9d1bd/_/2/_27__13_11.png"},
            new Product {Name = "Notbuk Apple MacBook Pro 16", Description = "MNWE3RU/A Silver", Price = 8500, ImageUrl = "https://kontakt.az/media/catalog/product/cache/88174fa57c3607ad4c35922778a9d1bd/n/e/new-project-2023-02-17t101813.676-1_png_1.png"},
        };

        // GetAll 
        public IActionResult GetAll()
        {
            return View(products);
        }

        // Get 
        public IActionResult Get(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // Add 
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            var newProduct = new Product
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl
            };
            products.Add(newProduct);
            return RedirectToAction("GetAll");
        }

        // Update 
        public IActionResult Update(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        [HttpPost]
        public IActionResult Update(Product updatedProduct)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == updatedProduct.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = updatedProduct.Name;
                existingProduct.Description = updatedProduct.Description;
                existingProduct.Price = updatedProduct.Price;
                existingProduct.ImageUrl = updatedProduct.ImageUrl;
                
                return RedirectToAction("GetAll"); 
            }
            return NotFound();
        }

        // Delete 
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                products.Remove(product);
            }
            return RedirectToAction("GetAll");
        }
    }
}
