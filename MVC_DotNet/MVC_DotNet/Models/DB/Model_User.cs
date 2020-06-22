using OwlLibrary.Classes.Models.Basic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DotNet.Models.DB
{
    public class Model_User : Model_TableRecord
    {
        public Model_User()
        {
            id = 0;
            table_name = "users";
        }

        public int role_id { get; set; }
        public string name { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string pwd { get; set; }
        [Required]
        [Display(Name = "Email address")]
        public string email { get; set; }

    }
}
