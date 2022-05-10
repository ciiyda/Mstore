using AppCore.Business.Models.Result;
using Business.Models;
using Business.Services.Bases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumService _albumService;
        private readonly ISingerService _singerService;

        public AlbumsController(IAlbumService albumService, ISingerService singerService)
        {
            _albumService = albumService;
            _singerService = singerService;
        }
        public IActionResult Index()
        {
            List<AlbumModel> albums = _albumService.Query().ToList();

            return View(albums);
        }

        public IActionResult Create()
        {
            ViewBag.Singers = new SelectList(_singerService.Query().ToList(), "Id", "Name");
            var model = new AlbumModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AlbumModel model)
        {
            if (ModelState.IsValid)
            {

                var result = _albumService.Add(model);
                if (result.Status == ResultStatus.Success)
                {
                    return RedirectToAction("Index");
                }

                else if (result.Status == ResultStatus.Exception)
                {
                    return View("Error");
                }

                ModelState.AddModelError("", result.Message);
            }

            ViewBag.Singers = new SelectList(_singerService.Query().ToList(), "Id", "Name", model.SingerId);
            return View(model);

        }

        public IActionResult Edit(int? id)

        {
            if (id == null)
            {
                return View("Not Found");

            }

            AlbumModel model = _albumService.Query().SingleOrDefault(a => a.Id == id);

            if (model == null)

                return View("Not Found");
            ViewBag.Singers = new SelectList(_singerService.Query().ToList(), "Id", "Name", model.SingerId);

            return View(model);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(AlbumModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _albumService.Update(model);

                if (result.Status == ResultStatus.Success)
                {

                    return RedirectToAction("Index");
                }

                if (result.Status == ResultStatus.Exception)
                {
                    return View("Error");
                }

                ModelState.AddModelError("", result.Message);
            }
          
            ViewBag.Singers = new SelectList(_singerService.Query().ToList(), "Id", "Name", model.SingerId);

            return View(model);
        }

        public IActionResult Details(int? id)
        {
            if(id==null)
                return View("Not found");

            AlbumModel model = _albumService.Query().SingleOrDefault(a => a.Id == id);
                if(model==null)
                return View("Not Found");
            ViewBag.Singers = new SelectList(_singerService.Query().ToList(), "Id", "Name", model.SingerId);

            return View(model);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return View("Not found");
               
            var result = _albumService.Delete(id.Value);
            if(result.Status==ResultStatus.Success)
                return RedirectToAction("Index");
            return View("Error");

        }
    }

}
