using NUnit.Framework;
using OwlLibrary.Classes.Models.Basic;
using OwlLibrary.Classes.Models.Query;
using OwlLibrary.Classes.Models.Query.Tests;
using OwlLibrary.Classes.Models.Records;
using OwlLibrary.Enums;
using OwlLibrary.Factory;

namespace OwlTests
{
    public class Insert_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PostgreSql_Users_Test()
        {
            Model_Query<Model_User> table = new Model_Insert_User_Test();
            Model_User user = new Model_User() {
                name = "testName_Zbyszek",
                email = "test@gmail.com",
                pwd = "testPWD",
                role_id = 99
            };
            table.Rows.Add(user);
            var h = ActionFactory<Model_User>.DoAction(Enum_Action.Insert, ref table);

            Model_Query<Model_User> table2 = new Model_Select_AllUsers_Test();
            var ha = ActionFactory<Model_User>.DoAction(Enum_Action.Select, ref table2);
            Assert.AreEqual(table.Rows[0].role_id, table2.Rows[6].role_id);
            //delete record where role_id = 99
        }
    }
}
