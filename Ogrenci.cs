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
    public partial class Ogrenci : Form
    {
        public Ogrenci()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            { 
            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cnn = new SqlCommand("insert into Öğrencitablo (ÖğrenciNo,ÖğrenciAdı,DT,Cinsiyet,Telefon,BölümNo) values (@ÖğrenciNo,@ÖğrenciAdı,@DT,@Cinsiyet,@Telefon,@BölümNo)", con);
            cnn.Parameters.AddWithValue("@ÖğrenciNo", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@ÖğrenciAdı", textBox2.Text);
            cnn.Parameters.AddWithValue("@DT", dateTimePicker1.Value);
            cnn.Parameters.AddWithValue("@Cinsiyet", textBox3.Text.Substring(0, 1).ToUpper());
            cnn.Parameters.AddWithValue("@Telefon", textBox4.Text);
            cnn.Parameters.AddWithValue("@BölümNo", comboBox1.SelectedValue);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Öğrenci başarıyla Kaydedildi!", "Kaydet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            catch
            {
                MessageBox.Show("Kaydetme işlemi başarısız! Lütfen kutuları boş bırakmadığınızdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            { 
            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cnn = new SqlCommand("delete Öğrencitablo where ÖğrenciNo=@ÖğrenciNo", con);
            cnn.Parameters.AddWithValue("@ÖğrenciNo", int.Parse(textBox1.Text));

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Öğrenci başarıyla Silindi!", "Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            catch
            {
                MessageBox.Show("Silme işlemi başarısız! Lütfen Öğrenci No alanını boş bırakmadığınızdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateTimePicker1.CustomFormat = " ";
            }
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from Öğrencitablo", con);
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

                SqlCommand cnn = new SqlCommand("update Öğrencitablo set ÖğrenciAdı=@ÖğrenciAdı, DT=@DT, Cinsiyet=@Cinsiyet, Telefon=@Telefon, BölümNo=@BölümNo where ÖğrenciNo=@ÖğrenciNo", con);
                cnn.Parameters.AddWithValue("@ÖğrenciNo", int.Parse(textBox1.Text));
                cnn.Parameters.AddWithValue("@ÖğrenciAdı", textBox2.Text);
                cnn.Parameters.AddWithValue("@DT", dateTimePicker1.Value);
                cnn.Parameters.AddWithValue("@Cinsiyet", textBox3.Text.Length > 0 ? textBox3.Text.Substring(0, 1).ToUpper() : "");
                cnn.Parameters.AddWithValue("@Telefon", textBox4.Text);
                cnn.Parameters.AddWithValue("@BölümNo", comboBox1.SelectedValue);

                cnn.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Öğrenci başarıyla Güncellendi!", "Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            catch
            { 
                MessageBox.Show("Güncelleme işlemi başarısız! Lütfen Öğrenci No alanını ve diğer kutuları boş bırakmadığınızdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
        }



        private void btnyeni_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "Seçiniz..." ;
            dateTimePicker1.Value = DateTime.Now;

        }

        private void btngorun_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cnn = new SqlCommand("SELECT Ö.ÖğrenciNo, Ö.ÖğrenciAdı, Ö.DT, Ö.Cinsiyet, Ö.Telefon, B.BölümAdı FROM Öğrencitablo Ö INNER JOIN Bolumtab B ON Ö.BölümNo = B.BölümNo", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void siticonePanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticonePanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void hep(object sender, EventArgs e)
        {

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Ogrenci_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=OkulYönetimiDB;Integrated Security=True;Encrypt=False");
            SqlDataAdapter da = new SqlDataAdapter("SELECT BölümNo, BölümAdı FROM Bolumtab ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "BölümAdı"; 
            comboBox1.ValueMember = "BölümNo"; 
        }
    }
}
