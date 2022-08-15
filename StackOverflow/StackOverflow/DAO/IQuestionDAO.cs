using StackOverflow.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflow.DAO
{
    public interface IQuestionDAO
    {
        public void CreateQuestion(Question question);
        public IEnumerable<Question> GetAllQuestions();
        public Question GetQuestionById(int? id);
        public void DeleteQuestion(Question question);

    }
}