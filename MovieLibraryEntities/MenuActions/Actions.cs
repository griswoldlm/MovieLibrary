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

                Console.WriteLine("Please enter movie release year: ");
                DateTime year = Convert.ToDateTime(Console.ReadLine());

                var movie = new Movie();
                movie.Title = title;
                movie.ReleaseDate = year;

                db.Movies.Add(movie);
                db.SaveChanges();
                Console.WriteLine($"ID: {movie.Id}, Title: {movie.Title}, ReleaseDate: {movie.ReleaseDate}");
            }
        }

        public void SearchMovie()
        {
        }

        public void UpdateMovie()
        {

            {
                Console.WriteLine("Please enter a movie title to update: ");
                var movieTitle = Console.ReadLine();

                using (var db = new MovieContext())
                {
                    var mov = db.Movies.FirstOrDefault(x => x.Title == movie);
                    Console.WriteLine("Please enter the updated title: ");
                    var movieUpdateTitle = Console.ReadLine();
                    mov.Title = movieUpdateTitle;


                    Console.WriteLine("Please enter the updated release year: ");
                    DateTime year = Convert.ToDateTime(Console.ReadLine());
                    mov.ReleaseDate = year;

                    db.SaveChanges();
                    Console.WriteLine($"ID: {mov.Id}, Title: {mov.Title}, ReleaseDate: {mov.ReleaseDate}");
                }
            }
        }
        public void DeleteMovie()
        {
        }
    }
}


