using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Azure;
using Microsoft.WindowsAzure;
using HelperLibrary;

namespace ImageReSizeWebRole.Controllers
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
        public ActionResult ImageUpload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ImageUpload(HttpPostedFileBase postedFile)
        {

            string originalImagesContainerName = CloudConfigurationManager.GetSetting("OriginalImages").ToString();
            string images20By20ContainerName = CloudConfigurationManager.GetSetting("Images20By20").ToString();
            string images40by40ContainerName = CloudConfigurationManager.GetSetting("Images40by40").ToString();
            string imageResizeQueueName = CloudConfigurationManager.GetSetting("QueueName").ToString();


            BlobStorage.CreateContainerIfNotExists(originalImagesContainerName);

            string url = BlobStorage.UploadImageToContainer(originalImagesContainerName, postedFile);
            Queue.CreateQueue(imageResizeQueueName);
            Queue.InsertIntoQueue(imageResizeQueueName, url);

            List<Uri> originalImageUrl;
            List<Uri> twentyByTwentyImageUrl;
            List<Uri> fortyByFortyImageUrl;

            BlobStorage.RetrieveAllImages(originalImagesContainerName, out originalImageUrl);
            ViewBag.allimages = originalImageUrl;

            BlobStorage.RetrieveAllImages(images20By20ContainerName, out twentyByTwentyImageUrl);
            ViewBag.all20by20images = twentyByTwentyImageUrl;

            BlobStorage.RetrieveAllImages(images40by40ContainerName, out fortyByFortyImageUrl);
            ViewBag.all40by40images = fortyByFortyImageUrl;

            return View();
        }
    }
}