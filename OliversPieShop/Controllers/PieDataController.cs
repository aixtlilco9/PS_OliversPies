using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OliversPieShop.Models;
using OliversPieShop.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OliversPieShop.Controllers
{
    [Route("api/pieData")]
    public class PieDataController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public PieDataController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        [HttpGet("{category}/{pagecounter}")]
        public IEnumerable<PieViewModel> LoadMorePies(string category)
        {
            IEnumerable<Pie> dbPies = null;

            //originally what gil gave but does not filter based on category 
            //dbPies = _pieRepository.Pies.OrderBy(p => p.PieId).Take(2);
            if (string.IsNullOrEmpty(category) || category.ToUpper() == "ALL PIES")
            {
                dbPies = _pieRepository.Pies;

            }
            else
            {
                dbPies = _pieRepository.Pies.Where(p => p.Category.CategoryName == category);
            }

            List<PieViewModel> pies = new List<PieViewModel>();

            foreach (var dbPie in dbPies)
            {
                pies.Add(MapDbPieToPieViewModel(dbPie));
            }
            return pies;
        }

        private PieViewModel MapDbPieToPieViewModel(Pie dbPie)
        {
            return new PieViewModel()
            {
                PieId = dbPie.PieId,
                Name = dbPie.Name,
                Price = dbPie.Price,
                ShortDescription = dbPie.ShortDescription,
                ImageThumbNailUrl = dbPie.ImageThumbnailUrl
            };
        }
    }
}