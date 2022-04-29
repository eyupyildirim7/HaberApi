using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Haber.ViewModel
{
    public class YazarModel
    {
        public string Yazarid { get; set; }
        public string adsoyad { get; set; }
        public string kayittarih { get; set; }
        public int yas { get; set; }
        public string yazarbrans { get; set; }
        public string sifre { get; set; }
        public string eposta { get; set; }

        public virtual KategoriModel KategoriBilgi { get; set; }
    }
}