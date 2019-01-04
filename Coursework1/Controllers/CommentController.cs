using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Coursework1.Models;
using Microsoft.AspNetCore.Authorization;
using System;

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

        // POST: Comment/AddComment
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canComment")]
        public async Task<IActionResult> AddComment(AddCommentVM comment)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("Addcomment post id");
                Console.WriteLine(comment.postId);
                Comment c = new Comment() { CommentMessage = comment.CommentMessage, PostId = comment.postId};
                _context.Add(c);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "PostModels");
            }
            return View(comment);
        }

        // GET: Comment/AddComment
        [HttpGet]
        [Authorize(Roles = "canComment")]
        public IActionResult AddComment()
        {
            ViewData["postId"] = Request.Query["postId"];
            return View();
        }


        //All the comments for the post
        // GET: Comment/CommentsView
        [HttpGet]
        public async Task<IActionResult> CommentsView(int postId)
        {
            ViewData["PostId"] = postId;
            Console.WriteLine(postId);
            List<ViewCommentVM> vm = new List<ViewCommentVM>();
            List<Comment> viewComments = await _context.Comments.Where(c => c.PostId == postId).ToListAsync();
            foreach (var comment in viewComments)
            {
                ViewCommentVM commentvm = new ViewCommentVM { CommentMessage = comment.CommentMessage, Id = comment.Id};
                vm.Add(commentvm);
            }
            return View(vm);
        }

        // GET: Comment/Delete
        [HttpGet]
        [Authorize(Roles = "canDeleteComment")]
        public IActionResult Delete(ViewCommentVM vm)
        {
            return View(vm);
        }


        // POST: Comment/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canDeleteComment")]
        public async Task<IActionResult> Delete(ViewCommentVM cm, int? i)
        {
            Console.WriteLine("Comment delete id" + cm.Id);
            var comment = await _context.Comments.Where(c => c.Id == cm.Id).FirstOrDefaultAsync();
            if(comment == null)
            {
                return RedirectToAction("Index", "Home");
            }
             _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "PostModels");
        } 
    }
}
