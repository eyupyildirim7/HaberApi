using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Haber.Models;
using Haber.ViewModel;

namespace Haber.Controllers
{
    public class ServiceController : ApiController
    {
        HaberEntities1 db = new HaberEntities1();
        Sonuc sonuc = new Sonuc();

        #region Yazarlar
        [HttpGet]
        [Route("api/yazarliste")]
        public List<YazarModel> YazarListe()
        {
            List<YazarModel> Yazarlist = db.Yazar.Select(x => new YazarModel()
            {
                Yazarid = x.Yazarid,
                adsoyad = x.adsoyad,
                kayittarih = x.kayittarih,
                yas = x.yas,
                yazarbrans = x.yazarbrans,
                eposta = x.eposta,
            }).ToList();
            return Yazarlist;
        }
        [HttpGet]
        [Route("api/yazarbyid/{Yazarid}")]
        public YazarModel YazarById(string yazarid)
        {
            YazarModel kayit = db.Yazar.Where(s => s.Yazarid == yazarid).Select(x => new YazarModel()
            {
                Yazarid = x.Yazarid,
                adsoyad = x.adsoyad,
                kayittarih = x.kayittarih,
                yas = x.yas,
                yazarbrans = x.yazarbrans,
                eposta = x.eposta,
            }).SingleOrDefault();
            return kayit;
        }

        [HttpPost]
        [Route("api/yazarekle")]
        public Sonuc YazarEkle(YazarModel model)
        {
            if (db.Yazar.Count(c => c.Yazarid == model.Yazarid) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Yazar Kayıtlıdır!";
                return sonuc;
            }

            Yazar yeni = new Yazar();
            yeni.Yazarid = Guid.NewGuid().ToString();
            yeni.adsoyad = model.adsoyad;
            yeni.eposta = model.eposta;
            yeni.sifre = model.sifre;
            yeni.yas = model.yas;
            yeni.yazarbrans = model.yazarbrans;
            yeni.kayittarih = model.kayittarih;
            db.Yazar.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Yazar Eklendi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/yazarduzenle")]
        public Sonuc YazarDuzenle(YazarModel model)
        {
            Yazar kayit = db.Yazar.Where(s => s.Yazarid == model.Yazarid).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Yazar Bulunmadı!";
                return sonuc;
            }

            kayit.adsoyad = model.adsoyad;
            kayit.eposta = model.eposta;
            kayit.sifre = model.sifre;
            kayit.yazarbrans = model.yazarbrans;
            kayit.yas = model.yas;
            kayit.kayittarih = model.kayittarih;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Yazar Düzenlendi";
            return sonuc;
        }

        [HttpDelete]
        [Route("api/yazarsil/{Yazarid}")]
        public Sonuc YazarSil(string Yazarid)
        {
            Yazar kayit = db.Yazar.Where(s => s.Yazarid == Yazarid).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Yazar Bulunmadı!";
                return sonuc;
            }


            db.Yazar.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Yazar Silndi";
            return sonuc;
        }
        #endregion

        #region  Kategori
        [HttpGet]
        [Route("api/kategoriliste")]
        public List<KategoriModel> KategoriListe()
        {
            List<KategoriModel> Katlist = db.Kategori.Select(x => new KategoriModel()
            {
                kategoriid = x.kategoriid,
                Kategoriadı = x.Kategoriadı,
            }).ToList();
            return Katlist;
        }
        [HttpGet]
        [Route("api/kategoribyid/{kategoriid}")]
        public KategoriModel KatById(string kategoriid)
        {
            KategoriModel kayit = db.Kategori.Where(s => s.kategoriid == kategoriid).Select(x => new KategoriModel()
            {
                kategoriid = x.kategoriid,
                Kategoriadı = x.Kategoriadı,
            }).SingleOrDefault();
            return kayit;
        }

