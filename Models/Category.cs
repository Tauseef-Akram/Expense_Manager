using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Category
    {
        public int id { get; set; }

        [Required]
        public string category_name { get; set; }
        public int user_id { get; set; }
    }


   
}
