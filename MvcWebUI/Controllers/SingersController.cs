using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.EntityFramework.Contexts;
using Entities.Entities;
using Business.Services.Bases;
using Business.Models;
using AppCore.Business.Models.Result;

namespace MvcWebUI.Controllers
{
    public class SingersController : Controller
    {
        private readonly MusicStoreContext _context;

        private readonly ISingerService _singerService;

        public SingersController(ISingerService singerService)
        {
            _singerService = singerService;
        }


        // GET: Singers
        public IActionResult Index()
        {
            List<SingerModel> singers = _singerService.Query().ToList();
            return View(singers);
        }

        // GET: Singers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singer = await _context.Singers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (singer == null)
            {
                return NotFound();
            }

            return View(singer);
        }

        // GET: Singers/Create
        public IActionResult Create()
        {
            var model = new SingerModel();
            return View(model);
        }

        // POST: Singers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SingerModel singer)
        {
            if (ModelState.IsValid)
            {
                var result = _singerService.Add(singer);
                if (result.Status == ResultStatus.Success)
                    return RedirectToAction(nameof(Index));
                if (result.Status == ResultStatus.Exception)
                    return View("Error");
                ModelState.AddModelError("", result.Message);
            }
            return View(singer);
        }

        // GET: Singers/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View("NoFound");
            }

            var singer = _singerService.Query().SingleOrDefault(c => c.Id == id);
            if (singer == null)
            {
                return View("NoFound");
            }
            return View(singer);
        }

        // POST: Singers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SingerModel singer)
        {

            if (ModelState.IsValid)
            {
                var result = _singerService.Update(singer);
                if (result.Status == ResultStatus.Success)
                    return RedirectToAction(nameof(Index));
                if (result.Status == ResultStatus.Exception)
                    return View("Error");
                ModelState.AddModelError("", result.Message);


            }
            return View(singer);
        }

        // GET: Singers/Delete/5


        // POST: Singers/Delete/5
        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirmed(int id)
        {
            var result = _singerService.Delete(id);
            if (result.Status == ResultStatus.Success)
                return RedirectToAction(nameof(Index));
            return View("Error");

        }
    }
}
