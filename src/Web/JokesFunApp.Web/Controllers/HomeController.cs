namespace JokesFunApp.Web.Controllers
{
    using JokesFunApp.Services.DataServices;
    using JokesFunApp.Services.Models;
    using JokesFunApp.Services.Models.Home;

    using Microsoft.AspNetCore.Mvc;

    using System.Diagnostics;

    public class HomeController : BaseController
    {
        private readonly IJokesService jokesService;

        public HomeController(IJokesService jokesService)
        {
            this.jokesService = jokesService;
        }

        public IActionResult Index()
        {
            var jokes = this.jokesService.GetRandomJokes(20);

            var viewModel = new IndexViewModel
            {
                Jokes = jokes
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
