namespace JokesFunApp.Services.DataServices
{
    using JokesFunApp.Services.Models.Home;
    using JokesFunApp.Services.Models.Jokes;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IJokesService
    {
        IEnumerable<IndexJokeViewModel> GetRandomJokes(int count);

        Task<int> Create(int categoryId, string content);

        JokesDetailsViewModel GetJokeById(int id);
    }
}
