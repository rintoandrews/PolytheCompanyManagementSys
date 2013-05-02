using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace CheruKayil_Polymers
{
    public partial class PurchaseCash : Form
    {
        public PurchaseCash()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //splitContainer1.Panel1Collapsed = true;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                splitContainer1.Panel2Collapsed = true;
            }


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                splitContainer1.Panel1Collapsed = true;
            }
        }

        private void PurchaseCash_Load(object sender, EventArgs e)
        {
           splitContainer1.Panel2Collapsed = true;
            radioButton1.Checked=true ;

            namecombo();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[a-zA-Z]+?|[\b\t]|[ X]"))
                e.Handled = true;
        }

        private bool ValidateName()
        {
            bool bStatus = true;
            if (comboBox1.Text == "")
            {
                errorProvider1.SetError(comboBox1, "Please Supplier Name");
                bStatus = false;
            }
            else
                errorProvider1.SetError(comboBox1, "");
            return bStatus;
        }

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            bool tmp = ValidateName();
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



        private void grdShow()
        {
            string HostName;
            HostName = Environment.MachineName;

            string connetionString = null;


            string sname = comboBox1.Text;

            connetionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
            // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";


            string sql = "SELECT pdate as PurcahseDate, ptotal  as Amount, bal  as Balance, pno as PurchaseNumber FROM purchase where cname like'" +   sname      +"'";
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
                MessageBox.Show("Error Occoured...", "Error", MessageBoxButtons.OK);
           }


        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            grdShow();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[0-9]+?|[\b\t]|[ X]|[.]"))
                    e.Handled = true;
                bool t = VAmt();

            }
            catch (Exception ex)
            {
                Console.Write("Error");
            }


        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {


            try
            {

                bool sname = ValidateName();
                DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;
                string pno = "";
                bool tra = true;
                if (rows.Count == 0)
                {
                    tra = false;
                }
                else
                {
                    pno = (string)rows[0].Cells["PurchaseNumber"].Value.ToString();

                }

                string ball = (string)rows[0].Cells["Balance"].Value.ToString();

                float b = float.Parse(ball);

                // MessageBox.Show(b.ToString());

                bool byc = false;
                bool byck = false;


                if (radioButton1.Checked == true)
                {
                     byc = byCash();
                }
                else if (radioButton2.Checked == true)
                {
                     byck = byCheque();
                }

                float pmt = 0;
                float bal1 = 0;
                string pdate = "";
                string cqdate = "";
                string chqno = "";

                string bname = "";

                string method = "";

                if (sname == true & tra == true)
                {
                    if (byc == true | byck == true)
                    {
                        if (radioButton1.Checked == true)
                        {

                            pmt = float.Parse(textBox2.Text);
                            bal1 = float.Parse(textBox3.Text);
                            pdate = dateTimePicker1.Value.ToShortDateString();
                            chqno = "";
                            cqdate = "";
                            bname = "";
                            method = "CSH";

                            b = b - pmt;


                        }
                        else if (radioButton2.Checked == true)
                        {

                            pmt = float.Parse(textBox5.Text);
                            bal1 = float.Parse(textBox6.Text);
                            pdate = dateTimePicker2.Value.ToShortDateString();
                            chqno = textBox7.Text;
                            cqdate = dateTimePicker3.Value.ToShortDateString();
                            bname = textBox8.Text;
                            method = "CHQ";

                            b = b - pmt;

                        }
                 



                //----------------------

                string HostName;
                HostName = Environment.MachineName;

                string connetionString = null;
                SqlConnection connection;

                SqlDataAdapter adapter = new SqlDataAdapter();

                connetionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                connection = new SqlConnection(connetionString);
                string sql = "insert into PurchaseCash(pno,method,paydate,amt,bal,cqno,cqdate,bname) values (" + pno + ", '" + method + "', '" + pdate + "', " + pmt + "," + bal1 + ", '" + chqno + "' , '" + cqdate + "' , '" + bname + "');";
                // MessageBox.Show(sql);

                string sqlup = "update purchase set bal=" + b + " where pno=" + pno;
                //MessageBox.Show(sqlup);

                try
                {

                    connection.Open();
                    adapter.InsertCommand = new SqlCommand(sql, connection);
                    adapter.InsertCommand.ExecuteNonQuery();
                    connection.Close();

                    connection.Open();
                    adapter.UpdateCommand = new SqlCommand(sqlup, connection);
                    adapter.UpdateCommand.ExecuteNonQuery();
                    connection.Close();




                    MessageBox.Show("Data Inserted Into DataBase", "Sucess");

                    grdShow();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }



                    }
                }


            }
            catch (Exception ex1)
            {
            }

           

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyValue .ToString(), "[0-9]+?|[\b\t]|[ X]|[.]"))
                e.Handled = true;

            DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;

            if (rows.Count == 0)
            {
                MessageBox.Show("Select Treansaction To Be Processed!", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                e.Handled = true;
            }


            try
            {

                string tot = (string)rows[0].Cells["Balance"].Value.ToString();

                float  tot1;
                tot1 = float.Parse(tot);

                float pay = float.Parse(textBox2.Text.ToString());
                float b = tot1 - pay;
                


                //MessageBox.Show(b.ToString());

                textBox3.Text= b.ToString();

                Console.Write("Bal" + tot1.ToString()+" ");
                Console.Write("Pay" + pay.ToString()+" ");
                Console.Write("NewBal" + b.ToString()+" " + Environment.NewLine );

                

            }
            catch (Exception ex)
            {
            }


        }

       

        bool byCash()
        {

            bool vmt = VAmt();
            if (vmt == true)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        bool byCheque()
        {
            bool vmt = vamt2();
            bool ckno = chkno();
            bool bname = bname1();

            if (vmt == true & ckno == true & bname == true)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

          


        public  bool VAmt()
        {
            bool bStatus = true;

          //  Regex objTwoDotPattern = new Regex("[^0-9.-]");

            

             if (textBox2.Text == "")
            {
                errorProvider1.SetError(textBox2, "Please Payment Amount");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBox2, "");
            return bStatus;
        }

        private bool vamt2()
        {
            bool bStatus = true;

            //  Regex objTwoDotPattern = new Regex("[^0-9.-]");



            if (textBox5.Text == "")
            {
                errorProvider1.SetError(textBox5, "Please Payment Amount");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBox5, "");
            return bStatus;
        }

        private bool chkno()
        {
            bool bStatus = true;

            //  Regex objTwoDotPattern = new Regex("[^0-9.-]");



            if (textBox7.Text == "")
            {
                errorProvider1.SetError(textBox7, "Please Cheque Number");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBox7, "");
            return bStatus;
        }

        private bool bname1()
        {
            bool bStatus = true;

            //  Regex objTwoDotPattern = new Regex("[^0-9.-]");



            if (textBox8.Text == "")
            {
                errorProvider1.SetError(textBox8, "Please Bank Name");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBox8, "");
            return bStatus;
        }


        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[0-9]+?|[\b\t]|[ X]|[.]"))
                    e.Handled = true;
                bool l = vamt2();

            }
            catch (Exception ex)
            {
                Console.Write("Error");
            }

        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyValue.ToString(), "[0-9]+?|[\b\t]|[ X]|[.]"))
                e.Handled = true;

            DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;

            if (rows.Count == 0)
            {
                MessageBox.Show("Select Treansaction To Be Processed!", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                e.Handled = true;
            }


            try
            {

                string tot = (string)rows[0].Cells["Balance"].Value.ToString();

                float tot1;
                tot1 = float.Parse(tot);

                float pay = float.Parse(textBox5.Text.ToString());
                float b = tot1 - pay;



                //MessageBox.Show(b.ToString());

                textBox6.Text = b.ToString();

                Console.Write("Bal" + tot1.ToString() + " ");
                Console.Write("Pay" + pay.ToString() + " ");
                Console.Write("NewBal" + b.ToString() + " " + Environment.NewLine);



            }
            catch (Exception ex)
            {
            }

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool b = chkno();

        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool c = bname1();

        }


       

      


    }
}
