using System;
using System.Collections.Generic;
using System.Text;

namespace OwlLibrary.Classes.Models.Basic
{
    public class Model_Table<T>
    {
        public string Query { get; set; }
        public List<T> Rows { get; set; }
        public List<string> ColumnsNames { get; set; }

        
    }
}
