
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_54.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public int BrendId { get; set; }
        public Brend Brend { get; set; }
        public ImageModel ImageModel { get; internal set; }
    }
}
