using Microsoft.AspNetCore.Mvc;
using PethanyApplication.Models;
using PethanyApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PethanyApplication.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List(string category)
        {
            PiesListViewModel piesListViewModel = new PiesListViewModel();
            piesListViewModel.Pies = _pieRepository.AllPies();

            if (category != null)
            {
                piesListViewModel.Pies = piesListViewModel.Pies.Where(p => p.Category.CategoryName == category);
            }

            piesListViewModel.CurrentCategory = "Cheese cakes";
            return View(piesListViewModel);
        }

        public IActionResult Details(int id)
        {
            var Pie = _pieRepository.GetPieById(id);
            if (Pie == null)
                return NotFound();

            return View(Pie);
        }
    }
}
