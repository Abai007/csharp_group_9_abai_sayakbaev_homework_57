using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace homework_54.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Не указан Email")]

        public string Email { get; set; }



        [Required(ErrorMessage = "Не указан пароль")]

        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}
