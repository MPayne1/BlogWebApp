using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Coursework1.Models;

namespace Coursework1.Controllers
{
    public class PostModelsController : Controller
    {
        private readonly DataContext _context;

        public PostModelsController(DataContext context)
        {
            _context = context;
        }
        

        // GET: PostModels
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            Console.Write("post models index");
            return View(await _context.Post.ToListAsync());
        }




        // GET: PostModels/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        // POST: PostModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Post")] PostModel postModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postModel);
        }

    }
}
