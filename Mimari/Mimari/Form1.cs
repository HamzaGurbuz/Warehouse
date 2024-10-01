using System.Data;
using System.Data.SqlClient;

namespace Mimari
{
    public partial class Form1 : Form
    {

        int hesapla;
        public Form1()
        {
            InitializeComponent();


        }



        static string connection = "Data Source=.;Initial Catalog=Market;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(connection);
        SqlCommand cmd = new SqlCommand();

        private void listele()
        {
            SqlDataAdapter data = new SqlDataAdapter("Select * from Market", baglanti);
            DataSet ds = new DataSet();
            baglanti.Open();
            data.Fill(ds, "Market");
            dataGridView1.DataSource = ds.Tables["Market"];
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int fiyat = Convert.ToInt32(textBox3.Text);
            int adet = Convert.ToInt32(textBox5.Text);
            hesapla = fiyat * adet;

            baglanti.Open();
            cmd.Connection = baglanti;
            cmd.CommandText = "INSERT into Market(urun_id, urun_adi, fiyat, adet, tutar)values(" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + hesapla + "')";
            cmd.ExecuteNonQuery();
            baglanti.Close();
            listele();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            cmd.Connection = baglanti;
            cmd.CommandText = "DELETE From Market where urun_id=" + textBox4.Text + "";
            cmd.ExecuteNonQuery();
            baglanti.Close();
            listele();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int fiyat = Convert.ToInt32(textBox3.Text);
            int adet = Convert.ToInt32(textBox5.Text);
            hesapla = fiyat * adet;

            baglanti.Open();
            cmd.Connection = baglanti;
            cmd.CommandText = "UPDATE Market SET urun_adi='" + textBox2.Text + "', fiyat='" + textBox3.Text + "', adet='" + textBox5.Text + "', tutar='" + hesapla + "' where urun_id=" + textBox1.Text + " ";
            cmd.ExecuteNonQuery();
            baglanti.Close();
            listele();


        }
    }
}