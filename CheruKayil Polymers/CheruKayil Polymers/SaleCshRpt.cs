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
    public partial class SaleCshRpt : Form
    {
        public SaleCshRpt()
        {
            InitializeComponent();
        }


        private void namecombo()
        {
            string HostName = Environment.MachineName;

            string connetionString = null;

            connetionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
            // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";


            string sql = "SELECT distinct cname FROM sale";
            SqlConnection connection = new SqlConnection(connetionString);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            IList<string> lstFirst = new List<string>();

            try
            {
                connection.Open();

                dataadapter.Fill(dt);

                connection.Close();
                //dataGridView1.DataSource = ds;
                //dataGridView1.DataMember = "suppliers_table";

                comboBox1.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    lstFirst.Add(row.Field<string>("cname"));
                    //lstLast.Add(row.Field<string>("lastname"));


                }

                comboBox1.Items.AddRange(lstFirst.ToArray<string>());
                comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            connection.Close();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            namecombo();
        }

        private void SaleCshRpt_Load(object sender, EventArgs e)
        {
            namecombo();
        }


        private void grdShow()
        {
            string HostName;
            HostName = Environment.MachineName;

            string connetionString = null;


            string sname = comboBox1.Text;

            connetionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
            // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";


            string sql = "SELECT sdate as SaleDate, billno  as BillNumber, tot  as TotalAmount, bal  as Balance FROM sale where cname like'" + sname + "'";
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

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            grdShow();
        }


        private void grdShow2()
        {
            string HostName;
            HostName = Environment.MachineName;

            string connetionString = null;


            DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;
            string pno = (string)rows[0].Cells["BillNumber"].Value.ToString();
            int pno1 = int.Parse(pno);

          //  MessageBox.Show(pno);

            //string sname = comboBox1.Text;

            connetionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
            // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";


            //  string sql = "SELECT pdate as PurcahseDate, ptotal  as Amount, totpaid  as PaidAmount, bal  as Balance, pno as PurchaseNumber FROM purchase where cname like'" + sname + "'";

            string sql = "select  method as Method,paydate as PayDate,amt as Amount,cqno as ChequeNumber,cqdate as ChequeDate,bname as BankName from salecash where billno=" + pno1;

            SqlConnection connection = new SqlConnection(connetionString);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();

            try
            {
                connection.Open();
                dataadapter.Fill(ds, "suppliers_table");
                connection.Close();
                dataGridView2.DataSource = ds;
                dataGridView2.DataMember = "suppliers_table";
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Error Occoured..."+ ex.Message , "Error", MessageBoxButtons.OK);
            }


        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            grdShow2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grdShowView();

        }

        private void grdShowView()
        {
            string HostName;
            HostName = Environment.MachineName;

            string connetionString = null;

          //  string sql = "SELECT sdate as SaleDate, billno  as BillNumber, tot  as TotalAmount, bal  as Balance FROM sale where cname like'" + sname + "'";
           // SqlConnection connection = new SqlConnection(connetionString);

            // DateTime frm = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());

            // MessageBox.Show(frm.ToString());


            string sdate = dateTimePicker1.Value.ToString();
            string edate = dateTimePicker2.Value.ToString();



            string sname = comboBox1.Text;

            connetionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
            // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";


            string sql = "SELECT sdate as SaleDate, billno  as BillNumber, tot  as TotalAmount, bal  as Balance FROM sale purchase where sdate between '" + sdate + "' and '" + edate + "'";

            //MessageBox.Show(sql);



            //MessageBox.Show(sql);

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
    }
}
