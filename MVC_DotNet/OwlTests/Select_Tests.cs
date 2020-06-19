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
            // kolumny po ktorych szukamy - dodanie kolumny to zmiana wartosci pola na niedomyslne -> pobranie wszystkich to ustawienie wszystkim pola wartosci domyslnych
            table.Record_ToChange = new Model_User_test();
            // wartosci ktorych kolumn chcemy otrzymac w zwrotce - trzeba im ustawic niezerowa wartosc
            Model_User_test values_ToGet = new Model_User_test()
            {
                id = 99,
                role_id = 99,
                name ="x",
                pwd = "x",
                email = "x"
            };
            table.Rows.Add(values_ToGet);

            var h = ActionFactory<Model_User_test>.DoAction(Enum_Action.Select, ref table);
            Assert.AreEqual(table.Rows[0].id, 1);
            Assert.AreEqual(table.Rows[1].name, "peter");
            Assert.AreEqual(table.Rows[3].pwd, "adam1234");
            Assert.AreEqual(table.Rows[3].role_id, 1);
            Assert.AreEqual(table.Rows[4].role_id, 2);
            Assert.AreEqual(table.Rows[4].email, "kasia@gmail.com");
        }
        //[Test]
        //public void PostgreSql_Role_Test()
        //{
        //    Model_Query<Model_Role> table = new Model_Select_Roles();
        //    var h = ActionFactory<Model_Role>.DoAction(Enum_Action.Select, ref table);
        //    Assert.AreEqual(table.Rows[0].role_id, 1);
        //    Assert.AreEqual(table.Rows[1].role_id, 2);
        //    Assert.AreEqual(table.Rows[0].role_name, "admin");
        //    Assert.AreEqual(table.Rows[1].role_name, "user");
        //}
    }
}
