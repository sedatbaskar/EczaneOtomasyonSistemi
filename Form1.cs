using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace WindowsFormsApplication13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="yesim"&textBox2.Text=="12345")
            {
                Form2 frm2 = new Form2();
                frm2.Show();
                this.Hide();

            }

            else

                MessageBox.Show("Kullanıcı Adı veya Şifre hatalı girilmiştir.Lütfen tekrar deneyiniz..");
            textBox1.Clear();
            textBox2.Clear();
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult durum=new DialogResult();
          
          durum=  MessageBox.Show(" Çıkmak İstediğinizden Emin Misiniz?", "Çıkış", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
           if (durum==DialogResult.OK )
           {
               Application.Exit();
           }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
