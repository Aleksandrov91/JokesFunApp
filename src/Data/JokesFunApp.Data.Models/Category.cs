namespace JokesFunApp.Data.Models
{
    using JokesFunApp.Data.Common;

    using System.Collections.Generic;

    public class Category : BaseModel<int>
    {
        public Category()
        {
            this.Jokes = new HashSet<Joke>();
        }

        public string Name { get; set; }

        public virtual ICollection<Joke> Jokes { get; set; }
    }
}
