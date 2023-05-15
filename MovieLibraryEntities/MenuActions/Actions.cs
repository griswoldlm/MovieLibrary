using Microsoft.EntityFrameworkCore;
using MovieLibraryEntities.Context;
using MovieLibraryEntities.Models;
using MovieLibraryEntities.Dao;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Logging;
using Castle.Core.Logging;


namespace MovieLibraryEntities.MenuActions
{
    public class Actions
    {
        //readonly ILogger<IRepository> _logger;
        public void AddMovie()
        {
            using (var db = new MovieContext())
            {
                Console.WriteLine("Please enter a movie title: ");
                var title = Console.ReadLine();

                Console.WriteLine("Please enter movie release date (m/d/yyyy): ");
                var year = Convert.ToDateTime(Console.ReadLine());

                var movie = new Movie();
                movie.Title = title;
                movie.ReleaseDate = year;

                db.Movies.Add(movie);
                db.SaveChanges();
                Console.WriteLine($"ID: {movie.Id}, Title: {movie.Title}, Release Date: {movie.ReleaseDate}");

                //_logger.LogInformation("Movie has been added.");
            }
        }

        public void SearchMovie()
        {
            using (var db = new MovieContext())
            {
                Console.WriteLine("What title would you like to search?");
                var searchString = Console.ReadLine();

                List<Movie> movies = db.Movies.ToList().Where(m => m.Title.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                foreach(var movie in movies)
                {
                    Console.WriteLine($"Your search includes the following titles: \t{movie.Title}");
                }

                //_logger.LogInformation($"Movie(s) has been searched.");
            }
        }

        public void UpdateMovie()
        {

            Console.WriteLine("Please enter a movie title to update: ");
            var movieTitle = Console.ReadLine();

            using (var db = new MovieContext())
            {
                var mov = db.Movies.FirstOrDefault(x => x.Title == movieTitle);
                Console.WriteLine("Please enter the updated title: ");
                var movieUpdateTitle = Console.ReadLine();
                mov.Title = movieUpdateTitle;


                Console.WriteLine("Please enter the updated release date: ");
                DateTime year = Convert.ToDateTime(Console.ReadLine());
                mov.ReleaseDate = year;

                db.SaveChanges();
                Console.WriteLine($"ID: {mov.Id}, Title: {mov.Title}, Release Date: {mov.ReleaseDate}");

                //_logger.LogInformation($"Movie(s) has been updated.");
            }
        }
        public void DeleteMovie()
        {
            Console.WriteLine("Please enter a movie title to delete: ");
            var movieTitle = Console.ReadLine();

            using (var db = new MovieContext())
            {
                var mov = db.Movies.FirstOrDefault(x => x.Title == movieTitle);
                db.Movies.Remove(mov);
                db.SaveChanges();

                Console.WriteLine($"Movie Deleted: {mov.Title}");
               // _logger.LogInformation($"Movie(s) has been deleted.");
            }
        }
        public void DisplayMovies()
        {
            Console.WriteLine("How many movies would you like to display? ");
            int count = Convert.ToInt32(Console.ReadLine());

            using (var db = new MovieContext())
            {
                var movies = db.Movies.Take(count);

                //List<Movie> movies = db.Movies.OrderByDescending(m => m.Id).Where(m => m.Id == numberOfMovies).ToList();

                Console.WriteLine("The movies are as follows:");
                foreach (var mov in movies)
                {
                    Console.WriteLine($"ID: {mov.Id}, Title: {mov.Title}, Release Date: {mov.ReleaseDate}");
                }
               // _logger.LogInformation($"Movie(s) has been displayed.");
            }
        }
        public void AddUser()
        {
            using (var db = new MovieContext())
            {
                //var user = db.Users.Include(u => u.Occupation.Id);

                Console.WriteLine("Please enter the user's age: ");
                var age = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please enter the user's gender as F or M: ");
                var gender = Console.ReadLine();

                Console.WriteLine("Please enter the user's zip code: ");
                var zip = Console.ReadLine();

                //List all Occupations
                var occupations = db.Occupations;
                Console.WriteLine("Please choose the occupation that is closest to yours:");
                foreach (var occup in occupations)
                {
                    Console.WriteLine($"{occup.Id} {occup.Name}");
                }

                Console.WriteLine("Please enter the number of the user's occupation: ");
                var occupation = Convert.ToInt32(Console.ReadLine());

                var user = new User();
                user.Age = age;
                user.Gender = gender;
                user.ZipCode = zip;
                user.OccupationId = Convert.ToInt32(occupation);

                db.Users.Add(user);
                db.SaveChanges();

                Console.WriteLine($"ID: {user.Id}, Age: {user.Age}, Gender: {user.Gender}, Zip Code: {user.ZipCode}, Occupation: {user.Occupation.Name}");
               // _logger.LogInformation($"User has been added.");
            }
        }  
        public void UserMovieRate()
        {
            using (var db = new MovieContext())
            {
                Console.WriteLine("What would you rate the movie? (1 Bad - 5 Great)");
                var movieRating = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please enter the user ID for the person rating this title: ");
                var userId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please enter the movie ID: ");
                var movieId = Convert.ToInt32(Console.ReadLine());

                var userMovie = new UserMovie();
                userMovie.Rating = Convert.ToInt32(movieRating);
                userMovie.RatedAt = DateTime.Now;
                userMovie.UserId = Convert.ToInt32(userId);
                userMovie.MovieId = Convert.ToInt32(movieId);

                var movie = new Movie();

                db.UserMovies.Add(userMovie);
                db.SaveChanges();

                Console.WriteLine($"User ID: {userMovie.UserId}, Movie ID: {userMovie.MovieId}, Rating: {userMovie.Rating}, Rated At: {userMovie.RatedAt}");
                //_logger.LogInformation($"User has rated a movie.");
            }
        }
    }
}

