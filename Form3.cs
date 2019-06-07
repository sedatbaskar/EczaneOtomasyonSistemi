using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication13
{
    public partial class Form3 : Form
    {
         public Boolean yeni;
        public eczane_otomasyonuDataSet.İlaç_BilgileriRow ekle;

        public Form3()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            src_to_db();
            DialogResult = DialogResult.OK;
         
          
        }


        private void src_to_db()
        {
           ekle.ilac_kod = Convert.ToInt32(textBox2.Text);
           ekle.ilac_adı = textBox3.Text;
           ekle.sk_tarihi = Convert.ToDateTime(textBox4.Text);
           ekle.barkod_no= textBox5.Text;
           ekle.fiyat= Convert.ToInt32(textBox6.Text);
           ekle.adet = Convert.ToInt32(textBox7.Text);
           ekle.kullanım_sekli = textBox8.Text;

           
        }



        private void Form3_Shown(object sender, EventArgs e)
        {
            if (yeni)
                bosalt();
            else
                db_to_src();
        }


        private void db_to_src()
        {
            textBox2.Text= ekle.ilac_kod.ToString();
            textBox3.Text = ekle.ilac_adı;
            textBox4.Text = ekle.sk_tarihi.ToString();
            textBox5.Text=  ekle.barkod_no;
            textBox6.Text = ekle.fiyat.ToString();
            textBox7.Text = ekle.adet.ToString();
            textBox8.Text = ekle.kullanım_sekli;
           

        }



        private void bosalt()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode == Keys.F2)
                this.DialogResult = DialogResult.OK;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        


    }
}
