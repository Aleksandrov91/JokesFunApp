namespace JokesFunApp.Web.Controllers
{
    using JokesFunApp.Services.DataServices;
    using JokesFunApp.Web.Models.Jokes;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    using System.Linq;
    using System.Threading.Tasks;

    public class JokesController : BaseController
    {
        private readonly IJokesService jokesService;
        private readonly ICategoriesService categoriesService;

        public JokesController(
            IJokesService jokesService,
            ICategoriesService categoriesService)
        {
            this.jokesService = jokesService;
            this.categoriesService = categoriesService;
        }

        [Authorize]
        public IActionResult Create()
        {
            this.ViewData["Categories"] = this.categoriesService.GetAll()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.NameAndCount
                });

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateJokeInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var id = await this.jokesService.Create(input.CategoryId, input.Content);

            return this.RedirectToAction("View", new { id = id });
        }

        public IActionResult Details(int id)
        {
            var joke = this.jokesService.GetJokeById(id);

            return this.View(joke);
        }
    }
}