using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_54.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Grade { get; set; }
        public int PhoneId { get; set; }
        public Phone Phone { get; set; }
    }
}
