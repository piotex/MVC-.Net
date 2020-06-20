using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DotNet.Models
{
    public class Model_Basket
    {
        public Model_Basket()
        {
            Logged = false;
            User = new Model_User();
            Basket = new List<Model_Product>();
        }
        public bool Logged { get; set; }
        public Model_User User { get; set; }
        public List<Model_Product> Basket { get; set; }
    }
}
