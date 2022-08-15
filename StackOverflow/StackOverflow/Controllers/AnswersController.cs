using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StackOverflow.DAO;
using StackOverflow.Data;
using StackOverflow.Models;

namespace StackOverflow.Controllers
{
    public class AnswersController : Controller
    {
        //private readonly SOContext _context;
        private readonly IAnswerDAO _answerDAO;

        public AnswersController(SOContext context,IAnswerDAO answerDAO)        {
            //_context = context;
            _answerDAO = answerDAO;
        }

        // GET: Answers
       /* public async Task<IActionResult> Index()
        {
            var stackOverflowContext = _context.Answers.Include(a => a.User);
            return View(await stackOverflowContext.ToListAsync());
        }
*/
        // GET: Answers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Answer answer = _answerDAO.GetAnswerById(id);            
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }

        // GET: Answers/Create
        public IActionResult Create(string answer)
        {
            
            int questionId = (int)TempData["questionId"];
            int userId = (int)TempData["userId"];
            Answer answ = new Answer
            {
                Content = answer,
                UserID = userId,
                QuestionID = questionId                
            };
            _answerDAO.CreateAnswer(answ);            
            return RedirectToAction("Details", "Questions",new { id = questionId } );            
        }      

        // GET: Answers/Edit/5
      /*  public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _context.Answers.FindAsync(id);
            if (answer == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.Set<User>(), "ID", "ID", answer.UserID);
            return View(answer);
        }

        // POST: Answers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Content,Raiting,UserID")] Answer answer)
        {
            if (id != answer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(answer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnswerExists(answer.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Set<User>(), "ID", "ID", answer.UserID);
            return View(answer);
        }

        // GET: Answers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _context.Answers
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }

        // POST: Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnswerExists(int id)
        {
            return _context.Answers.Any(e => e.ID == id);
        }*/
    }
}
