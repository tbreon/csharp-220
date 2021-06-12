using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using homework06.Models;

namespace homework06.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BirthdayCard()
        {
            return View(new GuestResponse());
        }
        [HttpPost]
        public IActionResult BirthdayCard(Models.GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", guestResponse);
            }
            else
            {
                return View(guestResponse);
            }
        }

        // Product Action

    }
}
