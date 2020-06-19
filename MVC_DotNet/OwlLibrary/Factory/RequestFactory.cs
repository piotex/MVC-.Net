using OwlLibrary.Classes.GetData;
using OwlLibrary.Classes.Models.Basic;
using OwlLibrary.Classes.SetData;
using OwlLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwlLibrary.Factory
{
    public static class RequestFactory<T_Record> where T_Record : Model_TableRecord, new()
    {
        public static int MakeRequest(string request, ref Model_Query<T_Record> table)
        {
            if (request.ToLower().Contains("select"))
            {
                new PostgreSQL_Select<T_Record>().MakeRequest(request,ref table);
            }
            else
            {
                new PostgreSQL_SetData<T_Record>().MakeRequest(request,ref table);
            }
            return 0;
        }
    }
}
