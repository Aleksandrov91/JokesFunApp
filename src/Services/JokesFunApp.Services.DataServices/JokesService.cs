namespace JokesFunApp.Services.DataServices
{
    using JokesFunApp.Data.Common;
    using JokesFunApp.Data.Models;
    using JokesFunApp.Services.Mapping;
    using JokesFunApp.Services.Models.Home;
    using JokesFunApp.Services.Models.Jokes;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class JokesService : IJokesService
    {
        private readonly IRepository<Joke> jokesRepository;
        private readonly IRepository<Category> categoriesRepository;

        public JokesService(
            IRepository<Joke> jokesRepository,
            IRepository<Category> categoriesRepository)
        {
            this.jokesRepository = jokesRepository;
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<IndexJokeViewModel> GetRandomJokes(int count)
        {
            var jokes = this.jokesRepository.All()
                .OrderBy(x => Guid.NewGuid())
                .To<IndexJokeViewModel>()
                .Take(count).ToList();

            return jokes;
        }

        public async Task<int> Create(int categoryId, string content)
        {
            var joke = new Joke
            {
                CategoryId = categoryId,
                Content = content
            };

            await this.jokesRepository.AddAsync(joke);
            await this.jokesRepository.SaveChangesAsync();

            return joke.Id;
        }

        public JokesDetailsViewModel GetJokeById(int id)
        {
            var joke = this.jokesRepository.All()
                .Where(x => x.Id == id)
                .To<JokesDetailsViewModel>()
                .FirstOrDefault();

            return joke;
        }
    }
}
