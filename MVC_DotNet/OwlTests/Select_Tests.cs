using NUnit.Framework;
using OwlLibrary.Classes.Models.Basic;
using OwlLibrary.Classes.Models.Query;
using OwlLibrary.Classes.Models.Query.Complete;
using OwlLibrary.Classes.Models.Records;
using OwlLibrary.Enums;
using OwlLibrary.Factory;

namespace OwlTests
{
    public class Select_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PostgreSql_Users_Test()
        {
            Model_Query<Model_User_test> table = new Model_Select<Model_User_test>();
            // wartosci ktorych kolumn chcemy otrzymac w zwrotce - trzeba im ustawic niezerowa wartosc
            //table.Record_ToChange = new Model_User_test()
            //{
            //    role_id = "3",
            //};
            var h = ActionFactory<Model_User_test>.DoAction(Enum_Action.Select, ref table);
            Assert.AreEqual(table.Rows[0].id, 69);
            Assert.AreEqual(table.Rows[1].name, "admin2");
            Assert.AreEqual(table.Rows[3].pwd, "kasia1234");
            Assert.AreEqual(table.Rows[3].role_id, 2);
            Assert.AreEqual(table.Rows[4].role_id, 3);
            Assert.AreEqual(table.Rows[3].email, "kasia@gmail.com");
        }
        [Test]
        public void PostgreSql_SelectRequest_Test()
        {
            Model_Query<Model_User_test> table = new Model_Select<Model_User_test>();
            // wartosci ktorych kolumn chcemy otrzymac w zwrotce - trzeba im ustawic niezerowa wartosc
            //table.Record_ToChange = new Model_User_test()
            //{
            //    role_id = "3",
            //};
            var h = RequestFactory<Model_User_test>.MakeRequest("select * from test_users LIMIT 4", ref table);
            Assert.AreEqual(table.Rows[0].id, 69);
            Assert.AreEqual(table.Rows[1].name, "admin2");
            Assert.AreEqual(table.Rows[3].pwd, "kasia1234");
            Assert.AreEqual(table.Rows[3].role_id, 2);
            Assert.AreEqual(table.Rows[3].email, "kasia@gmail.com");
        }
    }
}
