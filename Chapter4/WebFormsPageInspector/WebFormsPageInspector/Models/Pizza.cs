using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormsPageInspector.Models
{
    public class Pizza
    {
        public PizzaSize Size { get; set; }
        public PizzaType Type { get; set; }
        public IEnumerable<string> Toppings { get; set; }
        public Pizza() {
            Size = PizzaSize.Large;
            Type = PizzaType.Regular;
        }
        public Pizza(string topping)
        {
            Size = PizzaSize.Large;
            Type = PizzaType.Regular;
            var toppings = new List<string>();
            toppings.Add(topping);
            Toppings = toppings;
        }
    }


    public enum PizzaSize { Small, Large, JerseySize };
    public enum PizzaType { ThinCrust, Regular, Sicilian, Deepdish, Grandma }
}