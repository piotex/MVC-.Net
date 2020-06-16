using NUnit.Framework;
using OwlLibrary.Classes.Models.Basic;
using OwlLibrary.Classes.Models.Records;
using OwlLibrary.Classes.Models.Table;
using OwlLibrary.Classes.Models.Tests;
using OwlLibrary.Enums;
using OwlLibrary.Factory;
using System;
using System.Collections.Generic;
using System.Text;

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
            Model_Table<Model_User> table = new Model_Test_UsersAll();
            var h = ActionFactory<Model_User>.DoAction(Enum_Action.Select, ref table);
            Assert.AreEqual(table.Rows[0].id, 1);
            Assert.AreEqual(table.Rows[1].name, "peter");
            Assert.AreEqual(table.Rows[3].pwd, "adam1234");
            Assert.AreEqual(table.Rows[3].role_id, 1);
            Assert.AreEqual(table.Rows[4].role_id, 2);
            Assert.AreEqual(table.Rows[4].email, "kasia@gmail.com");
        }
        [Test]
        public void PostgreSql_Role_Test()
        {
            Model_Table<Model_Role> table = new Model_User_Role();
            var h = ActionFactory<Model_Role>.DoAction(Enum_Action.Select, ref table);
            Assert.AreEqual(table.Rows[0].role_id, 1);
            Assert.AreEqual(table.Rows[1].role_id, 2);
            Assert.AreEqual(table.Rows[0].role_name, "admin");
            Assert.AreEqual(table.Rows[1].role_name, "user");
        }
    }
}
