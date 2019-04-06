namespace JokesFunApp.Services.DataServices
{
    using JokesFunApp.Services.Models.Categories;
    using System.Collections.Generic;

    public interface ICategoriesService
    {
        IEnumerable<CategoryIdAndNameViewModel> GetAll();

        bool IsCategoryIdValid(int categoryId);
    }
}