using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Coursework1.Models;
using Microsoft.AspNetCore.Authorization;

namespace Coursework1.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly AppDataContext _context;

        public CommentController(AppDataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canComment")]
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
        [Authorize(Roles = "canComment")]
        public IActionResult AddComment()
        {
            return View();
        }


        //All the comments for the post
        [HttpGet]
        public async Task<IActionResult> CommentsView(int? id)
        {
            ViewData["PostId"] = id;

            List<ViewCommentVM> vm = new List<ViewCommentVM>();
            List<Comment> viewComments = await _context.Comments.Where(c => c.PostId == id).ToListAsync();
            foreach (var comment in viewComments)
            {
                ViewCommentVM commentvm = new ViewCommentVM { CommentMessage = comment.CommentMessage };
                vm.Add(commentvm);
            }
            return View(vm);
        }

        //[HttpGet]
        //[AllowAnonymous]
        //public  IActionResult AccessDenied()
        //{
        //    // do accessdenied page
           
        //}

    }
}
