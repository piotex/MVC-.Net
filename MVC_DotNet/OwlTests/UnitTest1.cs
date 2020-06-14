using NUnit.Framework;
using OwlLibrary.Enums;
using OwlLibrary.Factory;

namespace OwlTests
{
    public class Connection
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PostgreSql_Connection_Test()
        {
            var h = ConnectionFactory.makeConnection(Enum_Db.PostgreeSQL);
            Assert.AreNotEqual(h,null);
        }
    }
}