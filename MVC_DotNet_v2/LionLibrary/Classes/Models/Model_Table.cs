using System;
using System.Collections.Generic;
using System.Text;

namespace LionLibrary.Classes.Models
{
    public abstract class Model_Table 
    { 
        public int id { get; set; }
        public abstract string GetTableName();
    }
}
