namespace JokesFunApp.Data.Models
{
    using Common;

    public class Category : BaseModel<int>
    {
        public string Name { get; set; }
    }
}
