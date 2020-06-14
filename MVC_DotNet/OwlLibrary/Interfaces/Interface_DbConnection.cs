using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace OwlLibrary.Interfaces
{
    interface Interface_DbConnection
    {
        int Connect(ref DbConnection connection);
    }
}
