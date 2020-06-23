using LionLibrary.Factory;
using Npgsql;
using NUnit.Framework;
using System.Data.Common;

namespace LionLibraryTests
{
    public class ConnectionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConnectionTest_PostgreSQL()
        {
            DbConnection db = Factory_Connection<NpgsqlConnection>.GetConnection("xml");
            db.Open();
            db.Close();
            //Assert.Pass();
        }
    }
}