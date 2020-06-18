using NUnit.Framework;
using OwlLibrary.Classes.Models.Basic;
using OwlLibrary.Classes.Models.Query.Complete;
using OwlLibrary.Classes.Models.Records;
using OwlLibrary.Enums;
using OwlLibrary.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwlTests
{
    class Update_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PostgreSql_Users_Test()
        {
            Model_Query<Model_User> table = new Model_Update<Model_User>();
            Model_User user = new Model_User()
            {
                role_id = 99,
                email = "changed_email_addres@gmail.com"
            };
            user.table_name = "test_users";
            table.Rows.Add(user);
            var h = ActionFactory<Model_User>.DoAction(Enum_Action.Update, ref table);

            //todo select user where role_id = 99 => jest ==> blad => nie ma => super

            //Model_Query<Model_User> table2 = new Model_Select_AllUsers_Test();
            //var ha = ActionFactory<Model_User>.DoAction(Enum_Action.Select, ref table2);
            //Assert.AreEqual(table.Rows[0].role_id, table2.Rows[6].role_id);
            //delete record where role_id = 99
        }
    }
}