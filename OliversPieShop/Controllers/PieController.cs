﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OliversPieShop.Models;
using OliversPieShop.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OliversPieShop.Controllers
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
        
        public ViewResult List(string category)
        {
            IEnumerable<Pie> pies;
            string currentCategory = string.Empty;
            //if statement can check for null or (null || = "all pies")
            if (string.IsNullOrEmpty(category))
            {
                pies = _pieRepository.Pies.OrderBy(p => p.PieId);
                currentCategory = "All pies";
            }
            else
            {
                pies = _pieRepository.Pies.Where(p => p.Category.CategoryName == category)
                .OrderBy(p => p.PieId);

                currentCategory = _categoryRepository.Categories.FirstOrDefault(c => c.CategoryName == category).CategoryName;          
            }

            return View(new PiesListViewModel
            {
                Pies = pies,
                CurrentCategory = currentCategory
            });
            //PiesListViewModel piesListViewModel = new PiesListViewModel();
            //piesListViewModel.Pies = _pieRepository.Pies;
            //piesListViewModel.CurrentCategory = "bacon bitz2";

            //return View(piesListViewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
            {
                return NotFound();
            }
            return View(pie);
        }
    }
}
