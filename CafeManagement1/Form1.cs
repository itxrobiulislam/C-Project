using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CafeManagement1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-4I67UUF2;Initial Catalog=Cafe;Integrated Security=True");
        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            GuestOrder guest = new GuestOrder();
            guest.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*UserOrder uorder = new UserOrder();
            uorder.Show();
            this.Hide();
            */
            if(UnameTb.Text==""||PasswordTb.Text=="")
            {
                MessageBox.Show("Enter A Username Or Password");
            }
            else
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*)from UsersTbl where Uname='" + UnameTb.Text + "' and Upassword='" + PasswordTb.Text + "'",Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(dt.Rows[0][0].ToString() == "1")
                {
                    UserOrder uorder = new UserOrder();
                    uorder.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password ");
                }
                Con.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
