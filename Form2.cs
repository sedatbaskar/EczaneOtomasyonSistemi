using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
namespace WindowsFormsApplication13
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eczane_otomasyonuDataSet.İlaç_Bilgileri' table. You can move, or remove it, as needed.
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ilaçBilgileriBindingSource.MoveNext();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ilaçBilgileriBindingSource.MovePrevious();
        }

        private void button4_Click(object sender, EventArgs e)
        {
             ilaçBilgileriBindingSource.MoveFirst();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           ilaçBilgileriBindingSource.MoveLast();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            eczane_otomasyonuDataSet.İlaç_BilgileriRow r = eczane_otomasyonuDataSet.İlaç_Bilgileri.Newİlaç_BilgileriRow();
            r.ilac_kod = Convert.ToInt32(textBox2.Text);
            r.ilac_adı = textBox3.Text;
            r.fiyat = Convert.ToInt32(textBox6.Text);
            r.sk_tarihi =Convert.ToDateTime(textBox4.Text);
            r.barkod_no =textBox5.Text;
            r.adet =Convert.ToInt32(textBox7.Text);
            //r.kullanım_sekli = textBox8.Text;
            r.kullanım_şekli = textBox8.Text;
            eczane_otomasyonuDataSet.İlaç_Bilgileri.Addİlaç_BilgileriRow(r);
            İlaç_BilgileriTableAdapter.Update(r);
            ilaçBilgileriBindingSource.MoveLast();
            MessageBox.Show("kayıt eklendi");




           





            //Form3 frm = new Form3();
            //frm.yeni = true;
            //frm.ekle = eczane_otomasyonuDataSet.İlaç_Bilgileri.Newİlaç_BilgileriRow();

            //if (frm.ShowDialog() == DialogResult.OK)
            //    MessageBox.Show(" yeni kayıt eklendi");
            //else
            //    MessageBox.Show("yeni kayıttan vazgeçtin");



        }

       

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
      
            frm.yeni = false;
            int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            frm.ekle = eczane_otomasyonuDataSet.İlaç_Bilgileri.FindBysıra_no(id);

            if (frm.ShowDialog() == DialogResult.OK)
                İlaç_BilgileriTableAdapter.Update(frm.ekle);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                int id = (int)item.Cells[0].Value;
                eczane_otomasyonuDataSet.İlaç_BilgileriRow sil = eczane_otomasyonuDataSet.İlaç_Bilgileri.FindBysıra_no(id);
                sil.Delete();
            }
            İlaç_BilgileriTableAdapter.Update(eczane_otomasyonuDataSet.İlaç_Bilgileri);
        }

        private void button9_Click(object sender, EventArgs e)
        {

            StreamWriter sw = new StreamWriter("d://deneme.txt", true, Encoding.Default);
            foreach (eczane_otomasyonuDataSet.İlaç_BilgileriRow item in eczane_otomasyonuDataSet.İlaç_Bilgileri.Rows)
            {
                sw.WriteLine(item[0] + "----" + item[1] + "----" + item[2] + "----" + item[3] + item[4] + "----" + item[5] + "----" + item[6] + "----" + item[7]);

            }
            MessageBox.Show("Yazdırma İşlemi Tamamlandı.");
            sw.Close();

        }

       

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult durum = new DialogResult();
            durum = MessageBox.Show(" Çıkmak İstediğinizden Emin Misiniz?", "Çıkış", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (durum == DialogResult.OK)
            {
                Application.Exit();



            }
            if (durum == DialogResult.Cancel)
            {
                MessageBox.Show("Çıkış iptal edildi..");

            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            DataRow[] arama = eczane_otomasyonuDataSet.İlaç_Bilgileri.Select("ilac_adı like '" + textBox9.Text + "%'");
            if (arama != null)
            {
                object id = arama[0][2];
                int yer = ilaçBilgileriBindingSource.Find("ilac_adı", id);
                ilaçBilgileriBindingSource.Position = yer;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
