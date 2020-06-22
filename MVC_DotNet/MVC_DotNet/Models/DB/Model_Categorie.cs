using OwlLibrary.Classes.Models.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DotNet.Models.DB
{
    public class Model_Categorie : Model_TableRecord
    {
        public Model_Categorie()
        {
            id = 0;
            table_name = "categories";
        }
        public int categorie_id { get; set; }
        public string categorie_name { get; set; }
    }
}
