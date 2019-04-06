namespace JokesFunApp.Services.DataServices
{
    using JokesFunApp.Data.Common;
    using JokesFunApp.Data.Models;
    using JokesFunApp.Services.Mapping;
    using JokesFunApp.Services.Models.Categories;
    using System.Collections.Generic;
    using System.Linq;

    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> categoriesRepository;

        public CategoriesService(IRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<CategoryIdAndNameViewModel> GetAll()
        {
            var categories = this.categoriesRepository.All()
                .OrderBy(x => x.Name)
                .To<CategoryIdAndNameViewModel>()
                .ToList();

            return categories;
        }

        public bool IsCategoryIdValid(int categoryId)
        {
            return this.categoriesRepository.All().Any(x => x.Id == categoryId);
        }
    }
}
