namespace JokesFunApp.Web.Controllers
{
    using JokesFunApp.Services.DataServices;
    using JokesFunApp.Services.Models.Jokes;
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
        private readonly IHtmlSanitizerService htmlSanitizerService;

        public JokesController(
            IJokesService jokesService,
            ICategoriesService categoriesService,
            IHtmlSanitizerService htmlSanitizerService)
        {
            this.jokesService = jokesService;
            this.categoriesService = categoriesService;
            this.htmlSanitizerService = htmlSanitizerService;
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

            var sanitizedContent = this.htmlSanitizerService.Sanitize(input.Content);

            var id = await this.jokesService.Create(input.CategoryId, sanitizedContent);

            return this.RedirectToAction(nameof(Details), new { id });
        }

        public IActionResult Details(int id)
        { 
            var joke = this.jokesService.GetJokeById<JokeDetailsViewModel>(id);

            return this.View(joke);
        }
    }
}