namespace JokesFunApp.Services.Models.Categories
{
    using AutoMapper;

    using JokesFunApp.Data.Models;
    using JokesFunApp.Services.Mapping;

    using System.Linq;

    public class CategoryIdAndNameViewModel : IMapFrom<Category>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NameAndCount => $"{this.Name} ({this.CoutOfAllJokes})";

        //JokesCount will be working without custom mapping
        public int CoutOfAllJokes { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Category, CategoryIdAndNameViewModel>()
                .ForMember(x => x.CoutOfAllJokes,
                m => m.MapFrom(c => c.Jokes.Count()));
        }
    }
}
