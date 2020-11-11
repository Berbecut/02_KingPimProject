using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPimV1.DB;
using KingPimV1.Models;
using KingPimV1.Repositories;
using KingPimV1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KingPimV1.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IDataRepository repo;

        private readonly UserManager<IdentityUser> _userManager;

        public ProductController(KingPimDatabaseContext contex, UserManager<IdentityUser> UserManager, IDataRepository repository)
        {
            _userManager = UserManager;
            repo = repository;
        }



        [Route("AllProducts/SubcategoryId/{subcategoryid:int}")]
        public IActionResult Index(int subcategoryId)
        {
            var vm = new ProductsViewModel();

            var products = repo.GetProducts(true).Where(x => x.SubcategoryId == subcategoryId);
            var subCategory = repo.GetSubCategoryById(subcategoryId);


            if (subCategory == null) return NotFound();

            subCategory.Products = products.ToList();
            vm.SubCategory = subCategory;
            vm.CategoryId = subCategory.CategoryId;

            return View(vm);
        }



        //int subCategoryId is from asp-route-subCategoryId="@subCat.Id" (from Subcategories/Index.cshtml, line 43)
        public IActionResult CreateProduct(int subCategoryId)
        {
            var product = new Product()
            {
                SubcategoryId = subCategoryId
            };

            return View(product);
        }


        [HttpPost]
        public IActionResult CreateNewProduct(Product p, string save)
        {
            if (!string.IsNullOrEmpty(save))
            {
                repo.AddNewProduct(p);
            }
            return RedirectToAction("Index", new { subcategoryId = p.SubcategoryId });
        }


        public IActionResult PublishProduct(int ProductId, int subcategoryId)
        {
            repo.UpdatePublishProduct(ProductId);

            return RedirectToAction("Index", "Product", new { SubcategoryId = subcategoryId });
        }


        public IActionResult UnPublishProduct(int ProductId, int subcategoryId)
        {
            repo.UpdateUnPublishProduct(ProductId);

            return RedirectToAction("Index", "Product", new { SubcategoryId = subcategoryId });
        }



        [HttpPost]
        // int SubCategoryId is from Product/Index.cshtml, line 132:  asp-route-SubCategoryId="@Model.SubCategory.Id" 
        public IActionResult Delete(int DeleteProductId, int SubCategoryId)
        {
            repo.DeleteProduct(DeleteProductId);

            return RedirectToAction(nameof(Index), new { subcategoryId = SubCategoryId });
        }


        // Delete Bulk
        [HttpPost]
        public IActionResult DeleteBulk(string productsIdToDelete, int SubCategoryId)
        {
            if (productsIdToDelete != null)
            {
                int[] productsIdToDeleteArray = Array.ConvertAll(productsIdToDelete.Split(','), int.Parse);

                foreach (var item in productsIdToDeleteArray)
                {
                    repo.DeleteProduct(item);
                }
            }
            return RedirectToAction(nameof(Index), new { subcategoryId = SubCategoryId });
        }


        [HttpGet]
        [Route("[controller]/[action]/{productId:int}/{subCategoryId:int}")]
        public IActionResult Edit(int productId, int subCategoryId)
        {
            var productToUpdate = repo.Products.Where(x => x.Id == productId).FirstOrDefault();

            var vm = new EditProductViewModel()
            {
                Product = productToUpdate,
                SubCategoryId = subCategoryId
            };

            return View(vm);
        }


        [HttpPost]
        [Route("[controller]/[action]", Name = "EditProduct")]
        public IActionResult Edit(EditProductViewModel vm)
        {
            repo.SaveProduct(vm.Product, User.Identity.Name);
            return RedirectToAction(nameof(Index), new { subcategoryId = vm.SubCategoryId });
        }
    }
}
