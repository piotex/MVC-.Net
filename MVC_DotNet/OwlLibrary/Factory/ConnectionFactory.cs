using Npgsql;
using OwlLibrary.Classes.Connection;
using OwlLibrary.Enums;
using OwlLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace OwlLibrary.Factory
{
    public static class ConnectionFactory
    {
        private static Dictionary<Enum_Db, Interface_DbConnection> _dic = new Dictionary<Enum_Db, Interface_DbConnection>
        {
            {Enum_Db.PostgreeSQL, new  PostgreSQL_Connection()}
        };
        public static T makeConnection<T>(Enum_Db dbType) where T : DbConnection
        {
            T conn = null;
             _dic[dbType].Connect(ref conn);
            return conn;            
        }
    }
}
