using Microsoft.EntityFrameworkCore;
using MovieLibraryEntities.Context;
using MovieLibraryEntities.MenuActions;
using MovieLibraryEntities.Models;
using System.ComponentModel;
using System.Reflection.Metadata;
using System.Linq;

namespace Griswold_A4_Movie_Library_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Menu
            Console.WriteLine("******MENU******\n0.Exit Program\n1.Add Movie\n2.Search Movie\n3.Update Movie\n4.Delete Movie");
            var choice = Console.ReadLine();

            do
            {
                // 1. Add Movie (C)
                if (choice == "1")
                {
                    Actions addmovie = new Actions();
                    addmovie.AddMovie();
                    break;
                }

                // 2. Search Movie (R)
                else if (choice == "2")
                {
                    Actions searchmovie = new Actions();
                    searchmovie.SearchMovie();
                    break;
                }

                // 3. Update Movie (U)
                else if (choice == "3")
                {
                    Actions updatemovies = new Actions();
                    updatemovies.UpdateMovie();
                    break;
                }

                // 4. Delete Movie (D)
                else if (choice == "4")
                {
                    Actions deletemovie = new Actions();
                    deletemovie.DeleteMovie();
                    break;
                }

                // 0. Exit Program
                else if (choice == "0")
                {
                    Console.WriteLine("Exiting program.");
                    break;
                }

            } while (choice == "1" || choice == "2" || choice == "3" || choice == "4");
        }
    }
}