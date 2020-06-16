using System;
using System.Collections.Generic;
using System.Text;

namespace OwlLibrary.Classes.Models.Basic
{
    public class Model_Table<T_Record>                             //todo zrobić z tego interfejs i wymuszac implementacje w klasach dziedziczacych
    {
        public string Query { get; set; }
        public List<T_Record> Rows { get; set; }
        public List<string> ColumnsNames { get; set; }

        
    }
}
