using StackOverflow.Models;
using System.Collections.Generic;

namespace StackOverflow.DAO
{
    public interface IAnswerDAO
    {
        public void CreateAnswer(Answer answer);
        public List<Answer> GetAllAnswers();
        public Answer GetAnswerById(int? id);
        public List<Answer> GetAnswersByQuestionId(int? id);        
    }
}