using KingPimV1.Models;
using KingPimV1.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPimV1.Repositories
{
    public interface IDataRepository
    {
        IEnumerable<Category> Categories { get; }
        IEnumerable<Subcategory> Subcategories { get; }
        IEnumerable<Product> Products { get; }


        IEnumerable<Category> GetCategories(bool includeSubCategories);
        IEnumerable<Subcategory> GetSubCategories(bool includeProducts);
        IEnumerable<Product> GetProducts(bool includeModifiedBy);


        Subcategory GetSubCategoryById(int id);


        void AddCategory(CategoriesViewModel vm);
        void AddNewSubCategory(int CategoryId, string SubCategoryName);
        void AddNewProduct(Product p);


        void UpdateCategoryName(int CategoryId, string CategoryName);
        void UpdateSubCategoryName(int SubCategoryId, string SubCategoryName, int CategoryId);
        void SaveProduct(Product p, string userName);


        void DeleteCat(int DeleteCategoryId);
        void DeleteSubCat(int DeleteSubCategoryId);
        void DeleteProduct(int productId);


        void UpdatePublishProduct(int ProductId);
        void UpdateUnPublishProduct(int ProductId);


    }
}
