using Npgsql;
using NUnit.Framework;
using OwlLibrary.Enums;
using OwlLibrary.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OwlTests
{
    [TestClass]
    public class Connection_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PostgreSql_Connection_Test()
        {
            var h = ConnectionFactory.makeConnection<NpgsqlConnection>(Enum_Db.PostgreeSQL) as NpgsqlConnection;
            Assert.AreNotEqual(h,null);
        }
    }
}