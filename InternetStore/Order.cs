using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetStore
{
    public class Order
    {
        public int number { get; set; }
        public Client client { get; set; }
        public DateTime dt { get; set; }
        public String status { get; set; }
        public List<Product> products { get; set; }
        public float total_price { get; set; }
    }
}
