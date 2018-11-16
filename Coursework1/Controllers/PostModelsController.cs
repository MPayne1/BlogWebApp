using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Coursework1.Models;
using Microsoft.AspNetCore.Authorization;
using AppContext = Coursework1.Models.AppDataContext;

namespace Coursework1.Controllers
{
    [Authorize]
    public class PostModelsController : Controller
    {
        private readonly AppDataContext _context;

        public PostModelsController(AppDataContext context)
        {
            _context = context;
        }
        
        
        // GET: PostModels
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ViewPostVM> vm = new List<ViewPostVM>();
            List<PostModel> viewPosts = await _context.Post.ToListAsync();
            foreach (var post in viewPosts)
            {
                ViewPostVM temp = new ViewPostVM { Post = post.Post, Description = post.Description, Id = post.Id };
                vm.Add(temp);
            }
            return View(vm);
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

        // Security stuff, santising user input ect.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> Create (CreatePostVM postvm)
        {
           
            if (ModelState.IsValid)
            {
                PostModel post = new PostModel { Post = postvm.Post , Description = postvm.Description};
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postvm);
        }

        

        [HttpGet]
        public async Task<IActionResult> Details(ViewPostVM vm, int? id)
        {
            ViewData["Id"] = id;
            PostModel tempPost = await _context.Post.Where(c => c.Id == id).FirstOrDefaultAsync();
            ViewPostVM postvm = new ViewPostVM { Post = tempPost.Post, Description = tempPost.Description, Id = tempPost.Id };
            return View(postvm);
        }
    }
}

