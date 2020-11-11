using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPimV1.DB;
using KingPimV1.Models;
using KingPimV1.Repositories;
using KingPimV1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KingPimV1.Controllers
{
    [Authorize]
    public class SubcategoriesController : Controller
    {
        private readonly IDataRepository repo;

        public SubcategoriesController(IDataRepository repository)
        {
            repo = repository;
        }


        [Route("AllSubcategories/CategoryId/{categoryid:int}")]
        public IActionResult Index(int categoryid)
        {
            var vm = new SubcategoriesViewModel();

            var categoryName = repo.Categories.Where(x => x.Id == categoryid).FirstOrDefault();
            var listOfSubCategories = repo.GetSubCategories(true).Where(x => x.CategoryId == categoryid).ToList();

            vm.AllSubCategories = listOfSubCategories;
            vm.Category = categoryName;

            return View(vm);
        }


        public IActionResult CreateNewSubCategory(int CategoryId, string SubCategoryName)
        {
            repo.AddNewSubCategory(CategoryId, SubCategoryName);
            return RedirectToAction("Index", "Subcategories", new { categoryId = CategoryId });
        }


        [HttpPost]
        public IActionResult EditSubCategory(int SubCategoryId, string SubCategoryName, int CategoryId)
        {
            var SubCatToUpdate = repo.Subcategories.Where(x => x.Id == SubCategoryId).FirstOrDefault();

            SubCatToUpdate.Name = SubCategoryName;

            repo.UpdateSubCategoryName(SubCategoryId, SubCategoryName, CategoryId);

            return RedirectToAction("Index", "Subcategories", new { categoryId = CategoryId });
        }


        public IActionResult DeleteSubCategory(int DeleteSubCategoryId, int CategoryId)
        {
            repo.DeleteSubCat(DeleteSubCategoryId);
            return RedirectToAction("Index", "Subcategories", new { categoryId = CategoryId });
        }
    }
}