using Microsoft.EntityFrameworkCore;
using StackOverflow.Data;
using StackOverflow.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverflow.DAO
{
    public class QuestionDAO: IQuestionDAO
    {
        private readonly SOContext _context;
        public QuestionDAO(SOContext context)
        {
            _context = context;
        }

        public void CreateQuestion(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
        }

        public void DeleteQuestion(Question question)
        {
            _context.Questions.Remove(question);
            _context.SaveChanges();
        }

        public IEnumerable<Question> GetAllQuestions()
        {
            return _context.Questions;
        }

        public Question GetQuestionById(int? id)
        {
            return _context.Questions.FirstOrDefault(q => q.ID == id);
        }
    }
}
