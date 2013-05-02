using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;


namespace CheruKayil_Polymers
{
    public partial class Supplier : Form
    {
        public Supplier()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool Vname = ValidateName();
            bool Vadd = ValidateAdd();
            bool Vplace = ValidatePlace();
           bool Vph1 = ValidatePh1();
            bool Vph2 = ValidatePh2();
            bool Vmob = ValidateMob();
            bool Vmail = ValidateMail();

            if (Vname == true & Vadd == true & Vplace == true & Vmail == true & Vph1==true & Vph2==true & Vmob==true )
            {
                addRow();

                grdShow();

                txtclr();

                namecombo();
            }
            else
            {
                MessageBox.Show("Please Enter Mandatroy Feilds", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void addRow()
        {
            string HostName;
            HostName = Environment.MachineName;

            string connetionString = null;
            SqlConnection connection;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = null;

            //-----------------------------------
            string name = textBox1.Text;
            string add = textBox2.Text;
            string place = textBox3.Text;
            string ph1 = textBox4 .Text;
            string ph2 = textBox5 .Text;
            string mob = textBox6 .Text;
            string mail = textBox7.Text;
            string tin = null;
            try
            {
                tin = textBox8.Text;

            }
            catch (Exception ex)
            {
                Console.Write("Null In Tin Number" + ex.Message);
            }
            //-----------------------

            connetionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
            // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
            connection = new SqlConnection(connetionString);


            sql = "insert into supplier(cname,cadd,cplace,cphone1,cphone2,mob,ctin,mail) values('" + name + "','" + add + "','" + place + "','" + ph1 + "','" + ph2 + "','" + mob + "','" + tin + "','" + mail + "')";


            try
            {
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


        private void grdShow()
        {
            string HostName;
            HostName = Environment.MachineName;

            string connetionString = null;




            connetionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
            // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";


            string sql = "SELECT cname as Name, cadd as Address, cplace as Place, cphone1 as Phone1 , cphone2 as Phone2, mob as Mobil, ctin as TinNumber, mail as Mail FROM supplier";
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



        private bool ValidateName()
        {
            bool bStatus = true;
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Please Enter Valid Name");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBox1, "");
            return bStatus;
        }

        private bool ValidateAdd()
        {
            bool bStatus = true;
            if (textBox2.Text == "")
            {
                errorProvider1.SetError(textBox2, "Please Enter Adress");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBox2, "");
            return bStatus;
        }

        private bool ValidatePlace()
        {
            bool bStatus = true;
            if (textBox3.Text == "")
            {
                errorProvider1.SetError(textBox3, "Please Enter Place");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBox3, "");
            return bStatus;
        }
        private bool ValidatePh1()
        {
            bool bStatus = true;
            if (textBox4.Text.Length ==0)
            {
                errorProvider1.SetError(textBox4, "Please Enter Phone Number");
                
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBox4, "");
            return bStatus;
        }

        private bool ValidatePh2()
        {
            bool bStatus = true;
            if (textBox5.Text == "")
            {
                errorProvider1.SetError(textBox5, "Please Enter Phone Number");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBox5, "");
            return bStatus;
        }

        private bool ValidateMob()
        {
            bool bStatus = true;
            string tmp = textBox6.Text;
            int a = tmp.Length;
            if (textBox6.Text == "")
            {
                errorProvider1.SetError(textBox6, "Please Enter Mobile Number");
                bStatus = false;
                
            }
           
                 else if (a !=10)
            {
                errorProvider1.SetError(textBox6, "Please Enter Phone Number(10 digit)");

                bStatus = false;
            }
            else
                errorProvider1.SetError(textBox6, "");
            return bStatus;
        }

        private bool ValidateMail()
        {
            bool bStatus = true;

            string ma = textBox7.Text;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            Regex re = new Regex(strRegex);

            if (textBox7.Text == "" | re.IsMatch(ma)==false  )
            {
                errorProvider1.SetError(textBox7, "Please Enter Mail");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBox7, "");
            return bStatus;
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[0-9]+?|[\b\t]|[ X]"))
                    e.Handled = true;
            }catch(Exception ex)
            {
                Console.Write("Error");
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "[0-9]+?|[\b\t]|[ X]"))
                    e.Handled = true;
            }catch(Exception ex)
            {
                Console.Write("Error");
            }
        }

        private void Supplier_Load(object sender, EventArgs e)
        {
            grdShow();
            namecombo();

            
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

        private void button4_Click(object sender, EventArgs e)
        {
            
            delrow();
            grdShow();
            txtclr();

            namecombo();

        }

        //private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        //{
        //    string name = null;
        //    name = comboBox1.Text;
        //    string HostName = Environment.MachineName;

        //    string connetionString = null;

        //    connetionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
        //    // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";


        //    string sql = "SELECT cname FROM supplier where cname='" + name + "';" ;
        //    SqlConnection connection = new SqlConnection(connetionString);
        //              SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
        //    DataSet ds = new DataSet();

        //    try
        //    {
        //        connection.Open();
        //        dataadapter.Fill(ds, "suppliers_table");
        //        connection.Close();
        //        dataGridView1.DataSource = ds;
        //        dataGridView1.DataMember = "suppliers_table";
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error Occoured...", "Error", MessageBoxButtons.OK);
        //    }


        //}

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            string name = null;
            name = comboBox1.Text;
            string HostName = Environment.MachineName;

            string connetionString = null;

            connetionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
            // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";


            string sql = "SELECT cname as Name, cadd as Address, cplace as Place, cphone1 as Phone1 , cphone2 as Phone2, mob as Mobil, ctin as TinNumber, mail as Mail FROM supplier where cname='"+name + "';";
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
                MessageBox.Show("Error Occoured..." + ex.Message , "Error", MessageBoxButtons.OK);
            }
        }

       

      

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {

            try
            {

                DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;
                string val = (string)rows[0].Cells["Name"].Value;
                //label13.Text = val.ToString();
            }
            catch (Exception ex)
            {
                Console.Write("Nothing Selected");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;

            string name=null ;
            string add=null ;
            string plc=null ;
                 string ph1=null ;
                 string ph2=null ;
                 string Mob=null ;
                 string Tin=null ;
                 string mail=null ;

                 try
                 {

                     name = (string)rows[0].Cells["Name"].Value.ToString();
                     add = (string)rows[0].Cells["Address"].Value.ToString();
                     plc = (string)rows[0].Cells["Place"].Value.ToString();
                     ph1 = (string)rows[0].Cells["Phone1"].Value.ToString();
                     ph2 = (string)rows[0].Cells["Phone2"].Value.ToString();
                     Mob = (string)rows[0].Cells["Mobil"].Value.ToString();
                     Tin = (string)rows[0].Cells["TinNumber"].Value.ToString();
                     mail = (string)rows[0].Cells["Mail"].Value.ToString();

                 }
                 catch (Exception ex)
                 {
                 }



            if (rows.Count == 0)
            {
                MessageBox.Show("Select Company Details From Grid For Editing...", "Warnning");
            }
            else
            {
                textBox1.Text = name;
                textBox2.Text = add;
                textBox3.Text = plc;
                textBox4 .Text = ph1;
                textBox5 .Text = ph2;
                textBox6 .Text = Mob;
                textBox8.Text = Tin;
                textBox7.Text = mail;

            }

            button1.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
        
        }

        private void txtclr()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
                textBox4 .Text="";
            textBox5 .Text="";
            textBox6 .Text="";
            textBox7.Text="";
            textBox8.Text = "";

        
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button4.Enabled=true;

            

      DialogResult rst=MessageBox.Show("Do You Want To Update", "Warnning", MessageBoxButtons.YesNo,MessageBoxIcon.Question );

      if (rst == DialogResult.Yes)
      {
          updaterow();

          grdShow();

          txtclr();

          namecombo();
      }
      else
      {
          grdShow();

          txtclr();

          namecombo();
      }


     

        }


        private void updaterow()
        {
            string HostName;
            HostName = Environment.MachineName;

            string connetionString = null;
            SqlConnection connection;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = null;

            //-----------------------------------
            string name = textBox1.Text;
            string add = textBox2.Text;
            string place = textBox3.Text;
            string ph1 = textBox4 .Text;
            string ph2 = textBox5 .Text;
            string mob = textBox6 .Text;
            string mail = textBox7.Text;
            string tin = null;
            try
            {
                tin = textBox8.Text;

            }
            catch (Exception ex)
            {
                Console.Write("Null In Tin Number" + ex.Message);
            }
            //-----------------------

            connetionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
            // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
            connection = new SqlConnection(connetionString);


            sql = "update supplier set cname = '" + name + "' ,cadd=' " + add + "' ,cplace='" + place + "' ,cphone1='" + ph1 + "' ,cphone2='" + ph2 + "' ,mob='" + mob + "' ,ctin='" + tin + "' ,mail='" + mail + "' where cname like '" + name + "'";
            //MessageBox.Show(sql.ToString());

            try
            {
                connection.Open();
                adapter.InsertCommand = new SqlCommand(sql, connection);
                adapter.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Data Update Into DataBase", "Sucess");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            connection.Close();


        }

        private void delrow()
        {
            string HostName;
            HostName = Environment.MachineName;

            string connetionString = null;
            SqlConnection connection;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = null;



            DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;
              string name=null ;

              bool ye = false;

              DialogResult rst = MessageBox.Show("Do You Want To Delete", "Warnning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
              if (rst == DialogResult.Yes)
              {
                  try
                  {
                      if (rows.Count == 0)
                      {
                          MessageBox.Show("Select Row To Be Deleted", "Error");
                          ye = true;
                      }
                      else
                      {

                          name = (string)rows[0].Cells["Name"].Value.ToString();
                      }
                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show("Select Row To Be Deleted", "Error");
                  }
            



            //-----------------------------------
          
            
            //-----------------------

            connetionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
            // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
            connection = new SqlConnection(connetionString);


          //  sql = "update supplier set cname = '" + name + "' ,cadd=' " + add + "' ,cplace='" + place + "' ,cphone1='" + ph1 + "' ,cphone2='" + ph2 + "' ,mob='" + mob + "' ,ctin='" + tin + "' ,mail='" + mail + "' where cname like '" + name + "'";
            //MessageBox.Show(sql.ToString());
            sql = "delete from supplier where cname like '" + name + "'";

            if (ye == false)
            {
                try
                {
                    connection.Open();
                    adapter.InsertCommand = new SqlCommand(sql, connection);
                    adapter.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("Deleted From DataBase", "Sucess");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }


                connection.Close();
            }

              }
              else
              {

              } 


        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            bool tmp = ValidateName();

        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            bool tmp = ValidateAdd();

        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            bool tmp = ValidatePlace();
        }

        private void textBox7_KeyUp(object sender, KeyEventArgs e)
        {
            bool tmp = ValidateMail();
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            bool tmp = ValidatePh1();
        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            bool tmp = ValidatePh2();
        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            bool tmp = ValidateMob();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

      










    }// calsss




}  // name space

