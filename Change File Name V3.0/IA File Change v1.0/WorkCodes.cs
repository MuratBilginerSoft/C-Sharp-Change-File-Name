using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace IA_File_Change_v1._0
{
    public class WorkCodes
    {
        #region Dosya İşlemi 1

        public void DosyaBilgiAl(int Deger1, int Deger2, FileInfo[] FI1, string Path, ComboBox CB1,Label Lbl1,Boolean Durum, ComboBox cmb)
        {
           
                for (; Deger1 < FI1.Length; Deger1++)
                {
                    if (Durum == false)
                    {

                        FileMove(Deger1, Deger2, FI1, Path, CB1, Durum);
                        Deger2++;
                    }

                     else if (Durum == true)
                     {
                         FileMove(Deger1, Deger2, FI1, Path, CB1, Durum);
                         Deger2++;
                     }
                } 
            Lbl1.Text = "İşlem Tamamlandı";
            cmb.Text = Deger2.ToString();
            
        }

        public void FileMove(int Deger1, int Deger2, FileInfo[] FI1, string Path,ComboBox CB1,bool Durum)
        {
            try
            {
                if (Durum==false)
                {
                    Directory.Move(FI1[Deger1].FullName, Path + "\\" + Deger2 + "." + CB1.Text);
                }

                else
                {
                    string[] z = FI1[Deger1].Name.Split('.');
                    Directory.Move(FI1[Deger1].FullName, Path + "\\" + Deger2 + " " + z[0] + "." + CB1.Text);
                }
               
            }
            catch (Exception)
            {
                Deger2++;
                FileMove(Deger1, Deger2, FI1, Path, CB1,Durum);
            }

        }

        #endregion

        #region Renk

        public void PicHover(PictureBox Pic1)
        {
            Pic1.BackColor = Color.White;
        }

        public void PicLeave(PictureBox Pic2)
        {
           Pic2.BackColor = Color.Transparent;
        }

        public void PicClick(PictureBox Pic3)
        {
            Pic3.BackColor = Color.RoyalBlue;
        
        }

        #endregion
    }
}
