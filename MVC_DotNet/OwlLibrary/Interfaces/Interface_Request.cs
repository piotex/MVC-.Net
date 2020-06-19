using OwlLibrary.Classes.Models.Basic;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwlLibrary.Interfaces
{
    public interface Interface_Request<T_Record> where T_Record : Model_TableRecord, new()
    {
        int MakeRequest(string request,ref Model_Query<T_Record> tableModel);
    }
}
