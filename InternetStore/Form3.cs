using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternetStore
{
    public partial class Form3 : Form
    {
        public Store store { get; set; }
        int c = 0;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            int j = 0;
            float total_price = 0;
            while (c < store.clients[0].orders.Count)
            {
                if (store.clients[0].orders[c].status == "У процесі")
                    break;
                c++;
            }
            label4.Text = store.clients[0].orders[c].status;
            label4.ForeColor = Color.Yellow;

            for (int i = 0; i < store.clients[0].orders[c].products.Count; i++)
            {
                Label lb = new Label();
                lb.Location = new System.Drawing.Point(20, 20 + 45 * i);
                lb.Text += store.clients[0].orders[c].products[i].name + "\nЦіна: " + store.clients[0].orders[0].products[i].price + "\n";
                lb.AutoSize = true;
                lb.Name = "label" + i.ToString();
                lb.Size = new System.Drawing.Size(0, 20);
                lb.TabIndex = 0;
                groupBox1.Controls.Add(lb);
                total_price += store.clients[0].orders[c].products[i].price;
                j++;
            }
            label2.Text = total_price.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            store.clients[0].orders[c].status = "Підтверджено";
            label4.Text = store.clients[0].orders[c].status;
            label4.ForeColor = Color.SeaGreen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label4.Text = "Відмінінено";
            label4.ForeColor = Color.Red;
            store.clients[0].orders.RemoveAt(c);
            groupBox1.Controls.Clear();
        }
    }
}
