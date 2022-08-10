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
    public class QuestionsController : Controller
    {
        private readonly SOContext _context;
        private readonly IQuestionDAO _questionDAO;
        private readonly IAnswerDAO _answerDAO;
        public QuestionsController(IQuestionDAO questionDAO, IAnswerDAO answerDAO)
        {
            _questionDAO = questionDAO;
            _answerDAO = answerDAO;
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {   
            IEnumerable<Question> questions = _questionDAO.GetAllQuestions();
            ViewData["Greeting"] = TempData["userName"];
            return View(questions);            
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            AQViewModel viewModel = new AQViewModel();
            //List<Answer> answers = _context.Answers.Where(a => a.ID == id).ToList();
            //viewModel.Answers = _context.Answers.ToList();
            List<Answer> answers = _answerDAO.GetAnswersById(id);            
            viewModel.Answers = _answerDAO.GetAllAnswers();

            var question = await _context.Questions.Include(q => q.User).FirstOrDefaultAsync(m => m.ID == id);
            viewModel.Question = question;
            if (question == null)
            {
                return NotFound();
            }
            TempData["questionId"] = id;
            return View(viewModel);             
        }

        // GET: Questions/Create
        public IActionResult Create()
        {  
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Question question)
        {
            if (ModelState.IsValid)
            {
                question.UserID = (int)TempData["userId"];
                _questionDAO.CreateQuestion(question);
                return RedirectToAction(nameof(Index));
            }           
            return View(question);
        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", question.UserID);
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Header,Content,UserID")] Question question)
        {
            if (id != question.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.ID))
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
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", question.UserID);
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var question = await _context.Questions.FindAsync(id);
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(e => e.ID == id);
        }
    }
}
