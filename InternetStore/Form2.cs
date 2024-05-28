using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InternetStore
{
    public partial class Form2 : Form
    {
        private DataSet ds = null;
        public Store store { get; set; }
        private Order order = new Order();
        private bool first_time = true;
        Form3 form = new Form3();
  
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            store.products = new List<Product> { };
            order.products = new List<Product>();
            store.orders = new List<Order>();


            ds = store.LoadProducts();
            int i = 0;
            int j = 0;
            foreach (DataRow row in ds.Tables["Product"].Rows)
            {
                Label lb = new Label();
                /*  PictureBox pb = new PictureBox();
                  pb.Image = Image.FromFile("hleb.jpg");
                  pb.Location = new Point(100, 15+i);
                  pb.Size = new Size(100, 100);
                */
                PictureBox pb1 = new PictureBox();
                pb1.Image = Image.FromFile("Product.png");

                System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
                btn.Click += productBtn_Click;
                btn.MouseEnter += OnMouseEnterButton1;
                btn.MouseLeave += OnMouseLeaveButton1;

                if (j == 0)
                {
                    pb1.Location = new Point(150, 20 + 35 * i + i * 130);
                    lb.Location = new System.Drawing.Point(150, 120 + 35 * i + 130 * i);
                    btn.Location = new System.Drawing.Point(150, 150 + 35 * i + 130 * i);
                }
                if (j == 1)
                {
                    pb1.Location = new Point(400, 20 + 35 * i + i * 130);
                    lb.Location = new System.Drawing.Point(400, 120 + 35 * i + 130 * i);
                    btn.Location = new System.Drawing.Point(400, 150 + 35 * i + 130 * i);
                }

                pb1.Size = new Size(100, 100);
                pb1.SizeMode = PictureBoxSizeMode.StretchImage;

//                foreach (DataColumn col in ds.Tables["Product"].Columns)
  //                  lb.Text += row[col] + ", ";

                Product p = new Product();

                for (int k = 1; k < ds.Tables["Product"].Columns.Count; k++)
                {
                    switch (k)
                    {
                        case 1:
                            p.name = row[k].ToString();
                            break;
                        case 2:
                            p.price = float.Parse(row[k].ToString());
                            break;
                        case 3:
                            p.count = int.Parse(row[k].ToString());
                            break;
                        case 4:
                            p.category = row[k].ToString();
                            break;
                    }
                }
                store.products.Add(p);

                lb.Text += "Назва: " + p.name + "\nЦіна: " + p.price + "\n";
                lb.AutoSize = true;
                //lb.Location = new System.Drawing.Point(100, 120 + 20*i + 100*i);
                lb.Name = "label" + i.ToString();
                lb.Font = new Font("Rubik", label1.Font.Size);
                lb.Size = new System.Drawing.Size(0, 20);
                lb.TabIndex = 0;
                //groupBox1.Controls.Add(pb);
                btn.Text = "Додати у кошик";
                btn.Font = new Font("Rubik", button1.Font.Size);
                btn.Size = new Size(150, 25);

                groupBox1.Controls.Add(pb1);
                groupBox1.Controls.Add(lb);
                groupBox1.Controls.Add(btn);
                
                if (j == 0)
                {
                    j++;
                    //i++;
                }
                else
                {
                    j = 0;
                    i++;
                }
            }

        }

        private void ScrollOn(object sender, ScrollEventArgs e)
        {
            if (e.NewValue > e.OldValue)
            {
                foreach (Control c in groupBox1.Controls)
                {
                    c.Top -= (e.NewValue - e.OldValue);
                }
            }
            if (e.NewValue < e.OldValue)
            {
                foreach (Control c in groupBox1.Controls)
                {
                    c.Top += (e.OldValue - e.NewValue);
                }
            }
        }
        private void OnMouseEnterButton1(object sender, EventArgs e)
        {
            for (int i = 0; i < groupBox1.Controls.Count; i++)
            {
                if (sender == groupBox1.Controls[i])
                {
                    groupBox1.Controls[i].BackColor = Color.LightGreen; // or Color.Red or whatever you want

                }
            }
        }
        private void OnMouseLeaveButton1(object sender, EventArgs e)
        {
            for (int i = 0; i < groupBox1.Controls.Count; i++)
            {
                if (sender == groupBox1.Controls[i])
                {
                    groupBox1.Controls[i].BackColor = SystemColors.ButtonShadow; // or Color.Red or whatever you want

                }
            }
        }
        private void productBtn_Click(object sender, EventArgs e) 
        {
            order.client = store.clients[0];
            order.status = "У процесі";
            int j = 1;
            for (int i = 0; i < groupBox1.Controls.Count; i++)
            {
                if (i != 0 && i % 3 == 0)
                    j++;
                if (sender == groupBox1.Controls[i])
                {
                    order.products.Add(store.products[i - 2 * j]);
                    // j++;
                    label5.Text = store.products[i - 2 * j].name;
                }
            }

            //order.products.Add(product);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            store.clients[0].orders.Add(order);
            store.orders.Add(order);
            //store.orders.Add(order);
            form.store = this.store;
            form.ShowDialog();
            this.store = form.store;
            if ((form.store.clients[0].orders.Count != 0) && form.store.clients[0].orders[form.store.clients[0].orders.Count - 1].status == "Підтверджено")
            {
                order = new Order();
                order.products = new List<Product>();
            }
        }
    }
}
