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
    public partial class Stock : Form
    {



        float ld2;
        float lld2;
        float hm2;

        public Stock()
        {
            InitializeComponent();
            ld2 = 0;
            lld2 = 0;
            hm2 = 0;
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            show1();
        }

        void show1()
        {
            string HostName;
            HostName = Environment.MachineName;

            string connetionString = null;




            connetionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
            // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";


            string sql = "SELECT ld,lld,hm from stock";
            SqlConnection connection = new SqlConnection(connetionString);

            sql = "select ld,lld,hm from stock";
            //connection = new SqlConnection(connetionString);
            connection.Open();


            SqlCommand o_sqlCommand = new SqlCommand();
            o_sqlCommand.CommandText = sql;
            o_sqlCommand.Connection = connection;



            //create SQL data reader

            SqlDataReader o_sqlDataReader;

            //execute reader to store back retrieved data into reader object

            o_sqlDataReader = o_sqlCommand.ExecuteReader();


            float ld1 = 0;
            float lld1 = 0;
            float hm1 = 0;



            while (o_sqlDataReader.Read())
            {

                ld1 = float.Parse(o_sqlDataReader["ld"].ToString());
                lld1 = float.Parse(o_sqlDataReader["lld"].ToString());
                hm1 = float.Parse(o_sqlDataReader["hm"].ToString());




            }


            ld2 = ld1;
            lld2 = lld1;
            hm2 = hm1;

            textBox1.Text = ld1.ToString();
            textBox2.Text = hm1.ToString();
            textBox3.Text = lld1.ToString();

            o_sqlDataReader.Dispose();
            connection.Close();



        }

        private bool Validateld()
        {
            bool bStatus = true;
            if (textBox6.Text == "")
            {
                errorProvider1.SetError(textBox6, "Please LD");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBox6, "");
            return bStatus;
        }

        private bool Validatehm()
        {
            bool bStatus = true;
            if (textBox5.Text == "")
            {
                errorProvider1.SetError(textBox5, "Please HM");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBox5, "");
            return bStatus;
        }

        private bool Validatelld()
        {
            bool bStatus = true;
            if (textBox4.Text == "")
            {
                errorProvider1.SetError(textBox4, "Please HM");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBox4, "");
            return bStatus;
        }


        private void button1_Click(object sender, EventArgs e)
        {

            bool a = Validateld();
            bool b = Validatehm();
            bool c = Validatelld();

            if (a == true & b == true & c == true)
            {


                float ld3 = float.Parse(textBox6.Text);
                float lld3 = float.Parse(textBox5.Text);
                float hm3 = float.Parse(textBox4.Text);

                ld3 = ld2 - ld3;
                lld3 = lld2 - lld3;
                hm3 = hm2 - hm3;


                string HostName;
                HostName = Environment.MachineName;

                string connetionString = null;
                SqlConnection connection;


                connetionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                connection = new SqlConnection(connetionString);

                string sql = "update  stock set ld=" + ld3 + ",lld=" + lld3 + ",hm=" + hm3;
                connection = new SqlConnection(connetionString);
                //connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
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


                show1();
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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

    }
}
