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
    public partial class Devamsızlık : Form
    {
        public Devamsızlık()
        {
            InitializeComponent();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            try
            { 
            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cnn = new SqlCommand("insert into Devamsızlık (ÖğrenciNo, Durum, Ders, Tarih) values (@ÖğrenciNo, @Durum, @Ders, @Tarih)", con);
            cnn.Parameters.AddWithValue("@DevamsızlıkNo", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@ÖğrenciNo", textBox2.Text);
            cnn.Parameters.AddWithValue("@Durum", comboBox1.Text);
            cnn.Parameters.AddWithValue("@Ders", comboBox2.Text);
            cnn.Parameters.AddWithValue("@Tarih", dateTimePicker1.Value);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Devamsızlık başarıyla Kaydedildi!", "Kaydet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch 
            {
                MessageBox.Show("Kaydetme işlemi başarısız! Lütfen kutuları boş bırakmadığınızdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from Devamsızlık", con);
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

            SqlCommand cnn = new SqlCommand("update Devamsızlık set ÖğrenciNo=@ÖğrenciNo,Durum=@Durum,Ders=@Ders,Tarih=@Tarih where DevamsızlıkNo=@DevamsızlıkNo", con);
            cnn.Parameters.AddWithValue("@DevamsızlıkNo", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@ÖğrenciNo", textBox2.Text);
            cnn.Parameters.AddWithValue("@Durum", comboBox1.Text);
            cnn.Parameters.AddWithValue("@Ders", comboBox2.Text);
            cnn.Parameters.AddWithValue("@Tarih", dateTimePicker1.Value);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Devamsızlık başarıyla Güncellendi!", "Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch 
            {
                MessageBox.Show("Güncelleme işlemi başarısız! Lütfen kutuları boş bırakmadığınızdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            try
            { 

            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cnn = new SqlCommand("delete Devamsızlık where DevamsızlıkNo=@DevamsızlıkNo", con);
            cnn.Parameters.AddWithValue("@DevamsızlıkNo", int.Parse(textBox1.Text));

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Devamsızlık başarıyla Silindi", "Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Silme işlemi başarısız! Lütfen kutuları boş bırakmadığınızdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnyeni_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "Seçiniz...";
            comboBox2.Text = "Seçiniz...";
            dateTimePicker1.Value = DateTime.Now;
        }

        private void btngorun_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from Devamsızlık", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       

            private void Devamsızlık_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");
                con.Open();

                SqlCommand komut = new SqlCommand("SELECT DersAdı FROM Derstab", con);
                SqlDataReader oku = komut.ExecuteReader();

                comboBox2.Items.Clear(); 

                while (oku.Read())
                {
                    comboBox2.Items.Add(oku["DersAdı"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            { 
           
                MessageBox.Show("Veri çekme hatası: " + ex.Message);
            }
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