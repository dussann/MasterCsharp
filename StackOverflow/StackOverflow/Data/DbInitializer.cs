using StackOverflow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverflow.Data
{
    public class DbInitializer
    {
        public static void Initialize(SOContext context)
        {
            try
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();/*

                User u1 = new User { FirstName = "Pera", Country = "Serbia", JobTitle = "Software developer", UserName = "Pera", Password = "Pera" };
                User u2 = new User { FirstName = "Pera1", Country = "Serbia", JobTitle = "Software developer", UserName = "Pera1", Password = "Pera1" };
                context.Users.Add(u1);
                context.Users.Add(u2);
                context.SaveChanges();
                Question question = new Question { User = u1, Content = "First question", Header = "header of first question" };
                context.Questions.Add(question);
                context.SaveChanges();
                Answer answer = new Answer { User = u1, Question = question, Content = "Answer ond question1" };
                context.Answers.Add(answer);
                context.SaveChanges();
                Answer comment = new Answer() { User = u2, Content = "Thisi is comment on firstr answer", Comment = answer };                
                context.Answers.Add(comment);
                context.SaveChanges();
                answer.Comments = new List<Answer>();
                answer.Comments.Add(comment);
                
                context.SaveChanges();


                Question q = new Question { Content = "First question", Header = "Js issueo with arrays", User = u1 };
                Question q1 = new Question { Content = "First question", Header = "What is dependency injection", User = u1 };
                Question q2 = new Question { Content = "First question", Header = "What is singleton", User = u1 };
                Question q3 = new Question { Content = "First question", Header = "What are microservices", User = u2 };
                context.Questions.Add(q);
                context.Questions.Add(q1);
                context.Questions.Add(q2);
                context.Questions.Add(q3);
                context.SaveChanges();

                Answer a = new Answer { Content = "Answer content", Raiting = 10, User = u1,Question=q};
                //q.Answers.Add(a);
                context.Answers.Add(a);
                context.SaveChanges();*/
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }
    }
}
