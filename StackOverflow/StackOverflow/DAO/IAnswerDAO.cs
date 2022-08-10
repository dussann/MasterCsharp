using StackOverflow.Models;
using System.Collections.Generic;

namespace StackOverflow.DAO
{
    public interface IAnswerDAO
    {
        public List<Answer> GetAllAnswers();
        public List<Answer> GetAnswersById(int? id);
    }
}