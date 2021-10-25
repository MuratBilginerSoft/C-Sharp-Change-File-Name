using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using IAFrameWork;

namespace IA_File_Change_v1._0
{
    public partial class Form1 : Form
    {
        #region Tanimlamalar

        FormProcessing FP = new FormProcessing();
        WorkCodes WC = new WorkCodes();

        FileInfo[] FileInformation;

        #endregion

        #region Degiskenler

        bool Durum = false;

        int x1 = 1, x2 = 0;

        string FilePath;

        #endregion

        #region Metodlar

        public void SistemBilgi()
        {
            LblBilgilendirme.Text = "Bilgilendirme";
            x2 = 0;
            FilePath = TextDizin.Text;
            DirectoryInfo Files = new DirectoryInfo(FilePath);
            FileInformation = Files.GetFiles();
            x1 = Convert.ToInt32(ComboDeger.Text);
        }

        #endregion

        #region Form Taşıma

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            FP.FTMouseDown(this, e);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            FP.FTMouseMove(this, e);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            FP.FTMouseUp(this);
        }

        #endregion

        #region Form Durum Kontrol

        private void Kapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Simge_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Olay

        public Form1()
        {
            InitializeComponent();
        }

        private void PicEkle_Click_1(object sender, EventArgs e)
        {
            WC.PicClick(sender as PictureBox);
            TextDizin.Text = FP.DosyaDizini(FDB1);
            LblBilgilendirme.Text = "Bilgilendirme";
        }

        private void PicTemizle_Click_1(object sender, EventArgs e)
        {
            WC.PicClick(sender as PictureBox);
            TextDizin.Clear();
            LblBilgilendirme.Text = "Bilgilendirme";
        }

        private void PicYapıstir_Click_1(object sender, EventArgs e)
        {
            WC.PicClick(sender as PictureBox);
            TextDizin.Text = FP.YapıstirVeri();
            LblBilgilendirme.Text = "Bilgilendirme";
        }

        private void Kapat_MouseHover(object sender, EventArgs e)
        {
            WC.PicHover(sender as PictureBox);
        }

        private void Kapat_MouseLeave(object sender, EventArgs e)
        {
            WC.PicLeave(sender as PictureBox);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            FP.IALinkVer();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FP.IALinkVer();
        }
        #endregion

        #region Yapılacak iş

        private void BtnDosyaAdi1_Click(object sender, EventArgs e)
        {
            SistemBilgi();
            Durum = false;
            WC.DosyaBilgiAl(x2, x1, FileInformation, FilePath, ComboUzanti,LblBilgilendirme,Durum,ComboDeger);
        }

        private void BtnDosyaAdi2_Click(object sender, EventArgs e)
        {
            SistemBilgi();
            Durum = true;
            WC.DosyaBilgiAl(x2, x1, FileInformation, FilePath, ComboUzanti, LblBilgilendirme, Durum, ComboDeger);
        }

        #endregion
    }
}
