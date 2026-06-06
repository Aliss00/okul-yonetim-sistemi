using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Okul_Yönetim_Sistemi
{
    public partial class Panel : Form
    {
        public Panel()
        {
            InitializeComponent();
        }

        private void Panel_Load(object sender, EventArgs e)
        {
            display();
            display1();
            display2();
            display3();

        }

        private void display()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("select count(*) from Öğrencitablo", con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0 ) 
            {
                lbog.Text = count.ToString(count.ToString());
            }
            else 
            {
                lbog.Text = "0";
            }

            con.Close();

        }

        private void display1()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("select count(*) from Öğretmenlertab", con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                lbog1.Text = count.ToString(count.ToString());
            }
            else
            {
                lbog1.Text = "0";
            }

            con.Close();

        }

        private void display2()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("select count(*) from Bolumtab", con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                lbbol.Text = count.ToString(count.ToString());
            }
            else
            {
                lbbol.Text = "0";
            }

            con.Close();

        }

        private void display3()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("select count(*) from Derstab", con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                lbder.Text = count.ToString(count.ToString());
            }
            else
            {
                lbder.Text = "0";
            }

            con.Close();
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Application.OpenForms["AnaSayfa"].Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Ana menü kapatılmış! Lütfen programı yeniden başlatın.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lbog1_Click(object sender, EventArgs e)
        {

        }
    }
}
