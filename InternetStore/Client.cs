using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetStore
{
    public class Client
    {
        public String name { get; set; }
        public String surname { get; set; }
        public String email { get; set; }
        public List<Order> orders { get; set; }
    }
}
