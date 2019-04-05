namespace JokesFunApp.Services.DataServices
{
    using JokesFunApp.Services.Models;

    using System.Collections.Generic;

    public interface ICategoriesService
    {
        IEnumerable<IdAndNameViewModel> GetAll();

        bool IsCategoryIdValid(int categoryId);
    }
}