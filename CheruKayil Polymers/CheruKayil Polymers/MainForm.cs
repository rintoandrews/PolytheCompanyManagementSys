using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CheruKayil_Polymers
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void viewSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // a flag to store if the child form is opened or not
            bool found = false;


            // get all of the MDI children in an array
            Form[] charr = this.MdiChildren;


           



                if (charr.Length == 0)      // no child form is opened
                {


                    Supplier frm1 = new Supplier();
                    frm1.MdiParent = this;
                    frm1.StartPosition = FormStartPosition.CenterParent;
                    
                    frm1.Show();


                }
                else      // child forms are opened
                {
                    try
                    {


                        foreach (Form chform in charr)
                        {
                            if (chform.Name == "Supplier")
                            // one instance of the form is already opened
                            {
                                chform.Activate();
                                found = true;
                                break;   // exit loop
                            }
                            else
                                found = false;      // make sure flag is set to
                            // false if the form is not found
                        }
                    }
                    catch (Exception ex)

                    {
                        Console.Beep();
                        
                    }


                }
            }

        private void addSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
             bool found = false;


            // get all of the MDI children in an array
            Form[] charr = this.MdiChildren;


           



                if (charr.Length == 0)      // no child form is opened
                {


                    Supplier frm1 = new Supplier();
                    frm1.MdiParent = this;
                    frm1.StartPosition = FormStartPosition.CenterParent;
                    
                    frm1.Show();


                }
                else      // child forms are opened
                {
                    try
                    {


                        foreach (Form chform in charr)
                        {
                            if (chform.Name == "Supplier")
                            // one instance of the form is already opened
                            {
                                chform.Activate();
                                found = true;
                                break;   // exit loop
                            }
                            else
                                found = false;      // make sure flag is set to
                            // false if the form is not found
                        }
                    }
                    catch (Exception ex)

                    {
                        Console.Beep();
                        
                    }


                }
            }

        private void deleteSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
             bool found = false;


            // get all of the MDI children in an array
            Form[] charr = this.MdiChildren;


           



                if (charr.Length == 0)      // no child form is opened
                {


                    Supplier frm1 = new Supplier();
                    frm1.MdiParent = this;
                    frm1.StartPosition = FormStartPosition.CenterParent;
                    
                    frm1.Show();


                }
                else      // child forms are opened
                {
                    try
                    {


                        foreach (Form chform in charr)
                        {
                            if (chform.Name == "Supplier")
                            // one instance of the form is already opened
                            {
                                chform.Activate();
                                found = true;
                                break;   // exit loop
                            }
                            else
                                found = false;      // make sure flag is set to
                            // false if the form is not found
                        }
                    }
                    catch (Exception ex)

                    {
                        Console.Beep();
                        
                    }


                }
            }

        private void updateSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;


            // get all of the MDI children in an array
            Form[] charr = this.MdiChildren;






            if (charr.Length == 0)      // no child form is opened
            {


                Supplier frm1 = new Supplier();
                frm1.MdiParent = this;
                frm1.StartPosition = FormStartPosition.CenterParent;

                frm1.Show();


            }
            else      // child forms are opened
            {
                try
                {


                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "Supplier")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop
                        }
                        else
                            found = false;      // make sure flag is set to
                        // false if the form is not found
                    }
                }
                catch (Exception ex)
                {
                    Console.Beep();

                }


            }
        }

        private void purchaseItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // a flag to store if the child form is opened or not
            bool found = false;
                        // get all of the MDI children in an array
            Form[] charr = this.MdiChildren;
              if (charr.Length == 0)      // no child form is opened
            {


                Purchase frm1 = new Purchase();
                frm1.MdiParent = this;
                frm1.StartPosition = FormStartPosition.CenterParent;

                frm1.Show();


            }
            else      // child forms are opened
            {
                try
                {


                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "Purchase")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop
                        }
                        else
                            found = false;      // make sure flag is set to
                        // false if the form is not found
                    }
                }
                catch (Exception ex)
                {
                    Console.Beep();

                }


            }
        }

        private void cashDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //PurchaseCash frm = new PurchaseCash();
            //frm.Show();

            bool found = false;
            
            // get all of the MDI children in an array
            Form[] charr = this.MdiChildren;
            
            if (charr.Length == 0)      // no child form is opened
            {


               

                PurchaseCash frm = new PurchaseCash();

                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterParent;

                frm.Show();


            }
            else      // child forms are opened
            {
                try
                {


                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "Purchase")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop
                        }
                        else
                            found = false;      // make sure flag is set to
                        // false if the form is not found
                    }
                }
                catch (Exception ex)
                {
                    Console.Beep();

                }


            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            



        }

        private void purchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            // get all of the MDI children in an array
            Form[] charr = this.MdiChildren;
            
            if (charr.Length == 0)      // no child form is opened
            {
                PurchaseRpt frm1 = new PurchaseRpt();
                frm1.MdiParent = this;
                frm1.StartPosition = FormStartPosition.CenterParent;
                
                frm1.Show();


            }
            else      // child forms are opened
            {
                try
                {


                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "PurchaseRpt")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop
                        }
                        else
                            found = false;      // make sure flag is set to
                        // false if the form is not found
                    }
                }
                catch (Exception ex)
                {
                    Console.Beep();

                }


            }

        }

        private void cutomerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            // get all of the MDI children in an array
            Form[] charr = this.MdiChildren;
            if (charr.Length == 0)      // no child form is opened
            {


                Cutomer frm1 = new Cutomer();
                frm1.MdiParent = this;
                frm1.StartPosition = FormStartPosition.CenterParent;

                frm1.Show();


            }
            else      // child forms are opened
            {
                try
                {


                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "Cutomer")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop
                        }
                        else
                            found = false;      // make sure flag is set to
                        // false if the form is not found
                    }
                }
                catch (Exception ex)
                {
                    Console.Beep();

                }


            }
        }

        private void makeOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            // get all of the MDI children in an array
            Form[] charr = this.MdiChildren;
            if (charr.Length == 0)      // no child form is opened
            {


                Order frm1 = new Order();
                frm1.MdiParent = this;
                frm1.StartPosition = FormStartPosition.CenterParent;

                frm1.Show();


            }
            else      // child forms are opened
            {
                try
                {


                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "Order")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop
                        }
                        else
                            found = false;      // make sure flag is set to
                        // false if the form is not found
                    }
                }
                catch (Exception ex)
                {
                    Console.Beep();

                }


            }
        }

        private void viewOrderDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            // get all of the MDI children in an array
            Form[] charr = this.MdiChildren;
            if (charr.Length == 0)      // no child form is opened
            {


                ViewOrder frm1 = new ViewOrder();
                frm1.MdiParent = this;
                frm1.StartPosition = FormStartPosition.CenterParent;

                frm1.Show();


            }
            else      // child forms are opened
            {
                try
                {


                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "ViewOrder")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop
                        }
                        else
                            found = false;      // make sure flag is set to
                        // false if the form is not found
                    }
                }
                catch (Exception ex)
                {
                    Console.Beep();

                }


            }
        }

        private void saleProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            // get all of the MDI children in an array
            Form[] charr = this.MdiChildren;
            if (charr.Length == 0)      // no child form is opened
            {


                Sales frm1 = new Sales();
                frm1.MdiParent = this;
                frm1.StartPosition = FormStartPosition.CenterParent;

                frm1.Show();


            }
            else      // child forms are opened
            {
                try
                {


                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "Sales")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop
                        }
                        else
                            found = false;      // make sure flag is set to
                        // false if the form is not found
                    }
                }
                catch (Exception ex)
                {
                    Console.Beep();

                }


            }

        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {


            bool found = false;
            // get all of the MDI children in an array
            Form[] charr = this.MdiChildren;
            if (charr.Length == 0)      // no child form is opened
            {


                SaleRpt frm1 = new SaleRpt();
                frm1.MdiParent = this;
                frm1.StartPosition = FormStartPosition.CenterParent;

                frm1.Show();


            }
            else      // child forms are opened
            {
                try
                {


                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "SaleRpt")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop
                        }
                        else
                            found = false;      // make sure flag is set to
                        // false if the form is not found
                    }
                }
                catch (Exception ex)
                {
                    Console.Beep();

                }


            }
        }

        private void chashDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            // get all of the MDI children in an array
            Form[] charr = this.MdiChildren;
            if (charr.Length == 0)      // no child form is opened
            {


                SaleCash frm1 = new SaleCash();
                frm1.MdiParent = this;
                frm1.StartPosition = FormStartPosition.CenterParent;

                frm1.Show();


            }
            else      // child forms are opened
            {
                try
                {


                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "SaleCash")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop
                        }
                        else
                            found = false;      // make sure flag is set to
                        // false if the form is not found
                    }
                }
                catch (Exception ex)
                {
                    Console.Beep();

                }


            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool found = false;
            // get all of the MDI children in an array
            Form[] charr = this.MdiChildren;
            if (charr.Length == 0)      // no child form is opened
            {


                SaleCshRpt frm1 = new SaleCshRpt();
                frm1.MdiParent = this;
                frm1.StartPosition = FormStartPosition.CenterParent;

                frm1.Show();


            }
            else      // child forms are opened
            {
                try
                {


                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "SaleCshRpt")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop
                        }
                        else
                            found = false;      // make sure flag is set to
                        // false if the form is not found
                    }
                }
                catch (Exception ex)
                {
                    Console.Beep();

                }


            }

        }

        private void currentStockDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            // get all of the MDI children in an array
            Form[] charr = this.MdiChildren;
            if (charr.Length == 0)      // no child form is opened
            {


                Stock frm1 = new Stock();
                frm1.MdiParent = this;
                frm1.StartPosition = FormStartPosition.CenterParent;

                frm1.Show();


            }
            else      // child forms are opened
            {
                try
                {


                    foreach (Form chform in charr)
                    {
                        if (chform.Name == "Stock")
                        // one instance of the form is already opened
                        {
                            chform.Activate();
                            found = true;
                            break;   // exit loop
                        }
                        else
                            found = false;      // make sure flag is set to
                        // false if the form is not found
                    }
                }
                catch (Exception ex)
                {
                    Console.Beep();

                }


            }
        }

        }

        }

        

       

  


