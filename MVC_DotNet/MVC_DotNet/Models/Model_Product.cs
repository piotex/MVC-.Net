using OwlLibrary.Classes.Models.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DotNet.Models
{
    public class Model_Product : Model_TableRecord
    {
        public Model_Product()
        {
            id = 0;
            table_name = "products";
        }

        public int _quantity_ { get; set; }
        public double _price_ { get; set; }
        public string _name_ { get; set; }
        public int _type_ { get; set; }

    }
}