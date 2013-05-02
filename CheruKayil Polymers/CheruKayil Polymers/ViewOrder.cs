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
    public partial class ViewOrder : Form
    {
        public ViewOrder()
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

            string sql = "select odate as OrderDate , cname as CompanyName,item as Item, qty as Qty,height as Height,width as Width,gage as Gage,color as  Color from orderitem where odate between '" + sdate + "' and '" + edate + "'";


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

        private void ViewOrder_Load(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;

            try
            {
                textBox1.Text = (string)rows[0].Cells["CompanyName"].Value.ToString();
                textBox2.Text = (string)rows[0].Cells["Item"].Value.ToString();
                textBox3.Text = (string)rows[0].Cells["Qty"].Value.ToString();
                textBox4.Text = (string)rows[0].Cells["Height"].Value.ToString();

                textBox5.Text = (string)rows[0].Cells["Width"].Value.ToString();
                textBox6.Text = (string)rows[0].Cells["Gage"].Value.ToString();

                textBox7.Text = (string)rows[0].Cells["Color"].Value.ToString();
                textBox8.Text = (string)rows[0].Cells["OrderDate"].Value.ToString();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
