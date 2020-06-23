using LionLibrary.Classes.Models;
using LionLibrary.Classes.Select;
using System;
using System.Collections.Generic;
using System.Text;

namespace LionLibrary.Factory
{
    public abstract class Factory_Request<T_Result> where T_Result : Model_Table, new()
    {
        public abstract string Get_PathTo_ConnectionStr();
        public List<T_Result> Select(string query)
        {
            return new Select_PostgreSQL<T_Result>().Select(Get_PathTo_ConnectionStr(), query);
            throw new NotImplementedException();
        }
        public void Insert(T_Result ob)
        {


            throw new NotImplementedException();
        }
        public void Update(string query)
        {


            throw new NotImplementedException();
        }
        public void Delete(string query)
        {


            throw new NotImplementedException();
        }
    }
}
