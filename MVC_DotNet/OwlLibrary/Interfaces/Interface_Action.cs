using OwlLibrary.Classes.Models.Basic;
using OwlLibrary.Classes.Models.Records;
using OwlLibrary.Classes.Models.Table;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace OwlLibrary.Interfaces
{
    public interface Interface_Action<T2> where T2 : new()
    {
        int DoAction(ref Model_Table<T2> tableModel) ;
    }
}
