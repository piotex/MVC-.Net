using NUnit.Framework;
using OwlLibrary.Classes.Models.Basic;
using OwlLibrary.Classes.Models.Query;
using OwlLibrary.Classes.Models.Query.Complete;
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
            Model_Query<Model_Owl_User_test> table = new Model_Insert<Model_Owl_User_test>();
            Model_Owl_User_test values_ToSet = new Model_Owl_User_test()
            {
                role_id = 99,
                name = "test_Adam",
                pwd = "insert_pwd_xxxxxxxxxxxx",
                email = "insert_email_addres@gmail.com"
            };
            table.Rows.Add(values_ToSet);

            var h = ActionFactory<Model_Owl_User_test>.DoAction(Enum_Action.Insert, ref table);

        }
    }
}
