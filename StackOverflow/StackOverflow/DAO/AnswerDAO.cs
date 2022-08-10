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

        public List<Answer> GetAllAnswers()
        {
            return _context.Answers.ToList();
        }

        public List<Answer> GetAnswersById(int? id)
        {
            return _context.Answers.Where(a => a.ID == id).ToList();
        }
    }
}
