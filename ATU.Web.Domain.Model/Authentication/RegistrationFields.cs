using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATU.Web.Domain.Model.Authentication
{
    public class RegistrationFields : ViewBase
    {
        [Required]
        public string DisplayName { get; set; }
    }
}
