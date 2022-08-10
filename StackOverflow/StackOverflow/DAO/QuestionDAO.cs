using Microsoft.EntityFrameworkCore;
using StackOverflow.Data;
using StackOverflow.Models;
using System.Collections.Generic;

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

        public IEnumerable<Question> GetAllQuestions()
        {
            return _context.Questions;
        }
    }
}
