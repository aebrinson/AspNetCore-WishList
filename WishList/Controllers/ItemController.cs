using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ItemController(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            return View("Index", _context.Items);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Add(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var itemToRemove = _context.Items.Where(x => x.Id == Id).FirstOrDefault();
            _context.Items.Remove(itemToRemove);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
