using NUnit.Framework;
using OwlLibrary.Classes.Models.Table;
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
        public void PostgreSql_Connection_Test()
        {
            Model_Table<Model_User> table = new Model_UserTable();
            var h = ActionFactory<Model_User>.DoAction(Enum_Action.SelectAll, ref table);
            Assert.AreNotEqual(h, null);
        }
    }
}
