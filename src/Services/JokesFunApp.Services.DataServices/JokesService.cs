namespace JokesFunApp.Services.DataServices
{
    using JokesFunApp.Data.Common;
    using JokesFunApp.Data.Models;
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
                .Select(x => new IndexJokeViewModel
                {
                    Id = x.Id,
                    Content = x.Content,
                    CategoryName = x.Category.Name
                }).Take(count).ToList();

            return jokes;
        }

        public async Task<int> Create(int categoryId, string content)
        {
            //TODO: Validate
            //category
            //joke

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
                .Select(x => new JokesDetailsViewModel
                {
                    Content = x.Content,
                    CategoryName = x.Category.Name
                }).FirstOrDefault();

            return joke;
        }
    }
}
