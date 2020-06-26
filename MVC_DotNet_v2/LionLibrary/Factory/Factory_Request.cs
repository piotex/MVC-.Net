using LionLibrary.Classes.Models;
using LionLibrary.Classes.Select;
using LionLibrary.Classes.SetData;
using System;
using System.Collections.Generic;
using System.Text;

namespace LionLibrary.Factory
{
    public abstract class Factory_Request<T_Result> where T_Result : Model_Table, new()
    {
        public abstract string Get_PathTo_ConnectionStr();
        public virtual List<T_Result> Select(string query)
        {
            return new Select_PostgreSQL<T_Result>().Select(Get_PathTo_ConnectionStr(), query);
        }
        public virtual void Insert(T_Result ob)
        {
            new SetObj_PostgreSQL<T_Result>().SetObj(ref ob, Get_PathTo_ConnectionStr());
        }
        public virtual void Update(string query)
        {
            new SetData_PostgreSQL().SetData(Get_PathTo_ConnectionStr(), query);
        }
        public virtual void Delete(string query)
        {
            new SetData_PostgreSQL().SetData(Get_PathTo_ConnectionStr(), query);
        }
    }
}
