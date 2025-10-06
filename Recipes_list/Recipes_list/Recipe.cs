using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes_list
{
    public class Recipe
    {
        public string Title { get; set; } = "";
        public string Category { get; set; } = "";
        public string PrepTime { get; set; } = "";
        public List<string> Ingredients { get; set; } = new();
        public List<string> Instructions { get; set; } = new();
        public string Description { get; set; } = "";
        public string Image { get; set; } = "";


    }
}
