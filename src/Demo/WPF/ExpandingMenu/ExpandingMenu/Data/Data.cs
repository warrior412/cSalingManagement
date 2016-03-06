using System.Collections.Generic;
using ExpandingMenu.Models;

namespace ExpandingMenu.Data
{
    /// <summary>
    /// Data class.
    /// </summary>
    public class Data
    {
        /// <summary>
        /// Loads the data.
        /// </summary>
        /// <returns>The categories.</returns>
        public static List<Category> LoadData()
        {
            var categories = new List<Category>
            {
                new Category
                    {
                        CategoryName = "Action / Sci-Fi",
                        Movies = new List<Movie>
                            {
                                new Movie
                                    {
                                        Title = "X-Men: First Class",
                                        Link = "http://www.imdb.com/title/tt1270798/",
                                        Director = "Matthew Vaughn"
                                    },
                                new Movie
                                    {
                                        Title = "Rise of the Planet of the Apes",
                                        Link = "http://www.imdb.com/title/tt1318514/",
                                        Director = "Rupert Wyatt"
                                    },
                                new Movie
                                    {
                                        Title = "Iron Man 2",
                                        Link = "http://www.imdb.com/title/tt1228705/",
                                        Director = "Jon Favreau"
                                    }
                            }
                    },                
                new Category
                    {
                        CategoryName = "Action / Thriller",
                        Movies = new List<Movie>
                            {
                                new Movie
                                    {
                                        Title = "The Amazing Spider-Man",
                                        Link = "http://www.imdb.com/title/tt0948470/",
                                        Director = "Marc Webb"
                                    },
                                new Movie
                                    {
                                        Title = "The Dark Knight Rises",
                                        Link = "http://www.imdb.com/title/tt1345836/",
                                        Director = "Christopher Nolan"
                                    },
                                new Movie
                                    {
                                        Title = "Captain America: The First Avenger",
                                        Link = "http://www.imdb.com/title/tt0458339/",
                                        Director = "Joe Johnston"
                                    }
                            }
                    },
                new Category
                    {
                        CategoryName = "Adventure",
                        Movies = new List<Movie>
                            {
                                new Movie
                                    {
                                        Title = "Harry Potter and the Deathly Hallows: Part 2",
                                        Link = "http://www.imdb.com/title/tt1201607/",
                                        Director = "David Yates"
                                    },
                                new Movie
                                    {
                                        Title = "The Adventures of Tintin",
                                        Link = "http://www.imdb.com/title/tt0983193/",
                                        Director = "Steven Spielberg"
                                    },
                                new Movie
                                    {
                                        Title = "Transformers: Dark of the Moon",
                                        Link = "http://www.imdb.com/title/tt1399103/",
                                        Director = "Michael Bay"
                                    },
                                new Movie
                                    {
                                        Title = "The Hobbit: An Unexpected Journey",
                                        Link = "http://www.imdb.com/title/tt0903624/",
                                        Director = "Peter Jackson"
                                    }
                            }
                    },
                new Category
                    {
                        CategoryName = "Comedy / Romance",
                        Movies = new List<Movie>
                            {
                                new Movie
                                    {
                                        Title = "Midnight in Paris",
                                        Link = "http://www.imdb.com/title/tt1605783/",
                                        Director = "Woody Allen"
                                    },
                                new Movie
                                    {
                                        Title = "The Hangover",
                                        Link = "http://www.imdb.com/title/tt1119646/",
                                        Director = "Todd Phillips"
                                    }
                            }
                    },
                new Category
                    {
                        CategoryName = "Mystery",
                        Movies = new List<Movie>
                            {
                                new Movie
                                    {
                                        Title = "Source Code",
                                        Link = "http://www.imdb.com/title/tt0945513/",
                                        Director = "Duncan Jones"
                                    },
                                new Movie
                                    {
                                        Title = "Super 8",
                                        Link = "http://www.imdb.com/title/tt1650062/",
                                        Director = "J.J. Abrams"
                                    },
                                new Movie
                                    {
                                        Title = "Black Swan",
                                        Link = "http://www.imdb.com/title/tt0947798/",
                                        Director = "Darren Aronofsky"
                                    }
                            }
                    },
            };

            return categories;
        }
    }
}