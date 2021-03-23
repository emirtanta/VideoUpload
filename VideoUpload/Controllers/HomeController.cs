using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoUpload.Models;

namespace VideoUpload.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #region Video Yükleme Bölgesi

        [HttpGet]
        public ActionResult UploadVideo()
        {
            OgrenciDBEntities entities = new OgrenciDBEntities();
            return View(entities.VideoFiles.Where(p => p.ContentType == "video/mp4").ToList());
        }

        [HttpPost]
        public ActionResult UploadVideo(HttpPostedFileBase postedFile)
        {
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(postedFile.InputStream))
            {
                bytes = br.ReadBytes(postedFile.ContentLength);
            }
            OgrenciDBEntities entities = new OgrenciDBEntities();
            entities.VideoFiles.Add(new VideoFiles
            {
                Name = Path.GetFileName(postedFile.FileName),
                ContentType = postedFile.ContentType,
                Data = bytes
            });
            entities.SaveChanges();
            return RedirectToAction("UploadVideo");
        }

        [HttpGet]
        public FileResult DownloadFile(int? fileId)
        {
            OgrenciDBEntities entities = new OgrenciDBEntities();
            VideoFiles file = entities.VideoFiles.ToList().Find(p => p.ID == fileId.Value);
            return File(file.Data, file.ContentType, file.Name);
        }


        #endregion

        #region Jquery Seçili Checkbox ile filtreleme

        public ActionResult JqueryCheckboxFiltre()
        {
            return View();
        }

        #endregion
    }
}