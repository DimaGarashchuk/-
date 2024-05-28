using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InternetStore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                MessageBox.Show("Реєстрація успішна!", "Реєстрація успішна", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                Store store = new Store();
                store.clients = new List<Client>();
                store.products = new List<Product>();
                Client client = new Client();
                client.name = textBox3.Text;
                client.surname = textBox4.Text;
                client.email = textBox5.Text;
                client.orders = new List<Order>();
                store.clients.Add(client);

                Form2 form = new Form2();
                form.label2.Text = textBox3.Text + " " + textBox4.Text;
                form.store = store;
                form.ShowDialog();
                this.Close();
            }
            else {
                MessageBox.Show("Не усі дані заповнені!", "Помилка!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                MessageBox.Show("Авторизація успішна!", "Авторизація успішна", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                Store store = new Store();
                store.clients = new List<Client>();
                store.products = new List<Product>();
                Client client = new Client();
                client.name = "";// z bd
                client.surname = "";//z bd
                client.email = textBox1.Text;
                client.orders = new List<Order>();
                store.clients.Add(client);

                Form2 form = new Form2();
                form.label2.Text = textBox1.Text;
                form.store = store;
                form.ShowDialog();
                this.Close();
            }
            else {
                MessageBox.Show("Не коректний вход!", "Помилка!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
    }
}
