namespace JokesFunApp.Services.DataServices
{
    using JokesFunApp.Data.Common;
    using JokesFunApp.Data.Models;
    using JokesFunApp.Services.Models.Home;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class JokesService : IJokesService
    {
        private readonly IRepository<Joke> jokesRepository;

        public JokesService(IRepository<Joke> jokesRepository)
        {
            this.jokesRepository = jokesRepository;
        }

        public IEnumerable<IndexJokeViewModel> GetRandomJokes(int count)
        {
            var jokes = this.jokesRepository.All()
                .OrderBy(x => Guid.NewGuid())
                .Select(x => new IndexJokeViewModel
                {
                    Content = x.Content,
                    CategoryName = x.Category.Name
                }).Take(count).ToList();

            return jokes;
        }
    }
}
