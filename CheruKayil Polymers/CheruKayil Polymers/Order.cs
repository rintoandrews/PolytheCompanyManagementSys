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
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
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


        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[0-9]+?|[\b\t]|[ X]|[.]"))
                e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[0-9]+?|[\b\t]|[ X]|[.]"))
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[0-9]+?|[\b\t]|[ X]|[.]"))
                e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[0-9]+?|[\b\t]|[ X]|[.]"))
                e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Order_Load(object sender, EventArgs e)
        {
            namecombo();
            comboBox2.SelectedIndex = 0;


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private bool ValidateName()
        {
            bool bStatus = true;
            if (comboBox1.Text == "")
            {
                errorProvider1.SetError(comboBox1, "Please Enter Valid Name");
                bStatus = false;
            }
            else
                errorProvider1.SetError(comboBox1, "");
            return bStatus;
        }

        private bool ValidateQty()
        {
            bool bStatus = true;
            if (textBox3.Text == "")
            {
                errorProvider1.SetError(textBox3, "Please Enter Valid Quantity");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBox3, "");
            return bStatus;
        }

        private bool ValidateHeight()
        {
            bool bStatus = true;
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Please Enter Valid Height");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBox1, "");
            return bStatus;
        }

        private bool ValidateWidth()
        {
            bool bStatus = true;
            if (textBox2.Text == "")
            {
                errorProvider1.SetError(textBox2, "Please Enter Valid Width");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBox2, "");
            return bStatus;
        }


        private bool ValidateGage()
        {
            bool bStatus = true;
            if (textBox4.Text == "")
            {
                errorProvider1.SetError(textBox4, "Please Enter Valid Gage");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBox4, "");
            return bStatus;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;

            bool drow= false;


            if(rows.Count==0)
            {
                drow = false;
                MessageBox.Show("No Item Ordered", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }else{
            drow=true ;
            }


            bool nam = ValidateName();
            bool qty = ValidateQty();
            bool hi = ValidateHeight();
            bool wi = ValidateWidth();
            bool ga = ValidateGage();


            string cname = comboBox1.Text;
            DateTime odate = dateTimePicker1.Value;

            string HostName;
            HostName = Environment.MachineName;

            string connetionString = null;
            SqlConnection connection;

            connetionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";

            connection = new SqlConnection(connetionString);

            if (nam == true & qty == true & hi == true & wi == true & ga == true & drow == true)
            {


                //-----------------------------------------------------
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string StrQuery = "INSERT INTO orderitem(cname,odate,item,width,height,gage,color,qty) VALUES ('" + cname + "', '" + odate.ToString() + "','" + dataGridView1.Rows[i].Cells["Column1"].Value + "', " + dataGridView1.Rows[i].Cells["Column4"].Value + ", " + dataGridView1.Rows[i].Cells["Column3"].Value + ", " + dataGridView1.Rows[i].Cells["Column5"].Value + ", '" + dataGridView1.Rows[i].Cells["Column6"].Value + "', " + dataGridView1.Rows[i].Cells["Column2"].Value + ");";
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

            }


            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            dataGridView1.Rows.Clear();




        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool qty = ValidateQty();
            bool hi = ValidateHeight();
            bool wi = ValidateWidth();
            bool gag = ValidateGage();

            string q = textBox3.Text;
            string h = textBox1.Text;
            string w = textBox2.Text;
            string g = textBox4.Text;
            string c = textBox5.Text;
            string t = comboBox2.Text;

            string[] row = new string[] { t,q, h, w,g,c };
            
            if (qty == true & hi == true & wi == true & gag == true)
            {

                dataGridView1.Rows.Add(row);
            }

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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }






    }
}
