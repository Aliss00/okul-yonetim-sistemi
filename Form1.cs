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

namespace Okul_Yönetim_Sistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

           private void btnGiriş_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");

            try
            {
                
                string sorgu = "SELECT * FROM Öğretmenlertab WHERE Eposta = @eposta AND CAST(ÖğretmenNo AS VARCHAR) = @sifre";
                SqlCommand cnn = new SqlCommand(sorgu, con);

                cnn.Parameters.AddWithValue("@eposta", txtEposta.Text.Trim());
                cnn.Parameters.AddWithValue("@sifre", txtŞifre.Text.Trim()); 

                SqlDataAdapter da = new SqlDataAdapter(cnn);
                DataTable dt = new DataTable();

                con.Open();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    AnaSayfa gecisEkrani = new AnaSayfa();
                    gecisEkrani.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Eposta ya da Şifre hatalı lütfen kontrol edin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bağlantı hatası: " + hata.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

    }
    }
    
