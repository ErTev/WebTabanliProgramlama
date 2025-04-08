using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTabanlıProgramlamaOdev2.Models.Entity;

namespace WebTabanlıProgramlamaOdev2.Controllers
{
    public class _1Controller : Controller
    {
        OgrenciOtomasyonuEntities ra = new OgrenciOtomasyonuEntities();

        // GET: _1
        public ActionResult Index()
        {
            var degerler = ra.Table.ToList();
            return View(degerler);
        }



        [HttpGet]//ogrencılerın bos kayıt almasını engller
        public ActionResult OgrenciEkle()
        {
            return View();
        }

        [HttpPost]//ogrencılerın bos kayıt almasını engller

        public ActionResult OgrenciEkle(Table s1)
        {
            ra.Table.Add(s1);
            ra.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var _1 = ra.Table.Find(id);
            ra.Table.Remove(_1);
            ra.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult ÖgrenciGetir(int id)
        {
            var _1 = ra.Table.Find(id);

            return View("ÖgrenciGetir",_1);
         
        }



        public ActionResult Güncelle(int id)
        {
            var student = ra.Table.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost]
        public ActionResult Güncelle(Table updatedStudent)
        {
            var student = ra.Table.Find(updatedStudent.OgrID);
            if (student != null)
            {
                student.OgrAd = updatedStudent.OgrAd;
                student.OgrSoyad = updatedStudent.OgrSoyad;
                student.OgrBolum = updatedStudent.OgrBolum;
                student.OgrMail = updatedStudent.OgrMail;
                student.OgrYas = updatedStudent.OgrYas;

                ra.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(updatedStudent);
        }

     



    }
}