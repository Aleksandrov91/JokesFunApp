namespace JokesFunApp.Services.Models.Jokes
{
    using JokesFunApp.Data.Models;
    using JokesFunApp.Services.Mapping;

    public class JokeDetailsViewModel : IMapFrom<Joke>
    {
        public string Content { get; set; }

        public string HtmlContent => this.Content.Replace("\n", "<br />\n");

        public string CategoryName { get; set; }
    }
}
