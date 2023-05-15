using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MovieLibraryEntities.Models;
using System.Linq;

namespace MovieLibraryEntities.Context
{
    public class MovieContext : DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserMovie> UserMovies { get; set; }

        readonly ILogger _logger;
        public MovieContext()
        {   // Could not figure out "AddFile" error -- it caused everything to not work, thus I submitted without the logger functioning
            var factory = LoggerFactory.Create(m => m.AddFile("logger.log"));
            _logger = factory.CreateLogger<MovieContext>();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder
                .LogTo(action => _logger.LogInformation(action), LogLevel.Information)
                .UseLazyLoadingProxies()
                .UseSqlServer(configuration.GetConnectionString("MovieContext")
            );
        }
    }
}