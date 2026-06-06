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
    public partial class Bolum : Form
    {
        public Bolum()
        {
            InitializeComponent();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            try
            { 
            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cnn = new SqlCommand("insert into Bolumtab values (@BölümNo, @BölümAdı)", con);
            cnn.Parameters.AddWithValue("@BölümNo", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@BölümAdı", textBox2.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Bölüm başarıyla Kaydedildi!", "Kaydet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Kaydetme işlemi başarısız! Lütfen Bölüm No alanına sadece sayı girdiğinizden ve kutuları boş bırakmadığınızdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from Bolumtab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btngun_Click(object sender, EventArgs e)
        {
            try
            {

            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cnn = new SqlCommand("update Bolumtab set BölümAdı=@BölümAdı where BölümNo=@BölümNo", con);
            cnn.Parameters.AddWithValue("@BölümNo", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@BölümAdı", textBox2.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Bölüm başarıyla Güncellendi!", "Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Güncelleme işlemi başarısız! Lütfen Bölüm No alanına sadece sayı girdiğinizden ve kutuları boş bırakmadığınızdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            try
            { 
            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cnn = new SqlCommand("delete Bolumtab where BölümNo=@BölümNo", con);
            cnn.Parameters.AddWithValue("@BölümNo", int.Parse(textBox1.Text));

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Bölüm başarıyla Silindi", "Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch 
            {
                MessageBox.Show("Silme işlemi başarısız! Lütfen Bölüm No alanına sadece sayı girdiğinizden ve kutuları boş bırakmadığınızdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnyeni_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void btngorun_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from Bolumtab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from Öğretmenlertab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
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
    }
    }

