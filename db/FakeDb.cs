using burger_shack_api.Models;
using System.Collections.Generic;
namespace burger_shack_api.db
{
    public class FakeDb
    {
        public static List<Burger> Burgers { get; set; } = new List<Burger>();          
    }
}