        [HttpPost]
        [Route("api/katekle")]
        public Sonuc KatEkle(KategoriModel model)
        {
            if (db.Kategori.Count(c => c.kategoriid == model.kategoriid) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Kategori Kayıtlıdır!";
                return sonuc;
            }

            Kategori yeni = new Kategori();
            yeni.kategoriid = Guid.NewGuid().ToString();
            yeni.Kategoriadı = model.Kategoriadı;
            db.Kategori.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kategori Eklendi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/katduzenle")]
        public Sonuc KatDuzenle(KategoriModel model)
        {
            Kategori kayit = db.Kategori.Where(s => s.kategoriid == model.kategoriid).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kategori Bulunmadı!";
                return sonuc;
            }

            kayit.Kategoriadı = model.Kategoriadı;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kategori Düzenlendi";
            return sonuc;
        }

        [HttpDelete]
        [Route("api/katsil/{kategoriid}")]
        public Sonuc KatSil(string kategoriid)
        {
            Kategori kayit = db.Kategori.Where(s => s.kategoriid == kategoriid).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kategori Bulunmadı!";
                return sonuc;
            }


            db.Kategori.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kategori Silndi";
            return sonuc;
        }
        #endregion

        #region Haber
        [HttpGet]
        [Route("api/haberliste")]
        public List<HaberModel> HaberListe()
        {
            List<HaberModel> Haberlist = db.Haberlerim.Select(y => new HaberModel()
            {
                Hbrid = y.Hbrid,
                Haberbaslik = y.Haberbaslik,
                haberadi = y.haberadi,
                habericeriği = y.habericeriği,
                habertarihi = y.habertarihi,
                haberyazari = y.haberyazari,
                Haberkategori = y.Haberkategori,
            }).ToList();
            return Haberlist;
        }
        [HttpGet]
        [Route("api/haberbyid/{Hbrid}")]
        public HaberModel HaberById(string Hbrid)
        {
            HaberModel kayit = db.Haberlerim.Where(s => s.Hbrid == Hbrid).Select(y => new HaberModel()
            {
                Hbrid = y.Hbrid,
                Haberbaslik = y.Haberbaslik,
                haberadi = y.haberadi,
                habericeriği = y.habericeriği,
                habertarihi = y.habertarihi,
                haberyazari = y.haberyazari,
                Haberkategori = y.Haberkategori,
            }).SingleOrDefault();
            return kayit;
        }

        [HttpPost]
        [Route("api/haberekle")]
        public Sonuc HaberEkle(HaberModel model)
        {
            if (db.Haberlerim.Count(c => c.Hbrid == model.Hbrid) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Haber Kayıtlıdır!";
                return sonuc;
            }

            Haberlerim yeni = new Haberlerim();
            yeni.Hbrid = Guid.NewGuid().ToString();
            yeni.Haberbaslik = model.Haberbaslik;
            yeni.haberadi = model.haberadi;
            yeni.Haberkategori = model.Haberkategori;
            yeni.habericeriği = model.habericeriği;
            yeni.haberyazari = model.haberyazari;
            yeni.habertarihi = model.habertarihi;
            db.Haberlerim.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Haber Eklendi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/haberduzenle")]
        public Sonuc HaberDuzenle(HaberModel model)
        {
            Haberlerim kayit = db.Haberlerim.Where(s => s.Hbrid == model.Hbrid).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Haber Bulunmadı!";
                return sonuc;
            }

            kayit.Haberbaslik = model.Haberbaslik;
            kayit.haberadi = model.haberadi;
            kayit.Haberkategori = model.Haberkategori;
            kayit.habericeriği = model.habericeriği;
            kayit.haberyazari = model.haberyazari;
            kayit.habertarihi = model.habertarihi;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Haber Düzenlendi";
            return sonuc;
        }

        [HttpDelete]
        [Route("api/habersil/{Hbrid}")]
        public Sonuc HaberSil(string Hbrid)
        {
            Haberlerim kayit = db.Haberlerim.Where(s => s.Hbrid == Hbrid).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Haber Bulunmadı!";
                return sonuc;
            }


            db.Haberlerim.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Haber Silndi";
            return sonuc;
        }
        #endregion
    }

}
