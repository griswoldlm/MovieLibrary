using Microsoft.Extensions.Logging;
using MovieLibraryEntities.Dao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieLibraryEntities.Models;
using MovieLibraryEntities.Context;

namespace MovieLibraryEntities.Services
{
    public class MainService : IMainService
    {
        private readonly ILogger<MainService> _logger;
        private readonly IRepository _repository;

        public MainService(ILogger<MainService> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public void Invoke()
        {
            var movie = new MovieContext();

        }
    }
}
