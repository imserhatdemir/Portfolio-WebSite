using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Areas.Writer.Models
{
    public class UserSignViewModel
    {
        [Display(Name ="Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı Adı girin")]
        public string UserName { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage =  "Şifre girin")]
        public string Password { get; set; }
    }
}
