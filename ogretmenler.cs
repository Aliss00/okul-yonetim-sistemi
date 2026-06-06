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
    public partial class ogretmenler : Form
    {
        public ogretmenler()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ogretmenler_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from Öğretmenlertab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");
                con.Open();

                SqlCommand cnn = new SqlCommand("insert into Öğretmenlertab values (@ÖğretmenNo, @ÖğretmenAdı, @Cinsiyet, @Eposta)", con);
                cnn.Parameters.AddWithValue("@ÖğretmenNo", int.Parse(textBox1.Text));
                cnn.Parameters.AddWithValue("@ÖğretmenAdı", textBox2.Text);
                cnn.Parameters.AddWithValue("@Cinsiyet", textBox3.Text.Length > 0 ? textBox3.Text.Substring(0, 1).ToUpper() : "");
                cnn.Parameters.AddWithValue("@Eposta", textBox4.Text);

                cnn.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Personel başarıyla kaydedildi!", "Kaydet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Kaydetme işlemi başarısız! Lütfen Personel No alanına sadece sayı girdiğinizden ve kutuları boş bırakmadığınızdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from Öğretmenlertab", con);
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

                SqlCommand cnn = new SqlCommand("update Öğretmenlertab set ÖğretmenAdı=@ÖğretmenAdı,Cinsiyet=@Cinsiyet,Eposta=@Eposta where ÖğretmenNo=@ÖğretmenNo", con);
                cnn.Parameters.AddWithValue("@ÖğretmenNo", int.Parse(textBox1.Text));
                cnn.Parameters.AddWithValue("@ÖğretmenAdı", textBox2.Text);
                cnn.Parameters.AddWithValue("@Cinsiyet", textBox3.Text.Substring(0, 1).ToUpper());
                cnn.Parameters.AddWithValue("@Eposta", textBox4.Text);
                cnn.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Öğretmen başarıyla Güncellendi!", "Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Güncelleme başarısız! Lütfen boş alan bırakmadığınızdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");
                con.Open();

                SqlCommand cnn = new SqlCommand("delete Öğretmenlertab where ÖğretmenNo=@ÖğretmenNo", con);
                cnn.Parameters.AddWithValue("@ÖğretmenNo", int.Parse(textBox1.Text));

                cnn.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Öğretmen başarıyla Silindi", "Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Silme işlemi başarısız! Lütfen Personel No alanını boş bırakmadığınızdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnyeni_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            
        }

        private void btngorun_Click(object sender, EventArgs e)
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
        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
