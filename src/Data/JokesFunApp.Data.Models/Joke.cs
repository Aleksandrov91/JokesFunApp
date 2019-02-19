namespace JokesFunApp.Data.Models
{
    using Common;

    public class Joke : BaseModel<int>
    {
        public string Content { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
