using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Login
    {

        public int id { get; set; }
        [Required]   
        [EmailAddress]                       // to make this attributes working add key in <appsetting>
        public string email { get; set; }   //tag <add key="ClientValidationEnabled"value="true" /> in web.config and also import jquery.validate and jquery unobstrusive source in html.
        [Required]
        public string password { get; set; }
    }
}
