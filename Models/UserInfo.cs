using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class UserInfo
    {

        public int id { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }


        public string email { get; set; }

        public string password { get; set; }

        public string confirm_password { get; set; }
        public string profile_pic_path { get; set; }
        public Nullable<System.DateTime> month_start_date { get; set; }


    }
}
