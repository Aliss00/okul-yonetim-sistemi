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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Okul_Yönetim_Sistemi
{
    public partial class Ders : Form
    {
        public Ders()
        {
            InitializeComponent();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            try
            { 
            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cnn = new SqlCommand("insert into Derstab values (@DersNo,@DersAdı)", con);
            cnn.Parameters.AddWithValue("@DersNo", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@DersAdı", textBox2.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Ders başarıyla Kaydedildi!", "Kaydet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch 
            {
                MessageBox.Show("Kaydetme işlemi başarısız! Lütfen Ders No alanına sadece sayı girdiğinizden ve kutuları boş bırakmadığınızdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from Derstab", con);
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

            SqlCommand cnn = new SqlCommand("update Derstab set DersAdı=@DersAdı where DersNo=@DersNo", con);
            cnn.Parameters.AddWithValue("@DersNo", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@DersAdı", textBox2.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Ders başarıyla Güncellendi!", "Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
            catch
            {
                MessageBox.Show("Güncelleme işlemi başarısız! Lütfen Ders No alanına sadece sayı girdiğinizden ve kutuları boş bırakmadığınızdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnsil_Click(object sender, EventArgs e)
        {
            try 
            {
            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cnn = new SqlCommand("delete Derstab where DersNo=@DersNo", con);
            cnn.Parameters.AddWithValue("@DersNo", int.Parse(textBox1.Text));

            cnn.ExecuteNonQuery();
            con.Close();

                MessageBox.Show("Ders başarıyla Silindi", "Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch 
            {  
                MessageBox.Show("Silme işlemi başarısız! Lütfen Ders No alanına sadece sayı girdiğinizden ve kutuları boş bırakmadığınızdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            SqlCommand cnn = new SqlCommand("select * from Derstab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void Ders_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from Derstab", con);
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
