using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiifinal.Models
{
    public class PortUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public int cost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string usertype { get; set; }

    }
}
