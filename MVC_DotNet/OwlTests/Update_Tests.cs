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
            Model_Query<Model_User_test> table = new Model_Update<Model_User_test>();
            table.Constrain_Object = new Model_User_test() 
            {
                role_id = 99 
            };
            Model_User_test values_ToChange = new Model_User_test()
            {
                pwd = "changed_pwd_xxxxxxxxxxxx",
                email = "changed_email_addres@gmail.com"
            };
            table.Rows.Add(values_ToChange);

            var h = ActionFactory<Model_User_test>.DoAction(Enum_Action.Update, ref table);

        }
    }
}