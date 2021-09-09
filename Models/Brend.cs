using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace homework_54.Models
{
    public class Brend
    {
        public int Id { get; set; }
        [Remote(action: "CheckName", controller: "Brends", ErrorMessage = "Такой бренд уже есть!")]
        public string Name { get; set; }
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес электронной почты")]
        public string Email { get; set; }
        [Remote(action: "CheckDate", controller: "Brends", ErrorMessage = "Дата не корректна!")]
        public DateTime DataOfCreate { get; set; }
    }
}
