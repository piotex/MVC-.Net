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
        public void PostgreSql_Select_Test()
        {
            Model_Table<Model_User> table = new Model_Test_UsersAll();
            var h = ActionFactory<Model_User>.DoAction(Enum_Action.Select, ref table);
            Assert.AreEqual(table.Rows[0].id, 1);
            Assert.AreEqual(table.Rows[1].name, "wojtek");
            Assert.AreEqual(table.Rows[3].pwd, "adam1234");
            Assert.AreEqual(table.Rows[4].email, "zosia@gmail.com");
        }
    }
}
