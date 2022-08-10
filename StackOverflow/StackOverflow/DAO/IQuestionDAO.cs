using StackOverflow.Models;
using System.Collections.Generic;

namespace StackOverflow.DAO
{
    public interface IQuestionDAO
    {
        public void CreateQuestion(Question question);
        public IEnumerable<Question> GetAllQuestions();
        
    }
}