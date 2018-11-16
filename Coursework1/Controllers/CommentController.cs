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
    public class CommentController : Controller
    {
        private readonly AppDataContext _context;

        public CommentController(AppDataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(int id, AddCommentVM comment)
        {
            if (ModelState.IsValid)
            {

                Comment c = new Comment() { CommentMessage = comment.CommentMessage, PostId = id };
                _context.Add(c);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "PostModels");
            }
            return View(comment);
        }


        [HttpGet]
        public IActionResult AddComment()
        {
            return View();
        }


        //All the comments for the post
        [HttpGet]
        public async Task<IActionResult> CommentsView(int? id)
        {
            ViewData["PostId"] = id;
            return View(await _context.Comments.Where(c => c.PostId == id).ToListAsync());
        }

    }
}
