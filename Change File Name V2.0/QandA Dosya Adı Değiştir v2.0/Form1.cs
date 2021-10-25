using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace QandA_Dosya_Adı_Değiştir_v2._0
{
    public partial class Form1 : Form
    {
        #region Tanımlamalar

        FileInfo[] DosyaAdı; // Dosya isimlerinin bilgisini alacak dizi.
        string[] Kelimeler, Kelimeler2;

        Point İlkKonum;
        bool Durum = false;

        #endregion

        #region Değişkenler

        string DosyaYolu; // Dosya dizinini tutacak değişken

        string İlkHarf, TümKelime, Kelime1;

        int a,i;

        char ayraç=' ';

        #endregion

        #region Ana İşlemler

        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        #region PictureBox İşlemleri

        private void PicKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PicYapıştır1_Click(object sender, EventArgs e)
        {
            // Yapıştır Butonu Kodları

            IDataObject Nesne = Clipboard.GetDataObject();

            if (Nesne.GetDataPresent(DataFormats.Text))
            {
                textBox1.Text = Nesne.GetData(DataFormats.Text).ToString();
            }
        }

        private void PicSil1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void PicOnayla1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    textBox2.Clear();
                    DosyaYolu = textBox1.Text;
                    DirectoryInfo Dosyalar = new DirectoryInfo(DosyaYolu);
                    DosyaAdı = Dosyalar.GetFiles(); // Dosya isimleri getiriliyor.

                    for (i = 0; i < DosyaAdı.Length; i++)
                    {
                        Kelimeler = DosyaAdı[i].ToString().Split(' ');

                        TümKelime = Kelimeler[1].ToString();

                        for (int j = 2; j < Kelimeler.Length; j++)
                        {
                            TümKelime += " " + Kelimeler[j];

                        }

                        Directory.Move(DosyaAdı[i].FullName, DosyaYolu + "\\" + TümKelime);
                    }
                    label5.Visible = true;
                    panel4.BackColor = Color.GreenYellow;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Dosya oluşmama nedeni: Aynı dosyadan var.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = DosyaAdı[i].ToString();
                panel4.BackColor = Color.Red;
            }
        }

        private void PicYapıştır2_Click(object sender, EventArgs e)
        {
            // Yapıştır Butonu Kodları

            IDataObject Nesne = Clipboard.GetDataObject();

            if (Nesne.GetDataPresent(DataFormats.Text))
            {
                textBox3.Text = Nesne.GetData(DataFormats.Text).ToString();
            }
        }

        private void PicSil2_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox4.Clear();
        }

        private void PicOnayla2_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt16(numericUpDown1.Value);

            if (txtAyraç.Text=="")
            {
                ayraç = ' ';
            }

            else
            {
                ayraç = Convert.ToChar(txtAyraç.Text);
            }
            try
            {
                if (textBox3.Text != "")
                {
                    DosyaYolu = textBox3.Text;
                    DirectoryInfo Dosyalar = new DirectoryInfo(DosyaYolu);
                    DosyaAdı = Dosyalar.GetFiles();

                    for (int k = 0; k < DosyaAdı.Length; k++)
                    {
                        Kelimeler2 = DosyaAdı[k].ToString().Split(ayraç);

                        TümKelime = "";

                        for (int l = 0; l < Kelimeler2.Length; l++)
                        {
                            Kelime1 = Kelimeler2[l];

                            if (Kelime1 != "")
                            {
                                İlkHarf = Kelime1[0].ToString().ToUpper();

                                if (TümKelime == "")
                                {
                                    TümKelime = İlkHarf;
                                }

                                else
                                {
                                    TümKelime += " " + İlkHarf;
                                }

                                for (int d = 1; d < Kelime1.Length; d++)
                                {
                                    TümKelime = TümKelime + (Kelime1[d].ToString().ToLower());
                                }
                            }
                        }

                        Directory.Move(DosyaAdı[k].FullName, DosyaYolu + "\\" + a + " " + TümKelime);

                        a++;
                    }

                    label6.Visible = true;
                    panel5.BackColor = Color.GreenYellow;
                    textBox1.Clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Dosya oluşmama nedeni:Kelimeler Arası 1 den fazla boşluk olabilir.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Text = DosyaAdı[i].ToString();
                panel5.BackColor = Color.Red;
            }
        }

        #endregion

        #region TextBox İşlemleri

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label5.Visible = false;
            panel4.BackColor = Color.DeepSkyBlue;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label6.Visible = false;
            panel5.BackColor = Color.DeepSkyBlue;
        }

        #endregion

        #region Form Taşıma

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Durum = true;
            this.Cursor = Cursors.SizeAll;
            İlkKonum = e.Location;

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Durum)
            {
                this.Left = e.X + this.Left - (İlkKonum.X);
                this.Top = e.Y + this.Top - (İlkKonum.Y);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Durum = false;
            this.Cursor = Cursors.Default;
        }

        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
