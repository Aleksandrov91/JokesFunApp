namespace JokesFunApp.Services.DataServices
{
    using JokesFunApp.Services.Models.Home;

    using System.Collections.Generic;

    public interface IJokesService
    {
        IEnumerable<IndexJokeViewModel> GetRandomJokes(int count);
    }
}
