namespace JokesFunApp.Services.DataServices
{
    using JokesFunApp.Services.Models.Home;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IJokesService
    {
        IEnumerable<IndexJokeViewModel> GetRandomJokes(int count);

        Task<int> Create(int categoryId, string content);

        TViewModel GetJokeById<TViewModel>(int id);
    }
}
