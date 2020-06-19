using NUnit.Framework;
using OwlLibrary.Classes.Models.Basic;
using OwlLibrary.Classes.Models.Query;
using OwlLibrary.Classes.Models.Query.Complete;
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
            Model_Query<Model_User> table = new Model_Insert<Model_User>();
            table.Record_ToChange = new Model_User()
            {
                table_name = "test_users"
            };
            Model_User values_ToSet = new Model_User()
            {
                role_id = 3,
                name = "test_Adam",
                pwd = "insert_pwd_xxxxxxxxxxxx",
                email = "insert_email_addres@gmail.com"
            };
            table.Rows.Add(values_ToSet);

            var h = ActionFactory<Model_User>.DoAction(Enum_Action.Insert, ref table);

        }
    }
}
