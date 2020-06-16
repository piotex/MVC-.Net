using OwlLibrary.Classes.GetData;
using OwlLibrary.Classes.Models.Basic;
using OwlLibrary.Classes.SetData;
using OwlLibrary.Enums;

namespace OwlLibrary.Factory
{
    public static class ActionFactory<T_Record> where T_Record : new() 
    {
        public static int DoAction(Enum_Action actionType,ref Model_Query<T_Record> table)
        {
            switch (actionType)
            {
                case Enum_Action.Select:
                    new PostgreSQL_Select<T_Record>().DoAction(ref table);
                    break;
                case Enum_Action.Insert:
                    new PostgreSQL_SetData<T_Record>().DoAction(ref table);
                    break;
                //case Enum_Action.Delete:
                //    break;
                //case Enum_Action.Update:
                    //break;
                default:
                    break;
            }

            return 1;
        }
    }
}
