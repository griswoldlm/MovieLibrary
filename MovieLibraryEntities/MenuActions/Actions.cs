using Castle.DynamicProxy.Generators;
using MovieLibraryEntities.Context;
using MovieLibraryEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryEntities.MenuActions
{
    public class Actions
    {
        public void AddMovie()
        {

            using (var db = new MovieContext())
            {
                Console.WriteLine("Please enter a movie title: ");
                var title = Console.ReadLine();

                Console.WriteLine("Please enter movie release date: ");
                var year = Convert.ToDateTime(Console.ReadLine());

                var movie = new Movie();
                movie.Title = title;
                movie.ReleaseDate = year;

                db.Movies.Add(movie);
                db.SaveChanges();
                Console.WriteLine($"ID: {movie.Id}, Title: {movie.Title}, Release Date: {movie.ReleaseDate}");
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
                    Console.WriteLine($"Your search includes the following titles: \t{movie.Title} {movie.MovieGenres} {movie.ReleaseDate}");
                }

                //var movies = db.Movies;

                //Console.WriteLine("The movies are as follows:");
                //foreach (var mov in movies)
                //{
                //    Console.WriteLine($"ID: {mov.Id}, Title: {mov.Title}, Release Date: {mov.ReleaseDate}");
                //}
            }
        }

        public void UpdateMovie()
        {

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
                    
                }
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
            }
        }
    }
}


