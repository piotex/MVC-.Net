using OwlLibrary.Classes.GetData;
using OwlLibrary.Enums;
using OwlLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace OwlLibrary.Factory
{
    public static class ActionFactory
    {
        private static Dictionary<Enum_Action, Interface_Action> _dic = new Dictionary<Enum_Action, Interface_Action>
        {
            {Enum_Action.SelectAll, new PostgreSQL_selectAll() }
        };
        public static DbConnection makeConnection(Enum_Action actionType)
        {
            DbConnection conn = null;
            _dic[actionType].DoAction();
            return conn;
        }
    }
}
