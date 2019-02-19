namespace Sandbox
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using AngleSharp;
    using JokesFunApp.Data;
    using JokesFunApp.Data.Models;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"{typeof(Program).Namespace} ({string.Join(" ", args)}) starts working...");
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider(true);

            using (var serviceScope = serviceProvider.CreateScope())
            {
                serviceProvider = serviceScope.ServiceProvider;
                SandboxCode(serviceProvider);
            }
        }

        private static void SandboxCode(IServiceProvider serviceProvider)
        {
            var dbContext =  serviceProvider.GetService<JokesFunAppContext>();
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            for (var i = 3001; i <= 10000; i++)
            {
                var url = "http://fun.dir.bg/vic_open.php?id=" + i;
                var document = context.OpenAsync(url).GetAwaiter().GetResult();
                var jokeContent = document.QuerySelector("#newsbody")?.TextContent?.Trim();
                var categoryName = document.QuerySelector(".tag-links-left a")?.TextContent?.Trim();

                if (!string.IsNullOrWhiteSpace(jokeContent) && !string.IsNullOrWhiteSpace(categoryName))
                {
                    var category = dbContext.Categories.FirstOrDefault(x => x.Name == categoryName);

                    if (category == null)
                    {
                        category = new Category
                        {
                            Name = categoryName
                        };
                    }

                    var joke = new Joke
                    {
                        Category = category,
                        Content = jokeContent
                    };

                    dbContext.Jokes.Add(joke);
                }

                if (i % 10 == 0)
                {
                    dbContext.SaveChanges();
                }

                Console.WriteLine($"{i} => {categoryName}");
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();

            services.AddDbContext<JokesFunAppContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
