using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

namespace Dosya_Adı_Değiştirme
{
    public partial class Form1 : Form
    {
        #region Değişkenler

        string dosyaolu;
        int y = 1;
        int i = 0;

        #endregion

        #region Tanımlamalar

        FileInfo[] dosyabilgisi;
        
        #endregion

        #region Metotlar

        public void tekrarla(int t)
        {
            for (i = 0; i < dosyabilgisi.Length; i++)
            {
             
                tekrarla2(y, dosyabilgisi[i]);
                y++;

            }
        }

        public void tekrarla2(int t, FileInfo x)
        {
            try
            {
               
                Directory.Move(x.FullName, dosyaolu + "\\" + y + "." + textBox2.Text);
               
            }
            catch (Exception)
            {
                y++;
                tekrarla2(y, dosyabilgisi[i]);
            }
        
        }

        public void tekrarla4(int t)
        {
            for (i = 0; i < dosyabilgisi.Length; i++)
            {

                tekrarla3(y, dosyabilgisi[i]);
                y++;

            }
        }

        public void tekrarla3(int t, FileInfo x)
        {
            try
            {
                string[] z = x.Name.Split('.');
                Directory.Move(x.FullName, dosyaolu + "\\" + y + " " + z[0]+"." + textBox2.Text);
              
            }
            catch (Exception)
            {
                y++;
                tekrarla3(y, dosyabilgisi[i]);
            }
        
        
        
        }

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dosyaolu = textBox1.Text;
            DirectoryInfo Dosyalar = new DirectoryInfo(dosyaolu);
            dosyabilgisi = Dosyalar.GetFiles();

            try
            {
                y = int.Parse(textBox3.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen sayısal bir ifade giriniz");
            }

            tekrarla(y);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dosyaolu = textBox1.Text;
            DirectoryInfo Dosyalar = new DirectoryInfo(dosyaolu);
            dosyabilgisi = Dosyalar.GetFiles();

            try
            {
                y = int.Parse(textBox3.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen sayısal bir ifade giriniz");
            }

            tekrarla4(y);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            textBox3.Clear();
        }
    }
}
