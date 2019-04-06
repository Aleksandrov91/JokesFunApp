namespace JokesFunApp.Services.Models.Jokes
{
    using JokesFunApp.Data.Models;
    using JokesFunApp.Services.Mapping;

    public class JokesDetailsViewModel : IMapFrom<Joke>
    {
        public string Content { get; set; }

        public string CategoryName { get; set; }
    }
}
