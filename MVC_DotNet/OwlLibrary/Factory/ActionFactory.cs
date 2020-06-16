using OwlLibrary.Classes.GetData;
using OwlLibrary.Classes.Models.Basic;
using OwlLibrary.Classes.Models.Records;
using OwlLibrary.Classes.Models.Table;
using OwlLibrary.Enums;
using OwlLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace OwlLibrary.Factory
{
    public static class ActionFactory<T> where T : Model_User, new() 
    {
        public static int DoAction(Enum_Action actionType,ref Model_Table<T> table)
        {
            switch (actionType)
            {
                case Enum_Action.Select:
                    new PostgreSQL_select<T>().DoAction(ref table);
                    break;
                case Enum_Action.Insert:
                    break;
                case Enum_Action.Delete:
                    break;
                case Enum_Action.Update:
                    break;
                default:
                    break;
            }

            return 1;
        }
    }
}
