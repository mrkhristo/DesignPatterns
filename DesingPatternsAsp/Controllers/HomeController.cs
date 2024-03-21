using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using DesingPatternsAsp.Configuration;
using DesingPatternsAsp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using Tools;

namespace DesingPatternsAsp.Controllers
{
    public class HomeController : Controller
    {
        //dependency injection
        private readonly IOptions<MyConfig> _config;
        private readonly IRepository<Beer> _repository;

        public HomeController(
            IOptions<MyConfig> config, 
            IRepository<Beer> repository)
        {
            _config = config;
            _repository = repository;
        }

        public IActionResult Index()
        {
            //singleton
            //Log.GetInstance(_config.Value.PathLog).Save("Entro a Index");
            IEnumerable<Beer> beers = _repository.Get();

            return View("Index",beers);
        }

        public IActionResult Privacy()
        {
            //singleton
            //Log.GetInstance(_config.Value.PathLog).Save("Entro a Privacy");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}