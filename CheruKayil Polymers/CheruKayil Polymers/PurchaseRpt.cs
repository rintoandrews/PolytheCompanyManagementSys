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
    public partial class PurchaseRpt : Form
    {
        public PurchaseRpt()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }


        private void namecombo()
        {
            string HostName = Environment.MachineName;

            string connetionString = null;

            connetionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
            // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";


            string sql = "SELECT distinct cname FROM purchase";
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

       

        private void comboBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            namecombo();
        }

        private void PurchaseRpt_Load(object sender, EventArgs e)
        {
            namecombo();

            label22.Height = 2;

        }

        private void grdShow()
        {
            string HostName;
            HostName = Environment.MachineName;

            string connetionString = null;


            string sname = comboBox1.Text;

            connetionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
            // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";


            string sql = "SELECT pdate as PurchaseDate, ptotal  as Amount, totpaid  as PaidAmount, bal  as Balance, pno as PurchaseNumber FROM purchase where cname like'" + sname + "'";
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
            string pno = (string)rows[0].Cells["PurchaseNumber"].Value.ToString();
            int pno1 = int.Parse(pno);


            //string sname = comboBox1.Text;

            connetionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
            // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";


          //  string sql = "SELECT pdate as PurcahseDate, ptotal  as Amount, totpaid  as PaidAmount, bal  as Balance, pno as PurchaseNumber FROM purchase where cname like'" + sname + "'";

            string sql = "select method as Method,paydate as PayDate,amt as Amount,cqno as ChequeNumber,cqdate as ChequeDate,bname as BankName from PurchaseCash where pno=" + pno1;

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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            
           

        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;


            label21.Text = comboBox1.Text;
            label3.Text = (string)rows[0].Cells["PurchaseDate"].Value.ToString();
            label5.Text = (string)rows[0].Cells["Amount"].Value.ToString();
            label7.Text = (string)rows[0].Cells["PaidAmount"].Value.ToString();
            label9.Text = (string)rows[0].Cells["Balance"].Value.ToString();


            DataGridViewSelectedRowCollection rows2 = dataGridView2.SelectedRows;

            label11.Text = (string)rows2[0].Cells["Method"].Value.ToString();
            label15.Text = (string)rows2[0].Cells["PayDate"].Value.ToString();
            label26.Text = (string)rows2[0].Cells["Amount"].Value.ToString();
            label14.Text = (string)rows2[0].Cells["ChequeNumber"].Value.ToString();
            label17.Text = (string)rows2[0].Cells["ChequeDate"].Value.ToString();
            label19.Text = (string)rows2[0].Cells["BankName"].Value.ToString();
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



            string sname = comboBox1.Text;

            connetionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
            // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";


       string sql = "SELECT cname as Supplier, pdate as PurchaseDate, ptotal  as Amount, totpaid  as PaidAmount, bal  as Balance, pno as PurchaseNumber FROM purchase where pdate between '"+ sdate+ "' and '"+ edate +"'" ;

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

        private void button1_Click(object sender, EventArgs e)
        {
            grdShowView();
        }
       


    }
}
