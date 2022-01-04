using Microsoft.AspNetCore.Mvc;

namespace MovieStoreSample.Controllers
{
    public class PhotoController : Controller
    {
        [HttpGet]
        public IActionResult UploadPicture()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UploadPicture(IFormFile datei)
        {
            FileInfo fileInfo = new FileInfo(datei.FileName);

            string speicherPfad = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images\" + fileInfo.Name;


            using (FileStream stream = new FileStream(speicherPfad, FileMode.Create))
            {
                datei.CopyTo(stream);
            }

            return RedirectToAction(nameof(UploadPicture));
        }



        public IActionResult PictureGallery()
        {
            string path = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images";
            string[] bilder = Directory.GetFiles(path);
            return View(bilder);
        }


    }
}
