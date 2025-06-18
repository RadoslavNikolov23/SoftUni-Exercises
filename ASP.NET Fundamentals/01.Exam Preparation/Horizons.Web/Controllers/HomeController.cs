﻿namespace Horizons.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using ViewModels;

    public class HomeController : BaseController
    {

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            try
            {
                if (this.IsAuthenticated())
                {
                    return this.RedirectToAction(nameof(Index), "Destination");
                }
                return this.View();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
