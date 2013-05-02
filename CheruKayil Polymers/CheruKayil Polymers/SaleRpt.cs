using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CheruKayil_Polymers
{
    public partial class SaleRpt : Form
    {
        public SaleRpt()
        {
            InitializeComponent();
        }

        private void grdShowView()
        {
            string HostName;
            HostName = Environment.MachineName;

            string connetionString = null;



            // DateTime frm = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());

            // MessageBox.Show(frm.ToString());


            string sdate = dateTimePicker1.Value.ToString();
            string edate = dateTimePicker2.Value.ToString();



            //string sname = comboBox1.Text;

            connetionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
            // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";


            //string sql = "SELECT cname as Supplier, pdate as PurchaseDate, ptotal  as Amount, totpaid  as PaidAmount, bal  as Balance, pno as PurchaseNumber FROM purchase where pdate between '" + sdate + "' and '" + edate + "'";

            string sql = "select billno as BillNumber , sdate as SaleDate,cname as CompanyName, tot as Total from sale where sdate between '" + sdate + "' and '" + edate + "'";


            // MessageBox.Show(sql);



            //   MessageBox.Show(sql);

            SqlConnection connection = new SqlConnection(connetionString);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();

            try
            {
                connection.Open();
                dataadapter.Fill(ds, "suppliers_table");
                connection.Close();
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "suppliers_table";
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Error Occoured..." + ex.Message , "Error", MessageBoxButtons.OK);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            grdShowView();

        }
    }
}
