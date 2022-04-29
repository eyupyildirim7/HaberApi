using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Haber.ViewModel
{
    public class HaberModel
    {
        public string Hbrid { get; set; }
        public string Haberbaslik { get; set; }
        public string haberadi { get; set; }
        public string Haberkategori { get; set; }
        public string habericeriği { get; set; }
        public string haberyazari { get; set; }
        public System.DateTime habertarihi { get; set; }

        public virtual KategoriModel KategoriBilgi { get; set; }
        public virtual YazarModel YazarBilgi { get; set; }
    }
}