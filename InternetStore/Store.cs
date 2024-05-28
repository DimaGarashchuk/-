using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternetStore
{
   public class Store
    {
        public SqlConnection sql_conn = null;
        public SqlCommandBuilder sql_com_b = null;
        public SqlDataAdapter sql_da = null;
        private DataSet ds = null;

        public String name { get; set; }
        public List<Order> orders { get; set; }
        public List<Product> products { get; set; }
        public List<Client> clients { get; set; }

        public DataSet LoadProducts()
        {
            sql_conn = new SqlConnection(@"Data Source=DESKTOP-RK8IGF2\MAINMSSQLSERVER;Initial Catalog=InternetStore;Integrated Security=True");
            sql_conn.Open();

            try
            {

                sql_da = new SqlDataAdapter("SELECT * FROM Product", sql_conn);
                sql_com_b = new SqlCommandBuilder(sql_da);

                sql_com_b.GetInsertCommand();
                //sql_com_b.GetUpdateCommand();
                //sql_com_b.GetDeleteCommand();

                ds = new DataSet();
                sql_da.Fill(ds, "Product");

                return ds; //= ds.Tables["Product"];

                    //----------------------------------------------------
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
    }
}
