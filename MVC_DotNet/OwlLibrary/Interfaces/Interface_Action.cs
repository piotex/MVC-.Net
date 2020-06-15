using OwlLibrary.Classes.Models.Table;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace OwlLibrary.Interfaces
{
    public interface Interface_Action<T2> where T2 : Model_User, new()
    {
        int DoAction(ref Model_Table<T2> tableModel) ;
    }
}
