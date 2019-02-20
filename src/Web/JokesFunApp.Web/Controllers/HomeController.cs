using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JokesFunApp.Web.Models;

namespace JokesFunApp.Web.Controllers
{
    using Data.Common;
    using Data.Models;
    using Models.Home;

    public class HomeController : Controller
    {
        private readonly IRepository<Joke> jokesRepository;

        public HomeController(IRepository<Joke> jokesRepository)
        {
            this.jokesRepository = jokesRepository;
        }

        public IActionResult Index()
        {
            var jokes = this.jokesRepository.All()
                .OrderBy(x => Guid.NewGuid())
                .Select(x => new IndexJokeViewModel
                {
                    Content = x.Content,
                    CategoryName = x.Category.Name
                }).Take(20);

            var viewmodel = new IndexViewModel
            {
                Jokes = jokes
            };

            return this.View(viewmodel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
