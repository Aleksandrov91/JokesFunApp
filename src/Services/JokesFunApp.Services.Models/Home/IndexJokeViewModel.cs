namespace JokesFunApp.Services.Models.Home
{
    using AutoMapper;

    using JokesFunApp.Data.Models;
    using JokesFunApp.Services.Mapping;

    public class IndexJokeViewModel : IMapFrom<Joke>, IMapTo<Joke>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string HtmlContent => this.Content.Replace("\n", "<br />\n");

        public string CategoryName { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //configuration.CreateMap<Joke, IndexViewModel>()
            //    .ForMember(x => this.CategoryName, x => x.MapFrom(j => j.Category.Name));
        }
    }
}
