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
            Console.WriteLine("Hello User, Would you like to... \n0.Exit Program\n1.Add Movie\n2.Search Movie\n3.Update Movie\n4.Delete Movie");
            var choice = Console.ReadLine();

            do
            {
                // 1. Add Movie (C)
                if (choice == "1")
                {
                    MenuActions addmovie = new MenuActions();
                    addmovie.Add();
                }

                // 2. Search Movie (R)
                else if (choice == "2")
                {
                    MenuActions searchmovie = new MenuActions();
                    searchmovie.Search();
                }

                // 3. Update Movie (U)
                else if (choice == "3")
                {
                    MenuActions updatemovies = new MenuActions();
                    updatemovies.Update();
                }

                // 4. Delete Movie (D)
                else if (choice == "4")
                {
                    MenuActions deletemovie = new MenuActions();
                    deletemovie.Delete();
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