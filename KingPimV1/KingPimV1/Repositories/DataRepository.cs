using KingPimV1.DB;
using KingPimV1.Models;
using KingPimV1.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPimV1.Repositories
{
    public class DataRepository : IDataRepository
    {
        private KingPimDatabaseContext ctx;
        private readonly UserManager<IdentityUser> _userManager;

        public DataRepository(KingPimDatabaseContext context, UserManager<IdentityUser> UserManager)
        {
            ctx = context;
            _userManager = UserManager;
        }
        public IEnumerable<Product> Products => ctx.Products;
        public IEnumerable<Category> Categories => ctx.Categories;
        public IEnumerable<Subcategory> Subcategories => ctx.Subcategories;


        public IEnumerable<Category> GetCategories(bool includeSubCategories)
        {
            if (includeSubCategories)
                return ctx.Categories.Include(x => x.SubCategories);
            return ctx.Categories;
        }



        public IEnumerable<Subcategory> GetSubCategories(bool includeProducts)
        {
            if (includeProducts)
                return ctx.Subcategories.Include(x => x.Products);
            return ctx.Subcategories;
        }


        public Subcategory GetSubCategoryById(int id)
        {
            return ctx.Subcategories.Include(x => x.Products).FirstOrDefault(x => x.Id == id);
        }


        public IEnumerable<Product> GetProducts(bool includeModifiedBy)
        {
            if (includeModifiedBy)
                return ctx.Products.Include(x => x.ModifiedBy);
            return ctx.Products;
        }


        public void AddCategory(CategoriesViewModel vm)
        {
            ctx.Categories.Add(vm.Category);
            ctx.SaveChanges();
        }


        public void AddNewSubCategory(int CategoryId, string SubCategoryName)
        {
            var NewSubCategory = new Subcategory();
            NewSubCategory.Name = SubCategoryName;
            NewSubCategory.CategoryId = CategoryId;

            ctx.Subcategories.Add(NewSubCategory);
            ctx.SaveChanges();
        }


        public void UpdateCategoryName(int CategoryId, string CategoryName)
        {
            var CatToUpdate = ctx.Categories.Where(x => x.Id == CategoryId).FirstOrDefault();

            CatToUpdate.Name = CategoryName;

            ctx.Categories.Update(CatToUpdate).State = EntityState.Modified;
            ctx.SaveChanges();
        }


        public void DeleteCat(int DeleteCategoryId)
        {
            var CatToDelete = ctx.Categories.Find(DeleteCategoryId);

            ctx.Categories.Remove(CatToDelete);
            ctx.SaveChanges();
        }


        public void UpdateSubCategoryName(int SubCategoryId, string SubCategoryName, int CategoryId)
        {
            var SubCatToUpdate = ctx.Subcategories.Where(x => x.Id == SubCategoryId).FirstOrDefault();

            SubCatToUpdate.Name = SubCategoryName;

            ctx.Subcategories.Update(SubCatToUpdate).State = EntityState.Modified;
            ctx.SaveChanges();
        }


        public void DeleteSubCat(int DeleteSubCategoryId)
        {
            var SubCatToDelete = ctx.Subcategories.Find(DeleteSubCategoryId);

            ctx.Subcategories.Remove(SubCatToDelete);
            ctx.SaveChanges();
        }


        public void AddNewProduct(Product p)
        {
                p.DateCreated = DateTime.Now;
                ctx.Products.Add(p);
                ctx.SaveChanges();
        }


        public void UpdatePublishProduct(int ProductId)
        {
            var ProductToPublish = ctx.Products.Where(x => x.Id == ProductId).FirstOrDefault();
            ProductToPublish.Published = true;

            ctx.Products.Update(ProductToPublish).State = EntityState.Modified;
            ctx.SaveChanges();
        }


        public void UpdateUnPublishProduct(int ProductId)
        {
            var ProductToUnPublish = ctx.Products.Where(x => x.Id == ProductId).FirstOrDefault();
            ProductToUnPublish.Published = false;

            ctx.Products.Update(ProductToUnPublish).State = EntityState.Modified;
            ctx.SaveChanges();
        }


        public void DeleteProduct(int productId)
        {
            var ProductToDelete = ctx.Products.FirstOrDefault(x => x.Id.Equals(productId));

            if (ProductToDelete != null)
            {
                ctx.Products.Remove(ProductToDelete);
                ctx.SaveChanges();
            }
        }


        public void SaveProduct(Product p, string userName)
        {
            if (p.Id == 0)
            {
                ctx.Products.Add(p);
            }
            else
            {
                var ctxProduct = ctx.Products.Where(x => x.Id.Equals(p.Id)).FirstOrDefault();
                if (ctxProduct != null)
                {
                    ctxProduct.ArticleNumber = p.ArticleNumber;
                    ctxProduct.Name = p.Name;
                    ctxProduct.Price = p.Price;
                    ctxProduct.CampaignStartDate = p.CampaignStartDate;
                    ctxProduct.CampaignEndDate = p.CampaignEndDate;
                    ctxProduct.Discontinued = p.Discontinued;
                    ctxProduct.DiscountPercentage = p.DiscountPercentage;

                    var user = _userManager.FindByNameAsync(userName).Result;
                    ctxProduct.ModifiedBy = user;

                    ctxProduct.DateUpdated = DateTime.Now;

                    ctxProduct.StockBalance = p.StockBalance;
                    ctxProduct.Width = p.Width;
                    ctxProduct.Height = p.Height;
                    ctxProduct.Depth = p.Depth;
                    ctxProduct.Weight = p.Weight;
                }
                ctx.SaveChanges();
            }
        }
    }
}