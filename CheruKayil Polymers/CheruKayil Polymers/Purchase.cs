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
    public partial class Purchase : Form
    {
        public Purchase()
        {
            InitializeComponent();
        }

        private void namecombo()
        {
            string HostName = Environment.MachineName;

            string connetionString = null;

            connetionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
            // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";


            string sql = "SELECT distinct cname FROM supplier";
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

        private void Purchase_Load(object sender, EventArgs e)
        {
            namecombo();
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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


        private bool ValidateName()
        {
            bool bStatus = true;
            if (comboBox1 .Text == "")
            {
                errorProvider1.SetError(comboBox1, "Please Supplier Name");
                bStatus = false;
            }
            else
                errorProvider1.SetError(comboBox1, "");
            return bStatus;
        }

        private bool ValidateVehNo()
        {
            bool bStatus = true;
            if (textBox1 .Text == "")
            {
                errorProvider1.SetError(textBox1, "Please Supplier Name");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBox1, "");
            return bStatus;
        }

        private bool Tot()
        {
            bool bStatus = true;
            if (textBox2.Text == "")
            {
                errorProvider1.SetError(textBox2, "Please Vehicle Number");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBox2, "");
            return bStatus;
        }

        private bool ValidateItem()
        {
            bool bStatus = true;
            if (comboBox2 .Text == "")
            {
                errorProvider1.SetError(comboBox2, "Please Item Type");
                bStatus = false;
            }
            else
                errorProvider1.SetError(comboBox2, "");
            return bStatus;
        }

        private bool ValidateQty()
        {
            bool bStatus = true;
            if (textBox3 .Text == "")
            {
                errorProvider1.SetError(textBox3, "Please Item Type");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBox3, "");
            return bStatus;
        }


       



        private void button3_Click(object sender, EventArgs e)
        {



            string HostName;
            HostName = Environment.MachineName;

            string connetionString = null;
            SqlConnection connection;




            SqlDataAdapter adapter = new SqlDataAdapter();


            string sName = comboBox1.Text;

            bool n=ValidateName();
            bool vno=ValidateVehNo();
            bool to=Tot();

            int r = dataGridView1.Rows.Count;


            string sql;
            if (n == false | vno == false | to == false | r == 0)
            {
                MessageBox.Show("You Must Have Atlest One Item","Warnning",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);

            }else
            {
                
              //  DateTime pdate = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());

               // string  pdate = dateTimePicker1.Value.ToString("yyy-mm-dd HH:MM");

                //DateTime pdate1 = Convert.ToDateTime(pdate);


                DateTime pdate = dateTimePicker1.Value;


                


              //  MessageBox.Show(pdate.ToString());
                string vino = textBox1.Text;
                float tot = float.Parse(textBox2.Text);

               
               //SELECT        cid, cname, pdate, pvehicleno, pno, ptotal, totpaid, bal
                //FROM            purchase
                //WHERE        (pdate BETWEEN '10/22/2012' AND '10/27/2012')

                connetionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                connection = new SqlConnection(connetionString);

                 sql = "insert into purchase(cname,pdate,pvehicleno,ptotal,bal) values ('"+ sName+ "', '"+pdate.ToString()+"' , '"+ vino+"', "+ tot+ "," +tot +");";
               // MessageBox.Show(sql);

               // MessageBox.Show(sql);

                try{

                connection.Open();
                adapter.InsertCommand = new SqlCommand(sql, connection);
                adapter.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Data Inserted Into DataBase", "Sucess");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            connection.Close();

            
            }

            string itm;
            float qty;

            float ld=0;
            float lld=0;
            float hm=0;

            string a;
            for (int i = 0; i < dataGridView1.Rows.Count ; i++)
            {
              
                //dataGridView1.Rows[i].Cells[1].Value);
                //    b = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                //    tp = a * b;



                itm = dataGridView1.Rows[i].Cells[0].Value.ToString();
                a = dataGridView1.Rows[i].Cells[1].Value.ToString() ;
               // MessageBox.Show(itm.ToString());

                qty = float.Parse(a);


                if (itm == "HM")
                {
                    hm = hm + qty;
                }
                else if (itm == "LD")
                {
                    ld = ld + qty;
                }
                else if (itm == "LLD")
                {
                    lld = lld + qty;
                }


            }

         //   MessageBox.Show("hm=" + hm + " " + "ld=" + ld + " " + "lld=" + lld + " ");





            //0--------------------------------------------------------------------------

            connetionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
            // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
            connection = new SqlConnection(connetionString);

            sql = "select ld,lld,hm from stock";
            connection = new SqlConnection(connetionString);
             connection.Open();


            SqlCommand o_sqlCommand = new SqlCommand();
            o_sqlCommand.CommandText = sql;
            o_sqlCommand.Connection = connection;



            //create SQL data reader

            SqlDataReader o_sqlDataReader;

            //execute reader to store back retrieved data into reader object

            o_sqlDataReader = o_sqlCommand.ExecuteReader();

            float ld1=0;
            float lld1=0;
            float hm1=0;



            while (o_sqlDataReader.Read())
            {

                ld1 =float.Parse( o_sqlDataReader["ld"].ToString()) ;
                lld1 =float.Parse( o_sqlDataReader["lld"].ToString() );
                hm1 =float.Parse( o_sqlDataReader["hm"].ToString()) ;


              

            }
            connection.Close();


            hm = hm + hm1;
            ld = ld + ld1;
            lld = lld + lld1;






            //--------------------------------------------------------------------------------------------
           
            connetionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
            // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
            connection = new SqlConnection(connetionString);

            sql = "update  stock set ld=" + ld + ",lld=" + lld + ",hm=" + hm;


                 
                 //(ld,lld,hm) values (" + ld + ", " +lld + " , " + hm  +");";
            // MessageBox.Show(sql);

            try
            {

                connection.Open();
                adapter.InsertCommand = new SqlCommand(sql, connection);
                adapter.InsertCommand.ExecuteNonQuery();
             //   MessageBox.Show("Data Inserted Into DataBase", "Sucess");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            connection.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool itm= ValidateItem();
            bool qty=ValidateQty();
            string im = comboBox2.Text;
            string qt = textBox3.Text;

            string[] row = new string[] { im,qt };
           
            if (itm == true & qty == true)
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

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[a-zA-Z]+?|[\b\t]|[ X]"))
                e.Handled = true;
        }

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            bool tmp = ValidateName();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            bool tmp = ValidateVehNo();

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[0-9]+?|[\b\t]|[ X]|[.]"))
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[0-9]+?|[\b\t]|[ X]"))
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                Console.Write("Error");
            }
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            bool tmp = ValidateQty();
        }

       

        
    }
}
