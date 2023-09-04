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

namespace Test_Petrol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection(@"Data Source=LENOVO\SQLEXPRESS;Initial Catalog=TestBenzin;Integrated Security=True");
        
        void Listele()
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("select*from TBLBENZIN where PETROLTUR='Kursunsuz95'", bgl);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblKursunsuz95.Text = dr[3].ToString();
                decimal v = decimal.Parse(dr[4].ToString());
                progressBar1.Value = (int)v;
                label16.Text = dr[4].ToString();
                

            }
            bgl.Close();
            //kursunsuz97
            bgl.Open();
            SqlCommand komut1 = new SqlCommand("select*from TBLBENZIN where PETROLTUR='Kursunsuz97'", bgl);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblKursunsuz97.Text = dr1[3].ToString();
                decimal v = decimal.Parse(dr1[4].ToString());
                progressBar2.Value = (int)v;
                label17.Text = dr1[4].ToString();

            }
            bgl.Close();
            //EURODIZEL10
            bgl.Open();
            SqlCommand komut2 = new SqlCommand("select*from TBLBENZIN where PETROLTUR='EuroDizel10'", bgl);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblEuro.Text = dr2[3].ToString();
                decimal v = decimal.Parse(dr2[4].ToString());
                progressBar3.Value = (int)v;
                label18.Text = dr2[4].ToString();

            }
            bgl.Close();
            //yeniprodizel
            bgl.Open();
            SqlCommand komut3 = new SqlCommand("select*from TBLBENZIN where PETROLTUR='YeniProDizel'", bgl);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblYeniPro.Text = dr3[3].ToString();
                decimal v = decimal.Parse(dr3[4].ToString());
                progressBar4.Value = (int)v;
                label19.Text = dr3[4].ToString();

            }
            bgl.Close();
            //gaz
            bgl.Open();
            SqlCommand komut4 = new SqlCommand("select*from TBLBENZIN where PETROLTUR='Gaz'", bgl);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblGaz.Text = dr4[3].ToString();
                decimal v = decimal.Parse(dr4[4].ToString());
                progressBar5.Value = (int)v;
                label20.Text = dr4[4].ToString();

            }
            bgl.Close();

            bgl.Open();
            SqlCommand komut5 = new SqlCommand("select*from TBLKASA", bgl);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblKasa.Text = dr5[0].ToString();
            }
            bgl.Close();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
            
          
        

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz95,litre,tutar;
            kursunsuz95 = Convert.ToDouble(LblKursunsuz95.Text);
            litre = Convert.ToDouble(numericUpDown1.Value);
            tutar = kursunsuz95 * litre;
            TxtKursunsuz95.Text = tutar.ToString();


        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

            double kursunsuz97, litre, tutar;
            kursunsuz97 = Convert.ToDouble(LblKursunsuz97.Text);
            litre = Convert.ToDouble(numericUpDown2.Value);
            tutar = kursunsuz97 * litre;
            TxtKursunsuz97.Text = tutar.ToString();

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            double eurodizel, litre, tutar;
            eurodizel = Convert.ToDouble(LblEuro.Text);
            litre = Convert.ToDouble(numericUpDown3.Value);
            tutar = eurodizel * litre;
            TxtEuroDizel.Text = tutar.ToString();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            double yeniprodizel, litre, tutar;
            yeniprodizel = Convert.ToDouble(LblYeniPro.Text);
            litre = Convert.ToDouble(numericUpDown4.Value);
            tutar = yeniprodizel * litre;
            TxtYeniPro.Text = tutar.ToString();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            double  gaz,litre,tutar;
            gaz = Convert.ToDouble(LblGaz.Text);
            litre = Convert.ToDouble(numericUpDown5.Value);
            tutar = gaz * litre;
            TxtGaz.Text = tutar.ToString();
        }

        private void BtnDepoDoldur_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 0)
            {
                bgl.Open();
                SqlCommand komutEkle = new SqlCommand("insert into TBLHAREKET (PLAKA,BENZINTURU,LITRE,FIYAT) values(@p1,@p2,@p3,@p4)", bgl);
                komutEkle.Parameters.AddWithValue("@p1", TxtPlaka.Text);
                komutEkle.Parameters.AddWithValue("@p2", label3.Text);
                komutEkle.Parameters.AddWithValue("@p3", numericUpDown1.Value);
                //double kursunsuz95, litre, tutar;
                //kursunsuz95 = Convert.ToDouble(LblKursunsuz95.Text);
                //litre = Convert.ToDouble(numericUpDown1.Value);
                //tutar = kursunsuz95 * litre;
                //TxtKursunsuz95.Text = tutar.ToString();
                
                komutEkle.Parameters.AddWithValue("@p4",decimal.Parse(TxtKursunsuz95.Text));
                komutEkle.ExecuteNonQuery();
                bgl.Close();

                bgl.Open();
                SqlCommand komut2 = new SqlCommand("update TBLKASA set MIKTAR=MIKTAR+@p1", bgl);
                komut2.Parameters.AddWithValue("@p1", decimal.Parse(TxtKursunsuz95.Text));
                komut2.ExecuteNonQuery();
                bgl.Close();
                MessageBox.Show("Bilgiler Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                bgl.Open();
                SqlCommand komut3 = new SqlCommand("update TBLBENZIN set stok=stok-@p1 where PETROLTUR='Kursunsuz95'", bgl);
                komut3.Parameters.AddWithValue("@p1",numericUpDown1.Value);
                komut3.ExecuteNonQuery();
                bgl.Close();
                MessageBox.Show("işlem Yapıldı");
                Listele();

            }

        }
    }
}
