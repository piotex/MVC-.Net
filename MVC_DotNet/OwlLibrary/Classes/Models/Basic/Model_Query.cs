using OwlLibrary.Classes.Models.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwlLibrary.Classes.Models.Basic
{
    public abstract class Model_Query<T_Record> where T_Record : Model_TableRecord                            //todo zrobić z tego interfejs i wymuszac implementacje w klasach dziedziczacych
    {
        public abstract string get_Query();
        public List<T_Record> Rows { get; set; }

    }
}
