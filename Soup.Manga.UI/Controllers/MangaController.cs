using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Soup.Manga.Logic;

namespace Soup.Manga.UI.Controllers
{
    public class MangaController : Controller
    {
        private MangaService _MangaService = new MangaService();
        public IActionResult Index()
        {
            return View(_MangaService.GetMangas());
        }
        [HttpPost]
        public IActionResult Edit(Objects.Manga manga)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error");
            }
            _MangaService.UpdateManga(manga);
            return View(manga);
        }

        public IActionResult Edit(int id)
        {
            return View(_MangaService.GetMangaById(id));
        }

        public IActionResult Details(int id)
        {
            return View(_MangaService.GetMangaById(id));
        }

        //The logic writes to a json and this just grabs that json to show
        public IActionResult GetData()
        {
            var json = JsonConvert.SerializeObject(_MangaService.GetMangas());
            return Json(json);
        }
    }
}
