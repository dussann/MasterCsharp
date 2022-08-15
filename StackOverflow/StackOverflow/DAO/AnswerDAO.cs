using StackOverflow.Data;
using StackOverflow.Models;
using System.Collections.Generic;
using System.Linq;

namespace StackOverflow.DAO
{
    public class AnswerDAO: IAnswerDAO
    {
        private readonly SOContext _context;
        public AnswerDAO(SOContext context)
        {
            _context = context;
        }

        public void CreateAnswer(Answer answer)
        {
            _context.Answers.Add(answer);
            _context.SaveChanges();
        }

        public List<Answer> GetAllAnswers()
        {
            return _context.Answers.ToList();
        }

        public Answer GetAnswerById(int? id)
        {            
            return _context.Answers.FirstOrDefault(answer=>answer.ID==id);
        }

        public List<Answer> GetAnswersByQuestionId(int? id)
        {            
            return _context.Answers.Where(answer=>answer.QuestionID == id).ToList();
        }
    }
}
