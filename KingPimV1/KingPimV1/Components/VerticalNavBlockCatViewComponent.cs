using KingPimV1.DB;
using KingPimV1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPimV1.Components
{
    public class VerticalNavBlockCatViewComponent : ViewComponent
    {
        private KingPimDatabaseContext ctx;
        public VerticalNavBlockCatViewComponent(KingPimDatabaseContext context)
        {
            ctx = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var vm = new CategoriesViewModel();

            var listOfCategories = await ctx.Categories.Include(x => x.SubCategories).ToListAsync();

            vm.AllCategories = listOfCategories;

            return View(vm);
        }
    }
}
