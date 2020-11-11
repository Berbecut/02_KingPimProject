using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KingPimV1.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error(int? statusCode = null)
        {
            var errorMessage = String.Empty;

            if (statusCode.HasValue)
            {
                if (statusCode.Value == 404)
                {
                    errorMessage = "Error 404";
                }
                else
                {
                    errorMessage = "Something was wrong..";
                }
            }
            ViewBag.ErrorMessage = errorMessage;
            return View(nameof(Error));
        }
    }
}