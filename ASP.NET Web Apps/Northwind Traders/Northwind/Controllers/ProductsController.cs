using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Northwind.Models;

namespace Northwind.Controllers
{
    public class ProductsController : Controller
    {
        private string baseURL = "https://localhost:44361/api/";

        private async Task<List<Category>> GetCategoriesAsync()
        {
            var categories = new List<Category>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                var response = await client.GetAsync($"categories");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    categories = JsonSerializer.Deserialize<List<Category>>(json);
                }
            }

            return categories;
        }

        
        // GET: ProductsController
        public async Task<IActionResult> Index(int categoryId = 1)
        {
            
            var categories = await GetCategoriesAsync();

            ViewBag.categoryId = new SelectList(categories, "categoryId", "categoryName");

            var products = new List<Product>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                var response = await client.GetAsync($"products/ByCategory/{categoryId}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    products = JsonSerializer.Deserialize<List<Product>>(json);
                }
            }

            return View(products);
        }

        [Authorize]
        // GET: ProductsController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var product = new Product();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                var response = await client.GetAsync($"products/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    product = JsonSerializer.Deserialize<Product>(json);
                }
                else
                {
                    return View("Error",
                    new ErrorViewModel
                    {
                        RequestId = $"Product id {id} not found."
                    });
                }
            }

            var categories = await GetCategoriesAsync();

            var category = categories.Find(x => x.categoryId == product.categoryId);

            ViewBag.categoryName = category.categoryName;

            return View(product);
        }

        

    }
}
