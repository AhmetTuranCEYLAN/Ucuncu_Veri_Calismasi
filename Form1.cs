using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ucuncu_Veri_Calismasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void getir()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\toshıba\Desktop\Görsel Programlama Çalışmalarım\Üçüncü Sql Çalışmaları\Ucuncu_Veri_Calismasi\Database1.mdf;Integrated Security=True");
            con.Open();

            SqlCommand com = new SqlCommand("delete from memleket where m_kod=@p1", con);
            com.Parameters.AddWithValue("@p1", textBox1.Text);
            com.ExecuteNonQuery();

            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\toshıba\Desktop\Görsel Programlama Çalışmalarım\Üçüncü Sql Çalışmaları\Ucuncu_Veri_Calismasi\Database1.mdf;Integrated Security=True");
            con.Open();

            SqlCommand com = new SqlCommand("select ad, soyad, c.cinsiyet_id, cn.cinsiyet_adi from calisanlar c, cinsiyet cn where c.cinsiyet_id=cn.cinsiyet_id", con);
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);

            dataGridView2.DataSource = dt;
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "ad";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'database1DataSet.Calisanlar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.calisanlarTableAdapter.Fill(this.database1DataSet.Calisanlar);

        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            comboBox1.DisplayMember = "ad";
            MessageBox.Show(comboBox1.SelectedValue.ToString());
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\toshıba\Desktop\Görsel Programlama Çalışmalarım\Üçüncü Sql Çalışmaları\Ucuncu_Veri_Calismasi\Database1.mdf;Integrated Security=True");
            con.Open();

            SqlCommand com = new SqlCommand("insert into memleket(m_kod, şehir_adı) values(@p1,@p2)", con);
            com.Parameters.AddWithValue("@p1", textBox1.Text);
            com.Parameters.AddWithValue("@p2", textBox2.Text);
            com.ExecuteNonQuery();

            con.Close();




        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\toshıba\Desktop\Görsel Programlama Çalışmalarım\Üçüncü Sql Çalışmaları\Ucuncu_Veri_Calismasi\Database1.mdf;Integrated Security=True");
            con.Open();

            SqlCommand com = new SqlCommand("select * from memleket", con);
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);

            dataGridView2.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            getir();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\toshıba\Desktop\Görsel Programlama Çalışmalarım\Üçüncü Sql Çalışmaları\Ucuncu_Veri_Calismasi\Database1.mdf;Integrated Security=True");
            con.Open();

            SqlCommand com = new SqlCommand("update calisanlar set maas=10000 where calisan_id=@p1", con);

            com.Parameters.AddWithValue("@p1", textBox2.Text);
            com.ExecuteNonQuery();
            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <dataGridView1.SelectedRows[0].Cells.Count; i++)
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\toshıba\Desktop\Görsel Programlama Çalışmalarım\Üçüncü Sql Çalışmaları\Ucuncu_Veri_Calismasi\Database1.mdf;Integrated Security=True");
                con.Open();

                SqlCommand com = new SqlCommand("update calisanlar set maas=maas+min(maas) where ad=@p1", con);
                com.Parameters.AddWithValue("@p1", comboBox1.SelectedItem);
                com.ExecuteNonQuery();
                con.Close();

            }

            

        }
    }
}
