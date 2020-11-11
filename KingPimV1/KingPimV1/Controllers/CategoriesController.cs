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
    public class CategoriesController : Controller
    {
        private readonly IDataRepository repo;

        public CategoriesController(IDataRepository repository)
        {
            repo = repository;
        }


        public IActionResult Index()
        {
            var vm = new CategoriesViewModel();

            var listOfCategories = repo.GetCategories(true).ToList();

            vm.AllCategories = listOfCategories;

            return View(vm);
        }


        public IActionResult CreateNewCategory(CategoriesViewModel vm)
        {
            repo.AddCategory(vm);
            return RedirectToAction("Index", "Categories");
        }


        public IActionResult CreateNewSubCategory(int CategoryId, string SubCategoryName)
        {
            repo.AddNewSubCategory(CategoryId, SubCategoryName);

            return RedirectToAction("Index", "Categories");
        }


        public IActionResult EditCategoryName(int CategoryId, string CategoryName)
        {
            repo.UpdateCategoryName(CategoryId, CategoryName);
            return RedirectToAction("Index", "Categories");
        }


        public IActionResult DeleteCategory(int DeleteCategoryId)
        {
            repo.DeleteCat(DeleteCategoryId);
            return RedirectToAction("Index", "Categories");
        }
    }
}

