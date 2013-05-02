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
    public partial class Sales : Form
    {
        public string item;
        public float qty, uprice;
        public int no;




        public Sales()
        {
            InitializeComponent();
            no = 0;

        }
        private void namecombo()
        {
            string HostName = Environment.MachineName;

            string connetionString = null;

            connetionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
            // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";


            string sql = "SELECT distinct cname FROM customer";
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

        private void Sales_Load(object sender, EventArgs e)
        {
            namecombo();

        }

        void showDet()
        {
            string name = null;
            name = comboBox1.Text;
            string HostName = Environment.MachineName;

            string connetionString = null;

            connetionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
            // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";


            SqlDataReader rdr = null;
            //SqlConnection con = null;
            SqlCommand cmd = null;


            string sql = "SELECT cname ,cadd ,  ctin  FROM customer where cname='" + name + "';";
            SqlConnection connection = new SqlConnection(connetionString);



            try
            {
                connection.Open();
                string CommandText = sql;
                cmd = new SqlCommand(CommandText);
                cmd.Connection = connection;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {


                    comboBox2.Text = rdr["cadd"].ToString();
                    textBox1.Text = rdr["ctin"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occoured..." + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void comboBox1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            showDet();
        }


        private bool vname()
        {
            bool bStatus = true;
            if (comboBox3.Text == "")
            {
                errorProvider1.SetError(comboBox3, "Please Enter Valid Company Name");
                bStatus = false;
            }
            else
                errorProvider1.SetError(comboBox3, "");
            return bStatus;
        }

        private bool vqty()
        {
            bool bStatus = true;

            if (comboBox4.Text == "")
            {
                errorProvider1.SetError(comboBox4, "Please Enter Valid Quantity");
                bStatus = false;
            }
            else
                errorProvider1.SetError(comboBox4, "");
            return bStatus;
        }

        private bool vuprice()
        {
            bool bStatus = true;
            if (comboBox5.Text == "")
            {
                errorProvider1.SetError(comboBox5, "Please Enter Valid Unit Price");
                bStatus = false;
            }
            else
                errorProvider1.SetError(comboBox5, "");
            return bStatus;
        }

        private bool tval()
        {
            bool i = vname();
            bool q = vqty();
            bool u = vuprice();

            if (i == true & q == true & u == true)
            {
                return true;
            }
            else
                return false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool t = tval();





            string q = comboBox3.Text;
            string h = comboBox4.Text;
            string w = comboBox5.Text;



            if (t == true)
            {

                string[] row = new string[] { q, h, w };


                dataGridView1.Rows.Add(row);

            }


        }

        private void comboBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[0-9]+?|[\b\t]|[ X]|[.]"))
                e.Handled = true;
        }

        private void comboBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[0-9]+?|[\b\t]|[ X]|[.]"))
                e.Handled = true;
        }

        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[a-zA-Z]+?|[\b\t]|[ X]"))
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                Console.Write("Error");
            }
        }

        private void comboBox3_KeyUp(object sender, KeyEventArgs e)
        {
            bool i = vname();

        }

        private void comboBox4_KeyUp(object sender, KeyEventArgs e)
        {
            bool x = vqty();
        }

        private void comboBox5_KeyUp(object sender, KeyEventArgs e)
        {
            bool z = vuprice();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = dataGridView1.RowCount;
            if (x != 0)
            {

                DialogResult rst = MessageBox.Show("Do You Want To Delete ?", "Warnning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                try
                {

                    int rw = dataGridView1.CurrentCell.RowIndex;

                    //MessageBox.Show(rw.ToString());



                    if (rst == DialogResult.Yes)
                    {
                        dataGridView1.Rows.RemoveAt(rw);
                    }
                }
                catch (Exception ex)
                {
                    Console.Write("Error" + ex.Message);
                }
            }


            //------------------------------------- Expriment-------------------------------







        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x = dataGridView1.RowCount;

            int i;


            double a;
            double b;

            double caltot = 0;
            double tp = 0;

            double vat = 0;


            double tmp1;
            double tmp2;
            double tmp3;

            if (x != 0)
            {

                for (i = 0; i < x; i++)
                {


                    // a=dataGridView1.
                    a = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                    b = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                    tp = a * b;
                    caltot = caltot + tp;


                }
                textBox6.Text = caltot.ToString();
                vat = caltot * 0.05;
                textBox7.Text = vat.ToString();

                tmp1 = caltot + vat;

                tmp2 = Math.Round(tmp1);

                textBox3.Text = tmp2.ToString();
                tmp3 = tmp1 - tmp2;
                textBox4.Text = tmp3.ToString();



            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[0-9]+?|[\b\t]|[ X]|[.]"))
                e.Handled = true;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[a-zA-Z]+?|[\b\t]|[ X]"))
                e.Handled = true;
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[a-zA-Z]+?|[\b\t]|[ X]"))
                e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[0-9]+?|[\b\t]|[ X]|[.]"))
                e.Handled = true;
        }


        private bool billno()
        {
            bool bStatus = true;
            if (textBox2.Text == "")
            {
                errorProvider1.SetError(textBox2, "Please Enter Valid Bill No");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBox2, "");
            return bStatus;
        }

        private bool cname1()
        {
            bool bStatus = true;
            if (comboBox1.Text == "")
            {
                errorProvider1.SetError(comboBox1, "Please Enter Valid COmpany Name");
                bStatus = false;
            }
            else
                errorProvider1.SetError(comboBox1, "");
            return bStatus;
        }

        private bool adds()
        {
            bool bStatus = true;
            if (comboBox2.Text == "")
            {
                errorProvider1.SetError(comboBox2, "Please Enter Valid COmpany Address");
                bStatus = false;
            }
            else
                errorProvider1.SetError(comboBox2, "");
            return bStatus;
        }

        private bool tin()
        {
            bool bStatus = true;
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Please Enter Valid Tin Number");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBox1, "");
            return bStatus;
        }

        private bool net()
        {
            bool bStatus = true;
            if (textBox6.Text == "")
            {
                errorProvider1.SetError(textBox6, "Please Enter Valid Net Value");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBox6, "");
            return bStatus;
        }

        private bool vatv()
        {
            bool bStatus = true;
            if (textBox7.Text == "")
            {
                errorProvider1.SetError(textBox7, "Please Enter Valid Vat Value");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBox7, "");
            return bStatus;
        }

        private bool tot1()
        {
            bool bStatus = true;
            if (textBox3.Text == "")
            {
                errorProvider1.SetError(textBox3, "Please Enter Valid Total Value");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBox3, "");
            return bStatus;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string HostName;
            HostName = Environment.MachineName;

            string connetionString = null;
            SqlConnection connection;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = null;


            bool bno = billno();
            bool cn = cname1();
            bool cad = adds();
            bool ti = tin();
            bool nt = net();
            bool vt = vatv();
            bool to = tot1();
            int x = dataGridView1.RowCount;


            double bno1;
            string sdate = dateTimePicker1.Value.ToShortDateString();
            string cname;
            double tot;

            if (bno == true & cn == true & cad == true & ti == true & nt == true & vt == true & to == true & x != 0)
            {


                bno1 = Convert.ToDouble(textBox2.Text);
                cname = comboBox1.Text;
                tot = Convert.ToDouble(textBox3.Text);

                connetionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                connection = new SqlConnection(connetionString);


                sql = "insert into sale(billno,sdate,cname,tot,bal) values(" + bno1 + ",'" + sdate + "','" + cname + "'," + tot +","+tot+ ")";


                try
                {
                    connection.Open();
                    adapter.InsertCommand = new SqlCommand(sql, connection);
                    adapter.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("Data Inserted Into DataBase", "Sucess");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Deplicate Bill Number");
                }


                connection.Close();


                //------------- sale item inserion------------

                connetionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                connection = new SqlConnection(connetionString);
                //sql = "insert into sale(billno,sdate,cname,tot) values(" + bno1 + ",'" + sdate + "','" + cname + "'," + tot + ")";


                bno1 = Convert.ToDouble(textBox2.Text);
                string StrQuery = "";
                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    StrQuery = "INSERT INTO saleitem(billno,sitem,qty,uprice) VALUES (" + bno1 + ",'" + dataGridView1.Rows[i].Cells["Column2"].Value + "', " + dataGridView1.Rows[i].Cells["Column3"].Value + ", " + dataGridView1.Rows[i].Cells["Column4"].Value +  ");";
                   // MessageBox.Show(StrQuery);


                    try
                    {
                        // SqlConnection conn = new SqlConnection();
                        connection.Open();

                        using (SqlCommand comm = new SqlCommand(StrQuery, connection))
                        {
                            comm.ExecuteNonQuery();
                        }
                        connection.Close();

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }


                    //--------------------------------------------------------------------
                    // MessageBox.Show("valided:");

                }

                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
                comboBox5.Text = "";

                textBox1.Text = "";
                textBox2.Text = "";

                textBox3.Text = "";
                textBox4.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";

                dataGridView1.Rows.Clear();




            }


            



        }
    }

}