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
    public partial class Login : Form
    {

         bool Uname;
         bool Pass;

         string HostName;
         

        private Timer Stats = new Timer();
        public Login()
        {
            InitializeComponent();
            Stats.Interval = 800;
            //closeTimer.Tick += new Eventhandler(closeTimer_Tick);
            Stats.Tick += new EventHandler(Show_Txt);
            Stats.Start();
                     

        }

        private void Show_Txt(object sender, EventArgs e)
        {

            HostName = Environment.MachineName;

            DateTime nw = DateTime.Now;

            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            conn.ConnectionString = "Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
            //label3.Text = conn.ConnectionString.ToString();

           // button1.Enabled = true;

            try
            {
                progressBar1.Value = progressBar1.Value + 10;
                if (progressBar1.Value <= 10)
                {
                    label3.Text = "Loading...";
                }else if(progressBar1.Value<=20)
                {
                    label3.Text = "Getting System Date..." + nw;
                }
                else if (progressBar1.Value <= 40)
                {
                    label3.Text = "Checking System Name..."+ HostName;
                }
                else if (progressBar1.Value <= 60)
                {
                    label3.Text = "Preparing Connection String SQLServer...";
                }
                else if (progressBar1.Value <= 80)
                {
                    label3.Text = "Checking DataBase Connection...";
                   // Stats.Stop();  
   
                    try
                    {
                        conn.Open();
                        label3.Text = "Connection  Successful :" + conn.ConnectionString.ToString();
                    }
                    catch (Exception ex)
                    {
                        label3.Text = ex.Message;
                        Stats.Stop();
                        
                    }


                }
                else if (progressBar1.Value <= 95)
                {
                    pictureBox3.Hide();
                }
                               
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Stats.Stop();
            }

            conn.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private bool ValidateName()
        {
            bool bStatus = true;
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Please Admin User Name");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBox1, "");
            return bStatus;
        }
        private bool ValidatePass()
        {
            bool bStatus = true;
            if (textBox2.Text == "")
            {
                errorProvider1.SetError(textBox2, "Please Admin Password");
                bStatus = false;
            }
            else
                errorProvider1.SetError(textBox2, "");
            return bStatus;
        }


        private bool ValidateFrm()
        {
            Uname = ValidateName();
            Pass = ValidatePass();
            if (Uname == true & Pass == true)
            {
                button1.Enabled = true;

                return true;


            }
            else
            {
                button1.Enabled = false;
                return false;
                
            }


        }

       


        private void button1_Click(object sender, EventArgs e)
        {
            
           
          
            string UsName = textBox1.Text;
            string Passwd = textBox2.Text;

            HostName = Environment.MachineName;

            SqlConnection lgnConnection = new SqlConnection();
            lgnConnection.ConnectionString ="Data Source=" + HostName + "\\sqlexpress;Initial Catalog=PMSYS;Integrated Security=True;Pooling=False";
            lgnConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT name,pass FROM admin WHERE name='" + textBox1.Text + "' and pass='" + textBox2 .Text + "'", lgnConnection);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            MainForm frm1 = new MainForm();

          

            while (dr.Read())
            {
                if (dr["name"].ToString() == textBox1.Text && dr["pass"].ToString() == textBox2.Text)
                {
                    this.Hide();
                    //  frm1.ShowDialog();
                    frm1.Show();
                }
               

                
              

            }


            



        }

       

           
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            bool tmp = ValidateFrm();
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            bool tmp = ValidateFrm();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
            
           
    }
}
