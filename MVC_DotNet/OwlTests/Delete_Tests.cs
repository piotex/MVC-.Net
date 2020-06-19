using NUnit.Framework;
using OwlLibrary.Classes.Models.Basic;
using OwlLibrary.Classes.Models.Query.Complete;
using OwlLibrary.Classes.Models.Records;
using OwlLibrary.Enums;
using OwlLibrary.Factory;

namespace OwlTests
{
    public class Delete_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PostgreSql_Users_Test()
        {
            Model_Query<Model_User_test> table = new Model_Delete<Model_User_test>();
            var h = ActionFactory<Model_User_test>.DoAction(Enum_Action.Delete, ref table);

            //todo select user where role_id = 99 => jest ==> blad => nie ma => super

            //Model_Query<Model_User> table2 = new Model_Select_AllUsers_Test();
            //var ha = ActionFactory<Model_User>.DoAction(Enum_Action.Select, ref table2);
            //Assert.AreEqual(table.Rows[0].role_id, table2.Rows[6].role_id);
            //delete record where role_id = 99
        }
    }
}