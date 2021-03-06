using Microsoft.AspNetCore.Mvc;
using PethanyApplication.Models;
using PethanyApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PethanyApplication.Controllers
{

    public class HomeController : Controller
    {
        private readonly IPieRepository pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            this.pieRepository = pieRepository;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel()
            {
                PiesOfTheWeek = pieRepository.PiesOfTheWeek()
            };
            return View(homeViewModel);
        }
    }
}

//session id -- by default - session can be accessed by http

//cookie
