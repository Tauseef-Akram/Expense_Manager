using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Models
{
    public class Records
    {

        public int id { get; set; }
        public bool expense_income { get; set; }
        [Required]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter Numbers only")]
        public int amount { get; set; }
        [Required]
        public int category { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public System.DateTime date { get; set; }
        public string notes { get; set; }
        public int userid { get; set; }

    }
}
