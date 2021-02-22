using System.ComponentModel.DataAnnotations;

namespace burger_shack_api.Models
{
    public class Burger
    {
    public Burger()
    {
    }

        [Required]
        public string name { get; set; }
        [Required]
        public decimal price { get; set; }
        [Required]
        public string description { get; set; }
        public int id { get; set; }
    }
}