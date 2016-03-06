using System.Collections.Generic;

namespace ExpandingMenu.Models
{
    /// <summary>
    /// Category class.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        /// <value>The name of the category.</value>
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the movies.
        /// </summary>
        /// <value>The movies.</value>
        public List<Movie> Movies { get; set; }
    }
}